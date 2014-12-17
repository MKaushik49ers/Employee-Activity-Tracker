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
        int Year = Convert.ToInt32(Session["Year"]);
        int Period = Convert.ToInt32(Session["Period"]);
        int Week = Convert.ToInt32(Session["Week"]);
        string FName = Convert.ToString(Session["FName"]);
        string LName = Convert.ToString(Session["LName"]);
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);
    
        SqlCommand cmd1 = new SqlCommand("select t1.ActivityName, t2.ActivityDuration, t3.Tesco_Date from tbl_Activity t1,tbl_ActivityDetails t2,tbl_TescoCalender t3,tbl_UserDetails t4,tbl_Team t5 where t1.ActivityID = t2.ActivityID and t2.Tesco_Date = t3.Tesco_Date and t2.TeamID = t5.TeamID and t5.TeamID = t4.TeamID and t3.Tesco_Week="+Week+" and t3.Tesco_Period = "+Period+" and t4.FirstName = "+"'"+FName+"'"+" AND t4.LastName = "+"'"+LName+"'"+" group by t1.ActivityName, t2.ActivityDuration, t3.Tesco_Date order by t3.Tesco_Date", connection);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        GridView1.DataSource = ds1;
        GridView1.DataBind();
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
