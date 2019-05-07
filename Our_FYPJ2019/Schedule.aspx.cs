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
    public partial class Schedule : System.Web.UI.Page
    {
        protected List<schedule> estateList = new List<schedule>();
        protected List<schedule> tableListno = new List<schedule>();
        protected List<schedule> tableListyes = new List<schedule>();
        protected List<schedule> timeList = new List<schedule>();
        protected List<schedule> otherList = new List<schedule>();
        protected List<schedule> scheduleList = new List<schedule>();
        protected List<schedule> notscheduleList = new List<schedule>();
        protected void Page_Load(object sender, EventArgs e)
        {
            scheduleDAO scheduledao = new scheduleDAO();            
            string username = Session["Login"].ToString();
            
            if (!IsPostBack)
            {
                Calendar2.SelectedDate = DateTime.Today; //set today's date
                string selecteddate = Calendar2.SelectedDate.ToString("dd MMMM yyyy");
                tableListno = scheduledao.gettableno(username, selecteddate); //get uncollected data
                tableListyes = scheduledao.gettableyes(username, selecteddate); //get collecteddata
                cdate.Visible = true; //Make Date header text visible
                cdate.InnerText = selecteddate; //set it to selected date
                toggle.Visible = true;

                if (tableListno != null)
                {
                    nodate.Text = "";
                    dateGVno.Visible = true;
                    //collectionbutton.Visible = true;
                    dateGVno.DataSource = tableListno;
                    dateGVno.DataBind();
                }

                else if (tableListno == null)
                {
                    dateGVno.Visible = false;
                    //collectionbutton.Visible = false;
                    nodate.Text = "There is no scheduled timeslots";
                }

                if (tableListyes != null)
                {
                    nodate2.Text = "";
                    dateGVyes.DataSource = tableListyes;
                    dateGVyes.DataBind();
                }

                else if (tableListno == null)
                {
                    nodate2.Text = "No collected items";
                }
            }           
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {

            scheduleDAO scheduledao = new scheduleDAO();
            string user = Session["Login"].ToString();
            estateList = scheduledao.getscheduleList(user);
            notscheduleList = scheduledao.notreschedule(user);

            if (estateList != null)
            {
                foreach (var i in estateList)
                {
                    if (e.Day.Date.ToString("dd MMMM yyyy") == i.date)
                    {                       
                        e.Cell.Controls.Add(new LiteralControl("<br /><span style='font-size:80%'>" + i.estate + " : " + i.num + "</span>"));
                        e.Cell.BackColor = System.Drawing.Color.Wheat;
                    }

                }
            }


            if (notscheduleList!= null)
            {
                foreach (var i in notscheduleList)
                {
                    if (e.Day.Date.ToString("dd MMMM yyyy") == i.date)
                    {
                        e.Cell.Controls.Add(new LiteralControl("Reschedule item!"));
                        e.Cell.BackColor = System.Drawing.Color.DarkRed;
                    }

                }
            }


            if (e.Day.IsSelected)
            {
                e.Cell.BackColor = System.Drawing.Color.DarkBlue;
            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            scheduleDAO scheduledao = new scheduleDAO();
            string username = Session["Login"].ToString();
            string selecteddate = Calendar2.SelectedDate.ToString("dd MMMM yyyy");
            tableListno = scheduledao.gettableno(username, selecteddate); //get uncollected data
            tableListyes = scheduledao.gettableyes(username, selecteddate); //get collecteddata

            cdate.Visible = true; //Make Date header text visible
            cdate.InnerText = selecteddate;
            toggle.Visible = true;

            if (tableListno != null)
            {
                nodate.Text = "";
                dateGVno.Visible = true;
                dateGVno.DataSource = tableListno;
                dateGVno.DataBind();    
            }

            else if (tableListno == null)
            {
                dateGVno.Visible = false;
                nodate.Text = "There is no scheduled timeslots";
            }
                
            if (tableListyes != null)
            {
                nodate2.Text = "";
                dateGVyes.DataSource = tableListyes;
                dateGVyes.DataBind();
            }

            else if (tableListno == null)
            {              
                nodate2.Text = "No collected items";
            }

        }
        
        protected void btnreschedule_Click(object sender, EventArgs e)
        {
            scheduleDAO scheduledao = new scheduleDAO();
            string username = Session["Login"].ToString();
            string selecteddate = cdate.InnerText; //get selected dates
            string changetime = "";

            if (rb1.Checked)
            {
                changetime = rb1.Text;
            }

            else if (rb2.Checked)
            {
                changetime = rb2.Text;
            }

            else if (rb3.Checked)
            {
                changetime = rb3.Text;
            }

            else if (rb4.Checked)
            {
                changetime = rb4.Text;
            }

            string desc = tadesc.InnerText;
            string changedate = datetimeslot.Text;
            string currentdatetime = DateTime.Now.ToString("dd MMMM yyyy, hh:mm tt"); //current time and date

            foreach (GridViewRow gvItem in dateGVno.Rows)
            {
                CheckBox chkItem = (CheckBox)gvItem.FindControl("reschedule"); //get checkboxfield
                Label lblQuoteId = (Label)gvItem.FindControl("lblquoteid") as Label; //get quoteid
                int QuoteidValue = Convert.ToInt32(lblQuoteId.Text.ToString());
                if (chkItem.Checked)
                {
                    scheduledao.updatetiming(QuoteidValue,desc,changedate,changetime, currentdatetime);
                }

                tableListno = scheduledao.gettableno(username, selecteddate); //get uncollected data
                tableListyes = scheduledao.gettableyes(username, selecteddate); //get collecteddata
                Calendar1.SelectedDate = Convert.ToDateTime(selecteddate); //set selected date
                dateGVno.DataBind();
                dateGVno.DataSource = tableListno;
                dateGVyes.DataBind();
                dateGVyes.DataSource = tableListyes;
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            scheduleDAO scheduledao = new scheduleDAO();
            string username = Session["Login"].ToString();
            timeslot.Visible = true;
            string selecteddate = Calendar1.SelectedDate.ToString("dd MMMM yyyy");
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

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModal').modal('show')", true);
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
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

        protected void collectionbutton_Click(object sender, EventArgs e)
        {
            string date = cdate.InnerText;
            Response.Redirect("slot.aspx?date=" + date);
        }
    }
}