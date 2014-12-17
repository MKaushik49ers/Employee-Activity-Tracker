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

public partial class AddTeam : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtTeamName.Focus();
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        string TeamID, TeamName, TeamManager;
        DateTime CreatedOn, UpdatedOn;
        TeamID = TeamName = TeamManager = String.Empty;
        //ActivityID = txtActivityID.Text;
        TeamName = txtTeamName.Text;
        TeamManager = txtTeamManager.Text;
        CreatedOn = DateTime.Now;
        UpdatedOn = DateTime.Now;


        string CreatedBy = "amy";
        string UpdatedBy = "amy";

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

        string Select_TeamName = "select count(*) from dbo.tbl_Team where TeamName  ='" + TeamName + "'";
        SqlCommand cmd2 = new SqlCommand(Select_TeamName, con);
        con.Open();
        SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
        rdr.Read();
        int teamcount = Convert.ToInt16(rdr[0].ToString());
        rdr.Close();
        cmd2.Dispose();

        //    

        if (TeamName == String.Empty || TeamManager == String.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Team Cannot be empty');", true);

        }
        else
        {
            if (teamcount == 0)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();
                cmd.CommandText = "InsertTeamDetails";
                //cmd.Parameters.AddWithValue("@ActivityID", ActivityID);
                cmd.Parameters.AddWithValue("@TeamName", TeamName);
                cmd.Parameters.AddWithValue("@TeamManager", TeamManager);
                cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);

                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }

                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Team Saved');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Team Already present');", true);
            }
            Response.AppendHeader("Refresh", "1;URL=AddTeam.aspx");

        }

    }
}
//    }
    
//    protected void ImgAdd_Click_Click(object sender, ImageClickEventArgs e)
//    {
      
//    }
//    protected void btnLogin_Click(object sender, EventArgs e)
//    {
//        string TeamName, TeamManager;
//        TeamName = TeamManager = String.Empty;
//        //TeamID = txtTeamID.Text;
//        TeamName = txtTeamName.Text;
//        TeamManager = txtTeamManager.Text;
//        DateTime CreatedOn, UpdatedOn;
//        CreatedOn = DateTime.Now;
//        UpdatedOn = DateTime.Now;

//        string UserID = (string)Session["UserID"];
//        string CreatedBy = UserID;
//        string UpdatedBy = UserID;


//        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
//        SqlCommand cmd = new SqlCommand();
//        cmd.Connection = con;
//        cmd.CommandType = CommandType.StoredProcedure;

//        cmd.Parameters.Clear();
//        cmd.CommandText = "InsertTeamDetails";
//        //cmd.Parameters.AddWithValue("@TeamID", TeamID);
//        cmd.Parameters.AddWithValue("@TeamName", TeamName);
//        cmd.Parameters.AddWithValue("@TeamManager", TeamManager);
//        cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
//        cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
//        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
//        cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

//        //SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
//        //returnValue.Direction = ParameterDirection.ReturnValue;

//        // cmd.Parameters.Add(returnValue);

//        try
//        {
//            con.Open();
//            cmd.ExecuteNonQuery();

//            // int count = Int32.Parse(cmd.Parameters["@ReturnValue"].Value.ToString());

//            if (TeamName != null)
//            {
//                Response.Write("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspTeam details updated successfully!");
//                //tbl_Activity.Visible = false;
//                //txtActivityID.Text = String.Empty;
//                //txtActivityID.Focus();
//                txtTeamName.Text = String.Empty;
//                txtTeamName.Focus();
//            }
//            else
//            {
//                Response.Write("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspError updating Team!");

//            }
//        }
//        catch (Exception ex)
//        {
//            Response.Write(ex.Message);
//        }
//        finally
//        {
//            con.Close();
//        }

//    }
//}
