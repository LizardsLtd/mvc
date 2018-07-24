namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using System;
  using System.Net.Http;
  using Lamar;
  using Lizards.MvcToolkit.Core.Startup;
  using Microsoft.Extensions.DependencyInjection;

  public sealed class HttpClientFactoryBlock<TClient> : ConfigurationBlockBase
    where TClient : class
  {
    private readonly Action<ServiceRegistry> configureHttpClientFactory;

    public HttpClientFactoryBlock()
      : this(services => services.AddHttpClient())
    {
    }

    public HttpClientFactoryBlock(string name)
      : this(services => services.AddHttpClient<TClient>(name))
    {
    }

    public HttpClientFactoryBlock(string name, Action<HttpClient> configureClient)
      : this(service => service.AddHttpClient<TClient>(name, configureClient))
    {
    }

    private HttpClientFactoryBlock(Action<IServiceCollection> configureHttpClientFactory)
    {
      this.configureHttpClientFactory = configureHttpClientFactory;
    }

    protected override void ConfigureServices(ServicesConfigurator config)
      => config.Add(this.configureHttpClientFactory);
  }
}
