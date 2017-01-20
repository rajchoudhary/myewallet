using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class retailerusertransfer : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();
    int bal;string no;
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void BtnSend_Click(object sender, EventArgs e)
    {
        string q = "select * from customer";
        cmd = new SqlCommand(q, con);
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            bal = Convert.ToInt32(dr["Balance"]);
        }
        con.Close();
        no = Session["LoginMobile"].ToString();
        if (bal> Convert.ToInt32(TxtPay.Text))
        {
            string p = "UPDATE Customer set balance= balance-" + TxtPay.Text + " where MobileNo=" + no + "";
            cmd2 = new SqlCommand(p, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            string id = Session["user"].ToString();
            string r = "update retailer set Balance= Balance+" + TxtPay.Text + " where UserName='" + id + "'";
            cmd3 = new SqlCommand(r, con);
            con.Open();
            cmd3.ExecuteNonQuery();
            con.Close();
        }
        
    }
}