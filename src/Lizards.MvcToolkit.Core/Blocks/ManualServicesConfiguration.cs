namespace Lizards.MvcToolkit.Core.Blocks
{
  using System;
  using Lamar;
  using Lizards.MvcToolkit.Core.Startup;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class ManualServicesConfiguration : ConfigurationBlockBase
  {
    private readonly Action<IServiceCollection> manaualConfigureService;

    public ManualServicesConfiguration(Action<ServiceRegistry> manaualConfigureService)
    {
      this.manaualConfigureService = manaualConfigureService;
    }

    protected override void ConfigureServices(ServicesConfigurator config)
      => config.Add(this.manaualConfigureService);
  }
}
