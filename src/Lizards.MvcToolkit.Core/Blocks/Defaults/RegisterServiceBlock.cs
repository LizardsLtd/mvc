using SimpleInjector;

namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  public sealed class RegisterServiceBlock<TService, TDecorator> : IConfigurationBlock
    where TService : class
    where TDecorator : class, TService
  {
    private readonly Lifestyle lifestyle;

    public RegisterServiceBlock()
      : this(Lifestyle.Scoped)
    {
    }

    public RegisterServiceBlock(Lifestyle lifestyle)
    {
      this.lifestyle = lifestyle;
    }

    public void Apply(StartupConfigurations host)
    {
      host.Container.Register<TService, TDecorator>(this.lifestyle);
    }
  }
}
