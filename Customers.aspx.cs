using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Customers : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        Customerdetails();
    }

    private void Customerdetails()
    {
        string q = "select UserRefID,MobileNo,Name,Age,Gender,Balance from customer";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvCustomers.DataSource = dt;
        GvCustomers.DataBind();
        con.Close();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string q = "select UserRefID,MobileNo,Name,Age,Gender,Balance from customer where MobileNo ='" + TxtMobileNo.Text + "'";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvCustomers.DataSource = dt;
        GvCustomers.DataBind();
        con.Close();
    }

    protected void btnUserSearch_Click(object sender, EventArgs e)
    {
        string q = "select UserRefID,MobileNo,Name,Age,Gender,Balance from customer where UserRefID ='" + TxtUserRefId.Text + "'";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvCustomers.DataSource = dt;
        GvCustomers.DataBind();
        con.Close();
    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        TxtMobileNo.Text = "";
        Customerdetails();
    }

    protected void BtnRefClear_Click(object sender, EventArgs e)
    {
        TxtUserRefId.Text = "";
        Customerdetails();
    }

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerhome.aspx");
    }

    protected void BtnCustomers_Click(object sender, EventArgs e)
    {
        Response.Redirect("Customers.aspx");
    }

    protected void BtnAddBalance_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerTransfer.aspx");
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void BtnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerhistory.aspx");
    }
}