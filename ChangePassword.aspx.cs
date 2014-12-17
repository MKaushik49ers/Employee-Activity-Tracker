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

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtUsername.Attributes.Add("onFocus", "javascript:this.select()");
        txtUsername.Focus();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        string Query = "SELECT * FROM tbl_Login WHERE UserID = '" + txtUsername.Text.Trim().ToLower() + "' AND Password = '" + txtPassword.Text + "'";
        //'Encryption.EncodeTo64(txtPassword.Text) + "'";
        SqlCommand cmd = new SqlCommand(Query, ServerConnection);

        try
        {
            ServerConnection.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.Read())
            {
                rdr.Close();
                rdr.Dispose();

                if (ServerConnection.State == ConnectionState.Closed)
                    ServerConnection.Open();

                Query = "UPDATE tbl_Login SET Password = '" + txtNewPssword.Text.Trim()+ "' WHERE UserID = '" + txtUsername.Text.Trim() + "'";
                SqlCommand cmdUpdate = new SqlCommand(Query, ServerConnection);

                cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();

                txtUsername.Text = String.Empty;
                lblError.Text = "Password changed sucessfully! You'll be redirected to the login page in 3 seconds...";
                lblError.CssClass = "success";
                Response.AppendHeader("Refresh", "3;URL=Login.aspx");
            }
            else
            {
                txtUsername.Focus();
                lblError.Text = "Invalid Username or Password!";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/Login.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        string Query = "SELECT * FROM tbl_Login WHERE UserID = '" + txtUsername.Text.Trim().ToLower() + "' AND Password = '" + txtPassword.Text + "'";
        //'Encryption.EncodeTo64(txtPassword.Text) + "'";
        SqlCommand cmd = new SqlCommand(Query, ServerConnection);

        try
        {
            ServerConnection.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.Read())
            {
                rdr.Close();
                rdr.Dispose();

                if (ServerConnection.State == ConnectionState.Closed)
                    ServerConnection.Open();

                Query = "UPDATE tbl_Login SET Password = '" + txtNewPssword.Text.Trim() + "' WHERE UserID = '" + txtUsername.Text.Trim() + "'";
                SqlCommand cmdUpdate = new SqlCommand(Query, ServerConnection);

                cmdUpdate.ExecuteNonQuery();
                cmdUpdate.Dispose();

                txtUsername.Text = String.Empty;
                lblError.Text = "Password changed sucessfully! You'll be redirected to the login page in 3 seconds...";
                lblError.CssClass = "success";
                Response.AppendHeader("Refresh", "3;URL=Login.aspx");
            }
            else
            {
                txtUsername.Focus();
                lblError.Text = "Invalid Username or Password!";
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
