namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
  using System;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class ServicesShard : ConfigurableShardBase<Action<IServiceCollection>>
  {
    public ServicesShard(Func<Action<IServiceCollection>> optionsFactory)
      : base(optionsFactory) { }

    protected override void ConfigureServices(IServiceCollection services, Action<IServiceCollection> options)
      => options(services);
  }
}
