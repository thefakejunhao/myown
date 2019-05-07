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
using System.Text.RegularExpressions;

namespace Our_FYPJ2019
{
    public partial class mapdirection : System.Web.UI.Page
    {
        protected string destination = "";
        protected string address = "";
        protected double targetlat = 0;
        protected double targetlng = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string postalcode = Request.QueryString["postalcode"];
            string timeslot = Request.QueryString["timeslot"];
            address = getaddress(postalcode);
            lbldate.InnerText = Request.QueryString["date"];//set date
            lbladdress.Text = "<strong>Destination : </strong>" + address; //set address
            lbltimeslot.Text = "<strong>Timeslot : </strong>" + timeslot;
            destination = getLatLng(postalcode);
            targetlat = getlat(postalcode);
            targetlng = getlng(postalcode);
        }

        //get Lat and Lng
        public string getLatLng(string postalcode)
        {
            double UserLat;
            double UserLng;
            string website = "https://developers.onemap.sg/commonapi/search?searchVal=" + postalcode + "&returnGeom=Y&getAddrDetails=Y&pageNum=1";
            System.Diagnostics.Debug.WriteLine("Website is  " + website);
            var json = new WebClient().DownloadString(website);
            dynamic jsonresult = JsonConvert.DeserializeObject<dynamic>(json);
            var res = jsonresult.results;
            string latlng = "";
            foreach (var data in res)
            {
                var latvalue = data.LATITUDE;
                UserLat = Convert.ToDouble(latvalue);
                var lngvalue = data.LONGITUDE;
                UserLng = Convert.ToDouble(lngvalue);
                latlng = UserLat + "," + UserLng;
            }
            System.Diagnostics.Debug.WriteLine("latlng value is  " + latlng);
            return latlng;
        }

        public double getlat(string postalcode)
        {
            double UserLat = 0 ;
            double UserLng = 0 ;
            string website = "https://developers.onemap.sg/commonapi/search?searchVal=" + postalcode + "&returnGeom=Y&getAddrDetails=Y&pageNum=1";
            System.Diagnostics.Debug.WriteLine("Website is  " + website);
            var json = new WebClient().DownloadString(website);
            dynamic jsonresult = JsonConvert.DeserializeObject<dynamic>(json);
            var res = jsonresult.results;
            string latlng = "";
            foreach (var data in res)
            {
                var latvalue = data.LATITUDE;
                UserLat = Convert.ToDouble(latvalue);
                var lngvalue = data.LONGITUDE;
                UserLng = Convert.ToDouble(lngvalue);
                latlng = UserLat + "," + UserLng;
            }

            return UserLat;
        }

        public double getlng(string postalcode)
        {
            double UserLat = 0;
            double UserLng = 0;
            string website = "https://developers.onemap.sg/commonapi/search?searchVal=" + postalcode + "&returnGeom=Y&getAddrDetails=Y&pageNum=1";
            System.Diagnostics.Debug.WriteLine("Website is  " + website);
            var json = new WebClient().DownloadString(website);
            dynamic jsonresult = JsonConvert.DeserializeObject<dynamic>(json);
            var res = jsonresult.results;
            string latlng = "";
            foreach (var data in res)
            {
                var latvalue = data.LATITUDE;
                UserLat = Convert.ToDouble(latvalue);
                var lngvalue = data.LONGITUDE;
                UserLng = Convert.ToDouble(lngvalue);
                latlng = UserLat + "," + UserLng;
            }

            return UserLng;
        }



        //get address
        public string getaddress(string postalcode)
        {
            string address = "";
            string website = "https://developers.onemap.sg/commonapi/search?searchVal=" + postalcode + "&returnGeom=Y&getAddrDetails=Y&pageNum=1";
            var json = new WebClient().DownloadString(website);
            dynamic jsonresult = JsonConvert.DeserializeObject<dynamic>(json);
            var res = jsonresult.results;
            foreach (var data in res)
            {
                address = data.ADDRESS;
            }
            return address;
        }

        protected void btnarrive_Click(object sender, EventArgs e)
        {
            Session["timeslot"] = Request.QueryString["timeslot"];
            Session["postalcode"] = Regex.Replace(Request.QueryString["postalcode"], @"\s", ""); ;
            Session["date"] = lbldate.InnerText;
            Session["address"] = address;
            Response.Redirect("collection.aspx");
        }

    }
}