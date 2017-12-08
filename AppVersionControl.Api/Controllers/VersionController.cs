using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppVersionControl.Api.Controllers
{
    public class VersionController : Controller
    {
        public ActionResult History(string merchantNo)
        {
            return View();
        }
    }
}