namespace Lizzards.MvcToolkit.Core.Blocks.Defaults
{
  using Lizzards.MvcToolkit.Core.Startup;
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  public sealed class ModelBinderWithCustomProviderBlock<TModelBinderProvider> : IConfigurationBlock
    where TModelBinderProvider : IModelBinderProvider, new()

  {
    public void Apply(StartupConfigurations host)
        => host.MVC.Options.AddModelBinderProvider<TModelBinderProvider>();
  }
}
