using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class Register : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;
        static string activationcode;

        protected void Page_Load(object sender, EventArgs e)
        {
            btn_buyer.CssClass = "afterclick";

            BuyerPanel.Visible = true;

            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string pwd = tb_bpassword.Text;
            tb_bpassword.Attributes.Add("value", pwd);

            string cpwd = tb_bcpassword.Text;
            tb_bcpassword.Attributes.Add("value", cpwd);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "Business")
            {
                BusinessPanel.Visible = true;
            }
            else
            {
                BusinessPanel.Visible = false;
            }
        }

        //Seller registration
        protected void btn_next2_Click(object sender, EventArgs e)
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

            //validation for existing username and email
            Label1.Visible = false;
            Label2.Visible = false;

            string queryStr = "SELECT * FROM Users";
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];

            //check existing email
            if (tb_email.Text == ds.Tables[0].Rows[0]["email"].ToString())
            {
                Label2.Visible = true;
            }
            //check existing username
            else if (tb_username.Text == ds.Tables[0].Rows[0]["username"].ToString())
            {
                Label1.Visible = true;
            }

            //connect to database
            else
            {
                int result = 0;
                string email = tb_email.Text;
                string username = tb_username.Text;
                string password = tb_password.Text;
                string cpassword = tb_cpassword.Text;
                string mobileno = tb_mobileno.Text;

                //Generate random activation code between 1001 and 9999
                Random random = new Random();
                activationcode = random.Next(1001, 9999).ToString();

                string queryStr2 = "INSERT into Users(email, username, password, mobileNo, status, activationCode, roles)" +
                                "values(@email, @username, @password, @mobileNo, @status, @activationCode, @roles)";
                SqlConnection conn2 = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr2, conn2);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", savedPasswordHash);
                cmd.Parameters.AddWithValue("@mobileNo", mobileno);
                cmd.Parameters.AddWithValue("@status", "Unverified");
                cmd.Parameters.AddWithValue("@activationCode", activationcode);
                cmd.Parameters.AddWithValue("@roles", "Seller");

                conn2.Open();
                try
                {
                    result = +cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        sendSMS();
                        SMSVerificationPanel.Visible = true;
                        lbl_mobileNo.Text = tb_mobileno.Text;

                        string queryStr3 = "INSERT into Points(username)" +
                                           "values(@username)";
                        SqlConnection conn3 = new SqlConnection(_connStr);
                        SqlCommand cmd3 = new SqlCommand(queryStr3, conn3);
                        cmd3.Parameters.AddWithValue("@username", username);
                        conn3.Open();
                        cmd3.ExecuteNonQuery();
                        conn3.Close();
                    }
                }

                finally
                {
                    conn2.Close();
                    SellerPanel.Visible = false;
                    BuyerPanel.Visible = false;
                    RegisterAsPanel.Visible = false;
                }
            }
        }


        //buyer registration
        protected void btn_next3_Click(object sender, EventArgs e)
        {
            //make a new byte array
            byte[] salt;

            //generate salt
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //hash and salt using PBKDF2
            var pbkdf2 = new Rfc2898DeriveBytes(tb_bpassword.Text, salt, 10000);

            //place string in byte array
            byte[] hash = pbkdf2.GetBytes(20);

            //make new byte array to store hashed password + salt
            //36 --> 16(salt) + 20(hash)
            byte[] hashbytes = new byte[36];
            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);

            //convert byte array to string
            string savedPasswordHash = Convert.ToBase64String(hashbytes);

            //validation
            Label4.Visible = false;
            Label5.Visible = false;

            string queryStr = "SELECT * FROM Users";
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(queryStr, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            DataTable dt = ds.Tables[0];

            //check existing email
            if (tb_bemail.Text == ds.Tables[0].Rows[0]["email"].ToString())
            {
                Label4.Visible = true;
            }
            //check existing username
            else if (tb_busername.Text == ds.Tables[0].Rows[0]["username"].ToString())
            {
                Label5.Visible = true;
            }

            else
            {
                Random random = new Random();
                activationcode = random.Next(1001, 9999).ToString();

                string bemail = tb_bemail.Text;
                string busername = tb_busername.Text;
                string bpassword = tb_bpassword.Text;
                string bmobileNo = tb_bmobileNo.Text;
                string businessName = tb_businessName.Text;

                string queryStr2 = "INSERT into Users(email, username, password, mobileNo, status, activationCode, roles, businessName, purpose)" +
                                "values(@email, @username, @password, @mobileNo, @status, @activationCode, @roles, @businessName, @purpose)";
                SqlConnection conn2 = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr2, conn2);
                cmd.Parameters.AddWithValue("@email", bemail);
                cmd.Parameters.AddWithValue("@username", busername);
                cmd.Parameters.AddWithValue("@password", savedPasswordHash);
                cmd.Parameters.AddWithValue("@mobileNo", bmobileNo);
                cmd.Parameters.AddWithValue("@status", "Unverified");
                cmd.Parameters.AddWithValue("@activationCode", activationcode);
                cmd.Parameters.AddWithValue("@roles", "Buyer");
                cmd.Parameters.AddWithValue("@businessName", businessName);
                cmd.Parameters.AddWithValue("@purpose", RadioButtonList1.SelectedValue);

                conn2.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    if (RadioButtonList2.SelectedValue == "SMS")
                    {
                        sendSMS();
                        SMSVerificationPanel.Visible = true;
                        lbl_mobileNo.Text = tb_bmobileNo.Text;
                    }
                    else
                    {
                        sendEmail();
                        EmailVerificationPanel.Visible = true;
                        lbl_Email.Text = tb_bemail.Text;
                    }
                }
                finally
                {
                    SellerPanel.Visible = false;
                    BuyerPanel.Visible = false;
                    RegisterAsPanel.Visible = false;
                    conn2.Close();
                }
            }
        }

        private void sendSMS()
        {
            try
            {
                string number = "65" + tb_mobileno.Text;
                string bnumber = "65" + tb_bmobileNo.Text;

                string msg = "Your OTP number is " + activationcode + ".";

                String message = HttpUtility.UrlEncode(msg);
                using (var wb = new WebClient())
                {
                    byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                //{"apikey" , "dJd3j06P+qA-Id07zk4r3JPqUWCsE0oK0mZuiCGG4O"},//home
                //{"apikey" , "dJd3j06P+qA-ZW9yImn6LRiW9GekqBzJWzE5fH6fau"}, //school
               {"apikey" , "	vDdmpgnhK/s-ueqJOPtPZzqtID4axzU9Mon84E9VRk"},

                {"numbers" , number},
                {"numbers" , bnumber},
                {"message" , message},
                {"sender" , "FYPJ"}
                });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                    Session["SMS"] = activationcode;
                }
            }
            catch (WebException wex)
            {
                Response.Write("SOMETHING WENT WRONG! Status: " + wex.Status + "Message: " + wex.Message + "");
            }
        }

        private void sendEmail()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Dear " + tb_busername.Text + ",");
                sb.Append("<br/><br/>");
                sb.Append("Thank you for registering at xxx. Your account is created and must be activatied before you can use it.");
                sb.Append("<br/><br/>");
                sb.Append("Your activation code is:");
                sb.Append("<h2>" + " " + activationcode + "</h2>");
                sb.Append("<br/><br/><br/>");
                sb.Append("Thanks & Regards<br/>");

                MailMessage msg = new MailMessage("gwwc99@gmail.com", tb_bemail.Text.Trim(), "Activation Code", sb.ToString());
                SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("gwwc99@gmail.com", "s9927302z");
                smtp.EnableSsl = true;

                msg.IsBodyHtml = true;
                smtp.Send(msg);
                Session["email"] = activationcode;
            }
            catch (Exception ex)
            {

            }
        }

        //Email verification
        protected void btn_verify_Click(object sender, EventArgs e)
        {
            if (tb_code.Text == Session["email"].ToString())
            {
                EmailVerificationPanel.Visible = false;
                string queryStr = "UPDATE Users SET " +
                                  " status =  @status " +
                                  " WHERE activationCode='" + Session["email"] + "'";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@status", "Verified");
                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Your account have been activated. Login now!'); location.href='Login.aspx';</script>");
            }
            else
            {
                BuyerPanel.Visible = false;
                SellerPanel.Visible = false;
                RegisterAsPanel.Visible = false;
                Label7.Visible = true;
            }
        }

        //SMS verification
        protected void btn_verify2_Click(object sender, EventArgs e)
        {
            if (tb_code2.Text == Session["SMS"].ToString())
            {
                SMSVerificationPanel.Visible = false;
                string queryStr = "UPDATE Users SET " +
                                  " status =  @status " +
                                  " WHERE activationCode='" + Session["SMS"] + "'";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@status", "Verified");
                conn.Open();
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Your account have been activated. Login now!'); location.href='Login.aspx';</script>");
            }
            else
            {
                BuyerPanel.Visible = false;
                SellerPanel.Visible = false;
                RegisterAsPanel.Visible = false;
                Label8.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            sendEmail();
        }

        protected void linkbtn_sms_Click(object sender, EventArgs e)
        {
            sendSMS();
        }

        protected void btn_buyer_Click(object sender, EventArgs e)
        {
            BuyerPanel.Visible = true;
            SellerPanel.Visible = false;

            btn_buyer.CssClass = "afterclick";
            btn_seller.CssClass = "button";
        }

        protected void btn_seller_Click(object sender, EventArgs e)
        {
            SellerPanel.Visible = true;
            BuyerPanel.Visible = false;

            btn_seller.CssClass = "afterclick";
            btn_buyer.CssClass = "button";
        }
    }
}