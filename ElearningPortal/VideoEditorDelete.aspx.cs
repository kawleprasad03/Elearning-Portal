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
    public partial class VideoEditorDelete : System.Web.UI.Page
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
            string selectedcourse = DropDownList1.SelectedValue;
            string query = $"exec fetchsubcourse '{selectedcourse}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DropDownList2.DataSource = reader;
            DropDownList2.DataTextField = "subCourseName";
            DropDownList2.DataValueField = "subCourseName";
            DropDownList2.DataBind();

            DropDownList2.Items.Insert(0, new ListItem("Select Option", "Selected Option"));
            DropDownList2.Items[0].Selected = true;
            DropDownList2.Items[0].Attributes.Add("disabled", "true");

            
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGridView();
        }

        private void BindGridView()
        {
            string subcourse = DropDownList2.SelectedValue;
            string query = $"select * from uploadVideo where subCourseName='{subcourse}'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            GridView1.DataSource = reader;
            GridView1.DataBind();
        }


        protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"EditVideo.aspx?id={id}");
            }
            else if (e.CommandName == "DeleteVideo")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                deletevideo(id);
                BindGridView();
            }
        }
        private void deletevideo(int id)
        {
            string query = $"exec deletevideo @id";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            BindGridView();
        }

    }
}