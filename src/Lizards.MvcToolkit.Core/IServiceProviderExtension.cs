using System;

namespace Lizards.MvcToolkit.
{
    public static class IServiceProviderExtension
    {
        public static T GetService<T>(this IServiceProvider serviceProvider)
            => (T)serviceProvider.GetService(typeof(T));
    }
}