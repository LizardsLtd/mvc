namespace Lizards.MvcToolkit.Core.Shards
{
    using System;
    using System.Collections.Generic;
    using Lizards.MvcToolkit.Core.Shards.Defaults;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;

    public abstract class BasicShardedStartup : ShardedStartup
    {
        public Action<IRouteBuilder>[] Routes =
            new Action<IRouteBuilder>[]
            {
                routes => routes.MapRoute(
                            name: "default",
                            template: "{controller=Home}/{action=Index}/{id?}"),

                routes => routes.MapSpaFallbackRoute(
                            name: "spa-fallback",
                            defaults: new { controller = "Home", action = "Index" }),
            };

        protected BasicShardedStartup(IHostingEnvironment env, IConfiguration configuration)
            : base(env, configuration)
        {
            this.ApplyDefault<FeaturesShard>();
            this.ApplyDefault<UseStaticFiles>();
            this.ApplyDefault<DevelopmentSetup>();

            this.ApplyDefault<RouteShard, IEnumerable<Action<IRouteBuilder>>>(this.Routes);
        }
    }
}