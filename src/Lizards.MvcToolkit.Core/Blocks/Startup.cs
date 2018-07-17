namespace Lizards.MvcToolkit.Core.Blocks
{
  using System;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using SimpleInjector;

  public abstract class Startup
  {
    private readonly Container container;
    private readonly StartupConfigurations startupConfiguration;

    protected Startup(IHostingEnvironment env, IConfiguration configuration)
    {
      this.startupConfiguration = new StartupConfigurations(env, configuration);
      this.container = new Container();
    }

    public IConfiguration Configuration => this.startupConfiguration.Configuration;

    public IHostingEnvironment Environment => this.startupConfiguration.Environment;

    public Startup ConfigureOptions<TOption>(Action<TOption> configure)
        where TOption : class
    {
      this.startupConfiguration.Services.Configure(configure);

      return this;
    }

    public Startup ConfigureOptions<TOption>(Action<IConfiguration, TOption> configure)
        where TOption : class
    {
      this.startupConfiguration.Services.Configure<TOption>(options => configure(this.Configuration, options));

      return this;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      this.startupConfiguration.IntegrateSimpleInjector(services);
      this.startupConfiguration.MVC.AddMvc(services);
      this.startupConfiguration.Razor.Use(services);
      this.startupConfiguration.Services.Use(services);
    }

    public void Configure(IApplicationBuilder app)
    {
      this.startupConfiguration.InitializeContainerWithinApplicationBuilder(app);

      this.startupConfiguration.ASP.Use(app, this.Environment);
      this.startupConfiguration.MVC.Use(app);

      container.Verify();
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
