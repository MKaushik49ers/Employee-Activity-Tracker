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

public partial class AddLoginDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
                       DropDownList1.Items.Add(dr[0].ToString());
                       
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
       }
   }
   protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
   {
       SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

       try
       {
           int userrole = 0;
           string QueryRole = "select RoleID from dbo.tbl_Role where RoleName='" + DropDownList1.SelectedItem.Text + "'";
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
   protected void btnSave_Click(object sender, ImageClickEventArgs e)
   {
       try
       {
           string UserID, Password;
           DateTime CreatedOn, UpdatedOn;
           UserID = Password = String.Empty;
           //ActivityID = txtActivityID.Text;

           UserID = txtUserID.Text.Trim().ToLower();
           Password = txtPassword.Text;

           int RoleID = Convert.ToInt16(Session["UserRole"]);

           CreatedOn = DateTime.Now;
           UpdatedOn = DateTime.Now;

           string createdUserID = (string)Session["UserID"];
           string CreatedBy = createdUserID;
           string UpdatedBy = createdUserID;

           //string CreatedBy = "amy";
           //string UpdatedBy = "amy";

           SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

           string Select_UserID = "select count(*) from dbo.tbl_Login where UserID  ='" + UserID + "'";
           SqlCommand cmd2 = new SqlCommand(Select_UserID, con);
           con.Open();
           SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
           rdr.Read();
           int usercount = Convert.ToInt16(rdr[0].ToString());
           rdr.Close();
           cmd2.Dispose();

           if (UserID == String.Empty || Password == String.Empty)
           {
               Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('User/Password Cannot be empty');", true);

           }

           else
           {
               if (usercount == 0)
               {

                   SqlCommand cmd = new SqlCommand();
                   cmd.Connection = con;
                   cmd.CommandType = CommandType.StoredProcedure;

                   cmd.Parameters.Clear();
                   cmd.CommandText = "InsertLoginDetails";

                   cmd.Parameters.AddWithValue("@UserID", UserID);
                   cmd.Parameters.AddWithValue("@Password", Password);
                   cmd.Parameters.AddWithValue("@RoleID", RoleID);

                   cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                   cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
                   cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                   cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

                   con.Open();
                   cmd.ExecuteNonQuery();

                   Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('User details added');", true);

                   txtUserID.Text = String.Empty; ;
               }
               else
               {
                   Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('User Already present');", true);
               }
           }
       }

       catch (Exception ex)
       {
           Debug.Write(ex.Message);
       }
       finally
       {
       }
       Response.AppendHeader("Refresh", "1;URL=AddLoginDetails.aspx");

   }
}
 
    