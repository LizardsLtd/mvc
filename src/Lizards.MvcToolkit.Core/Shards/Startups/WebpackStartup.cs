namespace Lizards.MvcToolkit.Core.Shards
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Lizards.MvcToolkit.Core.Shards.Defaults;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Configuration;

    public abstract class WebpackStartup : BasicShardedStartup
    {
        protected WebpackStartup(IHostingEnvironment env, IConfiguration configuration)
            : base(env, configuration)
        {
            this.ApplyDefault<WebpackShard>();
        }

        public override IEnumerable<Action<IRouteBuilder>> GetRoutes()
        {
            var routes = new Action<IRouteBuilder>[]
            {
                r => r.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" }),
            };

            return base.GetRoutes().Union(routes);
        }
    }
}