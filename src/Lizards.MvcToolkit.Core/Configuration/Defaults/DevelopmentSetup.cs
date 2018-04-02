﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Lizards.MvcToolkit..Configuration.Defaults
{
    public sealed class DevelopmentSetup : BasicDefault
    {
        protected override void ConfigureApp(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IEnumerable<object> arguments)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}