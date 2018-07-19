namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using System;
  using System.Net.Http;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class HttpClientFactoryBlock<TClient, TImplementation> : ConfigurationBlockBase
        where TClient : class
        where TImplementation : class, TClient
  {
    private readonly Action<IServiceCollection> configureHttpClientFactory;

    public HttpClientFactoryBlock()
      : this(services => services.AddHttpClient<TClient, TImplementation>())
    {
    }

    public HttpClientFactoryBlock(string name)
      : this(services => services.AddHttpClient<TClient, TImplementation>(name))
    {
    }

    public HttpClientFactoryBlock(string name, Action<HttpClient> configureClient)
      : this(service => service.AddHttpClient<TClient, TImplementation>(name, configureClient))
    {
    }

    private HttpClientFactoryBlock(Action<IServiceCollection> configureHttpClientFactory)
    {
      this.configureHttpClientFactory = configureHttpClientFactory;
    }

    protected override void ConfigureServices(IServiceCollection services)
      => this.configureHttpClientFactory(services);
  }
}
