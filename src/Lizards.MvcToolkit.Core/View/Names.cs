﻿namespace Lizards.MvcToolkit.View
{
    public static class Names
    {
        public static string DropController(this string controller)
            => controller.Replace("Controller", string.Empty);
    }
}