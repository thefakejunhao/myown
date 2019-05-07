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
using System.Web.Services;
using Newtonsoft.Json;
using System.Net;


namespace Our_FYPJ2019
{
    public partial class Post : System.Web.UI.Page
    {
        protected List<Listitems> addlist = new List<Listitems>();
        protected string address;
        protected string postalcode;
        protected string unitno;
        protected string username;
    
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack) {
                
                ddltypes.Items[0].Attributes["disabled"] = "disabled";
                ddlplastic.Items[0].Attributes["disabled"] = "disabled";
                ddlelectronics.Items[0].Attributes["disabled"] = "disabled";
                ddlbatteries.Items[0].Attributes["disabled"] = "disabled";
                ddlmetal.Items[0].Attributes["disabled"] = "disabled";
                ddlpaper.Items[0].Attributes["disabled"] = "disabled";
                username = Request.QueryString["user"];
                ListingDAO listingdao = new ListingDAO();
                addlist = listingdao.getadd(username);
                if (addlist != null)
                {
                    foreach (var item in addlist)
                    {
                        tbaddress.Text = item.address;
                        tbpc.Text = item.postalcode;
                        tbunitnum.Text = item.unitno;
                        postalcode = item.postalcode;

                    }
                }

                FillDropDownList();
                FillDropDownPlastic();
                FillDropDownPaper();
                FillDropDownMetal();
                FillDropDownBatteries();
                FillDropDownElectronics();
            }

        }

        public void FillDropDownList()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            SqlDataAdapter myda = new SqlDataAdapter("select distinct name from adminEdit ", DBConnect);
            myda.Fill(ds);
            ddltypes.DataSource = ds;
            ddltypes.DataValueField = "name";
            ddltypes.DataBind();
            ddltypes.Items.Insert(0, new ListItem("", "0"));
        }


        public void FillDropDownPlastic()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            SqlDataAdapter myda = new SqlDataAdapter("select distinct rtype from adminEdit where name='Plastics'", DBConnect);
            myda.Fill(ds);
            ddlplastic.DataSource = ds;
            ddlplastic.DataValueField = "rtype";
            ddlplastic.DataBind();
            ddlplastic.Items.Insert(0, new ListItem("", "0"));
        }


        public void FillDropDownPaper()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            SqlDataAdapter myda = new SqlDataAdapter("select distinct rtype from adminEdit where name='Paper'", DBConnect);
            myda.Fill(ds);
            ddlpaper.DataSource = ds;
            ddlpaper.DataValueField = "rtype";
            ddlpaper.DataBind();
            ddlpaper.Items.Insert(0, new ListItem("", "0"));
        }


        public void FillDropDownMetal()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            SqlDataAdapter myda = new SqlDataAdapter("select distinct rtype from adminEdit where name='Metals'", DBConnect);
            myda.Fill(ds);
            ddlmetal.DataSource = ds;
            ddlmetal.DataValueField = "rtype";
            ddlmetal.DataBind();
            ddlmetal.Items.Insert(0, new ListItem("", "0"));
        }

        public void FillDropDownBatteries()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            SqlDataAdapter myda = new SqlDataAdapter("select distinct rtype from adminEdit where name='Batteries/Bulbs'", DBConnect);
            myda.Fill(ds);
            ddlbatteries.DataSource = ds;
            ddlbatteries.DataValueField = "rtype";
            ddlbatteries.DataBind();
            ddlbatteries.Items.Insert(0, new ListItem("", "0"));
        }


        public void FillDropDownElectronics()
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            DataSet ds = new DataSet();
            SqlDataAdapter myda = new SqlDataAdapter("select distinct rtype from adminEdit where name='Electronics'", DBConnect);
            myda.Fill(ds);
            ddlelectronics.DataSource = ds;
            ddlelectronics.DataValueField = "rtype";
            ddlelectronics.DataBind();
            ddlelectronics.Items.Insert(0, new ListItem("", "0"));
        }


        string SaveFile(HttpPostedFile file)
        {
            string savePath = "../Images/";
            string filename = Path.GetFileNameWithoutExtension(file.FileName);
            string ext = Path.GetExtension(file.FileName);
            savePath += filename + DateTime.Now.ToString("ddmmyyyyfffffff") + ext;
            string fullPath = Path.Combine(Server.MapPath("~/Images"), savePath);
            file.SaveAs(fullPath);
            return savePath;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            postDAO uploadDao = new postDAO();
            ListingDAO listingdao = new ListingDAO();
            List<Listitems> mapList = new List<Listitems>();
            List<Listitems> estateList = new List<Listitems>();

            string date = DateTime.Now.ToString("dd MMMM yyyy, hh:mm tt");
            
            string item = tbitem.Text;
            string rtype = ddltypes.SelectedItem.Text;
            string weight = tbweight.Text;
            string qty = tbqty.Text;
            string desc = tadesc.InnerText;
            string add = tbaddress.Text;
            string user = Request.QueryString["user"];
            string unitno = tbunitnum.Text;
            string postalcode = tbpc.Text;
            string pc = postalcode.Substring(0, 2);
            string district = "";
            double lat = 0;
            double lng = 0;
            string estate = "";
            estateList = listingdao.getestates(pc);

            foreach (var i in estateList)
            {
                estate = i.estate;
            }
            
            //Count number of same address
            mapList = listingdao.getmapitems(postalcode);
            int count = 0;
            var min = .999999;
            var max = 1.000001;
            Random random = new Random();
            int num = random.Next(0,2);
            double randnum = num * (max - min) + min;

            string website = "https://developers.onemap.sg/commonapi/search?searchVal=" + postalcode + "&returnGeom=Y&getAddrDetails=Y&pageNum=1";
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
            
            if (mapList != null)
            {
                foreach (var mark in mapList)
                {
                    count += 1;
                    randnum += 0.0000001;
                }

                lat = lat * randnum;
                lng = lng * randnum;

            }
            
            //Plastics
            string ptype = ddlplastic.SelectedItem.Text;
            string paper = ddlpaper.SelectedItem.Text;
            string metal = ddlmetal.SelectedItem.Text;
            string batt = ddlbatteries.SelectedItem.Text;
            string elec = ddlelectronics.SelectedItem.Text;
            string[] images = new string[4];
                      
            if (imgUpload.HasFiles && imgUpload.PostedFiles.Count == 4)
            {
                // Image
                HttpFileCollection uploadedFiles = Request.Files;
                for (int i = 0; i < uploadedFiles.Count; i++)
                {
                    HttpPostedFile userPostedFile = uploadedFiles[i];
                    images[i] = SaveFile(userPostedFile);

                }

                //district
                if (pc == "01" || pc == "02" || pc == "03" || pc == "04" || pc == "05" || pc == "06")
                {
                    district = "01";
                }

                else if (pc == "07" || pc == "08" )
                {
                    district = "02";
                }

                else if (pc == "14" || pc == "15" || pc == "16")
                {
                    district = "03";
                }

                else if (pc == "09" || pc == "10" )
                {
                    district = "04";
                }

                else if (pc == "11" || pc == "12" || pc == "13")
                {
                    district = "05";
                }

                else if (pc == "17")
                {
                    district = "06";
                }

                else if (pc == "18" || pc == "19")
                {
                    district = "07";
                }

                else if (pc == "20" || pc == "21")
                {
                    district = "08";
                }

                else if (pc == "22" || pc == "23")
                {
                    district = "09";
                }

                else if (pc == "24" || pc == "25" || pc == "26" || pc == "27")
                {
                    district = "10";
                }

                else if (pc == "28" || pc == "29" || pc == "30")
                {
                    district = "11";
                }

                else if (pc == "31" || pc == "32" || pc == "33")
                {
                    district = "12";
                }

                else if (pc == "34" || pc == "35" || pc == "36" || pc == "37")
                {
                    district = "13";
                }

                else if (pc == "38" || pc == "39" || pc == "40" || pc == "41")
                {
                    district = "14";
                }

                else if (pc == "42" || pc == "43" || pc == "44" || pc == "45")
                {
                    district = "15";
                }

                else if (pc == "46" || pc == "47" || pc == "48")
                {
                    district = "16";
                }

                else if (pc == "49" || pc == "50" || pc == "81")
                {
                    district = "17";
                }

                else if (pc == "51" || pc == "52")
                {
                    district = "18";
                }

                else if (pc == "53" || pc == "54" || pc == "55" || pc == "82")
                {
                    district = "19";
                }

                else if (pc == "56" || pc == "57")
                {
                    district = "20";
                }

                else if (pc == "58" || pc == "59")
                {
                    district = "21";
                }

                else if (pc == "60" || pc == "61" || pc == "62" || pc == "63" || pc == "64")
                {
                    district = "22";
                }

                else if (pc == "65" || pc == "66" || pc == "67" || pc == "68")
                {
                    district = "23";
                }

                else if (pc == "69" || pc == "70" || pc == "71")
                {
                    district = "24";
                }

                else if (pc == "72" || pc == "73")
                {
                    district = "25";
                }

                else if (pc == "77" || pc == "78")
                {
                    district = "26";
                }

                else if (pc == "75" || pc == "76")
                {
                    district = "27";
                }

                else if (pc == "79" || pc == "80")
                {
                    district = "28";
                }

                uploadDao.listitem(user, date, item, rtype, ptype, paper, metal, batt, 
                    elec, weight, desc, add, images[0], images[1], images[2], images[3], unitno, postalcode, qty, district, lat, lng, estate);
                Response.Redirect("SellerListing.aspx?user=" + user);
            }

            else if (imgUpload.HasFiles && imgUpload.PostedFiles.Count != 4)
            {
                lblimg.Text = "Please upload 4 images";
            }

        }
    }
}