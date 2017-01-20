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

public partial class Transfer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();
    SqlCommand cmd4 = new SqlCommand();
    SqlCommand cmd5 = new SqlCommand();
    SqlCommand cmd6 = new SqlCommand();
    SqlCommand cmd7 = new SqlCommand();
    SqlCommand cmd8 = new SqlCommand();
    SqlCommand cmd9 = new SqlCommand();
    SqlCommand cmd10 = new SqlCommand();
    SqlCommand cmd11 = new SqlCommand();
    SqlCommand cmd12 = new SqlCommand();
    SqlCommand cmd13 = new SqlCommand();
    string tname; string receiver; string send; string UnSend; String UnRec; string time, otp1 = "";int limit;int reverse = 0;
    int flag = 0; int incorrect;int t;string r;string rec;string recname;int j;int i;int transactionp=0;int updater;int cou; int otp=0;int otpgen;string h1,h2, h;int copy;

    protected void Page_Load(object sender, EventArgs e)
    {
        LblTAvBal.Text = "Available Balance";
        //LblAvbal.Text = Session["b"].ToString();
        tname = Session["U"].ToString();
        if (!IsPostBack)
        {
            int l = Convert.ToInt32(Session["id"]);
            string bal = "select * from customer where UserRefId= " + l + "";
            cmd7 = new SqlCommand(bal, con);
            con.Open();
            SqlDataReader dr = cmd7.ExecuteReader();
            if(dr.Read())
            { 
                LblAvbal.Text = dr["Balance"].ToString();
            }
            con.Close();

            TransferToBeneficiary();
            notificationcounter();

        }
    }

    protected void BtnSendClear_Click(object sender, EventArgs e)
    {
        Session["otpgen"] = 0;
        Session["otp"] = "";
        Random rnd = new Random();
        otp = rnd.Next(100000, 999999);
        Session["otp"] = otp.ToString();
        otp1 = otp.ToString();
        var client = new WebClient();
        string sendotp = "http://2factor.in/API/V1/e0197f54-d7d3-11e6-afa5-00163ef91450/SMS/" + tname + "/" + otp + " ";
        var content = client.DownloadString(sendotp);
        Session["otpgen"] = 1;
        LblVal.Text = "OTP Sent to Mobile";
    }

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }

    protected void BtnReceiver_Click(object sender, EventArgs e)
    {
        
        if (TxtTransferMobile.Text != "")
        {
            string q = "Select * from customer where MobileNo= " + TxtTransferMobile.Text + " ";
            cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                LblTrMobileNo.Text = "Mobile No: ";
                LblTrName.Text = "Name: ";
                LblTrAge.Text = "Age: ";
                LblTrGender.Text = "Gender: ";
                LblShTrMobileNo.Text = dr["MobileNo"].ToString();
                receiver = dr["Name"].ToString();
                //LblShTrName.Text = dr["Name"].ToString();
                LblShTrName.Text = receiver;
                LblShTrAge.Text = dr["Age"].ToString();
                LblShTrGender.Text = dr["Gender"].ToString();
            }
            else
            {
                LblVal.Text = "incorrect mobile no";
            }
            dr.Close();
            con.Close();
        }
        else
        {
            LblVal.Text = "mobile no is missing";
        }
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        if (TxtTransferMobile.Text != "" && TxtAmount.Text != "" && TxtTransact.Text != "")
        {
            string q = "Select * from customer where MobileNo= " + TxtTransferMobile.Text + " ";
            cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                LblTrMobileNo.Text = "Mobile No: ";
                LblTrName.Text = "Name: ";
                LblTrAge.Text = "Age: ";
                LblTrGender.Text = "Gender: ";
                LblShTrMobileNo.Text = dr["MobileNo"].ToString();
                receiver = dr["Name"].ToString();
                //LblShTrName.Text = dr["Name"].ToString();
                LblShTrName.Text = receiver;
                LblShTrAge.Text = dr["Age"].ToString();
                LblShTrGender.Text = dr["Gender"].ToString();
            }
            else
            {
                LblVal.Text = "incorrect mobile no"; incorrect = 1;
            }
            dr.Close();
            con.Close();
            if(Convert.ToInt32(Session["otpgen"])==1)
            {
                h2 = Session["otp"].ToString();
            }


            string p = "Select * from customer where MobileNo='" + tname + "' ";
            cmd2 = new SqlCommand(p, con);
            con.Open();
            SqlDataReader pr = cmd2.ExecuteReader();
            if (pr.Read() && incorrect != 1)
            {
                h1 = pr["TransactPass"].ToString();
                
                if (h2 == TxtTransact.Text || h1==TxtTransact.Text)
                {
                    transactionp = 1;
                    int insufficient; int asked;
                    i = Convert.ToInt32(pr["UserRefID"]);
                    insufficient = Convert.ToInt32(pr["Balance"].ToString());copy = insufficient;
                    asked = Convert.ToInt32(TxtAmount.Text);
                    if (insufficient < asked)
                    {
                        LblVal.Text = "insufficient Balance";
                        flag = 1;
                        con.Close();
                    }
                    else
                    {
                        int rm;
                        send = pr["Name"].ToString();
                        rm = Convert.ToInt32(pr["Balance"].ToString()) - Convert.ToInt32(TxtAmount.Text);
                        string qz = "update customer set Balance = " + rm + " where MobileNo = '" + tname + "' ";
                        cmd3 = new SqlCommand(qz, con);
                        con.Close();
                        con.Open();
                        cmd3.ExecuteNonQuery();
                        con.Close();
                    }
                }
                else if (TxtTransact.Text == "")
                {
                    LblVal.Text = "Enter the OTP ";
                    con.Close();
                }
                else if (h2 != TxtTransact.Text)
                {
                    LblVal.Text = "Incorrect OTP ";
                    con.Close();
                }
            }

            else
            {
                LblVal.Text = "Incorrect Mobile No"; con.Close();

            }



            string qr = "select * From customer where MobileNo='" + TxtTransferMobile.Text + "'";
            cmd = new SqlCommand(qr, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (transactionp == 1)
                {
                    if (flag == 1)
                    {
                        LblVal.Text = "insufficient Balance";
                        con.Close();
                    }
                    else
                    {
                        int am; time = DateTime.Now.ToString("dd-MM-yyyy");
                        j = Convert.ToInt32(dr["UserRefID"]);
                        am = Convert.ToInt32(dr["Balance"].ToString()) + Convert.ToInt32(TxtAmount.Text);
                        if (am < 2500)
                        {
                            string qr1 = "update customer set Balance = " + am + " where MobileNo = '" + TxtTransferMobile.Text + "' ";
                            SqlCommand cmd1 = new SqlCommand(qr1, con);
                            con.Close();
                            con.Open();
                            cmd1.ExecuteNonQuery();
                            con.Close();
                            LblVal.Text = "Money Sent";
                        }
                        else
                        {
                            LblVal.Text = "Account Limit Exceeded";
                            //rm = Convert.ToInt32(pr["Balance"].ToString()) - Convert.ToInt32(TxtAmount.Text);
                            string qz = "update customer set Balance = " + copy + " where MobileNo = '" + tname + "' ";
                            cmd3 = new SqlCommand(qz, con);
                            con.Close();
                            con.Open();
                            cmd3.ExecuteNonQuery();
                            con.Close();

                            reverse = 1;
                        }
                    }

                }
                else
                    con.Close();
            }
            else
            {
                LblVal.Text = "Incorrect mobile No"; flag = 1;
            }
            dr.Close();

            {
                if (flag == 0 && transactionp == 1 && reverse==0)
                {
                    string h = "insert into transact values('" + send + "','" + receiver + "'," + TxtAmount.Text + ",'" + time + "'," + i + "," + j + ")";
                    cmd4 = new SqlCommand(h, con);
                    con.Open();
                    cmd4.ExecuteNonQuery();
                    con.Close();

                    string y = "select * from notificationdata where userId=" + j + " ";
                    cmd9 = new SqlCommand(y, con);
                    con.Open();
                    SqlDataReader tr = cmd9.ExecuteReader();
                    if (tr.Read())
                    {
                        updater = Convert.ToInt32(tr["lastseen"]);
                        cou = Convert.ToInt32(tr["count"]);
                    }
                    con.Close();
                    string k = "update notificationdata set count=count+1 where userId=" + j + "";
                    cmd8 = new SqlCommand(k, con);
                    con.Open();
                    cmd8.ExecuteNonQuery();
                    con.Close();

                    int re = Convert.ToInt32(TxtAmount.Text);
                    string z = " " + send + " sent Rs " + re + " to you";
                    updater = updater + cou + 1;
                    string v = "insert into notification values(" + updater + ",'" + z + "')";
                    cmd10 = new SqlCommand(v, con);
                    con.Open();
                    cmd10.ExecuteNonQuery();
                    con.Close();
                }
                flag = 0;
            }
            //Response.Redirect("Transfer.aspx");
        }
        else
        {
            LblVal.Text = "one or more fields empty";
        }
    }

    protected void BtnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("history.aspx");
    }

    protected void BtnMoneySent_Click(object sender, EventArgs e)
    {
        Response.Redirect("sent.aspx");
    }

    protected void BtnBeneficiary_Click(object sender, EventArgs e)
    {
        Response.Redirect("beneficiary.aspx");
    }

    private void TransferToBeneficiary()
    {
        string t = "Select beneficiary from contact where person = '" + Session["HistoryName"].ToString() + "'";
        cmd5 = new SqlCommand(t, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd5);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvBenTransfer.DataSource = dt;
        GvBenTransfer.DataBind();
        con.Close();
    }



    protected void btnSend1_Click(object sender, EventArgs e)
    {

    }

    protected void BtnTest_Click(object sender, EventArgs e)
    {
        
        foreach (GridViewRow row in GvBenTransfer.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("CbSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    TextBox txt = (row.Cells[2].FindControl("TxtBoxAmount") as TextBox);
                    Label lbl = (row.Cells[1].FindControl("LblReceiver") as Label);
                    Label lbls = (row.Cells[3].FindControl("LblStat") as Label);
                    if (txt.Text != "")
                    {
                        t = Convert.ToInt32(txt.Text.ToString());
                        r = lbl.Text.ToString();
                        string p = "Select * from customer where MobileNo='" + tname + "' "; 
                        cmd2 = new SqlCommand(p, con);
                        con.Open();
                        SqlDataReader pr = cmd2.ExecuteReader(); flag = 0;
                        if (pr.Read())
                        {
                            if (Convert.ToInt32(Session["otpgen"]) == 1)
                            {
                                 h1 = Session["otp"].ToString();
                                 h = otp1;
                            }
                            string h2 = Session["transactp"].ToString();
                            string tpass = pr["TransactPass"].ToString();
                            if (h1 == TxtTransaction.Text.ToString() || h2== TxtTransaction.Text.ToString())
                            {
                                transactionp = 1;
                                int insufficient; int asked;
                                insufficient = Convert.ToInt32(pr["Balance"].ToString());
                                asked = t;
                                if (insufficient < asked)
                                {
                                    lbls.Text = "insufficinet Balance";
                                    flag = 1;
                                    con.Close();
                                }
                                else
                                {
                                    flag = 0;
                                    int rm;
                                    send = pr["Name"].ToString();
                                    rm = Convert.ToInt32(pr["Balance"].ToString()) - t;copy = Convert.ToInt32(pr["Balance"]);
                                    string qz = "update customer set Balance = " + rm + " where MobileNo = '" + tname + "' ";
                                    cmd3 = new SqlCommand(qz, con);
                                    con.Close();
                                    con.Open();
                                    cmd3.ExecuteNonQuery();
                                    con.Close();
                                }
                            }
                            else if (TxtTransaction.Text == "")
                            {
                                LblVal.Text = "Enter OTP";
                                con.Close();
                            }
                            else if (tpass != TxtTransaction.Text)
                            {
                                LblVal.Text = "Incorrect OTP";
                                con.Close();
                            }
                        }
                        string get = "select * from customer where Name='" + r + "'";
                        cmd6 = new SqlCommand(get, con);
                        con.Open();
                        SqlDataReader cr = cmd6.ExecuteReader();
                        if (cr.Read())
                        {
                            rec = cr["MobileNo"].ToString();
                        }
                        con.Close();
                        int recid;
                        string qr = "select * From customer where MobileNo='" + rec + "'";
                        cmd = new SqlCommand(qr, con);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (dr.Read() && flag == 0 && transactionp == 1)
                        {
                            limit = 0;
                            int am; time = DateTime.Now.ToString("dd-MM-yyyy");
                            recname = dr["Name"].ToString(); Session["recid"] = dr["UserRefID"];
                            am = Convert.ToInt32(dr["Balance"].ToString()) + t;
                            if (am < 25000)
                            {
                                limit = 1;
                                string qr1 = "update customer set Balance = " + am + " where MobileNo = '" + rec + "' ";
                                SqlCommand cmd1 = new SqlCommand(qr1, con);
                                con.Close();
                                con.Open();
                                cmd1.ExecuteNonQuery();
                                con.Close();
                                lbls.Text = "Money Sent";
                            }
                            else
                            {
                                limit = 0;
                                lbls.Text = "Account Limit Exceeded";

                                //money back to sender
                                int rm;
                                rm = copy;
                                string qz = "update customer set Balance = " + rm + " where MobileNo = '" + tname + "' ";
                                cmd12 = new SqlCommand(qz, con);
                                con.Close();
                                con.Open();
                                cmd12.ExecuteNonQuery();
                                con.Close();
                                reverse = 1;
                            }
                        }
                        if (flag == 0 && transactionp == 1 && limit==1 && reverse==0)
                        {
                            string h = "insert into transact values('" + send + "','" + recname + "'," + t + ",'" + time + "'," + Session["id"] + "," + Session["recid"] + ")";
                            cmd4 = new SqlCommand(h, con);
                            con.Open();
                            cmd4.ExecuteNonQuery();
                            con.Close();

                            string y = "select * from notificationdata where userId=" + Session["recid"] + " ";
                            cmd9 = new SqlCommand(y, con);
                            con.Open();
                            SqlDataReader tr = cmd9.ExecuteReader();
                            if (tr.Read())
                            {
                                updater = Convert.ToInt32(tr["lastseen"]);
                                cou = Convert.ToInt32(tr["count"]);
                            }
                            con.Close();
                            string k = "update notificationdata set count=count+1 where userId=" + Session["recid"] + "";
                            cmd8 = new SqlCommand(k, con);
                            con.Open();
                            cmd8.ExecuteNonQuery();
                            con.Close();

                            int re = Convert.ToInt32(t);
                            string z = " " + send + " sent Rs " + re + " to you";
                            updater = updater + cou + 1;
                            string v = "insert into notification values(" + updater + ",'" + z + "')";
                            cmd10 = new SqlCommand(v, con);
                            con.Open();
                            cmd10.ExecuteNonQuery();
                            con.Close();

                            int cv = Convert.ToInt32(Session["id"]);
                            string bal = "select * from customer where UserRefId= " + cv + "";
                            cmd13 = new SqlCommand(bal, con);
                            con.Open();
                            SqlDataReader zr = cmd13.ExecuteReader();
                            if (zr.Read())
                            {
                                LblAvbal.Text = zr["Balance"].ToString();
                            }
                            con.Close();
                        }

                    }

                    else
                    {
                        lbls.Text = "Enter the amount";
                    }

                }
            }
        }
        //System.Threading.Thread.Sleep(5000);
        //Response.Redirect("Transfer.aspx");

    }

    private void notificationcounter()
    {
        string q = "select * from notificationdata where userId=" + Session["id"] + "";
        cmd11 = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd11.ExecuteReader();
        if (dr.Read())
        {
            BtnNotification.Text = dr["count"].ToString();
        }
        con.Close();
    }

    protected void TxtTransaction_TextChanged(object sender, EventArgs e)
    {

    }

    protected void BtnGenerateOtp_Click(object sender, EventArgs e)
    {
        Session["otpgen"]= 0;
        Session["otp"] = "";
        Random rnd = new Random();
        otp = rnd.Next(100000, 999999);
        Session["otp"] = otp.ToString();
        otp1 = otp.ToString();
        var client = new WebClient();
        string sendotp = "http://2factor.in/API/V1/e0197f54-d7d3-11e6-afa5-00163ef91450/SMS/" + tname + "/" + otp + " ";
        var content = client.DownloadString(sendotp);
        Session["otpgen"] = 1;
        LblVal.Text = "OTP Sent to Mobile";
    }
}