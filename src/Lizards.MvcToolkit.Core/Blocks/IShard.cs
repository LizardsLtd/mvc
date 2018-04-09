namespace Lizards.MvcToolkit.Core.Blocks
{
    public interface IShard
    {
        void Apply(StartupConfigurations host);
    }
}