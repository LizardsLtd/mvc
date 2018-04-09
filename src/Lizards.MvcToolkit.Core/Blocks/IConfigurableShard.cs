namespace Lizards.MvcToolkit.Core.Blocks
{
    public interface IConfigurableShard<TConfiguration> : IShard
    {
        TConfiguration Options { get; }
    }
}