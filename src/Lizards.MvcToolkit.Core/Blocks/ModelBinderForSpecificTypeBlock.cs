namespace Lizzards.MvcToolkit.Core.Blocks.Defaults
{
  using Lizzards.MvcToolkit.Core.Startup;
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  public sealed class ModelBinderBlock<TBindedType, TModelBinder> : IConfigurationBlock
      where TModelBinder : IModelBinder, new()
  {
    public void Apply(StartupConfigurations host)
        => host.MVC.Options.AddModelBinderProvider<TBindedType, TModelBinder>();
  }
}
