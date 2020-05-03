using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RsvpForm(string name, string email, string phone, string choice)
        {
            if (name != null && email != null)
            {
                ViewBag.Name = name;
                return View("Welcome");
            }
            return View();
        }
    }
}