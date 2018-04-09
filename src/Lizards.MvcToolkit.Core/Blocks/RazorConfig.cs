namespace Lizards.MvcToolkit.Core.Blocks
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.DependencyInjection;

    public sealed class RazorConfig
    {
        private readonly List<Action<RazorViewEngineOptions>> actions;

        internal RazorConfig()
            => this.actions = new List<Action<RazorViewEngineOptions>>();

        public void Options(Action<RazorViewEngineOptions> options)
            => this.actions.Add(options);

        internal void Use(IServiceCollection services)
            => services.Configure<RazorViewEngineOptions>(x => this.actions.ForEach(action => action(x)));
    }
}