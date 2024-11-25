using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Org.BouncyCastle.Utilities;
using iTextSharp.tool.xml.html.table;
using iTextSharp.tool.xml.html;
using System.Diagnostics;

namespace ElearningPortal
{
    public partial class Invoice : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            string email = Request.QueryString["emailid"];
            string coursename = Request.QueryString["coursename"];
            string totalamount = Request.QueryString["totalamount"];
            DateTime purchaseDate = DateTime.Now;
            DateTime expiryDate = purchaseDate.AddDays(30);

            Label1.Text = "Email ID : " + email;
            Label2.Text = "Purchased Course : " + coursename;
            Label3.Text = "Total Amount : " + totalamount;
            Label4.Text = "Purchased Date : " + purchaseDate.ToString();
            Label5.Text = "Expiry Date : " + expiryDate.ToString();


            string query = "INSERT INTO userPurchase (email, mainCourseName, purchaseAmount, purchaseDate, expiryDate) " +
                            "VALUES (@Email, @MainCourseName, @PurchaseAmount, @PurchaseDate, @ExpiryDate)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@MainCourseName", coursename);
            cmd.Parameters.AddWithValue("@PurchaseAmount", totalamount);
            cmd.Parameters.AddWithValue("@PurchaseDate", purchaseDate);
            cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);

            cmd.ExecuteNonQuery();

            string invoiceHtml = GenerateInvoiceHtml(email, coursename, totalamount, purchaseDate.ToString(), expiryDate.ToString());

            // Generate PDF from HTML and send email
            byte[] pdfBytes = GeneratePdfFromHtml(invoiceHtml);
            SendEmailWithAttachment(pdfBytes);
        }


        private string GenerateInvoiceHtml(string email, string coursename, string totalamount, string purchaseDate, string expiryDate       )
        {
          
            string name = null;
            SqlCommand cmd = new SqlCommand($"select username from users where email = '{email}'",conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read()) {
                name = reader["username"].ToString();
            }
            Random random = new Random();
            int invoice_no = random.Next(1000, 9999);
            string s = @"
<style>
 body {
   font-family: Arial, sans-serif;
   background-color: #f4f4f4;
   padding: 20px;
 }

 .invoice {
   background-color: #fff;
   border-radius: 8px;
   box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
   padding: 30px;
   max-width: 600px;
   margin: 0 auto;
 }

 .invoice-header {
   border-bottom: 2px solid #f1f1f1;
   padding-bottom: 20px;
   margin-bottom: 20px;
   text-align: center;
 }

 .invoice-header h1 {
   font-size: 32px;
   margin: 0;
   color: #333;
 }

 .invoice-info {
   display: flex;
   justify-content: space-between;
   margin-bottom: 15px;
 }

 .invoice-info p {
   margin: 5px 0;
   color: #555;
 }

 .invoice-table {
   width: 100%;
   border-collapse: collapse;
   margin-bottom: 20px;
 }

 .invoice-table th, .invoice-table td {
   padding: 12px;
   border-bottom: 1px solid #f1f1f1;
   text-align: left;
 }

 .invoice-table th {
   background-color: blue;
   color: #333;
   font-weight: bold;
 }

 .invoice-table td {
   color: #666;
 }

 .invoice-total {
   display: flex;
   justify-content: space-between;
   font-weight: bold;
   font-size: 18px;
   margin-top: 10px;
 }

 .footer {
   margin-top: 20px;
   text-align: center;
   color: #888;
   font-size: 14px;
 }
</style>

<body>
 <div class='invoice'>
   <div class='invoice-header'>
     <h1>Invoice</h1>
   </div>
   <div class='invoice-info'>
     <p><strong>Invoice Number:</strong> INV-00" + $"{invoice_no}" + @"</p>
     <p><strong>Name:</strong> " + $"{name}" + @"</p>
     <p><strong>Purchase Date:</strong> " + $"{purchaseDate}" + @"</p>
   </div>
   <div class='invoice-info'>
     <p><strong>Email ID:</strong> " + $"{email}" + @"</p>
     <p><strong>Course Name:</strong> " + $"{coursename}" + @"</p>
   </div>
   <table class='invoice-table'>
     <thead>
       <tr>
         <th>Course</th>
         <th>Paid Amount</th>
         <th>Expiry Date</th>
       </tr>
     </thead>
     <tbody>
       <tr>
<td>" + $"{coursename}" + @"</td>
<td>" + $"{totalamount}" + @"</td>
<td>" + $"{expiryDate}" + @"</td>
 </tr>
     </tbody>
   </table>

   <div class='invoice-total'>
     <p><strong>Total Paid Amount:</strong></p>
     <p>" + $"{totalamount} " + @"</p>
   </div>
 </div>
</body>
";

            return s;
        }


        private byte[] GeneratePdfFromHtml(string htmlContent)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                Document document = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
                PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                document.Open();

                using (StringReader stringReader = new StringReader(htmlContent))
                {
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, stringReader);
                }

                document.Close();
                return memoryStream.ToArray();
            }
        }

        private void SendEmailWithAttachment(byte[] attachmentBytes)
        {
            string email = Session["email"].ToString();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("kawleprasad03@gmail.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = "Fees Receipt";
            mailMessage.Body = "Please find the Fees Receipt attachment.";
            mailMessage.IsBodyHtml = true;

            // Attach PDF
            MemoryStream stream = new MemoryStream(attachmentBytes);
            mailMessage.Attachments.Add(new Attachment(stream, "Receipt.pdf", "application/pdf"));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new NetworkCredential("kawleprasad03@gmail.com", "fzdo rrmf uhce iptx");
            smtpClient.EnableSsl = true;

            try
            {
                smtpClient.Send(mailMessage);
                Response.Write("<script>alert('Receipt Sent Successfully');</script>");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                stream.Dispose();
                mailMessage.Dispose();
            }
        }

    }
}