using MyFYPJBackup.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackUpProject
{
    public partial class reportedUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();

            //Set default to reported by Listing
            lblType.Text = "Reported by Listing";

            customerList = customer.getReportedCustomerByReason("Listing");

            reportedListingUserGv.DataSource = customerList;
            reportedListingUserGv.DataBind();
            reportedListingUserGv.Visible = true;

            lbldisplayPage.Text = "Displaying page" + (reportedListingUserGv.PageIndex + 1).ToString() + " of " + reportedListingUserGv.PageCount.ToString();

            if (ddlSort.SelectedItem.Text == "Most Reported")
            {
                customerList = customer.getReportedCustomerbyNumber("Listing");
                reportedListingUserGv.DataSource = customerList;
                reportedListingUserGv.DataBind();
            }
            else if (ddlSort.SelectedItem.Text == "Least Reported")
            {
                customerList = customer.getReportedCustomerbyNumber2("Listing");
                reportedListingUserGv.DataSource = customerList;
                reportedListingUserGv.DataBind();
            }
            else if (ddlSort.SelectedItem.Text == "Recent")
            {
                customerList = customer.getReportedCustomerByRecent("Listing");
                reportedListingUserGv.DataSource = customerList;
                reportedListingUserGv.DataBind();
            }
            else
            {
                //Set default to reported by Listing
                lblType.Text = "Reported by Listing";


                customerList = customer.getReportedCustomerByReason("Listing");

                reportedListingUserGv.DataSource = customerList;
                reportedListingUserGv.DataBind();
                reportedListingUserGv.Visible = true;
            }

        }

        protected void btnChat_Click(object sender, EventArgs e)
        {
            lblGv.Text = String.Empty;
            lblType.Text = "Reported by Chat";
            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();

            customerList = customer.getReportedCustomerByReason("Chat");

            if (reportedListingUserGv.Visible == true && customerList != null)
            {
                reportedListingUserGv.Visible = false;
                reportedChatUserGv.DataSource = customerList;
                reportedChatUserGv.DataBind();
                reportedChatUserGv.Visible = true;

            }
            else
            {
                lblGv.Text = "You have no existing report for chat";
            }
        }

        protected void btnListing_Click(object sender, EventArgs e)
        {
            lblGv.Text = String.Empty;
            lblType.Text = "Reported by Listing";
            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();

            customerList = customer.getReportedCustomerByReason("Listing");

            if (reportedChatUserGv.Visible == true && customerList != null)
            {

                reportedListingUserGv.DataSource = customerList;
                reportedListingUserGv.DataBind();
                reportedListingUserGv.Visible = true;
                reportedChatUserGv.Visible = false; //hide chat

            }

            else
            {
                lblGv.Text = "You have no existing report for listing";
            }
        }

        protected void reportedListingUserGv_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = reportedListingUserGv.SelectedRow;
            Session["itemID"] = row.Cells[3].Text;
            Session["username"] = row.Cells[0].Text;
            Response.Redirect("Delete.aspx?itemName=" + Session["itemID"] + "&username=" + Session["username"]);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            customerDAO customer = new customerDAO();

            customer.deleteReport(reportIDtb.Text);
            Response.Redirect("reportedUser.aspx");
            lblMsg.Text = "Report ID: " + reportIDtb.Text + " Deleted successfully";

        }

        //paging property

        protected void reportedListingUserGv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            lblGv.Text = String.Empty;
            lblType.Text = "Reported By Listing";

            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();

            customerList = customer.getReportedCustomerByReason("Listing");

            reportedListingUserGv.DataSource = customerList;
            reportedListingUserGv.PageIndex = e.NewPageIndex;
            reportedChatUserGv.DataBind();

        }

        protected void Sort_Click(object sender, EventArgs e)
        {

            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();

            customerList = customer.getReportedCustomerbyNumber("Listing");
            reportedListingUserGv.DataSource = customerList;
            reportedListingUserGv.DataBind();
        }
    }
}