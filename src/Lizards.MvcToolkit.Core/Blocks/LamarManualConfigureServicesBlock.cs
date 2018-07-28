namespace Lizzards.MvcToolkit.Core.Blocks
{
  using System;
  using Lamar;
  using Lizzards.MvcToolkit.Core.Startup;

  public sealed class LamarManualConfigureServicesBlock : IConfigurationBlock
  {
    private readonly Action<ServiceRegistry> manualConfiguration;

    public LamarManualConfigureServicesBlock(Action<ServiceRegistry> manualConfiguration)
    {
      this.manualConfiguration = manualConfiguration;
    }

    public void Apply(StartupConfigurations host)
      => host.Services.Add(this.manualConfiguration);
  }
}
