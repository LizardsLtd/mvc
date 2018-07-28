namespace Lizzards.MvcToolkit.Blocks.Data
{
  using System;
  using Lamar;
  using Lizzards.MvcToolkit.Core.Startup;

  public sealed class QueriesCachingBlock : ConfigurationBlockBase
  {
    private readonly Action<ServiceRegistry> preconfigureOnOfDistributedCacheOption;

    public QueriesCachingBlock(Action<ServiceRegistry> preconfigureOnOfDistributedCacheOption)
    {
      this.preconfigureOnOfDistributedCacheOption = preconfigureOnOfDistributedCacheOption;
    }

    protected override void ConfigureServices(ServicesConfigurator config)
    {
      config.Add(this.preconfigureOnOfDistributedCacheOption);
      config.AddConvention(new QueriesCachingConvention());
    }
  }
}
