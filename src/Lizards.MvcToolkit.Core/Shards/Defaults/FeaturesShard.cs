namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
  using Lizards.MvcToolkit.FeatureSlices;

  public sealed class FeaturesShard : IShard
  {
    public void Apply(StartupConfigurations host)
    {
      host.MVC.Options.AddControllerConvention<FeatureConvention>();

      host.Razor.Options(options
          => new ViewLocationFormatsUpdater(options)
              .UpdateViewLocations()
              .AddExtender());
    }
  }
}
