﻿using System.Web;
using System.Web.Mvc;

namespace DISamples.Layers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}