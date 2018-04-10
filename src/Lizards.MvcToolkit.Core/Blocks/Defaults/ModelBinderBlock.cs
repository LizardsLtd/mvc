namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public sealed class ModelBinderBlock<TBindedType, TModelBinder> : IConfigurationBlock
        where TModelBinder : IModelBinder, new()
    {
        public void Apply(StartupConfigurations host)
            => host.MVC.Options.AddModelBinderProvider<TBindedType, TModelBinder>();
    }
}