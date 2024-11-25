using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class SubCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                
                string mainCourseName = Session["courseName"].ToString();
                BindSubCourses(mainCourseName);
                
            }
        }

        private void BindSubCourses(string mainCourseName)
        {
            
            string query = "SELECT subCourseName, price, image FROM subCourses WHERE mainCourseName = @mainCourseName";
            SqlCommand cmd = new SqlCommand(query, conn);
                
            cmd.Parameters.AddWithValue("@mainCourseName", mainCourseName);

            SqlDataReader reader = cmd.ExecuteReader();
                   
            DataListSubCourses.DataSource = reader;
            DataListSubCourses.DataBind();
                    
                
            
        }

        protected void DataListSubCourses_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "WatchCourse")
            {
                
                string subCourseName = e.CommandArgument.ToString();

                
                Session["subCourseName"] = subCourseName;
                Response.Redirect("WatchCourse.aspx");
            }
        }

    }
}