using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{ 
    public abstract class BaseController : Controller
    {
        public ProductRepository repo = RepositoryHelper.GetProductRepository();
    }
}