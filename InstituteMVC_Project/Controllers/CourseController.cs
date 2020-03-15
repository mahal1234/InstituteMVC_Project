using InstituteMVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InstituteMVC_Project.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        //object of the ADO.Net Model class to conect with the database for usinf the conceot of the crud 
        InstituteDBEntities dataDB = new InstituteDBEntities();
        //List Method is used to display tthe whole record from the database table 
        public ActionResult DisplayCourse()
        {
            return View(dataDB.Courses.ToList());
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        //with the help of create method we can add new record in the file 
        public ActionResult Create()
        {
            return View();
        }

        //here is the coed to enter the record in the database table 
        // POST: Course/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Course CourseToAdd)
        {
            if (!ModelState.IsValid)
                return View();
            dataDB.Courses.Add(CourseToAdd);
            dataDB.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("DisplayCourse");


        }

        // GET: Course/Edit/5
        //if we want to update the record then we must have to need the id to update 
        public ActionResult Edit(int id)
        {
            var CourseToEdit = (from m in dataDB.Courses where m.id == id select m).First();
            return View(CourseToEdit);
        }

        // POST: Course/Edit/5
        //after passign the id we can edit the details of the inserted record 
        [HttpPost]
        public ActionResult Edit(Course CourseToEdit)
        {

            var orignalRecord = (from m in dataDB.Courses where m.id == CourseToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            dataDB.Entry(orignalRecord).CurrentValues.SetValues(CourseToEdit);

            dataDB.SaveChanges();
            return RedirectToAction("DisplayRecord");
        }

        // GET: Course/Delete

        //when we want to delee the record from the table then we must have to pass the id 
        public ActionResult Delete(Course CourseToDelete)
        {
            var d = dataDB.Courses.Where(x => x.id == CourseToDelete.id).FirstOrDefault();
            dataDB.Courses.Remove(d);
            dataDB.SaveChanges();
            return RedirectToAction("DisplayStaff");

            
        }

        // POST: Course/Delete/5
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
