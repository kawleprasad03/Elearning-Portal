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
    public partial class EditVideo : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                string videoId = Request.QueryString["id"];

                string query = $"select * from uploadVideo where id = '{videoId}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    TextBox1.Text = reader["topicName"].ToString();
                    TextBox2.Text = reader["topicUrl"].ToString();
                    
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string videoId = Request.QueryString["id"];
            string utopicname = TextBox1.Text;
            string utopicurl = TextBox2.Text;

            string query = $"exec updatevidoetopic '{utopicname}','{utopicurl}','{videoId}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            Response.Write("<script>alert('Data Updated Successfully!');window.location.href='VideoEditorDelete.aspx'</script>");
        }
    }
}