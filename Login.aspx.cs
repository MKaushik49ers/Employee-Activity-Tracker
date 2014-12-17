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


public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
     {
        if (Session["UserID"] != null && Session["Role"] != null)
        {
            if ((string)Session["UserID"] != String.Empty && (String)Session["Role"] != String.Empty)
                Response.Redirect(@"~/DaySheet.aspx");
        }   
        else
        {
            Session["Username"] = String.Empty;
            Session["Role"] = String.Empty;
        }

        txtUsername.Attributes.Add("onFocus", "javascript:this.select()");
        txtUsername.Focus();

    }
  
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        string Query = "SELECT * FROM tbl_Login WHERE UserID = '" + txtUsername.Text.Trim().ToLower() + "' AND Password = '" + txtPassword.Text + "'and UserID in (select UserID from  dbo.tbl_UserDetails)";
        //'Encryption.EncodeTo64(txtPassword.Text) + "'";

        
        SqlCommand cmd = new SqlCommand(Query, ServerConnection);

        try
        {
            ServerConnection.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            if (rdr.Read())
            {
                Session["UserID"] = rdr["UserID"].ToString();
                Session["RoleID"] = rdr["RoleID"].ToString();

                //if (Convert.ToInt16(rdr["RoleID"].ToString()) == 1)
                //{
                //    Response.Redirect("AdminConsole.aspx", false);
                //}
                //else
                //{
                    Response.Redirect("NewDayUpdate.aspx", false);
                //Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert(Please Fill appropriate  Details!!');", true);

              //  }
                
              
            }
            else
            {
                txtUsername.Focus();
                lblError.Text = "Invalid Username or Password!";
            }
            rdr.Close();
            rdr.Dispose();

            txtUsername.Text = "";
            txtPassword.Text = "";

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
