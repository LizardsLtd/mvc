namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public sealed class ModelBinderShard<TBindedType, TModelBinder> : IShard
        where TModelBinder : IModelBinder, new()
    {
        public void Apply(StartupConfigurations host, IEnumerable<object> arguments)
            => host.MVC.Options.AddModelBinderProvider<TBindedType, TModelBinder>();
    }
}