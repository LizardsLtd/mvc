namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System;

    public sealed class OptionsShard<TOptions> : IConfigurableShard<Action<TOptions>>
        where TOptions : class
    {
        public OptionsShard(Action<TOptions> options)
        {
            this.Options = options;
        }

        public Action<TOptions> Options { get; }

        public void Apply(StartupConfigurations host)
            => host.Services.Configure(this.Options);
    }
}