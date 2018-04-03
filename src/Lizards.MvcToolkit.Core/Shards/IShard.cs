namespace Lizards.MvcToolkit.Core.Shards
{
    using System.Collections.Generic;

    public interface IShard
    {
        void Apply(StartupConfigurations host, IEnumerable<object> arguments);
    }
}