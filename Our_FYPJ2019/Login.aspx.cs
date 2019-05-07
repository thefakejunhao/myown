using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class Login1 : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text;
            string password = tb_password.Text;

            string queryStr = "SELECT * FROM Users WHERE username =@username and Status =@Status AND banStatus = 'no'";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@Status", "Verified");
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);

            //if there is 1 element, check for password matching
            if (dt.Rows.Count == 1)
            {
                //get the saved string
                string savedPasswordHash = dt.Rows[0][2].ToString();

                //convert to bytes
                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

                //take the salt out of the string
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);

                //hash the user input password with salt
                var pbkdf2 = new Rfc2898DeriveBytes(tb_password.Text, salt, 10000);

                //put the hased input in a byte array to compare byte by byte
                byte[] hash = pbkdf2.GetBytes(20);

                //compare results byte by byte
                //starting from 16 in the stored array as 0-15 are the salt there
                int ok = 1;
                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] != hash[i])
                        ok = 0;

                //if there are no differences between the strings grant access
                if (ok == 1)
                {
                    if ((string)dt.Rows[0]["roles"] == "Seller")
                    {
                        Session["Login"] = username;
                        Response.Redirect("Profile.aspx");
                    }
                    else
                    {
                        Session["Login"] = username;
                        Response.Redirect("Profile.aspx");
                    }

                }

                //if password is wrong, deny access
                else
                {
                    Label1.Visible = true;
                }
            }
            else
            {
                Label1.Visible = true;
            }
        }

        //forget password
        protected void btn_Send_Click(object sender, EventArgs e)
        {
            Session["email"] = tb_femail.Text;
            string queryStr = "SELECT * FROM Users WHERE email= @email and status= @status";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlDataAdapter sda = new SqlDataAdapter(queryStr, conn);
            conn.Open();
            sda.SelectCommand.Parameters.AddWithValue("@email", tb_femail.Text);
            sda.SelectCommand.Parameters.AddWithValue("@status", "Verified");
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                SendEmail();

                Response.Write("<script>alert('Successfully sent reset link to your mail, kindly check your mail inbox.'); location.href = 'Login.aspx'</script>");
                conn.Close();
            }
            else
            {
                Response.Write("<script>alert('User does not exist!'); location.href= 'Login.aspx';</script>");
            }
        }

        private void SendEmail()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<b>Hello!</b>");
                sb.Append("<br/><br>");
                sb.Append("You are receiving this email because we received a password reset request for your account.");
                sb.Append("<br/><br>");
                sb.Append("To reset your password click the link below:<br/>");
                sb.Append("<a href=http://localhost:28066/ResetPassword.aspx");
                sb.Append("?email=" + Session["email"] + ">Reset Password</a>");
                sb.Append("<br/><br/>");
                sb.Append("If you did not request a password reset, no further action is required.");
                sb.Append("<br/><br/>");
                sb.Append("Thanks & Regards<br/> ");

                MailMessage msg = new MailMessage("gwwc99@gmail.com", tb_femail.Text.Trim(), " Reset Password", sb.ToString());
                SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("gwwc99@gmail.com", "s9927302z");
                smtp.EnableSsl = true;

                msg.IsBodyHtml = true;
                smtp.Send(msg);
            }
            catch (Exception ex)
            {

            }
        }
    }
}