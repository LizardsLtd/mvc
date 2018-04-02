using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Picums.Data.CQRS;
using Lizards.MvcToolkit.Configuration.Defaults;
using Lizards.MvcToolkit.Localisation.DataStorage;

namespace Lizards.MvcToolkit.Localisation.Configuration.Defaults
{
    public sealed class LocaliseUsingDatabaseDefault : BasicDefault
    {
        protected override void ConfigureServices(IServiceCollection services, IEnumerable<object> arguments)
            => services
                .AddTransient<ICommandHandler, AddNewTranslationCommandHandler>()
                .AddTransient<GetAllTranslationsQuery>()
                .AddTransient<ITranslationSetProvider, DataTranslationProvider>();
    }
}