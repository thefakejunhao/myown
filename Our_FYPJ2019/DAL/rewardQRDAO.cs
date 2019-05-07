using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Text;

namespace MyFYPJBackup.DAL
{
    public class rewardQRDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public int insertPoint(string QRCode, string username,string ID)
        {
            int result = 0;
            string sqlStr = "UPDATE rewardPoints SET qrRecord = @QRCode, points=1 ,date = getdate() where username=@username and qrID=@ID";

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

            sqlCmd.Parameters.AddWithValue("@ID", ID);
            sqlCmd.Parameters.AddWithValue("@username", username);
            sqlCmd.Parameters.AddWithValue("@QRCode", QRCode);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }



        public int insertID(string ID,string username)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO rewardPoints(qrID,username)");
            sqlStr.AppendLine("VALUES(@paraID,@paraname)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraID", ID);
            sqlCmd.Parameters.AddWithValue("@paraname", username);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public int getPoints(string name)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("SELECT COUNT(*) from rewardPoints where username=@paraname");
            //sqlStr.AppendLine("VALUES(@paraID,@paraname)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            //sqlCmd.Parameters.AddWithValue("@paraID", ID);
            sqlCmd.Parameters.AddWithValue("@paraname", name);

            myConn.Open();
            object totalPoint = sqlCmd.ExecuteScalar();
            //result = sqlCmd.ExecuteNonQuery();

            result = Convert.ToInt16(totalPoint);

            return result; 
            

        }
       
    



    }
}