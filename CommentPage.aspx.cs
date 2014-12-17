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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public partial class CommentPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (Txtreason.Text == String.Empty || Txtreason.Text == " ")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please enter reason and then Submit');", true);
        }
        else
        {


            SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            string UserID = (string)Session["UserID"];
            DateTime Date = Convert.ToDateTime(Session["date"]);
            string Comments = Txtreason.Text;
            decimal ReportedHours = Convert.ToDecimal(Session["reportedhours"]);
            DateTime CreatedOn = DateTime.Today;
            DateTime UpdatedOn = DateTime.Today;
            string CreatedBy = UserID;
            string UpdatedBy = UserID;


            try
            {
                string Query = "";
                int count1 = 0;
                string dbcount = @"select count(*) from dbo.tbl_Comment where UserID='"+UserID+"' and Date='"+Date+"'";
                SqlDataAdapter dacount = new SqlDataAdapter(dbcount,ServerConnection);
                DataTable dtcount = new DataTable();
                dacount.Fill(dtcount);
                foreach (DataRow dr in dtcount.Rows)
                {
                    count1 = Convert.ToInt16(dr[0].ToString());
                }
                if (count1 != 0)
                {
                    Query = @"Update dbo.tbl_Comment set UserID='" + UserID + "',Date='" + Date + "',Comments='" + Comments + "',ReportedHours='" + ReportedHours + "',CreatedOn='" + CreatedOn + "',CreatedBy='" + CreatedBy + "',UpdatedOn='" + UpdatedOn + "',UpdatedBy='" + UpdatedBy + "' where UserID='"+UserID+"' and Date='"+Date+"'";
                }
                else
                {
                 Query = @"INSERT INTO tbl_Comment VALUES('" + UserID + "','" + Date + "','" + Comments + "','" + ReportedHours
                                                                     + "','" + CreatedOn + "','" + CreatedBy + "','" + UpdatedOn + "','" + UpdatedBy + "')";

                }
                ServerConnection.Open();
                SqlCommand cmd = new SqlCommand(Query, ServerConnection);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Saved Successfully');", true);
                //string msg = "This is variable message"; Page.ClientScript.RegisterStartupScript(typeof(Page), "wel1", " alert('" + msg + "');");
                
            }

            catch (Exception ex)
            {

                Debug.Write(ex.Message);
            }
            finally
            {
                ServerConnection.Close();
                lblmsg.Visible = true;
                Response.AppendHeader("Refresh", "3;URL=NewDayUpdate.aspx");
                //;
            }
        }

        //Response.Redirect("NewDayUpdate.aspx");
    }
}
