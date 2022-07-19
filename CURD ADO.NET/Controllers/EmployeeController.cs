using CURD_ADO.NET.DAL;
using CURD_ADO.NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CURD_ADO.NET.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController


        Employe1DAL db = new Employe1DAL();       //code

        public ActionResult Index()
        {

            var model = db.GetAllEmployee();  //code

            return View(model);   // code
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee1 employee)
        {
            try
            {


                int result = db.AddEmployee(employee);//code
                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {

            var model = db.GetEmployee1ById(id); //code
            return View(model);
            
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee1 employee)
        {
            try
            {
                int result = db.UpdateEmployee(employee);//code

                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.GetEmployee1ById(id); //code
            return View(model);

        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        [ActionName("Delete")]
        public ActionResult Delete1(int id)
        {
            try
            {
                int result = db.DeleteEmployee(id);//code

               

                if (result == 1)
                    return RedirectToAction(nameof(Index));
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
