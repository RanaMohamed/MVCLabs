using Lab3.DAL;
using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class EmployeesController : Controller
    {
        ModelContext ctx = new ModelContext();

        // GET: Employees
        [HttpGet]
        public ActionResult Index()
        {
            return View(ctx.Employees.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ctx.Employees.Add(employee);
                try
                {
                    ctx.SaveChanges();
                }
                catch
                {
                    ModelState.AddModelError("Email", "Email Address is already in use");
                    return View();
                }

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View("Add", ctx.Employees.FirstOrDefault(emp => emp.Id == id));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {


                ctx.Employees.Attach(employee);
                ctx.Entry(employee).State = EntityState.Modified;
                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    return RedirectToAction(nameof(Edit), employee);
                }

                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit), employee);
        }
    
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(ctx.Employees.FirstOrDefault(emp => emp.Id == id));
        }
    }
}