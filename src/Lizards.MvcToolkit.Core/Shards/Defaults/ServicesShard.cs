namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class ServicesShard : ConfigurableShardBase<IEnumerable<Action<IServiceCollection>>>
  {
    public ServicesShard(Func<IEnumerable<Action<IServiceCollection>>> optionsFactory)
      : base(optionsFactory) { }

    protected override void ConfigureServices(IServiceCollection services, IEnumerable<Action<IServiceCollection>> options)
      => options.ToList().ForEach(applyThis => applyThis(services));
  }
}
