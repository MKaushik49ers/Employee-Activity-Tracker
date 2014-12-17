using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        string LName="", FName = "" , TeamName = "";
        string userid = Convert.ToString(Session["UserID"]);
        string DRweek = "";
        string DRperiod = "";
        string DRyear = "";
        if (Session["DropPeriod"] != null)
            DRperiod = (Session["DropPeriod"].ToString());
        if (Session["DropYear"] != null)
            DRyear = (Session["DropYear"].ToString());
        if (Session["DropWeek"] != null)
            DRweek = (Session["DropWeek"].ToString()); 
        if ( Session["TeamName"] != null)
            TeamName = Convert.ToString(Session["TeamName"]);
        if (Session["FName"] != null)
            FName = Convert.ToString(Session["FName"]);
        if (Session["LName"] != null)
            LName = Convert.ToString(Session["LName"]);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);

        if (DRperiod == "All")
        {
            //  int Year = Convert.ToInt32(Session["Year"]);

            SqlCommand cmd1 = new SqlCommand(@"select TeamName,ActivityName,ActivityDuration,td.Tesco_Date
                                               from dbo.tbl_ActivityDetails AD ,dbo.tbl_Activity AC , dbo.tbl_Team T,tbl_TescoCalender td
                                               where AD.UserID in (select UserID from dbo.tbl_UserDetails where FirstName = '" + FName+"' and LastName = '"+ LName + "') and AD.Tesco_Date = td.Tesco_Date  and td.Tesco_Year =" + DRyear + " and AD.TeamID in (select TeamID from dbo.tbl_Team Where TeamName = '" + TeamName 
                                               + "' )and AC.ActivityID=AD.ActivityID and AD.TeamID = T.TeamID", connection);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataTable dtdata = new DataTable();
            da1.Fill(dtdata);
            if (dtdata.Rows.Count == 0)
            {
                int count = 0;
                count++;
                Session["countval"] = count;
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Data Available!!');", true);

                Response.AppendHeader("Refresh", "2;URL=ReportPage.aspx");

            }

            GridView1.DataSource = ds1;
            GridView1.DataBind();

        }
        else if (DRweek == "All" && DRperiod != "All")
        {
            SqlCommand cmd1 = new SqlCommand("select t1.ActivityName, t2.ActivityDuration, t3.Tesco_Date from tbl_Activity t1,tbl_ActivityDetails t2,tbl_TescoCalender t3,tbl_UserDetails t4,tbl_Team t5 where t1.ActivityID = t2.ActivityID and t2.Tesco_Date = t3.Tesco_Date and t2.TeamID = t5.TeamID and t5.TeamID = t4.TeamID and Tesco_Year =" + DRyear + " and t3.Tesco_Period = " + DRperiod + " and t4.FirstName = " + "'" + FName + "'" + " AND t4.LastName = " + "'" + LName + "'" + " group by t1.ActivityName, t2.ActivityDuration, t3.Tesco_Date order by t3.Tesco_Date", connection);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataTable dtdata = new DataTable();
            da1.Fill(dtdata);
            if (dtdata.Rows.Count == 0)
            {
                int count = 0;
                count++;
                Session["countval"] = count;
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Data Available!!');", true);

                Response.AppendHeader("Refresh", "2;URL=ReportPage.aspx");

            }

            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }

        else
        {
            SqlCommand cmd1 = new SqlCommand(@"select t1.ActivityName, t2.ActivityDuration, t3.Tesco_Date 
                                from tbl_Activity t1,tbl_ActivityDetails t2,tbl_TescoCalender t3,tbl_UserDetails t4,tbl_Team t5 
                                where t1.ActivityID = t2.ActivityID and t2.Tesco_Date = t3.Tesco_Date and t2.TeamID = t5.TeamID 
                                and t5.TeamID = t4.TeamID and Tesco_Year =" + DRyear + " and t3.Tesco_Week=" + DRweek 
                                + " and t3.Tesco_Period = " + DRperiod + " and t4.FirstName = " + "'" + FName + "'" 
                                + " AND t4.LastName = " + "'" + LName + "'" 
                                + " group by t1.ActivityName, t2.ActivityDuration, t3.Tesco_Date order by t3.Tesco_Date", connection);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            DataTable dtdata = new DataTable();
            da1.Fill(dtdata);
            if (dtdata.Rows.Count == 0)
            {
                int count = 0;
                count++;
                Session["countval"] = count;
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Data Available!!');", true);

                Response.AppendHeader("Refresh", "2;URL=ReportPage.aspx");

            }
            GridView1.DataSource = ds1;
            GridView1.DataBind();
        }
      
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["countval"] = 0;
    }
}
