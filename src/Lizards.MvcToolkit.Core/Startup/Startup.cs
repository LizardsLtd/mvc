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
      this.startupConfiguration.Services.AutoScan(services);
    }

    public void Configure(IApplicationBuilder app)
    {
      this.startupConfiguration.ASP.Use(app, this.Environment);
      this.startupConfiguration.MVC.Use(app);
    }

    public Startup Apply<TDefault>()
           where TDefault : IConfigurationBlock, new()
       => this.Apply(new TDefault());

    public Startup Apply(IConfigurationBlock @default)
    {
      this.startupConfiguration.Apply(@default);

      return this;
    }

    protected virtual void AddConfigurationBuilderDetails(ConfigurationBuilder provider)
    {
    }
  }
}
