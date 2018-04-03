namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    public sealed class UseStaticFiles : ShardBase
    {
        protected override void ConfigureApp(
                IApplicationBuilder app
                , IHostingEnvironment env
                , IEnumerable<object> arguments)
            => app.UseStaticFiles();
    }
}