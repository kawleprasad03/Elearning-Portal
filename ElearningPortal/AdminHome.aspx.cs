using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class AdminHome : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadDashboardData();
                List<int> monthlySales = GetMonthlySales();
                JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
                string monthlySalesJson = jsSerializer.Serialize(monthlySales);

                ClientScript.RegisterStartupScript(this.GetType(), "monthlySalesData", $"var monthlySalesData = {monthlySalesJson};", true);
            }
        }

        private void LoadDashboardData()
        {
            int userCount = GetUserCount();
            int courseCount = GetCourseCount();
            int totalSales = GetTotalSales();

        
            Label1.Text = userCount.ToString(); 
            Label2.Text = courseCount.ToString(); 
            Label3.Text = $"₹ {totalSales}"; 
        }

        private int GetUserCount()
        {
            string email = Session["email"].ToString();
            string query = $"SELECT COUNT(*) FROM users WHERE email != '{email}'";
            SqlCommand cmd = new SqlCommand(query, conn);
                
                   
            return (int)cmd.ExecuteScalar();
                
            
        }

        private int GetCourseCount()
        {
          
            string query = "SELECT COUNT(*) FROM courses";
            SqlCommand cmd = new SqlCommand(query, conn);
                
                  
            return (int)cmd.ExecuteScalar();
                
            
        }

        private int GetTotalSales()
        {
           
            string query = "SELECT SUM(purchaseAmount) FROM userPurchase";
            SqlCommand cmd = new SqlCommand(query, conn);
            var result = cmd.ExecuteScalar();
            return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                
            
        }


        private List<int> GetMonthlySales()
        {
            var monthlySales = new int[12];

               
            string query = @"
            SELECT MONTH(purchaseDate) AS Month, SUM(purchaseAmount) AS TotalSales
            FROM userPurchase
            GROUP BY MONTH(purchaseDate)
            ORDER BY MONTH(purchaseDate)";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int month = reader.GetInt32(0) - 1;
                monthlySales[month] = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
            }
            

            return new List<int>(monthlySales);
        }
    }
}