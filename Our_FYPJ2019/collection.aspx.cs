using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Our_FYPJ2019
{
    public partial class collection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<schedule> scheduleList = new List<schedule>();
            scheduleDAO scheduledao = new scheduleDAO();
            string postalcode = Session["postalcode"].ToString();
            string username = Session["Login"].ToString();
            string address = Session["address"].ToString();
            string timeslot = Session["timeslot"].ToString();
            string date = Session["date"].ToString();

            lbladdress.Text = "<strong>ADDRESS  :  </strong>" + address;
            lbltimeslot.Text = "<strong>TIMESLOT  :  </strong>" + timeslot;
            lbldate.InnerText = date;

            scheduleList = scheduledao.uncollectedlist(username, date, timeslot, postalcode);
            if (scheduleList == null)
            {
                System.Diagnostics.Debug.WriteLine("schedulist is empty");
            }

            else
            {
                System.Diagnostics.Debug.WriteLine("schedulelist is not empty");
            }

            if (!IsPostBack)
            {
                dateGVno.DataSource = scheduleList;
                dateGVno.DataBind();
            }
            
        }

        protected void dateGVno_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            scheduleDAO scheduledao = new scheduleDAO();
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;

            if (e.CommandName == "collectone")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                Label lblQuoteId = row.FindControl("lblquoteid") as Label;
                int QuoteidValue = Convert.ToInt32(lblQuoteId.Text.ToString());
                scheduledao.updatecollect(QuoteidValue);
                Response.Redirect("collection.aspx");

            }

        }

        protected void btnallcollect_Click(object sender, EventArgs e)
        {
            scheduleDAO scheduledao = new scheduleDAO();

            foreach (GridViewRow gvItem in dateGVno.Rows)
            {
                CheckBox chkItem = (CheckBox)gvItem.FindControl("CBcollect"); //get checkboxfield
                Label lblQuoteId = (Label)gvItem.FindControl("lblquoteid") as Label; //get quoteid
                int QuoteidValue = Convert.ToInt32(lblQuoteId.Text.ToString());
                if (chkItem.Checked)
                {
                    scheduledao.updatecollect(QuoteidValue);
                }
            }

            Response.Redirect("collection.aspx");

        }

        protected void linkhomepage_Click(object sender, EventArgs e)
        {
            string date = Session["date"].ToString();
            Response.Redirect("slot.aspx?date=" + date);
        }
    }
}