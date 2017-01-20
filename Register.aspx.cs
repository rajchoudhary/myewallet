using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Register : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();
    SqlCommand cmd4 = new SqlCommand();
    SqlCommand cmd5 = new SqlCommand();
    int d;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnClear_Click(object sender, EventArgs e)
    {
        TxtMobileNo.Text = "";
        TxtName.Text = "";
        TxtAge.Text = "";
        TxtGender.Text = "";
        TxtPassword.Text = "";
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (TxtMobileNo.Text!="" && TxtName.Text!="" && TxtAge.Text != "" && TxtGender.Text != "" && TxtPassword.Text != "" && TxtTransPassword.Text != "" && TxtQuestion.Text!="" && TxtAnswer.Text!="")
        {
            int a = 1000;
            string check = "select * from customer where MobileNo='" + TxtMobileNo.Text + "'";
            cmd4 = new SqlCommand(check, con);
            con.Open();
            SqlDataReader dr = cmd4.ExecuteReader();
            if (dr.Read())
            {
                Lblstatus.Text = "User Already Exists";
                con.Close();
            }
            else
            {
                con.Close();
                string q = "insert into customer values('" + TxtMobileNo.Text + "','" + TxtName.Text + "'," + TxtAge.Text + ",'" + TxtGender.Text + "','" + TxtPassword.Text + "'," + a + ",'" + TxtTransPassword.Text + "')";
                cmd = new SqlCommand(q, con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Lblstatus.Text = "User Registered";
            }

            string r = "Select * from customer where MobileNo= '" + TxtMobileNo.Text + "' ";
            cmd2 = new SqlCommand(r, con);
            con.Open();
            SqlDataReader lo = cmd2.ExecuteReader();
            if (lo.Read())
            {
                d = Convert.ToInt32(lo["UserRefID"]);
            }
            con.Close();
            int y = d;
            y = y * 10000; int u = 0;
            string l = "insert into notificationdata values(" + d + "," + u + "," + y + ")";
            cmd3 = new SqlCommand(l, con);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();

            string z = "insert into security values('"+TxtMobileNo.Text+"','"+TxtQuestion.Text+"','"+TxtAnswer.Text+"')";
            cmd5 = new SqlCommand(z, con);
            con.Open();
            cmd5.ExecuteNonQuery();
            con.Close();
        }
        else
        {
            Lblstatus.Text = "One Or More Feilds Empty Can't Register";
        }
    }

    protected void TxtMobileNo_TextChanged(object sender, EventArgs e)
    {

    }

    protected void TxtMobileNo_TextChanged1(object sender, EventArgs e)
    {

    }

}