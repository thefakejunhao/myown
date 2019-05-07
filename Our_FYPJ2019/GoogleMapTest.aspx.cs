using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using System.Net;

namespace Our_FYPJ2019
{
    public partial class GoogleMapTest : System.Web.UI.Page
    {
        //Get distance
        public double distance(double lat1, double lon1, double lat2, double lon2, char unit)
        {
            if ((lat1 == lat2) && (lon1 == lon2))
            {
                return 0;
            }

            else
            {
                double theta = lon1 - lon2;
                double dist = Math.Sin(deg2rad(lat1)) * Math.Sin(deg2rad(lat2)) + Math.Cos(deg2rad(lat1)) * Math.Cos(deg2rad(lat2)) * Math.Cos(deg2rad(theta));
                dist = Math.Acos(dist);
                dist = rad2deg(dist);
                dist = dist * 60 * 1.1515;
                if (unit == 'K')
                {
                    dist = dist * 1.609344;
                }
                else if (unit == 'N')
                {
                    dist = dist * 0.8684;
                }
                return (dist);
            }
        }

        public double deg2rad(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        public double rad2deg(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        protected List<Map> itemList = new List<Map>();
        protected string range;
        protected string postalcode;
        protected double UserLat;
        protected double UserLng;
        protected string start = "";
        protected string end = "";
        protected string mode = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["Login"].ToString();
            List<product> userList = new List<product>();
            productDAO userdao = new productDAO();
            string status = "";
            userList = userdao.getuser(username);
            foreach (var i in userList)
            {
                status = i.status;
            }

            if (status == "Seller")
            {
                Response.Write("<script>alert('Not Allowed to view this page');window.history.back();</script>"); //works great
            }

            MapDAO mapdao = new MapDAO();
            postalcode = Request.QueryString["postalcode"];
            string choice = ddlchoice.SelectedItem.Text;
            string estate = Request.QueryString["estate"];
            string address = Request.QueryString["address"];
            range = Request.QueryString["range"];
            string types = ddltypes.SelectedItem.Text;
            
            //Get User Lat and Lng
            if (range != null)
            {
                string website = "https://developers.onemap.sg/commonapi/search?searchVal=" + postalcode + "&returnGeom=Y&getAddrDetails=Y&pageNum=1";
                //System.Diagnostics.Debug.WriteLine("Website is  " + website);
                var json = new WebClient().DownloadString(website);
                dynamic jsonresult = JsonConvert.DeserializeObject<dynamic>(json);
                var res = jsonresult.results;

                foreach (var data in res)
                {
                    var latvalue = data.LATITUDE;
                    UserLat = Convert.ToDouble(latvalue);
                    var lngvalue = data.LONGITUDE;
                    UserLng = Convert.ToDouble(lngvalue);

                }
            }

            itemList = mapdao.getMapData(estate, types, address, postalcode, range);
            usergridview.DataSource = itemList;
            usergridview.DataBind();

        }     

        protected void usergridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            usergridview.PageIndex = e.NewPageIndex;
            usergridview.DataBind();
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            string search = tbsearch.Text;
            string choice = ddlchoice.SelectedItem.Text;

            if (choice == "Estate")
            {
                Response.Redirect("GoogleMapTest.aspx?estate=" + search);
            }

            else if (choice == "Address")
            {
                Response.Redirect("GoogleMapTest.aspx?address=" + search);
            }

            else if (choice == "Postal code")
            {
                //Get all Items in Database
                MapDAO mapdao = new MapDAO();
                List<Map> AllList = new List<Map>();
                AllList = mapdao.getAllListing();

                double range = 0; //Get user input range (convert to double)
                string rangetxt = tbrange.Text; //Convert range to string

                if (rangetxt != "")
                {
                    System.Diagnostics.Debug.WriteLine("rangetxt = " + rangetxt);
                    // Get user input and convert it to LatLng to calculate distance
                    range = Convert.ToDouble(tbrange.Text);
                    double lat = 0;
                    double lng = 0;
                    string website = "https://developers.onemap.sg/commonapi/search?searchVal=" + search + "&returnGeom=Y&getAddrDetails=Y&pageNum=1";
                    System.Diagnostics.Debug.WriteLine(website);
                    var json = new WebClient().DownloadString(website);
                    dynamic jsonresult = JsonConvert.DeserializeObject<dynamic>(json);
                    var res = jsonresult.results;

                    foreach (var data in res)
                    {
                        var latvalue = data.LATITUDE;
                        lat = Convert.ToDouble(latvalue);

                        var lngvalue = data.LONGITUDE;
                        lng = Convert.ToDouble(lngvalue);


                    }

                    foreach (var item in AllList)
                    {
                        double dist = distance(lat, lng, item.latitude, item.longitude, 'K');
                        System.Diagnostics.Debug.WriteLine("Distance of " + item.id + " is " + dist);
                        System.Diagnostics.Debug.WriteLine("Lat Lng of " + item.id + " are " + item.latitude, item.longitude);
                        System.Diagnostics.Debug.WriteLine("Followed By");
                        System.Diagnostics.Debug.WriteLine("distance : " + dist + " is <= " + range + " for itemid : " + item.id);
                        mapdao.pushDistance(dist, item.id);

                    }
                    Response.Redirect("GoogleMapTest.aspx?postalcode=" + search + "&range=" + rangetxt);
                    System.Diagnostics.Debug.WriteLine("**************END**********************");
                }

                else
                {
                    Response.Redirect("GoogleMapTest.aspx?postalcode=" + search);
                }
            }

        }

        protected void usergridview_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = usergridview.SelectedRow;
            Session["id"] = row.Cells[1].Text;
            Session["username"] = row.Cells[2].Text;
            Session["itemname"] = row.Cells[3].Text;
            Session["rtype"] = row.Cells[4].Text;

            Response.Redirect("Product.aspx?user=" + Session["username"] + "&id=" + Session["id"] + "&type=" + Session["rtype"] + "&item=" + Session["itemname"]);

        }
    }
}