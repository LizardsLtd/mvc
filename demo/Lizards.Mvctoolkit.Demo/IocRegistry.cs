namespace Lizards.Mvctoolkit.Demo
{
  using Lamar;
  using Lizards.Mvctoolkit.Demo.Services;

  /// <summary>
  /// Defaukt registry for demo project.
  /// </summary>
  /// <seealso cref="Lamar.ServiceRegistry" />
  internal sealed class IocRegistry : ServiceRegistry
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="IocRegistry"/> class.
    /// </summary>
    public IocRegistry()
    {
      this.For<IService>().Use<Service>();
    }
  }
}
