using System.Collections.Generic;
using Picums.Data.Types;
using Lizards.MvcToolkit.ApplicationServices;
using Lizards.MvcToolkit.Core.Shards.Defaults;

namespace Lizards.MvcToolkit.Core.Shards.Data
{
    public sealed class DataTypesDefault : IDefault
    {
        public void Apply(StartupConfigurations host, IEnumerable<object> arguments)
        {
            host.MVC.Options
                .AddModelBinderProvider<Address, AddressModelBinder>()
                .AddModelBinderProvider<BankDetails, BankDetailsModelBinder>()
                .AddModelBinderProvider<Email, EmailModelBinder>();
        }
    }
}