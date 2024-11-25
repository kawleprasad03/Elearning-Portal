using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ElearningPortal
{
    public partial class UserView : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            con = new SqlConnection(cs);
            con.Open();
            if (!IsPostBack)
            {
                LoadUserProfiles();
            }
        }

        private void LoadUserProfiles()
        {
            string email = Session["email"].ToString();
            string query = $"SELECT id, username, email, profilePhoto,password,urole FROM users WHERE email != '{email}'";
            SqlCommand cmd = new SqlCommand(query, con);
                
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            
            dt.Columns.Add("profile_img", typeof(string));

           
            foreach (DataRow row in dt.Rows)
            {
                if (row["profilePhoto"] != DBNull.Value)
                {
                    byte[] imgBytes = (byte[])row["profilePhoto"];
                    string imgBase64 = Convert.ToBase64String(imgBytes);
                    string imgSrc = "data:image/png;base64," + imgBase64;
                    row["profile_img"] = imgSrc;
                }
                else
                {
                    row["profile_img"] = "path_to_default_image.png"; 
                }
            }

            DataList1.DataSource = dt;
            DataList1.DataBind();
                
            
        }
    }
}