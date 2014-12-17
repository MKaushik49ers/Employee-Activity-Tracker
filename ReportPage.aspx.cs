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
            ListBox1.DataSource = ds;
            ListBox1.DataTextField = "TeamName";
            ListBox1.DataValueField = "TeamName";
            ListBox1.DataBind();
            DropDownList3.Enabled = false;
            DropDownList4.Enabled = false;
            DropDownList5.Enabled = false;
            DropDownList2.Enabled = false;
            ImageButton1.Enabled = false;

            
        }

        if (DropDownList6.SelectedItem.Text == "Team Report" || DropDownList6.SelectedValue == "DetailedTeamReport")
        {
            DropDownList2.Enabled = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

           
    }
    protected void ListBox1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        
        DropDownList3.Enabled = true;
        ImageButton1.Enabled = true;
        DropDownList3.Items.Insert(0,"Select one");
        string TescoYear = "select distinct(Tesco_Year) from tbl_TescoCalender where Tesco_Year > 2012 order by Tesco_Year ";
        DataSet dsYear = bn.DatabindingTeam(TescoYear);
        DropDownList3.DataSource = dsYear;
        DropDownList3.DataTextField = "Tesco_Year";
        DropDownList3.DataValueField = "Tesco_Year";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, "--Select One--");
        
        if (DropDownList6.SelectedValue == "Team Report" || DropDownList6.SelectedValue == "DetailedTeamReport")
        {
            DropDownList2.Enabled = false;
        }
        else
        {
            DropDownList2.Enabled = true;
        }
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
            if (DropDownList3.SelectedValue == "--Select One--" || DropDownList4.SelectedValue == "--Select One--" || DropDownList5.SelectedValue == "--Select One--")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Select Valid Year/Period/Week!!');", true);

            }
            else
            {
                if (DropDownList4.SelectedValue == "All")
                {
                    Session["DropPeriod"] = DropDownList5.SelectedValue;
                    Session["DropYear"] = DropDownList3.SelectedValue;
                    Session["DropWeek"] = DropDownList4.SelectedValue;
                }
                else if (DropDownList5.SelectedValue == "All" && DropDownList4.SelectedValue == "")
                {
                    Session["DropYear"] = DropDownList3.SelectedValue;
                    Session["DropPeriod"] = DropDownList5.SelectedValue;

                }
                else
                {
                    Session["DropPeriod"] = DropDownList5.SelectedValue;
                    Session["DropYear"] = DropDownList3.SelectedValue;
                    Session["DropWeek"] = DropDownList4.SelectedValue;
                }
            if (DropDownList6.SelectedValue == "Employee Report")
            {
                string EmpName = DropDownList2.SelectedValue;
                String[] Name = EmpName.Split(' ');
                string FName = Name[0];
                string LName = Name[1];

                int checkperiod = 0, checkweek = 0;
                Session["Fname"] = FName;
                Session["Lname"] = LName;
                Response.Redirect("EmployeeReportPage.aspx",false);
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
                Response.Redirect("DetailedTeamReportPage.aspx", false);

            }
            else if (DropDownList6.SelectedValue == "DetailedEmployee Report")
            {
                string EmpName = DropDownList2.SelectedValue;
                String[] Name = EmpName.Split(' ');
                string FName = Name[0];
                string LName = Name[1];
                Session["TeamName"] = ListBox1.SelectedValue;
                Session["Fname"] = FName;
                Session["Lname"] = LName;
                Response.Redirect("DetailedEmployeeReportPage.aspx", false);
                DropDownList2.Enabled = true;
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
                Response.Redirect("TeamReportPage.aspx", false);
            }
        }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
       if(DropDownList6.SelectedItem.Text == "Team Report")
       {
           DropDownList2.Enabled = false;
       }
    }
   
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedValue == "--Select One--")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Select Valid Week!!');", true);

        }
    }
   
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedValue == "--Select One--")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Select Valid Year!!');", true);

        }
        else
        {
            DropDownList5.Enabled = true;
            string TescoPeriod = "select distinct(Tesco_Period) from tbl_TescoCalender where Tesco_Year=" + DropDownList3.SelectedValue + " order by Tesco_Period ";
            DataSet dsPeriod = bn.DatabindingTeam(TescoPeriod);
            DropDownList5.DataSource = dsPeriod;
            DropDownList5.DataTextField = "Tesco_Period";
            DropDownList5.DataValueField = "Tesco_Period";
            DropDownList5.DataBind();
            DropDownList5.Items.Insert(0, "--Select One--");
            DropDownList5.Items.Insert(1, "All");
        }
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedValue == "--Select One--" )
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Select Valid Period!!');", true);

        }
        else if (DropDownList5.SelectedValue == "All")
        {
            DropDownList4.Enabled = false;
        }
        else
        {
            DropDownList4.Enabled = true;
            string TescoWeek = "select distinct(Tesco_Week) from tbl_TescoCalender where Tesco_Year= " + DropDownList3.SelectedValue + " and Tesco_Period=" + DropDownList5.SelectedValue + " order by Tesco_Week ";
            DataSet dsWeek = bn.DatabindingTeam(TescoWeek);
            DropDownList4.DataSource = dsWeek;
            DropDownList4.DataTextField = "Tesco_Week";
            DropDownList4.DataValueField = "Tesco_Week";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, "--Select One--");
            DropDownList4.Items.Insert(1, "All");
        }
    }
}
