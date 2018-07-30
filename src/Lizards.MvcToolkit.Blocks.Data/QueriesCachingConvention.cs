namespace Lizzards.MvcToolkit.Blocks.Data
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using Lamar;
  using Lamar.Scanning;
  using Lamar.Scanning.Conventions;
  using Lizzards.Data.Cache;
  using Lizzards.Data.CQRS;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class QueriesCachingConvention : IRegistrationConvention
  {
    private readonly Dictionary<Type, Type> queriesMap;
    private Func<IServiceCollection, Type, Type, IServiceCollection> AddToService;

    public QueriesCachingConvention()
      : this(ServiceCollectionServiceExtensions.AddTransient)
    { }

    public QueriesCachingConvention(Func<IServiceCollection, Type, Type, IServiceCollection> addToService)
    {
      this.AddToService = addToService;

      this.queriesMap = new Dictionary<Type, Type>
      {
        { typeof(IQuery<>), typeof(CachedQueryDecorator<>) },
        { typeof(IQuery<,>), typeof(CachedQueryDecorator<,>) },
        { typeof(IQuery<,,>), typeof(CachedQueryDecorator<,,>) },
        { typeof(IQuery<,,,>), typeof(CachedQueryDecorator<,,,>) },
        { typeof(IAsyncQuery<>), typeof(AsyncCachedQueryDecorator<>) },
        { typeof(IAsyncQuery<,>), typeof(AsyncCachedQueryDecorator<,>) },
        { typeof(IAsyncQuery<,,>), typeof(AsyncCachedQueryDecorator<,,>) },
        { typeof(IAsyncQuery<,,,>), typeof(AsyncCachedQueryDecorator<,,,>) },
      };
    }

    public void ScanTypes(TypeSet types, ServiceRegistry services)
    {
      var isQuery = typeof(IsQuery);
      var queries = types
        .FindTypes(TypeClassification.Concretes)
        .Where(type => isQuery.IsAssignableFrom(type))
        .ToList();

      queries.ForEach(queryType
        => queryType
          .GetInterfaces()
          .ToList()
          .ForEach(@interface =>
          {
            services.AddSingleton(@interface, queryType);

            this.DecorateNonGenericQueriesInterfaces(services, @interface);
          }));
    }

    private void DecorateNonGenericQueriesInterfaces(ServiceRegistry services, Type @interface)
    {
      if (@interface.IsGenericType)
      {
        var genericVersionOfInterface = @interface.GetGenericTypeDefinition();
        if (this.queriesMap.ContainsKey(genericVersionOfInterface))
        {
          var concreateDecoratorType = CreateDecorator(@interface, genericVersionOfInterface);
          services.For(@interface).DecorateAllWith(concreateDecoratorType);
        }
      }
    }

    private Type CreateDecorator(Type @interface, Type genericVersionOfInterface)
    {
      var decoratorType = this.queriesMap[genericVersionOfInterface];
      var genericParametes = @interface.GenericTypeArguments;
      var concreateDecoratorType = decoratorType.MakeGenericType(genericParametes);
      return concreateDecoratorType;
    }
  }
}
