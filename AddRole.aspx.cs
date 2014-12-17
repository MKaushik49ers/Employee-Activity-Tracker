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
using System.IO;

public partial class AddRole : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        txtRoleName.Focus();
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        string UserID = (string)Session["UserID"];
        string CreatedBy = UserID;
        string UpdatedBy = UserID;



        string RoleName, RoleDescription;
        RoleName = RoleDescription = String.Empty;
        RoleName = txtRoleName.Text;
        RoleDescription = txtRoleDescription.Text;
        DateTime CreatedOn, UpdatedOn;
        CreatedOn = DateTime.Now;
        UpdatedOn = DateTime.Now;


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());


        string Select_RoleName = "select count(*) from dbo.tbl_Role where RoleName = '" + RoleName + "'";
        SqlCommand cmd2 = new SqlCommand(Select_RoleName, con);
        con.Open();
        SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
        rdr.Read();
        int actcount = Convert.ToInt16(rdr[0].ToString());
        rdr.Close();
        cmd2.Dispose();

        if (actcount == 0)
        {


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Clear();
            cmd.CommandText = "InsertRoleDetails";
            cmd.Parameters.AddWithValue("@RoleName", RoleName);

            cmd.Parameters.AddWithValue("@RoleDescription", RoleDescription);
            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
            cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
            cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

            //SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
            //returnValue.Direction = ParameterDirection.ReturnValue;

            // cmd.Parameters.Add(returnValue);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();

                // int count = Int32.Parse(cmd.Parameters["@ReturnValue"].Value.ToString());


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();

            }

            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Role Added Successfully');", true);

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Role Already present');", true);
        }

        txtRoleName.Text = "";
        txtRoleDescription.Text = "";
        Response.AppendHeader("Refresh", "1;URL=AddRole.aspx");


    }
}