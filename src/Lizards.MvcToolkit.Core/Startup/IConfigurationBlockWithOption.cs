namespace Lizards.MvcToolkit.Core.Startup
{
  public interface IConfigurationBlockWithOption<TConfiguration> : IConfigurationBlock
  {
    TConfiguration Options { get; }
  }
}
