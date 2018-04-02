using Picums.Data.Domain;

namespace Lizards.MvcToolkit..UserAccess.Claims
{
    public interface IUser : IAggregateRoot, IPermissionContainer, IIdentityUser
    {
    }
}