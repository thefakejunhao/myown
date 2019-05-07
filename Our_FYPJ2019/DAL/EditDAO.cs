using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Our_FYPJ2019.DAL
{
    public class EditDAO
    {
        public int edititem(int id, string date, string itemname, string rtype, string plastic,
            string paper, string metal, string batteries, string electronics, string weight, string desc, string address,
            string image1, string image2, string image3, string image4, string unitno, string postalcode, string qty, double lat, double lng)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //Query string


            //SQL command to insert data into database
            strSql.AppendLine("UPDATE Listing");
            strSql.AppendLine("set dates = @pdates, itemname = @pitemname, rtype = @prtype, " +
                "plastic = @pplastic, paper = @ppaper, metal = @pmetal, batteries = @pbatteries, electronics = @pelectronics, weights = @pweights," +
                "descriptions = @pdesc, addr = @paddr, img1 = @pimg1, img2 = @pimg2, img3 = @pimg3, img4 = @pimg4, unitno = @punitno, postalcode = @ppostalcode , quantity = @pqty, Lat = @plat, Lng = @plng");
            strSql.AppendLine("where itemid = @pid");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pdates", date);
            sqlCmd.Parameters.AddWithValue("@pitemname", itemname);
            sqlCmd.Parameters.AddWithValue("@prtype", rtype);
            sqlCmd.Parameters.AddWithValue("@pplastic", plastic);
            sqlCmd.Parameters.AddWithValue("@ppaper", paper);
            sqlCmd.Parameters.AddWithValue("@pmetal", metal);
            sqlCmd.Parameters.AddWithValue("@pbatteries", batteries);
            sqlCmd.Parameters.AddWithValue("@pelectronics", electronics);
            sqlCmd.Parameters.AddWithValue("@pweights", weight);
            sqlCmd.Parameters.AddWithValue("@pdesc", desc);
            sqlCmd.Parameters.AddWithValue("@paddr", address);
            sqlCmd.Parameters.AddWithValue("@pimg1", image1);
            sqlCmd.Parameters.AddWithValue("@pimg2", image2);
            sqlCmd.Parameters.AddWithValue("@pimg3", image3);
            sqlCmd.Parameters.AddWithValue("@pimg4", image4);
            sqlCmd.Parameters.AddWithValue("@punitno", unitno);
            sqlCmd.Parameters.AddWithValue("@ppostalcode", postalcode);
            sqlCmd.Parameters.AddWithValue("@pqty", qty);
            sqlCmd.Parameters.AddWithValue("@pid", id);
            sqlCmd.Parameters.AddWithValue("@plat", lat);
            sqlCmd.Parameters.AddWithValue("@plng", lng);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }
    }
}