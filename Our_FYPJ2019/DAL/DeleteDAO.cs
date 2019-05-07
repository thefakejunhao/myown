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
    public class DeleteDAO
    {
        public int deleteList(int id)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("Delete from Listing where itemid = @pid;");
            strSql.AppendLine("Delete from Quotation where itemid = @pid");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pid", id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }
    }
}