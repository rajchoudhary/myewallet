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
public partial class CustomerTransfer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand(); SqlCommand cmd1 = new SqlCommand(); SqlCommand cmd2 = new SqlCommand(); SqlCommand cmd3 = new SqlCommand();
    SqlCommand cmd4 = new SqlCommand(); SqlCommand cmd5 = new SqlCommand(); SqlCommand cmd6 = new SqlCommand(); SqlCommand cmd7 = new SqlCommand(); int t, r;string name;
    string p;int otp;string otp1;int otpgen;string h1;int avalbal;string m, n;int u;string tranf;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Customerdetails(); string g = Session["refname"].ToString();
            string i = "Select * from retailer where UserName='" + g + "'";
            cmd7 = new SqlCommand(i, con);
            con.Open();
            SqlDataReader dr = cmd7.ExecuteReader();
            if(dr.Read())
            {
                LblBal.Text="Available Balance is "+dr["Balance"]+"";
            }
        }
    }
    private void Customerdetails()
    {
        string g = Session["refname"].ToString();
        string q = "select * from retailercontact where RetailerName='" + g + "' ";
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
        string g = Session["refname"].ToString();
        string q = "select * from retailercontact where RetailerName='" + g + "' and MobileNo='"+TxtMobileNo.Text+"' ";
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
        string g = Session["refname"].ToString();
        string q = "select * from retailercontact where RetailerName='" + g + "' and UserId="+TxtUserRefId.Text+" ";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvCustomers.DataSource = dt;
        GvCustomers.DataBind();
        con.Close();
    }

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerhome.aspx");
    }

    protected void BtnCustomers_Click(object sender, EventArgs e)
    {
        Response.Redirect("Customers.aspx");
    }

    protected void Btntransfer_Click(object sender, EventArgs e)
    {
        Response.Redirect("CustomerTransfer.aspx");
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void BtnTest_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["otpgen"]) == 1)
        {
             h1 = Session["otp"].ToString();
        }
        string h2 = Session["transactpass"].ToString();
        //string h2 = "";
        if (Txtotp.Text==h1 || Txtotp.Text == h2)
        {
            foreach (GridViewRow row in GvCustomers.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CbSelect") as CheckBox);
                    if (chkRow.Checked)
                    {
                        TextBox txt = (row.Cells[1].FindControl("txtAmount") as TextBox);
                        Label lbl = (row.Cells[2].FindControl("LblAdder") as Label);
                        Label lbls = (row.Cells[3].FindControl("LblStatus") as Label);

                        t = Convert.ToInt32(txt.Text.ToString());
                        r = Convert.ToInt32(lbl.Text);
                        string o =Session["otpnum"].ToString();
                        string j = "select * from retailer where MobileNo=" + o + "";
                        cmd3 = new SqlCommand(j, con);
                        con.Open();
                        SqlDataReader dr = cmd3.ExecuteReader();
                        if(dr.Read())
                        {
                            avalbal = Convert.ToInt32(dr["Balance"]);
                            name = dr["UserName"].ToString();
                        }
                        con.Close();
                        if(avalbal>=t)
                        {
                            string v = "update retailer set Balance=Balance-" + t + " where MobileNo=" + o + "";
                            cmd2 = new SqlCommand(v, con);
                            con.Open();
                            cmd2.ExecuteNonQuery();
                            con.Close();

                            string q = "update customer set balance=balance+" + t + " where UserRefID=" + r + "";
                            cmd = new SqlCommand(q, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            LblStatus.Text = "Balance added to customers";
                            string date = DateTime.Today.ToString("dd-MM-yyyy");

                            p = "insert into sent_amount values( " + r + "," + t + ",'" + date + "','"+name+"')";
                            cmd1 = new SqlCommand(p, con);
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            lbls.Text = "Money Sent";
                        }
                        else
                        {
                            lbls.Text = "Insufficient Balance";
                        }
                    }
                }
            }
            
        }

        else
        {
            LblStatus.Text = "Incorrect OTP";
        }
    }
    protected void BtnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerhistory.aspx");
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {

    }

    protected void BtnSend_Click1(object sender, EventArgs e)
    {

    }

    protected void BtnGenotp_Click(object sender, EventArgs e)
    {
        Session["otpgen"] = 0;
        Session["otp"] = "";
        string s = Session["otpnum"].ToString();
        Random rnd = new Random();
        otp = rnd.Next(100000, 999999);
        Session["otp"] = otp.ToString();
        otp1 = otp.ToString();
        var client = new WebClient();
        string sendotp = "http://2factor.in/API/V1/e0197f54-d7d3-11e6-afa5-00163ef91450/SMS/" + s + "/" + otp + " ";
        var content = client.DownloadString(sendotp);
        Session["otpgen"] = 1;
    }

    //protected void BtnAddViewUser_Click(object sender, EventArgs e)
    //{
    //    string y="select * from customer where MobileNo='"+TxtNumber.Text+"' ";
    //    cmd4 = new SqlCommand(y, con);
    //    con.Open();
    //    SqlDataReader dr = cmd4.ExecuteReader();
    //    if(dr.Read())
    //    {
    //        Label1.Text = "MobileNo";
    //        Label2.Text = "Name";
    //        Label3.Text = "Age";
    //        Label4.Text = "Gender";
    //        LblAddNo.Text = dr["MobileNo"].ToString();
    //        LblAddName.Text = dr["Name"].ToString();
    //        LblAddAge.Text = dr["Age"].ToString();
    //        LblAddGender.Text = dr["Gender"].ToString();
    //    }
    //}

    //protected void BtnAddUser_Click(object sender, EventArgs e)
    //{
    //    string y = "select * from customer where MobileNo='" + TxtNumber.Text + "' ";
    //    cmd4 = new SqlCommand(y, con);
    //    con.Open();
    //    SqlDataReader dr = cmd4.ExecuteReader();
    //    if (dr.Read())
    //    {

    //        m= dr["MobileNo"].ToString();
    //        n= dr["Name"].ToString();
    //        u=Convert.ToInt32(dr["UserRefID"]);
    //    }
    //    con.Close();
    //    int x = Convert.ToInt32(Session["refid"]);
    //    string g = Session["refname"].ToString();

    //    string l = " Select * from retailercontact where MobileNo='" + TxtNumber.Text + "' and RetailerName='"+g+"'";
    //    cmd6 = new SqlCommand(l, con);
    //    con.Open();
    //    SqlDataReader pr = cmd6.ExecuteReader();
    //    if (pr.Read())
    //    {
    //        LblStatus.Text = "Beneficiary Already  Exists";
    //        con.Close();
    //    }
    //    else
    //    {
    //        con.Close();
    //        string k = "insert into retailercontact values('" + g + "'," + x + ",'" + n + "','" + m + "'," + u + ")";
    //        cmd5 = new SqlCommand(k, con);
    //        con.Open();
    //        cmd5.ExecuteNonQuery();
    //        con.Close();
    //    }
    //    Response.Redirect("CustomerTransfer.aspx");
    //}
}