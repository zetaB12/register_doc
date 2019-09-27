using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var dey = new Class1();
            ViewBag.nombre = dey.name = "deyvi";
            return View();
        }
    }
}