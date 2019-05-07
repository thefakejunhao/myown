using MyFYPJBackup.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackUpProject
{
    public partial class adminBanning : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSearch.Text = String.Empty;
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            //binding customer data
            customerDAO customer = new customerDAO();
            List<customer> customerList = new List<customer>();
            customerList = customer.getCustomerById(searchtb.Text.ToLower());

            if (searchtb.Text == "")
            {
                lblSearch.Text = "Please Enter a NRIC or Contact Number or Name";

            }
            else if (customerList == null)
            {
                lblSearch.Text = "No user record found, please try again!";

            }
            else
            {
                CustomerGv.DataSource = customerList;
                CustomerGv.DataBind();
            }

        }

        protected void banListBtn_Click(object sender, EventArgs e)
        {

            Response.Redirect("BannedList.aspx");
        }

        protected void CustomerSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

            customerDAO customer = new customerDAO();
            GridViewRow row = CustomerGv.SelectedRow;
            //int count = customer.deleteCustomer(row.Cells[1].Text);
            Session["name"] = row.Cells[0].Text;
            Session["unit"] = row.Cells[2].Text;
            Session["Address"] = row.Cells[1].Text;
            Session["ContactNo"] = row.Cells[3].Text;
            Session["Email"] = row.Cells[4].Text;
            //Session["Area"] = row.Cells[3].Text;

            Response.Redirect("BanConfirmation.aspx?name=" + Session["name"] + "&unit=" + Session["unit"] + "&address=" + Session["Address"] + "&ContactNo=" + Session["ContactNo"] + "&email=" + Session["Email"]);


        }

    }
}