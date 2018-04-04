namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using Lizards.Data.CQRS;
    using Lizards.Data.Events;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /// <summary>
    ///
    /// </summary>
    public sealed class InMemoryCQRSBusesShard : ExtendednShardBase
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<ICommandBus, CommandBus>();
            services.TryAddSingleton<IEventBus, EventBus>();
        }
    }
}