namespace Lizards.MvcToolkit.Core.Blocks
{
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Http;
  using Microsoft.AspNetCore.Mvc.Controllers;
  using Microsoft.AspNetCore.Mvc.ViewComponents;
  using Microsoft.Extensions.Configuration;
  using Microsoft.Extensions.DependencyInjection;
  using SimpleInjector;
  using SimpleInjector.Integration.AspNetCore.Mvc;
  using SimpleInjector.Lifestyles;

  public sealed class StartupConfigurations
  {
    /// <summary>Record Constructor</summary>
    /// <param name="mVC"><see cref="MVC"/></param>
    /// <param name="aSP"><see cref="ASP"/></param>
    /// <param name="razor"><see cref="Razor"/></param>
    /// <param name="environment"><see cref="Environment"/></param>
    /// <param name="configurationRoot"><see cref="Configuration"/></param>
    internal StartupConfigurations(IHostingEnvironment environment, IConfiguration configuration)
    {
      this.MVC = new MvcConfig();
      this.ASP = new AspConfigurator();
      this.Razor = new RazorConfig();
      this.Services = new ServicesConfigurator();
      this.Container = CreateContainer();
      this.Environment = environment;
      this.Configuration = configuration;
    }

    public MvcConfig MVC { get; }

    public AspConfigurator ASP { get; }

    public RazorConfig Razor { get; }

    public ServicesConfigurator Services { get; }

    public Container Container { get; }

    public IHostingEnvironment Environment { get; }

    public IConfiguration Configuration { get; }

    internal void Apply<TDefault>() where TDefault : IConfigurationBlock, new()
        => this.Apply(new TDefault());

    internal void Apply(IConfigurationBlock @default)
        => @default.Apply(this);

    internal void InitializeContainerWithinApplicationBuilder(IApplicationBuilder app)
    {
      this.Container.RegisterMvcControllers(app);
      this.Container.RegisterMvcViewComponents(app);
      this.Container.AutoCrossWireAspNetComponents(app);
    }

    internal void IntegrateSimpleInjector(IServiceCollection services)
    {
      services.AddSingleton<IControllerActivator>(
        new SimpleInjectorControllerActivator(this.Container));
      services.AddSingleton<IViewComponentActivator>(
          new SimpleInjectorViewComponentActivator(this.Container));

      services.EnableSimpleInjectorCrossWiring(this.Container);
      services.UseSimpleInjectorAspNetRequestScoping(this.Container);
    }

    private Container CreateContainer()
    {
      var container = new Container();
      this.Container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
      container.Register<IHttpContextAccessor, HttpContextAccessor>();

      return container;
    }
  }
}
