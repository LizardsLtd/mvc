﻿using System.Collections.Generic;

namespace Lizards.MvcToolkit..Configuration.Defaults
{
    public interface IDefault
    {
        void Apply(StartupConfigurations host, IEnumerable<object> arguments);
    }
}