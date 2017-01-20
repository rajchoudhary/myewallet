using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class Beneficiary : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();
    SqlCommand cmd4 = new SqlCommand();
    string ben;
    string per;int exist = 0;int o;
    protected void Page_Load(object sender, EventArgs e)
    {
        per = Session["HistoryName"].ToString();
        o = Convert.ToInt32(Session["id"]);
        if (!IsPostBack)
        {
            ShowDetails();
        }
        notificationcounter();
    }

    private void ShowDetails()
    {
        string sh = "select beneficiary  from contact where Senderid ='" + Session["id"] + "'";
        cmd2 = new SqlCommand(sh, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd2);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvBeneficiary.DataSource = dt;
        GvBeneficiary.DataBind();
        con.Close();
    }

    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        string q = " Select * from customer  where MobileNo ='" + TxtBenNo.Text + "'";
        cmd = new SqlCommand(q, con);
        
        con.Open();
        SqlDataReader dr=cmd.ExecuteReader();
        if(dr.Read())
        {
            LblTrMobileNo.Text = "Mobile No: ";
            LblTrName.Text = "Name: ";
            LblTrAge.Text = "Age: ";
            LblTrGender.Text = "Gender";
            LblShTrMobileNo.Text = dr["MobileNo"].ToString();
            LblShTrName.Text = dr["Name"].ToString();
            ben = dr["Name"].ToString();
            LblShTrAge.Text = dr["Age"].ToString(); 
            LblShTrGender.Text = dr["Gender"].ToString();
            LblStatus.Text = "Beneficiary added";
            con.Close();

            string i = "select * from contact where Senderid='"+Session["id"]+"'and beneficiary='"+ben+"' ";
            cmd3 = new SqlCommand(i, con);
            con.Open();
            SqlDataReader dp = cmd3.ExecuteReader();
            if(dp.Read())
            {
                exist = 1;LblStatus.Text = "Beneficiary already exits";
            }
            con.Close();
            if (exist == 0)
            {
                string qr = "insert into contact values('" + per + "','" + ben + "',"+TxtBenNo.Text+","+o+")";
                cmd1 = new SqlCommand(qr, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                Response.Redirect("beneficiary.aspx");
            }
        }
        
        else
        {
            LblStatus.Text = "Incorrect Mobile NO"; con.Close();
        }
        

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
        Response.Redirect("History.aspx");
    }

    protected void BtnMoneySent_Click(object sender, EventArgs e)
    {
        Response.Redirect("sent.aspx");
    }

    protected void BtnMoneyReceived_Click(object sender, EventArgs e)
    {
        Response.Redirect("receiver.aspx");
    }

    protected void BtnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void BtnDelete_Click(object sender, EventArgs e)
    {
        
    }

    protected void BtnDelete_Click1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GvBeneficiary.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("CheckBox") as CheckBox);
                if (chkRow.Checked)
                { 
                    Label Lbl = (row.Cells[1].FindControl("LblContact") as Label);
                    int i = Convert.ToInt32(Session["id"]);
                    string n = Lbl.Text.ToString();
                    string s = "delete from contact where beneficiary = '" +n+ "' and senderid= " + i + " ";
                    cmd4 = new SqlCommand(s, con);
                    con.Open();
                    cmd4.ExecuteNonQuery();
                    con.Close();
                }
            }            
        }
        Response.Redirect("Beneficiary.aspx");
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