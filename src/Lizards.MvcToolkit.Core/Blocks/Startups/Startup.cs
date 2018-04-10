namespace Lizards.MvcToolkit.Core.Blocks
{
  using System;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  public abstract class Startup
  {
    private readonly StartupConfigurations configuration;

    protected Startup(IHostingEnvironment env, IConfiguration configuration)
    {
      this.configuration = new StartupConfigurations(env, configuration);
    }

    public IConfiguration Configuration => this.configuration.Configuration;

    public IHostingEnvironment Environment => this.configuration.Environment;

    public Startup ConfigureOptions<TOption>(Action<TOption> configure)
        where TOption : class
    {
      this.configuration.Services.Configure(configure);

      return this;
    }

    public Startup ConfigureOptions<TOption>(Action<IConfiguration, TOption> configure)
        where TOption : class
    {
      this.configuration.Services.Configure<TOption>(options => configure(this.Configuration, options));

      return this;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      this.configuration.MVC.AddMvc(services);
      this.configuration.Razor.Use(services);
      this.configuration.Services.Use(services);
    }

    public void Configure(IApplicationBuilder app)
    {
      this.configuration.ASP.Use(app, this.Environment);
      this.configuration.MVC.Use(app);
    }

    public void ApplyDefault<TDefault>()
           where TDefault : IConfigurationBlock, new()
       => this.ApplyDefault(new TDefault());

    public void ApplyDefault(IConfigurationBlock @default)
    {
      this.configuration.Apply(@default);
    }

    protected virtual void AddConfigurationBuilderDetails(ConfigurationBuilder provider)
    {
    }
  }
}
