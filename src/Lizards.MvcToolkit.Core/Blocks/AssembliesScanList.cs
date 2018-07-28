namespace Lizzards.MvcToolkit.Core.Blocks
{
  using Lizzards.MvcToolkit.Core.Startup;

  public sealed class AssembliesScanList : ConfigurationBlockBase
  {
    private readonly string[] assemblies;

    public AssembliesScanList(params string[] assemblies)
    {
      this.assemblies = assemblies;
    }

    protected override void ConfigureServices(ServicesConfigurator config)
    {
      config.AddAssemblyForScan(this.assemblies);
    }
  }
}
