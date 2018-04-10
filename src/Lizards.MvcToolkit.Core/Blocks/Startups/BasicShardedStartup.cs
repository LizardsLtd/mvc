namespace Lizards.MvcToolkit.Core.Blocks
{
    using System;
    using System.Collections.Generic;
    using Lizards.MvcToolkit.Core.Blocks.Defaults;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;

    public abstract class BasicBlockedStartup : BlockedStartup
    {
        protected BasicBlockedStartup(IHostingEnvironment env, IConfiguration configuration)
            : base(env, configuration)
        {
            this.ApplyDefault<FeaturesBlock>();
            this.ApplyDefault<UseStaticFilesBlock>();
            this.ApplyDefault(new ExceptionHandlingBlock(this.ExceptionHandlingRoute));
            this.ApplyDefault(new MvcRouteConfigurationBlock(this.GetRoutes()));
        }

        protected abstract string ExceptionHandlingRoute { get; }

        public virtual IEnumerable<Action<IRouteBuilder>> GetRoutes()
        {
            yield return routes => routes.MapRoute(
                            name: "default",
                            template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}