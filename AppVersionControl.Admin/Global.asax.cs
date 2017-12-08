using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Providers.Behavior;

namespace AppVersionControl.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ProviderManager.RegisterLoginProvider(new OAuthLoginProvider("appversioncontrol", "79DA0EA645A245EA93205B63954392BB", "basic_api", "40FDD43F5A074FFE852E4A54DB5C05C2", null));
            ProviderManager.RegisterAccountProvider(new Winner.Mvc.Audit.UserAccountProvider());
        }
    }
}
