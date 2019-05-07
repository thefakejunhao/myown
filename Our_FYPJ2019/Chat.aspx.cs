using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;


namespace Our_FYPJ2019
{
    public partial class Chat : System.Web.UI.Page
    {
        protected string itemid;
        protected string buyer;
        protected string seller;
        protected string date;
        protected string time;
        protected string item;
        protected string msg;
        
        protected List<product> itemList = new List<product>();
        protected List<product> chatList = new List<product>();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                itemid = Request.QueryString["itemid"];
                buyer = Request.QueryString["buyer"];
                seller = Request.QueryString["seller"];
                item = Request.QueryString["item"];
                time = DateTime.Now.ToString("HH:mm:ss");
                date = DateTime.Today.ToString("dd-MM-yyyy");

                productDAO productdao = new productDAO();
                string id = Request.QueryString["itemid"];
                int id2 = Convert.ToInt32(id);
                itemList = productdao.getproduct(id2);
                chatList = productdao.getchat(Convert.ToInt32(itemid), item, buyer, seller);
                

            
        }

        [WebMethod]
        public static string receivemsg(string chatmsg, string buyer, string seller, string date, string time, string item, string itemid)
        {
            string message = chatmsg;
            productDAO productdao = new productDAO();
            int result = productdao.push(buyer, chatmsg, Convert.ToInt32(itemid), seller, time, date, item);
            if (result == 0)
            {
                System.Diagnostics.Debug.WriteLine("not sent in");
            }

            else
            {
                System.Diagnostics.Debug.WriteLine("sent in");
            }
            return message;
        }

        //[WebMethod()]
        //protected void sendmessage_Click(object sender, EventArgs e)
        //{

        //    itemid = Request.QueryString["itemid"];
        //    buyer = Request.QueryString["buyer"];
        //    seller = Request.QueryString["seller"];
        //    item = Request.QueryString["item"];
        //    time = DateTime.Now.ToString("HH:mm:ss");
        //    date = DateTime.Today.ToString("dd-MM-yyyy");
        //    productDAO productdao = new productDAO();

        //    productdao.push(buyer, chatmsg, Convert.ToInt32(itemid), seller, time, date, item);
        //}

        
    }
}