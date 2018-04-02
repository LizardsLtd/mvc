using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Lizards.MvcToolkit.Core.Shards.Defaults;

namespace Lizards.MvcToolkit.Localisation.Configuration.Defaults
{
    public sealed class LocaliseUsingConfigurationDefault : BasicDefault
    {
        protected override void ConfigureServices(IServiceCollection services, IEnumerable<object> arguments)
        {
            services.AddTransient(_ => this.GetTranslationSetProvider());
        }

        private ITranslationSetProvider GetTranslationSetProvider()
            => new JsonTransaltionProvider(this.Configuration.GetSection("Translations"));
    }
}