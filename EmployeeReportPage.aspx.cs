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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int checkedweek = 0,checkedperiod=0;
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

        if (DRperiod == "All")
        {
          //  int Year = Convert.ToInt32(Session["Year"]);

            SqlCommand cmd = new SqlCommand("select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + DRyear + " and Tesco_Period in(select distinct(Tesco_Period) from dbo.tbl_TescoCalender where Tesco_Year=" + DRyear + ")and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName", connection);
            //string query = "select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and c.Tesco_Week ='" + Week + "'and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet1 ds = new DataSet1();
            da.Fill(ds.DataTable1);
            DataTable dtdetail = new DataTable();
            da.Fill(dtdetail);
            int count = 0;
            if (dtdetail.Rows.Count == 0)
            {
                count++;
                Session["countval"] = count;
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Data Available!!');", true);

                Response.AppendHeader("Refresh", "2;URL=ReportPage.aspx");
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
            SqlCommand cmd = new SqlCommand("select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + DRyear + "and c.Tesco_Period =" + DRperiod + "and Tesco_Week in(select distinct(Tesco_Week) from dbo.tbl_TescoCalender where Tesco_Year=" + DRyear + " and Tesco_Period=" + DRperiod + ") and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName", connection);
            //string query = "select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and c.Tesco_Week ='" + Week + "'and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet1 ds = new DataSet1();
            da.Fill(ds.DataTable1);
            DataTable dtdetail = new DataTable();
            da.Fill(dtdetail);
            int count = 0;
            if (dtdetail.Rows.Count == 0)
            {
                count++;
                Session["countval"] = count;
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Data Available!!');", true);

                Response.AppendHeader("Refresh", "2;URL=ReportPage.aspx");
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
            SqlCommand cmd = new SqlCommand("select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + DRyear + "and c.Tesco_Period =" + DRperiod + "and c.Tesco_Week =" + DRweek + "and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName", connection);
            string query = "select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + DRyear + "and c.Tesco_Period =" + DRperiod + "and c.Tesco_Week =" + DRweek + "and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet1 ds = new DataSet1();
            da.Fill(ds.DataTable1);
            DataTable dtdetail = new DataTable();
            da.Fill(dtdetail);
            int count = 0;
            if (dtdetail.Rows.Count == 0)
            {
                count++;
                Session["countval"] = count;
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Data Available!!');", true);

                Response.AppendHeader("Refresh", "2;URL=ReportPage.aspx");
            }

            ReportDocument rpt = new ReportDocument();
            rpt.Load(Server.MapPath("CrystalReport.rpt"));
            rpt.SetDatabaseLogon("sa", "scott", "inlte7171", "Activity_Tracker");
            rpt.SetDatabaseLogon("sa", "Tesco123", "inlte6799", "Activity_Tracker");
            rpt.SetDataSource(ds);
            CrystalReportViewer1.ReportSource = rpt;
        }
          
    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }




    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Session["countval"] = 0;
    }
}
