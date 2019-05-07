using MyFYPJBackup.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackUpProject
{
    public partial class adminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginbtn_Click(object sender, EventArgs e)
        {
            admin adObj = new admin();
            adminDAO adDAO = new adminDAO();

            adObj = adDAO.loginAdmin(usertb.Text.ToLower());


            if (adObj != null)
            {
                if (usertb.Text.Contains("admin"))
                {
                    if (adObj.adminpass == passwordtb.Text)
                    {
                        Session["NRIC"] = usertb.Text;
                        Response.Redirect("reportedUser.aspx");
                    }
                    else
                    {
                        lblError.Text = "Username/Password incorrect";

                    }
                }

            }
        }
    }
}