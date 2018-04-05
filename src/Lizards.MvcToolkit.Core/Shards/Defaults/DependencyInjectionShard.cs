namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Lizards.MvcToolkit.Core.Shards;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class DependencyInjectionShard : ShardBase
    {
        private readonly List<Action<IServiceCollection>> configurationActions;

        public DependencyInjectionShard(params Action<IServiceCollection>[] configurationActions)
        {
            this.configurationActions = configurationActions.ToList();
        }

        protected override void ConfigureServices(IServiceCollection services)
            => configurationActions.ForEach(x => x(services));
    }
}