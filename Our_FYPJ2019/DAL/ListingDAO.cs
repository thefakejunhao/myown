using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;


namespace Our_FYPJ2019.DAL
{
    public class ListingDAO
    {
        public List<Listitems> getlisting(string item, string sort, string min, string max, string location, string category, string qtymin, string qtymax)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<Listitems> itemList = new List<Listitems>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            
            
            if (item == null && sort == "" && min == "" && max == "" && location == "" && category == "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE status = 'no'");
            }

            else if (item != null && sort == "" && min == "" && max == "" && location == "" && category == "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item == null && sort != "" && min == "" && max == "" && location == "" && category == "" && qtymin == "" && qtymax == "")
            {
                if (sort == "Recent")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("ORder by dates DESC");
                }

                else if (sort == "Weight : Heaviest") {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("ORder by weights DESC");
                    
                }
                else if (sort == "Weight : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("ORder by weights ASC");
                }

                else if (sort == "Quantity : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity ASC");
                }

                else if (sort == "Quantity : Highest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity DESC");
                }

            }

            else if (item == null && sort == "" && min != "" && max != "" && location == "" && category == "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE weights BETWEEN " + min + "AND " + max);
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item == null && sort == "" && min == "" && max == "" && location != "" && category == "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE Estate LIKE '%" + location.ToLower() + "%'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item == null && sort == "" && min == "" && max == "" && location == "" && category != "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item == null && sort == "" && min == "" && max == "" && location == "" && category == "" && qtymin != "" && qtymax != "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE quantity BETWEEN " + qtymin + "AND " + qtymax);
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item != null && sort != "" && min == "" && max == "" && location == "" && category == "" && qtymin == "" && qtymax == "")
            {
                if (sort == "Recent")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by dates DESC");

                }

                else if (sort == "Weight : Heaviest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights DESC");
                }
                else if (sort == "Weight : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights ASC");
                }

                else if (sort == "Quantity : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity ASC");
                }

                else if (sort == "Quantity : Highest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity DESC");
                }

            }

            else if (item != null && sort == "" && min != "" && max != "" && location == "" && category == "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                sqlCommand.AppendLine("AND weights BETWEEN " + min + "AND " + max);
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item != null && sort == "" && min == "" && max == "" && location != "" && category == "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                sqlCommand.AppendLine("AND  Estate LIKE '%" + location.ToLower() + "%'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item != null && sort == "" && min == "" && max == "" && location == "" && category != "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                sqlCommand.AppendLine("AND rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item != null && sort == "" && min == "" && max == "" && location == "" && category == "" && qtymin != "" && qtymax != "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE itemname LIKE '%" + item + "%'");
                sqlCommand.AppendLine("AND quantity BETWEEN " + qtymin + "AND " + qtymax);
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item == null && sort != "" && min != "" && max != "" && location == "" && category == "" && qtymin == "" && qtymax == "")
            {
                if (sort == "Recent")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE weights BETWEEN " + min + "AND " + max);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by dates DESC");

                }

                else if (sort == "Weight : Heaviest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE weights BETWEEN " + min + "AND " + max);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights DESC");
                }
                else if (sort == "Weight : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE weights BETWEEN " + min + "AND " + max);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights ASC");
                }

                else if (sort == "Quantity : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE Quantity BETWEEN " + min + "AND " + max);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity ASC");
                }

                else if (sort == "Quantity : Highest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE Quantity BETWEEN " + min + "AND " + max);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity DESC");
                }

            }

            else if (item == null && sort != "" && min == "" && max == "" && location != "" && category == "" && qtymin == "" && qtymax == "")
            {
                if (sort == "Recent")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("AND Estate LIKE '%" + location.ToLower() + "%'");
                    sqlCommand.AppendLine("ORder by dates DESC");
                }

                else if (sort == "Weight : Heaviest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("AND Estate LIKE '%" + location.ToLower() + "%'");
                    sqlCommand.AppendLine("ORder by weights DESC");

                }

                else if (sort == "Weight : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("AND Estate LIKE '%" + location.ToLower() + "%'");
                    sqlCommand.AppendLine("ORder by weights ASC");
                }

                else if (sort == "Quantity : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("AND Estate LIKE '%" + location.ToLower() + "%'");
                    sqlCommand.AppendLine("ORder by quantity ASC");
                }

                else if (sort == "Quantity : Highest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE status = 'no'");
                    sqlCommand.AppendLine("AND  Estate LIKE '%" + location.ToLower() + "%'");
                    sqlCommand.AppendLine("ORder by quantity DESC");
                }
            }

            else if (item == null && sort != "" && min == "" && max == "" && location == "" && category != "" && qtymin == "" && qtymax == "")
            {
                if (sort == "Recent")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE rtype = " + "'" + category + "'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by dates DESC");

                }

                else if (sort == "Weight : Heaviest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE rtype = " + "'" + category + "'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights DESC");
                }
                else if (sort == "Weight : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE rtype = " + "'" + category + "'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights ASC");
                }

                else if (sort == "Quantity : Highest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE rtype = " + "'" + category + "'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity DESC");
                }
                else if (sort == "Quantity : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE rtype = " + "'" + category + "'");
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity ASC");
                }

            }

            else if (item == null && sort != "" && min == "" && max == "" && location == "" && category == "" && qtymin != "" && qtymax != "")
            {
                if (sort == "Recent")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE quantity BETWEEN " + qtymin + "AND " + qtymax);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by dates DESC");

                }

                else if (sort == "Weight : Heaviest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE quantity BETWEEN " + qtymin + "AND " + qtymax);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights DESC");
                }
                else if (sort == "Weight : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE quantity BETWEEN " + qtymin + "AND " + qtymax);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by weights ASC");
                }

                else if (sort == "Quantity : Highest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE quantity BETWEEN " + qtymin + "AND " + qtymax);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity DESC");
                }
                else if (sort == "Quantity : Lowest")
                {
                    sqlCommand.AppendLine("SELECT * from Listing");
                    sqlCommand.AppendLine("WHERE quantity BETWEEN " + qtymin + "AND " + qtymax);
                    sqlCommand.AppendLine("AND status = 'no'");
                    sqlCommand.AppendLine("ORder by quantity ASC");
                }

            }

            else if (item == null && sort == "" && min != "" && max != "" && location != "" && category == "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE  Estate LIKE '%" + location.ToLower() + "%'");
                sqlCommand.AppendLine("AND status = 'no'");
                sqlCommand.AppendLine("AND weights BETWEEN " + min + "AND " + max);
            }

            else if (item == null && sort == "" && min != "" && max != "" && location == "" && category != "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE weights BETWEEN " + min + "AND " + max);
                sqlCommand.AppendLine("AND rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item == null && sort == "" && min == "" && max == "" && location != "" && category != "" && qtymin == "" && qtymax == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE  Estate LIKE '%" + location.ToLower() + "%'");
                sqlCommand.AppendLine("AND rtype = " + "'" + category + "'");
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else if (item == null && sort == "" && min == "" && max == "" && location == "" && category != "" && qtymin != "" && qtymax != "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("WHERE quantity BETWEEN " + qtymin + "AND " + qtymax);
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
                    Listitems objList = new Listitems();
                    objList.itemid = Convert.ToInt32(row["itemid"]);
                    objList.itemname = row["itemname"].ToString();
                    objList.weight = row["weights"].ToString();
                    objList.image1 = row["img1"].ToString();
                    objList.rtype = row["rtype"].ToString();
                    objList.desc = row["descriptions"].ToString();
                    objList.date = row["dates"].ToString();
                    objList.username = row["username"].ToString();
                    objList.qty = row["quantity"].ToString();
                    
                    itemList.Add(objList);
                }
            }


            return itemList;
        }

        public List<Listitems> getSellerListing(string user, string searchitem)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<Listitems> Selleritems = new List<Listitems>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            if (searchitem == "")
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("where username = '" + user + "'" );
                sqlCommand.AppendLine("AND status = 'no'");
            }

            else
            {
                sqlCommand.AppendLine("SELECT * from Listing");
                sqlCommand.AppendLine("where username = '" + user + "'");
                sqlCommand.AppendLine("AND itemname LIKE '%" + searchitem + "%'");
                sqlCommand.AppendLine("AND status = 'no'");
            }
           

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            //da.SelectCommand.Parameters.AddWithValue("@puser", user);
            //da.SelectCommand.Parameters.AddWithValue("@pitem", searchitem);

            // fill dataset to a table
            da.Fill(ds, "Listing");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["Listing"].Rows.Count;
            if (rec_cnt == 0)
            {
                Selleritems = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Listing"].Rows)
                {
                    Listitems objList = new Listitems();
                    objList.itemid = Convert.ToInt32(row["itemid"]);
                    objList.itemname = row["itemname"].ToString();
                    objList.weight = row["weights"].ToString();
                    objList.image1 = row["img1"].ToString();
                    objList.rtype = row["rtype"].ToString();
                    objList.desc = row["descriptions"].ToString();
                    objList.date = row["dates"].ToString();
                    objList.username = row["username"].ToString();
                    objList.qty = row["quantity"].ToString();
                    Selleritems.Add(objList);
                }
            }
            return Selleritems;
        }

        public List<Listitems> getadd(string user)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<Listitems> ladd = new List<Listitems>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * from Users");
            sqlCommand.AppendLine("where username = '" + user + "'");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "Users");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["Users"].Rows.Count;
            if (rec_cnt == 0)
            {
                ladd = null;
            }

            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Users"].Rows)
                {
                    Listitems objList = new Listitems();
                    objList.address = row["address"].ToString();
                    objList.postalcode = row["postal"].ToString();
                    objList.unitno = row["unitNo"].ToString();

                    ladd.Add(objList);
                }
            }
            
            return ladd;
        }

        public List<Listitems> getmapitems(string postalcode)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<Listitems> itemList = new List<Listitems>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * from Listing");
            sqlCommand.AppendLine("WHERE postalcode = '" + postalcode + "'");

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
                    Listitems objList = new Listitems();
                    objList.postalcode = row["postalcode"].ToString();
                    itemList.Add(objList);
                }
            }


            return itemList;
        }

        public List<Listitems> getestates(string postalcode)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<Listitems> itemList = new List<Listitems>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * from EstateList");
            sqlCommand.AppendLine("WHERE SUBSTRING(postalcode,1,2) = '" + postalcode + "'");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "EstateList");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["EstateList"].Rows.Count;
            if (rec_cnt == 0)
            {
                itemList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["EstateList"].Rows)
                {
                    Listitems objList = new Listitems();
                    objList.estate = row["estate"].ToString();
                    itemList.Add(objList);
                }
            }


            return itemList;
        }

    }
}