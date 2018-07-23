namespace Lizards.MvcToolkit.Core.Blocks
{
  using Lamar;
  using Lizards.MvcToolkit.Core.Startup;

  public sealed class LamarServiceRegistryBlock<TCustomRegistry> : IConfigurationBlock
        where TCustomRegistry : ServiceRegistry, new()
  {
    public void Apply(StartupConfigurations host)
      => host.Services.Add<TCustomRegistry>();
  }
}
