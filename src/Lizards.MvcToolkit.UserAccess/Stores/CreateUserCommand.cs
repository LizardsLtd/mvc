using System;
using Microsoft.AspNetCore.Identity;
using Picums.Data.CQRS;
using Lizards.MvcToolkit..UserAccess.Claims;

namespace Lizards.MvcToolkit..UserAccess.Stores
{
    public sealed class CreateUserCommand<TUser> : CommandBase
        where TUser : IdentityUser<Guid>, IUser
    {
        public CreateUserCommand(TUser user)
        {
            this.User = user;
        }

        public TUser User { get; }
    }
}