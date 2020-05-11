using Lab6.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            //ApplicationUserManager userManager = new ApplicationUserManager(
            //    new UserStore<ApplicationUser>(
            //        new ApplicationDbContext()));

            //ApplicationUser admin = userManager.FindByEmail("admin@admin.com");
            //ApplicationUser manager = userManager.FindByEmail("manager@manager.com");
            //ApplicationUser client = userManager.FindByEmail("client@client.com");

            //userManager.AddToRole(admin.Id, "Admin");
            //userManager.AddToRole(manager.Id, "Manager");
            //userManager.AddToRole(client.Id, "Client");
            
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

        [Authorize(Roles = "Admin")]
        public ActionResult ForAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Manager")]
        public ActionResult ForManager()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Client")]
        public ActionResult ForClient()
        {
            return View();
        }

        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRole(IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                RoleManager<IdentityRole> roleManager =
                    new RoleManager<IdentityRole>(
                        new RoleStore<IdentityRole>(
                            new ApplicationDbContext()));
                
                roleManager.Create(role);
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}