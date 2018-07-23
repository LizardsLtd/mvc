namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Lizards.MvcToolkit.Core.Startup;
  using Microsoft.AspNetCore.Mvc;

  public sealed class MvcOptionsConfigurationBlock : IConfigurationBlockWithOption<IEnumerable<Action<MvcOptions>>>
  {
    public MvcOptionsConfigurationBlock(IEnumerable<Action<MvcOptions>> options)
    {
      this.Options = options;
    }

    public IEnumerable<Action<MvcOptions>> Options { get; }

    public void Apply(StartupConfigurations host)
        => this.Options
            .ToList()
            .ForEach(routeBuilder => host.MVC.Options.Add());
  }
}
