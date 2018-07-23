namespace Lizards.MvcToolkit.Core.Startup
{
  using System;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;

  public abstract class ConfigurationBlockWithOptionBase<TOption> : IConfigurationBlockWithOption<TOption>
  {
    private readonly Lazy<TOption> options;

    protected ConfigurationBlockWithOptionBase(Func<TOption> optionsFactory)
        : this(new Lazy<TOption>(optionsFactory)) { }

    protected ConfigurationBlockWithOptionBase(TOption options)
        : this(new Lazy<TOption>(() => options)) { }

    protected ConfigurationBlockWithOptionBase(Lazy<TOption> options)
        => this.options = options;

    public TOption Options => this.options.Value;

    protected IConfiguration Configuration { get; private set; }

    protected MvcConfig Mvc { get; private set; }

    public void Apply(StartupConfigurations host)
    {
      this.Configuration = host.Configuration;
      this.Mvc = host.MVC;

      this.Configure();
      host.ASP.Add((app, env) => this.ConfigureApp(app, env, this.Options));
      host.Services.Add(services => this.ConfigureServices(services, this.Options));
    }

    protected virtual void Configure()
    {
    }

    protected virtual void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env, TOption options)
    {
    }

    protected virtual void ConfigureServices(IServiceCollection services, TOption options)
    {
    }
  }
}
