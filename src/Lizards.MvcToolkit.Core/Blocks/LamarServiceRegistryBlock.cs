namespace Lizzards.MvcToolkit.Core.Blocks
{
  using Lamar;
  using Lizzards.MvcToolkit.Core.Startup;

  public sealed class LamarServiceRegistryBlock<TCustomRegistry> : IConfigurationBlock
        where TCustomRegistry : ServiceRegistry, new()
  {
    public void Apply(StartupConfigurations host)
      => host.Services.Add<TCustomRegistry>();
  }
}
