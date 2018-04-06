namespace Lizards.Mvctoolkit.Demo
{
  using Lizards.MvcToolkit.Core.Shards;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;

  public sealed class DemoStartup : BasicShardedStartup
  {
    public DemoStartup(IHostingEnvironment env, IConfiguration configuration) : base(env, configuration)
    {
    }

    protected override string ExceptionHandlingRoute => "/home/error";
  }
}
