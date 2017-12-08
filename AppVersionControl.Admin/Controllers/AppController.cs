using AppVersionControl.DataAccess;
using Javirs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC;
using Winner.Framework.MVC.Controllers;
using Winner.Framework.Utils;

namespace AppVersionControl.Admin.Controllers
{
    [AuthLogin]
    public class AppController : TopControllerBase
    {
        // GET: App
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int? appId)
        {
            Tvc_App_InfoCollection daAppCollection = new Tvc_App_InfoCollection();
            daAppCollection.ListAll();

            List<object> list = daAppCollection.DataTable.ToDynamic();
            return SuccessResultList(list);
        }
        [HttpGet]
        public ActionResult Version()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Version(int? appId)
        {
            Tvc_VersionCollection daVersionCollection = new Tvc_VersionCollection();
            daVersionCollection.ListByAdmin(appId);
            List<object> list = daVersionCollection.DataTable.ToDynamic();
            return SuccessResultList(list);
        }
    }
}