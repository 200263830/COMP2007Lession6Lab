using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP_2007_Lession6.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;
namespace COMP_2007_Lession6
{
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["sortcolumn"] = "CourseID";
                Session["sortdirection"] = "ASC";
                GetCourses();
            }
        }
        protected void GetCourses()
        {
            using (COMP2007Entities db = new COMP2007Entities())
            {
                string sortstring = Session["sortcolumn"].ToString()+" "+ Session["sortdirection"].ToString();
                // query for students table in entity framwork
                var Courses = from c in db.Courses
                               select new{c.CourseID,c.Title,c.Credits,c.Department.Name};
                
                grcourses.DataSource = Courses.AsQueryable().OrderBy(sortstring).ToList();
                grcourses.DataBind();
                
            }
        }

        protected void grcourses_PageIndexChanged(object sender, GridViewPageEventArgs e)
            {
                //Set New page nummber
                grcourses.PageIndex = e.NewPageIndex;
                GetCourses();
            }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grcourses.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetCourses();
        }

        protected void grcourses_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Get the column to short by
            Session["sortcolumn"] = e.SortExpression;
            //reload the grid
            GetCourses();
            //toggel the direction
            if (Session["sortdirection"].ToString() == "ASC")
            {
                Session["sortdirection"] = "DESC";
            }
            else
            {
                Session["sortdirection"] = "ASC";
            }
        }

        protected void grcourses_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack) { 
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();
                
                    for (int i = 0; i <= grcourses.Columns.Count -1; i++) {
                        if (grcourses.Columns[i].SortExpression == Session["sortcolumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "images/desc.jpg";
                                SortImage.AlternateText = "Sort desc";
                            }
                            else
                            {
                                SortImage.ImageUrl = "images/asc.jpg";
                                SortImage.AlternateText = "Sort asc";
                            }
                        
                            e.Row.Cells[i].Controls.Add(SortImage);
                            
                        }
                    }
                }
               
            }
        }
        }
    }
