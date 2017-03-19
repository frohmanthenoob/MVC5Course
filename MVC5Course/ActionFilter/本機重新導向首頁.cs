using System;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    class 本機重新導向首頁 : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            //base.OnResultExecuted(filterContext);
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.HttpContext.Response.Redirect("/");
            }
        }
    }
}