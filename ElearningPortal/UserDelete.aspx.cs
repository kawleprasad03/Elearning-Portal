using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class UserDelete : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                // Bind DataList with users data
                BindDeleteUserDataList();
            }
        }

        private void BindDeleteUserDataList()
        {
            string email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand($"SELECT id, username AS name, email, profilePhoto FROM users WHERE email != '{email}'", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DeleteUserDataList.DataSource = reader;
            DeleteUserDataList.DataBind();
            
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
          
            int userId = Convert.ToInt32((sender as Button).CommandArgument);

           
            DeleteUser(userId);

           
            BindDeleteUserDataList();
        }

        private void DeleteUser(int userId)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE id = @UserId", conn);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
            
        }
    }
}