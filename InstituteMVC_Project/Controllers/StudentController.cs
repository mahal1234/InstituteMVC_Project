using InstituteMVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC_Project.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        //object of the ADO.Net Model class to conect with the database for usinf the conceot of the crud 
        InstituteDBEntities dataDB = new InstituteDBEntities();

        //List Method is used to display tthe whole record from the database table 
        public ActionResult DisplayStudent()
        {
            return View(dataDB.Students.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();

        }

        // POST: Student/Create
        //here is the coed to enter the record in the database table 
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Student studentToCreate)
        {
            if (!ModelState.IsValid)
                return View();
            dataDB.Students.Add(studentToCreate);
            dataDB.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("DisplayStudent");
        }

        // GET: Student/Edit/5
        //if we want to update the record then we must have to need the id to update 
        public ActionResult Edit(int id)
        {
            var studentToEdit = (from m in dataDB.Students where m.ID == id select m).First();
            return View(studentToEdit);

            
        }

        // POST: Student/Edit/5
        //after passign the id we can edit the details of the inserted record 
        [HttpPost]
        public ActionResult Edit(Student studentToEdit)
        {
            var orignalRecord = (from m in dataDB.Students where m.ID == studentToEdit.ID select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dataDB.Entry(orignalRecord).CurrentValues.SetValues(studentToEdit);
            dataDB.SaveChanges();
            return RedirectToAction("DisplayStudent");

        }

        // GET: Student/Delete/5
        //when we want to delee the record from the table then we must have to pass the id 
        public ActionResult Delete(Student studentToDelete)
        {
            var d = dataDB.Students.Where(x => x.ID == studentToDelete.ID).FirstOrDefault();
            dataDB.Students.Remove(d);
            dataDB.SaveChanges();
            return RedirectToAction("DisplayStudent");

            
        }

        // POST: Student/Delete/5
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
