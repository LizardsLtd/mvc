namespace Lizards.MvcToolkit.Core.ModelBinder
{
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  internal sealed class ImmutableModelBinderProvider : IModelBinderProvider
  {
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
      return new ImmutableModelBinder();
    }
  }
}
