namespace Lizards.MvcToolkit.Core.Startup
{
  using System;
  using System.Collections.Generic;
  using Lamar;
  using Lamar.Scanning.Conventions;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class ServicesConfigurator
  {
    private readonly List<Action<ServiceRegistry>> services;
    private readonly List<IRegistrationConvention> Conventions;
    private readonly List<string> AssembliesForScan;

    public ServicesConfigurator()
    {
      this.services = new List<Action<ServiceRegistry>>();
      this.Conventions = new List<IRegistrationConvention>();
      this.AssembliesForScan = new List<string>();
    }

    public void Add<TCustomRegistry>()
        where TCustomRegistry : ServiceRegistry, new()
      => this.services.Add(serviceRegistry => serviceRegistry.IncludeRegistry<TCustomRegistry>());

    public void Add(Action<ServiceRegistry> registryUpdateAction)
      => this.services.Add(registryUpdateAction);

    public void Add(Action<IServiceCollection> registryUpdateAction)
      => this.services.Add(registryUpdateAction);

    public void AddAssemblyForScan(string assemblyName)
      => this.AssembliesForScan.Add(assemblyName);

    public void AddConvention(IRegistrationConvention convention)
      => this.Conventions.Add(convention);

    internal void AddAssemblyForScan(string[] assemblies)
      => this.AssembliesForScan.AddRange(assemblies);

    internal void Use(ServiceRegistry services)
    {
      this.services.ForEach(x => x(services));
    }

    internal void AutoScan(ServiceRegistry services)
      => services.Scan(_ =>
        {
          this.AssembliesForScan.ForEach(x => _.Assembly(x));
          this.Conventions.ForEach(x => _.With(x));
        });
  }
}
