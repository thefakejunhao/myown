using MyFYPJBackup.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackUpProject
{
    public partial class BannedList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            banResult.Text = String.Empty;
            if (Request.QueryString["name"] != null)
            {
                banResult.Text = "You have successfully banned user: " + Request.QueryString["name"] + ". An email has been sent to notify the user.";
            }
            else if (Request.QueryString["state"] != null)
            {
                banResult.Text = "You have successfully unbanned user: " + Request.QueryString["state"];
            }

            else
            {
                banResult.Text = String.Empty;
            }

            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();


            customerList = customer.getBannedCustomer();

            BannedGriDView.DataSource = customerList;
            BannedGriDView.DataBind();
        }

        protected void BannedGriDView_SelectedIndexChanged(object sender, EventArgs e)
        {
            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();

            GridViewRow row = BannedGriDView.SelectedRow;
            //delete from banned list
            customer.unBan(row.Cells[0].Text);

            //set status to no
            customer.updateBanStatusNo(row.Cells[0].Text);

            Response.Redirect("BannedList.aspx?state=" + row.Cells[0].Text);
        }


        protected void searchBtn_Click(object sender, EventArgs e)
        {
            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();

            customerList = customer.getBannedCustomerbySearch(searchTb.Text);
            BannedGriDView.DataSource = customerList;
            BannedGriDView.DataBind();
        }

    }
}