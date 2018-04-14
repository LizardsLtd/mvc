namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using System;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class ServicesBlock : ConfigurationBlockWithOptionBase<Action<IServiceCollection>>
  {
    public ServicesBlock(Action<IServiceCollection> optionsFactory)
      : base(optionsFactory) { }

    protected override void ConfigureServices(IServiceCollection services, Action<IServiceCollection> options)
      => options(services);
  }
}
