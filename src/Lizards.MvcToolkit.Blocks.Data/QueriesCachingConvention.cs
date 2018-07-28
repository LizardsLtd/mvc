namespace Lizzards.MvcToolkit.Blocks.Data
{
  using System;
  using Lamar;
  using Lamar.Scanning;
  using Lamar.Scanning.Conventions;
  using Lizzards.Data.Cache;
  using Lizzards.Data.CQRS;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class QueriesCachingConvention : IRegistrationConvention
  {
    private Func<IServiceCollection, Type, Type, IServiceCollection> AddToService;

    public QueriesCachingConvention()
    {
      this.AddToService = ServiceCollectionServiceExtensions.AddTransient;
    }

    public QueriesCachingConvention(Func<IServiceCollection, Type, Type, IServiceCollection> addToService)
    {
      this.AddToService = addToService;
    }

    public void ScanTypes(TypeSet types, ServiceRegistry services)
    {
      services.For(typeof(IQuery<>)).DecorateAllWith(typeof(CachedQueryDecorator<>));
      services.For(typeof(IQuery<,>)).DecorateAllWith(typeof(CachedQueryDecorator<,>));
      services.For(typeof(IQuery<,,>)).DecorateAllWith(typeof(CachedQueryDecorator<,,>));
      services.For(typeof(IQuery<,,,>)).DecorateAllWith(typeof(CachedQueryDecorator<,,,>));
      services.For(typeof(IAsyncQuery<>)).DecorateAllWith(typeof(AsyncCachedQueryDecorator<>));
      services.For(typeof(IAsyncQuery<,>)).DecorateAllWith(typeof(AsyncCachedQueryDecorator<,>));
      services.For(typeof(IAsyncQuery<,,>)).DecorateAllWith(typeof(AsyncCachedQueryDecorator<,,>));
      services.For(typeof(IAsyncQuery<,,,>)).DecorateAllWith(typeof(AsyncCachedQueryDecorator<,,,>));
    }
  }
}
