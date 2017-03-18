using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC5Course.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page. Test000123.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Login(string ReturnUrl="")
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVM form, string ReturnUrl="")
        {
            if (ModelState.IsValid)
            {
                FormsAuthentication.RedirectFromLoginPage(form.userName,false);
                TempData["loginInfo"] = form;
                //return Content(form.userName + " : " + form.userPassword);

                return ReturnUrl == null|| ReturnUrl=="" ? Redirect("index") : Redirect(ReturnUrl);
            }
            else
            {
                return RedirectToAction("Index");
            }
            //return Content("Login failed.");
        }
        [HttpPost]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("Index");
        }
    }
}