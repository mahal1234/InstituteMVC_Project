using InstituteMVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC_Project.Controllers
{
    public class SalaryController : Controller
    {
        // GET: Salary

        //object of the ADO.Net Model class to conect with the database for usinf the conceot of the crud 
        InstituteDBEntities dataDB = new InstituteDBEntities();
        //List Method is used to display tthe whole record from the database table 
        public ActionResult DisplaySalary()
        {
            return View(dataDB.Salaries.ToList());
        }

        // GET: Salary/Details/5
        
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Salary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Salary/Create
        //here is the coed to enter the record in the database table 
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Salary StaffToPay)
        {

            if (!ModelState.IsValid)
                return View();
            dataDB.Salaries.Add(StaffToPay);
            dataDB.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("DisplaySalary");
        }

        // GET: Salary/Edit/5
        //if we want to update the record then we must have to need the id to update 
        public ActionResult Edit(int id)
        {
           var staffToPay = (from m in dataDB.Salaries where m.ID == id select m).First();
            return View(staffToPay);
        }

        // POST: Salary/Edit/5
        //after passign the id we can edit the details of the inserted record 
        [HttpPost]
        public ActionResult Edit(Salary StaffToSalary)
        {
            var orignalRecord = (from m in dataDB.Salaries where m.ID == StaffToSalary.ID select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dataDB.Entry(orignalRecord).CurrentValues.SetValues(StaffToSalary);

            dataDB.SaveChanges();
            return RedirectToAction("DisplaySalary");

        }


        // GET: Salary/Delete/5
        //when we want to delete the record from the table then we must have to pass the id 
        public ActionResult Delete(Salary StaffToDel)
        {
            var d = dataDB.Salaries.Where(x => x.ID == StaffToDel.ID).FirstOrDefault();
            dataDB.Salaries.Remove(d);
            dataDB.SaveChanges();
            return RedirectToAction("DisplaySalary");
            
        }

        // POST: Salary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
