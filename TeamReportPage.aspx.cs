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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         string DRweek = "";
        string DRperiod = "";
        string DRyear = "";
         string   LName="",FName="";
        if (Session["DropPeriod"] != null)
            DRperiod = (Session["DropPeriod"].ToString());
        if (Session["DropYear"] != null)
            DRyear = (Session["DropYear"].ToString());
        if (Session["DropWeek"] != null)
            DRweek = (Session["DropWeek"].ToString());
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);
        if(Session["FName"]!=null)
          FName = Convert.ToString(Session["FName"]);
        if(Session["LName"]!=null)
          LName = Convert.ToString(Session["LName"]);
        ArrayList ListedItems = (ArrayList)Session["ListBoxValues"];
        string ActivityTeams = string.Empty;
        for (int j = 0; j < ListedItems.Count; j++)
        {
            string jkdjk = Convert.ToString(ListedItems[j]);
            ActivityTeams = jkdjk + "','" + ActivityTeams;
        }
        if (DRperiod == "All")
        {
            //  int Year = Convert.ToInt32(Session["Year"]);

            SqlCommand cmd1 = new SqlCommand("select t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration, t3.TeamName from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID  and t4.Tesco_Year =" + DRyear + " and t3.TeamName in('" + ActivityTeams + "')Group by t3.TeamName,t1.ActivityName", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet1 ds = new DataSet1();
            da.Fill(ds.DataTable1);
            DataTable dtdetail = new DataTable();
            da.Fill(dtdetail);
            int count = 0;
            if (dtdetail.Rows.Count == 0)
            {
                count++;
                Session["countval"] = count;
                Response.Redirect("ReportPage.aspx");
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport.rpt"));
            rpt.SetDatabaseLogon("sa", "scott", "inlte7171", "Activity_Tracker");
            rpt.SetDatabaseLogon("sa", "Tesco123", "inlte6799", "Activity_Tracker");
            rpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rpt;

        }
        else if (DRweek == "All" && DRperiod != "All")
        {
            SqlCommand cmd1 = new SqlCommand("select t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration, t3.TeamName from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID  and t4.Tesco_Year =" + DRyear + " and t4.Tesco_Period =" + DRperiod + "and t3.TeamName in('" + ActivityTeams + "')Group by t3.TeamName,t1.ActivityName", connection);
            //string query = "select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and c.Tesco_Week ='" + Week + "'and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName";
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet1 ds = new DataSet1();
            da.Fill(ds.DataTable1);
            DataTable dtdetail = new DataTable();
            da.Fill(dtdetail);
            int count = 0;
            if (dtdetail.Rows.Count == 0)
            {
                count++;
                Session["countval"] = count;
                Response.Redirect("ReportPage.aspx", false);
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport.rpt"));
            //        rpt.SetDatabaseLogon("sa", "scott", "inlte7171", "Activity_Tracker");
            rpt.SetDatabaseLogon("sa", "Tesco123", "inlte6799", "Activity_Tracker");
            rpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rpt;
        }

        else
        {
            SqlCommand cmd1 = new SqlCommand("select t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration, t3.TeamName from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID and t4.Tesco_Week =" + DRweek + " and t4.Tesco_Year =" + DRyear + " and t4.Tesco_Period =" + DRperiod + "and t3.TeamName in('" + ActivityTeams + "')Group by t3.TeamName,t1.ActivityName", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataSet1 ds = new DataSet1();
            da.Fill(ds.DataTable1);
            DataTable dtdetail = new DataTable();
            da.Fill(dtdetail);
            int count = 0;
            if (dtdetail.Rows.Count == 0)
            {
                count++;
                Session["countval"] = count;
                Response.Redirect("ReportPage.aspx", false);
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport.rpt"));
            rpt.SetDatabaseLogon("sa", "scott", "inlte7171", "Activity_Tracker");
            rpt.SetDatabaseLogon("sa", "Tesco123", "inlte6799", "Activity_Tracker");
            rpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rpt;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["countval"] = 0;
    }
}
