using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace ElearningPortal
{
    public partial class WatchCourse : System.Web.UI.Page
    {
        //SqlConnection con;

        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["dbcon"].ConnectionString;
        //    con = new SqlConnection(cs);
        //    con.Open();
        //    if (!IsPostBack)
        //    {
        //        BindVideos();
        //    }
        //}

        //private void BindVideos()
        //{
        //    string CourseName = "Java Full Course";
        //    string query = $"SELECT subCourseName, image, Video FROM subCourses WHERE CourseName ='{CourseName}'";
        //    SqlCommand command = new SqlCommand(query, con);
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    DataTable dataTable = new DataTable();
        //    adapter.Fill(dataTable);

        //    gridPlaylists.DataSource = dataTable;
        //    gridPlaylists.DataBind();
        //}

        //protected void gridPlaylists_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    Session["Subcourse"] = (e.CommandArgument).ToString();
        //    if (e.CommandName == "Play")
        //    {
        //        string subCourseName = /*"Introduction Of Java";//*/(e.CommandArgument).ToString();
        //        string query = $"SELECT Video FROM subCourses WHERE subCourseName ='{subCourseName}'";
        //        SqlCommand command = new SqlCommand(query, con);
        //        string ytVideoId = command.ExecuteScalar()?.ToString();

        //        if (!string.IsNullOrEmpty(ytVideoId))
        //        {
        //            string iframeUrl = $"https://www.youtube.com/embed/{ytVideoId}";
        //            string iframeHtml = $"<iframe width='980' height='350' src='{iframeUrl}' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";
        //            ltrYouTubePlayer.Text = iframeHtml;
        //            ScriptManager.RegisterStartupScript(this, GetType(), "showPlayer", "playVideoAndHideMCQ();", true); // Call the JS function to hide MCQ;
        //        }

        //    }

        //}
        ////bind mcq

        //private void BindMCQ()
        //{
        //    string courseName = "Java Full Course";
        //    string subCourseName = Session["Subcourse"]?.ToString() ?? "Introduction to Java";
        //    string query = $"SELECT question, options, answer FROM mcq WHERE mainCourseName ='{courseName}' AND subCourseName ='{subCourseName}'";

        //    SqlCommand cmd = new SqlCommand(query, con);
        //    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //    DataTable dataTable = new DataTable();
        //    adapter.Fill(dataTable);

        //    rptQuestions.DataSource = dataTable;
        //    rptQuestions.DataBind();
        //}
        //protected void rptQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        DataRowView dataRow = (DataRowView)e.Item.DataItem;
        //        string options = dataRow["options"].ToString();
        //        RadioButtonList rblOptions = (RadioButtonList)e.Item.FindControl("rblOptions");

        //        foreach (string option in options.Split(','))
        //        {
        //            rblOptions.Items.Add(new ListItem(option));
        //        }
        //    }
        //}
        //protected void btnMCQTab_Click(object sender, EventArgs e)
        //{
        //    BindMCQ(); // Load MCQs when the MCQ tab is clicked
        //    ScriptManager.RegisterStartupScript(this, GetType(), "keepMCQTabOpen", "showContent('MCQ');", true); // Show MCQ content
        //}


        //protected void btnCheckAnswer_Click(object sender, EventArgs e)
        //{
        //    Button btnCheckAnswer = (Button)sender;
        //    RepeaterItem item = (RepeaterItem)btnCheckAnswer.NamingContainer;
        //    RadioButtonList rblOptions = (RadioButtonList)item.FindControl("rblOptions");
        //    Label lblAnswer = (Label)item.FindControl("lblAnswer");

        //    // Get correct answer from CommandArgument
        //    string correctAnswer = btnCheckAnswer.CommandArgument;
        //    string selectedAnswer = rblOptions.SelectedItem?.Text;

        //    // Ensure to show the MCQ content
        //    lblAnswer.Text = selectedAnswer == correctAnswer ? "Correct!" : "Incorrect, try again.";
        //    lblAnswer.Visible = true;

        //}

        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindTopics();
            }
        }

        private void BindTopics()
        {
            // Fetch topic data from uploadVideo table
            string query = "SELECT topicName, topicUrl FROM uploadVideo WHERE mainCourseName = @mainCourseName AND subCourseName = @subCourseName";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@mainCourseName", Session["courseName"].ToString());
            cmd.Parameters.AddWithValue("@subCourseName", Session["subCourseName"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridTopics.DataSource = dt;
            gridTopics.DataBind();
        }

        protected void gridTopics_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PlayTopic")
            {
                string topicUrl = e.CommandArgument.ToString();
                ltrYouTubePlayer.Text = $"<iframe width='100%' height='350' src='https://www.youtube.com/embed/{topicUrl}?rel=0' frameborder='0' allowfullscreen></iframe>";
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            // Redirect to MCQ page
            Response.Redirect("MCQ.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Redirect to Assignment page
            Response.Redirect("Assignment.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            // Redirect to Review page
            Response.Redirect("Review.aspx");
        }

        //protected void btnMCQTab_Click(object sender, EventArgs e)
        //{
        //    Session["ActiveTab"] = "MCQ";
        //    // Fetch MCQ data from mcq table based on subCourseName
        //    string query = "SELECT question, options, answer FROM mcq WHERE mainCourseName = @mainCourseName AND subCourseName = @subCourseName";
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@mainCourseName", Session["courseName"].ToString());
        //    cmd.Parameters.AddWithValue("@subCourseName", Session["subCourseName"].ToString());
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    rptQuestions.DataSource = dt;
        //    rptQuestions.DataBind();
        //}

        //protected void rptQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        var options = ((DataRowView)e.Item.DataItem)["options"].ToString().Split(';');
        //        RadioButtonList rblOptions = (RadioButtonList)e.Item.FindControl("rblOptions");
        //        foreach (var option in options)
        //        {
        //            rblOptions.Items.Add(new ListItem(option));
        //        }
        //    }
        //}

        //protected void btnCheckAnswer_Click(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    RepeaterItem item = (RepeaterItem)btn.NamingContainer;
        //    string correctAnswer = btn.CommandArgument;
        //    RadioButtonList rblOptions = (RadioButtonList)item.FindControl("rblOptions");
        //    Label lblAnswer = (Label)item.FindControl("lblAnswer");

        //    lblAnswer.Visible = true;
        //    lblAnswer.Text = rblOptions.SelectedValue == correctAnswer ? "Correct!" : "Incorrect";
        //}

        //protected void btnAssignmentTab_Click(object sender, EventArgs e)
        //{
        //    Session["ActiveTab"] = "Assignment";
        //    showAssignment();
        //}


        //protected void showAssignment()
        //{
        //    // Fetch assignment data for the subCourseName
        //    string query = "SELECT assignmentfile FROM assignment WHERE mainCourseName = @mainCourseName AND subCourseName = @subCourseName";
        //    SqlCommand cmd = new SqlCommand(query, conn);
        //    cmd.Parameters.AddWithValue("@mainCourseName", Session["courseName"].ToString());
        //    cmd.Parameters.AddWithValue("@subCourseName", Session["subCourseName"].ToString());
        //    byte[] fileBytes = (byte[])cmd.ExecuteScalar();

        //    if (fileBytes != null)
        //    {
        //        string base64String = Convert.ToBase64String(fileBytes, 0, fileBytes.Length);
        //        ltrAssignment.Text = $"<a href='data:application/octet-stream;base64,{base64String}' download='Assignment.pdf'>Download Assignment</a>";
        //    }
        //}

    }
}