using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class retailerdebit : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd1 = new SqlCommand();
    int t, r; string p;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Customerdetails();
        }
    }

    private void Customerdetails()
    {
        string q = "select UserRefID,MobileNo,Name,Age,Gender,Balance from customer";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvDebit.DataSource = dt;
        GvDebit.DataBind();
        con.Close();
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in GvDebit.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("CbSelect") as CheckBox);
                if (chkRow.Checked)
                {
                    TextBox txt = (row.Cells[1].FindControl("TxtRemoveAmount") as TextBox);
                    Label lbl = (row.Cells[2].FindControl("LblRemove") as Label);

                    t = Convert.ToInt32(txt.Text.ToString());
                    r = Convert.ToInt32(lbl.Text);

                    string q = "update customer set balance=balance-" + t + " where UserRefID=" + r + "";
                    cmd = new SqlCommand(q, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //LblStatus.Text = "Balance added to customers";
                    string date = DateTime.Today.ToString("dd-MM-yyyy");
                    p = "insert into receive_amount values( " + r + "," + t + ",'" + date + "')";
                    cmd1 = new SqlCommand(p, con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }

    protected void BtnSearch_Click(object sender, EventArgs e)
    {
        string q = "select UserRefID,MobileNo,Name,Age,Gender,Balance from customer where MobileNo ='" + TxtMobileNo.Text + "'";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvDebit.DataSource = dt;
        GvDebit.DataBind();
        con.Close();
    }

    protected void btnUserSearch_Click(object sender, EventArgs e)
    {
        string q = "select UserRefID,MobileNo,Name,Age,Gender,Balance from customer where UserRefID ='" + TxtUserRefId.Text + "'";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvDebit.DataSource = dt;
        GvDebit.DataBind();
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


    protected void BtnHistory_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerhistory.aspx");
    }

    protected void BtnLogout_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }

    protected void BtnDebit_Click(object sender, EventArgs e)
    {
        Response.Redirect("retailerdebit.aspx");
    }
}