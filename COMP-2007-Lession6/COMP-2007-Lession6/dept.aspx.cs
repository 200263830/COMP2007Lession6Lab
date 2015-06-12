using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP_2007_Lession6.Models;
using System.Web.ModelBinding;

namespace COMP_2007_Lession6
{
    public partial class dept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDept();
            }
        }
        protected void GetDept()
        {
            using (COMP2007Entities db = new COMP2007Entities())
            {
                // query for students table in entity framwork
                var Department = from s in db.Departments
                               select s;
                GrdDepartment.DataSource = Department.ToList();
                GrdDepartment.DataBind();
            }
        }
        protected void GrdDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            Int32 selectedRow = e.RowIndex;
            //get the slected StudentID using the grid's dataview collection
            Int32 deptID = Convert.ToInt32(GrdDepartment.DataKeys[selectedRow].Values["DepartmentID"]);
            //use ef to delete row
            using (COMP2007Entities db = new COMP2007Entities())
            {
                Department d = (from objs in db.Departments where objs.DepartmentID == deptID select objs).FirstOrDefault();

                //do delete 
                db.Departments.Remove(d);
                db.SaveChanges();
                GetDept();

            }
        }
    }
}