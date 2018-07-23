namespace Lizards.MvcToolkit.Core.Startup
{
  using System;
  using System.Collections.Generic;
  using Lamar;

  public sealed class ServicesConfigurator
  {
    private readonly List<Action<ServiceRegistry>> services;

    public ServicesConfigurator()
    {
      this.services = new List<Action<ServiceRegistry>>();
    }

    public void Add<TCustomRegistry>()
        where TCustomRegistry : ServiceRegistry, new()
      => this.services.Add(serviceRegistry => serviceRegistry.IncludeRegistry<TCustomRegistry>());

    public void Add(Action<ServiceRegistry> registryUpdateAction)
      => this.services.Add(registryUpdateAction);

    internal void Use(ServiceRegistry services)
        => this.services.ForEach(x => x(services));
  }
}
