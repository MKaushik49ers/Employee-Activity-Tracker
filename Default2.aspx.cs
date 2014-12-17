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
        int Year = Convert.ToInt32(Session["Year"]);
        int Period = Convert.ToInt32(Session["Period"]);
        int Week = Convert.ToInt32(Session["Week"]);
        string FName = Convert.ToString(Session["FName"]);
        string LName = Convert.ToString(Session["LName"]);

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);
        SqlCommand cmd = new SqlCommand("select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + Year + "and c.Tesco_Period =" + Period + "and c.Tesco_Week =" + Week + "and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName", connection);
        string query = "select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + Year + "and c.Tesco_Period =" + Period + "and c.Tesco_Week =" + Week + "and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName";
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet1 ds = new DataSet1();
        da.Fill(ds.DataTable1);       
        ReportDocument rpt = new ReportDocument();
        rpt.Load(Server.MapPath("CrystalReport.rpt"));
//        rpt.SetDatabaseLogon("sa", "scott", "inlte7171", "Activity_Tracker");
        rpt.SetDatabaseLogon("sa", "Tesco123", "inlte6799", "Activity_Tracker");
        rpt.SetDataSource(ds);
        CrystalReportViewer1.ReportSource = rpt;
          
    }
    protected void CrystalReportViewer1_Init(object sender, EventArgs e)
    {

    }

   
        

}
