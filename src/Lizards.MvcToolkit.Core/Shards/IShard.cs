namespace Lizards.MvcToolkit.Core.Shards
{
    public interface IShard
    {
        void Apply(StartupConfigurations host);
    }

    public interface IConfigurableShard<TConfiguration>: IShard
    {
    }
}