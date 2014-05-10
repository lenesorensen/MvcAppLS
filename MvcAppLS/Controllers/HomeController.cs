using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppLS.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Dette er About siden";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Dette er Contact siden";

            return View();
        }
    }
}