using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Our_FYPJ2019.DAL;


namespace Our_FYPJ2019.DAL
{
    public class ChatHub : Hub
    {
        
        public void Send(string name, string message)
        {        
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);

            
        }

        public int sendmsg(string name, string message)
        {
            System.Diagnostics.Debug.WriteLine("database sendmsg() activated!");
            //Storing in database
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("INSERT INTO chat (buyers, msgs)");
            strSql.AppendLine("VALUES (@pbuyer, @pmsg)");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pbuyer", name);
            sqlCmd.Parameters.AddWithValue("@pmsg", message);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }


    }
}