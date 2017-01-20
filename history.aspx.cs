using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
public partial class history : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    string HisUser;int r;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            r = Convert.ToInt32(Session["recid"]);
            HisUser = Session["HistoryName"].ToString();
            ShowDetails();
        }
        notificationcounter();
    }

    private void ShowDetails()
    {                                                                                                                                              //replaced below instead of r
        string p = " Select  TransactionsRefID,Sender,Receiver,Amount,Date from transact  where SenderId= " + Session["id"] + " or ReceiverId= " +Session["id"]+ " order by TransactionsRefID DESC";
        cmd = new SqlCommand(p, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvShow.DataSource = dt;
        GvShow.DataBind();
        con.Close();
    }

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("Home.aspx");
    }

    protected void BtnTransfer_Click(object sender, EventArgs e)
    {
        Response.Redirect("Transfer.aspx");
    }

    protected void BtnHistory_Click(object sender, EventArgs e)
    {

    }

    protected void GvShow_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void BtnMoneySent_Click(object sender, EventArgs e)
    {
        Response.Redirect("sent.aspx");
    }

    protected void BtnBeneficiary_Click(object sender, EventArgs e)
    {
        Response.Redirect("beneficiary.aspx");
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string q = "select TransactionsRefID,Sender,Receiver,Amount,Date from transact where Date ='" + TxtDate.Text + "'  order by TransactionsRefID DESC";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvShow.DataSource = dt;
        GvShow.DataBind();
        con.Close();

    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void BtnMoneyReceived_Click(object sender, EventArgs e)
    {
        Response.Redirect("receiver.aspx");
    }

    private void notificationcounter()
    {
        string q = "select * from notificationdata where userId=" + Session["id"] + "";
        cmd2 = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd2.ExecuteReader();
        if (dr.Read())
        {
            BtnNotification.Text = dr["count"].ToString();
        }
        con.Close();
    }
}