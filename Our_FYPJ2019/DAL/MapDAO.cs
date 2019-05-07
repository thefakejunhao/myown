using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;


namespace Our_FYPJ2019.DAL
{
    public class MapDAO
    {
        public List<Map> getMapData(string estate, string category, string address, string postalcode, string range)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<Map> itemList = new List<Map>();

            // Step 2 :Retrieve connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();

            if (estate == null && category == "" && address == null && postalcode == null && range == null)
            {
                System.Diagnostics.Debug.WriteLine("1 nothing good");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE status = 'no'");

            }
            
            else if (estate != null && category == "" && address == null && postalcode == null && range == null)
            {
                System.Diagnostics.Debug.WriteLine("2");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE Estate = '" + estate.ToLower() + "'");
                sqlCommand.AppendLine("AND status = 'no'");

            }

            else if ((estate == null || address == null || postalcode == null) && category != "")
            {
                System.Diagnostics.Debug.WriteLine("3");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (estate != null && category != "" && address == null && postalcode == null && range == null)
            {
                System.Diagnostics.Debug.WriteLine("4");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE Estate = '" + estate.ToLower() + "'");
                sqlCommand.AppendLine("AND rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (address != null && category == "" && estate == null && postalcode == null && range == null)
            {
                System.Diagnostics.Debug.WriteLine("5");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE addr LIKE '%" + address + "%'");
                sqlCommand.AppendLine("AND status = 'no'");

            }

            else if (address != null && category != "" && estate == null && postalcode == null && range == null)
            {
                System.Diagnostics.Debug.WriteLine("6");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE addr LIKE '%" + address + "%'");
                sqlCommand.AppendLine("AND rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (postalcode != null && category == "" && range == null && address == null && estate == null)
            {
                System.Diagnostics.Debug.WriteLine("7");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE postalcode = '" + postalcode + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (postalcode != null && category != "" && range == null && address == null && estate == null)
            {
                System.Diagnostics.Debug.WriteLine("8");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE postalcode = '" + postalcode + "'");
                sqlCommand.AppendLine("AND rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (postalcode != null && category == "" && range != null && address == null && estate == null)
            {
                double intrange = Convert.ToDouble(range);
                System.Diagnostics.Debug.WriteLine("9");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE distance <= " + intrange);
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (postalcode != null && category != "" && range != null && address == null && estate == null)
            {
                double intrange = Convert.ToDouble(range);
                System.Diagnostics.Debug.WriteLine("9");
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE distance <= " + intrange);
                sqlCommand.AppendLine("AND rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "Listing");

            
            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["Listing"].Rows.Count;
            if (rec_cnt == 0)
            {
                itemList = null;
            }

            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Listing"].Rows)
                {
                    Map objList = new Map();

                    objList.PostalCode = row["postalcode"].ToString();
                    objList.unitno = row["unitno"].ToString();
                    objList.username = row["username"].ToString();
                    objList.itemname = row["itemname"].ToString();
                    objList.rtype = row["rtype"].ToString();
                    objList.address = row["addr"].ToString();
                    objList.id = Convert.ToInt32(row["itemid"]);
                    //objList.district = row["district"].ToString();
                    objList.latitude = Convert.ToDouble(row["Lat"]);
                    objList.longitude = Convert.ToDouble(row["Lng"]);
                    objList.estate = row["Estate"].ToString();
                    itemList.Add(objList);

                }
            }

            return itemList;
        }

        public List<Map> getAllListing()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<Map> itemList = new List<Map>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("SELECT * from Listing");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "Listing");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["Listing"].Rows.Count;
            if (rec_cnt == 0)
            {
                itemList = null;
            }

            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Listing"].Rows)
                {
                    Map objList = new Map();

                    objList.PostalCode = row["postalcode"].ToString();
                    objList.unitno = row["unitno"].ToString();
                    objList.username = row["username"].ToString();
                    objList.itemname = row["itemname"].ToString();
                    objList.rtype = row["rtype"].ToString();
                    objList.address = row["addr"].ToString();
                    objList.id = Convert.ToInt32(row["itemid"]);
                    //objList.district = row["district"].ToString();
                    objList.latitude = Convert.ToDouble(row["Lat"]);
                    objList.longitude = Convert.ToDouble(row["Lng"]);
                    itemList.Add(objList);

                }
            }

            return itemList;
        }

        // Update distance when User get range
        public int pushDistance(double dist, int itemid)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("update Listing");
            strSql.AppendLine("set distance = @pdist");
            strSql.AppendLine("WHERE itemid = @pitemid");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pdist", dist);
            sqlCmd.Parameters.AddWithValue("@pitemid", itemid);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }
    }
}