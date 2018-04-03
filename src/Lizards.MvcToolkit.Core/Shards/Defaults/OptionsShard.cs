namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System;

    public sealed class OptionsShard<TOptions> : IShard<Action<TOptions>>
        where TOptions : class
    {
        public void Apply(StartupConfigurations host, Action<TOptions> arguments)
        {
            host.Services.Configure(arguments);
        }
    }
}