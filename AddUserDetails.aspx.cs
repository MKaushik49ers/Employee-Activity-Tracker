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
using System.Diagnostics;
using System.Data.SqlClient;

public partial class AddUserDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        txtUserID.Focus();
        try
        {

            string Query1 = "select TeamName from dbo.tbl_Team";
            SqlCommand cmd1 = new SqlCommand(Query1, conn1);
            SqlDataAdapter da2 = new SqlDataAdapter(Query1, conn1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
            {

                ListBox1.Items.Add(dr2[0].ToString());
            }
            string Select_Shift = "select ShiftTime from dbo.tbl_Shift";
            SqlDataAdapter da = new SqlDataAdapter(Select_Shift, conn1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                ListBox2.Items.Add(dr[0].ToString());
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

    }
    protected void ImgAdd_Click_Click(object sender, ImageClickEventArgs e)
    {
       

    
    }
    //protected void btnSave_Click(object sender, EventArgs e)
    //{
       

    //}
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        // conn1.Open();
        string Qcount = @"select count(*) from dbo.tbl_UserDetails WHERE UserID = '" + txtUserID.Text + "'";
        SqlDataAdapter dacount = new SqlDataAdapter(Qcount, conn1);
        DataTable dtcount = new DataTable();
        dacount.Fill(dtcount);
        int count = 0;
        foreach (DataRow dr in dtcount.Rows)
        {
            count = Convert.ToInt16(dr[0].ToString());
        }
        if (count != 0)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('This User already exist!!');", true);

        }
        else
        {
            string str = (string)Session["UserID"];
            try
            {
                ArrayList listTeam = new ArrayList();
                foreach (ListItem list in ListBox1.Items)
                {
                    if (list.Selected == true)
                    {
                        listTeam.Add(list);
                    }
                }
                ArrayList listShift = new ArrayList();
                foreach (ListItem list in ListBox2.Items)
                {
                    if (list.Selected == true)
                    {
                        listShift.Add(list);
                    }
                }
                string CreatedBy = str;
                DateTime CreatedOn = DateTime.Now;
                string UpdatedBy = str;
                DateTime UpdatedOn = DateTime.Now;
                for (int i = 0; i < listTeam.Count; i++)
                {
                    string QTeamID = "select TeamID from dbo.tbl_Team where TeamName='" + listTeam[i] + "'";
                    SqlDataAdapter dTeam = new SqlDataAdapter(QTeamID, conn1);
                    DataTable dtTeamID = new DataTable();
                    dTeam.Fill(dtTeamID);
                    int TeamID = 0;
                    foreach (DataRow dr in dtTeamID.Rows)
                    {
                        TeamID = Convert.ToInt16(dr[0].ToString());
                    }
                    string QShiftID = "select ShiftID from dbo.tbl_Shift where ShiftTime='" + listShift[0] + "'";
                    SqlDataAdapter dshift = new SqlDataAdapter(QShiftID, conn1);
                    DataTable dtshiftID = new DataTable();
                    dshift.Fill(dtshiftID);
                    int ShiftID = 0;
                    foreach (DataRow dr in dtshiftID.Rows)
                    {
                        ShiftID = Convert.ToInt16(dr[0].ToString());
                    }
                    try
                    {
                        string Qinsert = "insert into dbo.tbl_UserDetails values('" + txtUserID.Text.ToLower() + "','" + TeamID + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtDesignation.Text + "','" + ShiftID + "','" + CreatedOn + "','" + CreatedBy + "','" + UpdatedOn + "','" + UpdatedBy + "')";
                        SqlCommand cmdinsert = new SqlCommand(Qinsert, conn1);
                        conn1.Open();
                        cmdinsert.ExecuteNonQuery();
                        cmdinsert.Dispose();
                    }
                    finally
                    {
                        conn1.Close();
                    }
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
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Saved Successfully');", true);
            Response.AppendHeader("Refresh", "1;URL=AddUserDetails.aspx");



        }
    }
}
