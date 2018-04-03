namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Lizards.MvcToolkit.Core.Shards;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class DependencyInjectionDefault : ShardBase
    {
        private readonly List<Action<IServiceCollection>> configurationActions;

        public DependencyInjectionDefault(params Action<IServiceCollection>[] configurationActions)
        {
            this.configurationActions = configurationActions.ToList();
        }

        protected override void ConfigureServices(IServiceCollection services, IEnumerable<object> arguments)
            => configurationActions.ForEach(x => x(services));
    }
}