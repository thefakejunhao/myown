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
using Our_FYPJ2019.DAL;
using Newtonsoft.Json;
using System.Net;

namespace Our_FYPJ2019
{
    public partial class Edit : System.Web.UI.Page
    {
        protected List<product> itemList = new List<product>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddltypes.Items[0].Attributes["disabled"] = "disabled";
                ddlplastic.Items[0].Attributes["disabled"] = "disabled";
                ddlelectronics.Items[0].Attributes["disabled"] = "disabled";
                ddlbatteries.Items[0].Attributes["disabled"] = "disabled";
                ddlmetal.Items[0].Attributes["disabled"] = "disabled";
                ddlpaper.Items[0].Attributes["disabled"] = "disabled";

                productDAO productdao = new productDAO();
                string id = Request.QueryString["id"];
                int id2 = Convert.ToInt32(id);
                itemList = productdao.getproduct(id2);

                foreach (var item in itemList)
                {
                    tbitem.Text = item.itemname;
                    ddltypes.Items.FindByText(item.rtype).Selected = true;
                    if (item.plastic != "")
                    {
                        ddlplastic.Items.FindByText(item.plastic).Selected = true;
                    }

                    else
                    {
                        ddlplastic.Items.FindByText("").Selected = true;
                    }

                    if (item.paper != "")
                    {
                        ddlpaper.Items.FindByText(item.paper.ToLower()).Selected = true;
                    }

                    else
                    {
                        ddlpaper.Items.FindByText("").Selected = true;
                    }

                    if (item.metal != "")
                    {
                        ddlmetal.Items.FindByText(item.metal).Selected = true;
                    }

                    else
                    {
                        ddlmetal.Items.FindByText("").Selected = true;
                    }

                    if (item.electronics != "")
                    {
                        ddlelectronics.Items.FindByText(item.electronics).Selected = true;
                    }

                    else
                    {
                        ddlelectronics.Items.FindByText("").Selected = true;
                    }

                    if (item.batteries != "")
                    {
                        ddlbatteries.Items.FindByText(item.batteries).Selected = true;
                    }

                    else
                    {
                        ddlbatteries.Items.FindByText("").Selected = true;
                    }

                    if (item.rtype != "Plastics" )
                    {
                        tbweight.Text = item.weight;
                    }
                    
                    else
                    {
                        tbqty.Text = item.qty;
                    }
                    tadesc.InnerText = item.desc;
                    tbaddress.Text = item.address;
                    tbpc.Text = item.postalcode;
                    tbunitnum.Text = item.unitno;
                    ddlestate.Items.FindByText(item.estate).Selected = true;
                }
            }
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
            EditDAO editDAO = new EditDAO();
            string date = DateTime.Now.ToString("dd MMMM yyyy, hh:mm tt");

            string item = tbitem.Text;
            string rtype = ddltypes.SelectedItem.Text;
            string weight = tbweight.Text;
            string desc = tadesc.InnerText;
            string add = tbaddress.Text;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string unitno = tbunitnum.Text;
            string postalcode = tbpc.Text;
            string qty = tbqty.Text;
            string user = Request.QueryString["user"];
            double lat = 0;
            double lng = 0;

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

            //Plastics
            string ptype = ddlplastic.SelectedItem.Text;

            //others
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
                    System.Diagnostics.Debug.WriteLine(images[i]);

                }

               

                editDAO.edititem(id,date, item, rtype, ptype, paper, metal, batt,
                    elec, weight, desc, add, images[0], images[1], images[2], images[3], unitno, postalcode, qty, lat, lng);
                Response.Redirect("SellerListing.aspx?user=" + user);
            }

            else if (imgUpload.HasFiles && imgUpload.PostedFiles.Count != 4)
            {
                lblimg.Text = "Maximum of 4 Images are Allowed";
            }

        }
    }
}