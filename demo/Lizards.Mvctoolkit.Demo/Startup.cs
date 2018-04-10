namespace Lizards.Mvctoolkit.Demo
{
  using Lizards.MvcToolkit.Core.Blocks;
  using Lizards.MvcToolkit.Core.Blocks.Defaults;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.Extensions.Configuration;

  public sealed class DemoStartup : BasicBlockedStartup
  {
    public DemoStartup(IHostingEnvironment env, IConfiguration configuration) : base(env, configuration)
    {
      this.ApplyDefault(new CQRSBlock("Lizards.Mvctoolkit.Demo"));
    }

    protected override string ExceptionHandlingRoute => "/home/error";
  }
}
