using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class CourseEditOrUpdate : System.Web.UI.Page
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

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            string maincoursename = DropDownList1.SelectedValue;
            string query = $"exec fetchsubcourse '{maincoursename}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSubCourse")
            {
                int subCourseId = Convert.ToInt32(e.CommandArgument);

                Response.Redirect($"EditSubCourse.aspx?id={subCourseId}");
            }
            else if (e.CommandName == "DeleteSubCourse")
            {
                int subCourseId = Convert.ToInt32(e.CommandArgument);

                DeleteSubCourse(subCourseId);

                ShowData();
            }
        }

        
        private void DeleteSubCourse(int subCourseId)
        {
            SqlCommand cmd3 = new SqlCommand($"select subCourseName from subCourses where id = @subCourseId", conn);
            cmd3.Parameters.AddWithValue("@subCourseId", subCourseId);
            SqlDataReader rd = cmd3.ExecuteReader();
            string dsubcourse = null;
            if (rd.Read())
            {
                 dsubcourse=rd["subCourseName"].ToString();
            }
            SqlCommand cmd4 = new SqlCommand("exec deletesubcuploadvideo @subcourse", conn);
            cmd4.Parameters.AddWithValue("@subcourse", dsubcourse);
            cmd4.ExecuteNonQuery();


            string maincoursename = DropDownList1.SelectedValue;
            string query = "exec deletesubcourse @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", subCourseId);
            cmd.ExecuteNonQuery();





            SqlCommand cmd1 = new SqlCommand($"select sum(price) as TotalPrice from subCourses where mainCourseName = '{maincoursename}'", conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            int totalamount = 0;
            if (reader.Read())
            {
                totalamount = Convert.ToInt32(reader["TotalPrice"] == DBNull.Value ? 0 : reader["TotalPrice"]);
            }

            string query1 = $"exec updatecourseamount {totalamount},'{maincoursename}'";
            SqlCommand cmd2 = new SqlCommand(query1, conn);
            cmd2.ExecuteNonQuery();
        }
    }
}