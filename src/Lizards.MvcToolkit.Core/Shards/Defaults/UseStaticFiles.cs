namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    public sealed class UseStaticFiles : ExtendednShardBase

    {
        protected override void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
            => app.UseStaticFiles();
    }
}