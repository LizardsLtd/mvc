namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;

    public sealed class MiddlewareShard<TMiddleware> : ConfigurationBlockWithOptionBase<IEnumerable<object>>
    {
        public MiddlewareShard(Func<IEnumerable<object>> optionsFactory)
            : base(optionsFactory) { }

        protected override void ConfigureApp(
            IApplicationBuilder app
            , IHostingEnvironment env
            , IEnumerable<object> arguments)
        {
            if (arguments.Any())
            {
                app.UseMiddleware<TMiddleware>(arguments);
            }
            else
            {
                app.UseMiddleware<TMiddleware>();
            }
        }
    }
}