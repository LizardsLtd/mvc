namespace Lizards.MvcToolkit.Core.Startup
{
  public interface IConfigurationBlock
  {
    void Apply(StartupConfigurations host);
  }
}
