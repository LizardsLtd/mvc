namespace Lizards.MvcToolkit.Core.Shards
{
    public interface IConfigurableShard<TConfiguration> : IShard
    {
        TConfiguration Options { get; }
    }
}