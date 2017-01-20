using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public partial class Notification : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["SampleConnection"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    SqlCommand cmd2 = new SqlCommand();
    SqlCommand cmd3 = new SqlCommand();
    SqlCommand cmd4 = new SqlCommand();
    int testvalue;int c, l,limit,reset;
    protected void Page_Load(object sender, EventArgs e)
    {
        testvalue = Convert.ToInt32(Session["id"]);
        if(!IsPostBack)
        {
            showdetails();
        }
    }

    private void showdetails()
    {
        string s = "select * from notificationdata where userId=" + testvalue + "";
        cmd2 = new SqlCommand(s, con);
        con.Open();
        SqlDataReader dr = cmd2.ExecuteReader();
        if (dr.Read())
        {
            c = Convert.ToInt32(dr["count"]);
            l = Convert.ToInt32(dr["lastseen"]);
            limit = l + c;
        }
        con.Close();

        string sh = "select message  from notification where NotificationNo > " + l + " and NotificationNo<= "+limit+"";
        cmd = new SqlCommand(sh, con);
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        Gvnotification.DataSource = dt;
        Gvnotification.DataBind();
        con.Close();

        reset = 0;

        string b = "update notificationdata set count="+reset+" where userId=" + testvalue + "";
        cmd3 = new SqlCommand(b, con);
        con.Open();
        cmd3.ExecuteNonQuery();
        con.Close();

        string p = "update notificationdata set lastseen=" + limit + " where userId=" + testvalue + "";
        cmd4 = new SqlCommand(p, con);
        con.Open();
        cmd4.ExecuteNonQuery();
        con.Close();
    }

    
}