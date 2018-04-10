namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
    using System;

    public sealed class OptionsBlock<TOptions> : IConfigurationBlockWithOption<Action<TOptions>>
        where TOptions : class
    {
        public OptionsBlock(Action<TOptions> options)
        {
            this.Options = options;
        }

        public Action<TOptions> Options { get; }

        public void Apply(StartupConfigurations host)
            => host.Services.Configure(this.Options);
    }
}