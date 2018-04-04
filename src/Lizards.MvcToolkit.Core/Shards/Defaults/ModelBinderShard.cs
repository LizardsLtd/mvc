namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public sealed class ModelBinderShard<TBindedType, TModelBinder> : IShard
        where TModelBinder : IModelBinder, new()
    {
        public void Apply(StartupConfigurations host)
            => host.MVC.Options.AddModelBinderProvider<TBindedType, TModelBinder>();
    }
}