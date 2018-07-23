namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using Lamar;
  using Lizards.Data.CQRS;
  using Lizards.Data.Events;
  using Lizards.MvcToolkit.Core.Startup;
  using Microsoft.Extensions.DependencyInjection.Extensions;

  /// <summary>
  /// COnfigures services to run in memory
  /// </summary>
  /// <seealso cref="Lizards.MvcToolkit.Core.Startup.ConfigurationBlockBase" />
  public sealed class InMemoryCQRSBusesBlock : ConfigurationBlockBase
  {
    protected override void ConfigureServices(ServiceRegistry services)
    {
      services.TryAddSingleton<ICommandBus, CommandBus>();
      services.TryAddSingleton<IEventBus, EventBus>();
    }
  }
}
