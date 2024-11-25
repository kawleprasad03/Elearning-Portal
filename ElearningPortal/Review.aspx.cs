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
    public partial class Review : System.Web.UI.Page
    {
        private SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            lblMainCourse.Text = "Main Course: " + Session["courseName"].ToString();
            lblSubCourse.Text = "Sub Course: " + Session["subCourseName"].ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string mainCourseName = Session["courseName"].ToString();
            string subCourseName = Session["subCourseName"].ToString();
            string email = Session["email"].ToString();
            int rating = int.Parse(rblRating.SelectedValue);
            string description = txtDescription.Text;

    
            string query = "INSERT INTO Reviews (email , MainCourseName, SubCourseName, Rating, Description,Status) VALUES (@email,@MainCourseName, @SubCourseName, @Rating, @Description, @Status)";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@MainCourseName", mainCourseName);
                    cmd.Parameters.AddWithValue("@SubCourseName", subCourseName);
                    cmd.Parameters.AddWithValue("@Rating", rating);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Status", "Pending");


            cmd.ExecuteNonQuery();
                
            

            lblMessage.Text = "Thank you for your review!";
            ClearForm();
        }

        private void ClearForm()
        {
            rblRating.ClearSelection();
            txtDescription.Text = string.Empty;
        }
    }
}