using System;
using System.Collections.Generic;
using Picums.Data.Domain;

namespace Lizards.MvcToolkit.UserAccess.Claims
{
    public interface IPermissionContainer
    {
        IEnumerable<Permission> Permissions { get; }
    }
}