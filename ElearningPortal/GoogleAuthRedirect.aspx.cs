using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElearningPortal
{
    public partial class GoogleAuthRedirect : System.Web.UI.Page
    {
        SqlConnection conn;
        protected async void Page_Load(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
            conn = new SqlConnection(cs);
            conn.Open();
            if (Request.QueryString["code"] != null)
            {
                string code = Request.QueryString["code"];
                await ExchangeCodeForTokens(code);  // Handle OAuth code
            }
        }

        // Step 1: Exchange the authorization code for access tokens
        private async Task ExchangeCodeForTokens(string code)
        {
            string clientId = "1091820565810-901ek849lhu65jqkg06oi0vv05s05fav.apps.googleusercontent.com";
            string clientSecret = "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";
            string redirectUri = "https://localhost:44398/GoogleAuthRedirect";  // Your registered redirect URI

            using (var client = new HttpClient())
            {
                var tokenRequest = new HttpRequestMessage(HttpMethod.Post, "https://oauth2.googleapis.com/token");
                tokenRequest.Content = new FormUrlEncodedContent(new[]
                {
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("client_id", clientId),
                new KeyValuePair<string, string>("client_secret", clientSecret),
                new KeyValuePair<string, string>("redirect_uri", redirectUri),
                new KeyValuePair<string, string>("grant_type", "authorization_code")
            });

                var tokenResponse = await client.SendAsync(tokenRequest);
                var tokenResponseString = await tokenResponse.Content.ReadAsStringAsync();
                var tokenData = JsonConvert.DeserializeObject<TokenResponse>(tokenResponseString);

                // Step 2: Fetch Google user info using the access token
                var userInfoResponse = await client.GetAsync($"https://www.googleapis.com/oauth2/v2/userinfo?access_token={tokenData.AccessToken}");
                var userInfoResponseString = await userInfoResponse.Content.ReadAsStringAsync();
                var userInfo = JsonConvert.DeserializeObject<GoogleUserInfo>(userInfoResponseString);

                // Step 3: Store Google user info in the database
                StoreGoogleUserInDatabase(userInfo);

                // Redirect to home page or dashboard after successful login
                Response.Redirect("login.aspx");
            }
        }

        // Step 3: Store Google user data in the database
        private void StoreGoogleUserInDatabase(GoogleUserInfo userInfo)
        {
            

                // Check if the user already exists based on Email or Google ID
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, conn);
                checkUserCmd.Parameters.AddWithValue("@Email", userInfo.Email);
                int userExists = (int)checkUserCmd.ExecuteScalar();

                if (userExists == 0)
                {
                    // Insert new user if they don't exist
                    string insertQuery = "INSERT INTO Users (GoogleId, FullName, Email, ProfilePicture, AuthProvider) " +
                                         "VALUES (@GoogleId, @FullName, @Email, @ProfilePicture, 'google')";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@GoogleId", userInfo.Id);
                    insertCmd.Parameters.AddWithValue("@FullName", userInfo.Name);
                    insertCmd.Parameters.AddWithValue("@Email", userInfo.Email);
                    insertCmd.Parameters.AddWithValue("@ProfilePicture", userInfo.Picture);

                    insertCmd.ExecuteNonQuery();
                }
                else
                {
                    // Optionally update existing user info
                    string updateQuery = "UPDATE Users SET FullName = @FullName, ProfilePicture = @ProfilePicture, AuthProvider = 'google' WHERE Email = @Email";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@FullName", userInfo.Name);
                    updateCmd.Parameters.AddWithValue("@ProfilePicture", userInfo.Picture);
                    updateCmd.Parameters.AddWithValue("@Email", userInfo.Email);

                    updateCmd.ExecuteNonQuery();
                }
            
        }

        // Google OAuth Token Response Model
        public class TokenResponse
        {
            [JsonProperty("access_token")]
            public string AccessToken { get; set; }

            [JsonProperty("expires_in")]
            public int ExpiresIn { get; set; }

            [JsonProperty("refresh_token")]
            public string RefreshToken { get; set; }

            [JsonProperty("token_type")]
            public string TokenType { get; set; }

            [JsonProperty("id_token")]
            public string IdToken { get; set; }
        }

        // Google User Info Model
        public class GoogleUserInfo
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("picture")]
            public string Picture { get; set; }
        }
    }
}