namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.SpaServices.Webpack;

    public sealed class WebpackShard : ShardBase
    {
        protected override void ConfigureApp(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IEnumerable<object> arguments)
        {
            if (env.IsDevelopment())
            {
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                });
            }
        }
    }
}