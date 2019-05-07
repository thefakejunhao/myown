using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Our_FYPJ2019
{
    public partial class E_vouchers : System.Web.UI.Page
    {
        //string _connStr = ConfigurationManager.ConnectionStrings["fypj"].ConnectionString;
        string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            linkbtn_catalog.CssClass = "linkbtn";

            if (!IsPostBack)
            {
                bindVoucher();
            }
            bindEwallet();

            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();

            string queryStr = "SELECT image, p.username, pointLeft From users u INNER JOIN points p ON u.username = p.username WHERE p.username = '" + Session["Login"] + "' ";

            SqlCommand cmd = new SqlCommand(queryStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Image4.ImageUrl = "~\\Images\\" + dr["Image"].ToString();
                lbl_name.Text = dr["username"].ToString();
                Label17.Text = dr["pointLeft"].ToString();
            }
            dr.Close();
        }

        //lbl_header.Text = "TRANSACTION IN PROGRESS ";
        //SqlConnection conn = new SqlConnection(_connStr);
        //conn.Open();
        //string queryStr = "SELECT * FROM Vouchers WHERE id = '" + Session["id"] + "'";
        //SqlCommand cmd = new SqlCommand(queryStr, conn);
        //SqlDataReader dr = cmd.ExecuteReader();

        //if (dr.Read())
        //{
        //    lbl_voucherName0.Text = dr["vouchersName"].ToString();

        //    string barCode = dr["barCode"].ToString();
        //    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        //    using (Bitmap bitmap = new Bitmap(barCode.Length * 40, 80))
        //    {
        //        using (Graphics graphics = Graphics.FromImage(bitmap))
        //        {
        //            Font oFont = new Font("IDAutomationHC39M", 16);
        //            PointF point = new PointF(2f, 2f);
        //            SolidBrush blackBrush = new SolidBrush(Color.Black);
        //            SolidBrush whiteBrush = new SolidBrush(Color.White);
        //            graphics.FillRectangle(whiteBrush, 0, 0, bitmap.Width, bitmap.Height);
        //            graphics.DrawString("*" + barCode + "*", oFont, blackBrush, point);
        //        }
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //            byte[] byteImage = ms.ToArray();

        //            Convert.ToBase64String(byteImage);
        //            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
        //        }
        //        PlaceHolder1.Controls.Add(imgBarCode);
        //    }
        //}




        private void bindVoucher()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            string queryStr = "SELECT * FROM Vouchers";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataList1.DataSource = dt;
            DataList1.DataBind();
        }

        //protected void Timer1_Tick(object sender, EventArgs e)
        //{
        //    int seconds = int.Parse(lbl_timer.Text);
        //    if (seconds > 0)
        //    {
        //        lbl_timer.Text = (seconds - 1).ToString();
        //    }
        //    else
        //    {
        //        Timer1.Enabled = false;
        //        Response.Write("<script>alert('Sorry, your e-vourcher has expired.')</script>");
        //    }
        //}

        //protected void btn_done_Click(object sender, EventArgs e)
        //{
        //    completedPanel.Visible = true;
        //    transactionPanel.Visible = false;
        //    lbl_header.Text = "TRANSACTION COMPLETED";
        //    lbl_dateTime.Text = Convert.ToString(DateTime.Now);
        //}

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "select")
            {
                Session["id"] = e.CommandArgument.ToString();
                SqlConnection conn = new SqlConnection(_connStr);
                conn.Open();
                string queryStr = "SELECT * FROM Vouchers WHERE id = '" + Session["id"] + "'";
                SqlCommand cmd = new SqlCommand(queryStr, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Image2.ImageUrl = "~\\Images\\" + dr["Image"].ToString();
                    lbl_voucherName3.Text = dr["vouchersName"].ToString();
                    lbl_voucherPoints.Text = dr["requiredPts"].ToString();
                    int ptsRequired = int.Parse(dr["requiredPts"].ToString());
                    lbl_ptsRequired.Text = dr["requiredPts"].ToString();
                }
                conn.Close();
                dr.Close();

                SqlConnection conn2 = new SqlConnection(_connStr);
                conn2.Open();
                string queryStr2 = "SELECT pointLeft FROM Points WHERE username = '" + Session["Login"] + "' ";
                SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);
                SqlDataReader dr2 = cmd2.ExecuteReader();

                if (dr2.Read())
                {
                    lbl_totalpts.Text = dr2["pointLeft"].ToString();
                }
                conn2.Close();
                dr2.Close();

                lbl_ptsLeft.Text = (int.Parse(lbl_totalpts.Text) - int.Parse(lbl_ptsRequired.Text)).ToString();

                if (int.Parse(lbl_totalpts.Text) < int.Parse(lbl_ptsRequired.Text))
                {
                    Response.Write("<script>alert ('Sorry, you do not have enough points to redeem the voucher.'); location.href='E-vouchers.aspx';</script>");
                }
                else
                {
                    nav.Visible = false;
                    DataList1.Visible = false;
                    redemptionPanel.Visible = true;
                }
            }
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(lbl_ptsLeft.Text) < 50)
                {

                }
                else
                {
                    int counter = Convert.ToInt32(tb_quantity.Text);
                    counter = counter + 1;
                    tb_quantity.Text = counter.ToString();

                    lbl_ptsRequired.Text = (int.Parse(tb_quantity.Text) * int.Parse(lbl_voucherPoints.Text)).ToString();
                    lbl_ptsLeft.Text = (int.Parse(lbl_totalpts.Text) - int.Parse(lbl_ptsRequired.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                lbl_error.Visible = true;
            }
        }

        protected void btn_minus_Click(object sender, EventArgs e)
        {
            try
            {
                int counter = Convert.ToInt32(tb_quantity.Text);
                counter = counter - 1;
                if (counter > 0)
                {
                    tb_quantity.Text = counter.ToString();
                }

                lbl_ptsRequired.Text = (int.Parse(tb_quantity.Text) * int.Parse(lbl_voucherPoints.Text)).ToString();
                lbl_ptsLeft.Text = (int.Parse(lbl_totalpts.Text) - int.Parse(lbl_ptsRequired.Text)).ToString();

                if (int.Parse(lbl_ptsLeft.Text) < 0)
                {
                    lbl_ptsLeft.Text = "0";
                    lbl_ptsRequired.ForeColor = Color.Red;
                }
                else
                {
                    lbl_ptsRequired.ForeColor = Color.Black;
                    lbl_error.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbl_error.Visible = true;
            }
        }

        protected void tb_quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lbl_ptsRequired.Text = (int.Parse(tb_quantity.Text) * int.Parse(lbl_voucherPoints.Text)).ToString();
                lbl_ptsLeft.Text = (int.Parse(lbl_totalpts.Text) - int.Parse(lbl_ptsRequired.Text)).ToString();

                if (int.Parse(lbl_ptsLeft.Text) < 0)
                {
                    lbl_ptsLeft.Text = "0";
                    lbl_ptsRequired.ForeColor = Color.Red;
                    lbl_error.Visible = true;
                }
                else
                {
                    lbl_ptsRequired.ForeColor = Color.Black;
                    lbl_error.Visible = false;
                }
            }
            catch (Exception ex)
            {
                lbl_error.Visible = true;
            }
        }

        protected void btn_redeem_Click(object sender, EventArgs e)
        {
            if (int.Parse(tb_quantity.Text) != 0)
            {
                if (int.Parse(lbl_ptsRequired.Text) > int.Parse(lbl_totalpts.Text))
                {
                    lbl_error.Visible = true;
                }

                else
                {
                    //generate random redemptionID
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    var stringChars = new char[16];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }
                    var finalString = new string(stringChars);
                    Session["redemptionID"] = finalString;

                    //insert into redemption table
                    int result = 0;
                    string username = Session["Login"].ToString();
                    int id = Convert.ToInt32(Session["id"].ToString());

                    string queryStr = "INSERT into Redemption(redemptionID, username, id, dateTime, quantity)" +
                           "values(@redemptionID, @username, @id, @dateTime, @quantity)";
                    SqlConnection conn = new SqlConnection(_connStr);
                    SqlCommand cmd = new SqlCommand(queryStr, conn);
                    cmd.Parameters.AddWithValue("@redemptionID", finalString);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@dateTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@quantity", int.Parse(tb_quantity.Text));
                    conn.Open();
                    result += cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        //insert into activity table
                        string queryStr2 = "INSERT into Activity(activityName, dateTime, username, redemptionID, change, balance)" +
                                             "values(@activityName, @dateTime, @username, @redemptionID, @change, @balance)";
                        SqlConnection conn2 = new SqlConnection(_connStr);
                        SqlCommand cmd2 = new SqlCommand(queryStr2, conn2);
                        string activityName = "You have redeemed " + tb_quantity.Text + "x " + lbl_voucherName3.Text + ".";
                        cmd2.Parameters.AddWithValue("@activityName", activityName);
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@dateTime", DateTime.Now);
                        cmd2.Parameters.AddWithValue("@redemptionID", finalString);
                        cmd2.Parameters.AddWithValue("@change", "-" + lbl_ptsRequired.Text);
                        cmd2.Parameters.AddWithValue("@balance", lbl_ptsLeft.Text);
                        conn2.Open();
                        cmd2.ExecuteNonQuery();
                        conn2.Close();

                        //update points
                        string queryStr3 = "UPDATE Points SET " +
                                           " pointLeft =@pointLeft " +
                                           " WHERE username='" + Session["Login"] + "'";
                        SqlConnection conn3 = new SqlConnection(_connStr);
                        SqlCommand cmd3 = new SqlCommand(queryStr3, conn3);
                        cmd3.Parameters.AddWithValue("@pointLeft", lbl_ptsLeft.Text);
                        conn3.Open();
                        cmd3.ExecuteNonQuery();

                        conn3.Close();

                        nav.Visible = false;
                        redemptionPanel.Visible = false;
                        redemptionSucessPanel.Visible = true;
                        bindSuccess();

                    }
                    conn.Close();
                }
            }
            else
            {
                lbl_error.Visible = true;
            }
        }

        private void bindSuccess()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();
            string queryStr = "SELECT quantity, dateTime, redemptionID, vouchersName FROM redemption r INNER JOIN vouchers v ON r.id = v.id WHERE redemptionID = '" + Session["redemptionID"] + "' ";
            SqlCommand cmd = new SqlCommand(queryStr, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lbl_quantity.Text = dr["quantity"].ToString();
                lbl_voucherName2.Text = dr["vouchersName"].ToString();
                lbl_quantity2.Text = dr["quantity"].ToString();
                lbl_dateTime.Text = dr["dateTime"].ToString();
                lbl_redemptionID.Text = dr["redemptionID"].ToString();
            }
            conn.Close();
            dr.Close();
            lbl_balance.Text = lbl_ptsLeft.Text;
        }

        private void bindEwallet()
        {
            SqlConnection conn = new SqlConnection(_connStr);
            string queryStr = "SELECT vouchersName, barCode, requiredPts, image, quantity, DATEADD(mm, 1, dateTime) as ExpiryDate, DATEDIFF(day, GETDATE(), DATEADD(mm, 1, dateTime)) AS DateDiff FROM Redemption r INNER JOIN Vouchers v ON r.id = v.id WHERE r.username = '" + Session["Login"] + "' ORDER BY expiryDate ";

            SqlCommand cmd = new SqlCommand(queryStr, conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DataList2.DataSource = dt;
            DataList2.DataBind();
        }

        protected void btn_eWallet_Click(object sender, EventArgs e)
        {
            nav.Visible = true;
            redemptionPanel.Visible = false;
            redemptionSucessPanel.Visible = false;
            eWalletPanel.Visible = true;
            linkbtn_ewallet.CssClass = "btnlink";
            linkbtn_catalog.CssClass = "";
        }

        protected void linkbtn_ewallet_Click(object sender, EventArgs e)
        {
            redemptionPanel.Visible = false;
            redemptionSucessPanel.Visible = false;
            eWalletPanel.Visible = true;
            DataList1.Visible = false;

            linkbtn_ewallet.CssClass = "linkbtn";
            linkbtn_catalog.CssClass = "";

        }

        protected void linkbtn_catalog_Click(object sender, EventArgs e)
        {
            redemptionPanel.Visible = false;
            redemptionSucessPanel.Visible = false;
            eWalletPanel.Visible = false;
            DataList1.Visible = true;

            linkbtn_catalog.CssClass = "linkbtn";
            linkbtn_ewallet.CssClass = "";
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
            {
                Label lbl_vouchersName = (Label)e.Item.FindControl("Label5");
                string lbl = lbl_vouchersName.Text;
                lbl = lbl.Substring(0, 3);
                lbl_vouchersName.Text = lbl.ToString();
            }
        }
    }
}

