using System.Collections.Generic;

namespace Lizards.MvcToolkit.Core.Shards.Data
{
    public sealed class DataTypesDefault : IShard
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