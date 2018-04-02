using System.Collections.Generic;
using System.Security.Claims;

namespace Lizards.MvcToolkit.UserAccess.Claims
{
    public sealed class NameClaimProvider : IClaimProvider
    {
        public IEnumerable<Claim> GetClaims(IUser user)
        {
            yield return new Claim(ClaimIdentity.UserName, user.UserName);
        }
    }
}