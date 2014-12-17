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

public partial class _Default : System.Web.UI.Page
{
    DateTime mindate;
    protected void Page_Load(object sender, EventArgs e)
    {

        RangeValidator2.MinimumValue = DateTime.Now.AddMonths(-12).ToShortDateString();
        RangeValidator2.MaximumValue = DateTime.Now.ToShortDateString();
        if (TextBox7.Text!="")
        {
            //DateTime mindate1 = Convert.ToDateTime(ViewState["date"].ToString());
            //RangeValidator1.MinimumValue = mindate1.ToShortDateString();
            //RangeValidator1.MaximumValue = System.DateTime.Now.ToShortDateString();
            RangeValidator1.MinimumValue = Convert.ToDateTime(TextBox7.Text).ToShortDateString();
            RangeValidator2.MaximumValue = DateTime.Now.ToShortDateString();
        }
        else
        {
            RangeValidator1.MinimumValue = System.DateTime.MinValue.ToShortDateString();
            RangeValidator1.MaximumValue = System.DateTime.MaxValue.ToShortDateString();
        }
    
        if (!Page.IsPostBack)
        {

           
            FirstGridViewRow();
            TextBox txtDate = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtDate");
            txtDate.Text = "";
            DropDownList drpTeam = (DropDownList)grvStudentDetails.Rows[0].Cells[2].FindControl("drpTeam");
            DropDownList drpActivity = (DropDownList)grvStudentDetails.Rows[0].Cells[3].FindControl("drpActivity");
            DropDownList drpHour = (DropDownList)grvStudentDetails.Rows[0].Cells[4].FindControl("drpHour");
            DropDownList drpMin = (DropDownList)grvStudentDetails.Rows[0].Cells[5].FindControl("drpMin");
            TextBox txtComments = (TextBox)grvStudentDetails.Rows[0].Cells[6].FindControl("txtComments");
            SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            string str = (string)Session["UserID"];
            try
            {
                ServerConnection.Open();
                string QueryTeam = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                string queryActivity = "select ActivityName from dbo.tbl_Activity";
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
            if (Session["count"] != null)
            {
                int countval = Convert.ToInt16(Session["count"].ToString());
                if (countval == 0)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('No Details available for this period!!');", true);

                }
        }
       
        }
   
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (TextBox7.Text == String.Empty || TextBox8.Text == String.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Select a valid Date');", true);

        }
        else
        {

            ReSetRowData();
            if (ViewState["date"] != null)
            {
                DateTime mindate1 = System.DateTime.Now;
                
            }
            Panel5.Visible = true;
        }

    }
    private void FirstGridViewRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Col1", typeof(string)));
        //dt.Columns.Add(new DataColumn("Col2", typeof(string)));
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
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        try
        {
            string str = "HS72";
            string Query1 = "select TeamName from dbo.tbl_Team";
            conn1.Open();
            SqlCommand cmd1 = new SqlCommand(Query1, conn1);
            SqlDataAdapter da = new SqlDataAdapter(Query1, conn1);
            DataSet ds = new DataSet();
            DataTable dt2 = new DataTable();
            da.Fill(ds, "tb");
            dt2 = ds.Tables["tb"];
            //int count = 0;
            cmd1.Dispose();
        }
        finally
        {
            conn1.Close();
        }
        //dr["Col5"] = string.Empty;
        dt.Rows.Add(dr);
        ViewState["CurrentTable"] = dt;
        grvStudentDetails.DataSource = dt;
        grvStudentDetails.DataBind();


        TextBox txn = (TextBox)grvStudentDetails.Rows[0].Cells[1].FindControl("txtDate");
        txn.Focus();
        Button btnAdd = (Button)grvStudentDetails.FooterRow.Cells[2].FindControl("ButtonAdd");
    }
    private void ReSetRowData()
    {
        DateTime Fromdate=Convert.ToDateTime(TextBox7.Text);
        DateTime ToDate=Convert.ToDateTime(TextBox8.Text);
        
        // FirstGridViewRow();
        SqlConnection ServerConnection1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        try
        {
            string str = (string)Session["UserID"];
            string countval = @"select count(*) from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and Tesco_Date between '"
                           + Fromdate + "'and'" + ToDate + "'";
            SqlDataAdapter dacount = new SqlDataAdapter(countval,ServerConnection1);
            DataTable dtcount = new DataTable();
            dacount.Fill(dtcount);
            int cval=0;
            foreach (DataRow dr in dtcount.Rows)
            {
                cval = Convert.ToInt16(dr[0].ToString());
            }
            if (cval == 0)
            {
                Session["count"] = cval;
                Response.Redirect("MyView.aspx",false);
            }
            int rowIndex = 0;
            
            string allvalues =  @"select TeamID,Tesco_Date,ActivityID,ActivityDuration,Comments from dbo.tbl_ActivityDetails WHERE UserID = '" + str + "' and Tesco_Date between '"
                                       + Fromdate + "'and'" + ToDate + "'order by Tesco_Date asc";

            SqlDataAdapter dadbtable = new SqlDataAdapter(allvalues, ServerConnection1);
            DataTable dt = new DataTable();
            dadbtable.Fill(dt);
            DataRow drCurrentRow = null;
            if (Page.IsPostBack)
            {
                FirstGridViewRow();
            }
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
                    txtDate.Enabled = false;
                    drpActivity.Enabled = false;
                    drpTeam.Enabled = false;
                    drpHour.Enabled = false;
                    drpMin.Enabled = false;
                    txtComments.Enabled = false;
                    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

                    try
                    {

                        string Query1 = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                        string query2 = "select ActivityName from dbo.tbl_Activity";
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
                        string QueryActivity = "select ActivityName from dbo.tbl_Activity where ActivityID='" + ActivityID + "'";
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
                        if (i < dt.Rows.Count)
                        {
                            drCurrentRow = dt1.NewRow();
                            drCurrentRow["RowNumber"] = i + 1;
                        }
                        txtDate.Text = dt.Rows[i - 1]["Tesco_Date"].ToString();
                        Session["date1"] = dt.Rows[i - 1]["Tesco_Date"].ToString();
                        dt1.Rows[i - 1]["Col1"] = txtDate.Text;
                        dt1.Rows[i - 1]["Col3"] = drpTeam.SelectedValue;
                        dt1.Rows[i - 1]["Col4"] = drpActivity.SelectedValue;
                        dt1.Rows[i - 1]["Col5"] = drpHour.SelectedValue;
                        dt1.Rows[i - 1]["Col6"] = drpMin.SelectedValue;
                        dt1.Rows[i - 1]["Col7"] = txtComments.Text;
                        if (i < dt.Rows.Count)
                        {
                            rowIndex++;
                            dt1.Rows.Add(drCurrentRow);
                        }
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
            int cval = Convert.ToInt16(ViewState["ival"]);
            if ((cval+1) > 0)
            {
                //recreating all the rows with its control,where number of row to be created here is
                //same as it was  after execution of addnewrow() function
                
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
                    txtDate.Enabled = false;
                    drpActivity.Enabled = false;
                    drpTeam.Enabled = false;
                    drpHour.Enabled = false;
                    drpMin.Enabled = false;
                    txtComments.Enabled = false;
                    try
                    {

                        string Query1 = "select TeamName from dbo.tbl_Team   where TeamID in (Select TeamID from dbo.tbl_UserDetails where UserID='" + str + "')";
                        string query2 = "select ActivityName from dbo.tbl_Activity";
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
                    //dt.Rows[i]["Col1"] = Session["date1"].ToString();
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
   
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {
        mindate = Convert.ToDateTime(TextBox7.Text);
        ViewState["date"] = mindate;
      
        
    }
    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
       
        
    }
}
