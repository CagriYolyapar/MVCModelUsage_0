﻿using System.Web;
using System.Web.Mvc;

namespace MVCModelUsage_0
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
