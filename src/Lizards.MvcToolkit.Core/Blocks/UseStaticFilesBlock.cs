namespace Lizzards.MvcToolkit.Core.Blocks.Defaults
{
  using Lizzards.MvcToolkit.Core.Startup;
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;

  public sealed class UseStaticFilesBlock : ConfigurationBlockBase

  {
    protected override void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
        => app.UseStaticFiles();
  }
}
