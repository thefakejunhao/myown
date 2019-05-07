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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //SqlConnection conn = new SqlConnection(_connStr);
                //string queryStr = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.image, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.image) as T WHERE DensePowerRank BETWEEN 4 AND 10";
                //SqlCommand cmd = new SqlCommand(queryStr, conn);
                //cmd.Parameters.AddWithValue("@role", "Seller");
                //conn.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //DataTable dt = new DataTable();
                //dt.Load(dr);
                //GridView1.DataSource = dt;
                //GridView1.DataBind();


                SqlConnection conn = new SqlConnection(_connStr);

                string queryStr = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.image, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.image)as T WHERE DensePowerRank = '1'";

                SqlCommand cmd = new SqlCommand(queryStr, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                DataList1.DataSource = dt;
                DataList1.DataBind();


                string queryStr2 = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.image, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.image)as T WHERE DensePowerRank = '2'";
                SqlCommand cmd2 = new SqlCommand(queryStr2, conn);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                DataTable dt2 = new DataTable();
                dt2.Load(dr2);
                DataList2.DataSource = dt2;
                DataList2.DataBind();

                string queryStr3 = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.image, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.image)as T WHERE DensePowerRank = '3'";
                SqlCommand cmd3 = new SqlCommand(queryStr3, conn);
                SqlDataReader dr3 = cmd3.ExecuteReader();
                DataTable dt3 = new DataTable();
                dt3.Load(dr3);
                DataList3.DataSource = dt3;
                DataList3.DataBind();
            }
        }
    }
}