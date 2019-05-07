using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Our_FYPJ2019.DAL;

namespace Our_FYPJ2019
{
    public partial class signalrchattest : System.Web.UI.Page
    {
        protected string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Session["Login"].ToString();
        }

        protected void sendmessage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Send message backend is clicked");
            string user = Session["Login"].ToString();
            string msg = message.Text;
            System.Diagnostics.Debug.WriteLine("User = ", user);
            System.Diagnostics.Debug.WriteLine("Message = ", msg);
            ChatHub chathubdao = new ChatHub();
            chathubdao.sendmsg(user, msg);
        }

    }
}