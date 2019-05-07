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
    public partial class Delete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblerror.Text = String.Empty;
                string name = Request.QueryString["username"];
                string item = Request.QueryString["itemName"];

                nameTb.Text = name;
                itemTb.Text = item;
                searchBtn_Click(searchBtn, EventArgs.Empty);
                lblerror.Text = String.Empty;
            }
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {


            adminCRUD_DAO admin = new adminCRUD_DAO();
            List<adminCRUD> list = new List<adminCRUD>();
            list = admin.getListingById(nameTb.Text, itemTb.Text);

            if (list != null)
            {
                lblerror.Text = String.Empty;
                ListingGv.DataSource = list;
                ListingGv.DataBind();
            }
            else
            {
                lblerror.Text = "This listing does not exist!";
            }


        }

        protected void ListingGv_SelectedIndexChanged(object sender, EventArgs e)
        {
            adminCRUD_DAO admin = new adminCRUD_DAO();
            List<adminCRUD> list = new List<adminCRUD>();
            GridViewRow row = ListingGv.SelectedRow;
            admin.deleteListing(row.Cells[0].Text, row.Cells[2].Text);

            customerDAO customer = new customerDAO();
            customer.deleteReport(row.Cells[0].Text);
            lblResult.Text = "Successfully deleted listing. An email has been sent to notify the user.";

            customerDAO report = new customerDAO();
            string email = report.getEmail(row.Cells[1].Text).ToString();
            string body = "Dear " + row.Cells[1].Text + "," + Environment.NewLine + Environment.NewLine + "Your listing: " + row.Cells[0].Text + " has been removed due to unrelated content/post. This violates the rules and regulation of our application. Please refrain from doing so if you do not want your account to be taken away. " + Environment.NewLine + Environment.NewLine + "Regards," + Environment.NewLine + "Admin Team";
            string subject = "Banned account alert";
            sendMail(subject, body, email);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BannedList.aspx");
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