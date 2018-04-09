namespace Lizards.MvcToolkit.Core.Blocks.Defaults
{
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using Picums.GeoCoding;

    public sealed class GeoCodingDefault : BasicDefault
    {
        protected override void ConfigureServices(IServiceCollection services, IEnumerable<object> arguments)
        {
            services.AddTransient<IGeocodingService, GoogleGeocodingService>();
        }
    }
}