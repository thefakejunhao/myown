using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace Our_FYPJ2019.DAL
{

    public class dashboardDAO
    {
        public List<dashboard> getpiechart(string username, string startdate, string enddate)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<dashboard> itemList = new List<dashboard>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("select count(*) as noofitem, category from Quotation where seller = '" + username + "' AND date BETWEEN '" + startdate + "' AND '" + enddate + "' group by category");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "Quotation");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["Quotation"].Rows.Count;
            if (rec_cnt == 0)
            {
                itemList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Quotation"].Rows)
                {
                    dashboard objList = new dashboard();
                    objList.noofitem = Convert.ToInt32(row["noofitem"]);
                    objList.category = row["category"].ToString();
                    
                    itemList.Add(objList);
                }
            }

            return itemList;
        }
    }
}