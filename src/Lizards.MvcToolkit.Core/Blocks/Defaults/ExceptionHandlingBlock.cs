namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    public sealed class ExceptionHandlingBlock : ConfigurationBlockWithOptionBase<string>
    {
        public ExceptionHandlingBlock(string exceptionPage)
            : base(exceptionPage) { }

        protected override void ConfigureApp(IApplicationBuilder app, IHostingEnvironment env, string exceptionRoute)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(exceptionRoute);
            }
        }
    }
}