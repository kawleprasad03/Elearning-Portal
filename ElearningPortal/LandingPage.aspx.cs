using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class LandingPage : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        private void LoadCourses()
        {
            
            string query = "SELECT id, courseName, image, totalAmount FROM courses";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

          
            CourseRepeater.DataSource = dt;
            CourseRepeater.DataBind();
            
        }
    }
}