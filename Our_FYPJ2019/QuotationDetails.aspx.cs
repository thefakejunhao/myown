using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace Our_FYPJ2019
{
    public partial class QuotationDetails : System.Web.UI.Page
    {
        protected List<product> quoteList = new List<product>();
        protected List<schedule> timeList = new List<schedule>();
        protected List<schedule> otherList = new List<schedule>();
        protected List<schedule> scheduleList = new List<schedule>();
        protected List<product> HistoryList = new List<product>();
        protected string status;
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            status = Request.QueryString["status"];
            string quoteid = Request.QueryString["quoteid"];
            string estate = "";
            string username = Session["Login"].ToString();
            string selecteddate = "";
            string currentdate = DateTime.Now.ToString("dd MMMM yyyy");

            productDAO productdao = new productDAO();
            scheduleDAO scheduledao = new scheduleDAO();
                       
            quoteList = productdao.getQuoteDetail(status, quoteid);
            HistoryList = productdao.getQuoteHistory(quoteid);
            quotegv.DataSource = HistoryList;
            quotegv.DataBind();

            if (!IsPostBack && status == "buyer" )
            {               
                foreach (var i in quoteList)
                {
                    Calendar2.SelectedDate = Convert.ToDateTime(i.collectiondate); //Set default date                    
                    datetimeslot.Text = i.collectiondate;//Set header timeslot
                    selecteddate = i.collectiondate;
                    tbuserprice.Text = i.price;
                    tauserdesc.InnerText = i.desc;
                    estate = i.estate;
                    if (i.timeslot == "9am - 12pm")
                    {
                        rb1.Checked = true;
                    }

                    else if (i.timeslot == "1pm - 4pm")
                    {
                        rb2.Checked = true;
                    }

                    else if (i.timeslot == "4pm - 7pm")
                    {
                        rb3.Checked = true;
                    }

                    else if (i.timeslot == "8pm - 10pm")
                    {
                        rb4.Checked = true;
                    }
                }
                
                //set default value for radiobutton                
                otherList = scheduledao.getothers(username, selecteddate);
                timeslot.Visible = true;
                if (otherList != null)
                {
                    foreach (var i in otherList)
                    {
                        if (i.timeslot == "9am - 12pm")
                        {
                            li1.Visible = false;
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            li.Attributes["class"] = "list-group-item";
                            li.InnerText = i.estate + " : " + i.num;
                            ul1.Controls.Add(li);
                        }

                        else if (i.timeslot == "1pm - 4pm")
                        {
                            li2.Visible = false;
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            li.Attributes["class"] = "list-group-item";
                            li.InnerText = i.estate + " : " + i.num;
                            ul2.Controls.Add(li);
                        }

                        else if (i.timeslot == "4pm - 7pm")
                        {
                            li3.Visible = false;
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            li.Attributes["class"] = "list-group-item";
                            li.InnerText = i.estate + " : " + i.num;
                            ul3.Controls.Add(li);
                        }

                        else if (i.timeslot == "8pm - 10pm")
                        {
                            li4.Visible = false;
                            HtmlGenericControl li = new HtmlGenericControl("li");
                            li.Attributes["class"] = "list-group-item";
                            li.InnerText = i.estate + " : " + i.num;
                            ul4.Controls.Add(li);
                        }
                    }
                }
            }

        }

        

        protected void sellerSubmit_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("sellersubmit is clicked");
            productDAO productdao = new productDAO();
            int quoteid = Convert.ToInt32(Request.QueryString["quoteid"]);
            string accept = ddlaccept.SelectedItem.Text;
            //string counter = "";
            string reason = ddlreason.SelectedItem.Text;
            string reasondesc = tareasondesc.InnerText;
            string sellerdate = DateTime.Now.ToString("dd MMMM yyyy, hh:mm tt");
            
            string itemid = "";
            string item = "";
            string buyer = "";
            string seller = "";
            string desc = "";
            string price = "";
            string buyerdate = "";

            foreach (var i in quoteList)
            {
                itemid = i.quoteid.ToString();
                item = i.item;
                buyer = i.buyer;
                seller = i.seller;
                desc = i.desc;
                price = i.price;
                buyerdate = i.date;
            }

            if (accept == "yes")
            {
                //junhao

                //Germaine
                int result = 0;
                string username = Session["Login"].ToString();
                string queryStr = "UPDATE Points SET " +
                                 "itemSoldpoints = itemSoldpoints + 5, " +
                                 "mitemSoldpoints = mitemSoldpoints + 5, " +
                                 "pointLeft = pointLeft + 5 " +
                                 " WHERE username='" + username + "'";
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                conn.Open();
                result = cmd.ExecuteNonQuery();
                conn.Close();

                if (result > 0)
                {
                    SqlConnection conn3 = new SqlConnection(_connStr);
                    conn3.Open();
                    string queryStr3 = "SELECT pointLeft FROM Points WHERE username='" + username + "'";
                    SqlCommand cmd3 = new SqlCommand(queryStr3, conn3);
                    SqlDataReader dr = cmd3.ExecuteReader();

                    if (dr.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("drread");
                        int balance = int.Parse(dr["pointLeft"].ToString());
                        System.Diagnostics.Debug.WriteLine("balance = ", balance);

                        string queryStr2 = "INSERT into Activity(activityName, dateTime, username, change, balance)" +
                                            "values(@activityName, @dateTime, @username, @change, @balance)";

                        SqlConnection conn2 = new SqlConnection(_connStr);
                        SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);

                        cmd2.Parameters.AddWithValue("@activityName", "You have earned 5 points for successful transaction.");
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@dateTime", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@change", "+5");
                        cmd2.Parameters.AddWithValue("@balance", balance);

                        conn2.Open();
                        cmd2.ExecuteNonQuery();
                        conn2.Close();
                    }
                    conn3.Close();
                    dr.Close();
                }
            }

            sellermsg.Text = "You have successfully send!";

            productdao.sellerQuotepush(quoteid, accept, reason, reasondesc, "no", "yes", sellerdate, Convert.ToInt32(itemid));
            productdao.QuoteHistorypush(itemid, item, buyer, seller, desc, price, accept, buyerdate, reason, reasondesc, sellerdate);

            sellersec.Visible = false;

        }

        protected void buyerbutton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("buyerbutton is clicked");
            int quoteid = Convert.ToInt32(Request.QueryString["quoteid"]);
            productDAO productdao = new productDAO();
            string price = tbuserprice.Text;
            string desc = tauserdesc.InnerText;
            string buyerdate = DateTime.Now.ToString("dd MMMM yyyy");
            string buyertime = DateTime.Now.ToString("hh:mm tt");
            string collectiondate = datetimeslot.Text;
            string timeslot = "";
            if (rb1.Checked)
            {
                timeslot = rb1.Text;
            }

            else if (rb2.Checked)
            {
                timeslot = rb2.Text;
            }

            else if (rb3.Checked)
            {
                timeslot = rb3.Text;
            }

            else if (rb4.Checked)
            {
                timeslot = rb4.Text;
            }

            string itemid = "";
            string item = "";
            string buyer = "";
            string seller = "";
            string sellerdate = "";
            string accept = "";
            string reason = "";
            string reasondesc = "";

            foreach (var i in quoteList)
            {
                itemid = i.quoteid.ToString();
                item = i.item;
                buyer = i.buyer;
                seller = i.seller;
                sellerdate = i.sellerdate;
                accept = i.status;
                reason = i.reason;
                reasondesc = i.reasondesc;
            }

            buyermsg.Text = "You have succesfully sent!";

            productdao.buyerQuotepush(quoteid, desc, price, buyerdate, "yes", "no", collectiondate, timeslot, buyertime);
            productdao.QuoteHistorypush(itemid, item, buyer, seller, desc, price, accept, buyerdate, reason, reasondesc, sellerdate);
            Response.Write("<script>alert('You have successfully send your quotation!')</script>");

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

            scheduleDAO scheduledao = new scheduleDAO();
            string username = Session["Login"].ToString();
            timeslot.Visible = true;
            string selecteddate = Calendar2.SelectedDate.ToString("dd MMMM yyyy");
            datetimeslot.Text = selecteddate;//radiofield
            otherList = scheduledao.getothers(username, selecteddate);

            //Displaying other schedules
            if (otherList != null)
            {
                foreach (var i in otherList)
                {
                    if (i.timeslot == "9am - 12pm")
                    {
                        li1.Visible = false;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.estate + " : " + i.num;
                        ul1.Controls.Add(li);
                    }

                    else if (i.timeslot == "1pm - 4pm")
                    {
                        li2.Visible = false;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.estate + " : " + i.num;
                        ul2.Controls.Add(li);
                    }

                    else if (i.timeslot == "4pm - 7pm")
                    {
                        li3.Visible = false;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.estate + " : " + i.num;
                        ul3.Controls.Add(li);
                    }

                    else if (i.timeslot == "8pm - 10pm")
                    {
                        li4.Visible = false;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.estate + " : " + i.num;
                        ul4.Controls.Add(li);
                    }
                }
            }

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#ScheduleModal').modal('show')", true);

        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            scheduleDAO scheduledao = new scheduleDAO();
            string user = Session["Login"].ToString();
            timeList = scheduledao.getnumbers(user);

            if (e.Day.Date <= DateTime.Now)

            {

                e.Cell.BackColor = System.Drawing.Color.DarkGray;
                e.Day.IsSelectable = false;

            }

            if (timeList != null)
            {
                foreach (var i in timeList)
                {
                    if (e.Day.Date.ToString("dd MMMM yyyy") == i.date)
                    {
                        System.Diagnostics.Debug.WriteLine("*************yes************");
                        e.Cell.BackColor = System.Drawing.Color.Yellow;
                        e.Cell.Controls.Add(new LiteralControl("<br />" + "<strong style= 'border-radius:50%;border:2px solid black;text-align:center'>" + i.num + "</strong>"));
                    }

                    else
                    {
                        System.Diagnostics.Debug.WriteLine("*************none************");
                    }
                }
            }

        }

        






    }
}