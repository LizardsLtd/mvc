namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class OptionsDefault<TOptions> : IShard
        where TOptions : class
    {
        public void Apply(StartupConfigurations host, IEnumerable<object> arguments)
        {
            if (arguments.FirstOrDefault() is Action<TOptions> configure)
            {
                host.Services.Configure(configure);
            }
        }
    }
}