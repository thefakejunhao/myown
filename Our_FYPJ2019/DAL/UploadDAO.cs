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
    public class UploadDAO
    {
        //public int InsertImage(string name, string name2, string name3)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    int result = 0;

        //    //SQL command to insert data into database
        //    strSql.AppendLine("INSERT INTO tblImages (Name, name2, name3)");
        //    strSql.AppendLine("VALUES (@paramname1, @paramname2, @paramname3)");

        //    // Instantiate Sql connection instance and SqlCOmmand instance
        //    string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        //    SqlConnection myConn = new SqlConnection(DBConnect);
        //    SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

        //    sqlCmd.Parameters.AddWithValue("@paramname", name);
        //    sqlCmd.Parameters.AddWithValue("@paramname2", name2);
        //    sqlCmd.Parameters.AddWithValue("@paramname3", name3);

        //    myConn.Open();
        //    result = sqlCmd.ExecuteNonQuery();
        //    myConn.Close();

        //    return result;

        //}

        public int InsertImage(string name,string name2, string name3)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("INSERT INTO tblImages (Name, name2, name3)");
            strSql.AppendLine("VALUES (@paramname, @paramname2, @paramname3)");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paramname", name);
            sqlCmd.Parameters.AddWithValue("@paramname2", name2);
            sqlCmd.Parameters.AddWithValue("@paramname3", name3);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;

        }
    }
}