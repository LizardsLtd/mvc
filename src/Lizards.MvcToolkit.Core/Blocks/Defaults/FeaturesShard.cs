namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using Lizards.MvcToolkit.FeatureSlices;

  public sealed class FeaturesShard : IConfigurationBlock
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
