using AppVersionControl.Api.Models;
using AppVersionControl.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Winner.Framework.Utils;
using Winner.WebApi.Contract;

namespace AppVersionControl.Api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            VerificationManager.Register(new ApiVerification());
        }

        protected void Application_End()
        {
            ApplicationState.State.AppDownload.Flush();
            Log.Info("应用程序池重启！");
        }
    }
}
