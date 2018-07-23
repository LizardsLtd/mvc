namespace Lizards.MvcToolkit.Core.Startup
{
  using Lamar;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Http;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  public abstract class Startup
  {
    private readonly StartupConfigurations startupConfiguration;

    protected Startup(IHostingEnvironment env, IConfiguration configuration)
    {
      this.startupConfiguration = new StartupConfigurations(env, configuration);
    }

    public IConfiguration Configuration => this.startupConfiguration.Configuration;

    public IHostingEnvironment Environment => this.startupConfiguration.Environment;

    public void ConfigureServices(IServiceCollection services)
    {
      this.startupConfiguration.MVC.AddMvc(services);
      this.startupConfiguration.Razor.Use(services);
    }

    public void ConfigureContainer(ServiceRegistry services)
    {
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
      this.startupConfiguration.Services.Use(services);
    }

    public void Configure(IApplicationBuilder app)
    {
      this.startupConfiguration.ASP.Use(app, this.Environment);
      this.startupConfiguration.MVC.Use(app);
    }

    public void ApplyDefault<TDefault>()
           where TDefault : IConfigurationBlock, new()
       => this.ApplyDefault(new TDefault());

    public void ApplyDefault(IConfigurationBlock @default)
    {
      this.startupConfiguration.Apply(@default);
    }

    protected virtual void AddConfigurationBuilderDetails(ConfigurationBuilder provider)
    {
    }
  }
}
