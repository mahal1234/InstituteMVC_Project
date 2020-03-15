using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace InstituteMVC_Project.Models
{
    public class data_Model
    {
        //Conn Instance Object of SQl Connection Class
        SqlConnection sqlCon;
        //String ConnectionString for Making the Connection between the Class and Database
        String conStr = "Data Source=DESKTOP-K5FQKLS\\SQLEXPRESS;Initial Catalog=DBInstitute;Integrated Security=True";
        //Cmd Instance Object to Create the Relation between  the Commad to execute the sql Command 
        SqlCommand sqlcmd;
        // DReader is instance to read the data from the database and pass to the Class
        SqlDataReader DReader;

        //this method is used to execute the sql query like insert delete update in the database tables
        public void SqlQuery(String query)
        {
            sqlCon = new SqlConnection(conStr);
            sqlCon.Open();
            sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        // this method is used to search the record from the data base and then pass the whole record to the query using where clause of the sql
        public DataTable srchRecord(String qry)
        {
            DataTable tbl = new DataTable();


            sqlCon = new SqlConnection(conStr);

            sqlCon.Open();
            sqlcmd = new SqlCommand(qry, sqlCon);

            DReader = sqlcmd.ExecuteReader();

            tbl.Load(DReader);

            sqlCon.Close();

            return tbl;
        }

    }
}