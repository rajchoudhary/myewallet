using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class retailerhistory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            showdetails();
        }

    }

    private void showdetails()
    {
       
        string q = "select Transact_RefId,User_RefId,Amount,Date from sent_amount  where retailer='" + Session["refname"] + "'order by Transact_RefId DESC";
       
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvHistory.DataSource = dt;
        GvHistory.DataBind();
        con.Close();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerhome.aspx");
    }

    protected void BtnCustomers_Click(object sender, EventArgs e)
    {
        Response.Redirect("customers.aspx");
    }

    protected void BtnFlushBalance_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerTransfer.aspx");
    }

    protected void BtnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerhistory.aspx");
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailer.aspx");
    }
}