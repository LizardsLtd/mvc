using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Lizards.MvcToolkit.Core.Shards
{
    public abstract class ArgumentLessShardBase : ShardBase<object>
    {
        protected virtual void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
            => this.ConfigureApp(app, env, null);

        protected virtual void ConfigureServices(IServiceCollection services)
            => this.ConfigureServices(services, null);
    }
}