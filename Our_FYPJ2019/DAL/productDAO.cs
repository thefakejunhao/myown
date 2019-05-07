using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;

namespace Our_FYPJ2019.DAL
{
    public class productDAO
    {   
        public List<product> getproduct(int id)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<product> itemList = new List<product>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();
            string ids = id.ToString();
            sqlCommand.AppendLine("SELECT * from Listing");
            sqlCommand.AppendLine("where itemid = " + ids);
                
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
                    product objList = new product();
                    objList.id = Convert.ToInt32(row["itemid"]);
                    objList.itemname = row["itemname"].ToString();
                    objList.weight = row["weights"].ToString();
                    objList.image1 = row["img1"].ToString();
                    objList.rtype = row["rtype"].ToString();
                    objList.desc = row["descriptions"].ToString();
                    objList.date = row["dates"].ToString();
                    objList.username = row["username"].ToString();
                    objList.plastic = row["plastic"].ToString();
                    objList.paper = row["paper"].ToString();
                    objList.metal = row["metal"].ToString();
                    objList.batteries= row["batteries"].ToString();
                    objList.electronics = row["electronics"].ToString();
                    objList.image2 = row["img2"].ToString();
                    objList.image3 = row["img3"].ToString();
                    objList.image4 = row["img4"].ToString();
                    objList.unitno = row["unitno"].ToString();
                    objList.postalcode = row["postalcode"].ToString();
                    objList.address = row["addr"].ToString();
                    objList.qty = row["quantity"].ToString();
                    objList.district = row["district"].ToString();
                    objList.estate = row["Estate"].ToString();

                    itemList.Add(objList);
                }
            }
            return itemList;
        }

        public int push(string buyer, string message, int itemid, string seller, string time, string date, string item)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("INSERT INTO chat (itemid, item, buyers, sellers, msgs, chattime, chatdate)");
            strSql.AppendLine("VALUES (@pitemid, @pitem, @pbuyers, @psellers, @pmsgs, @pchattime, @pchatdate)");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pitemid", itemid);
            sqlCmd.Parameters.AddWithValue("@pitem", item);
            sqlCmd.Parameters.AddWithValue("@pbuyers", buyer);
            sqlCmd.Parameters.AddWithValue("@psellers", seller);
            sqlCmd.Parameters.AddWithValue("@pmsgs", message);
            sqlCmd.Parameters.AddWithValue("@pchattime", time);
            sqlCmd.Parameters.AddWithValue("@pchatdate", date);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public List<product> getchat(int itemid, string item, string buyer, string seller)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<product> chatList = new List<product>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * from chat");
            sqlCommand.AppendLine("where itemid = " + "'" + itemid + "'");
            sqlCommand.AppendLine("AND item = " + "'" + item + "'");
            sqlCommand.AppendLine("AND buyers = " + "'" + buyer + "'");
            sqlCommand.AppendLine("AND sellers = " + "'" + seller + "'");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "chat");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["chat"].Rows.Count;
            if (rec_cnt == 0)
            {
                chatList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["chat"].Rows)
                {
                    product objList = new product();
                    objList.itemid = row["itemid"].ToString();
                    objList.item = row["item"].ToString();
                    objList.msg = row["msgs"].ToString();
                    objList.buyer = row["buyers"].ToString();
                    objList.seller = row["sellers"].ToString();
                    

                    chatList.Add(objList);
                }
            }
            return chatList;
        }

        //Quotation
        public int qpush(int itemid, string item, string buyer, string seller, string desc, string price, string status, string date, string coverimg, string reason,
            string reasondesc, string bres, string sres, string category, string weight, string quantity, string img2, string img3, string img4, string estate, string address, 
            string unitno, string postalcode, string collectiondate, string timeslot, string time)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("INSERT INTO Quotation (itemid, item, buyer, seller, description, price, status, date, coverimg, reason, reasondesc, bresponse, sresponse, category, weight, quantity, img2, img3, img4, offer, estate, " +
                "address, unitno, postalcode, buyerres, buyeraccept, collectiondate, collectiontime, collected, time)");
            strSql.AppendLine("VALUES (@pitemid, @pitem, @pbuyer, @pseller, @pdesc, @pprice, @pstatus, @pdate, @pcoverimg, @preason, @preasondesc, @pbres, @psres," +
                " @pcategory, @pweight, @pquantity, @pimg2, @pimg3, @pimg4, 'no', @pestate, @paddress, @punitno, @ppostalcode, 'no', 'no', @pcdate, @pctime, 'no', @ptime)");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pitemid", itemid);
            sqlCmd.Parameters.AddWithValue("@pitem", item);
            sqlCmd.Parameters.AddWithValue("@pbuyer", buyer);
            sqlCmd.Parameters.AddWithValue("@pseller", seller);
            sqlCmd.Parameters.AddWithValue("@pdesc", desc);
            sqlCmd.Parameters.AddWithValue("@pdate", date);
            sqlCmd.Parameters.AddWithValue("@pprice", price);
            sqlCmd.Parameters.AddWithValue("@pstatus", status);
            sqlCmd.Parameters.AddWithValue("@pcoverimg", coverimg);
            sqlCmd.Parameters.AddWithValue("@preason", reason);
            sqlCmd.Parameters.AddWithValue("@preasondesc", reasondesc);
            sqlCmd.Parameters.AddWithValue("@pbres", bres);
            sqlCmd.Parameters.AddWithValue("@psres", sres);
            sqlCmd.Parameters.AddWithValue("@pcategory", category);
            sqlCmd.Parameters.AddWithValue("@pweight", weight);
            sqlCmd.Parameters.AddWithValue("@pquantity", quantity);
            sqlCmd.Parameters.AddWithValue("@pimg2", img2);
            sqlCmd.Parameters.AddWithValue("@pimg3", img3);
            sqlCmd.Parameters.AddWithValue("@pimg4", img4);
            sqlCmd.Parameters.AddWithValue("@pestate", estate);
            sqlCmd.Parameters.AddWithValue("@paddress", address);
            sqlCmd.Parameters.AddWithValue("@punitno", unitno);
            sqlCmd.Parameters.AddWithValue("@ppostalcode", postalcode);
            sqlCmd.Parameters.AddWithValue("@pcdate", collectiondate);
            sqlCmd.Parameters.AddWithValue("@pctime", timeslot);
            sqlCmd.Parameters.AddWithValue("@ptime", time);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        //QUotation.aspx [Both buyer & Seller side]
        public List<product> getquotation(string user, string status, string sort, string search)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<product> quotoList = new List<product>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            // from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            if (status == "seller" && (sort == null || sort == "unaccepted") && search == null)
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where seller = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'no'");
                sqlCommand.AppendLine("AND offer = 'no'");
                sqlCommand.AppendLine("AND collected = 'no'");
            }

            else if (status == "buyer" && (sort == null || sort == "unaccepted") && search == null)
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where buyer = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'no'");
                sqlCommand.AppendLine("AND collected = 'no'");
            }

            else if (status == "seller" && sort == "accepted" && search == null)
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where seller = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'yes'");
                sqlCommand.AppendLine("AND collected = 'no'");
            }

            else if (status == "buyer" && sort == "accepted" && search == null)
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where buyer = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'yes'");
                sqlCommand.AppendLine("AND collected = 'no'");
            }

            else if (status == "buyer" && search != null && (sort == null || sort == "unaccepted"))
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where buyer = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'no'");
                sqlCommand.AppendLine("AND offer = 'no'");
                sqlCommand.AppendLine("AND item LIKE '%" + search + "%'");
                sqlCommand.AppendLine("AND collected = 'no'");

            }

            else if (status == "seller" && search != null && (sort == null || sort == "unaccepted"))
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where seller = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'no'");
                sqlCommand.AppendLine("AND offer = 'no'");
                sqlCommand.AppendLine("AND item LIKE '%" + search + "%'");
                sqlCommand.AppendLine("AND collected = 'no'");
               
            }

            else if (status == "buyer" && search != null && sort == "accepted")
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where buyer = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'yes'");
                sqlCommand.AppendLine("AND item LIKE '%" + search + "%'");
                sqlCommand.AppendLine("AND collected = 'no'");

            }

            else if (status == "seller" && search != null && sort == "accepted")
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
                sqlCommand.AppendLine("where seller = " + "'" + user + "'");
                sqlCommand.AppendLine("AND status = 'yes'");
                sqlCommand.AppendLine("AND item LIKE '%" + search + "%'");
                sqlCommand.AppendLine("AND collected = 'no'");
           
            }

            else
            {
                sqlCommand.AppendLine("SELECT * from Quotation");
            }

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
                quotoList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Quotation"].Rows)
                {
                    product objList = new product();
                    objList.quoteid = Convert.ToInt32(row["quoteid"]);
                    objList.id = Convert.ToInt32(row["itemid"]);
                    objList.item = row["item"].ToString();
                    objList.buyer = row["buyer"].ToString();
                    objList.seller = row["seller"].ToString();
                    objList.desc = row["description"].ToString();
                    objList.price = row["price"].ToString();
                    objList.status = row["status"].ToString();
                    objList.date = row["date"].ToString();
                    objList.collectiondate = row["collectiondate"].ToString();
                    objList.timeslot = row["collectiontime"].ToString();
                    objList.coverimg = row["coverimg"].ToString();
                    objList.rtype = row["category"].ToString();
                    objList.seller = row["seller"].ToString();
                    quotoList.Add(objList);

                }
            }
            return quotoList;
        }

        //QuotationDetails.aspx [Both buyer & seller side)
        public List<product> getQuoteDetail(string status, string quoteid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<product> quotoList = new List<product>();

            // Step 2 :Retrieve connection string from web.config

            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * from Quotation");
            sqlCommand.AppendLine("where quoteid = " + "'" + quoteid + "'");

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
                quotoList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Quotation"].Rows)
                {
                    product objList = new product();
                    objList.quoteid = Convert.ToInt32(row["quoteid"]);
                    objList.itemid = row["itemid"].ToString();
                    objList.item = row["item"].ToString();
                    objList.buyer = row["buyer"].ToString();
                    objList.seller = row["seller"].ToString();
                    objList.desc = row["description"].ToString();
                    objList.price = row["price"].ToString();
                    objList.status = row["status"].ToString();
                    objList.date = row["date"].ToString();
                    objList.coverimg = row["coverimg"].ToString();
                    objList.reason = row["reason"].ToString();
                    objList.reasondesc = row["reasondesc"].ToString();
                    objList.bres = row["bresponse"].ToString();
                    objList.sres = row["sresponse"].ToString();
                    objList.sellerdate = row["sellerdate"].ToString();
                    objList.rtype = row["category"].ToString();
                    objList.weight = row["weight"].ToString();
                    objList.qty = row["quantity"].ToString();
                    objList.image2 = row["img2"].ToString();
                    objList.image3 = row["img3"].ToString();
                    objList.image4 = row["img4"].ToString();
                    objList.buyerres = row["buyerres"].ToString();
                    objList.buyeraccept = row["buyeraccept"].ToString();
                    objList.collectiondate = row["collectiondate"].ToString();
                    objList.timeslot = row["collectiontime"].ToString();
                    
                    quotoList.Add(objList);
                }
            }
            return quotoList;
        }

        //QuotationDetails.aspx[seller]
        public int sellerQuotepush(int quoteid, string accept, string reason, string reasondesc, string bres, string sres, string date, int itemid)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database]
            if (accept == "no")
            {
                System.Diagnostics.Debug.WriteLine("&&&&&&&& ACcept = no &&&&&&&&&&&&&&&&&&&&");
                strSql.AppendLine("update Quotation");
                strSql.AppendLine("set status = @pstatus , reason = @preason, reasondesc = @preasondesc, bresponse = @pbres, sresponse = @psres, " +
                    "sellerdate = @psdate");
                strSql.AppendLine("where quoteid = @pquoteid");
            }

            else if (accept == "yes")
            {
                System.Diagnostics.Debug.WriteLine("&&&&&&&& ACcept = yes &&&&&&&&&&&&&&&&&&&&");
                strSql.AppendLine("update Quotation");
                strSql.AppendLine("set status = @pstatus, offer = 'yes', buyerres = 'yes'");
                strSql.AppendLine("where quoteid = @pquoteid;");

                strSql.AppendLine("update Quotation");
                strSql.AppendLine("set offer = 'yes'");
                strSql.AppendLine("where itemid = @pitemid;");

                strSql.AppendLine("update Listing");
                strSql.AppendLine("set status = 'yes'");
                strSql.AppendLine("where itemid = @pitemid;");
            }

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pstatus", accept);
            //sqlCmd.Parameters.AddWithValue("@pcounter", counter);
            sqlCmd.Parameters.AddWithValue("@preason", reason);
            sqlCmd.Parameters.AddWithValue("@preasondesc", reasondesc);
            sqlCmd.Parameters.AddWithValue("@pquoteid", quoteid);
            sqlCmd.Parameters.AddWithValue("@pbres", bres);
            sqlCmd.Parameters.AddWithValue("@psres", sres);
            sqlCmd.Parameters.AddWithValue("@psdate", date);
            sqlCmd.Parameters.AddWithValue("@pitemid", itemid);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        //QuotationDetails.aspx[buyer]
        public int buyerQuotepush(int quoteid, string desc, string price, string date, string bres, string sres, string collectiondate, string timeslot, string time)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("update Quotation");
            strSql.AppendLine("set description = @pdesc, price = @pprice, date = @pdate, bresponse = @pbres, sresponse = @psres," +
                "collectiondate = @pcdate, collectiontime = @pctime, time = @ptime");
            strSql.AppendLine("where quoteid = @pquoteid");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pdesc", desc);
            sqlCmd.Parameters.AddWithValue("@pprice", price);
            sqlCmd.Parameters.AddWithValue("@pdate", date);
            sqlCmd.Parameters.AddWithValue("@pbres", bres);
            sqlCmd.Parameters.AddWithValue("@psres", sres);
            sqlCmd.Parameters.AddWithValue("@pquoteid", quoteid);
            sqlCmd.Parameters.AddWithValue("@pcdate", collectiondate);
            sqlCmd.Parameters.AddWithValue("@pctime", timeslot);
            sqlCmd.Parameters.AddWithValue("@ptime", time);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public int QuoteHistorypush(string itemid, string item, string buyer, string seller, string desc, string price,string accept, string buyerdate, 
            string reason, string reasondesc, string sellerdate)
        {
            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database
            strSql.AppendLine("INSERT INTO QuoteHistory(itemid, item, seller, description, price, status, date, reason, reasondesc, sellerdate, buyer)");
            strSql.AppendLine("VALUES (@pitemid, @pitem, @pseller, @pdesc, @pprice, @pstatus, @pdate , @preason, @preasondesc, @psellerdate, @pbuyer)");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pitemid", itemid);
            sqlCmd.Parameters.AddWithValue("@pitem", item);
            sqlCmd.Parameters.AddWithValue("@pseller", seller);
            sqlCmd.Parameters.AddWithValue("@pdesc", desc);
            sqlCmd.Parameters.AddWithValue("@pprice", price);
            sqlCmd.Parameters.AddWithValue("@pstatus", accept);
            sqlCmd.Parameters.AddWithValue("@pdate", buyerdate);
            sqlCmd.Parameters.AddWithValue("@preason", reason);
            sqlCmd.Parameters.AddWithValue("@preasondesc", reasondesc);           
            sqlCmd.Parameters.AddWithValue("@psellerdate", sellerdate);           
            sqlCmd.Parameters.AddWithValue("@pbuyer", buyer);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        //To display history of quotation
        public List<product> getQuoteHistory(string quoteid)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<product> quotoList = new List<product>();

            // Step 2 :Retrieve connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

            // Step 3 :Create SQLcommand to select tdTerm and tdRate 
            //        from TDRate table where the rate is current
            StringBuilder sqlCommand = new StringBuilder();

            sqlCommand.AppendLine("SELECT * from QuoteHistory");
            sqlCommand.AppendLine("where itemid = " + "'" + quoteid + "'");

            // Step 4 :Instantiate SqlConnection instance  
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 5 :Retrieve record using DataAdapter
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            // fill dataset to a table
            da.Fill(ds, "QuoteHistory");

            // Step 6 : if there is no record in dataset, set the rteList to null
            int rec_cnt = ds.Tables["QuoteHistory"].Rows.Count;
            if (rec_cnt == 0)
            {
                quotoList = null;
            }
            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["QuoteHistory"].Rows)
                {
                    product objList = new product();
                    objList.itemid = row["itemid"].ToString();
                    objList.item = row["item"].ToString();
                    objList.buyer = row["buyer"].ToString();
                    objList.seller = row["seller"].ToString();
                    objList.desc = row["description"].ToString();
                    objList.price = row["price"].ToString();
                    objList.status = row["status"].ToString();
                    objList.date = row["date"].ToString();
                    objList.reason = row["reason"].ToString();
                    objList.reasondesc = row["reasondesc"].ToString();                  
                    objList.sellerdate = row["sellerdate"].ToString();

                    quotoList.Add(objList);
                }
            }
            return quotoList;
        }

        // For gridview update
        public int GridPush(int quoteid, int itemid)
        {

            StringBuilder strSql = new StringBuilder();
            int result = 0;

            //SQL command to insert data into database]
            strSql.AppendLine("update Quotation");
            strSql.AppendLine("set status = 'yes', offer = 'yes'");
            strSql.AppendLine("where quoteid = @pquoteid;");

            strSql.AppendLine("update Quotation");
            strSql.AppendLine("set offer = 'yes'");
            strSql.AppendLine("where itemid = @pitemid;");
            
            strSql.AppendLine("update Listing");
            strSql.AppendLine("set status = 'yes'");
            strSql.AppendLine("where itemid = @pitemid;");

            // Instantiate Sql connection instance and SqlCOmmand instance
            string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(strSql.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@pitemid", itemid);
            sqlCmd.Parameters.AddWithValue("@pquoteid", quoteid);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();

            return result;
        }

        public List<product> getuser(string user)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            // Step 1 : declare a List to hold collection of interestRte object
            List<product> itemList = new List<product>();

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
                itemList = null;
            }

            else
            {
                // Step 7 : Iterate DataRow to extract table column tdTerm and tdRate and
                //          create interestRte instance and add the instance to a List collection       

                foreach (DataRow row in ds.Tables["Users"].Rows)
                {
                    product objList = new product();
                    objList.status = row["roles"].ToString();
                    itemList.Add(objList);
                }

            }
            return itemList;
        }
    }
}