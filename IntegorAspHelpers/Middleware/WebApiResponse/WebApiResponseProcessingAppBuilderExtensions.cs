using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

using IntegorAspHelpers.Http;

namespace IntegorAspHelpers.Middleware.WebApiResponse
{
	using Internal;

	public static class WebApiResponseProcessingAppBuilderExtensions
    {
        public static void UseWebApiExceptionsHandling(this IApplicationBuilder app, WriteBodyDelegate bodyWriter)
        {
            app.UseMiddleware<WebApiExceptionsHandlingMiddleware>(bodyWriter);
        }

        public static void UseWebApiStatusCodesHandling(this IApplicationBuilder app, WriteBodyDelegate bodyWriter, ValidateHttpContextActionDelegate? checkProcessingRequired = null)
        {
            app.UseMiddleware<WebApiStatusCodesHandlingMiddleware>(bodyWriter, checkProcessingRequired ?? CheckContextProcessUnmarked);
        }

		private static bool CheckContextProcessUnmarked(HttpContext context)
		{
			IHttpContextProcessedMarker processedMarker =
				context.RequestServices.GetRequiredService<IHttpContextProcessedMarker>();

			return !processedMarker.IsProcessed();
		}
	}
}
