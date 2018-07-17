using SimpleInjector;

namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  public sealed class RegisterDecoratorBlock<TService, TDecorator> : IConfigurationBlock
    where TService : class
    where TDecorator : class, TService
  {
    private readonly Lifestyle lifestyle;

    public RegisterDecoratorBlock()
      : this(Lifestyle.Scoped)
    {
    }

    public RegisterDecoratorBlock(Lifestyle lifestyle)
    {
      this.lifestyle = lifestyle;
    }

    public void Apply(StartupConfigurations host)
    {
      host.Container.RegisterDecorator<TService, TDecorator>(this.lifestyle);
    }
  }
}
