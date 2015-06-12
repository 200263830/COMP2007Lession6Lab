using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//refrence the EF models

using COMP_2007_Lession6.Models;
using System.Web.ModelBinding;

namespace COMP_2007_Lession6
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetStud();
            }
        }

        protected void GetStud()
        {
            // onnect to EF model
            using (COMP2007Entities db = new COMP2007Entities())
            {
                // query for students table in entity framwork
                var Students = from s in db.Students
                               select s;
                grstudent.DataSource = Students.ToList();
                grstudent.DataBind();
            }
        }

       protected void grstudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           //store which row was clicked
            Int32 selectedRow = e.RowIndex;
           //get the slected StudentID using the grid's dataview collection
            Int32 studentID = Convert.ToInt32(grstudent.DataKeys[selectedRow].Values["StudentID"]);
           //use ef to delete row
            using (COMP2007Entities db = new COMP2007Entities())
            {
                Student s=(from objs in db.Students where objs.StudentID==studentID select objs).FirstOrDefault();

                //do delete 
                db.Students.Remove(s);
                db.SaveChanges();
                GetStud();
                
            }
        }
       
    }

}