namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Lizards.MvcToolkit.Core.Startup;
  using Microsoft.AspNetCore.Routing;

  public sealed class MvcRouteConfigurationBlock : IConfigurationBlockWithOption<IEnumerable<Action<IRouteBuilder>>>
  {
    public MvcRouteConfigurationBlock(IEnumerable<Action<IRouteBuilder>> options)
    {
      this.Options = options;
    }

    public IEnumerable<Action<IRouteBuilder>> Options { get; }

    public void Apply(StartupConfigurations host)
        => this.Options
            .ToList()
            .ForEach(routeBuilder => host.MVC.Routes.Add(routeBuilder));
  }
}
