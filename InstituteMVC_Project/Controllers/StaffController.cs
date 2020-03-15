using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteMVC_Project.Models;
namespace InstituteMVC_Project.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        //object of the ADO.Net Model class to conect with the database for usinf the conceot of the crud 
        InstituteDBEntities dataDB = new InstituteDBEntities();


        //List Method is used to display tthe whole record from the database table 
        public ActionResult DisplayStaff()
        {
            return View(dataDB.Staffs.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        //here is the coed to enter the record in the database table 
        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Staff staffToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            dataDB.Staffs.Add(staffToCreate);
            dataDB.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("DisplayStaff");
        }

        // GET: Staff/Edit/5
        //if we want to update the record then we must have to need the id to update 
        public ActionResult Edit(int id)
        {
            var staffToEdit = (from m in dataDB.Staffs where m.id == id select m).First();
            return View(staffToEdit);
        }

        // POST: Staff/Edit/5
        //after passign the id we can edit the details of the inserted record 
        [HttpPost]
        public ActionResult Edit(Staff StaffToEdit)
        {
            var orignalRecord = (from m in dataDB.Staffs where m.id == StaffToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dataDB.Entry(orignalRecord).CurrentValues.SetValues(StaffToEdit);

            dataDB.SaveChanges();
            return RedirectToAction("DisplayStaff");

        }

        // GET: Staff/Delete/5
        //when we want to delee the record from the table then we must have to pass the id 
        public ActionResult Delete(Staff StaffToDelete)
        {

            var d = dataDB.Staffs.Where(x => x.id == StaffToDelete.id).FirstOrDefault();
           dataDB.Staffs.Remove(d);
            dataDB.SaveChanges();
            return RedirectToAction("DisplayStaff");


            
        }

        // POST: Staff/Delete/5
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
