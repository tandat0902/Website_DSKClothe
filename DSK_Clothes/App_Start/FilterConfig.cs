﻿using System.Web;
using System.Web.Mvc;

namespace DSK_Clothes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}