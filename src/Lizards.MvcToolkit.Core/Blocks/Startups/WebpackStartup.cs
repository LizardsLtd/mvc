namespace Lizards.MvcToolkit.Core.Blocks
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Lizards.MvcToolkit.Core.Blocks.Defaults;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Routing;
  using Microsoft.Extensions.Configuration;

  public abstract class WebpackStartup : IConfigurationBlock
  {
    public void Apply(StartupConfigurations host)
    {
      host.Apply(new MvcRouteConfigurationBlock(this.GetRoutes()));
      host.Apply<WebpackBlock>();
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
