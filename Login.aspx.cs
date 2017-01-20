using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    string U = "";
    string P = "";
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.TxtPassword.Attributes.Add("onkeypress", "button_click(this,'" + this.BtnLogin.ClientID + "')");

    }

    protected void BtnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string q="select * from customer where MobileNo ='"+TxtMobileNo.Text+"' and pass= '"+TxtPassword.Text+"'";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Session["id"] = Convert.ToInt32(dr["UserRefID"]);
            Session["U"] = TxtMobileNo.Text;
            Session["P"] = TxtPassword.Text;
            Response.Redirect("Home.aspx");
        }
        else
        {
            LblLoginStatus.Text = "Incorrect username or password";
        }
        dr.Close();
        con.Close();
    }

    protected void BtnRetailer_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailer.aspx");
    }
}