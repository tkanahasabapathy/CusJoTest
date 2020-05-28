using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CusJo_Test.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Main()
        {
            ViewBag.Title = "Main Page";

            return View();
        }
    }
}
