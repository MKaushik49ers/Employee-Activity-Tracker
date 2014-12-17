using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
      Calendar1.Visible = false;
      Calendar2.Visible = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
  

    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        
        

    }
    protected void Calendar2_SelectionChanged2(object sender, EventArgs e)
    {
   
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Calendar1.Visible = true;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Calendar2.Visible = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(@"~/ViewReport.aspx");
    }
    protected void Calendar1_SelectionChanged1(object sender, EventArgs e)
    {
        TextBox1.Text = Calendar1.SelectedDate.ToShortDateString().ToString();
        
    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        TextBox2.Text = Calendar2.SelectedDate.ToShortDateString().ToString();
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string UserID = (string)Session["UserID"];


        string Fromdate = (TextBox1.Text);
        string ToDate = (TextBox2.Text);

        if (Convert.ToDateTime(Fromdate) > Convert.ToDateTime(ToDate))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please select the valid date range');", true);
     
        }

        //DateTime  Fromdate = Convert.ToDateTime(TextBox1.Text);
        //DateTime ToDate = Convert.ToDateTime(TextBox2.Text);
        try
        {
            SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            string Select_Date = @"select UserID, Tesco_Date, TeamName, ShiftTime, Activityname, ActivityDuration, Comments 
                                   from  	Tbl_ActivityDetails A, 		Tbl_Team T, 	Tbl_Shift S, 		Tbl_Activity A1  
                                   where  A.TeamID=T.TeamID and A.ShiftID=S.ShiftID 
                                   and A.ActivityID = A1.ActivityID and UserID = '" + UserID + "' and A.Tesco_Date between '"
                                       + Fromdate + "'and'" + ToDate + "'order by Tesco_Date desc";

            SqlCommand cmd1 = new SqlCommand(Select_Date, conn1);
            SqlDataAdapter da = new SqlDataAdapter(Select_Date, conn1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn1.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
        finally
        {


        }
    }
}
