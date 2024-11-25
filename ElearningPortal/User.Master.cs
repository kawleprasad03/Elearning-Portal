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
    public partial class User : System.Web.UI.MasterPage
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();

            string email = Session["email"].ToString();

            SqlCommand cmd = new SqlCommand($"SELECT username FROM users where email = '{email}'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Label1.Text = reader["username"].ToString();
            }
        }
    }
}