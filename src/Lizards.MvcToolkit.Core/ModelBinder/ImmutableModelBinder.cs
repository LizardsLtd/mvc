namespace Lizards.MvcToolkit.Core.ModelBinder
{
  using System.ComponentModel;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Mvc.ModelBinding;

  internal sealed class ImmutableModelBinder : IModelBinder
  {
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
      var constructor = bindingContext
        .ModelType
        .GetConstructors()
        .FirstOrDefault(x => x.GetParameters().Length > 0);

      if (constructor != null)
      {
        try
        {
          var parameters = constructor
            .GetParameters()
            .Select(x => new
            {
              Type = x.ParameterType,
              Value = bindingContext.ValueProvider.GetValue(x.Name.ToLower()).FirstOrDefault()
            })
            .Select(x => TypeDescriptor.GetConverter(x.Type).ConvertFromString(x.Value))
            .ToArray();
          var model = constructor.Invoke(parameters);
          bindingContext.Result = ModelBindingResult.Success(model);
        }
        catch { }
      }

      return Task.CompletedTask;
    }
  }
}
