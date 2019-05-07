using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        //string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadThismonthRank();
            }

            bindTop3Alltime();
            LoadAlltimeRank();

            bindTop3Thismonth();


            linkbtn_alltime.CssClass = "linkbtn";
            Label16.Text = "All time";

            users();
        }

        //show user own rank and points
        private void users()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();

            //All time
            string queryStr = "SELECT * FROM (SELECT p.pointLeft, SUM(p.QRpoints + p.itemSoldpoints) AS Total, p.username, u.roles, u.image, p.QRpoints, p.itemSoldpoints, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM points p INNER JOIN users u ON p.username = u.username  GROUP BY u.image, u.roles, p.username, p.QRpoints, p.itemSoldpoints, p.pointLeft)as T WHERE username = '" + Session["Login"] + "' AND roles= 'Seller' ";

            SqlCommand cmd = new SqlCommand(queryStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Image4.ImageUrl = "~\\Images\\" + dr["Image"].ToString();
                lbl_name.Text = dr["username"].ToString();
                lbl_QRpts.Text = dr["Total"].ToString();
                lbl_QRrank.Text = dr["DensePowerRank"].ToString();
                Label17.Text = dr["pointLeft"].ToString();
            }
            dr.Close();

            //This month
            string queryStr2 = "SELECT * FROM (SELECT p.pointLeft, SUM(p.mQRpoints + p.mitemSoldpoints) AS mTotal, p.username, u.roles, u.image, p.mQRpoints, p.mitemSoldpoints, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.mQRpoints + p.mitemSoldpoints) DESC) AS DensePowerRank FROM points p INNER JOIN users u ON p.username = u.username  GROUP BY u.image, u.roles, p.username, p.mQRpoints, p.mitemSoldpoints, p.pointLeft)as T WHERE username = '" + Session["Login"] + "' AND roles='Seller' ";
            SqlCommand cmd2 = new SqlCommand(queryStr2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();

            if (dr2.Read())
            {
                Image5.ImageUrl = "~\\Images\\" + dr2["Image"].ToString();
                Label10.Text = dr2["username"].ToString();
                Label12.Text = dr2["mTotal"].ToString();
                Label11.Text = dr2["DensePowerRank"].ToString();
                Label13.Text = dr2["pointLeft"].ToString();
            }
            dr2.Close();

            conn.Close();
        }

        private void bindTop3Alltime()
        {
            SqlConnection conn = new SqlConnection(_connStr);

            string queryStr = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.image, u.roles, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.roles, u.image)as T WHERE DensePowerRank = '1' AND roles = 'Seller'";

            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataList1.DataSource = dt;
            DataList1.DataBind();


            string queryStr2 = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.roles, u.image, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.roles, u.image)as T WHERE DensePowerRank = '2' AND roles = 'Seller'";
            SqlCommand cmd2 = new SqlCommand(queryStr2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            DataList2.DataSource = dt2;
            DataList2.DataBind();

            string queryStr3 = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.roles, u.image, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.roles, u.image)as T WHERE DensePowerRank = '3' AND roles = 'Seller'";
            SqlCommand cmd3 = new SqlCommand(queryStr3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            DataList3.DataSource = dt3;
            DataList3.DataBind();
        }

        private void bindTop3Thismonth()
        {
            SqlConnection conn = new SqlConnection(_connStr);

            string queryStr = "SELECT * FROM(SELECT p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image, SUM(p.mQRpoints + p.mitemSoldpoints) AS mTotal, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.mQRpoints + p.mitemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image) as T WHERE DensePowerRank = '1' AND roles = 'Seller'";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataList4.DataSource = dt;
            DataList4.DataBind();


            string queryStr2 = "SELECT * FROM(SELECT p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image, SUM(p.mQRpoints + p.mitemSoldpoints) AS mTotal, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.mQRpoints + p.mitemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image) as T WHERE DensePowerRank = '2' AND roles = 'Seller'";
            SqlCommand cmd2 = new SqlCommand(queryStr2, conn);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(dr2);
            DataList5.DataSource = dt2;
            DataList5.DataBind();

            string queryStr3 = "SELECT * FROM(SELECT p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image, SUM(p.mQRpoints + p.mitemSoldpoints) AS mTotal, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.mQRpoints + p.mitemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image) as T WHERE DensePowerRank = '3' AND roles = 'Seller'";
            SqlCommand cmd3 = new SqlCommand(queryStr3, conn);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            DataTable dt3 = new DataTable();
            dt3.Load(dr3);
            DataList6.DataSource = dt3;
            DataList6.DataBind();
        }

        //gridview
        protected void LoadAlltimeRank()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            string queryStr = "SELECT * FROM(SELECT p.username, p.QRpoints, p.itemSoldpoints, u.roles, u.image, SUM(p.QRpoints + p.itemSoldpoints) AS Total, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.QRpoints + p.itemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.QRpoints, p.itemSoldpoints, u.roles, u.image) as T WHERE DensePowerRank BETWEEN 4 AND 10 AND roles= 'Seller'";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@role", "Seller");
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        //gridview
        protected void LoadThismonthRank()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            string queryStr = "SELECT * FROM(SELECT p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image, SUM(p.mQRpoints + p.mitemSoldpoints) AS mTotal, DENSE_RANK() OVER(PARTITION BY roles ORDER BY SUM(p.mQRpoints + p.mitemSoldpoints) DESC) AS DensePowerRank FROM users u INNER JOIN points p on u.username = p.username GROUP BY p.username, p.mQRpoints, p.mitemSoldpoints, u.roles, u.image) as T WHERE DensePowerRank BETWEEN 4 AND 10 AND roles = 'Seller'";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            cmd.Parameters.AddWithValue("@role", "Seller");
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_username = (Label)e.Row.FindControl("lbl_username");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.WhiteSmoke;
                    e.Row.Cells[2].Text = "Me";
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_username = (Label)e.Row.FindControl("lbl_username");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Row.BackColor = System.Drawing.Color.WhiteSmoke;
                    //e.Row.Cells[2].Text = "Me";

                    SqlConnection conn = new SqlConnection(_connStr);
                    conn.Open();

                    string queryStr = "SELECT mclaim FROM points WHERE username = '" + Session["Login"] + "' ";

                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        string mclaim = dr["mclaim"].ToString();

                        if (mclaim == "false")
                        {
                            ImageButton ib = (ImageButton)e.Row.FindControl("btn_claimpts");
                            ib.Visible = true;
                        }
                    }
                    dr.Close();
                }
            }
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Label lbl_username = (Label)e.Item.FindControl("Label3");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl_username.Text = "Me";
                }
            }
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Label lbl_username = (Label)e.Item.FindControl("Label1");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl_username.Text = "Me";
                }
            }
        }

        protected void DataList3_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Label lbl_username = (Label)e.Item.FindControl("Label5");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl_username.Text = "Me";
                }
            }
        }

        protected void DataList5_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Label lbl_username = (Label)e.Item.FindControl("Label3");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl_username.Text = "Me";
                }
            }
        }

        protected void DataList4_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Label lbl_username = (Label)e.Item.FindControl("Label1");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl_username.Text = "Me";
                }
            }
        }

        protected void DataList6_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {
                Label lbl_username = (Label)e.Item.FindControl("Label5");
                if (lbl_username.Text == Session["Login"].ToString())
                {
                    e.Item.BackColor = System.Drawing.Color.WhiteSmoke;
                    lbl_username.Text = "Me";
                }
            }
        }

        protected void linkbtn_alltime_Click(object sender, EventArgs e)
        {
            Top3alltimePanel.Visible = true;
            alltimePanel.Visible = true;
            userAlltimePanel.Visible = true;
            Label16.Text = "All time";

            Top3thismonthPanel.Visible = false;
            thismonthPanel.Visible = false;
            userThismonthPanel.Visible = false;

            linkbtn_alltime.CssClass = "linkbtn";
            linkbtn_thismonth.CssClass = "";
        }

        protected void linkbtn_thismonth_Click(object sender, EventArgs e)
        {
            Top3alltimePanel.Visible = false;
            alltimePanel.Visible = false;
            userAlltimePanel.Visible = false;

            Top3thismonthPanel.Visible = true;
            thismonthPanel.Visible = true;
            userThismonthPanel.Visible = true;
            Label16.Text = "This month";

            linkbtn_alltime.CssClass = "";
            linkbtn_thismonth.CssClass = "linkbtn";
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Activity.aspx?user=" + Session["Login"].ToString());
        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                //update points
                int result = 0;
                string username = Session["Login"].ToString();
                string queryStr3 = "UPDATE Points SET " +
                                   " pointLeft = pointLeft + 50, " +
                                   " mclaim = @mclaim " +
                                   " WHERE username='" + Session["Login"] + "'";
                SqlConnection conn3 = new SqlConnection(_connStr);
                SqlCommand cmd3 = new SqlCommand(queryStr3, conn3);
                conn3.Open();
                cmd3.Parameters.AddWithValue("@mclaim", "true");
                result = +cmd3.ExecuteNonQuery();
                if (result > 0)
                {
                    SqlConnection conn = new SqlConnection(_connStr);
                    conn.Open();
                    string queryStr = "SELECT pointLeft FROM Points WHERE username='" + Session["Login"] + "'";
                    SqlCommand cmd = new SqlCommand(queryStr, conn3);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        int balance = int.Parse(dr["pointLeft"].ToString());

                        //insert into activity table
                        string queryStr2 = "INSERT into Activity(activityName, dateTime, username, change, balance)" +
                                         "values(@activityName, @dateTime, @username, @change, @balance)";
                        SqlConnection conn2 = new SqlConnection(_connStr);
                        SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);
                        string activityName = "You have claimed 50 points for being the Top 10 recyclist this month!";
                        cmd2.Parameters.AddWithValue("@activityName", activityName);
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@dateTime", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@change", "+50");
                        cmd2.Parameters.AddWithValue("@balance", balance);
                        conn2.Open();
                        cmd2.ExecuteNonQuery();
                        conn2.Close();
                        Response.Write("<script>confirm('Are you sure you want to claim the 50 points for being the Top 10 recyclist this month?'); location.href='Leaderboard.aspx';</script>");
                    }
                    conn3.Close();
                    conn.Close();
                }
            }
        }
    }
}