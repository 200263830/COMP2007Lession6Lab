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
    public partial class stud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if save wasnt click and we have a studenID in url
            if ((!IsPostBack) && (Request.QueryString.Count > 0)){
                GetStudents();
            }

        }
        protected void GetStudents()
        {
            Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            // connect with database
            using(COMP2007Entities db=new COMP2007Entities())
            {
                Student s = (from objs in db.Students
                             where objs.StudentID == StudentID
                             select objs).FirstOrDefault();
            //map data with form controls
                if (s != null) { 
                txtLastname.Text = s.LastName;
                txtfirstname.Text = s.FirstMidName;
                txtenrlldate.Text = s.EnrollmentDate.ToShortDateString();
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            //add eF to onnect sqlserver
            using (COMP2007Entities db = new COMP2007Entities())
            {
                Student s = new Student();
                Int32 StudentID = 0;
                //check query string
                if (Request.QueryString["StudentID"]!= null)
                {
                    //get ID from URL
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
                    s = (from objs in db.Students
                         where objs.StudentID == StudentID
                         select objs).FirstOrDefault();
                }
                s.LastName = txtLastname.Text;
                s.FirstMidName = txtfirstname.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtenrlldate.Text);
                //call add only if there is no student id
                if (StudentID == 0)
                {
                    db.Students.Add(s);
                }                
                db.SaveChanges();

                Response.Redirect("students.aspx");
            }
        
        }
    }
}