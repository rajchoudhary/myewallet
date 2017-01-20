using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class retailerhome : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();string otpnum;string transactpass;string refid, refname;
    protected void Page_Load(object sender, EventArgs e)
    {
        showdetails();
    }
    private void showdetails()
    {
        string q = "Select * from retailer where UserName='" +Session["user"]+ "' and Pass= '" +Session["pa"]+ "' ";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            LblShUsername.Text = dr["UserName"].ToString();
            LblShName.Text = dr["Name"].ToString();
            LblShMobileNo.Text = dr["MobileNo"].ToString();
                                                            Session["otpnum"]= dr["MobileNo"].ToString();
                                                            Session["transactpass"] = dr["Pass"].ToString();
                                                            Session["refid"]= Convert.ToInt32(dr["RetailerRefId"]);
                                                            Session["refname"]= dr["UserName"].ToString();
            LblShAge.Text = dr["Age"].ToString();
            LblShGender.Text = dr["Gender"].ToString();
            LblFunds.Text="Available Balance: "+dr["Balance"]+"";
        }
        dr.Close();
        con.Close();
    }

    protected void BtnCustomers_Click(object sender, EventArgs e)
    {
        Response.Redirect("Customers.aspx");
    }

    protected void BtnFlushBalance_Click(object sender, EventArgs e)
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

    protected void BtnDebit_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerdebit.aspx");
    }

    protected void BtnDebitHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("debithistory.aspx");
    }
}