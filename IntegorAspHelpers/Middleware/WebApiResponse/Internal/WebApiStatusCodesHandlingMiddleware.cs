﻿using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

using IntegorAspHelpers.Http;

using IntegorErrorsHandling;
using IntegorSharedErrorHandlers.Converters;

namespace IntegorAspHelpers.Middleware.WebApiResponse.Internal
{
	public class WebApiStatusCodesHandlingMiddleware : IMiddleware
    {
        private IResponseErrorObjectCompiler _errorsCompiler;
        private StatusCodeErrorConverter _statusCodeConverter;

		private WriteBodyDelegate _writeBody;
		private ValidateHttpContextActionDelegate _checkProcessingRequired;

		public WebApiStatusCodesHandlingMiddleware(
            IResponseErrorObjectCompiler errorsCompiler,
            StatusCodeErrorConverter statusCodeConverter,

			WriteBodyDelegate bodyWriter,
			ValidateHttpContextActionDelegate? checkProcessingRequired = null)
        {
            _errorsCompiler = errorsCompiler;
            _statusCodeConverter = statusCodeConverter;

			_writeBody = bodyWriter;
			_checkProcessingRequired = checkProcessingRequired ?? CheckContextProcessUnmarked;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next.Invoke(context);

            if (_checkProcessingRequired.Invoke(context))
                return;

            HttpResponse response = context.Response;

			IErrorConvertationResult errors = _statusCodeConverter.Convert(response.StatusCode)!;
			object body = _errorsCompiler.CompileResponse(errors);

			await _writeBody.Invoke(response, body);
		}

		private bool CheckContextProcessUnmarked(HttpContext context)
		{
			IHttpContextProcessedMarker processedMarker =
				context.RequestServices.GetRequiredService<IHttpContextProcessedMarker>();

			return !processedMarker.IsProcessed();
		}
    }
}