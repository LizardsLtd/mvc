namespace Lizards.MvcToolkit.Core.Shards
{
    public interface IShard<TArgument>
    {
        void Apply(StartupConfigurations host, TArgument arguments);
    }
}