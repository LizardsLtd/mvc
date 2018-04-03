namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using Lizards.MvcToolkit.FeatureSlices;

    public sealed class FeaturesShard : ShardBase<object>
    {
        public void Apply(StartupConfigurations host, object arguments)
        {
            host.MVC.Options.AddControllerConvention<FeatureConvention>();

            host.Razor.Options(options
                => new ViewLocationFormatsUpdater(options)
                    .UpdateViewLocations()
                    .AddExtender());
        }
    }
}