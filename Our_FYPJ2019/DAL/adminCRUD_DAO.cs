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
    public class adminCRUD_DAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        public int deleteListing(string username, string itemName)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM Listing");
            sqlStr.AppendLine("WHERE username= @paraname and itemname=@itemName");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraname", username);
            sqlCmd.Parameters.AddWithValue("@itemName", itemName);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }


        public List<adminCRUD> getListingById(string username, string itemID)
        {
            List<adminCRUD> Listing = new List<adminCRUD>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM Listing");
            sqlStr.AppendLine("where username=@parauser and itemid = @paraID");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("parauser", username);
            da.SelectCommand.Parameters.AddWithValue("paraID", itemID);
            da.Fill(ds, "Table");

            int rec_cnt = ds.Tables["Table"].Rows.Count;

            if (rec_cnt > 0)
            {
                //changes
                foreach (DataRow row in ds.Tables["Table"].Rows)
                {
                    adminCRUD CRUD = new adminCRUD();
                    CRUD.itemid = row["itemid"].ToString();
                    CRUD.username = row["username"].ToString();
                    CRUD.itemname = row["itemname"].ToString();
                    CRUD.img1 = row["img1"].ToString();
                    CRUD.img2 = row["img2"].ToString();
                    CRUD.img3 = row["img3"].ToString();
                    //CRUD.time = row["times"].ToString();
                    CRUD.dates = row["dates"].ToString();
                    CRUD.descriptions = row["descriptions"].ToString();

                    Listing.Add(CRUD);
                }
            }
            else
            {
                Listing = null;
            }
            return Listing;

        }


        public int AddType(string type, string name)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO adminEdit(rtype,name)");
            sqlStr.AppendLine("VALUES(@paratype,@paraname)");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paratype", type);
            sqlCmd.Parameters.AddWithValue("@paraname", name);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public int deleteType(string type)
        {
            int result;
            StringBuilder sqlStr = new StringBuilder();
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM adminEdit");
            sqlStr.AppendLine("WHERE rtype= @paratype ");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paratype", type);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }


        public List<adminCRUD> getItem()
        {
            List<adminCRUD> Listing = new List<adminCRUD>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM adminEdit group by name");
            //sqlStr.AppendLine("where rtype=@paraName");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            //da.SelectCommand.Parameters.AddWithValue("parauser", username);
            //da.SelectCommand.Parameters.AddWithValue("paraName", itemName);
            da.Fill(ds, "eTable");

            int rec_cnt = ds.Tables["eTable"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["eTable"].Rows)
                {
                    adminCRUD CRUD = new adminCRUD();

                    //CRUD.username = row["username"].ToString();
                    CRUD.rtype = row["rtype"].ToString();
                    CRUD.name = row["name"].ToString();

                    Listing.Add(CRUD);
                }
            }
            else
            {
                Listing = null;
            }
            return Listing;

        }

        public List<adminCRUD> getItembyname(string type)
        {
            List<adminCRUD> Listing = new List<adminCRUD>();
            DataSet ds = new DataSet();
            DataTable Data = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM adminEdit");
            sqlStr.AppendLine("where rtype=@paraName");

            SqlConnection myconn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myconn);

            da.SelectCommand.Parameters.AddWithValue("paraName", type);
            //da.SelectCommand.Parameters.AddWithValue("paraName", itemName);
            da.Fill(ds, "eTable");

            int rec_cnt = ds.Tables["eTable"].Rows.Count;

            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["eTable"].Rows)
                {
                    adminCRUD CRUD = new adminCRUD();

                    //CRUD.username = row["username"].ToString();
                    CRUD.rtype = row["rtype"].ToString();
                    CRUD.name = row["name"].ToString();

                    Listing.Add(CRUD);
                }
            }
            else
            {
                Listing = null;
            }
            return Listing;

        }






    }
}