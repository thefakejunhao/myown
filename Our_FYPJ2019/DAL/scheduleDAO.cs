using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Our_FYPJ2019.DAL
{
    public class scheduleDAO
    {

        //Show number of Scheduled timeslots for each dates
        public List<schedule> getnumbers(string username)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT collectiondate, count(*) as num FROM Quotation WHERE buyer = '" + username + "'AND status = 'yes' AND collected = 'no' GROUP BY collectiondate");

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
                    schedule objList = new schedule();
                    objList.date = row["collectiondate"].ToString();
                    objList.num = row["num"].ToString();

                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        //get past items that are not rescheduled
        public List<schedule> notreschedule(string username)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT collectiondate, count(*) as num FROM Quotation WHERE buyer = '" + username + "'AND status = 'yes' " +
                "AND collected = 'no' AND convert(datetime, collectiondate, 101) < convert(datetime, getdate(), 101) GROUP BY collectiondate");
    
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
                    schedule objList = new schedule();
                    objList.date = row["collectiondate"].ToString();
                    objList.num = row["num"].ToString();

                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        //Display Estates and number of scheduled timeslot for each estate for each particular date
        public List<schedule> getothers(string username, string date)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            // from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            //sqlCommand.AppendLine("SELECT collectiontime, estate, count(*) as num FROM Quotation");
            //sqlCommand.AppendLine("WHERE status = 'yes' AND buyer = '" + username + "' AND collectiondate = '" + date + "' GROUP BY collectiontime, estate");
            sqlCommand.AppendLine("SELECT collectiontime, estate, count(*) as num FROM Quotation");
            sqlCommand.AppendLine("WHERE status = 'yes' AND buyer = '" + username + "' AND collectiondate = '" + date + "' GROUP BY collectiontime, estate");

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
                    schedule objList = new schedule();
                    objList.estate = row["estate"].ToString();
                    //objList.collectiondate = row["collectiondate"].ToString();
                    objList.timeslot = row["collectiontime"].ToString();
                    objList.num = row["num"].ToString();

                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        //Set suggested dates and timeslot for user
        public List<schedule> getsuggestion(string username, string estate, string currentdate)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select TOP 1 collectiondate, collectiontime, count(*) as num from Quotation");
            sqlCommand.AppendLine("where buyer = '" + username + "' AND status = 'yes' and estate = '" + estate + "' AND convert(datetime, collectiondate, 101) > convert(datetime, getdate(), 101) AND collected = 'no' GROUP by collectiondate, collectiontime order by num DESC");

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
                    schedule objList = new schedule();
                    //objList.estate = row["estate"].ToString();
                    objList.collectiondate = row["collectiondate"].ToString();
                    objList.timeslot = row["collectiontime"].ToString();
                    objList.num = row["num"].ToString();

                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        //Display the number of schedules in each date 
        public List<schedule> getscheduleList(string username)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT collectiondate, estate, count(*) as num FROM Quotation " +
                "WHERE buyer = '" + username + "'AND status = 'yes' AND collected = 'no' GROUP BY collectiondate, estate");

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
                    schedule objList = new schedule();
                    objList.date = row["collectiondate"].ToString();
                    objList.estate = row["estate"].ToString();
                    objList.num = row["num"].ToString();

                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        //Display the number of schedules in each date 
        public List<schedule> gettableno(string username, string date)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * FROM Quotation WHERE buyer = '" + username + "'AND status = 'yes' AND collectiondate = '" + date + "' AND collected = 'no' ORDER BY estate, unitno ASC ");

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
                    schedule objList = new schedule();
                    objList.date = row["collectiondate"].ToString();
                    objList.timeslot = row["collectiontime"].ToString();
                    objList.estate = row["estate"].ToString();
                    objList.price = row["price"].ToString();
                    objList.address = row["address"].ToString();
                    objList.unitno = row["unitno"].ToString();
                    objList.postalcode = row["postalcode"].ToString();
                    objList.itemname = row["item"].ToString();
                    objList.img = row["coverimg"].ToString();
                    objList.quoteid = row["quoteid"].ToString();

                    itemList.Add(objList);
                }
            }

            return itemList;
        }

        public List<schedule> gettableyes(string username, string date)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //from TDRate table where the rate is current

            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * FROM Quotation WHERE buyer = '" + username + "'AND status = 'yes' AND collectiondate = '" + date + "' " +
                "AND collected = 'yes' ORDER BY estate, unitno ASC ");

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
                    schedule objList = new schedule();
                    objList.date = row["collectiondate"].ToString();
                    objList.timeslot = row["collectiontime"].ToString();
                    objList.estate = row["estate"].ToString();
                    objList.price = row["price"].ToString();
                    objList.address = row["address"].ToString();
                    objList.unitno = row["unitno"].ToString();
                    objList.postalcode = row["postalcode"].ToString();
                    objList.itemname = row["item"].ToString();
                    objList.img = row["coverimg"].ToString();

                    itemList.Add(objList);
                }
            }

            return itemList;
        }

        public int updatecollect(int quoteid)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("UPDATE Quotation set collected = 'yes' where quoteid = @pquoteid");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pquoteid", quoteid);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public int updatetiming(int quoteid, string desc, string date, string timeslot, string currentdate)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("UPDATE Quotation set status = 'no', description = @pdesc, collectiondate = @pcdate, collectiontime = @pctime, date = @pdate," +
                "offer='no',bresponse = 'no', sresponse = 'no' where quoteid = @pquoteid");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pdesc", desc);
            sqlCmd.Parameters.AddWithValue("@pcdate", date);
            sqlCmd.Parameters.AddWithValue("@pctime", timeslot);
            sqlCmd.Parameters.AddWithValue("@pquoteid", quoteid);
            sqlCmd.Parameters.AddWithValue("@pdate", currentdate);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public List<schedule> collectiontimeslot(string username, string date)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine(" select collectiontime, postalcode, count(*) as num from Quotation where collectiondate = '" + date + "' " +
                "AND buyer = '" + username + "' AND collected = 'no' group by collectiontime, postalcode");

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
                    schedule objList = new schedule();
                    objList.timeslot = row["collectiontime"].ToString();
                    objList.postalcode = row["postalcode"].ToString();
                    objList.num = row["num"].ToString();

                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        public List<schedule> uncollectedlist(string username, string date, string timeslot, string postalcode)
        {

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<schedule> itemList = new List<schedule>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("select * from Quotation where buyer = '" + username + "'AND collectiondate = '" + date + "' AND collectiontime = '" + timeslot + "'" +
                "AND postalcode = '" + postalcode + "' AND collected = 'no' order by unitno ASC ");

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
                    schedule objList = new schedule();
                    objList.seller = row["seller"].ToString();
                    objList.quoteid = row["quoteid"].ToString();
                    objList.price = row["price"].ToString();
                    objList.img1 = row["coverimg"].ToString();
                    objList.img2 = row["img2"].ToString();
                    objList.img3 = row["img3"].ToString();
                    objList.img4 = row["img4"].ToString();
                    objList.itemname = row["item"].ToString();
                    objList.unitno = row["unitno"].ToString();
                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        

    }

}