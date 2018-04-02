using System.Collections.Generic;
using System.Security.Claims;

namespace Lizards.MvcToolkit..UserAccess.Claims
{
    public interface IClaimProvider
    {
        IEnumerable<Claim> GetClaims(IUser user);
    }
}