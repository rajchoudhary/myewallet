using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class senderlogin : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand(); SqlCommand cmd2 = new SqlCommand(); SqlCommand cmd3 = new SqlCommand(); SqlCommand cmd5 = new SqlCommand(); SqlCommand cmd6 = new SqlCommand(); SqlCommand cmd7 = new SqlCommand();
    string no; int bal;int see,se; SqlCommand cmd8 = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        string no = Session["LoginMobile"].ToString();
        LblNumber.Text = "Amount to Send";
        if (!IsPostBack)
        {
            //TransferToBeneficiary();
        }
    }
    protected void BtnSend_Click(object sender, EventArgs e)
    {
        no = Session["LoginMobile"].ToString();
        string s = "update customer set Balance=Balance + " + TxtAmount.Text + " where MobileNo= " + no + "";
        cmd = new SqlCommand(s, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        LblStatus.Text = "Money Sent";
    }

    protected void BtnSend1_Click(object sender, EventArgs e)
    {
        string q = "select * from customer"; //this has to be changed because it's just taking the 1st value and since it matches raj so its working out
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            bal = Convert.ToInt32(dr["Balance"]);
        }
        con.Close();
        no = Session["LoginMobile"].ToString();
        if (bal > Convert.ToInt32(TxtPay.Text))
        {
            string id = Session["user"].ToString();
            string check = "select * from retailer where UserName='" + id + "'";
            cmd7 = new SqlCommand(check, con);
            con.Open();
            SqlDataReader or = cmd7.ExecuteReader();
            if (or.Read())
            {
                see = Convert.ToInt32(or["Balance"]);
            }

            if (see <= 50000)
                {
                    con.Close();
                    string p = "UPDATE Customer set balance= balance-" + TxtPay.Text + " where MobileNo=" + no + "";
                    cmd2 = new SqlCommand(p, con);
                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();


                    string r = "update retailer set Balance= Balance+" + TxtPay.Text + " where UserName='" + id + "'";
                    cmd3 = new SqlCommand(r, con);
                    con.Open();
                    cmd3.ExecuteNonQuery();
                    con.Close();

                    string time;
                    time = DateTime.Now.ToString("dd-MM-yyyy");
                    string up = "insert into receive_amount values(" + Session["loginid"] + "," + TxtPay.Text + ",'" + time + "','" + Session["refname"] + "')";
                    cmd6 = new SqlCommand(up, con);
                    con.Open();
                    cmd6.ExecuteNonQuery();
                    con.Close();
                    LblStatus.Text = " Money has been Debited ";
                }
                else
                {
                    LblStatus.Text = "Wallet Limit exceeded";
                }
            }
        else
        {
            LblStatus.Text = "insufficient balance in users accocunt";
        }

    }



    //private void TransferToBeneficiary()
    //{
    //    string t = "Select beneficiary from contact where senderid = " + Convert.ToInt32(Session["loginid"]) + "";
    //    cmd5 = new SqlCommand(t, con);
    //    con.Open();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd5);
    //    DataTable dt = new DataTable();
    //    da.Fill(dt);
    //    GvBenTransfer.DataSource = dt;
    //    GvBenTransfer.DataBind();
    //    con.Close();
    //}
}

//    protected void Btntransfer_Click(object sender, EventArgs e)
//    {
//        foreach (GridViewRow row in GvBenTransfer.Rows)
//        {
//            if (row.RowType == DataControlRowType.DataRow)
//            {
//                CheckBox chkRow = (row.Cells[0].FindControl("CbSelect") as CheckBox);
//                if (chkRow.Checked)
//                {
//                    TextBox txt = (row.Cells[2].FindControl("TxtBoxAmount") as TextBox);
//                    Label lbl = (row.Cells[1].FindControl("LblReceiver") as Label);
//                    Label lbls = (row.Cells[3].FindControl("LblStat") as Label);
//                    if (txt.Text != "")
//                    {
//                        t = Convert.ToInt32(txt.Text.ToString());
//                        r = lbl.Text.ToString();
//                        string p = "Select * from customer where MobileNo='" + tname + "' ";
//                        cmd2 = new SqlCommand(p, con);
//                        con.Open();
//                        SqlDataReader pr = cmd2.ExecuteReader(); flag = 0;
//                        if (pr.Read())
//                        {
//                            string h1 = Session["otp"].ToString();
//                            string h = otp1;

//                            string tpass = pr["TransactPass"].ToString();
//                            if (/*h1 == TxtTransaction.Text.ToString()*/ 1)
//                            {
//                                transactionp = 1;
//                                int insufficient; int asked;
//                                insufficient = Convert.ToInt32(pr["Balance"].ToString());
//                                asked = t;
//                                if (insufficient < asked)
//                                {
//                                    lbls.Text = "insufficinet Balance";
//                                    flag = 1;
//                                    con.Close();
//                                }
//                                else
//                                {
//                                    flag = 0;
//                                    int rm;
//                                    send = pr["Name"].ToString();
//                                    rm = Convert.ToInt32(pr["Balance"].ToString()) - t;
//                                    string qz = "update customer set Balance = " + rm + " where MobileNo = '" + tname + "' ";
//                                    cmd3 = new SqlCommand(qz, con);
//                                    con.Close();
//                                    con.Open();
//                                    cmd3.ExecuteNonQuery();
//                                    con.Close();
//                                }
//                            }
//                            //else if (TxtTransaction.Text == "")
//                            //{
//                            //    LblVal.Text = "Enter OTP";
//                            //    con.Close();
//                            //}
//                            //else if (tpass != TxtTransaction.Text)
//                            //{
//                            //    LblVal.Text = "Incorrect OTP";
//                            //    con.Close();
//                            //}
//                        }
//                        string get = "select * from customer where Name='" + r + "'";
//                        cmd6 = new SqlCommand(get, con);
//                        con.Open();
//                        SqlDataReader cr = cmd6.ExecuteReader();
//                        if (cr.Read())
//                        {
//                            rec = cr["MobileNo"].ToString();
//                        }
//                        con.Close();
//                        int recid;
//                        string qr = "select * From customer where MobileNo='" + rec + "'";
//                        cmd = new SqlCommand(qr, con);
//                        con.Open();
//                        SqlDataReader dr = cmd.ExecuteReader();
//                        if (dr.Read() && flag == 0 && transactionp == 1)
//                        {

//                            int am; time = DateTime.Now.ToString("dd-MM-yyyy");
//                            recname = dr["Name"].ToString(); Session["recid"] = dr["UserRefID"];
//                            am = Convert.ToInt32(dr["Balance"].ToString()) + t;
//                            string qr1 = "update customer set Balance = " + am + " where MobileNo = '" + rec + "' ";
//                            SqlCommand cmd1 = new SqlCommand(qr1, con);
//                            con.Close();
//                            con.Open();
//                            cmd1.ExecuteNonQuery();
//                            con.Close();
//                            lbls.Text = "Money Sent";
//                        }
//                    }
//}