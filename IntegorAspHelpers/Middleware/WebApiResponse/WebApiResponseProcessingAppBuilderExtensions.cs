using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;

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
            app.UseMiddleware<WebApiStatusCodesHandlingMiddleware>(bodyWriter, checkProcessingRequired);
        }
    }
}
