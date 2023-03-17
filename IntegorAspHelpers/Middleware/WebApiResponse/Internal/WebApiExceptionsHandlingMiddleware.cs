using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using IntegorErrorsHandling;
using IntegorSharedErrorHandlers.Converters;

namespace IntegorAspHelpers.Middleware.WebApiResponse.Internal
{
    public class WebApiExceptionsHandlingMiddleware
    {
		private RequestDelegate _next;

		private IResponseErrorObjectCompiler _errorsCompiler;
        private StatusCodeErrorConverter _statusCodeConverter;

		private WriteBodyDelegate _writeBody;

		public WebApiExceptionsHandlingMiddleware(
			RequestDelegate next,

            IResponseErrorObjectCompiler errorsCompiler,
            StatusCodeErrorConverter statusCodeConverter,

			WriteBodyDelegate bodyWriter)
        {
			_next = next;

            _errorsCompiler = errorsCompiler;
            _statusCodeConverter = statusCodeConverter;

			_writeBody = bodyWriter;
		}

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch
            {
                await SendErrorAsync(context.Response);
            }
        }

        private async Task SendErrorAsync(HttpResponse response)
        {
            response.Clear();

            response.StatusCode = StatusCodes.Status500InternalServerError;

            object body = GenerateErrorBody(response.StatusCode);
            await _writeBody.Invoke(response, body);
        }

        private object GenerateErrorBody(int statusCode)
        {
            IErrorConvertationResult error = _statusCodeConverter.Convert(statusCode)!;
            return _errorsCompiler.CompileResponse(error);
        }
    }
}
