using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //qr point
        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = Session["Login"].ToString();

            int result = 0;
            string queryStr = "UPDATE Points SET " +
                              "QRpoints = QRpoints + 5, " +
                              "mQRpoints = mQRpoints + 5, " +
                              "pointLeft = pointLeft + 5 " +
                              " WHERE username='" + Session["Login"] + "'";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            result = +cmd.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
            {
                SqlConnection conn3 = new SqlConnection(_connStr);
                conn3.Open();
                string queryStr3 = "SELECT pointLeft FROM Points WHERE username='" + Session["Login"] + "'";
                SqlCommand cmd3 = new SqlCommand(queryStr3, conn3);
                SqlDataReader dr = cmd3.ExecuteReader();

                if (dr.Read())
                {
                    int balance = int.Parse(dr["pointLeft"].ToString());

                    string queryStr2 = "INSERT into Activity(activityName, dateTime, username, change, balance)" +
                                        "values(@activityName, @dateTime, @username, @change, @balance)";
                    SqlConnection conn2 = new SqlConnection(_connStr);
                    SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);
                    cmd2.Parameters.AddWithValue("@activityName", "You have earned 5 bring your own bag point.");
                    cmd2.Parameters.AddWithValue("@username", username);
                    cmd2.Parameters.AddWithValue("@dateTime", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@change", "+5");
                    cmd2.Parameters.AddWithValue("@balance", balance);

                    conn2.Open();
                    cmd2.ExecuteNonQuery();
                    conn2.Close();
                }
                conn3.Close();
                dr.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int result = 0;
            string username = Session["Login"].ToString();
            string queryStr = "UPDATE Points SET " +
                             "itemSoldpoints = itemSoldpoints + 5, " +
                             "mitemSoldpoints = mitemSoldpoints + 5, " +
                             "pointLeft = pointLeft + 5 " +
                             " WHERE username='" + Session["Login"] + "'";
            SqlConnection conn = new SqlConnection(_connStr);
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            result = +cmd.ExecuteNonQuery();
            conn.Close();

            if (result > 0)
            {
                SqlConnection conn3 = new SqlConnection(_connStr);
                conn3.Open();
                string queryStr3 = "SELECT pointLeft FROM Points WHERE username='" + Session["Login"] + "'";
                SqlCommand cmd3 = new SqlCommand(queryStr3, conn3);
                SqlDataReader dr = cmd3.ExecuteReader();

                if (dr.Read())
                {
                    int balance = int.Parse(dr["pointLeft"].ToString());


                    string queryStr2 = "INSERT into Activity(activityName, dateTime, username, change, balance)" +
                                        "values(@activityName, @dateTime, @username, @change, @balance)";
                    SqlConnection conn2 = new SqlConnection(_connStr);
                    SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);
                    cmd2.Parameters.AddWithValue("@activityName", "You have earned 5 points for successful transaction.");
                    cmd2.Parameters.AddWithValue("@username", username);
                    cmd2.Parameters.AddWithValue("@dateTime", DateTime.Now);
                    cmd2.Parameters.AddWithValue("@change", "+5");
                    cmd2.Parameters.AddWithValue("@balance", balance);

                    conn2.Open();
                    cmd2.ExecuteNonQuery();
                    conn2.Close();
                }
                conn3.Close();
                dr.Close();
            }
        }
    }
}