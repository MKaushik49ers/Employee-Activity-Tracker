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

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArrayList ListedItemssx = new ArrayList();
        int Year = Convert.ToInt32(Session["Year"]);
        int Period = Convert.ToInt32(Session["Period"]);
        int Week = Convert.ToInt32(Session["Week"]);
        ArrayList ListedItems = (ArrayList)Session["ListBoxValues"];
        string ActivityTeams = string.Empty;
        for (int j = 0; j < ListedItems.Count; j++)
        {
            string jkdjk =Convert.ToString(ListedItems[j]);
            ActivityTeams = jkdjk + "','" + ActivityTeams;

        }

        ActivityTeams = ActivityTeams.Remove(ActivityTeams.Length-3);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);
        SqlCommand cmd1 = new SqlCommand("select t3.TeamName, t1.ActivityName, sum(t2.ActivityDuration) ActivityDuration from tbl_Activity t1, tbl_ActivityDetails t2, tbl_Team t3, tbl_TescoCalender t4, tbl_UserDetails t5 where t1.ActivityID = t2.ActivityID and t2.TeamID = t3.TeamID and t2.Tesco_Date = t4.Tesco_Date and t3.TeamID = t5.TeamID and t4.Tesco_Week =" + Week + " and t4.Tesco_Year =" + Year + " and t4.Tesco_Period =" + Period + "and t3.TeamName in('" + ActivityTeams + "')Group by t3.TeamName,t1.ActivityName", connection);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet1 ds1 = new DataSet1();
        da1.Fill(ds1);
        GridView1.DataSource = ds1;
        GridView1.DataBind();
    }



}