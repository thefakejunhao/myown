using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Our_FYPJ2019
{
    public partial class ListingItems : System.Web.UI.Page
    {
        protected List<Listitems> itemList = new List<Listitems>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["Login"].ToString();

            //string url = Request.UrlReferrer.AbsoluteUri;
            List<product> addlist = new List<product>(); productDAO userdao = new productDAO();
            string status = "";
            addlist = userdao.getuser(username);
            foreach (var i in addlist)
            {
                status = i.status;
            }

            if (status == "Seller")
            {
                Response.Write("<script>alert('Not Allowed to view this page');window.history.back();</script>"); //works great

            }

            string locations = tblocation.Text;
            string sorts = ddlsort.SelectedItem.Text;
            string mins = tbmin.Text;
            string maxs = tbmax.Text;
            string types = ddltypes.SelectedItem.Text;
            string qtymin = tbminqty.Text;
            string qtymax = tbmaxqty.Text;
            string search = tbsearch.Text;
            string itemQuery = Request.QueryString["item"];
            ListingDAO listingdao = new ListingDAO();
            itemList = listingdao.getlisting(itemQuery, sorts, mins, maxs, locations, types, qtymin, qtymax);

        }

        protected void searchbutton_Click(object sender, EventArgs e)
        {
            string URL = Request.Url.AbsoluteUri;
            string locations = "";
            string sorts = "";
            string mins = "";
            string maxs = "";
            string types = "";
            string search = tbsearch.Text;
            string qtymin = tbminqty.Text;
            string qtymax = tbmaxqty.Text;
            ListingDAO listingdao = new ListingDAO();
            listingdao.getlisting(search, sorts, mins, maxs, locations, types, qtymin, qtymax);
            if (search != "")
            {
                Response.Redirect("ListingItems.aspx?item=" + search);
            }

            else
            {
                Response.Redirect("ListingItems.aspx");
            }
        }

        protected void setbutton_Click(object sender, EventArgs e)
        {
            //string locations = tblocation.Text;
            //string sorts = ddlsort.SelectedItem.Text;
            //string mins = tbmin.Text;
            //string maxs = tbmax.Text;
            //string types = ddltypes.SelectedItem.Text;
            //string itemQuery = Request.QueryString["item"];
            //ListingDAO listingdao = new ListingDAO();
            //listingdao.getlisting(itemQuery, sorts, mins, maxs, locations, types);
        }
    }
}