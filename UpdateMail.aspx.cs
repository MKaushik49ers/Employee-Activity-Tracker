using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.ClientServices;

using System.Xml.Linq;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
public partial class Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Visible = false;
        Label3.Visible = false;
        TextEmail.Visible = false;
        DropDownMgr.Visible = false;
        ImageButton1.Visible = false;
        if (!Page.IsPostBack)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);

            string TeamManager = "select UserID,FirstName,LastName from tbl_UserDetails where UserID in (select UserID from tbl_Login where RoleID not in ('37','39'))";
            SqlDataAdapter teammgr = new SqlDataAdapter(TeamManager,connection);
            DataTable dtteam = new DataTable();
            teammgr.Fill(dtteam);
            foreach (DataRow dr in dtteam.Rows)
            {
                DropDownMgr.Items.Add(dr[1].ToString()+" "+dr[2].ToString());
            }
        }
      
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        //TextManagerId.Enabled = true;
        TextEmail.Enabled = true;
        ImageButton1.Enabled = true;
        int UserCount=0,EmailCount=0;
        string UsID = "";
        string Usmail = "";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);
        try
        {
            string User = "select count(*) from dbo.tbl_Login a,dbo.tbl_UserDetails b where a.UserID=b.UserID and b.UserID='" + TextBox1.Text.ToLower() + "' and a.Password='"+TextPassword.Text+"'";
            SqlDataAdapter dauser = new SqlDataAdapter(User, connection);
            DataTable dtuser = new DataTable();
            dauser.Fill(dtuser);
            
            foreach (DataRow dr in dtuser.Rows)
            {
                UserCount = Convert.ToInt16(dr[0].ToString());
            }
            if (UserCount== 0)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Invalid User Detail!!');", true);

            }
            else
            {
                Label2.Visible = true;
                Label3.Visible = true;
                TextEmail.Visible = true;
                DropDownMgr.Visible = true;
                ImageButton1.Visible = true;
                Session["password"] = TextPassword.Text;
                string EmailDetail = "select count(*) from dbo.tbl_Emails where UserID='"+TextBox1.Text.ToLower()+"'";
                SqlDataAdapter daEmail = new SqlDataAdapter(EmailDetail, connection);
                DataTable dtEmail = new DataTable();
                daEmail.Fill(dtEmail);

                foreach (DataRow dr in dtEmail.Rows)
                {
                    EmailCount = Convert.ToInt16(dr[0].ToString());
                }
                if (EmailCount != 0)
                {
                    string Userid = "select UserID from dbo.tbl_Emails where UserID in (select ManagerID from dbo.tbl_Emails where UserID='" + TextBox1.Text.ToLower() + "')";
                    SqlDataAdapter daUserID = new SqlDataAdapter(Userid, connection);
                    DataTable dtUserID = new DataTable();
                    daUserID.Fill(dtUserID);

                    foreach (DataRow dr in dtUserID.Rows)
                    {
                        UsID = (dr[0].ToString());
                    }
                    string ManagerName = @"select FirstName,LastName from dbo.tbl_UserDetails where UserID='"+UsID+"'";
                    SqlDataAdapter damgr = new SqlDataAdapter(ManagerName,connection);
                    DataTable dtmgr = new DataTable();
                    damgr.Fill(dtmgr);
                    string FirstName = "";
                    string LastName = "";
                    foreach (DataRow dr in dtmgr.Rows)
                    {
                        FirstName = dr[0].ToString();
                        LastName = dr[1].ToString();
                    }
                    DropDownMgr.SelectedValue = FirstName + " " + LastName;
                    //TextManagerId.Text = UsID;
                    string Usermail = "select EmailID from dbo.tbl_Emails where UserID in (select UserID from dbo.tbl_Emails where UserID='" + TextBox1.Text + "')";
                    SqlDataAdapter daUsermail = new SqlDataAdapter(Usermail, connection);
                    DataTable dtUsermail = new DataTable();
                    daUsermail.Fill(dtUsermail);

                    foreach (DataRow dr in dtUsermail.Rows)
                    {
                        Usmail = (dr[0].ToString());
                    }
                    TextEmail.Text = Usmail;

                }
                else
                {
                   Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please Fill Your Details!!');", true);

                }
                
            }

        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
        finally
        {
            connection.Close();
        }
     
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string ID = "";
        string FirstName1 = "";
        string LastName1 = "";
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ConnectionString);
        int EmailCount = 0;
      
        if (TextEmail.Text == string.Empty || TextBox1.Text == string.Empty || TextPassword.Text==string.Empty)
        {
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('Please Fill appropriate  Details!!');", true);

        }
        else
        {
            Label2.Visible = true;
            Label3.Visible = true;
            TextEmail.Visible = true;
            DropDownMgr.Visible = true;
            ImageButton1.Visible = true;
            
            //TextManagerId.Enabled = true;
            string QueryInsert = "select count(*) from dbo.tbl_Emails where UserID='"+TextBox1.Text.ToLower()+"'";
                SqlDataAdapter daEmail = new SqlDataAdapter(QueryInsert, connection);
                DataTable dtEmail = new DataTable();
                daEmail.Fill(dtEmail);

                foreach (DataRow dr in dtEmail.Rows)
                {
                    EmailCount = Convert.ToInt16(dr[0].ToString());
                }
                if (EmailCount != 0)
                {
                   
                    DateTime CreatedOn = DateTime.Today;
                    DateTime UpdatedOn = DateTime.Today;
                    string CreatedBy = TextBox1.Text.ToLower();
                    string UpdatedBy = TextBox1.Text.ToLower();
                    string Delrecord = "delete from dbo.tbl_Emails where UserID='" + TextBox1.Text.ToLower() + "'";
                    SqlCommand del = new SqlCommand(Delrecord, connection);
                    connection.Open();
                    del.ExecuteNonQuery();
                    del.Dispose();
                    connection.Close();
                    String[] splitval = DropDownMgr.SelectedValue.Split(' ');
                    FirstName1 = splitval[0];
                    LastName1 = splitval[1];
                    string QueryID = @"select UserID from tbl_UserDetails where FirstName='" + FirstName1 + "' and LastName='" + LastName1 + "'";
                    SqlDataAdapter daID = new SqlDataAdapter(QueryID,connection);
                    DataTable dtID = new DataTable();
                    daID.Fill(dtID);
                    foreach (DataRow dr in dtID.Rows)
                    {
                        ID = dr[0].ToString();
                    }
                    string insertrecord = "insert into dbo.tbl_Emails values ('" + TextBox1.Text.ToLower() + "','" + ID + "','" + TextEmail.Text + "','" + CreatedOn + "','" + CreatedBy + "','" + UpdatedOn + "','" + UpdatedBy + "')";
                    SqlCommand dainsert = new SqlCommand(insertrecord, connection);
                    connection.Open();
                    dainsert.ExecuteNonQuery();
                    dainsert.Dispose();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('Successfully Updated!!');", true);
                    Response.AppendHeader("Refresh", "2;URL=UpdateMail.aspx");


                }
                else
                {
                    DateTime CreatedOn = DateTime.Today;
                    DateTime UpdatedOn = DateTime.Today;
                    string CreatedBy = TextBox1.Text.ToLower();
                    string UpdatedBy = TextBox1.Text.ToLower();
                    String[] splitval = DropDownMgr.SelectedValue.Split(' ');
                    FirstName1 = splitval[0];
                    LastName1 = splitval[1];
                    string QueryID = @"select UserID from tbl_UserDetails where FirstName='" + FirstName1 + "' and LastName='" + LastName1 + "'";
                    SqlDataAdapter daID = new SqlDataAdapter(QueryID, connection);
                    DataTable dtID = new DataTable();
                    daID.Fill(dtID);
                    foreach (DataRow dr in dtID.Rows)
                    {
                        ID = dr[0].ToString();
                    }
                    string insertrecord = "insert into dbo.tbl_Emails values ('" + TextBox1.Text.ToLower() + "','" +ID + "','" + TextEmail.Text + "','" + CreatedOn + "','" + CreatedBy + "','" + UpdatedOn + "','" + UpdatedBy + "')";
                    SqlCommand dainsert = new SqlCommand(insertrecord, connection);
                    connection.Open();
                    dainsert.ExecuteNonQuery();
                    dainsert.Dispose();
                    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "popup", "alert('Successfully Updated!!');", true);

                    Response.AppendHeader("Refresh", "2;URL=UpdateMail.aspx");

                }
        }
    }
}
