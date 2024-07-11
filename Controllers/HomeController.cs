using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcCRUDoperation.Controllers
{
    public class HomeController : Controller
    {
        MVCEntities context = new MVCEntities();

        public ActionResult Index()
        {
            var listofData = context.Employees.ToList();

            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Create( Employee model) 
        {
            context.Employees.Add(model);
            context.SaveChanges();
            ViewBag.Message = "Data Add Successfully";   
            return View();

        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
        var data = context.Employees.Where(x=> x.EmpID == ID).FirstOrDefault();
            return View(data);
        }

        [HttpPost]
        public ActionResult Edit(Employee model) 
        {
            var data = context.Employees.Where(x => x.EmpID == model.EmpID).FirstOrDefault();
        if(data != null)
            {
             data.EmpName = model.EmpName;   
             data.Email = model.Email;
             data.Salary = model.Salary;   
             data.City = model.City;

                context.SaveChanges();

            }
        return RedirectToAction("Index");
        }
    
        public ActionResult Detail() 
        {
            var data = context.Employees.Where(x => x.EmpID == x.EmpID).FirstOrDefault();
            return View(data);
        
        }

        public ActionResult Delete(int id) 
        {
            var data = context.Employees.Where(x => x.EmpID == x.EmpID).FirstOrDefault();
            context.Employees.Remove(data);
            context.SaveChanges();
            ViewBag.Message = "Delete successfully";
            return RedirectToAction("index");

        }



    }

}