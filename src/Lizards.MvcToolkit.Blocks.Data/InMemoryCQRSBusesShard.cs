namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
    using Lizards.Data.CQRS;
    using Lizards.Data.Events;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /// <summary>
    ///
    /// </summary>
    public sealed class InMemoryCQRSBusesShard : ShardBase
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<ICommandBus, CommandBus>();
            services.TryAddSingleton<IEventBus, EventBus>();
        }
    }
}