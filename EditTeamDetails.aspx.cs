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
using System.IO;

public partial class EditTeamDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = btnGo.UniqueID;
        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string Select_TeamName = "select TeamName from dbo.tbl_Team";
                SqlCommand cmd2 = new SqlCommand(Select_TeamName, con);
                SqlDataAdapter da = new SqlDataAdapter(Select_TeamName, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlSelectTeam.Items.Add(dr[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
            ImageButton2.Enabled = false;
            ImageButton3.Enabled = false;
        }

        // rfvActivityName.Visible = false;
    }
  

    protected void btnGo_Click(object sender, ImageClickEventArgs e)
    {
        SqlDataReader rdrTeamDetails;

        string Query = "select TeamName,TeamManager from dbo.tbl_Team WHERE TeamName = '" + ddlSelectTeam.SelectedItem.Text + "'";
        SqlCommand cmd = new SqlCommand(Query, new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString()));
        cmd.Connection.Open();

        rdrTeamDetails = cmd.ExecuteReader();

        PopulateDetails(rdrTeamDetails);

        cmd.Connection.Close();
        cmd.Connection.Dispose();
        ImageButton2.Enabled = true;
        ImageButton3.Enabled = true;

    }
    private void PopulateDetails(SqlDataReader rdrTeamDetails)
    {
        string TeamName, TeamManager;
        TeamName = TeamManager = String.Empty;
        if (rdrTeamDetails.Read())
        {
            TeamName = rdrTeamDetails["TeamName"].ToString();
            TeamManager = rdrTeamDetails["TeamManager"].ToString();
            txtTeamName.Text = TeamName;
            txtTeamManager.Text = TeamManager;
        }
        else
        {

        }
    }

    protected void ddlTeamName_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/EditShift.aspx");
    }


    protected void txtTeamName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ddlSelectTeam_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string TeamName, TeamManager;
        TeamName = TeamManager = String.Empty;
        string selectTeam = ddlSelectTeam.SelectedItem.Text;
        TeamName = txtTeamName.Text;
        TeamManager = txtTeamManager.Text;
        DateTime UpdatedOn;
        UpdatedOn = DateTime.Now;
        string UpdatedBy = "Amreen";

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();


        if (TeamName == String.Empty || TeamManager == String.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('TeamName/TeamManager cannot be empty');", true);
        }
        else
        {

            string Query = @"Update tbl_Team SET TeamName ='" + TeamName + "', TeamManager = '" + TeamManager
                            + " ',UpdatedOn='" + UpdatedOn + "',UpdatedBy='" + UpdatedBy + "'Where TeamName like '" + selectTeam + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }

            finally
            {
                con.Close();
            }

        }

        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Updated Successfully');", true);
        txtTeamManager.Text = String.Empty;
        txtTeamName.Text = String.Empty;
        Response.AppendHeader("Refresh", "1;URL=EditTeamDetails.aspx");

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        
        string TeamName = txtTeamName.Text;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();
        string Query = @"delete from  dbo.tbl_Team where TeamName= '" + TeamName + "'";
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

        Response.AppendHeader("Refresh", "1;URL=EditTeamDetails.aspx");

    }
}
//        txtTeamID.Focus();

//    }
    
//    protected void btnGo_Click(object sender, ImageClickEventArgs e)
//    {
//        SqlDataReader rdrTeamDetails;
//        if (!String.IsNullOrEmpty(txtTeamID.Text))
//        {
//            string Query = "select TeamID,TeamName,TeamManager from dbo.tbl_Team WHERE TeamID = '" + txtTeamID.Text + "'";
//            SqlCommand cmd = new SqlCommand(Query, new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString()));
//            cmd.Connection.Open();

//            rdrTeamDetails = cmd.ExecuteReader();

//            PopulateDetails(rdrTeamDetails);

//            cmd.Connection.Close();
//            cmd.Connection.Dispose();
//        }

//    }

//    private void PopulateDetails(SqlDataReader rdrTeamDetails)
//    {
//        string TeamName, TeamManager;
//        TeamName = TeamManager = String.Empty;
//        if (rdrTeamDetails.Read())
//        {
//            TeamName = rdrTeamDetails["TeamName"].ToString();
//            TeamManager = rdrTeamDetails["TeamManager"].ToString();
//            //tblEdit.Visible = true;
//            //tblEditTeam.Visible = true;
//            lblTeamName.Visible = true;
//            txtTeamName.Visible = true;
//            lblTeamManager.Visible = true;
//            txtTeamManager.Visible = true;
//            txtTeamName.Text = TeamName;
//            txtTeamManager.Text = TeamManager;
//        }
//        else
//        {
//            Response.Write(txtTeamID.Text + " - Team not found!");
//            //tblEdit.Visible = false;
//            //tblEditTeam.Visible = false;
//            lblTeamName.Visible = false;
//            txtTeamName.Visible = false;
//            lblTeamManager.Visible = false;
//            txtTeamManager.Visible = false;
//        }
//    }
//    protected void btnTeam_Click(object sender, EventArgs e)
//    {
//        string TeamID, TeamName, TeamManager;
//        TeamID = TeamName = TeamManager = String.Empty;
//        TeamID = txtTeamID.Text;
//        TeamName = txtTeamName.Text;
//        TeamManager = txtTeamManager.Text;
//        DateTime UpdatedOn;
//        //CreatedOn = DateTime.Now;
//        UpdatedOn = DateTime.Now;
//        string UserID = (string)Session["UserID"];
//        string CreatedBy = UserID;
//        string UpdatedBy = UserID;


//        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
//        SqlCommand cmd = new SqlCommand();
//        cmd.Connection = con;
//        cmd.CommandType = CommandType.StoredProcedure;
//        cmd.Parameters.Clear();
//        cmd.CommandText = "UpdateTeamDetails";
//        cmd.Parameters.AddWithValue("@TeamID", txtTeamID);
//        cmd.Parameters.AddWithValue("@TeamName", txtTeamName);
//        cmd.Parameters.AddWithValue("@TeamManager", txtTeamManager);
//        cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);

//        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
//        cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
//        //  SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
//        // returnValue.Direction = ParameterDirection.ReturnValue;
//        // cmd.Parameters.Add(returnValue);

//        try
//        {
//            con.Open();
//            cmd.ExecuteNonQuery();

//            //  int count = Int32.Parse(cmd.Parameters["@ReturnValue"].Value.ToString());

//            if (TeamID != null)
//            {
//                Response.Write("Team details updated successfully!");
//                //tblEdit.Visible = false;
//                //tblEditTeam.Visible = false;
//                txtTeamID.Text = String.Empty;
//                txtTeamName.Focus();
//            }
//            else
//            {
//                Response.Write("Error updating Activity!");
//                //lblError.Visible = true;
//            }
//        }
//        catch (Exception ex)
//        {
//            Debug.Write(ex.Message);
//        }
//        finally
//        {
//            con.Close();
//        }
//    }
//    protected void ddlSelectTeam_SelectedIndexChanged(object sender, EventArgs e)
//    {

//    }
//}
