using MyFYPJBackup.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BackUpProject
{
    public partial class adminUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            // FillDropDownList();
            // }

            //adminCRUD_DAO customer = new adminCRUD_DAO();
            //List<adminCRUD> adminCRUD = new List<adminCRUD>();
            //adminCRUD = customer.getItem();
            //editGV.DataSource = adminCRUD;
            //editGV.DataBind();
            lblError.Text = String.Empty;

            if (!IsPostBack)
            {
                lblResult.Text = Request.QueryString["result"];
            }
            else
            {
                lblResult.Text = String.Empty;
            }

        }


        // private void FillDropDownList()
        //{
        //  string DBConnect = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;

        //DataSet ds = new DataSet();
        //SqlDataAdapter myda = new SqlDataAdapter("select rtype from adminEdit ", DBConnect);
        //myda.Fill(ds);
        //ddlType.DataSource = ds;
        //ddlType.DataValueField = "rtype";
        //ddlType.DataBind();
        //}

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (addNametb.Text == "" && addTypetb.Text == "")
            {

                Response.Write("<script >alert('Please enter name and type')</script >");
                lblError.Text = "Please enter a category and type!";

            }
            else
            {
                adminCRUD_DAO edit = new adminCRUD_DAO();
                edit.AddType(addTypetb.Text, addNametb.Text);
                Response.Redirect("adminUpdate.aspx?result=You have successfully added" + addTypetb);
            }

        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //adminCRUD_DAO edit = new adminCRUD_DAO();
        //edit.deleteType(addTypetb.Text);
        // Response.Redirect("adminUpdate.aspx");
        //Response.Redirect("adminUpdate.aspx?result=You have successfully deleted");
        //lblResult.Text = "You have successfully deleted " + addTypetb.Text;

        //}


        protected void editGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            adminCRUD_DAO edit = new adminCRUD_DAO();
            GridViewRow row = editGV.SelectedRow;

            edit.deleteType(row.Cells[3].Text);
            Response.Redirect("adminUpdate.aspx");
            lblResult.Text = "You have successfully deleted " + addTypetb.Text;
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            // adminCRUD_DAO customer = new adminCRUD_DAO();
            //List<adminCRUD> adminCRUD = new List<adminCRUD>();

            // adminCRUD = customer.getItembyname(searchTb.Text);

            //editGV.DataSource = adminCRUD;
            //editGV.DataBind();

        }

    }
}