using System;
using System.Web.Mvc;

namespace MVC5Course.ActionFilter
{
    class 紀錄Action執行時間Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(filterContext);
            filterContext.Controller.ViewBag.StartTime = DateTime.Now;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            filterContext.Controller.ViewBag.EndTime = DateTime.Now;
            filterContext.Controller.ViewBag.ActionDuration =
            filterContext.Controller.ViewBag.StartTime - filterContext.Controller.ViewBag.EndTime;
        }
    }
}