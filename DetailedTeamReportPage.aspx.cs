using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList ListedItemssx = new ArrayList();
        ArrayList ListedItems = (ArrayList)Session["ListBoxValues"];
        string ActivityTeams = string.Empty;
        for (int j = 0; j < ListedItems.Count; j++)
        {
            string jkdjk =Convert.ToString(ListedItems[j]);
            ActivityTeams = jkdjk + "','" + ActivityTeams;

        }
        string LName="", FName = "";
        if (Session["FName"] != null)
            FName = Convert.ToString(Session["FName"]);
        if (Session["LName"] != null)
            LName = Convert.ToString(Session["LName"]);
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
        if (Session["FName"] != null)
            FName = Convert.ToString(Session["FName"]);
        if (Session["LName"] != null)
            LName = Convert.ToString(Session["LName"]);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);



        if (DRperiod == "All")
        {
            //  int Year = Convert.ToInt32(Session["Year"]);

            SqlCommand cmd1 = new SqlCommand(@"select t3.TeamName, t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration 
                                                from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, 
                                                tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID 
                                                and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID and 
                                                t4.Tesco_Year ='" + DRyear + "' and t3.TeamName in('" + ActivityTeams 
                                                 + "')Group by t3.TeamName,t1.ActivityName", connection);
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
        else if (DRperiod != "All")
        {
            string querytm = "";
            SqlCommand cmd1 = new SqlCommand("select t3.TeamName, t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID  and t4.Tesco_Year ='" + DRyear + "' and t4.Tesco_Period ='" + DRperiod + "'and t3.TeamName in('" + ActivityTeams + "')Group by t3.TeamName,t1.ActivityName", connection);
            if (DRweek == "All")
            {
                querytm = "select t3.TeamName, t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID  and t4.Tesco_Year ='" + DRyear + "' and t4.Tesco_Period ='" + DRperiod + "'and t3.TeamName in('" + ActivityTeams + "')Group by t3.TeamName,t1.ActivityName";
            }
            else
            {
                querytm = "select t3.TeamName, t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID  and t4.Tesco_Year ='" + DRyear + "' and t4.Tesco_Period ='" + DRperiod + "' and t4.Tesco_Week ='" + DRweek + "' and t3.TeamName in('" + ActivityTeams + "')Group by t3.TeamName,t1.ActivityName";
            }
            SqlDataAdapter da1 = new SqlDataAdapter(querytm,connection);
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
    }

    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    Session["countval"] = 0;
    //}
