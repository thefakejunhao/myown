using Our_FYPJ2019.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

namespace Our_FYPJ2019
{
    public partial class Quotation : System.Web.UI.Page
    {
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        protected List<product> quoteList = new List<product>();
        protected string user;
        protected string status;
        protected string filter;
        protected string image;
        protected string item;

        //protected string choice;

        protected void Page_Load(object sender, EventArgs e)
        {

            productDAO productdao = new productDAO();
            user = Request.QueryString["user"];
            status = Request.QueryString["status"];
            string filter = Request.QueryString["filter"];
            string search = Request.QueryString["search"];
            image = null;

            if (filter == "unaccepted" || filter == null)
            {
                unaccept.Visible = true;
            }

            else
            {
                accept.Visible = true;
            }
            
            if (status == "seller")
            {
                QgridView.Columns[6].HeaderText = "Received On";
            }

            else
            {
                QgridView.Columns[6].HeaderText = "Sent On";
            }

            quoteList = productdao.getquotation(user, status, filter, search);

            if (status == "seller" && (filter == null || filter == "unaccepted") && search == null)
            {
                QgridView.Columns[2].Visible = false;
            }

            else if (status == "buyer")
            {
                QgridView.Columns[3].Visible = false;
                QgridView.Columns[10].Visible = false;
            }

            else if (status == "seller" & filter == "accepted" && search == null)
            {
                QgridView.Columns[10].Visible = false;
                QgridView.Columns[2].Visible = false;
            }

            if (search != null && quoteList != null)
            {
                QgridView.Columns[2].Visible = false;
                
            }


            if (!Page.IsPostBack)
            {
                QgridView.DataSource = quoteList;
                QgridView.DataBind();
            }

        }

        protected void QgridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("onrowcommand");

            productDAO productdao = new productDAO();
            int index = 0;
            GridViewRow row;
            GridView grid = sender as GridView;
            string status = Request.QueryString["status"];

            if (e.CommandName == "View")
            {
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                Label lblQuoteId = row.FindControl("lblquoteid") as Label;
                int QuoteidValue = Convert.ToInt32(lblQuoteId.Text.ToString());
                System.Diagnostics.Debug.WriteLine("buttonView is clicked");
                Response.Redirect("Quotationdetails.aspx?status=" + status + "&quoteid=" + QuoteidValue);

            }

            else if (e.CommandName == "Accept")
            {
                System.Diagnostics.Debug.WriteLine("buttonAccept is clicked");
                index = Convert.ToInt32(e.CommandArgument);
                row = grid.Rows[index];
                Label lblItemId = row.FindControl("lblitemid") as Label;
                Label lblQuoteId = row.FindControl("lblquoteid") as Label;
                int ItemidValue = Convert.ToInt32(lblItemId.Text.ToString());
                int QuoteidValue = Convert.ToInt32(lblQuoteId.Text.ToString());
                System.Diagnostics.Debug.WriteLine("Itemidvalue = ", ItemidValue.ToString());
                System.Diagnostics.Debug.WriteLine("QuoteidValue = ", QuoteidValue.ToString());
                productdao.GridPush(QuoteidValue, ItemidValue);

                //Germaine
                int result = 0;
                string username = Session["Login"].ToString();
                string queryStr = "UPDATE Points SET " +
                                 "itemSoldpoints = itemSoldpoints + 5, " +
                                 "mitemSoldpoints = mitemSoldpoints + 5, " +
                                 "pointLeft = pointLeft + 5 " +
                                 " WHERE username='" + username + "'";
                SqlConnection conn = new SqlConnection(_connStr);
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                conn.Open();
                result = cmd.ExecuteNonQuery();
                conn.Close();

                if (result > 0)
                {
                    SqlConnection conn3 = new SqlConnection(_connStr);
                    conn3.Open();
                    string queryStr3 = "SELECT pointLeft FROM Points WHERE username='" + username + "'";
                    SqlCommand cmd3 = new SqlCommand(queryStr3, conn3);
                    SqlDataReader dr = cmd3.ExecuteReader();

                    if (dr.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("drread");
                        int balance = int.Parse(dr["pointLeft"].ToString());
                        System.Diagnostics.Debug.WriteLine("balance = ", balance);

                        string queryStr2 = "INSERT into Activity(activityName, dateTime, username, change, balance)" +
                                            "values(@activityName, @dateTime, @username, @change, @balance)";

                        SqlConnection conn2 = new SqlConnection(_connStr);
                        SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);

                        cmd2.Parameters.AddWithValue("@activityName", "You have earned 5 points for successful transaction.");
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@dateTime", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@change", "+5");
                        cmd2.Parameters.AddWithValue("@balance", balance);

                        conn2.Open();
                        cmd2.ExecuteNonQuery();
                        conn2.Close();
                    }
                    conn3.Close();
                    dr.Close();
                }

                Response.Redirect("Quotation.aspx?status=seller&user=" + username);
            }

        }

        protected void searchbutton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Searchbutton is clicked");
            string search = tbsearch.Text;
            string user = Request.QueryString["user"];
            string status = Request.QueryString["status"];
            string filter = Request.QueryString["filter"];
            //string choice = ddlchoice.SelectedItem.Text;

            if (status == "seller" && filter == null)
            {
                Response.Redirect("Quotation.aspx?status=seller&user=" + user + "&search=" + search /*+ "&choice=" + choice*/);
            }

            else if (status == "buyer" && filter == null)
            {
                Response.Redirect("Quotation.aspx?status=buyer&user=" + user + "&search=" + search);
            }

            if (status == "seller" && filter != null)
            {
                Response.Redirect("Quotation.aspx?status=seller&user=" + user + "&filter=" + filter + "&search=" + search /*+ "&choice=" + choice*/);
            }

            else if (status == "buyer" && filter != null)
            {
                Response.Redirect("Quotation.aspx?status=buyer&user=" + user + "&filter=" + filter + "&search=" + search);
            }

        }

        protected void BtnFilter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BtnFilter is clicked");
            string search = Request.QueryString["search"];
            string user = Request.QueryString["user"];
            string status = Request.QueryString["status"];
            string filter = ddlstatus.SelectedItem.Text;
            string choice = Request.QueryString["choice"];

            if (status == "seller" && search == null)
            {
                Response.Redirect("Quotation.aspx?status=seller&user=" + user + "&filter=" + filter);
            }

            else if (status == "buyer" && search == null)
            {
                Response.Redirect("Quotation.aspx?status=buyer&user=" + user + "&filter=" + filter);
            }

            if (status == "seller" && search != null)
            {
                Response.Redirect("Quotation.aspx?status=seller&user=" + user + "&search=" + search /*+ "&choice=" + choice */+ "&filter=" + filter);
            }

            else if (status == "buyer" && search != null)
            {
                Response.Redirect("Quotation.aspx?status=buyer&user=" + user + "&search=" + search + "&filter=" + filter);
            }

        }

        protected void QgridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            QgridView.PageIndex = e.NewPageIndex;
            QgridView.DataBind();
        }
    }
}