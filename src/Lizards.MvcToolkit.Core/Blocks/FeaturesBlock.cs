namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using Lizards.MvcToolkit.Core.FeatureSlices;
  using Lizards.MvcToolkit.Core.Startup;

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
