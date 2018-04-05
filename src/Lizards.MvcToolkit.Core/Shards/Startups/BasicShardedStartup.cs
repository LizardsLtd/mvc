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
        protected BasicShardedStartup(IHostingEnvironment env, IConfiguration configuration)
            : base(env, configuration)
        {
            this.ApplyDefault<FeaturesShard>();
            this.ApplyDefault<UseStaticFiles>();
            this.ApplyDefault(new ExceptionHandlingShard(this.ExceptionHandlingRoute));
            this.ApplyDefault(new MvcRouteConfigurationShard(this.GetRoutes()));
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