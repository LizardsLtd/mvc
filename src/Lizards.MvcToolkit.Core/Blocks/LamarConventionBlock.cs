namespace Lizards.MvcToolkit.Core.Blocks
{
  using System.Collections.Generic;
  using System.Linq;
  using Lamar.Scanning.Conventions;
  using Lizards.MvcToolkit.Core.Startup;

  public sealed class LamarConventionBlock : IConfigurationBlock
  {
    private readonly List<IRegistrationConvention> conventions;

    public LamarConventionBlock(params IRegistrationConvention[] conventions)
    {
      this.conventions = conventions.ToList();
    }

    public void Apply(StartupConfigurations host)
      => this.conventions
        .ForEach(convention => host.Services.AddConvention(convention));
  }
}
