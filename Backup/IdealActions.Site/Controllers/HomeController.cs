using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdealActions.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Free tool for associating actions with rewards.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Ideal Actions is a Free Tool that connects Actions to Rewards.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Wade Harvey.";

            return View();
        }
    }
}
