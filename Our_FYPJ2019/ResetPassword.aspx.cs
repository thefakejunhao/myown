using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            //make a new byte array
            byte[] salt;

            //generate salt
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //hash and salt using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(tb_password.Text, salt, 10000);

            //place string in byte array
            byte[] hash = pbkdf2.GetBytes(20);

            //make new byte array to store hashed password + salt
            //36 --> 16(salt) + 20(hash)
            byte[] hashbytes = new byte[36];
            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);

            //convert byte array to string
            string savedPasswordHash = Convert.ToBase64String(hashbytes);

            string email = Request.QueryString["email"];
            string queryStr = "UPDATE Users SET " +
                       " password = @password " +
                       " WHERE email= @email";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@password", savedPasswordHash);
            cmd.Parameters.AddWithValue("@email", email);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert ('Your password has been successfully updated'); location.href='Login.aspx';</script>");
        }
    }
}