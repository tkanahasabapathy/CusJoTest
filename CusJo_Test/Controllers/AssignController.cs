using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CusJo_Test.Controllers
{
    public class AssignController : Controller
    {
        public ActionResult Assign()
        {
            ViewBag.Title = "Assign User Privilege";

            return View();
        }
    }
}
