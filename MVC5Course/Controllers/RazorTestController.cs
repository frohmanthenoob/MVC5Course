using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class RazorTestController : Controller
    {
        // GET: RazorTest
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult test1()
        {
            int[] data = new int[] { 1,2,3,4,5};
            return PartialView(data);
        }
    }
}