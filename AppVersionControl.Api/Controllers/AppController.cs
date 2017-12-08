using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Winner.WebApi.Contract;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using AppVersionControl.Facade;

namespace AppVersionControl.Api.Controllers
{
    [IgnoreUserToken]
    public class AppController : ApiControllerBase
    {
        public ActionResult Version()
        {
            AppVersionProvider verProvider = new AppVersionProvider(Package.MerchantNo, Package.UserCode, Package.ClientVersion);
            AppVersion newVer = verProvider.GetNewVersion();
            return SuccessResult(newVer);
        }
        public ActionResult ReleaseNote()
        {
            var appVersionCollection = AppVersionCollection.SingletonInstance();
            AppVersion currVersion = appVersionCollection.Find(it => it.Version_Code.Equals(Package.ClientVersion, StringComparison.OrdinalIgnoreCase));
            return SuccessResult(currVersion);
        }
    }
}