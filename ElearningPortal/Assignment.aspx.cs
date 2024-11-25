using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class Assignment : System.Web.UI.Page
    {
        private SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                LoadAssignments();
            }
        }

       
        private void LoadAssignments()
        {
            string mainCourse = Session["courseName"].ToString();
            string subCourse = Session["subCourseName"].ToString();

            List<AssignmentFile> assignments = GetAssignments(mainCourse, subCourse);
            gvAssignments.DataSource = assignments;
            gvAssignments.DataBind();
        }

       
        private List<AssignmentFile> GetAssignments(string mainCourse, string subCourse)
        {
            List<AssignmentFile> assignments = new List<AssignmentFile>();

    
                string query = "SELECT id, mainCourseName, subCourseName FROM assignment WHERE mainCourseName = @mainCourse AND subCourseName = @subCourse";

            SqlCommand cmd = new SqlCommand(query, conn);
                
                    cmd.Parameters.AddWithValue("@mainCourse", mainCourse);
                    cmd.Parameters.AddWithValue("@subCourse", subCourse);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        assignments.Add(new AssignmentFile
                        {
                            Id = reader.GetInt32(0),
                            MainCourseName = reader.GetString(1),
                            SubCourseName = reader.GetString(2)
                        });
                    }
                
            

            return assignments;
        }

       
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int assignmentId = Convert.ToInt32(btn.CommandArgument);

            byte[] fileData = null;


            string query = "SELECT assignmentfile FROM assignment WHERE id = @id";

            SqlCommand cmd = new SqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@id", assignmentId);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                fileData = (byte[])reader["assignmentfile"];
            }

            if (fileData != null)
            {
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", $"attachment; filename=Assignment.pdf"); 
                Response.BinaryWrite(fileData);
                Response.Flush();
                Response.End();

            }
        }

        protected void btnUploadSolution_Click(object sender, EventArgs e)
        {
           
            GridViewRow row = (sender as Button).NamingContainer as GridViewRow;
            if (row != null)
            {
                
                FileUpload fuSolution = row.FindControl("fuSolution") as FileUpload;
                if (fuSolution != null && fuSolution.HasFile)
                {


                    string mainCourse = Session["courseName"].ToString();
                    string subCourse = Session["subCourseName"].ToString();
                    string email = Session["email"].ToString();

                    byte[] fileBytes;
                    using (BinaryReader reader = new BinaryReader(fuSolution.PostedFile.InputStream))
                    {
                        fileBytes = reader.ReadBytes((int)fuSolution.PostedFile.InputStream.Length);
                    }

                    SaveSolution(email, mainCourse, subCourse, fileBytes);
                }
                else
                {
                   
                    Response.Write("<script>alert('Please select a file to upload.');</script>");
                }
            }
        }

        private void SaveSolution(string email, string mainCourseName, string subCourseName, byte[] solution)
        {

                string query = @"
                INSERT INTO submitAssignment (email, mainCourseName, subCourseName, solution) 
                VALUES (@Email, @MainCourseName, @SubCourseName, @Solution)";

            SqlCommand cmd = new SqlCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@MainCourseName", mainCourseName);
                cmd.Parameters.AddWithValue("@SubCourseName", subCourseName);
                cmd.Parameters.Add("@Solution", SqlDbType.VarBinary).Value = solution;

               
                cmd.ExecuteNonQuery();
               
                
            

           
            Response.Write("<script>alert('Solution uploaded successfully.');</script>");
        }
    }

   
    public class AssignmentFile
    {
        public int Id { get; set; }
        public string MainCourseName { get; set; }
        public string SubCourseName { get; set; }
    }

}