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
    public partial class AddSubCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindCourses();
            }
        }

        private void BindCourses()
        {
            string query = "exec fetchcoursename";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DropDownList1.DataSource = reader;
            DropDownList1.DataTextField = "courseName";
            DropDownList1.DataValueField = "courseName";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, new ListItem("Select Option", "Selected Option"));
            DropDownList1.Items[0].Selected = true;
            DropDownList1.Items[0].Attributes.Add("disabled", "true");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string coursename = DropDownList1.SelectedValue;
            string subcoursename = TextBox1.Text;
            int price = int.Parse(TextBox2.Text);
            byte[] subimage = null;
            if (FileUpload1.HasFile)
            {
                subimage = FileUpload1.FileBytes;
                string query = "exec insertsubcourseproc @coursename,@subcoursename,@price,@subimage";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@coursename", coursename);
                cmd.Parameters.AddWithValue("@subcoursename", subcoursename);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@subimage", subimage);
                cmd.ExecuteNonQuery();

                SqlCommand cmd1 = new SqlCommand($"select totalAmount from courses where courseName='{coursename}'", conn);
                SqlDataReader rdr = cmd1.ExecuteReader();
                int totalamount = 0;
                if (rdr.Read())
                {
                    totalamount = int.Parse(rdr["totalAmount"].ToString());
                }

                totalamount += price;
                string query1 = $"exec updatecourseamount {totalamount},'{coursename}'";
                SqlCommand cmd2 = new SqlCommand(query1, conn);
                cmd2.ExecuteNonQuery();
                Response.Write("<script>alert('Sub Course Added Successfully!');</script>");
            }
            else
            {
                Response.Write("<script>alert('Please Upload File!');</script>");
            }
        }
    }
}