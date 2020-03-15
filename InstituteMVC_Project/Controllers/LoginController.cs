using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InstituteMVC_Project.Models;
namespace InstituteMVC_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult SignIn()
        {
            return View();
        }


        public ActionResult sign_In(Login Admin)
        {

            DataTable tbl = new DataTable();
            data_Model obj_connection = new data_Model();

            tbl = obj_connection.srchRecord("Select * from AdminDetails where AdminID='" + Admin.AdminID + "' and AdminPassword='" +Admin.AdminPassword + "'");
            if (tbl.Rows.Count > 0)
            {
                return View("AdminWork");
            }
            else
            {
                return View("AdminWrong");
            }


        }


    }
}