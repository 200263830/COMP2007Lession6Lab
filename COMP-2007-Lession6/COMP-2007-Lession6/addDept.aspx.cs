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
    public partial class addDept : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if save wasnt click and we have a studenID in url
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                GetDept();
            }
        }
        protected void GetDept()
        {
            Int32 DeptID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
            // connect with database
            using (COMP2007Entities db = new COMP2007Entities())
            {
                Department d = (from objs in db.Departments
                             where objs.DepartmentID == DeptID
                             select objs).FirstOrDefault();
                //map data with form controls
                if (d != null)
                {
                    txtDeptName.Text = d.Name;
                    txtBudget.Text = Convert.ToString(d.Budget);
                    
                }
            }
        }

        protected void btnDeptsave_Click(object sender, EventArgs e)
        {
            using (COMP2007Entities db = new COMP2007Entities())
            {
                Department d = new Department();
                Int32 DeptID = 0;
                //check query string
                if (Request.QueryString["DepartmentID"] != null)
                {
                    //get ID from URL
                    DeptID = Convert.ToInt32(Request.QueryString["DepartmentID"]);
                    d = (from objs in db.Departments
                         where objs.DepartmentID == DeptID
                         select objs).FirstOrDefault();
                }
                d.Name = txtDeptName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);
                
                //call add only if there is no student id
                if (DeptID == 0)
                {
                    db.Departments.Add(d);
                }               
                db.SaveChanges();

                Response.Redirect("dept.aspx");
            }

        }

        
    }
}
