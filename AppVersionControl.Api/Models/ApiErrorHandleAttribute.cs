using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Winner.Framework.MVC.Models;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.WebApi.Contract;

namespace AppVersionControl.Api.Models
{
    public class ApiErrorHandleAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            string currentUrl = string.Format("{0}/{1}", filterContext.RouteData.GetRequiredString("controller"),
                filterContext.RouteData.GetRequiredString("action"));
            Log.Error("错误信息{0},{1}", currentUrl, filterContext?.Exception?.Message);
            var apiCtrl = filterContext.Controller as ApiControllerBase;
            if (apiCtrl != null)
            {
                FuncResult result = new FuncResult();
                result.Success = false;
                result.StatusCode = 500;
                result.Message = filterContext.Exception?.Message;
                JsonNetResult jsonResult = new JsonNetResult();
                jsonResult.Data = result;
                filterContext.Result = jsonResult;
                filterContext.ExceptionHandled = true;
            }
        }
    }
}