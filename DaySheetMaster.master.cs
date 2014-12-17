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

public partial class DaySheetMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string str = (string)Session["UserID"];
        SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        string Query = "SELECT * FROM tbl_Login WHERE UserID = '" + str+ "'";
        SqlCommand cmd = new SqlCommand(Query, ServerConnection);
        try
        {
            ServerConnection.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.Read())
            {
                if (Convert.ToInt16(rdr["RoleID"].ToString()) == 39)
                {
                    //LinkButton4.Visible = false;
                    //lnkbtngenerate.Visible = false;
                    HyperLink linkbtn4 = (HyperLink)AdminLinks1.FindControl("lnkAdmin");
                    linkbtn4.Enabled = true;
                    //HyperLink linkbtn4 = (HyperLink)AdminLinks1.FindControl("lnkAdmin");
                }
                else
                {
                    //LinkButton4.Visible = true;
                    //lnkbtngenerate.Visible = true;
                    HyperLink linkbtn4 = (HyperLink)AdminLinks1.FindControl("lnkAdmin");
                    linkbtn4.Enabled = false;
                }
            }
            rdr.Close();
            rdr.Dispose();
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }
        finally
        {
            ServerConnection.Close();
        }
        //Response.Buffer=<SPAN style="COLOR: blue">true;<o:p></o:p>
//Response.ExpiresAbsolute=DateTime.Now.AddDays(-1d);
Response.Expires =3;
Response.CacheControl = "no-cache";
 //if(Session["SessionId"] == null)
 //   {
 //   Response.Redirect ("Login.aspx");
 //   }
}

  }

    //protected void LinkButton6_Click(object sender, EventArgs e)
    //{

       
    //}
    //protected void lnkbtngenerate_Click(object sender, EventArgs e)
    //{

    //}
    //protected void LinkButton4_Click(object sender, EventArgs e)
    //{

    //}
