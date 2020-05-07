using Lab3.DAL;
using Lab3.Models;
using Lab3.ViewModels;
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
            return View(new EmployeeViewModel { Employees =  ctx.Employees.ToList() , Employee = new Employee(), Departments = ctx.Departments.ToList()});
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("EmployeeForm", new EmployeeViewModel { Departments = ctx.Departments.ToList()});
        }

        [HttpPost]
        public ActionResult Add(Employee employee)
        {
            ViewBag.Action = "Add";
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
                    return View("EmployeeForm",  new EmployeeViewModel { Departments = ctx.Departments.ToList() });
                }

                return RedirectToAction(nameof(Index));
            }

            return View("EmployeeForm", new EmployeeViewModel { Departments = ctx.Departments.ToList() });
        }

        [HttpPost]
        public ActionResult AddAjax(Employee employee)
        {
            Response.StatusCode = 422;
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
                    return PartialView("_EmployeeFormPartial",  new EmployeeViewModel { Departments = ctx.Departments.ToList() , Employee = employee} );
                }

                Response.StatusCode = 200;
                return PartialView("_EmployeePartial", new EmployeeViewModel { Departments = ctx.Departments.ToList(), Employee = employee });
            }

            return PartialView("_EmployeeFormPartial", new EmployeeViewModel { Departments = ctx.Departments.ToList(), Employee = employee });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            return View("EmployeeForm", new EmployeeViewModel { Departments = ctx.Departments.ToList(), Employee = ctx.Employees.FirstOrDefault(emp => emp.Id == id) } );
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            ViewBag.Action = "Edit";
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
                    ModelState.AddModelError("Email", "Email Address is already in use");
                    return View("EmployeeForm", new EmployeeViewModel { Departments = ctx.Departments.ToList(), Employee = employee });
                }

                return RedirectToAction(nameof(Index));
            }
            return View("EmployeeForm", new EmployeeViewModel { Departments = ctx.Departments.ToList(), Employee = employee });
        }
    
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(ctx.Employees.FirstOrDefault(emp => emp.Id == id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee employee = ctx.Employees.FirstOrDefault(emp => emp.Id == id);
            ctx.Employees.Remove(employee);
            ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult DeleteAjax(int id)
        {
            Employee employee = ctx.Employees.FirstOrDefault(emp => emp.Id == id);
            ctx.Employees.Remove(employee);
            ctx.SaveChanges();

            return Json(true);
        }
    }
}