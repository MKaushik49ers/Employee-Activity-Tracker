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

public partial class EditUserDetails : System.Web.UI.Page
{
    int clickcount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = btnGo.UniqueID;
        txtUserID.Focus();

        if (!Page.IsPostBack)
        {

            string str1 = (string)Session["sestring1"];
            
        }

       // Button1.Enabled = false;
        //Button1.Visible = false;
        //btnUser.Enabled = false;
        //btnUser.Visible = false;

        ImageButton2.Enabled = false;
        ImageButton2.Visible = false;
        ImageButton3.Enabled = false;
        ImageButton3.Visible = false;
        
        ListBox1.Visible = false;
        ListBox2.Visible = false;
        txtDesignation.Visible = false;
        txtFirstName.Visible = false;
        txtLastName.Visible = false;
        lblDesignation.Visible = false;
        lblFirstName.Visible = false;
        lblLastName.Visible = false;
        lblTeamID.Visible = false;
        lblShiftID.Visible = false;



    }
     

protected void btnGo_Click(object sender, ImageClickEventArgs e)
{
  
    if (ViewState["count"]!= null)
    {
        clickcount = Convert.ToInt16(ViewState["count"].ToString());

        if (clickcount > 0)
        {
            ListBox1.Items.Clear();
            ListBox2.Items.Clear();
            txtDesignation.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";

        }
    }
    SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
    // conn1.Open();
    string Qcount = @"select count(*) from dbo.tbl_UserDetails WHERE UserID = '" + txtUserID.Text.ToLower()+ "'";
    SqlDataAdapter dacount = new SqlDataAdapter(Qcount,conn1);
    DataTable dtcount = new DataTable();
    dacount.Fill(dtcount);
    int count = 0;
    foreach (DataRow dr in dtcount.Rows)
    {
        count =Convert.ToInt16( dr[0].ToString());
    }
    if (count == 0)
    {
        
        //btnUser.Enabled = false;
        //btnUser.Visible = false;

        ImageButton2.Enabled = false;
        ImageButton2.Visible = false;
        ImageButton3.Enabled = false;
        ImageButton3.Visible = false;

        ListBox1.Visible = false;
        ListBox2.Visible = false;
        txtDesignation.Visible = false;
        txtFirstName.Visible = false;
        txtLastName.Visible = false;
        lblDesignation.Visible = false;
        lblFirstName.Visible = false;
        lblLastName.Visible = false;
        lblTeamID.Visible = false;
        lblShiftID.Visible = false;
        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('This User Does not exist!!');", true);
     
    }
    else
    {
        try
        {
            string Select_Shift = "select ShiftTime from dbo.tbl_Shift";
            SqlDataAdapter da = new SqlDataAdapter(Select_Shift, conn1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                ListBox2.Items.Add(dr[0].ToString());
            }


            //TeamName to Dropdown list


            string Query1 = "select TeamName from dbo.tbl_Team";
            SqlCommand cmd1 = new SqlCommand(Query1, conn1);
            SqlDataAdapter da2 = new SqlDataAdapter(Query1, conn1);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            foreach (DataRow dr2 in dt2.Rows)
            {

                ListBox1.Items.Add(dr2[0].ToString());
            }

            string Qteam = "select TeamName from dbo.tbl_Team where TeamID  in (select TeamID from  dbo.tbl_UserDetails where UserID='" + txtUserID.Text.ToLower() + "')";
            SqlDataAdapter daTeam = new SqlDataAdapter(Qteam, conn1);
            DataTable dtTEam = new DataTable();
            daTeam.Fill(dtTEam);
            foreach (DataRow drTeam in dtTEam.Rows)
            {
                for (int cTeam = 0; cTeam <= ListBox1.Items.Count - 1; cTeam++)
                {
                    if (ListBox1.Items[cTeam].Text == drTeam[0].ToString())
                    {
                        ListBox1.Items[cTeam].Selected = true;
                    }
                }
            }

            string Qshift = "select ShiftTime from dbo.tbl_Shift where ShiftID in (select ShiftID from  dbo.tbl_UserDetails where UserID='" + txtUserID.Text.ToLower() + "')";
            SqlDataAdapter daShift = new SqlDataAdapter(Qshift, conn1);
            DataTable dtShift = new DataTable();
            daShift.Fill(dtShift);
            foreach (DataRow drShift in dtShift.Rows)
            {
                for (int cShift = 0; cShift <= ListBox2.Items.Count - 1; cShift++)
                {
                    if (ListBox2.Items[cShift].Text == drShift[0].ToString())
                    {
                        ListBox2.Items[cShift].Selected = true;
                    }
                }
            }

            string QName = "select FirstName,LastName,Designation from dbo.tbl_UserDetails where UserID='" + txtUserID.Text.ToLower() + "'";
            SqlDataAdapter daName = new SqlDataAdapter(QName, conn1);
            DataTable dtName = new DataTable();
            daName.Fill(dtName);
            foreach (DataRow drName in dtName.Rows)
            {
                txtFirstName.Text = drName[0].ToString();
                txtLastName.Text = drName[1].ToString();
                txtDesignation.Text = drName[2].ToString();
            }
        }//try end here 
        catch (Exception ex)
        {

            Debug.Write(ex.Message);
        }

        finally
        {
            conn1.Close();
        }
        //btnUser.Enabled = true;
        //btnUser.Visible = true;

        ImageButton2.Enabled = true;
        ImageButton2.Visible = true;
        ImageButton3.Enabled = true;
        ImageButton3.Visible = true;

        ListBox1.Visible = true;
        ListBox2.Visible = true;
        txtDesignation.Visible = true;
        txtFirstName.Visible = true;
        txtLastName.Visible = true;
        lblDesignation.Visible = true;
        lblFirstName.Visible = true;
        lblLastName.Visible = true;
        lblTeamID.Visible = true;
        lblShiftID.Visible = true;
    }
    clickcount++;
    ViewState["count"] = clickcount;
 //   Button1.Enabled = true;
  //  Button1.Visible = true; ;
    
}
    protected void btnUser_Click(object sender, EventArgs e)
    {
        }




 
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
   
      
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
     
    }
    protected void txtUserID_TextChanged(object sender, EventArgs e)
    {
        btnGo.Enabled = true;
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        ListBox1.Enabled = true;
        txtFirstName.Enabled = true;
        txtLastName.Enabled = true;
        ListBox2.Enabled = true;
        txtDesignation.Enabled = true;
        btnGo.Enabled = false;
        //   Button1.Enabled = true;
        //  Button1.Visible = true; ;
        //btnUser.Enabled = true;
        //btnUser.Visible = true;


        ImageButton2.Enabled = true;
        ImageButton2.Visible = true;
        ImageButton3.Enabled = true;
        ImageButton3.Visible = true;

        ListBox1.Visible = true;
        ListBox2.Visible = true;
        txtDesignation.Visible = true;
        txtFirstName.Visible = true;
        txtLastName.Visible = true;
        lblDesignation.Visible = true;
        lblFirstName.Visible = true;
        lblLastName.Visible = true;
        lblTeamID.Visible = true;
        lblShiftID.Visible = true;

        string str = (string)Session["UserID"];
        DateTime Tesco_Date = Convert.ToDateTime(Session["date"]);
        //string str = "abc";
        //DateTime Tesco_Date = DateTime.Now;
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        try
        {
            string QdeleteUser = "delete from dbo.tbl_UserDetails where UserID='" + txtUserID.Text.ToLower() + "'";
            SqlCommand cmddel = new SqlCommand(QdeleteUser, conn1);
            conn1.Open();
            cmddel.ExecuteNonQuery();
            cmddel.Dispose();
        }
        finally
        {
            conn1.Close();
        }
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
        //btnGo.Enabled = true;
        //btnUser.Enabled = false;


        //ImageButton2.Enabled = false;
        //ImageButton3.Enabled = false;

        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Updated Successfully');", true);
                Response.AppendHeader("Refresh", "1;URL=EditUserDetails.aspx");
      
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        string userid = txtUserID.Text.ToLower();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();
        string Query = @"delete from dbo.tbl_UserDetails where UserID= '" + userid + "'";
        try
        {
            SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
             Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Deleted Successfully');", true);

         }
           
        

        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }

        finally
        {
            con.Close();
        }

        Response.AppendHeader("Refresh", "1;URL=EditUserDetails.aspx");

    }
}

