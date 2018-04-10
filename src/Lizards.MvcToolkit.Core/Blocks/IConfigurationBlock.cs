namespace Lizards.MvcToolkit.Core.Blocks
{
  public interface IConfigurationBlock
  {
    void Apply(StartupConfigurations host);
  }
}
