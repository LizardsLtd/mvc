namespace Lizards.MvcToolkit.Core.Startup
{
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.AspNetCore.Routing;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class MvcConfig
  {
    public MvcConfig()
    {
      Options = new Configurator<MvcOptions>();
      Routes = new Configurator<IRouteBuilder>();
    }

    public Configurator<MvcOptions> Options { get; }

    public Configurator<IRouteBuilder> Routes { get; }

    internal void AddMvc(IServiceCollection services)
    {
      var mvcBuilder = services
          .AddMvc(CreateMvcOptions)
          .AddViewLocalization();
    }

    internal void Use(IApplicationBuilder app)
    {
      app.UseMvc(routes => this.Routes.Execute(routes));
    }

    private void CreateMvcOptions(MvcOptions options)
        => this.Options.Execute(options);
  }
}
