using System;
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
using CrystalDecisions.CrystalReports.Engine;
using System.Diagnostics;
using CrystalDecisions.Shared;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using System.Web.UI.Design;
using System.Collections;


public partial class _Default : System.Web.UI.Page 
{
    Binding bn = new Binding();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack == true)
        {
            
            string Tescoteam = "select TeamName from tbl_Team";
            DataSet ds = bn.DatabindingTeam(Tescoteam);
            String TecoWeek = String.Empty, TecoPeriod = String.Empty, TecoYear = String.Empty;
            TecoWeek = "select distinct(Tesco_Week) from tbl_TescoCalender order by Tesco_Week ";
            TecoPeriod = "select distinct(Tesco_Period) from tbl_TescoCalender order by Tesco_Period ";
            TecoYear = "select distinct(Tesco_Year) from tbl_TescoCalender where Tesco_Year > 2011 order by Tesco_Year";
            DataSet dsWeek = bn.DatabindingTeam(TecoWeek);
            DataSet dsPeriod = bn.DatabindingTeam(TecoPeriod);
            DataSet dsYear = bn.DatabindingTeam(TecoYear);
            DropDownList4.DataSource = dsWeek;
            DropDownList4.DataTextField = "Tesco_Week";
            DropDownList4.DataValueField = "Tesco_Week";
            DropDownList4.DataBind();
            DropDownList5.DataSource = dsPeriod;
            DropDownList5.DataTextField = "Tesco_Period";
            DropDownList5.DataValueField = "Tesco_Period";
            DropDownList5.DataBind();
            DropDownList3.DataSource = dsYear;
            DropDownList3.DataTextField = "Tesco_Year";
            DropDownList3.DataValueField = "Tesco_Year";
            DropDownList3.DataBind();
            ListBox1.DataSource = ds;
            ListBox1.DataTextField = "TeamName";
            ListBox1.DataValueField = "TeamName";
            ListBox1.DataBind();
         

            
        }

        if (DropDownList6.SelectedItem.Text == "Team Report")
        {
            DropDownList2.Enabled = false;
        }
            
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

           
    }
    protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList2.Enabled = true;
        int i = ListBox1.GetSelectedIndices().Length;
        if (i > 1)
        {

            int j = DropDownList2.Items.Count;
            DropDownList2.Enabled = false;
            //Label3.Visible = false;
        }
        else
        {
//           CrystalReportViewer1.Enabled = false;
            string Team = ListBox1.SelectedValue;
            string Emp = " select t1.FirstName+' '+t1.LastName as EmpName from tbl_UserDetails t1, tbl_Team t2 where t1.TeamID = t2.TeamID and t2.TeamName=" + "'" + Team + "'";
            DataSet ds1 = bn.DatabindingTeam(Emp);
            DropDownList2.DataSource = ds1;
            DropDownList2.DataTextField = "EmpName";
            DropDownList2.DataValueField = "EmpName";
            DropDownList2.DataBind();
           // CrystalReportViewer1.Enabled = false;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

            if (DropDownList6.SelectedValue == "EmplyeeReport")
            {
                string EmpName = DropDownList2.SelectedValue;
                String[] Name = EmpName.Split(' ');
                string FName = Name[0];
                string LName = Name[1];
                Session["Period"] = DropDownList5.SelectedValue;
                Session["Year"] = DropDownList3.SelectedValue;
                Session["Week"] = DropDownList4.SelectedValue;
                Session["Fname"] = FName;
                Session["Lname"] = LName;
                Response.Redirect("Default2.aspx");

                //int Period = Convert.ToInt32(DropDownList5.SelectedValue);
                //int Year = Convert.ToInt32(DropDownList3.SelectedValue);
                //int Week = Convert.ToInt32(DropDownList4.SelectedValue);
                //string EmpName = DropDownList2.SelectedValue;
                //String[] Name = EmpName.Split(' ');
                //string FName = Name[0];
                //string LName = Name[1];
                //string Report = "select a.ActivityName, b.ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and c.Tesco_Period = 11 and c.Tesco_Week = 46";
                //DataSet ds = bn.DatabindingTeam(Report);

                //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
                //SqlCommand cmd = new SqlCommand("select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + Year + "and c.Tesco_Period =" + Period + "and c.Tesco_Week =" + Week + "and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'"+"group by a.ActivityName", connection);
                //string query = "select a.ActivityName, sum(b.ActivityDuration) ActivityDuration from tbl_Activity a, tbl_ActivityDetails b,tbl_TescoCalender c, tbl_UserDetails d where a.ActivityID = b.ActivityID and b.Tesco_Date = c.Tesco_Date and b.UserID = d.UserID and Tesco_Year =" + Year + "and c.Tesco_Period =" + Period + "and c.Tesco_Week =" + Week + "and d.FirstName =" + "'" + FName + "'" + " and d.LastName= " + "'" + LName + "'" + "group by a.ActivityName";
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataSet1 ds = new DataSet1();
                //da.Fill(ds.DataTable1);
                //bn.Crystalreport(query);

                //ReportDocument rpt = new ReportDocument();
                //rpt.Load(Server.MapPath("CrystalReport.rpt"));
                //rpt.SetDatabaseLogon("sa", "scott", "localhost", "Activity_Tracker");
                //rpt.SetDataSource(ds);
                //rpt.Refresh();
                //CrystalReportViewer1.ReportSource = rpt;
            }
            else if (DropDownList6.SelectedValue == "DetailedTeamReport")
            {
                ArrayList SelectedItems = new ArrayList();
                //string[] SelectedItems;
                for (int i = 0; i < ListBox1.Items.Count; ++i)
                {
                    if (ListBox1.Items[i].Selected == true)
                        SelectedItems.Add(ListBox1.Items[i].Value);
                }
                Session["ListBoxValues"] = SelectedItems;
                Session["Period"] = DropDownList5.SelectedValue;
                Session["Year"] = DropDownList3.SelectedValue;
                Session["Week"] = DropDownList4.SelectedValue;
                Response.Redirect("Default4.aspx", false);

            }
            else if (DropDownList6.SelectedValue == "DetailedEmployee Report")
            {
                string EmpName = DropDownList2.SelectedValue;
                String[] Name = EmpName.Split(' ');
                string FName = Name[0];
                string LName = Name[1];
                Session["Period"] = DropDownList5.SelectedValue;
                Session["Year"] = DropDownList3.SelectedValue;
                Session["Week"] = DropDownList4.SelectedValue;
                Session["Fname"] = FName;
                Session["Lname"] = LName;
                Response.Redirect("Default3.aspx", false);
                // Response.Redirect("Default3.aspx");
            }
            else
            {

                ArrayList SelectedItems = new ArrayList();
                //string[] SelectedItems;
                for (int i = 0; i < ListBox1.Items.Count; ++i)
                {
                    if (ListBox1.Items[i].Selected == true)
                        SelectedItems.Add(ListBox1.Items[i].Value);
                }
                Session["ListBoxValues"] = SelectedItems;
                Session["Period"] = DropDownList5.SelectedValue;
                Session["Year"] = DropDownList3.SelectedValue;
                Session["Week"] = DropDownList4.SelectedValue;
                Response.Redirect("Default5.aspx", false);
            }

        }
        catch (Exception ex)
        {

            Response.Write("Fill the required field");
            //Console.WriteLine("Fill the required field");
        }
         
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
       if(DropDownList6.SelectedItem.Text == "Team Report")
       {
           DropDownList2.Enabled = false;
       }
    }
}
