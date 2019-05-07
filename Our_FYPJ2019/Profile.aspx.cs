using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class BuyerProfile : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;
        static string activationcode;

        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            //lbl_username.Text = "<h1>" + "123" + "</h1>";
            //lbl_buyer.Text = "Business";
            //lbl_username2.Text = "123";
            //tb_mobileNo.Text = "123";
            //tb_Email.Text = "123";
            //tb_Address.Text = "123";
            //tb_postalCode.Text = "123";
            //Image1.ImageUrl = "~\\Images\\" + "default.jpg";
            //tb_DOB.Text = "123";
            //RadioButtonList1.Text = "Female";

            if (!IsPostBack)
            {
                SqlConnection conn = new SqlConnection(_connStr);
                conn.Open();
                string queryStr = "SELECT * FROM Users WHERE username='" + Session["Login"] + "'";
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lbl_username.Text = "<h2>" + dr["username"].ToString() + "</h2>";
                    lbl_buyer.Text = dr["purpose"].ToString();
                    lbl_username2.Text = dr["username"].ToString();
                    tb_mobileNo.Text = dr["mobileNo"].ToString();
                    lbl_mobileNo.Text = dr["mobileNo"].ToString();
                    tb_Email.Text = dr["email"].ToString();
                    tb_Address.Text = dr["address"].ToString();
                    tb_postalCode.Text = dr["postal"].ToString();
                    tb_unitno.Text = dr["unitNo"].ToString();
                    Image1.ImageUrl = "~\\Images\\" + dr["Image"].ToString();
                    tb_DOB.Text = dr["DOB"].ToString();
                    RadioButtonList1.Text = dr["gender"].ToString();
                    tb_companyName.Text = dr["businessName"].ToString();

                    string role = dr["roles"].ToString();
                    if (role == "Buyer")
                    {
                        lbl_buyer.Visible = true;
                        business.Visible = true;
                        lbl_companyName.Visible = true;
                        tb_companyName.Visible = true;
                    }
                    else
                    {

                    }

                    //string address = dr["address"].ToString();
                    //if (address == "")
                    //{
                    //    Response.Write("<script>alert ('Update your personal details'); location.href='Profile.aspx';</script>");
                    //}
                    //else
                    //{


                    //}
                }
                else
                {

                }
                conn.Close();
                dr.Close();
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            int result = 0;
            string image = "";

            //update profile pic and details
            if (FileUpload1.HasFile == true)
            {
                image = "Images\\" + FileUpload1.FileName;
                string queryStr = "UPDATE Users SET " +
                            " gender =@gender, " +
                            " DOB =@DOB, " +
                            " address =@address, " +
                            " postal =@postal, " +
                            " unitNo =@unitNo, " +
                            //" mobileNo =@mobileNo, " +
                            " image =@image, " +
                            " businessName = @businessName, " +
                            " email =@email " +
                            " WHERE username='" + Session["Login"] + "'";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                cmd.Parameters.AddWithValue("@DOB", tb_DOB.Text);
                cmd.Parameters.AddWithValue("@address", tb_Address.Text);
                cmd.Parameters.AddWithValue("@postal", tb_postalCode.Text);
                cmd.Parameters.AddWithValue("@unitNo", tb_unitno.Text);
                //cmd.Parameters.AddWithValue("@mobileNo", tb_mobileNo.Text);
                cmd.Parameters.AddWithValue("@email", tb_Email.Text);
                cmd.Parameters.AddWithValue("@image", FileUpload1.FileName);
                cmd.Parameters.AddWithValue("@businessName", tb_companyName.Text);

                conn.Open();
                result += cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    string saveimg = Server.MapPath(" ") + "\\" + image;
                    FileUpload1.SaveAs(saveimg);
                }
                else
                {

                }
            }

            // update details only without profile pic
            else
            {
                string queryStr = "UPDATE Users SET " +
                            " gender =@gender, " +
                            " DOB =@DOB, " +
                            " address =@address, " +
                            " postal =@postal, " +
                            " unitNo =@unitNo, " +
                            //" mobileNo =@mobileNo, " +
                            " businessName = @businessName, " +
                            " email =@email " +
                            " WHERE username='" + Session["Login"] + "'";

                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                cmd.Parameters.AddWithValue("@DOB", tb_DOB.Text);
                cmd.Parameters.AddWithValue("@address", tb_Address.Text);
                cmd.Parameters.AddWithValue("@postal", tb_postalCode.Text);
                cmd.Parameters.AddWithValue("@unitNo", tb_unitno.Text);
                //cmd.Parameters.AddWithValue("@mobileNo", tb_mobileNo.Text);
                cmd.Parameters.AddWithValue("@email", tb_Email.Text);
                cmd.Parameters.AddWithValue("@businessName", tb_companyName.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Response.Write("<script>alert('Updated successfully'); location.href = 'Profile.aspx';</script>");
        }

        protected void linkbtn_leaderboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Leaderboard.aspx?user=" + Session["Login"].ToString());
        }

        protected void linkbtn_myrewards_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx?user=" + Session["Login"].ToString());
        }

        protected void linkbtn_voucher_Click(object sender, EventArgs e)
        {
            Response.Redirect("E-vouchers.aspx?user=" + Session["Login"].ToString());
        }

        protected void linkbtn_history_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx?user=" + Session["Login"].ToString());
        }

        protected void linkbtn_edit_Click(object sender, EventArgs e)
        {
            lbl_mobileNo.Visible = false;
            linkbtn_edit.Visible = false;

            tb_mobileNo.Visible = true;
            linkbtn_verify.Visible = true;
        }

        protected void linkbtn_verify_Click(object sender, EventArgs e)
        {
            linkbtn_verify.Visible = false;
            tb_code.Visible = true;
            tb_mobileNo.Visible = true;
            linkbtn_save.Visible = true;
            sent.Visible = true;

            Random random = new Random();
            activationcode = random.Next(1001, 9999).ToString();

            string queryStr = "UPDATE Users SET " +
                            " activationCode =@activationCode " +
                            " WHERE username='" + Session["Login"] + "'";

            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@activationCode", activationcode);
            conn.Open();
            cmd.ExecuteNonQuery();
            sendSMS();
            conn.Close();
        }

        private void sendSMS()
        {
            try
            {
                string number = "65" + tb_mobileNo.Text;

                string msg = "Your OTP number is " + activationcode + ".";

                String message = HttpUtility.UrlEncode(msg);
                using (var wb = new WebClient())
                {
                    byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "dJd3j06P+qA-Id07zk4r3JPqUWCsE0oK0mZuiCGG4O"},//home
                //{"apikey" , "dJd3j06P+qA-ZW9yImn6LRiW9GekqBzJWzE5fH6fau"}, //school
                {"numbers" , number},
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

        protected void linkbtn_save_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_connStr);
            string queryStr = "SELECT activationCode FROM Users WHERE username='" + Session["Login"] + "' AND activationCode = @activationCode";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@activationCode", tb_code.Text);
            conn.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                int result = 0;
                string queryStr2 = "UPDATE Users SET " +
                           " mobileNo =@mobileNo " +
                           " WHERE username='" + Session["Login"] + "'";

                SqlConnection conn2 = new SqlConnection(_connStr);
                SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);
                cmd2.Parameters.AddWithValue("@mobileNo", tb_mobileNo.Text);
                conn2.Open();
                result =+ cmd2.ExecuteNonQuery();
                if (result > 0)
                {
                    lbl_error.Visible = false;
                    tb_code.Visible = false;
                    linkbtn_verify.Visible = false;
                    Response.Write("<script>alert('Updated successfully'); location.href = 'Profile.aspx';</script>");
                }
                conn2.Close();
            }
            else
            {
                lbl_error.Visible = true;
            }
            conn.Close();
        }
    }
}