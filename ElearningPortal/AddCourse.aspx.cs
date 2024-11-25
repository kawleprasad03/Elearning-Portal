using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class AddCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        List<string> emailList = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string coursename = TextBox1.Text;
            byte[] courseimage = null;
            if (FileUpload1.HasFile)
            {
                courseimage = FileUpload1.FileBytes;
                string query = "exec insertcourseproc @coursename,@courseimage";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@coursename", coursename);
                cmd.Parameters.AddWithValue("@courseimage", courseimage);
                cmd.ExecuteNonQuery();
                sendMail(coursename);
                Response.Write("<script>alert('Course Added Successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please Upload File!');</script>");
            }
        }

        private void sendMail(string coursename)
        {
            string role = "User";
            string query = $"SELECT email FROM users WHERE urole='{role}'";
            SqlCommand cmd = new SqlCommand(query, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                string userEmail = reader["email"].ToString();
                if (!string.IsNullOrEmpty(userEmail))
                {
                    emailList.Add(userEmail);
                }
            }


            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("kawleprasad03@gmail.com");
            foreach (string email in emailList)
            {
                mailMessage.To.Add(email);
                
            }
            mailMessage.Subject = $"{coursename} New Course Added";
            mailMessage.Body = $"You can see '{coursename}' Course Soon!";
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }
}