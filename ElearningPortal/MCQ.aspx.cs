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
    public partial class MCQ : System.Web.UI.Page
    {

        private SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadQuestions();
            }
        }

       
        private void LoadQuestions()
        {
            string mainCourse = Session["courseName"].ToString();
            string subCourse = Session["subCourseName"].ToString();

            List<Question> questions = GetQuestions(mainCourse, subCourse);
            rptQuestions.DataSource = questions;
            rptQuestions.DataBind();
        }

       
        private List<Question> GetQuestions(string mainCourse, string subCourse)
        {
            List<Question> questions = new List<Question>();

      
            string query = "SELECT id, question, options, answer FROM mcq WHERE mainCourseName = @mainCourse AND subCourseName = @subCourse";

            SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@mainCourse", mainCourse);
                    cmd.Parameters.AddWithValue("@subCourse", subCourse);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        questions.Add(new Question
                        {
                            Id = reader.GetInt32(0),
                            QuestionText = reader.GetString(1),
                            Options = reader.GetString(2),
                            Answer = reader.GetString(3)
                        });
                    }
                
            

            return questions;
        }

      
        protected void rptQuestions_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Question question = (Question)e.Item.DataItem;
                RadioButtonList rblOptions = (RadioButtonList)e.Item.FindControl("rblOptions");
                string[] options = question.Options.Split(',');

                rblOptions.DataSource = options;
                rblOptions.DataBind();
            }
        }

      
        protected void btnCheckAnswer_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int questionId = Convert.ToInt32(btn.CommandArgument);

            RepeaterItem item = btn.NamingContainer as RepeaterItem;
            RadioButtonList rblOptions = (RadioButtonList)item.FindControl("rblOptions");
            Label lblAnswer = (Label)item.FindControl("lblAnswer");

            if (rblOptions.SelectedItem == null)
            {
                lblAnswer.Text = "Please select an answer.";
                lblAnswer.ForeColor = System.Drawing.Color.Orange;
                lblAnswer.Visible = true;
                return;
            }

            string selectedAnswer = rblOptions.SelectedValue;

           
            string correctAnswer = GetCorrectAnswer(questionId);
            if (correctAnswer != null)
            {
                if (selectedAnswer == correctAnswer)
                {
                    lblAnswer.Text = "Correct!";
                    lblAnswer.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblAnswer.Text = $"Incorrect! The correct answer is {correctAnswer}.";
                    lblAnswer.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblAnswer.Text = "Error: Question not found.";
                lblAnswer.ForeColor = System.Drawing.Color.Red;
            }

            lblAnswer.Visible = true;
        }

       
        private string GetCorrectAnswer(int questionId)
        {
            string correctAnswer = null;
       
              
                string query = "SELECT answer FROM mcq WHERE id = @id";

            SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@id", questionId);
                    correctAnswer = (string)cmd.ExecuteScalar();
                
            

            return correctAnswer;
        }
        
    }
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string Options { get; set; } // Comma-separated options
        public string Answer { get; set; }
    }
}