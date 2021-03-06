﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class receiver : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    string MoneyReceivedReceiver;
    protected void Page_Load(object sender, EventArgs e)
    {
        MoneyReceivedReceiver = Session["HistoryName"].ToString();
        string p = " Select  TransactionsRefID,Sender,Receiver,Amount,Date  from transact where ReceiverId=" + Session["id"] + "  order by TransactionsRefID DESC ";
        cmd1 = new SqlCommand(p, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd1);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvReceived.DataSource = dt;
        GvReceived.DataBind();
        con.Close();

        notificationcounter();
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string q = " Select  TransactionsRefID,Sender,Receiver,Amount,Date from transact where Sender ='" + TxtSenderName.Text+"' and ReceiverId="+Session["id"]+ "  order by TransactionsRefID DESC ";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvReceived.DataSource = dt;
        GvReceived.DataBind();
        con.Close();
    }

    protected void BtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
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

    protected void BtnBeneficiary_Click(object sender, EventArgs e)
    {
        Response.Redirect("beneficiary.aspx");
    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
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