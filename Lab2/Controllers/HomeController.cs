using Lab2.Models;
using Lab2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Employee employee)
        {

            if (ModelState.IsValid)
            {
                var ctx = new ModelContext();

                ctx.Employees.Add(employee);
                try { 
                    ctx.SaveChanges();
                } catch (Exception ex)
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View();
                }

                return View("Success", employee);
            }
            return View();
        }
    }
}