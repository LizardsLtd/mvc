namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System.Collections.Generic;
    using Lizards.Data.CQRS;
    using Lizards.Data.Events;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    /// <summary>
    ///
    /// </summary>
    public sealed class InMemoryCQRSBusesShard : ShardBase
    {
        protected override void ConfigureServices(IServiceCollection services, IEnumerable<object> arguments)
        {
            services.TryAddSingleton<ICommandBus, CommandBus>();
            services.TryAddSingleton<IEventBus, EventBus>();
        }
    }
}