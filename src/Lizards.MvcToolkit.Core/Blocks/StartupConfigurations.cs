namespace Lizards.MvcToolkit.Core.Blocks
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public sealed class StartupConfigurations
    {
        /// <summary>Record Constructor</summary>
        /// <param name="mVC"><see cref="MVC"/></param>
        /// <param name="aSP"><see cref="ASP"/></param>
        /// <param name="razor"><see cref="Razor"/></param>
        /// <param name="environment"><see cref="Environment"/></param>
        /// <param name="configurationRoot"><see cref="Configuration"/></param>
        public StartupConfigurations(IHostingEnvironment environment, IConfiguration configuration)
        {
            this.MVC = new MvcConfig();
            this.ASP = new AspConfigurator();
            this.Razor = new RazorConfig();
            this.Services = new ServicesConfigurator();
            this.Environment = environment;
            this.Configuration = configuration;
        }

        public MvcConfig MVC { get; }

        public AspConfigurator ASP { get; }

        public RazorConfig Razor { get; }

        public ServicesConfigurator Services { get; }

        public IHostingEnvironment Environment { get; }

        public IConfiguration Configuration { get; }

        internal void Apply<TDefault>() where TDefault : IConfigurationBlock, new()
            => this.Apply(new TDefault());

        internal void Apply(IConfigurationBlock @default)
            => @default.Apply(this);
    }
}