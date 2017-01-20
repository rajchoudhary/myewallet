using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class debithistory : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            showdetails();
        }
    }

    private void showdetails()
    {
        string q = "select Transact_RefId,User_RefId,Amount,Date from receive_amount where retailer='" + Session["refname"] +"' order by Transact_RefId desc ";

        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GvDebithistory.DataSource = dt;
        GvDebithistory.DataBind();
        con.Close();
    }
}