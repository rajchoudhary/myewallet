using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class retailer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    string user;int i;
    string pa;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnUser_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void TxtUserName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string q = "select * from retailer where UserName ='" + TxtUserName.Text + "' and Pass= '" + TxtPassword.Text + "'";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Session["i"] = Convert.ToInt32(dr["RetailerRefID"]);
            Session["user"] = TxtUserName.Text;
            Session["pa"] = TxtPassword.Text;
            LblRetailerLoginStatus.Text = "Login Successful";
            Response.Redirect("Retailerhome.aspx");
        }
        else
        {
            LblRetailerLoginStatus.Text = "Incorrect username or password";
        }
        dr.Close();
        con.Close();
    }
}