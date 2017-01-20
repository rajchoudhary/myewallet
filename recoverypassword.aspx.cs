using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class recoverypassword : System.Web.UI.Page
{
    string answer;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();int changepassword;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        if (TxtMobileNo.Text != "")
        {
            string s = "select * from security where MobileNo='" + TxtMobileNo.Text + "'";
            cmd = new SqlCommand(s, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                LblQuestion.Text = dr["SecurityQuestion"].ToString();
                answer = dr["Answer"].ToString();
            }
            con.Close();
        }
        else
        {
            LblStatus.Text = "Enter the Mobile No";
        }
    }

    protected void BtnEnter_Click(object sender, EventArgs e)
    {
        if (TxtMobileNo.Text != "")
        {
            string s = "select * from security where MobileNo='" + TxtMobileNo.Text + "'";
            cmd = new SqlCommand(s, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                answer = dr["Answer"].ToString();
            }
            if (answer == TxtAnswer.Text)
            {
                changepassword = 1;
                LblStatus.Text = "answer matched change the password now";
            }
            else
            {
                LblStatus.Text = "The answer entered is incorrect";
            }

            con.Close();
        }
        else
        {
            LblStatus.Text = "Enter the Mobile No";
        }
    }

    protected void BtnChange_Click(object sender, EventArgs e)
    {
        if (TxtMobileNo.Text != "")
        {
            string s = "select * from security where MobileNo='" + TxtMobileNo.Text + "'";
            cmd = new SqlCommand(s, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                answer = dr["Answer"].ToString();
            }
            if (answer == TxtAnswer.Text)
            {
                if (TxtChangePassword.Text == TxtConfirmPassword.Text)
                {
                    con.Close();
                    string p = "update customer set pass='" + TxtConfirmPassword.Text + "' where MobileNo='" + TxtMobileNo.Text + "' ";
                    cmd1 = new SqlCommand(p, con); con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    LblStatus.Text = "password changed";
                }
                else
                {
                    LblStatus.Text = "Passwords Don't Match";
                }
            }
            else
            {
                LblStatus.Text = "The Answer Entered is Incorrect";
            }
            
        }
        else
        {
            LblStatus.Text = "Enter the Mobile No";
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        
    }

    protected void BtnBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}