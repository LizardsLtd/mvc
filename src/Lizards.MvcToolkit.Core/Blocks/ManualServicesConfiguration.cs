namespace Lizards.MvcToolkit.Core.Blocks
{
  using System;
  using Lamar;
  using Lizards.MvcToolkit.Core.Startup;

  public sealed class ManualServicesConfiguration : ConfigurationBlockBase
  {
    private readonly Action<ServiceRegistry> manaualConfigureService;

    public ManualServicesConfiguration(Action<ServiceRegistry> manaualConfigureService)
    {
      this.manaualConfigureService = manaualConfigureService;
    }

    protected override void ConfigureServices(ServicesConfigurator config)
      => config.Add(this.manaualConfigureService);
  }
}
