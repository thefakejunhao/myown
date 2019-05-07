using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class SellerListing : System.Web.UI.Page
    {
        protected List<Listitems> Selleritems = new List<Listitems>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Session["Login"].ToString();
            List<product> addlist = new List<product>();
            productDAO userdao = new productDAO();
            string status = "";
            addlist = userdao.getuser(user);
            foreach (var i in addlist)
            {
                status = i.status;
            }

            if (status == "Buyer")
            {
                Response.Write("<script>alert('Not Allowed to view this page');window.history.back();</script>"); //works great

            }

            string username = Request.QueryString["user"];
            ListingDAO listingdao = new ListingDAO();
            string search = tbsearch.Text;
            Selleritems = listingdao.getSellerListing(username, search);
        }


    }
}