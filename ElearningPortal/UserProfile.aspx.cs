using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Razorpay.Api;
using System.Drawing.Printing;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using static Google.Apis.Requests.BatchRequest;
using System.Web.UI.HtmlControls;

namespace ElearningPortal
{
    public partial class UserProfile : System.Web.UI.Page
    {
        SqlConnection con;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            con = new SqlConnection(cs);
            con.Open();
            if (!IsPostBack)
            {
                string userEmail = Session["email"].ToString();
                LoadUserData(userEmail);
                LoadCourses();
            }
        }


        private void LoadUserData(string email)
        {
            string query = $"SELECT username, email, profilePhoto FROM users WHERE email ='{email}'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                UserName.Text = "User Name : " + reader["username"].ToString();
                Email.Text = "Email : " + reader["email"].ToString();
                byte[] profilePhoto = reader["profilePhoto"] as byte[];
                if (profilePhoto != null)
                {
                    string base64Image = Convert.ToBase64String(profilePhoto);
                    ProfileImage.ImageUrl = "data:image/png;base64," + base64Image;
                }
                else
                {
                    ProfileImage.ImageUrl = "~/Images/default.png";
                }
            }

        }





        private void LoadCourses()
        {

            string userEmail = Session["email"].ToString();


            // string query = "exec fetchnotbuycourse @UserEmail";
            string query = @"SELECT 
    c.id, 
    c.courseName, 
    c.image, 
    c.totalAmount,
    ISNULL(
        (SELECT AVG(CAST(r.Rating AS FLOAT)) 
         FROM Reviews r 
         WHERE r.MainCourseName = c.courseName AND r.Status = 'accepted'), 
        0
    ) AS AverageRating
FROM 
    courses c
LEFT JOIN 
    userPurchase up ON c.courseName = up.mainCourseName AND up.email = @UserEmail
WHERE 
    up.id IS NULL 
    AND c.totalAmount > 0
";

            SqlCommand cmd = new SqlCommand(query, con);
                
            cmd.Parameters.AddWithValue("@UserEmail", userEmail);


            SqlDataReader reader = cmd.ExecuteReader();
            
            CourseRepeater.DataSource = reader;
            CourseRepeater.DataBind();
            
                
            }





        protected void BuyButton_Command(object sender, CommandEventArgs e)
        {
            string keyId = "rzp_test_Kl7588Yie2yJTV";
            string keySecret = "6dN9Nqs7M6HPFMlL45AhaTgp";
            string[] args = e.CommandArgument.ToString().Split('|');
            string courseId = args[0];
            string courseName = args[1];
            string TotalAmount = args[2];
            RazorpayClient razorpayClient = new RazorpayClient(keyId, keySecret);
            //int userId = 10;
            double amount = int.Parse(TotalAmount);

            string email = Session["email"].ToString();
            // Create an order
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", amount * 100); // Amount should be in paisa (multiply by 100 for rupees)
            options.Add("currency", "INR");
            options.Add("receipt", "order_receipt_123");
            options.Add("payment_capture", 1); // Auto capture payment

            Razorpay.Api.Order order = razorpayClient.Order.Create(options);

            string orderId = order["id"].ToString();

            // Generate checkout form and redirect user to Razorpay payment page
            string razorpayScript = $@"
    var options = {{
        'key': '{keyId}',
        'amount': {amount * 100},
        'currency': 'INR',
        'name': 'eLEARNING',
        'description': 'Checkout Payment',
        'order_id': '{orderId}',
        'handler': function(response) {{
           
     
            alert('Payment successful. Payment ID: ' + response.razorpay_payment_id);

           window.location.href = 'Invoice.aspx?emailid=' + '{email}' + '&coursename=' + '{courseName}'+ '&totalamount=' + '{TotalAmount}';
        }},
        'prefill': {{
            'name': 'Krish Kheloji',
            'email': 'khelojikrish@gmail.com',
            'contact': '7208921898'
        }},
        'theme': {{
            'color': '#F37254'
        }}
    }};
    var rzp1 = new Razorpay(options);
    rzp1.open();";

            // Register the script on the page

            ClientScript.RegisterStartupScript(this.GetType(), "razorpayScript", razorpayScript, true);

           
        }


        protected void CourseRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                decimal averageRating = Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "AverageRating"));
                int fullStars = (int)Math.Floor(averageRating);
                int halfStars = (averageRating % 1 >= 0.5m) ? 1 : 0;
                int emptyStars = 5 - fullStars - halfStars;

                // Generate star HTML
                var starsContainer = (HtmlGenericControl)e.Item.FindControl("StarsContainer");
                string starsHtml = "";

                // Full stars in gold
                for (int i = 0; i < fullStars; i++)
                {
                    starsHtml += "<small class='fa fa-star star-gold'></small>";
                }
                // Half star in gold
                if (halfStars > 0)
                {
                    starsHtml += "<small class='fa fa-star-half-alt star-gold'></small>";
                }
                // Empty stars in gray
                for (int i = 0; i < emptyStars; i++)
                {
                    starsHtml += "<small class='fa fa-star star-muted'></small>";
                }

                // Set the generated HTML
                starsContainer.InnerHtml = starsHtml;
            }
        }




    }
}
