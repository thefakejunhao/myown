using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FYPJ
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected List<product> addlist = new List<product>();
        protected void Page_Load(object sender, EventArgs e)
        {
            productDAO listingdao = new productDAO();
            string status = "";
            
            if (Session["Login"] != null)
            {
                
                afterlogin.Visible = true;
                beforelogin.Visible = false;
                string username = Session["Login"].ToString();
                addlist = listingdao.getuser(username);
                foreach (var i in addlist)
                {
                    status = i.status;
                }

                System.Diagnostics.Debug.WriteLine("PageLoad, user status = " + status);

                if (status.ToLower() == "buyer")
                {
                    sellpart.Visible = false;
                    postbutton.Visible = false;
                    rewardpart.Visible = false;
                    
                }

                else if (status.ToLower() == "seller")
                {
                    listingpart.Visible = false;
                    mappart.Visible = false;
                    schedule.Visible = false;
                }
            }

            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void linkbtn_profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profile.aspx");
        }

        //protected void linkbtn_leaderboard_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("leaderboard.aspx?user=" + Session["login"].ToString());
        //}

        //protected void linkbtn_activity_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("Activity.aspx");
        //}

        //protected void linkbtn_vouchers_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("E-vouchers.aspx");
        //}

        //protected void linkbtn_logout_Click(object sender, EventArgs e)
        //{
        //    Session.Abandon();
        //    Session.Clear();
        //    Session.RemoveAll();
        //    System.Web.Security.FormsAuthentication.SignOut();
        //    Response.Write("<script>confirm('Are you sure you want to logout?'); location.href='Login.aspx';</script>");

        //}   

        protected void post_Click(object sender, EventArgs e)
        {
            string username = Session["Login"].ToString();
            Response.Redirect("Post.aspx?user=" + username);

        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Write("<script>confirm('Are you sure you want to logout?'); location.href='Login.aspx';</script>");
        }

        protected void linkquote_Click(object sender, EventArgs e)
        {
            string username = Session["Login"].ToString();
            productDAO listingdao = new productDAO();
            string status = "";
            addlist = listingdao.getuser(username);
            foreach(var i in addlist)
            {
                status = i.status;
            }

            if (status.ToLower() == "seller")
            {
                Response.Redirect("Quotation.aspx?status=seller&user=" + username);
            }

            else if (status.ToLower() == "buyer")
            {
                Response.Redirect("Quotation.aspx?status=buyer&user=" + username);
            }

        }

        protected void Linkbtn_listing_Click(object sender, EventArgs e)
        {
            string username = Session["Login"].ToString();
            Response.Redirect("SellerListing.aspx?user=" + username);
        }
    }
}