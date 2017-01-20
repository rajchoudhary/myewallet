using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Home : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    string uname;
    string pass;
    string HistoryName;int b;int transferuserid;string transactp;
    protected void Page_Load(object sender, EventArgs e)
    {
        uname = Session["U"].ToString();
        pass = Session["P"].ToString();
        showdetails();
        notificationcounter();
    }

    private void showdetails()
    {
        string q = "Select * from customer where MobileNo='" + uname + "' and Pass= '" + pass + "' ";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            LblShMobileNo.Text = dr["MobileNo"].ToString();
            LblShFunds.Text =  dr["Balance"].ToString();
                                                            Session["b"] = Convert.ToInt32(dr["Balance"].ToString());
                                                            Session["HistoryName"] = dr["Name"].ToString();
                                                            Session["transferuserid"] =Convert.ToInt32(dr["UserRefID"]);
                                                            Session["transactp"] = dr["TransactPass"].ToString();
            LblShName.Text = dr["Name"].ToString();
            LblShAge.Text= dr["Age"].ToString();
            LblShGender.Text = dr["Gender"].ToString();
            if(dr["Gender"].ToString()=="female" || dr["Gender"].ToString() == "FEMALE"|| dr["Gender"].ToString() == "Female" || dr["Gender"].ToString() == "f" || dr["Gender"].ToString() == "F")
            {
                Imgguy.ImageUrl = "female.png";
            }
            else
            {
                Imgguy.ImageUrl = "guy.png";
            }
        }
        dr.Close();
        con.Close();
    }
    protected void BtnTransfer_Click(object sender, EventArgs e)
    {
        Response.Redirect("Transfer.aspx");
    }

    protected void BtnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("history.aspx");
    }

    protected void BtnMoneySent_Click(object sender, EventArgs e)
    {
        Response.Redirect("sent.aspx");
    }

    protected void BtnMoneyReceived_Click(object sender, EventArgs e)
    {
        Response.Redirect("Receiver.aspx");
    }

    protected void BtnBeneficiary_Click(object sender, EventArgs e)
    {
        Response.Redirect("Beneficiary.aspx");
    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
        //Session.Abandon();
    }

    protected void BtnNotification_Click(object sender, EventArgs e)
    {
        Response.Redirect("Notification.aspx");
    }

    private void notificationcounter()
    {
        string q = "select * from notificationdata where userId=" + Session["id"] + "";
        cmd2 = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd2.ExecuteReader();
        if(dr.Read())
        {
            BtnNotification.Text = dr["count"].ToString();
        }
        con.Close();
    }
}