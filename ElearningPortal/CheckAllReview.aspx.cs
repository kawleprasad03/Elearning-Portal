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
    public partial class CheckAllReview : System.Web.UI.Page
    {
        private SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
 
                string query = "SELECT Id, Email, MainCourseName, SubCourseName, Rating, Description FROM Reviews WHERE Status = 'Pending'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
                
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvReviews.DataSource = dt;
                    gvReviews.DataBind();
                
            
        }

        protected void gvReviews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int reviewId = Convert.ToInt32(e.CommandArgument);

        
                string status = e.CommandName == "Accept" ? "Accepted" : "Rejected";

                string query = "UPDATE Reviews SET Status = @Status WHERE Id = @Id";
            SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@Id", reviewId);
                   
                    cmd.ExecuteNonQuery();
                
            BindGrid();
        }
    }
}