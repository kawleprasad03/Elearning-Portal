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
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(s);
            conn.Open();
        }

        protected void ButtonSendOtp_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string otp = GenerateOtp();


            string query = $"EXEC insetemail '{email}','{otp}'";


            SqlCommand cmd = new SqlCommand(query, conn);



            cmd.ExecuteNonQuery();



            SendOtpToEmail(email, otp);
            Session["Otp"] = otp;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string enteredOtp = TextBox2.Text;
            if (Session["Otp"] != null && enteredOtp == (string)Session["Otp"])
            {

                profileFields.Visible = true;
                Response.Write("<script alert('Email Verified Successfully!')></script>");

            }
            else
            {
                Response.Write("<script>alert('Invalid OTP');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string password = TextBox3.Text;
            string confirmPassword = TextBox4.Text;
            string username = TextBox5.Text;

            if (password == confirmPassword)
            {
                byte[] filePath = null;

                if (FileUpload1.HasFile)
                {
                    filePath = FileUpload1.FileBytes;
                    string hashpassword = HashPassword(password);
                    string query = "exec updateuserdata @username,@profilePhoto,@password,@email";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@profilePhoto", filePath);
                    cmd.Parameters.AddWithValue("@password", hashpassword);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('User Created Successfully!')</script>");
                    Response.Redirect("login.aspx");
                }


            }
        }

        private string GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        private void SendOtpToEmail(string email, string otp)
        {
            using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = "Smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
                smtp.EnableSsl = true;

                var mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress("kawleprasad03@gmail.com");
                mailMessage.To.Add(email);
                mailMessage.Subject = "Your OTP Code";
                mailMessage.Body = $"Your OTP code is: {otp}";

                smtp.Send(mailMessage);
                Response.Write("<script>alert('OTP Send Successfully!')</script>");
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
    }
}