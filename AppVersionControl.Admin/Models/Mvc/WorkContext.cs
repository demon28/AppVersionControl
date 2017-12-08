using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AppVersionControl.Admin.Models.Mvc
{
    public class WorkContext
    {
        private RequestContext _context;
        public WorkContext(RequestContext context)
        {
            this._context = context;
        }
        public string Avatar { get; set; }

        public bool IsActive(string controller, string action)
        {

            if (_context == null)
            {
                return false;
            }
            if (string.IsNullOrEmpty(controller) && string.IsNullOrEmpty(action))
            {
                return false;
            }
            var currentController = _context.RouteData.Values["controller"] + string.Empty;
            var currentAction = _context.RouteData.Values["action"] + string.Empty;

            bool sameController = currentController.Equals(controller, StringComparison.OrdinalIgnoreCase);
            bool emptyAction = string.IsNullOrEmpty(action);
            bool sameAction = currentAction.Equals(action, StringComparison.OrdinalIgnoreCase);
            bool res = (sameController && emptyAction) || (sameController && !emptyAction && sameAction);
            return res;
        }

        public int? Audit_ID { get; set; }
    }
}