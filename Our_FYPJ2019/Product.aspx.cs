using MyFYPJBackup.DAL;
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
    public partial class Product : System.Web.UI.Page
    {
        protected List<product> itemList = new List<product>();
        protected List<product> userList = new List<product>();
        protected List<schedule> timeList = new List<schedule>();
        protected List<schedule> otherList = new List<schedule>();
        protected List<schedule> scheduleList = new List<schedule>();
        List<schedule> SuggestionList = new List<schedule>();

        protected string states;
        protected void Page_Load(object sender, EventArgs e)
        {
            productDAO productdao = new productDAO();
            scheduleDAO scheduledao = new scheduleDAO();

            string estate = "";
            string status = ""; //buyer or seller
            string username = Session["Login"].ToString();
            string currentdate = DateTime.Now.ToString("dd MMMM yyyy");

            //string itemid = Request.QueryString[""];
            string currentuser = Session["Login"].ToString(); //get current session

            lblResult.Text = String.Empty;
            
            userList = productdao.getuser(currentuser);
            foreach (var i in userList)
            {
                status = i.status;           
            }

            states = status;

            if (status.ToLower() == "seller")
            {
                schedulebutton.Visible = false;
                report.Visible = false;
            }

            int id = Convert.ToInt32(Request.QueryString["id"]);
            itemList = productdao.getproduct(id);

            //check if suggestionlist is null
            foreach (var i in itemList)
            {
                estate = i.estate;
            }

            SuggestionList = scheduledao.getsuggestion(username, estate, currentdate);

            //Make suggestion part visible
            if (SuggestionList != null)
            {
                suggestionpart.Visible = true;
                foreach(var i in SuggestionList)
                {
                    lblsuggestion.Text = "You have <strong>" + i.num + " '" + i.timeslot + "'</strong> timeslots scheduled for <strong>" + estate + "</strong> on <strong>" + i.collectiondate + "</strong>. Do you like to set it to this date?";
                }

            }
        }

        protected void itemdel_Click(object sender, EventArgs e)
        {
            string user = Session["Login"].ToString();
            if (IsPostBack)
            {
                
                DeleteDAO deletedao = new DeleteDAO();
                int id = Convert.ToInt32(Request.QueryString["id"]);
                deletedao.deleteList(id);
                Response.Redirect("SellerListing.aspx?status=seller&user=" + user);
               
            }

        }

        protected void send_Click(object sender, EventArgs e)
        { 
            Response.Write("<script>alert('You have successfully send your quotation!')</script>");
            productDAO productdao = new productDAO();
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string coverimg = "";
            string img2 = "";
            string img3 = "";
            string img4 = "";
            string category = "";
            string weight = "";
            string quantity = "";
            string estate = "";
            string address = "";
            string unitno = "";
            string postalcode = "";
            string buyer = Session["Login"].ToString() ; //Retrieve session name
            string seller = Request.QueryString["user"];
            string price = tbprice.Text;
            string accept = status.Value;
            string date = DateTime.Now.ToString("dd MMMM yyyy");
            string time = DateTime.Now.ToString("hh:mm tt");
            string item = Request.QueryString["item"];
            string desc = tadesc.InnerText;
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

            submit.Text = "You have submitted your quotation";
            itemList = productdao.getproduct(id);
            foreach (var img in itemList)
            {
                coverimg = img.image1;
                category = img.rtype;
                weight = img.weight;
                quantity = img.qty;
                img2 = img.image2;
                img3 = img.image3;
                img4 = img.image4;
                estate = img.estate;
                address = img.address;
                unitno = img.unitno;
                postalcode = img.postalcode;

            }
            
            productdao.qpush(id, item, buyer, seller, desc, price, accept, date, coverimg, "", "", "yes", "no", category, weight, quantity, img2, img3, img4, 
                estate, address, unitno, postalcode, collectiondate, timeslot, time);
            buyermsg.Text = "You have succesfully sent!";
            
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
                        e.Cell.BackColor = System.Drawing.Color.Yellow;
                        e.Cell.Controls.Add(new LiteralControl("<br />" + "<strong style= 'border-radius:60% 50% 50% 60%;border:2px solid black;text-align:center;font-size:90%;" +
                            "font-color:white;-webkit-border-radius: 50%;-moz-border-radius: 50%;'>" + i.num + "</strong>"));
                    }

                  
                }
            }

        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            productDAO productdao = new productDAO();

            string currentuser = Session["Login"].ToString(); //get current session

            string status = ""; //buyer or seller

            userList = productdao.getuser(currentuser);
            foreach (var i in userList)
            {
                status = i.status;
            }

            btnReport.Enabled = true;
            int idd = Convert.ToInt32(Request.QueryString["id"]);

            string coverimg = "";
            string img2 = "";
            string img3 = "";
            string img4 = "";
            string category = "";
            string weight = "";
            string quantity = "";
            //string buyer = "jw"; //Retrieve session name
            //string seller = Request.QueryString["user"];
            string price = tbprice.Text;
            //string accept = status.Value;
            string date = DateTime.Now.ToString("dd MMMM yyyy, hh:mm tt");
            string desc = tadesc.InnerText;

            itemList = productdao.getproduct(idd);
            foreach (var img in itemList)
            {
                coverimg = img.image1;
                category = img.rtype;
                weight = img.weight;
                quantity = img.qty;
                img2 = img.image2;
                img3 = img.image3;
                img4 = img.image4;

            }

            string seller = Request.QueryString["user"];
            string id = Request.QueryString["id"];
            string item = Request.QueryString["item"];
            //changes
            customerDAO report = new customerDAO();
            if (ddlReason.SelectedItem.Text != "--Select--")
            {
                report.updateCount(seller);
                report.reportListing(seller, id, ddlReason.SelectedItem.Text, report.getEmail(seller).ToString(), item);
                lblResult.Text = "Report sent. Please allow some time for admin evaluation";
            }
            else
            {
                Response.Write("<script>alert('Report reason not selected! Report fail!')</script>");
            }


        }
      
        protected void btnyes_Click(object sender, EventArgs e)
        {
            //Variables
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string username = Session["Login"].ToString();
            string estate = "";
            string selecteddate = "";
            string currentdate = DateTime.Now.ToString("dd MMMM yyyy");

            //Get estate of seller
            productDAO productdao = new productDAO();
            itemList = productdao.getproduct(id);
            foreach (var i in itemList)
            {
                estate = i.estate;
            }

            //Get similar scheduled dates           
            scheduleDAO scheduledao = new scheduleDAO();
            SuggestionList = scheduledao.getsuggestion(username, estate, currentdate);
            foreach (var i in SuggestionList)
            {
                datetimeslot.Text = i.collectiondate;
                Calendar2.SelectedDate = Convert.ToDateTime(i.collectiondate);
                selecteddate = i.collectiondate;
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

            //Set default value of radiobutton
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

        protected void btnno_Click(object sender, EventArgs e)
        {
            suggestionpart.Visible = false;
            btnyes.Visible = false;
            btnno.Visible = false;
        }

    }
}