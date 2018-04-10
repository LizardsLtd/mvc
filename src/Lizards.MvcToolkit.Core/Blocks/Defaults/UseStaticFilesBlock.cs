namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;

  public sealed class UseStaticFilesBlockBlock : ConfigurationBlockBase

  {
    protected override void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
        => app.UseStaticFiles();
  }
}
