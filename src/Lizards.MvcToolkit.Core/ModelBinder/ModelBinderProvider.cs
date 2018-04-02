﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Lizards.MvcToolkit..ModelBinder
{
	public sealed class ModelBinderProvider<TBindType, TModelBinder> : IModelBinderProvider
		where TModelBinder : IModelBinder, new()
	{
		public IModelBinder GetBinder(ModelBinderProviderContext context)
			=> context.Metadata.ModelType == typeof(TBindType)
				? new TModelBinder()
				: default(TModelBinder);
	}
}