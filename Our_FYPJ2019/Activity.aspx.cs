using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class Activity : System.Web.UI.Page
    {
        //string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            bindActivity();
        }

        private void bindActivity()
        {
            SqlConnection conn = new SqlConnection(_connStr);

            string queryStr = "SELECT activityName, change, balance, dateTime FROM activity a INNER JOIN Users u on a.username = u.username WHERE a.username = '" + Session["Login"] + "' ORDER BY dateTime desc";

            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}