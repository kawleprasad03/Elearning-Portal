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
    public partial class MyCourse : System.Web.UI.Page
    {
      
        SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
                con = new SqlConnection(cs);
                con.Open();
                LoadCourses();
            }
        }

        private void LoadCourses()
        {
            string email = Session["email"].ToString();

            string query = @"
    SELECT 
        c.id,
        c.courseName,
        c.image,
        c.totalAmount,
        up.purchaseDate,
        up.expiryDate,
        up.purchaseAmount
    FROM 
        courses c
    INNER JOIN 
        userPurchase up ON c.courseName = up.mainCourseName
    WHERE 
        up.email = @Email
        AND up.expiryDate > GETDATE()";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Email", email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataListCourses.DataSource = dt;
            DataListCourses.DataBind();

        }

        protected void DataListCourses_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "ShowDetails")
            {

                Session["courseName"] = e.CommandArgument.ToString();
                Response.Redirect("SubCourse.aspx");
            }
        }
    }
}