namespace Lizards.MvcToolkit.Core.Blocks
{
  public interface IConfigurationBlockWithOption<TConfiguration> : IConfigurationBlock
  {
    TConfiguration Options { get; }
  }
}
