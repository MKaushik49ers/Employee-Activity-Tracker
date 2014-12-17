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
using System.IO;
using System.Data.SqlClient;

public partial class EditRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = btnGo.UniqueID;
        //txtRoleID.Focus();

        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string Select_RoleName = "select RoleName from dbo.tbl_Role";
                SqlCommand cmd2 = new SqlCommand(Select_RoleName, con);
                SqlDataAdapter da = new SqlDataAdapter(Select_RoleName, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlRoleName.Items.Add(dr[0].ToString());
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
            txtRoleName.Enabled = false;
            txtRoleDescription.Enabled = false;
        }

        // rfvActivityName.Visible = false;
    }
    protected void btnGo_Click(object sender, ImageClickEventArgs e)
    {
        SqlDataReader rdrRoleDetails;

        string Query = "select RoleName,RoleDescription from dbo.tbl_Role WHERE RoleName = '" + ddlRoleName.SelectedItem.Text + "'";
        SqlCommand cmd = new SqlCommand(Query, new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString()));
        cmd.Connection.Open();

        rdrRoleDetails = cmd.ExecuteReader();

        PopulateDetails(rdrRoleDetails);

        cmd.Connection.Close();
        cmd.Connection.Dispose();
        ImageButton2.Enabled = true;
        ImageButton3.Enabled = true;
        txtRoleName.Enabled = true;
        txtRoleDescription.Enabled = true;

    }
    private void PopulateDetails(SqlDataReader rdrRoleDetails)
    {
        string RoleName, RoleDescription;
        RoleName = RoleDescription = String.Empty;
        if (rdrRoleDetails.Read())
        {
            RoleName = rdrRoleDetails["RoleName"].ToString();
            RoleDescription = rdrRoleDetails["RoleDescription"].ToString();
            //tblEdit.Visible = true;
            //lblActivityName.Visible = true;
            //txtActivityName.Visible = true;
            //lblActivityDesc.Visible = true;
            //txtActivityDesc.Visible = true;
            //rfvActivityName.Visible = true;
            //rfvActivityDesc.Visible = true;
            txtRoleName.Text = RoleName;
            txtRoleDescription.Text = RoleDescription;
        }
        else
        {
            // Response.Write(txtActivityID.Text + " - Activity not found!");
            //lblActivityName.Visible = true;
            //txtActivityName.Visible = true;
            //lblActivityDesc.Visible = true;
            //txtActivityDesc.Visible = true;
            //rfvActivityName.Visible = true;
            //rfvActivityDesc.Visible = false;
            //tblEdit.Visible = false;
        }
    }

    protected void ddlActivityName_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }

    protected void ddlRoleName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string RoleName, RoleDescription;
        RoleName = RoleDescription = String.Empty;
        //     ActivityID = txtActivityID.Text;
        string selectRole = ddlRoleName.SelectedItem.Text;
        RoleName = txtRoleName.Text;
        RoleDescription = txtRoleDescription.Text;
        DateTime UpdatedOn;
        UpdatedOn = DateTime.Now;
        string UserID = (string)Session["UserID"];
        //   string CreatedBy = UserID;
        string UpdatedBy = UserID;
        //    string UpdatedBy = "Amreen";

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();
        //SqlCommand cmd = new SqlCommand();
        //  cmd.Connection = con;
        //  cmd.CommandType = CommandType.StoredProcedure;
        //  cmd.Parameters.Clear();
        //  cmd.CommandText = "UpdateActivityDetails";
        ////  cmd.Parameters.AddWithValue("@ActivityID", ActivityID);
        //  cmd.Parameters.AddWithValue("@ActivityName", ActivityName);
        //  cmd.Parameters.AddWithValue("@ActivityDescription", ActivityDescription);
        //  cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
        //  cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
        //  SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
        // returnValue.Direction = ParameterDirection.ReturnValue;
        // cmd.Parameters.Add(returnValue);

        if (RoleName == String.Empty || RoleDescription == String.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('RoleName/RoleDescription cannot be empty');", true);
        }
        else
        {

            string Query = @"Update tbl_Role SET RoleName ='" + RoleName + "', RoleDescription = '" + RoleDescription
                            + " ',UpdatedOn='" + UpdatedOn + "',UpdatedBy='" + UpdatedBy + "'Where RoleName like '" + selectRole + "'";

            try
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();


                //  int count = Int32.Parse(cmd.Parameters["@ReturnValue"].Value.ToString());

                //if (ActivityID != null)
                //{
                //    Response.Write("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspActivity details updated successfully!");
                //    //tblEdit.Visible = false;
                //    txtActivityID.Text = String.Empty;
                //    txtActivityName.Focus();
                //}
                //else
                //{
                //    Response.Write("&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspError updating Activity!");
                //    //lblError.Visible = true;
                //}
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
        txtRoleName.Text = String.Empty;
        txtRoleDescription.Text = String.Empty;
        Response.AppendHeader("Refresh", "1;URL=EditRole.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string RoleName = txtRoleName.Text;


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();
        string Query = @"delete from dbo.tbl_Role where RoleName = '" + RoleName + "'";
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

        Response.AppendHeader("Refresh", "1;URL=EditRole.aspx");

 
    }
}

