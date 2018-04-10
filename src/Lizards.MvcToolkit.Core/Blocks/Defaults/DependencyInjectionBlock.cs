namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Lizards.MvcToolkit.Core.Blocks;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class DependencyInjectionBlock : ConfigurationBlockBase
  {
    private readonly List<Action<IServiceCollection>> configurationActions;

    public DependencyInjectionBlock(params Action<IServiceCollection>[] configurationActions)
    {
      this.configurationActions = configurationActions.ToList();
    }

    protected override void ConfigureServices(IServiceCollection services)
        => configurationActions.ForEach(x => x(services));
  }
}