using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace MyFYPJBackup.DAL
{
    public class customerDAO
    {

        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        public List<customer> getCustomerByCustomerId(string textbox)
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM Customer");
            sqlStr.AppendLine("where NRIC=@paraCustId or Name=@paraCustId or ContactNo = @paraCustId");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraCustId", textbox);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["Name"].ToString();
                    myCustomer.Password = row["CusPass"].ToString();
                    myCustomer.Address = row["Address"].ToString();
                    myCustomer.ContactNo = row["ContactNo"].ToString();
                    myCustomer.HomeNo = row["HomeNo"].ToString();
                    myCustomer.Email = row["Email"].ToString();
                    myCustomer.Area = row["Area"].ToString();

                    CustomerList.Add(myCustomer);

                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }

        //integration to User table
        public List<customer> getCustomerById(string textbox)
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM Users");
            sqlStr.AppendLine("where username=@paraCustId or mobileNo = @paraCustId or email=@paraCustId");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraCustId", textbox);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    //myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["username"].ToString();
                    myCustomer.Password = row["password"].ToString();
                    myCustomer.Address = row["address"].ToString();
                    myCustomer.ContactNo = row["mobileNo"].ToString();
                    //myCustomer.HomeNo = row["HomeNo"].ToString();
                    myCustomer.Email = row["email"].ToString();
                    myCustomer.unitNo = row["unitNo"].ToString();

                    CustomerList.Add(myCustomer);

                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }



        public int deleteCustomer(string NRIC)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM Users");
            sqlStr.AppendLine("WHERE mobileNo= @paranric ");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paranric", NRIC);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public int AddBannedUser(string name, string ContactNo, string Address, string Email, string reason, string Area, string admin, string date)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO bannedList(Name,NRIC,ContactNo,Address,Area,Reason,Email,adminBan,date)");
            sqlStr.AppendLine("VALUES(@paraname,'NULL',@paraContactNo,@paraAddress,@paraArea,@paraReason,@paraEmail,@paraAdmin,@paradate)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraname", name);
            // sqlCmd.Parameters.AddWithValue("@paraNRIC", NRIC);
            sqlCmd.Parameters.AddWithValue("@paraContactNo", ContactNo);
            sqlCmd.Parameters.AddWithValue("@paraAddress", Address);
            sqlCmd.Parameters.AddWithValue("@paraArea", Area);
            sqlCmd.Parameters.AddWithValue("@paraReason", reason);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraAdmin", admin);
            sqlCmd.Parameters.AddWithValue("@paradate", date);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery(); // Execute NonQuery return an integer value
            myConn.Close();
            return result;
        }


        public List<customer> getBannedCustomer()
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM bannedList");
            //sqlStr.AppendLine("where NRIC=@paraCustId");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            //da.SelectCommand.Parameters.AddWithValue("paraCustId", NRIC);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["Name"].ToString();
                    //myCustomer.Password = row["C"].ToString();
                    myCustomer.Address = row["Address"].ToString();
                    myCustomer.ContactNo = row["ContactNo"].ToString();
                    myCustomer.Email = row["Email"].ToString();
                    myCustomer.reason = row["Reason"].ToString();
                    myCustomer.Area = row["Area"].ToString();
                    myCustomer.adminBan = row["adminBan"].ToString();
                    myCustomer.date = row["date"].ToString();

                    CustomerList.Add(myCustomer);
                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }

        public List<customer> getBannedCustomerbySearch(string search)
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM bannedList");
            sqlStr.AppendLine("where Name=@paraCustId or ContactNo=@paraCustId or Address=@paraCustId or date=@paraCustId");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraCustId", search);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["Name"].ToString();
                    //myCustomer.Password = row["C"].ToString();
                    myCustomer.Address = row["Address"].ToString();
                    myCustomer.ContactNo = row["ContactNo"].ToString();
                    myCustomer.Email = row["Email"].ToString();
                    myCustomer.reason = row["Reason"].ToString();
                    myCustomer.Area = row["Area"].ToString();
                    myCustomer.adminBan = row["adminBan"].ToString();
                    myCustomer.date = row["date"].ToString();

                    CustomerList.Add(myCustomer);
                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }

        public List<customer> getReportedCustomerByReason(string type)
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT NRIC,Name,ContactNo,Email,ReasonStated,type,listingID,itemName,noOfReports FROM reportedUser");
            sqlStr.AppendLine("where Type=@paraType group by NRIC,Name,ContactNo,Email,ReasonStated,type,listingID,itemName,noOfReports");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraType", type);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    //myCustomer.reportID = row["reportID"].ToString();
                    myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["Name"].ToString();
                    //myCustomer.Password = row["C"].ToString();
                    //myCustomer.Address = row["Address"].ToString();
                    myCustomer.ContactNo = row["ContactNo"].ToString();
                    myCustomer.Email = row["Email"].ToString();
                    myCustomer.reasonStated = row["ReasonStated"].ToString();
                    //myCustomer.Area = row["Area"].ToString();
                    //myCustomer.reportBy = row["ReportBy"].ToString();
                    myCustomer.type = row["Type"].ToString();
                    myCustomer.listingID = row["listingID"].ToString();
                    myCustomer.itemName = row["itemName"].ToString();
                    myCustomer.noOfReports = row["noOfReports"].ToString();
                    //myCustomer.date = row["Date"].ToString();

                    CustomerList.Add(myCustomer);
                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }


        public int deleteReport(string reportID)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM reportedUser");
            sqlStr.AppendLine("WHERE listingID= @paraID ");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraID", reportID);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }


        public int unBan(string NRIC)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM bannedList");
            sqlStr.AppendLine("WHERE Name=@para");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@para", NRIC);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        //Most reported first
        public List<customer> getReportedCustomerbyNumber(string type)
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();

            sqlStr.AppendLine("SELECT NRIC,Name,ContactNo,Email,ReasonStated,type,listingID,itemName,noOfReports FROM reportedUser ");
            sqlStr.AppendLine("where Type=@paraType group by NRIC,Name,ContactNo,Email,ReasonStated,type,listingID,itemName,noOfReports ORDER BY noOfReports desc");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraType", type);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    //myCustomer.reportID = row["reportID"].ToString();
                    myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["Name"].ToString();
                    //myCustomer.Password = row["C"].ToString();
                    //myCustomer.Address = row["Address"].ToString();
                    myCustomer.ContactNo = row["ContactNo"].ToString();
                    myCustomer.Email = row["Email"].ToString();
                    myCustomer.reasonStated = row["ReasonStated"].ToString();
                    //myCustomer.Area = row["Area"].ToString();
                    //myCustomer.reportBy = row["ReportBy"].ToString();
                    myCustomer.type = row["Type"].ToString();
                    myCustomer.listingID = row["listingID"].ToString();
                    myCustomer.itemName = row["itemName"].ToString();
                    myCustomer.noOfReports = row["noOfReports"].ToString();
                    //myCustomer.date = row["Date"].ToString();

                    CustomerList.Add(myCustomer);
                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }

        //Least reported
        public List<customer> getReportedCustomerbyNumber2(string type)
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();

            sqlStr.AppendLine("SELECT NRIC,Name,ContactNo,Email,ReasonStated,type,listingID,itemName,noOfReports FROM reportedUser ");
            sqlStr.AppendLine("where Type=@paraType group by NRIC,Name,ContactNo,Email,ReasonStated,type,listingID,itemName,noOfReports ORDER BY noOfReports");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraType", type);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    // myCustomer.reportID = row["reportID"].ToString();
                    myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["Name"].ToString();
                    //myCustomer.Password = row["C"].ToString();
                    //myCustomer.Address = row["Address"].ToString();
                    myCustomer.ContactNo = row["ContactNo"].ToString();
                    myCustomer.Email = row["Email"].ToString();
                    myCustomer.reasonStated = row["ReasonStated"].ToString();
                    //myCustomer.Area = row["Area"].ToString();
                    //myCustomer.reportBy = row["ReportBy"].ToString();
                    myCustomer.type = row["Type"].ToString();
                    myCustomer.listingID = row["listingID"].ToString();
                    myCustomer.itemName = row["itemName"].ToString();
                    myCustomer.noOfReports = row["noOfReports"].ToString();
                    //myCustomer.date = row["Date"].ToString();

                    CustomerList.Add(myCustomer);
                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }

        public List<customer> getReportedCustomerByRecent(string type)
        {
            List<customer> CustomerList = new List<customer>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM reportedUser");
            sqlStr.AppendLine("where Type=@paraType order by Date Desc");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraType", type);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    customer myCustomer = new customer();

                    //myCustomer.reportID = row["reportID"].ToString();
                    myCustomer.NRIC = row["NRIC"].ToString();
                    myCustomer.Name = row["Name"].ToString();
                    //myCustomer.Password = row["C"].ToString();
                    //myCustomer.Address = row["Address"].ToString();
                    myCustomer.ContactNo = row["ContactNo"].ToString();
                    myCustomer.Email = row["Email"].ToString();
                    myCustomer.reasonStated = row["ReasonStated"].ToString();
                    //myCustomer.Area = row["Area"].ToString();
                    //myCustomer.reportBy = row["ReportBy"].ToString();
                    myCustomer.type = row["Type"].ToString();
                    myCustomer.listingID = row["listingID"].ToString();
                    myCustomer.itemName = row["itemName"].ToString();
                    myCustomer.noOfReports = row["noOfReports"].ToString();
                    //myCustomer.date = row["Date"].ToString();

                    CustomerList.Add(myCustomer);
                }
            }
            else
            {
                CustomerList = null;
            }
            return CustomerList;
        }


        public int updateCount(string name)
        {
            int result = 0;
            string sqlStr = "UPDATE reportedUser SET noOfReports=(select count(*) from reportedUser where Name = @paraName )";

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", name);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }


        public int updateBanStatusYes(string name)
        {
            int result = 0;
            string sqlStr = "UPDATE Users SET banStatus='Yes' where username=@para ";

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

            sqlCmd.Parameters.AddWithValue("@para", name);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }


        public int updateBanStatusNo(string name)
        {
            int result = 0;
            string sqlStr = "UPDATE Users SET banStatus='no' where username=@para ";

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

            sqlCmd.Parameters.AddWithValue("@para", name);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }


        public customer reportList(string name, string listingID)
        {
            customer adObj = new customer();

            DataSet ds = new DataSet();
            string mysql = "Select * from Listing where username = @paraName and itemid=@paraID";
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(mysql, myConn);
            da.SelectCommand.Parameters.AddWithValue("paraName", name);
            da.SelectCommand.Parameters.AddWithValue("paraID", listingID);

            da.Fill(ds, "report");
            int rec_cnt = ds.Tables["report"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["report"].Rows[0];
                adObj.listingID = row["itemid"].ToString();
                adObj.Name = row["username"].ToString();
            }
            else
            {
                adObj = null;
            }

            return adObj;
        }


        public int reportListing(string name, string listingID, string reason, string email, string listing)
        {
            int result = 0;
            string sqlStr = "INSERT INTO reportedUser (Name,listingID,ReasonStated,Email,Date,itemName,Type) VALUES(@name,@listingID,@reason,@email,getDate(),@listing,'listing')";

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

            sqlCmd.Parameters.AddWithValue("@name", name);
            sqlCmd.Parameters.AddWithValue("@listingID", listingID);
            sqlCmd.Parameters.AddWithValue("@reason", reason);
            sqlCmd.Parameters.AddWithValue("@email", email);
            sqlCmd.Parameters.AddWithValue("@listing", listing);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }


        public string getEmail(string name)
        {
            string result = "0";
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStr = "Select email from [Users] where username = @paraname";
            SqlCommand sqlCmd = new SqlCommand(sqlStr, myConn);

            sqlCmd.Parameters.AddWithValue("@paraname", name);

            myConn.Open();
            object total = sqlCmd.ExecuteScalar();

            result = total.ToString();


            return result;
        }


    }
}