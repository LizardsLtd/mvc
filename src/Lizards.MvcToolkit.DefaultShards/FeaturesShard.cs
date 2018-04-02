namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System.Collections.Generic;
    using Lizards.MvcToolkit.FeatureSlices;

    public sealed class FeaturesShard : IShard
    {
        public void Apply(StartupConfigurations host, IEnumerable<object> arguments)
        {
            host.MVC.Options.AddControllerConvention<FeatureConvention>();

            host.Razor.Options(options
                => new ViewLocationFormatsUpdater(options)
                    .UpdateViewLocations()
                    .AddExtender());
        }
    }
}