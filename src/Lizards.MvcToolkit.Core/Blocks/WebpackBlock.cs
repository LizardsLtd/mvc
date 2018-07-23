namespace Lizards.MvcToolkit.Core.Blocks
{
  using System;
  using System.Collections.Generic;
  using Lizards.MvcToolkit.Core.Blocks.Defaults;
  using Lizards.MvcToolkit.Core.Startup;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Routing;
  using Microsoft.AspNetCore.SpaServices.Webpack;

  public sealed class WebpackBlock : IConfigurationBlock
  {
    public void Apply(StartupConfigurations host)
    {
      host.Apply(new MvcRouteConfigurationBlock(this.GetRoutes()));

      host.ASP.Add(this.ConfigureApp);
    }

    private void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
        {
          HotModuleReplacement = true,
        });
      }
    }

    private IEnumerable<Action<IRouteBuilder>> GetRoutes()
    {
      yield return routes
        => routes.MapSpaFallbackRoute(
            name: "spa-fallback",
            defaults: new { controller = "Home", action = "Index" });
    }
  }
}
