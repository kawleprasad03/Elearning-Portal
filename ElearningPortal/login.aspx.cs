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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(s);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string em = TextBox1.Text, pass = TextBox2.Text;
            string hashpassword = HashPassword(pass);
            string q = $"exec checkuserlogin '{em}','{hashpassword}'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (rdr["email"].Equals(em) && rdr["password"].Equals(hashpassword) && rdr["urole"].Equals("User"))
                    {
                        Session["email"] = em;
                        Response.Redirect("UserProfile.aspx");
                    }
                    else if (rdr["email"].Equals(em) && rdr["password"].Equals(hashpassword) && rdr["urole"].Equals("Admin"))
                    {
                        Session["email"] = em;
                        Response.Redirect("AdminHome.aspx");
                    }
                    
                }

            }
            else
            {
                Response.Write("<script>alert('Invalid Credintial');</script>");
            }

        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string clientId = "1091820565810-901ek849lhu65jqkg06oi0vv05s05fav.apps.googleusercontent.com";
            string redirectUri = "https://localhost:44398/GoogleAuthRedirect"; // This is your redirect URI (must match the URI in Google Developer Console)

            // Construct Google OAuth URL
            string googleOAuthUrl = $"https://accounts.google.com/o/oauth2/v2/auth?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&scope=email profile&access_type=online";

            // Redirect user to Google OAuth page
            Response.Redirect(googleOAuthUrl);
        }

      
    }
}