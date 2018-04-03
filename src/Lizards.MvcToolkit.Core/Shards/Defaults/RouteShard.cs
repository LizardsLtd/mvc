namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Routing;

    public sealed class RouteShard : IShard<IEnumerable<Action<IRouteBuilder>>>
    {
        public void Apply(StartupConfigurations host, IEnumerable<Action<IRouteBuilder>> arguments)
            => arguments
                .ToList()
                .ForEach(routeAction => host.MVC.Routes.Add(routeAction));
    }
}