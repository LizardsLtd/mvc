using System.Collections.Generic;

namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    public interface IShard
    {
        void Apply(StartupConfigurations host, IEnumerable<object> arguments);
    }
}