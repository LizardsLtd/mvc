using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NLog;
using Picums.Data.CQRS;
using Picums.Data.CQRS.DataAccess;
using Lizards.MvcToolkit..UserAccess.Claims;

namespace Lizards.MvcToolkit..UserAccess.Stores
{

    public sealed class CreateLoginCommand : CommandBase
    {
        public CreateLoginCommand(AggregateUserLogin login)
        {
            this.Login = login;
        }

        public AggregateUserLogin Login { get; }
    }
}