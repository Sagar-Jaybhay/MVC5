using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            ViewBag.id = id;
            ViewBag.name =Request.QueryString["name"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult NameList()
        {
            ViewData["Today"] = DateTime.Now;
            var list=new List<string>()
            {
                "Sagar Jaybhay",
                "Ram",
                "Raghu",
                "Ravan"

            };
            ViewBag.list = list;
            return View();
        }
    }
}