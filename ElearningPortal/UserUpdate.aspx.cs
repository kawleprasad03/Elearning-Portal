using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class UserUpdate : System.Web.UI.Page
    {
        SqlConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (!IsPostBack)
            {
                BindUserProfiles();
            }
        }

       
        private void BindUserProfiles()
        {
            string email = Session["email"].ToString();
            SqlCommand cmd = new SqlCommand($"SELECT id, username, email, password, urole, profilePhoto FROM users WHERE email != '{email}'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            EditUserDataList.DataSource = reader;
            EditUserDataList.DataBind();
            
        }

        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string id = ((System.Web.UI.WebControls.Button)sender).CommandArgument;

            
            foreach (DataListItem item in EditUserDataList.Items)
            {
                if (((Button)item.FindControl("btnSave")).CommandArgument == id)
                {
                    string name = ((TextBox)item.FindControl("txtName")).Text;


                    FileUpload fileUpload = (FileUpload)item.FindControl("fileUpload");
                    byte[] profilePhoto = null;

                    if (fileUpload.HasFile)
                    {
                        using (BinaryReader br = new BinaryReader(fileUpload.PostedFile.InputStream))
                        {
                            profilePhoto = br.ReadBytes((int)fileUpload.PostedFile.InputStream.Length);
                        }
                    }

                  
                    UpdateUser(id, name, profilePhoto);
                    BindUserProfiles();  
                    break;
                }
            }
        }

       
        private void UpdateUser(string id, string name, byte[] profilePhoto)
        {

            SqlCommand cmd = new SqlCommand("UPDATE users SET username=@name,  profilePhoto=@ProfilePhoto WHERE id=@Id", conn);

            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@name", name);


            if (profilePhoto != null)
            {
                cmd.Parameters.AddWithValue("@ProfilePhoto", profilePhoto);
                
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand($"select profilePhoto from users where id = '{id}'", conn);
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    profilePhoto = (byte[])reader["profilePhoto"];
                }
                cmd.Parameters.AddWithValue("@ProfilePhoto", profilePhoto);
            }

            cmd.ExecuteNonQuery();
            Response.Write("<script>alert('Data Updated Successfully!')</Script>");
        }
    }
}