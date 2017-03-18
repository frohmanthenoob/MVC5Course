using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class EmptyController : Controller
    {
        public ActionResult Index()
        {
            return View("123");
        }
        public ActionResult View1()
        {
            return PartialView();
        }
        public ActionResult View2()
        {
            return View();
        }
        public ActionResult File1()
        {
            return File(Server.MapPath("~/Content/pic.png"), "image/png");
        }
        public ActionResult File2()
        {
            return File(Server.MapPath("~/Content/pic.png"), "image/png", "我的圖片.png");
        }
    }
}