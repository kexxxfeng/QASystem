﻿using MySql.Data.Entity;
using QASystem.CommonHelper;
using QASystem.Web.Infrastructure;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace QASystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
            DependenceRegistrar.Register();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(Object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            LogHelper.WriteLog(exception.ToString());
        }
    }
}
