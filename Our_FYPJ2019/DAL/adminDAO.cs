using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MyFYPJBackup.DAL
{
    public class adminDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public admin loginAdmin(string adminNo)
        {
            admin adObj = new admin();

            DataSet ds = new DataSet();
            string mysql = "Select * from Admin where admin_No = @paraAdmin";
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(mysql, myConn);
            da.SelectCommand.Parameters.AddWithValue("paraAdmin", adminNo);

            da.Fill(ds, "adminTable");
            int rec_cnt = ds.Tables["adminTable"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["adminTable"].Rows[0];
                adObj.adminNo = row["admin_No"].ToString();
                adObj.adminpass = row["adminPass"].ToString();
            }
            else
            {
                adObj = null;
            }

            return adObj;
        }


        public int registerAdmin(string admin_No, string password)
        {
            int result = 0;
            string sqlStr = "INSERT INTO Admin (admin_No,adminPass) VALUES(@adminNo,@pw)";

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

            sqlCmd.Parameters.AddWithValue("@pw", password);
            sqlCmd.Parameters.AddWithValue("@adminNo", admin_No);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }


        //  public int reportUser(string id, string username )
        // {
        //    int result = 0;
        //   string sqlStr = "INSERT INTO Admin (admin_No,adminPass) VALUES(@adminNo,@pw)";

        //   SqlConnection myConn = new SqlConnection(DBConnect);
        // SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

        //   sqlCmd.Parameters.AddWithValue("@pw", password);
        //  sqlCmd.Parameters.AddWithValue("@adminNo", admin_No);

        //   myConn.Open();
        // result = sqlCmd.ExecuteNonQuery();

        //  myConn.Close();
        // return result;
        //  }



    }
}