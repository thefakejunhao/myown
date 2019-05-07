using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class Dashboard : System.Web.UI.Page
    { 
        protected string[] pclabel;
        protected int[] pcdata;
        protected void Page_Load(object sender, EventArgs e)
        {
            dashboardDAO dashboarddao = new dashboardDAO();
            List<dashboard> piechartList = new List<dashboard>();
            DateTime now = DateTime.Now;
            var startDate2 = new DateTime(now.Year, now.Month, 1);
            string startDate = new DateTime(now.Year, now.Month, 1).ToString("dd MMMM yyyy"); //get startdate
            System.Diagnostics.Debug.WriteLine("startdate = ", startDate);
            string endDate = startDate2.AddMonths(1).AddDays(-1).ToString("dd MMMM yyyy"); //get enddate
            System.Diagnostics.Debug.WriteLine("endDate =", endDate);
            string username = Session["Login"].ToString();
            piechartList = dashboarddao.getpiechart(username, startDate, endDate); 
            if (piechartList != null)
            {
                foreach (var i in piechartList)
                {
                    pclabel = new string[] { i.category }; //initilizing of category
                    pcdata = new int[] { i.noofitem };
                }

                for (int i = 0 ; i < pclabel.Length; i++) 
                {
                    System.Diagnostics.Debug.WriteLine("category = ", pclabel[i]);
                    System.Diagnostics.Debug.WriteLine("data = ", pcdata[i]);

                }

                if (pclabel.Length != 0)
                {
                    System.Diagnostics.Debug.WriteLine(" pclabel is not empty ");
                }
            }

            else
            {
                pclabel = new string[] { "nothing" }; //initilizing of category
                pcdata = new int[] { 0 };
            }
            



        }
    }
}