namespace Lizards.Mvctoolkit.Demo
{
  using Lizards.MvcToolkit.Core.Shards;
  using Lizards.MvcToolkit.Core.Shards.Defaults;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;

  public sealed class DemoStartup : BasicShardedStartup
  {
    public DemoStartup(IHostingEnvironment env, IConfiguration configuration) : base(env, configuration)
    {
      this.ApplyDefault(new CQRSShard("Lizards.Mvctoolkit.Demo"));
    }

    protected override string ExceptionHandlingRoute => "/home/error";
  }
}
