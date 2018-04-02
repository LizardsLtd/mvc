﻿using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Picums.GeoCoding;

namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    public sealed class GeoCodingDefault : BasicDefault
    {
        protected override void ConfigureServices(IServiceCollection services, IEnumerable<object> arguments)
        {
            services.AddTransient<IGeocodingService, GoogleGeocodingService>();
        }
    }
}