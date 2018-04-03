namespace Lizards.MvcToolkit.Core.Shards.Defaults
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Routing;

    public sealed class RouteDefault : IShard
    {
        public void Apply(StartupConfigurations host, IEnumerable<object> arguments)
            => arguments
                .Cast<Action<IRouteBuilder>>()
                .ToList()
                .ForEach(routeAction => host.MVC.Routes.Add(routeAction));
    }
}