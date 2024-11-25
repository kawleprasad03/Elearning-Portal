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
    public partial class EditSubCourse : System.Web.UI.Page
    {
        SqlConnection conn;
        byte[] imagedata = null;
        string maincourse = null;
        string oldsubcourse = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                string subCourseId = Request.QueryString["id"];

                string query = $"select * from subCourses where id = '{subCourseId}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    maincourse = reader["mainCourseName"].ToString();
                    Session["MainCourse"] = maincourse;
                    TextBox1.Text = reader["subCourseName"].ToString();
                    Session["OldSbuCourse"] = reader["subCourseName"].ToString();
                    TextBox2.Text = reader["price"].ToString();
                    imagedata = (byte[])reader["image"];
                    Session["imagedata"] = imagedata;

                }
            }
            else
            {
                maincourse = Session["MainCourse"].ToString();
                imagedata = Session["imagedata"] as byte[];
                oldsubcourse = Session["OldSbuCourse"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string subCourseId = Request.QueryString["id"];
            string usubcourse = TextBox1.Text;
            string uprice = TextBox2.Text;
            if (FileUpload1.HasFile)
            {
                imagedata = FileUpload1.FileBytes;
            }
            string query = "exec updatesubcourse @usubcoursename,@uprice,@uimagedate,@id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@usubcoursename", usubcourse);
            cmd.Parameters.AddWithValue("@uprice", uprice);
            cmd.Parameters.AddWithValue("@uimagedate", imagedata);
            cmd.Parameters.AddWithValue("@id", subCourseId);
            cmd.ExecuteNonQuery();

            SqlCommand cmd3 = new SqlCommand($"exec updatesubcourseinvideo '{oldsubcourse}','{usubcourse}'", conn);
            cmd3.ExecuteNonQuery();

            SqlCommand cmd1 = new SqlCommand($"select sum(price) as TotalPrice from subCourses where mainCourseName = '{maincourse}'", conn);
            SqlDataReader reader = cmd1.ExecuteReader();
            int totalamount = 0;
            if (reader.Read())
            {
                totalamount = int.Parse(reader["TotalPrice"].ToString());
            }

            string query1 = $"exec updatecourseamount {totalamount},'{maincourse}'";
            SqlCommand cmd2 = new SqlCommand(query1, conn);
            cmd2.ExecuteNonQuery();

            Response.Write("<script>alert('Data Updated Successfully!');window.location.href='CourseEditOrDelete.aspx'</script>");

        }
    }
}