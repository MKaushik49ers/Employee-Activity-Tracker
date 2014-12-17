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

public partial class EditLoginDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = btnGo.UniqueID;
        txtUserID.Focus();

        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string Select_ActivityName = "select distinct RoleName from dbo.tbl_Role";
                SqlCommand cmd2 = new SqlCommand(Select_ActivityName, con);
                SqlDataAdapter da = new SqlDataAdapter(Select_ActivityName, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlroleID.Items.Add(dr[0].ToString());
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
            btnsave.Enabled = false;
            ImageButton2.Enabled = false;
        }

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        

    }
  
    
    
    protected void btnGo_Click(object sender, ImageClickEventArgs e)
    {
        txtUserID.Enabled = false;

        SqlDataReader rdrLoginDetails;
        if (!String.IsNullOrEmpty(txtUserID.Text))
        {
            string Query = @"select UserID,Password, L.RoleID ,RoleName from  dbo.tbl_Role R , dbo.tbl_Login L 
                                Where L.RoleID = R.RoleID and UserID  ='" + txtUserID.Text + "'";
            SqlCommand cmd = new SqlCommand(Query, new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString()));
            cmd.Connection.Open();

            rdrLoginDetails = cmd.ExecuteReader();

            PopulateDetails(rdrLoginDetails);

            cmd.Connection.Close();
            cmd.Connection.Dispose();
        }
       // btnLogin.Enabled = true;
        btnsave.Enabled = true;
        ImageButton2.Enabled = true;
    }
        
    private void PopulateDetails(SqlDataReader rdrLoginDetails)
    {
        string Password1, RoleID;
        Password1 = RoleID = String.Empty;

        if (rdrLoginDetails.Read())
        {          
            Password1 = rdrLoginDetails["Password"].ToString();
            RoleID = rdrLoginDetails["RoleName"].ToString();
            txtPassword.Text = Password1;
         //   txtPassword.Attributes.Add("value", "secret");
            //txtPassword.TextMode =TextBoxMode.Password;
            ddlroleID.SelectedValue = RoleID;
        }
        else
        {
             Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('UserID not found!');", true);
             txtUserID.Enabled = true;
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string UserID = (string)Session["UserID"];
        string CreatedBy = UserID;
        string UpdatedBy = UserID;

        //string CreatedBy = "amy";
        //string UpdatedBy = "amy";


        string Password;
        int RoleId;
        DateTime UpdatedOn;
        string UserId = Password =  String.Empty;
        UserId = txtUserID.Text.ToLower();
        Password = txtPassword.Text;
        RoleId = Convert.ToInt16(Session["UserRole"]);
        UpdatedOn = DateTime.Now;

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Clear();
        cmd.CommandText = "UpdateLoginDetails";
        cmd.Parameters.AddWithValue("@UserID", UserId);
        cmd.Parameters.AddWithValue("@Password", Password);
        cmd.Parameters.AddWithValue("@RoleID", RoleId);
        cmd.Parameters.AddWithValue("UpdatedOn", UpdatedOn);
       // cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
        cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

        //  SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
        // returnValue.Direction = ParameterDirection.ReturnValue;
        // cmd.Parameters.Add(returnValue);

        try
        {
            con.Open();
            cmd.ExecuteNonQuery();



            if (UserId != null)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Login details updated successfully');", true);
                //.Visible = false;
                txtUserID.Text = String.Empty;
                txtPassword.Text = String.Empty;
                txtUserID.Focus();
                // txtRoleID.Focus();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Error updating Login details!');", true);
                //Response.Write("Error updating Login details!");
                //lblError.Visible = true;
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

        txtUserID.Enabled = true;

        //Response.Redirect("EditLoginDetails.aspx");
        Response.AppendHeader("Refresh", "1;URL=EditLoginDetails.aspx");

    }
    protected void ddlroleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

        try
        {
            int userrole = 0;
            string QueryRole = "select RoleID from dbo.tbl_Role where RoleName='" + ddlroleID.SelectedItem.Text + "'";
            SqlDataAdapter daRole = new SqlDataAdapter(QueryRole, ServerConnection);
            DataTable dt = new DataTable();
            daRole.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                userrole = Convert.ToInt16(dr[0].ToString());
            }
            Session["UserRole"] = userrole;
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

    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        string UserId = String.Empty;
        UserId = txtUserID.Text.ToLower();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();
        string Query = @"delete from  dbo.tbl_Login where UserID = '" + UserId + "'";
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
        txtUserID.Text = String.Empty;
        txtPassword.Text = String.Empty;
        txtUserID.Focus();
        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Deleted Successfully');", true);
        
        
        //Response.Redirect("EditLoginDetails.aspx");
        Response.AppendHeader("Refresh", "1;URL=EditLoginDetails.aspx");

        
    }
}