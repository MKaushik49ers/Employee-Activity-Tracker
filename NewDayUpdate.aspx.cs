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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;



public partial class Default2 : System.Web.UI.Page
{
    decimal Duration = 0;
    protected void Page_Load(object sender, EventArgs e)
  {
      DateTime dt = DateTime.Today;
      TextBox7.Text = ConfigurationManager.AppSettings["RequiredHour"];
      int Min = Convert.ToInt16(ConfigurationManager.AppSettings["MinDayValue"].ToString());
      int Max = Convert.ToInt16(ConfigurationManager.AppSettings["MaxDayValue"].ToString());
         RangeValidator1.MaximumValue = DateTime.Now.AddDays(Max).ToShortDateString();
         RangeValidator1.MinimumValue=DateTime.Now.AddDays(Min).ToShortDateString();
         Session["MaxDate"] = RangeValidator1.MaximumValue;
         Session["MinDate"] = RangeValidator1.MinimumValue;
        if (!Page.IsPostBack)
        {
           
            FirstGridViewRow();
            ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
            ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
            //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
            ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            //button3.Enabled = false;
            button4.Enabled = false;
            string str = (string)Session["UserID"];
            Session["sestring1"] = str;
            Lbltpx.Text = str;
            SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string Query = "SELECT * FROM tbl_UserDetails WHERE UserID = '" + str + "'";
                string Query1 = "select ShiftTime from dbo.tbl_Shift";
                SqlCommand cmd = new SqlCommand(Query, ServerConnection);
                ServerConnection.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                lblnameval.Text = rdr[2].ToString() + " " + rdr[3].ToString();
                Session["UserName"] = lblnameval.Text;
                Lbldesig.Text = rdr[4].ToString();
                Session["Desig"] = rdr[4].ToString();
                rdr.Close();
                cmd.Dispose();
                SqlDataAdapter da = new SqlDataAdapter(Query1, ServerConnection);
                DataSet ds = new DataSet();
                da.Fill(ds, "shift");
                DataTable shiftTb = new DataTable();
                shiftTb = ds.Tables["shift"];
                int TotlCount = shiftTb.Rows.Count;
                for (int count = 0; count < TotlCount; count++)
                {
                    DropDownList1.Items.Add(shiftTb.Rows[count]["ShiftTime"].ToString());
                }

                TextBox txtDate = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtDate");
                txtDate.Text = "";

//                Session["entereddate"] = txtDate.ToString();

                DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[0].Cells[2].FindControl("drpTeam");
                DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[0].Cells[3].FindControl("drpActivity");
                DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[0].Cells[4].FindControl("drpHour");
                DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[0].Cells[5].FindControl("drpMin");
                TextBox txtComments = (TextBox)grvStudentDetails.Rows[0].Cells[6].FindControl("txtComments");
                ImageButton delete = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
                delete.Visible = false;

                try
                {
                    ServerConnection.Open();
                    string QueryTeam = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                    string queryActivity = "select ActivityName from dbo.tbl_Activity where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "') order by ActivityName ";
                    string queryDuration = "select Hours,Minutes from dbo.Duration";

                    SqlCommand cmd1 = new SqlCommand(QueryTeam, ServerConnection);
                    SqlDataAdapter daTeam = new SqlDataAdapter(QueryTeam, ServerConnection);
                    SqlDataAdapter da1 = new SqlDataAdapter(queryActivity, ServerConnection);
                    SqlDataAdapter da2 = new SqlDataAdapter(queryDuration, ServerConnection);
                    DataSet dsTeam = new DataSet();
                    DataSet ds1 = new DataSet();
                    DataSet ds2 = new DataSet();
                    DataTable dt2 = new DataTable();
                    daTeam.Fill(dsTeam, "tb");
                    dt2 = dsTeam.Tables["tb"];
                    da1.Fill(ds1, "tb1");
                    DataTable dt3 = new DataTable();
                    dt3 = ds1.Tables["tb1"];

                    da2.Fill(ds2, "tb2");
                    DataTable dt4 = new DataTable();
                    dt4 = ds2.Tables["tb2"];
                    //int count = 0;
                    String[] m = new String[10];
                    int totalcount = dt2.Rows.Count;
                    for (int count = 0; count < totalcount; count++)
                    {
                        drpTeam.Items.Add(dt2.Rows[count]["TeamName"].ToString());

                    }
                    int totalcount1 = dt3.Rows.Count;
                    for (int count = 0; count < totalcount1; count++)
                    {
                        drpActivity.Items.Add(dt3.Rows[count]["ActivityName"].ToString());
                        string n = dt3.Rows[count]["ActivityName"].ToString();


                    }
                    int totalcount2 = dt4.Rows.Count;
                    for (int count = 0; count < totalcount2; count++)
                    {
                        drpHour.Items.Add(dt4.Rows[count]["Hours"].ToString());

                    }
                    int totalcount3 = dt4.Rows.Count;
                    for (int count = 0; count < totalcount3; count++)
                    {
                        drpMin.Items.Add(dt4.Rows[count]["Minutes"].ToString());

                    }
                    cmd1.Dispose();
                }
                finally
                {
                    ServerConnection.Close();
                }
            }
            catch (Exception ex)
            {

                Debug.Write(ex.Message);
            }
            finally
            {
                ServerConnection.Close();
            }
        }


    }
    private void FirstGridViewRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Col1", typeof(string)));
        dt.Columns.Add(new DataColumn("Col3", typeof(string)));
        dt.Columns.Add(new DataColumn("Col4", typeof(string)));
        dt.Columns.Add(new DataColumn("Col5", typeof(string)));
        dt.Columns.Add(new DataColumn("Col6", typeof(string)));
        dt.Columns.Add(new DataColumn("Col7", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = 1;
        dr["Col1"] = string.Empty;
        dr["Col3"] = string.Empty;
        dr["Col4"] = string.Empty;
        dr["Col5"] = string.Empty;
        dr["Col6"] = string.Empty;
        dr["Col7"] = string.Empty;
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        grvStudentDetails.DataSource = dt;
        grvStudentDetails.DataBind();
        TextBox txn = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtDate");
        txn.Focus();
        ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("ButtonAdd");

    }
    private void AddNewRow()
    {
        ArrayList TimeValidation = new ArrayList();
        int rowIndex = 0;

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            DataRow drCurrentRow1 = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //creating controls when row add button clicked
                    TextBox txtDate = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtDate");
                    //TextBox txtDay = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDay");
                    DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("drpTeam");
                    DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpActivity");
                    DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("drpHour");
                    DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("drpMin");
                    TextBox txtComments = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("txtComments");
                    string str = (string)Session["UserID"];
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

                    try
                    {

                        string Query1 = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                        string query2 = "select ActivityName from dbo.tbl_Activity where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "') order by ActivityName ";
                        string query3 = "select Hours,Minutes from dbo.Duration";
                        conn1.Open();
                        SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                        SqlDataAdapter da = new SqlDataAdapter(Query1, conn1);
                        SqlDataAdapter da1 = new SqlDataAdapter(query2, conn1);
                        SqlDataAdapter da2 = new SqlDataAdapter(query3, conn1);
                        DataSet ds = new DataSet();
                        DataSet ds1 = new DataSet();
                        DataSet ds2 = new DataSet();
                        DataTable dt2 = new DataTable();
                        da.Fill(ds, "tb");
                        dt2 = ds.Tables["tb"];
                        da1.Fill(ds1, "tb1");
                        DataTable dt3 = new DataTable();
                        dt3 = ds1.Tables["tb1"];

                        da2.Fill(ds2, "tb2");
                        DataTable dt4 = new DataTable();
                        dt4 = ds2.Tables["tb2"];
                        //int count = 0;
                        String[] m = new String[10];
                        int totalcount = dt2.Rows.Count;
                        for (int count = 0; count < totalcount; count++)
                        {
                            drpTeam.Items.Add(dt2.Rows[count]["TeamName"].ToString());

                        }
                        int totalcount1 = dt3.Rows.Count;
                        for (int count = 0; count < totalcount1; count++)
                        {
                            drpActivity.Items.Add(dt3.Rows[count]["ActivityName"].ToString());
                            string n = dt3.Rows[count]["ActivityName"].ToString();


                        }
                        int totalcount2 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount2; count++)
                        {
                            drpHour.Items.Add(dt4.Rows[count]["Hours"].ToString());

                        }
                        int totalcount3 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount3; count++)
                        {
                            drpMin.Items.Add(dt4.Rows[count]["Minutes"].ToString());

                        }
                        cmd1.Dispose();

                    }
                    finally
                    {
                        conn1.Close();
                    }
                    //row count value is increased by 1 and values of controls
                    //of previous rows is stored in column buffer
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow1 = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;
                    txtDate.Text = Session["date"].ToString();
                    Session["date1"] = txtdate.Text;
                    //txtDay.Text = Session["day"].ToString();
                    //dtCurrentTable.Rows[i ]["Col1"] = txtDate.Text;
                    //dtCurrentTable.Rows[i ]["Col2"] = txtDay.Text;
                    dtCurrentTable.Rows[i - 1]["Col1"] = txtDate.Text;
                    //dtCurrentTable.Rows[i - 1]["Col2"] = txtDay.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = drpTeam.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col4"] = drpActivity.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col5"] = drpHour.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col6"] = drpMin.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col7"] = txtComments.Text;
                   // Duration = Convert.ToDecimal(drpHour.SelectedValue) + Convert.ToDecimal(drpMin.SelectedValue);
                    
                    rowIndex++;
                    

                }
                //adding all created rows in data table and then binding it to gridview


                // txn.Focus;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                Session["UIROWCOUNT"] = dtCurrentTable.Rows.Count;
                grvStudentDetails.DataSource = dtCurrentTable;
                grvStudentDetails.DataBind();
                TextBox txn = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtDate");
                txn.Focus();

            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        //then calling below function to store the previous data of controls of previous row 
        //and newly added data of controls of newly added row if any is there.
        Session["Timevalid"] = TimeValidation;
        SetPreviousData();

    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                //recreating all the rows with its control,where number of row to be created here is
                //same as it was  after execution of addnewrow() function
                //int cval = Convert.ToInt16(ViewState["ival"]);
                string str = (string)Session["UserID"];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtDate = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtDate");
                    //TextBox txtDay = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDay");
                    DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpTeam");
                    DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("drpActivity");
                    DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("drpHour");
                    DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("drpMin");
                    TextBox txtComments = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("txtComments");
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
                    

                    try
                    {

                        string Query1 = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                        string query2 = "select ActivityName from dbo.tbl_Activity where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "') order by ActivityName ";
                        string query3 = "select Hours,Minutes from dbo.Duration";
                        conn1.Open();
                        SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                        SqlDataAdapter da = new SqlDataAdapter(Query1, conn1);
                        SqlDataAdapter da1 = new SqlDataAdapter(query2, conn1);
                        SqlDataAdapter da2 = new SqlDataAdapter(query3, conn1);
                        DataSet ds = new DataSet();
                        DataSet ds1 = new DataSet();
                        DataSet ds2 = new DataSet();
                        DataTable dt2 = new DataTable();
                        da.Fill(ds, "tb");
                        dt2 = ds.Tables["tb"];
                        da1.Fill(ds1, "tb1");
                        DataTable dt3 = new DataTable();
                        dt3 = ds1.Tables["tb1"];

                        da2.Fill(ds2, "tb2");
                        DataTable dt4 = new DataTable();
                        dt4 = ds2.Tables["tb2"];
                        //int count = 0;
                        String[] m = new String[10];
                        int totalcount = dt2.Rows.Count;
                        for (int count = 0; count < totalcount; count++)
                        {
                            drpTeam.Items.Add(dt2.Rows[count]["TeamName"].ToString());

                        }
                        int totalcount1 = dt3.Rows.Count;
                        for (int count = 0; count < totalcount1; count++)
                        {
                            drpActivity.Items.Add(dt3.Rows[count]["ActivityName"].ToString());
                            string n = dt3.Rows[count]["ActivityName"].ToString();


                        }
                        int totalcount2 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount2; count++)
                        {
                            drpHour.Items.Add(dt4.Rows[count]["Hours"].ToString());

                        }
                        int totalcount3 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount3; count++)
                        {
                            drpMin.Items.Add(dt4.Rows[count]["Minutes"].ToString());

                        }
                        cmd1.Dispose();
                    }
                    finally
                    {
                        conn1.Close();
                    }
                    //txtDate.Text = Session["date"].ToString();
                    //txtDay.Text = Session["day"].ToString();
                    dt.Rows[i]["Col1"] = Session["date"].ToString();
                    
                    //dt.Rows[i]["Col2"] = Session["day"].ToString();
                    //retreiving value of each control of each row at a time
                    grvStudentDetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    txtDate.Text = dt.Rows[i]["Col1"].ToString();
                    //txtDay.Text = dt.Rows[i]["Col2"].ToString();
                    drpTeam.SelectedValue = dt.Rows[i]["Col3"].ToString();
                    drpActivity.SelectedValue = dt.Rows[i]["Col4"].ToString();
                    drpHour.SelectedValue = dt.Rows[i]["Col5"].ToString();
                    drpMin.SelectedValue = dt.Rows[i]["Col6"].ToString();
                    txtComments.Text = dt.Rows[i]["Col7"].ToString();
                    //DrpQualification.SelectedValue = dt.Rows[i]["Col5"].ToString();
                    // DrpQualification.SelectedValue = "mails";
                    rowIndex++;
                    
                }
            }
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[dtCurrentTable.Rows.Count - 1].Cells[4].FindControl("drpHour");
            DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[dtCurrentTable.Rows.Count - 1].Cells[5].FindControl("drpMin");
            if (drpMin.SelectedValue == "0.00" && drpHour.SelectedValue == "0.00")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Select Valid Duration!!');", true);

            }
            else
            {
                AddNewRow();
                ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
                ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
                //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
                ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
                btnAdd.Enabled = true;
                btnSave.Enabled = true;
                //button3.Enabled = false;
                button4.Enabled = false;
                ImageButton delete = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
                delete.Visible = false;
            }
        }
        

    }
    protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        SetRowData();
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            int rowIndex = Convert.ToInt32(e.RowIndex);
            if (dt.Rows.Count > 1)
            {
                TextBox txtDate = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtDate");
                //TextBox txtDay = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDay");
                DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpTeam");
                DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("drpActivity");
                DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("drpHour");
                DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("drpMin");
                TextBox txtComments = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[7].FindControl("txtComments");
                string str = (string)Session["UserID"];
                SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
                //query to get ID's corresponding to value in dropdown
                string Qdetail = @" select a.TeamID,ShiftID,ActivityID from dbo.tbl_Team a,dbo.tbl_Shift,dbo.tbl_Activity b where a.TeamID=b.TeamID and
                                    TeamName='" + drpTeam.SelectedValue + "' and ShiftTime='" + DropDownList1.SelectedValue + "' and ActivityName='" + drpActivity.SelectedValue + "'";
                SqlDataAdapter daDetail = new SqlDataAdapter(Qdetail, conn1);
                DataTable dtDetail = new DataTable();
                daDetail.Fill(dtDetail);
                int TeamID = 0;
                string ShiftID = "";
                string ActivityID = "";
                foreach (DataRow dr in dtDetail.Rows)
                {
                    TeamID = Convert.ToInt16(dr[0].ToString());
                    ShiftID = dr[1].ToString();
                    ActivityID = dr[2].ToString();
                }
                Double ActivityDuration1 = 0.0d;
                Double Hours = Convert.ToDouble(drpHour.SelectedValue);
                Double Minutes = Convert.ToDouble(drpMin.SelectedValue);
                ActivityDuration1 = Hours + Minutes;
                string ActivityDuration = Convert.ToString(ActivityDuration1);
                int durval = 0;
                foreach (char durr in ActivityDuration)
                {
                    durval++;
                }
                if (durval == 1)
                {
                    ActivityDuration = ActivityDuration + ".00";
                }
                string Comments = txtComments.Text;
                DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
                string countrowsavail = @"select count(*) from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and TeamID ='" + TeamID
                                                + "' and Tesco_Date = '" + Tesco_Date + "'and ActivityID ='" + ActivityID
                                                + "' and ActivityDuration = '" + ActivityDuration + "'and Comments like '" + Comments + "'";

                int countval = 0;
                try
                {
                    SqlDataAdapter dacount = new SqlDataAdapter(countrowsavail, conn1);
                    DataTable tbcount = new DataTable();
                    dacount.Fill(tbcount);

                    foreach (DataRow drcount in tbcount.Rows)
                    {
                        countval = Convert.ToInt16(drcount[0].ToString());
                    }
                }

                catch (Exception ex)
                {

                    Debug.Write(ex.Message);
                }
                finally
                {
                    conn1.Close();
                }
                if (countval != 0)
                {
                    string Qdelete = "delete from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and TeamID ='" + TeamID
                                                + "' and Tesco_Date = '" + Tesco_Date + "'and ActivityID ='" + ActivityID
                                                + "' and ActivityDuration = '" + ActivityDuration + "'and Comments like '" + Comments + "'";
                    SqlCommand cmddel = new SqlCommand(Qdelete, conn1);
                    try
                    {
                        conn1.Open();
                        cmddel.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }
                    finally
                    {
                        conn1.Close();
                        cmddel.Dispose();
                    }
                    try
                    {

                        string REPORTEDHOURS = "SELECT ActivityDuration from dbo.tbl_ActivityDetails  where UserID = '" + str + "' and Tesco_Date ='" + Tesco_Date + "'";
                        //SqlCommand cmd2 = new SqlCommand(REPORTEDHOURS, ServerConnection);

                        //ServerConnection.Open();
                        //SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                        //rdr.Read();
                        //string reportedtotal = (rdr[0].ToString());

                        //String[] splitval = reportedtotal.Split('.');
                        int val1, val2;
                        //val1 = Convert.ToInt16(splitval[0]);
                        //val2 = Convert.ToInt16(splitval[1]);
                        SqlDataAdapter daduration = new SqlDataAdapter(REPORTEDHOURS, conn1);
                        DataTable dtdur = new DataTable();
                        daduration.Fill(dtdur);
                        ArrayList Durationhour = new ArrayList();
                        int rowcount = 0;
                        foreach (DataRow dr in dtdur.Rows)
                        {
                            Durationhour.Add(dr[0].ToString());
                            rowcount++;
                        }
                        int i1 = 0;
                        int sum1 = 0, sum2 = 0;
                        while (i1 < rowcount)
                        {
                            string x = Durationhour[i1].ToString();
                            String[] splitval = x.Split('.');
                            val1 = Convert.ToInt16(splitval[0]);
                            val2 = Convert.ToInt16(splitval[1]);
                            sum1 = sum1 + val1;
                            sum2 = sum2 + val2;
                            i1++;
                        }

                        while (sum2 >= 60)
                        {
                            sum1++;
                            sum2 = sum2 - 60;

                        }


                        TextBox8.Text = Convert.ToString(sum1) + "." + Convert.ToString(sum2);

                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }
                    finally
                    {
                        conn1.Close();
                    }
                }



                dt.Rows.Remove(dt.Rows[rowIndex]);
                drCurrentRow = dt.NewRow();
                ViewState["CurrentTable"] = dt;
                grvStudentDetails.DataSource = dt;
                grvStudentDetails.DataBind();

                for (int i = 0; i < grvStudentDetails.Rows.Count - 1; i++)
                {
                    grvStudentDetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                }
                SetPreviousData();
                //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
                ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
                //button3.Enabled = false;
                button4.Enabled = false;
                ImageButton delete = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
                delete.Visible = false;
            }
        }
    }
    private void SetRowData()
    {
        int rowIndex = 0;
        string str = (string)Session["UserID"];

        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox txtDate = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtDate");
                    //TextBox txtDay = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDay");
                    DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("drpTeam");
                    DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpActivity");
                    DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("drpHour");
                    DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("drpMin");
                    TextBox txtComments = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("txtComments");
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
                    
                    try
                    {

                        string Query1 = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                        string query2 = "select ActivityName from dbo.tbl_Activity where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "') order by ActivityName ";
                        string query3 = "select Hours,Minutes from dbo.Duration";
                        conn1.Open();
                        SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                        SqlDataAdapter da = new SqlDataAdapter(Query1, conn1);
                        SqlDataAdapter da1 = new SqlDataAdapter(query2, conn1);
                        SqlDataAdapter da2 = new SqlDataAdapter(query3, conn1);
                        DataSet ds = new DataSet();
                        DataSet ds1 = new DataSet();
                        DataSet ds2 = new DataSet();
                        DataTable dt2 = new DataTable();
                        da.Fill(ds, "tb");
                        dt2 = ds.Tables["tb"];
                        da1.Fill(ds1, "tb1");
                        DataTable dt3 = new DataTable();
                        dt3 = ds1.Tables["tb1"];

                        da2.Fill(ds2, "tb2");
                        DataTable dt4 = new DataTable();
                        dt4 = ds2.Tables["tb2"];
                        //int count = 0;
                        String[] m = new String[10];
                        int totalcount = dt2.Rows.Count;
                        for (int count = 0; count < totalcount; count++)
                        {
                            drpTeam.Items.Add(dt2.Rows[count]["TeamName"].ToString());
                            

                        }
                        int totalcount1 = dt3.Rows.Count;
                        for (int count = 0; count < totalcount1; count++)
                        {
                            drpActivity.Items.Add(dt3.Rows[count]["ActivityName"].ToString());
                            string n = dt3.Rows[count]["ActivityName"].ToString();


                        }
                        int totalcount2 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount2; count++)
                        {
                            drpHour.Items.Add(dt4.Rows[count]["Hours"].ToString());

                        }
                        int totalcount3 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount3; count++)
                        {
                            drpMin.Items.Add(dt4.Rows[count]["Minutes"].ToString());

                        }
                        cmd1.Dispose();
                    }
                    finally
                    {
                        conn1.Close();
                    }
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["RowNumber"] = i + 1;
                    txtDate.Text = Session["date"].ToString();
                    //txtDay.Text = Session["day"].ToString();

                    //drpTeam.SelectedValue=dtCurrentTable.Rows[i - 1]["Col3"] .ToString();
                    //drpActivity.SelectedValue=dtCurrentTable.Rows[i - 1]["Col4"].ToString();
                    //drpHour.SelectedValue=dtCurrentTable.Rows[i - 1]["Col5"].ToString();
                    //drpMin.SelectedValue=dtCurrentTable.Rows[i - 1]["Col6"].ToString();
                    //txtComments.Text=dtCurrentTable.Rows[i - 1]["Col7"].ToString() ;
                    dtCurrentTable.Rows[i - 1]["Col1"] = txtDate.Text;
                    //dtCurrentTable.Rows[i - 1]["Col2"] = txtDay.Text;
                    dtCurrentTable.Rows[i - 1]["Col3"] = drpTeam.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col4"] = drpActivity.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col5"] = drpHour.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col6"] = drpMin.SelectedValue;
                    dtCurrentTable.Rows[i - 1]["Col7"] = txtComments.Text;
                    rowIndex++;

                    

                }

                ViewState["CurrentTable"] = dtCurrentTable;
                grvStudentDetails.DataSource = dtCurrentTable;
                grvStudentDetails.DataBind();

            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
        SetPreviousData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[dtCurrentTable.Rows.Count - 1].Cells[4].FindControl("drpHour");
            DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[dtCurrentTable.Rows.Count - 1].Cells[5].FindControl("drpMin");
            if (drpMin.SelectedValue == "0.00" && drpHour.SelectedValue == "0.00")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Select Valid Duration!!');", true);

            }
        }
        else
        {
        string confirmValue = Request.Form["confirm_value"];
        if (confirmValue == "Yes")
        {
            int TeamID = 0;
            int ActivityID = 0;
            int ShiftID = 0;
            Double ActivityDuration1 = 0.00d;
            SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            string str = (string)Session["UserID"];
            DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
            try
            {

                DateTime CreatedOn = DateTime.Now;
                string CreatedBy = str;
                DateTime UpdatedOn = DateTime.Now;
                string UpdatedBy = str;
                SetRowData();
                DataTable table = ViewState["CurrentTable"] as DataTable;
                int rowcount = table.Rows.Count;
                int Dbcount = 0;
                int updcount = 0;
                int dbeqcount = 0;
                string countrows = @"select count(*) from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and Tesco_Date = '" + Tesco_Date + "'";
                SqlCommand cmd = new SqlCommand(countrows, ServerConnection);
                try
                {
                    ServerConnection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();
                    Dbcount = Convert.ToInt16(rdr[0].ToString());
                    rdr.Close();
                    cmd.Dispose();
                }

                catch (Exception ex)
                {

                    Debug.Write(ex.Message);
                }
                finally
                {

                }
                ArrayList list = new ArrayList();


                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {

                        list.Add(row.ItemArray[1] as string);
                        list.Add(row.ItemArray[2] as string);
                        list.Add(row.ItemArray[3] as string);
                        list.Add(row.ItemArray[4] as string);
                        list.Add(row.ItemArray[5] as string);
                        list.Add(row.ItemArray[6] as string);


                    }

                    if (Dbcount > rowcount)
                    {
                        dbeqcount = Dbcount - rowcount;
                        rowcount = rowcount + Dbcount;
                        updcount = Convert.ToInt16(ViewState["updcountval"]);
                    }
                    else
                    {
                        dbeqcount = Dbcount;
                    }
                    string allvalues = @"select * from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and Tesco_Date = '" + Tesco_Date + "'";
                    SqlDataAdapter dat = new SqlDataAdapter(allvalues, ServerConnection);
                    DataTable dbtb = new DataTable();
                    dat.Fill(dbtb);
                    ArrayList list1 = new ArrayList();
                    foreach (DataRow drr in dbtb.Rows)
                    {
                        list1.Add(drr[0].ToString());
                        list1.Add(drr[1].ToString());
                        list1.Add(drr[2].ToString());
                        list1.Add(drr[3].ToString());
                        list1.Add(drr[4].ToString());
                        list1.Add(drr[5].ToString());
                        list1.Add(drr[6].ToString());
                        list1.Add(drr[7].ToString());

                    }
                    int i = 0;
                    int i1 = 0;
                    ArrayList listUIval = new ArrayList();
                    while (updcount < dbeqcount)
                    {

                        //call update here
                        DateTime TescoDate = Convert.ToDateTime(list[i]);
                        // string TescoDay = list[i + 1].ToString();
                        string TeamName = list[i + 1].ToString();
                        //query to get corres TeamID
                        try
                        {

                            string Select_TeamID = "select TeamID from dbo.tbl_Team   where TeamName ='" + TeamName + "'and TeamID in(Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                            SqlDataAdapter da = new SqlDataAdapter(Select_TeamID, ServerConnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                TeamID = Convert.ToInt16(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                        }

                        string ActivityName = list[i + 2].ToString();
                        try
                        {
                            string Select_ActivityID = "select ActivityID from dbo.tbl_Activity where ActivityName ='" + ActivityName + "' and TeamID='"+TeamID+"'";
                            SqlDataAdapter daActivity = new SqlDataAdapter(Select_ActivityID, ServerConnection);
                            DataTable dt = new DataTable();
                            daActivity.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                ActivityID = Convert.ToInt16(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                        }
                        Double Hours = Convert.ToDouble(list[i + 3].ToString());
                        Double Minutes = Convert.ToDouble(list[i + 4].ToString());
                        string Comments = list[i + 5].ToString();
                        string ShiftTime = DropDownList1.SelectedValue;
                        try
                        {
                            string Select_ShiftID = "select ShiftID from dbo.tbl_Shift  where ShiftTime ='" + ShiftTime + "'";
                            SqlDataAdapter daShift = new SqlDataAdapter(Select_ShiftID, ServerConnection);
                            DataTable dt = new DataTable();
                            daShift.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                ShiftID = Convert.ToInt16(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                        }

                        ActivityDuration1 = Hours + Minutes;
                        string ActivityDuration = Convert.ToString(ActivityDuration1);
                        int durval = 0;
                        foreach (char durr in ActivityDuration)
                        {
                            durval++;
                        }
                        if (durval == 1)
                        {
                            ActivityDuration = ActivityDuration + ".00";
                        }
                        listUIval.Add(str);
                        listUIval.Add(TeamID);
                        listUIval.Add(TescoDate);
                        listUIval.Add(ShiftID);
                        listUIval.Add(ActivityID);
                        listUIval.Add(ActivityDuration);
                        listUIval.Add(Comments);





                        string Query = @"UPDATE .[dbo].[tbl_ActivityDetails]
                                 SET      [UserID] ='" + str + "',[TeamID] = '" + TeamID + "',[Tesco_Date] = '" + TescoDate
                                              + "',[ShiftID] = '" + ShiftID + "',[ActivityID] = '" + ActivityID
                                              + "',[ActivityDuration] = '" + ActivityDuration + "',[Comments] ='" + Comments
                                              + "',[CreatedOn] = '" + CreatedOn + "',[CreatedBy] = '" + CreatedBy
                                              + "',[UpdatedOn] = '" + UpdatedOn + "',[UpdatedBy] = '" + UpdatedBy
                                              + "'WHERE [RefID]='" + list1[i1] + "' and  UserID = '" + list1[i1 + 1] + "' and TeamID ='" + list1[i1 + 2]
                                              + "' and Tesco_Date = '" + list1[i1 + 3] + "'and ActivityID ='" + list1[i1 + 5]
                                              + "' and ActivityDuration = '" + list1[i1 + 6] + "'and Comments like '" + list1[i1 + 7] + "'";
                        SqlCommand cmd5 = new SqlCommand(Query, ServerConnection);
                        try
                        {
                            ServerConnection.Open();
                            cmd5.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                        }


                        finally
                        {
                            cmd5.Dispose();
                            ServerConnection.Close();
                        }

                        i = i + 6;
                        i1 = i1 + 8;

                        updcount++;
                    }
                    int j = 0;
                    while (Dbcount < rowcount)
                    {

                        //before insert check in db whether a row is available with same
                        //userid,tesco date,teamname,activityname,comments or not
                        //if no then only insert.

                        DateTime TescoDate = Convert.ToDateTime(list[j]);
                        //string TescoDay = list[j + 1].ToString();
                        string TeamName = list[j + 1].ToString();
                        //query to get corres TeamID
                        try
                        {

                            string Select_TeamID = "select TeamID from dbo.tbl_Team   where TeamName ='" + TeamName + "'and TeamID in(Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                            SqlDataAdapter da = new SqlDataAdapter(Select_TeamID, ServerConnection);
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                TeamID = Convert.ToInt16(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                        }

                        string ActivityName = list[j + 2].ToString();
                        try
                        {
                            string Select_ActivityID = "select ActivityID from dbo.tbl_Activity where ActivityName ='" + ActivityName + "' and TeamID ='" + TeamID+"'";
                            SqlDataAdapter daActivity = new SqlDataAdapter(Select_ActivityID, ServerConnection);
                            DataTable dt = new DataTable();
                            daActivity.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                ActivityID = Convert.ToInt16(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                        }
                        Double Hours = Convert.ToDouble(list[j + 3].ToString());
                        Double Minutes = Convert.ToDouble(list[j + 4].ToString());
                        ActivityDuration1 = Hours + Minutes;
                        string ActivityDuration = Convert.ToString(ActivityDuration1);
                        int durval = 0;
                        foreach (char durr in ActivityDuration)
                        {
                            durval++;
                        }
                        if (durval == 1)
                        {
                            ActivityDuration = ActivityDuration + ".00";
                        }

                        string Comments = list[j + 5].ToString();
                        string ShiftTime = DropDownList1.SelectedValue;
                        try
                        {
                            string Select_ShiftID = "select ShiftID from dbo.tbl_Shift  where ShiftTime ='" + ShiftTime + "'";
                            SqlDataAdapter daShift = new SqlDataAdapter(Select_ShiftID, ServerConnection);
                            DataTable dt = new DataTable();
                            daShift.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                ShiftID = Convert.ToInt16(dr[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.Write(ex.Message);
                        }
                        string countrowsavail = @"select count(*) from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and TeamID ='" + TeamID
                                                + "' and Tesco_Date = '" + TescoDate + "'and ActivityID ='" + ActivityID
                                                + "' and ActivityDuration = '" + ActivityDuration + "'and Comments like '" + Comments + "'";

                        int countval = 0;
                        try
                        {
                            ServerConnection.Open();
                            SqlDataAdapter dacount = new SqlDataAdapter(countrowsavail, ServerConnection);
                            DataTable tbcount = new DataTable();
                            dacount.Fill(tbcount);

                            foreach (DataRow drcount in tbcount.Rows)
                            {
                                countval = Convert.ToInt16(drcount[0].ToString());
                            }
                        }

                        catch (Exception ex)
                        {

                            Debug.Write(ex.Message);
                        }
                        finally
                        {
                            ServerConnection.Close();
                        }

                        if (countval == 0)
                        {
                            //call insert here
                            string Query5 = "Insert into tbl_ActivityDetails values ('" + str + "','" + TeamID + "','" + TescoDate + "','" + ShiftID + "','" + ActivityID + "','" + ActivityDuration + "','" + Comments + "','" + CreatedOn + "','" + CreatedBy + "','" + UpdatedOn + "','" + UpdatedBy + "')";
                            SqlCommand cmd4 = new SqlCommand(Query5, ServerConnection);
                            try
                            {
                                ServerConnection.Open();
                                cmd4.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                Debug.Write(ex.Message);
                            }


                            finally
                            {
                                cmd4.Dispose();
                                ServerConnection.Close();
                            }
                            Dbcount++;
                        }
                        j = j + 6;

                    }

                    //Response.Write(string.Format("{0} {1} {2} {3} {4}<br/>", txName, txAge, txAdd, rbGen, drpQual));
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                ServerConnection.Close();
            }
            try
            {
                string REPORTEDHOURS = "SELECT ActivityDuration from dbo.tbl_ActivityDetails  where UserID = '" + str + "' and Tesco_Date ='" + Tesco_Date + "'";
                //SqlCommand cmd2 = new SqlCommand(REPORTEDHOURS, ServerConnection);

                //ServerConnection.Open();
                //SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                //rdr.Read();
                //string reportedtotal = (rdr[0].ToString());

                //String[] splitval = reportedtotal.Split('.');
                int val1, val2;
                //val1 = Convert.ToInt16(splitval[0]);
                //val2 = Convert.ToInt16(splitval[1]);
                SqlDataAdapter daduration = new SqlDataAdapter(REPORTEDHOURS, ServerConnection);
                DataTable dtdur = new DataTable();
                daduration.Fill(dtdur);
                ArrayList Durationhour=new ArrayList();
                int rowcount = 0;
                foreach (DataRow dr in dtdur.Rows)
                {
                    Durationhour.Add(dr[0].ToString());
                    rowcount++;
                }
                int i1 = 0;
                int sum1 = 0, sum2 = 0;
               while(i1<rowcount)
                {
                    string x = Durationhour[i1].ToString();
                    String[] splitval = x.Split('.');
                    val1 = Convert.ToInt16(splitval[0]);
                    val2 = Convert.ToInt16(splitval[1]);
                    sum1 = sum1 + val1;
                    sum2 = sum2 + val2;
                    i1++;
                }

                while (sum2 >= 60)
                {
                   sum1++;
                    sum2 = sum2 - 60;

                }


                TextBox8.Text = Convert.ToString(sum1) + "." + Convert.ToString(sum2);
                daduration.Dispose();
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                ServerConnection.Close();
                
            }
            ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
            ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
            //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
            ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
            btnAdd.Enabled = true;
            btnSave.Enabled = true;
            //button3.Enabled = true;
            button4.Enabled = false;
            ImageButton delete = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
            delete.Visible = false;
          //  Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Do not forget to submit after the days activities are filled!!');", true);
            //string str = (string)Session["UserID"];
            Session["sestring1"] = str;
            //DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
           // SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

            try
            {
                string REPORTEDHOURS = "SELECT ActivityDuration from dbo.tbl_ActivityDetails  where UserID = '" + str + "' and Tesco_Date ='" + Tesco_Date + "'";
                //SqlCommand cmd2 = new SqlCommand(REPORTEDHOURS, ServerConnection);

                //ServerConnection.Open();
                //SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                //rdr.Read();
                //string reportedtotal = (rdr[0].ToString());

                //String[] splitval = reportedtotal.Split('.');
                int val11, val22;
                //val1 = Convert.ToInt16(splitval[0]);
                //val2 = Convert.ToInt16(splitval[1]);
                SqlDataAdapter daduration = new SqlDataAdapter(REPORTEDHOURS, ServerConnection);
                DataTable dtdur = new DataTable();
                daduration.Fill(dtdur);
                ArrayList Durationhour = new ArrayList();
                int rowcount = 0;
                foreach (DataRow dr in dtdur.Rows)
                {
                    Durationhour.Add(dr[0].ToString());
                    rowcount++;
                }
                int i11 = 0;
                int sum11 = 0, sum22 = 0;
                while(i11 < rowcount)
                {
                    string x = Durationhour[i11].ToString();
                    String[] splitval = x.Split('.');
                    val11 = Convert.ToInt16(splitval[0]);
                    val22 = Convert.ToInt16(splitval[1]);
                    sum11 = sum11 + val11;
                    sum22 = sum22 + val22;
                    i11++;
                }

                while (sum22 >= 60)
                {
                    sum11++;
                    sum22 = sum22 - 60;

                }
                Decimal Thresld =Convert.ToDecimal (Convert.ToString(sum11) + "." + Convert.ToString(sum22));
                //cmd2.Dispose();
                //rdr.Close();
                //int MinScheduledHours = Convert.ToInt16(ConfigurationManager.AppSettings["MinScheduledHour"].ToString());
                int MaxScheduledHours = Convert.ToInt16(ConfigurationManager.AppSettings["MaxScheduledHour"].ToString());

                if (Convert.ToDecimal(Thresld) < MaxScheduledHours)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Your Activity Duration is less than 9 hours.you will be redirected to comment page!!');", true);
                    Session["reportedhours"] = Thresld;
                    Response.AppendHeader("Refresh", "2;URL=CommentPage.aspx");
                }
                if (Convert.ToDecimal(Thresld) >MaxScheduledHours)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Wow..you worked more than 9 hours!!');", true);
                    Session["reportedhours"] = Thresld;
                    Response.AppendHeader("Refresh", "2;URL=CommentPage.aspx");
                }
                else
                {

                    //ImageButton btnAdd1 = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
                    //ImageButton btnSave1 = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
                    //ImageButton button31 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
                    //ImageButton button41 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
                    //btnAdd1.Enabled = false;
                    //btnSave1.Enabled = false;
                    //button31.Enabled = false;
                    //button41.Enabled = false;
                    Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Successfully submitted');", true);

                    Response.AppendHeader("Refresh", "2;URL=NewDayUpdate.aspx");

                    //Response.ClearContent();
                }

                ImageButton delete1 = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
                delete1.Visible = false;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                ServerConnection.Close();
            }

        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        }
    }
    }


    //protected void calendar2_Click(object sender, ImageClickEventArgs e)
    //{
    //    int selecCount = 0;
    //    if (ViewState["count"] != null)
    //    {
    //        selecCount = Convert.ToInt16(ViewState["count"].ToString());
    //    }
    //    SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

    //    //Calendar1.Visible = true;
    //    //txtdate.Text = Calendar1.SelectedDate.ToShortDateString().ToString();
    //    //Session["day"] = Calendar1.SelectedDate.DayOfWeek.ToString();
    //    Session["date"] = txtdate.Text;

    //    DateTime Tesco_Date=DateTime.Now;
    //    string str = (string)Session["UserID"];
    //    if (txtdate.Text != "")
    //    {
    //         Tesco_Date = Convert.ToDateTime(Session["date"]);
    //    }
    //    string countrowsavail = @"select count(*) from dbo.tbl_ActivityDetails WHERE UserID = '" + str
    //                             + "'and Tesco_Date = '" + Tesco_Date + "'";
    //    int countval = 0;
    //    DateTime OldDate = Convert.ToDateTime(Session["date1"]);
    //    try
    //    {
    //        ServerConnection.Open();
    //        SqlDataAdapter dacount = new SqlDataAdapter(countrowsavail, ServerConnection);
    //        DataTable tbcount = new DataTable();
    //        dacount.Fill(tbcount);
    //        //SqlDataReader rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection);
    //        //rdr3.Read();
    //        //countval = Convert.ToInt16(rdr3[0].ToString());
    //        TextBox txtDate = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtDate");
    //        //TextBox txtDay = (TextBox)grvStudentDetails.Rows[0].Cells[2].FindControl("txtDay");
    //        txtDate.Text = txtdate.Text;
    //        //txtDay.Text = Calendar1.SelectedDate.DayOfWeek.ToString();
    //        foreach (DataRow drcount in tbcount.Rows)
    //        {
    //            countval = Convert.ToInt16(drcount[0].ToString());
    //        }
    //        int uicount = Convert.ToInt16(Session["UIROWCOUNT"]);

    //        if (selecCount > 0)
    //        {
    //            for (int cdate = 1; cdate <= uicount - 1; cdate++)
    //            {
    //                TextBox txtDate1 = (TextBox)grvStudentDetails.Rows[cdate].Cells[1].FindControl("txtDate");
    //                //TextBox txtDay1 = (TextBox)grvStudentDetails.Rows[cdate].Cells[2].FindControl("txtDay");
    //                txtDate1.Text = txtdate.Text;
    //                //txtDay1.Text = Calendar1.SelectedDate.DayOfWeek.ToString();
    //            }
    //        }
    //    }

    //    catch (Exception ex)
    //    {

    //        Debug.Write(ex.Message);
    //    }
    //    finally
    //    {
    //        ServerConnection.Close();
    //    }

    //    if (countval == 0)
    //    {
    //        Button btnAdd = (Button)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
    //        Button btnSave = (Button)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
    //        Button button3 = (Button)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
    //        Button button4 = (Button)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
    //        btnAdd.Enabled = true;
    //        btnSave.Enabled = true;
    //        button3.Enabled = false;
    //        button4.Enabled = false;

    //    }
    //    else
    //    {
    //        Button btnAdd = (Button)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
    //        Button btnSave = (Button)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
    //        Button button3 = (Button)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
    //        Button button4 = (Button)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
    //        btnAdd.Enabled = false;
    //        btnSave.Enabled = false;
    //        button3.Enabled = false;
    //        button4.Enabled = true;
    //    }
    //    selecCount++;
    //    ViewState["count"] = selecCount;

    //}
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    if (TextBox8.Text == String.Empty || TextBox8.Text == "0.0")
    //    {
    //        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please enter valid Hours');", true);
    //    }
    //    else
    //    {
    //        // decimal checkval1 = Convert.ToDecimal(ViewState["reportedhours"].ToString());
    //        string str = (string)Session["UserID"];
    //        Session["sestring1"] = str;
    //        DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
    //        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

    //        try
    //        {
    //            string REPORTEDHOURS = "SELECT Sum(ActivityDuration) from dbo.tbl_ActivityDetails  where UserID = '" + str + "' and Tesco_Date ='" + Tesco_Date + "'";
    //            SqlCommand cmd2 = new SqlCommand(REPORTEDHOURS, ServerConnection);
    //            ServerConnection.Open();
    //            SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
    //            rdr.Read();
    //            string checkval1 = (rdr[0].ToString());
    //            cmd2.Dispose();
    //            rdr.Close();

    //            if (Convert.ToDecimal(checkval1) < 8)
    //            {
    //                Response.Redirect("CommentPage.aspx");
    //            }
    //            else
    //            {
    //                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Successfully submitted');", true);

    //                ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
    //                ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
    //                ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
    //                ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
    //                btnAdd.Enabled = false;
    //                btnSave.Enabled = false;
    //                button3.Enabled = false;
    //                button4.Enabled = false;
    //                Response.ClearContent();
    //            }

    //            ImageButton delete = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
    //            delete.Visible = false;
    //        }
    //        catch (Exception ex)
    //        {
    //            Debug.Write(ex.Message);
    //        }
    //        finally
    //        {
    //            ServerConnection.Close();
    //        }

    //    }
    //}
    protected void Button4_Click(object sender, EventArgs e)
    {
        ReSetRowData();
        ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
        ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
        //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
        ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
        btnAdd.Enabled = true;
        btnSave.Enabled = true;
        //button3.Enabled = false;
        button4.Enabled = false;
        //calendar2.Enabled = false;
        string str = (string)Session["UserID"];
        DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

        try
        {
            string REPORTEDHOURS = "SELECT ActivityDuration from dbo.tbl_ActivityDetails  where UserID = '" + str + "' and Tesco_Date ='" + Tesco_Date + "'";
            //SqlCommand cmd2 = new SqlCommand(REPORTEDHOURS, ServerConnection);

            //ServerConnection.Open();
            //SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
            //rdr.Read();
            //string reportedtotal = (rdr[0].ToString());

            //String[] splitval = reportedtotal.Split('.');
            int val1, val2;
            //val1 = Convert.ToInt16(splitval[0]);
            //val2 = Convert.ToInt16(splitval[1]);
            SqlDataAdapter daduration = new SqlDataAdapter(REPORTEDHOURS, ServerConnection);
            DataTable dtdur = new DataTable();
            daduration.Fill(dtdur);
            ArrayList Durationhour = new ArrayList();
            int rowcount = 0;
            foreach (DataRow dr in dtdur.Rows)
            {
                Durationhour.Add(dr[0].ToString());
                rowcount++;
            }
            int i1 = 0;
            int sum1 = 0, sum2 = 0;
            while (i1 < rowcount)
            {
                string x = Durationhour[i1].ToString();
                String[] splitval = x.Split('.');
                val1 = Convert.ToInt16(splitval[0]);
                val2 = Convert.ToInt16(splitval[1]);
                sum1 = sum1 + val1;
                sum2 = sum2 + val2;
                i1++;
            }

            while (sum2 >= 60)
            {
                sum1++;
                sum2 = sum2 - 60;

            }


            TextBox8.Text = Convert.ToString(sum1) + "." + Convert.ToString(sum2);
            daduration.Dispose();
            ImageButton delete = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
            delete.Visible = false;

        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
        finally
        {
            ServerConnection.Close();
        }
        //calendar2.Enabled = false;
        //Calendar1.Enabled = false;
    }
    private void ReSetRowData()
    {
        // FirstGridViewRow();
        SqlConnection ServerConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        try
        {
            int rowIndex = 0;
            string str = (string)Session["UserID"];
            DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
            string allvalues = @"select TeamID,ActivityID,ActivityDuration,Comments from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and Tesco_Date = '" + Tesco_Date + "'";
            SqlDataAdapter dadbtable = new SqlDataAdapter(allvalues, ServerConnection1);
            DataTable dt = new DataTable();
            dadbtable.Fill(dt);
            DataRow drCurrentRow = null;
            DataTable dt1 = (DataTable)ViewState["CurrentTable"];
            int cc = dt1.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    TextBox txtDate = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtDate");
                    //TextBox txtDay = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDay");
                    DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("drpTeam");
                    DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpActivity");
                    DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("drpHour");
                    DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("drpMin");
                    TextBox txtComments = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("txtComments");
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

                    try
                    {

                        string Query1 = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                        string query2 = "select ActivityName from dbo.tbl_Activity where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "') order by ActivityName ";
                        string query3 = "select Hours,Minutes from dbo.Duration";
                        conn1.Open();
                        SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                        SqlDataAdapter da = new SqlDataAdapter(Query1, conn1);
                        SqlDataAdapter da1 = new SqlDataAdapter(query2, conn1);
                        SqlDataAdapter da2 = new SqlDataAdapter(query3, conn1);
                        DataSet ds = new DataSet();
                        DataSet ds1 = new DataSet();
                        DataSet ds2 = new DataSet();
                        DataTable dt2 = new DataTable();
                        da.Fill(ds, "tb");
                        dt2 = ds.Tables["tb"];
                        da1.Fill(ds1, "tb1");
                        DataTable dt3 = new DataTable();
                        dt3 = ds1.Tables["tb1"];

                        da2.Fill(ds2, "tb2");
                        DataTable dt4 = new DataTable();
                        dt4 = ds2.Tables["tb2"];
                        //int count = 0;
                        String[] m = new String[10];
                        int totalcount = dt2.Rows.Count;
                        for (int count = 0; count < totalcount; count++)
                        {
                            drpTeam.Items.Add(dt2.Rows[count]["TeamName"].ToString());

                        }
                        int totalcount1 = dt3.Rows.Count;
                        for (int count = 0; count < totalcount1; count++)
                        {
                            drpActivity.Items.Add(dt3.Rows[count]["ActivityName"].ToString());
                            string n = dt3.Rows[count]["ActivityName"].ToString();


                        }
                        int totalcount2 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount2; count++)
                        {
                            drpHour.Items.Add(dt4.Rows[count]["Hours"].ToString());

                        }
                        int totalcount3 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount3; count++)
                        {
                            drpMin.Items.Add(dt4.Rows[count]["Minutes"].ToString());

                        }
                        cmd1.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }
                    finally
                    {
                        conn1.Close();
                    }

                    try
                    {
                        string TeamName = "";
                        string ActivityName = "";
                        string TeamID = dt.Rows[i - 1]["TeamID"].ToString();
                        string QueryTeam1 = "select TeamName from dbo.tbl_Team where TeamID='" + TeamID + "'";
                        SqlDataAdapter dateam = new SqlDataAdapter(QueryTeam1, ServerConnection1);
                        DataTable dtTeam = new DataTable();
                        dateam.Fill(dtTeam);
                        int teamcount = dtTeam.Rows.Count;
                        for (int count = 0; count < teamcount; count++)
                        {
                            TeamName = (dtTeam.Rows[count]["TeamName"].ToString());

                        }
                        drpTeam.SelectedValue = TeamName;
                        string ActivityID = dt.Rows[i - 1]["ActivityID"].ToString();
                        string QueryActivity = "select ActivityName from dbo.tbl_Activity where TeamID='" + TeamID + "' and  ActivityID='" + ActivityID + "'";
                        SqlDataAdapter daActivity = new SqlDataAdapter(QueryActivity, ServerConnection1);
                        DataTable dtActivity = new DataTable();
                        daActivity.Fill(dtActivity);
                        int Activitycount = dtActivity.Rows.Count;
                        for (int count = 0; count < Activitycount; count++)
                        {
                            ActivityName = (dtActivity.Rows[count]["ActivityName"].ToString());

                        }
                        drpActivity.SelectedValue = ActivityName;
                        string ActivityDuration = dt.Rows[i - 1]["ActivityDuration"].ToString();
                        String[] splitval = ActivityDuration.Split('.');
                        Double val1 = 0.00d, val2 = 0.00d;
                        val1 = Convert.ToDouble(splitval[0] + "." + "00");
                        val2 = Convert.ToDouble("0" + "." + splitval[1]);
                        while (val2 > 60)
                        {
                            val1++;
                            val2 = val2 - 60;

                        }
                        string xx = Convert.ToString(val1) + ".00";
                        drpHour.SelectedValue = xx;
                        int cx = 0;
                        string yy = "";
                        foreach (char ss in Convert.ToString(val2))
                        {
                            cx++;
                        }
                        if (cx == 3)
                        {
                            yy = Convert.ToString(val2) + "0";
                        }
                        else
                        {
                            if (cx == 1)
                            {
                                yy = Convert.ToString(val2) + ".00";
                            }
                            else
                            {
                                yy = Convert.ToString(val2);
                            }
                        }
                        drpMin.SelectedValue = yy;

                        string Comments = dt.Rows[i - 1]["Comments"].ToString();
                        txtComments.Text = Comments;
                        if (i != dt.Rows.Count)
                        {
                            drCurrentRow = dt1.NewRow();
                            drCurrentRow["RowNumber"] = i + 1;
                        }
                        txtDate.Text = Session["date"].ToString();
                        //txtDay.Text = Session["day"].ToString();
                        dt1.Rows[i - 1]["Col1"] = txtDate.Text;
                        //dt1.Rows[i - 1]["Col2"] = txtDay.Text;
                        dt1.Rows[i - 1]["Col3"] = drpTeam.SelectedValue;
                        dt1.Rows[i - 1]["Col4"] = drpActivity.SelectedValue;
                        dt1.Rows[i - 1]["Col5"] = drpHour.SelectedValue;
                        dt1.Rows[i - 1]["Col6"] = drpMin.SelectedValue;
                        dt1.Rows[i - 1]["Col7"] = txtComments.Text;
                        rowIndex++;
                        dt1.Rows.Add(drCurrentRow);
                        ViewState["CurrentTable"] = dt1;

                        grvStudentDetails.DataSource = dt1;
                        grvStudentDetails.DataBind();
                        ViewState["ival"] = i;
                        ReSetPreviousData();
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex.Message);
                    }
                    finally
                    {
                        ServerConnection1.Close();
                    }
                }


            }

            else
            {
                Response.Write("ViewState is null");
            }
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
        finally
        {
            ServerConnection1.Close();
        }


    }
    private void ReSetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                //recreating all the rows with its control,where number of row to be created here is
                //same as it was  after execution of addnewrow() function
                int cval = Convert.ToInt16(ViewState["ival"]);
                string str = (string)Session["UserID"];
                for (int i = 0; i < cval; i++)
                {
                    TextBox txtDate = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[1].FindControl("txtDate");
                    //TextBox txtDay = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("txtDay");
                    DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[2].FindControl("drpTeam");
                    DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[3].FindControl("drpActivity");
                    DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[4].FindControl("drpHour");
                    DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[rowIndex].Cells[5].FindControl("drpMin");
                    TextBox txtComments = (TextBox)grvStudentDetails.Rows[rowIndex].Cells[6].FindControl("txtComments");
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

                    try
                    {

                        string Query1 = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                        string query2 = "select ActivityName from dbo.tbl_Activity where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "') order by ActivityName";
                        string query3 = "select Hours,Minutes from dbo.Duration";
                        conn1.Open();
                        SqlCommand cmd1 = new SqlCommand(Query1, conn1);
                        SqlDataAdapter da = new SqlDataAdapter(Query1, conn1);
                        SqlDataAdapter da1 = new SqlDataAdapter(query2, conn1);
                        SqlDataAdapter da2 = new SqlDataAdapter(query3, conn1);
                        DataSet ds = new DataSet();
                        DataSet ds1 = new DataSet();
                        DataSet ds2 = new DataSet();
                        DataTable dt2 = new DataTable();
                        da.Fill(ds, "tb");
                        dt2 = ds.Tables["tb"];
                        da1.Fill(ds1, "tb1");
                        DataTable dt3 = new DataTable();
                        dt3 = ds1.Tables["tb1"];

                        da2.Fill(ds2, "tb2");
                        DataTable dt4 = new DataTable();
                        dt4 = ds2.Tables["tb2"];
                        //int count = 0;
                        String[] m = new String[10];
                        int totalcount = dt2.Rows.Count;
                        for (int count = 0; count < totalcount; count++)
                        {
                            drpTeam.Items.Add(dt2.Rows[count]["TeamName"].ToString());

                        }
                        int totalcount1 = dt3.Rows.Count;
                        for (int count = 0; count < totalcount1; count++)
                        {
                            drpActivity.Items.Add(dt3.Rows[count]["ActivityName"].ToString());
                            string n = dt3.Rows[count]["ActivityName"].ToString();


                        }
                        int totalcount2 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount2; count++)
                        {
                            drpHour.Items.Add(dt4.Rows[count]["Hours"].ToString());

                        }
                        int totalcount3 = dt4.Rows.Count;
                        for (int count = 0; count < totalcount3; count++)
                        {
                            drpMin.Items.Add(dt4.Rows[count]["Minutes"].ToString());

                        }
                        cmd1.Dispose();
                    }
                    finally
                    {
                        conn1.Close();
                    }
                    //txtDate.Text = Session["date"].ToString();
                    //txtDay.Text = Session["day"].ToString();
                    dt.Rows[i]["Col1"] = Session["date"].ToString();
                   // dt.Rows[i]["Col2"] = Session["day"].ToString();
                    //retreiving value of each control of each row at a time
                    grvStudentDetails.Rows[i].Cells[0].Text = Convert.ToString(i + 1);
                    txtDate.Text = dt.Rows[i]["Col1"].ToString();
                    //txtDay.Text = dt.Rows[i]["Col2"].ToString();
                    drpTeam.SelectedValue = dt.Rows[i]["Col3"].ToString();
                    drpActivity.SelectedValue = dt.Rows[i]["Col4"].ToString();
                    drpHour.SelectedValue = dt.Rows[i]["Col5"].ToString();
                    drpMin.SelectedValue = dt.Rows[i]["Col6"].ToString();
                    txtComments.Text = dt.Rows[i]["Col7"].ToString();
                    //DrpQualification.SelectedValue = dt.Rows[i]["Col5"].ToString();
                    // DrpQualification.SelectedValue = "mails";
                    rowIndex++;
                }
            }
        }
    }
    protected void txtdate_TextChanged(object sender, EventArgs e)
    {
        if (txtdate.Text == string.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Selected date cannot be empty!!');", true);
            Response.AppendHeader("Refresh", "1;URL=NewDayUpdate.aspx");


        }
       else if (Convert.ToDateTime(txtdate.Text) < Convert.ToDateTime(Session["MinDate"]) || Convert.ToDateTime(txtdate.Text) > Convert.ToDateTime(Session["MaxDate"]))
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please select valid date!!');", true);
            Response.AppendHeader("Refresh", "1;URL=NewDayUpdate.aspx");

        }
        else
        {
            SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            string str = (string)Session["UserID"];

            if (Session["selected Date"] != null)
            {
                if (Convert.ToDateTime(txtdate.Text) != Convert.ToDateTime(Session["selected Date"]))
                { 
                //wow
                    //grvStudentDetails.DataSource = "";
                    //grvStudentDetails.DataBind();
                    //grvStudentDetails.DeleteRow(3);
                    FirstGridViewRow();
                    ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
                    ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
                    //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
                    ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
                    btnAdd.Enabled = false;
                    btnSave.Enabled = false;
                    //button3.Enabled = false;
                    button4.Enabled = false;
                    //string str = (string)Session["UserID"];
                    Session["sestring1"] = str;
                    Lbltpx.Text = str;
                    try
                    {
                        string Query = "SELECT * FROM tbl_UserDetails WHERE UserID = '" + str + "'";
                        string Query1 = "select ShiftTime from dbo.tbl_Shift";
                        SqlCommand cmd = new SqlCommand(Query, ServerConnection);
                        ServerConnection.Open();
                        SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        rdr.Read();
                        lblnameval.Text = rdr[2].ToString() + " " + rdr[3].ToString();
                        Session["UserName"] = lblnameval.Text;
                        Lbldesig.Text = rdr[4].ToString();
                        Session["Desig"] = rdr[4].ToString();
                        rdr.Close();
                        cmd.Dispose();
                        SqlDataAdapter da = new SqlDataAdapter(Query1, ServerConnection);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "shift");
                        DataTable shiftTb = new DataTable();
                        shiftTb = ds.Tables["shift"];
                        int TotlCount = shiftTb.Rows.Count;
                        for (int count = 0; count < TotlCount; count++)
                        {
                            DropDownList1.Items.Add(shiftTb.Rows[count]["ShiftTime"].ToString());
                        }

                        TextBox txtDate = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtDate");
                        txtDate.Text = "";

                        //                Session["entereddate"] = txtDate.ToString();

                        DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[0].Cells[2].FindControl("drpTeam");
                        DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[0].Cells[3].FindControl("drpActivity");
                        DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[0].Cells[4].FindControl("drpHour");
                        DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[0].Cells[5].FindControl("drpMin");
                        TextBox txtComments = (TextBox)grvStudentDetails.Rows[0].Cells[6].FindControl("txtComments");
                        ImageButton delete = (ImageButton)grvStudentDetails.Rows[0].Cells[7].FindControl("deleteButton");
                        delete.Visible = false;

                        try
                        {
                            ServerConnection.Open();
                            string QueryTeam = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                            string queryActivity = "select ActivityName from dbo.tbl_Activity where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "') order by ActivityName ";
                            string queryDuration = "select Hours,Minutes from dbo.Duration";

                            SqlCommand cmd1 = new SqlCommand(QueryTeam, ServerConnection);
                            SqlDataAdapter daTeam = new SqlDataAdapter(QueryTeam, ServerConnection);
                            SqlDataAdapter da1 = new SqlDataAdapter(queryActivity, ServerConnection);
                            SqlDataAdapter da2 = new SqlDataAdapter(queryDuration, ServerConnection);
                            DataSet dsTeam = new DataSet();
                            DataSet ds1 = new DataSet();
                            DataSet ds2 = new DataSet();
                            DataTable dt2 = new DataTable();
                            daTeam.Fill(dsTeam, "tb");
                            dt2 = dsTeam.Tables["tb"];
                            da1.Fill(ds1, "tb1");
                            DataTable dt3 = new DataTable();
                            dt3 = ds1.Tables["tb1"];

                            da2.Fill(ds2, "tb2");
                            DataTable dt4 = new DataTable();
                            dt4 = ds2.Tables["tb2"];
                            //int count = 0;
                            String[] m = new String[10];
                            int totalcount = dt2.Rows.Count;
                            for (int count = 0; count < totalcount; count++)
                            {
                                drpTeam.Items.Add(dt2.Rows[count]["TeamName"].ToString());

                            }
                            int totalcount1 = dt3.Rows.Count;
                            for (int count = 0; count < totalcount1; count++)
                            {
                                drpActivity.Items.Add(dt3.Rows[count]["ActivityName"].ToString());
                                string n = dt3.Rows[count]["ActivityName"].ToString();


                            }
                            int totalcount2 = dt4.Rows.Count;
                            for (int count = 0; count < totalcount2; count++)
                            {
                                drpHour.Items.Add(dt4.Rows[count]["Hours"].ToString());

                            }
                            int totalcount3 = dt4.Rows.Count;
                            for (int count = 0; count < totalcount3; count++)
                            {
                                drpMin.Items.Add(dt4.Rows[count]["Minutes"].ToString());

                            }
                            cmd1.Dispose();
                        }
                        finally
                        {
                            ServerConnection.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                        Debug.Write(ex.Message);
                    }
                    finally
                    {
                        ServerConnection.Close();
                    }
                }
            }
            int selecCount = 0;
        if (ViewState["count"] != null)
        {
            selecCount = Convert.ToInt16(ViewState["count"].ToString());
        }

        //Calendar1.Visible = true;
        //txtdate.Text = Calendar1.SelectedDate.ToShortDateString().ToString();
        //Session["day"] = Calendar1.SelectedDate.DayOfWeek.ToString();
        Session["date"] = txtdate.Text;


        //string str = (string)Session["UserID"];
        DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
        string countrowsavail = @"select count(*) from dbo.tbl_ActivityDetails WHERE UserID = '" + str
                                 + "'and Tesco_Date = '" + Tesco_Date + "'";
        int countval = 0;
        DateTime OldDate = Convert.ToDateTime(Session["date1"]);
        try
        {
            ServerConnection.Open();
            SqlDataAdapter dacount = new SqlDataAdapter(countrowsavail, ServerConnection);
            DataTable tbcount = new DataTable();
            dacount.Fill(tbcount);
            //SqlDataReader rdr3 = cmd3.ExecuteReader(CommandBehavior.CloseConnection);
            //rdr3.Read();
            //countval = Convert.ToInt16(rdr3[0].ToString());
            
            //message if data available for the given date
           // DataRow Drdate = new DataRow();

            int chkcount = Convert.ToInt16(tbcount.Rows[0][0].ToString());
            

            if (chkcount > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Data present for the given date.Please click on view for any changes');", true);

            }
            else if (chkcount == 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Data available for given date.please add details');", true);

            }


            TextBox txtDate = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtDate");
            //TextBox txtDay = (TextBox)grvStudentDetails.Rows[0].Cells[2].FindControl("txtDay");
            txtDate.Text = txtdate.Text;
            //txtDay.Text = Calendar1.SelectedDate.DayOfWeek.ToString();
            foreach (DataRow drcount in tbcount.Rows)
            {
                countval = Convert.ToInt16(drcount[0].ToString());
            }
            int uicount = Convert.ToInt16(Session["UIROWCOUNT"]);

            if (selecCount > 0)
            {
                for (int cdate = 1; cdate <= uicount - 1; cdate++)
                {
                    TextBox txtDate1 = (TextBox)grvStudentDetails.Rows[cdate].Cells[1].FindControl("txtDate");
                    //TextBox txtDay1 = (TextBox)grvStudentDetails.Rows[cdate].Cells[2].FindControl("txtDay");
                    txtDate1.Text = txtdate.Text;
                    //txtDay1.Text = Calendar1.SelectedDate.DayOfWeek.ToString();
                }
            }


          

        }

        catch (Exception ex)
        {

            Debug.Write(ex.Message);
        }
        finally
        {
            ServerConnection.Close();
        }

        if (countval == 0)
        {
            ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
            ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
            //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
            ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
            btnAdd.Enabled = true;
            btnSave.Enabled = true;
            //button3.Enabled = false;
            button4.Enabled = false;

        }
        else
        {
            ImageButton btnAdd = (ImageButton)grvStudentDetails.FooterRow.Cells[7].FindControl("ButtonAdd");
            ImageButton btnSave = (ImageButton)grvStudentDetails.FooterRow.Cells[2].FindControl("btnSave");
            //ImageButton button3 = (ImageButton)grvStudentDetails.FooterRow.Cells[3].FindControl("Button3");
            ImageButton button4 = (ImageButton)grvStudentDetails.FooterRow.Cells[4].FindControl("Button4");
            btnAdd.Enabled = false;
            btnSave.Enabled = false;
            //button3.Enabled = false;
            button4.Enabled = true;
        }
        selecCount++;
        ViewState["count"] = selecCount;
        //calendar2.Enabled = false;
        Session["selected Date"] = txtdate.Text;
    }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        string dateselected = DropDownList1.SelectedItem.ToString();
        string userid = Session["sestring1"].ToString();
        try
        {
            string countdatequery = "select * from dbo.tbl_ActivityDetails where Tesco_Date = '" + dateselected
                + "'and " + "UserID = '" + userid + "' group by UserID";
            SqlCommand cmd = new SqlCommand(countdatequery, ServerConnection);
            ServerConnection.Open();
            SqlDataAdapter da = new SqlDataAdapter(countdatequery, ServerConnection);
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            da.Fill(ds, "datecount");
            dt1 = ds.Tables["datecount"];
            int datecount = dt1.Rows.Count;
            if (datecount > 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Data present for the given date.Please click on view for updating');", true);

            }

            cmd.Dispose();
        }
        
        catch (Exception ex)
            {

                Debug.Write(ex.Message);
            }
        finally
            {
                ServerConnection.Close();
            }
   }


    protected void calendar2_Click(object sender, ImageClickEventArgs e)
    {

    }
}