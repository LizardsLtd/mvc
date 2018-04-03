namespace Lizards.MvcToolkit.Core.Shards
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class ShardBase<TArgument> : IShard<TArgument>
    {
        protected IConfiguration Configuration { get; private set; }

        protected MvcConfig Mvc { get; private set; }

        public void Apply(StartupConfigurations host, TArgument arguments)
        {
            this.Configuration = host.Configuration;
            this.Mvc = host.MVC;

            this.Configure();
            host.ASP.Add((app, env) => this.ConfigureApp(app, env, arguments));
            host.Services.Add(services => this.ConfigureServices(services, arguments));
        }

        protected virtual void Configure()
        {
        }

        protected virtual void ConfigureApp(
            IApplicationBuilder app,
            IHostingEnvironment env,
            TArgument arguments)
        {
        }

        protected virtual void ConfigureServices(IServiceCollection services, TArgument arguments)
        {
        }
    }
}