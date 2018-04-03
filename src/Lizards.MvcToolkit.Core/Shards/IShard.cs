namespace Lizards.MvcToolkit.Core.Shards
{
    public interface IShard
    {
        void Apply<TArgument>(StartupConfigurations host, TArgument arguments);
    }
}