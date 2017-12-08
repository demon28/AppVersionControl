using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppVersionControl.Admin.Models.Mvc
{
    public abstract class AdminWebViewPage<TModel> : System.Web.Mvc.WebViewPage<TModel>
    {
        public WorkContext WorkContext { get; set; }
        public override void InitHelpers()
        {
            base.InitHelpers();
            this.WorkContext = new WorkContext(this.ViewContext.RequestContext);
        }
    }

    public abstract class AdminWebViewPage : AdminWebViewPage<dynamic>
    {

    }
}