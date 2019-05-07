using MyFYPJBackup.DAL;
using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Our_FYPJ2019
{
    public partial class slot : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string date = Request.QueryString["date"].ToString();
            string username = Session["Login"].ToString();
            List<schedule> List = new List<schedule>();
            scheduleDAO scheduledao = new scheduleDAO();
            List = scheduledao.collectiontimeslot(username, date);
            title.InnerText = date + "'s Timeslots";
            if (List != null)
            {
                foreach (var i in List)
                {
                    if (i.timeslot == "9am - 12pm")
                    {
                        string postalcode = Regex.Replace(i.postalcode, @"\s", "");
                        //create button
                        Button btn2 = new Button();
                        btn2.Text = "Go";                      
                        btn2.Attributes.Add("onclick", "window.location.href = 'mapdirection.aspx?timeslot=9am - 12pm&postalcode= " + postalcode+ "&date=" + date + "';return false");
                        
                        li1.Visible = true;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.postalcode + ":       " + i.num + "                 ";
                        li.Controls.Add(btn2);
                        slot1.Controls.Add(li);
                    }

                    else if (i.timeslot == "1pm - 4pm")
                    {
                        string postalcode = Regex.Replace(i.postalcode, @"\s", "");
                        //create button
                        Button btn2 = new Button();
                        btn2.Text = "Go";
                        btn2.Attributes.Add("onclick", "window.location.href = 'mapdirection.aspx?timeslot=1pm - 4pm&postalcode= " + postalcode + "&date=" + date + "';return false");


                        li2.Visible = true;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.postalcode+ ":        " + i.num + "                 ";
                        li.Controls.Add(btn2);
                        slot2.Controls.Add(li);
                    }

                    else if (i.timeslot == "4pm - 7pm")
                    {
                        string postalcode = Regex.Replace(i.postalcode, @"\s", "");
                        //create button
                        Button btn2 = new Button();
                        btn2.Text = "Go";
                        btn2.Attributes.Add("onclick", "window.location.href = 'mapdirection.aspx?timeslot=4pm - 7pm&postalcode= " + postalcode + "&date=" + date + "';return false");
                        li3.Visible = true;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.postalcode + ":       " + i.num + "                 ";
                        li.Controls.Add(btn2);
                        slot3.Controls.Add(li);
                    }

                    else if (i.timeslot == "8pm - 10pm")
                    {
                        string postalcode = Regex.Replace(i.postalcode, @"\s", "");
                        //create button
                        Button btn2 = new Button();
                        btn2.Text = "Go";
                        btn2.Attributes.Add("onclick", "window.location.href = 'mapdirection.aspx?timeslot=8pm - 10pm&postalcode= " + postalcode + "';return false");

                        li4.Visible = true;
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        li.Attributes["class"] = "list-group-item";
                        li.InnerText = i.postalcode + ":       " + i.num + "                 ";
                        li.Controls.Add(btn2);
                        slot4.Controls.Add(li);
                    }
                }
            }
            
        }

        
    }
}