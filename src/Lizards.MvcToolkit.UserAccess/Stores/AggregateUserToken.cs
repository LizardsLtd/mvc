using System;
using Microsoft.AspNetCore.Identity;
using Picums.Data.Domain;

namespace Lizards.MvcToolkit..UserAccess.Stores
{
    public sealed class AggregateUserToken : IdentityUserToken<Guid>, IAggregateRoot
    {
        public Guid Id => this.UserId;
    }
}