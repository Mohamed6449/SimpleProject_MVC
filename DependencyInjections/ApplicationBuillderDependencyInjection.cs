﻿using Microsoft.Extensions.Options;

namespace MCV_Empity.DependencyInjections
{
    public static class ApplicationBuillderDependencyInjection
    {
        public static IApplicationBuilder AddApplicationBuillderDependencyInjection(this IApplicationBuilder app,IServiceProvider serviceProvider)
        {



            #region Loclization middleware
            var options = serviceProvider.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options!.Value);
            #endregion



            return app;

        }

    }
}
