using MyFYPJBackup.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackUpProject
{
    public partial class BanConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //generate banning confirmation
            string name = String.Empty;
            //string unit = String.Empty;
            string Address = String.Empty;
            string ContactNo = String.Empty;
            string Email = String.Empty;
            string unit = String.Empty;

            name = Request.QueryString["name"];
            unit = Request.QueryString["unit"];
            Address = Request.QueryString["Address"];
            ContactNo = Request.QueryString["ContactNo"];
            Email = Request.QueryString["Email"];
            //Area = Request.QueryString["Area"];

            lblName.Text = name;
            //lblNRIC.Text = unit;
            lblAddress.Text = Address;
            lblContact.Text = ContactNo;
            lblEmail.Text = Email;
            lblArea.Text = unit;
            lbladmin.Text = Session["NRIC"].ToString();
        }

        protected void banBtn_Click(object sender, EventArgs e)
        {
            customerDAO customer = new customerDAO();
            string datetime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");


            if (reasontb.Text == "")
            {
                ErrorMsg.Text = "Please enter a banning reason!";
            }
            else
            {
                //put customer into banning list
                customer.AddBannedUser(Request.QueryString["name"], Request.QueryString["ContactNo"], Request.QueryString["Address"], Request.QueryString["Email"], reasontb.Text, Request.QueryString["unit"], Session["NRIC"].ToString(), DateTime.Now.ToString("MM/dd/yyyy HH:mm"));

                //Session["name"] = Request.QueryString["name"];
                Session["name"] = Request.QueryString["name"];

                //update banning status to yes

                customer.updateBanStatusYes(Request.QueryString["name"]);

                //send email to user
                string body = "Dear " + Session["name"] + "," + Environment.NewLine + Environment.NewLine + "Your account of name " + Session["name"] + " has been banned due to " + reasontb.Text + ". This violates the rules and regulation of our application, you will not be able to logon to your account anymore. " + Environment.NewLine + Environment.NewLine + "Regards," + Environment.NewLine + "Admin Team";
                string subject = "Banned account alert";
                sendMail(subject, body, Request.QueryString["Email"]);
                Response.Redirect("BannedList.aspx?name=" + Session["name"]);
            }
        }

        protected void sendMail(string subject, string body, string toEmail)
        {
            // Gmail Address from where you send the mail
            var fromAddress = "xsquare2000@gmail.com";
            // any address where the email will be sending
            var toAddress = toEmail;
            //Password of your gmail address
            const string fromPassword = "@xxiaoxiao";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

    }
}