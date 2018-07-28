namespace Lizzards.MvcToolkit.Core.Blocks.Defaults
{
  using Lizzards.MvcToolkit.Core.FeatureSlices;
  using Lizzards.MvcToolkit.Core.Startup;

  public sealed class FeaturesBlock : IConfigurationBlock
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
