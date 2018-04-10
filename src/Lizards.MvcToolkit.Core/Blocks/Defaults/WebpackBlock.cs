namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.SpaServices.Webpack;

  public sealed class WebpackBlock : ConfigurationBlockBase
  {
    protected override void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
        {
          HotModuleReplacement = true,
        });
      }
    }
  }
}
