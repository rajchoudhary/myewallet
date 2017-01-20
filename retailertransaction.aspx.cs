using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Net;

public partial class retailertransaction : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    int otp1;string otp;string LoginMobile;string pass;int otpgen = 0;string h;int loginid;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        string s="update customer set Balance=Balance + "+TxtAmount.Text+" where MobileNo= "+TxtMobileNo.Text+"";
        cmd = new SqlCommand(s, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        LblStatus.Text = "Money Sent";
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        if(Convert.ToInt32(Session["otpgen"])== 1)
        { 
             h = Session["otp"].ToString();
        }
        string s = "select * from customer where MobileNo= "+TxtLoginMobile.Text+"";
        cmd = new SqlCommand(s, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            pass = dr["TransactPass"].ToString();
            Session["loginid"] = Convert.ToInt32(dr["UserRefID"]);
        }
        con.Close();

        if (TxtOTP.Text==h || TxtOTP.Text==pass)
        {
            Session["LoginMobile"] = TxtLoginMobile.Text.ToString();
            Response.Redirect("senderlogin.aspx");
            
        }

        else
        {
            LblStatus.Text = "Incorrect OTP";
        }
    }

    protected void BtnGenerateOTP_Click(object sender, EventArgs e)
    {
        Session["otpgen"] = 0;
        Session["otp"] = "";
        Random rnd = new Random();
        otp1 = rnd.Next(100000, 999999);
        Session["otp"] = otp1.ToString();
        //otp1 = otp.ToString();
        var client = new WebClient();
        string sendotp = "http://2factor.in/API/V1/e0197f54-d7d3-11e6-afa5-00163ef91450/SMS/" + TxtLoginMobile.Text + "/" + otp1 + " ";
        var content = client.DownloadString(sendotp);
        Session["otpgen"] = 1;
    }
}