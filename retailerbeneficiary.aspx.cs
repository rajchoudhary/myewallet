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

public partial class retailerbeneficiary : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand(); SqlCommand cmd1 = new SqlCommand(); SqlCommand cmd2 = new SqlCommand(); SqlCommand cmd3 = new SqlCommand();
    SqlCommand cmd4 = new SqlCommand(); SqlCommand cmd5 = new SqlCommand(); SqlCommand cmd6 = new SqlCommand(); int t, r;
    string p; int otp; string otp1; int otpgen; string h1; int avalbal; string m, n; int u;string h2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Customerdetails();
        }

    }

    private void Customerdetails()
    {
        string g = Session["refname"].ToString();
        //string q = "select UserRefID,MobileNo,Name,Age,Gender,Balance from customer";
        string q = "select * from retailercontact where RetailerName='"+g+"' ";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvCustomers.DataSource = dt;
        GvCustomers.DataBind();
        con.Close();
    }
    protected void BtnGenotp_Click(object sender, EventArgs e)
    {
        otpgen = 0;
        Session["otp"] = "";
        string s = Session["otpnum"].ToString();
        Random rnd = new Random();
        otp = rnd.Next(100000, 999999);
        Session["otp"] = otp.ToString();
        otp1 = otp.ToString();
        var client = new WebClient();
        string sendotp = "http://2factor.in/API/V1/e0197f54-d7d3-11e6-afa5-00163ef91450/SMS/" + s + "/" + otp + " ";
        var content = client.DownloadString(sendotp);
        otpgen = 1;
    }

    protected void BtnAddViewUser_Click(object sender, EventArgs e)
    {
        string y = "select * from customer where MobileNo='" + TxtNumber.Text + "' ";
        cmd4 = new SqlCommand(y, con);
        con.Open();
        SqlDataReader dr = cmd4.ExecuteReader();
        if (dr.Read())
        {
            Label1.Text = "MobileNo";
            Label2.Text = "Name";
            Label3.Text = "Age";
            Label4.Text = "Gender";
            LblAddNo.Text = dr["MobileNo"].ToString();
            LblAddName.Text = dr["Name"].ToString();
            LblAddAge.Text = dr["Age"].ToString();
            LblAddGender.Text = dr["Gender"].ToString();
        }
    }

    protected void BtnAddUser_Click(object sender, EventArgs e)
    {
        string h1 = Session["otp"].ToString();

        string y = "select * from customer where MobileNo='" + TxtNumber.Text + "' ";
        cmd4 = new SqlCommand(y, con);
        con.Open();
        SqlDataReader dr = cmd4.ExecuteReader();
        if (dr.Read())
        {

            m = dr["MobileNo"].ToString();
            n = dr["Name"].ToString();
            u = Convert.ToInt32(dr["UserRefID"]);
            h2 = dr["TransactPass"].ToString(); con.Close();
        }
        
        else
        {
            LblStatus.Text = "Invalid Receiver";
        }
         
        if (TxtAddOtp.Text == h1 || TxtAddOtp.Text == h2)
        {
            int x = Convert.ToInt32(Session["refid"]);
            string g = Session["refname"].ToString();

            string l = " Select * from retailercontact where MobileNo='" + TxtNumber.Text + "' and RetailerName='" + g + "'";
            cmd6 = new SqlCommand(l, con);
            con.Open();
            SqlDataReader pr = cmd6.ExecuteReader();
            if (pr.Read())
            {
                LblStatus.Text = "Beneficiary Already  Exists";
                con.Close();
            }
            else
            {
                con.Close();
                string k = "insert into retailercontact values('" + g + "'," + x + ",'" + n + "','" + m + "'," + u + ")";
                cmd5 = new SqlCommand(k, con);
                con.Open();
                cmd5.ExecuteNonQuery();
                con.Close();
                LblStatus.Text = "Beneficiary Added";
                Response.Redirect("retailerbeneficiary.aspx");
            }
        }
        else
        {
            LblStatus.Text = "Incorrect OTP, Beneficiary Not Added";
        }
       
     }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GvCustomers.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("CbSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    string g = Session["refname"].ToString();
                    Label Lbl = (row.Cells[1].FindControl("LblAdder") as Label);
                    int i = Convert.ToInt32(Session["id"]);
                    string n = Lbl.Text.ToString();
                    string s = "delete from retailercontact where RetailerName = '" + g + "' and Receiver= '" + n + "' ";
                    cmd4 = new SqlCommand(s, con);
                    con.Open();
                    cmd4.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
        Response.Redirect("retailerbeneficiary.aspx");
    }

    protected void BtnAddGenOtp_Click(object sender, EventArgs e)
    {
        if (TxtNumber.Text != "")
        {
            Session["otpgen"] = 0;
            Session["otp"] = "";
            string s = Session["otpnum"].ToString();
            Random rnd = new Random();
            otp = rnd.Next(100000, 999999);
            Session["otp"] = otp.ToString();
            otp1 = otp.ToString();
            var client = new WebClient();
            string sendotp = "http://2factor.in/API/V1/e0197f54-d7d3-11e6-afa5-00163ef91450/SMS/" + TxtNumber.Text + "/" + otp + " ";
            var content = client.DownloadString(sendotp);
            Session["otpgen"] = 1;
        }
        else
        {
            LblStatus.Text = "Enter a Mobile No";
        }
    }
}