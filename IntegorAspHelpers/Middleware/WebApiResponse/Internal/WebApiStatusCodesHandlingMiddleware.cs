using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

using IntegorAspHelpers.Http;

using IntegorErrorsHandling;
using IntegorSharedErrorHandlers.Converters;

namespace IntegorAspHelpers.Middleware.WebApiResponse.Internal
{
	public class WebApiStatusCodesHandlingMiddleware
    {
		private RequestDelegate _next;

		private IResponseErrorObjectCompiler _errorsCompiler;
        private StatusCodeErrorConverter _statusCodeConverter;

		private WriteBodyDelegate _writeBody;
		private ValidateHttpContextActionDelegate _checkProcessingRequired;

		public WebApiStatusCodesHandlingMiddleware(
			RequestDelegate next,

            IResponseErrorObjectCompiler errorsCompiler,
            StatusCodeErrorConverter statusCodeConverter,

			WriteBodyDelegate bodyWriter,
			ValidateHttpContextActionDelegate checkProcessingRequired)
        {
			_next = next;

            _errorsCompiler = errorsCompiler;
            _statusCodeConverter = statusCodeConverter;

			_writeBody = bodyWriter;
			_checkProcessingRequired = checkProcessingRequired;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);

            if (_checkProcessingRequired.Invoke(context))
                return;

            HttpResponse response = context.Response;

			IErrorConvertationResult errors = _statusCodeConverter.Convert(response.StatusCode)!;
			object body = _errorsCompiler.CompileResponse(errors);

			await _writeBody.Invoke(response, body);
		}
    }
}
