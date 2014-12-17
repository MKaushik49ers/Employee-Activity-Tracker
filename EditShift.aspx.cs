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
using System.Data.SqlClient;
using System.IO;

public partial class EditShift : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Form.DefaultButton = btnGo.UniqueID;

        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string Select_ShiftName = "select ShiftName from dbo.tbl_Shift";
                SqlCommand cmd2 = new SqlCommand(Select_ShiftName, con);
                SqlDataAdapter da = new SqlDataAdapter(Select_ShiftName, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                 if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlSelectShift.Items.Add(dr[0].ToString());
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
        }

        // rfvActivityName.Visible = false;
    }
    protected void btnShift_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnGo_Click(object sender, ImageClickEventArgs e)
    {
        SqlDataReader rdrShiftDetails;

        string Query = "select ShiftName,ShiftTime from dbo.tbl_Shift WHERE ShiftName = '" + ddlSelectShift.SelectedItem.Text + "'";
        SqlCommand cmd = new SqlCommand(Query, new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString()));
        cmd.Connection.Open();

        rdrShiftDetails = cmd.ExecuteReader();

        PopulateDetails(rdrShiftDetails);

        cmd.Connection.Close();
        cmd.Connection.Dispose();
        ImageButton2.Enabled = true;
        ImageButton3.Enabled = true;

    }
    private void PopulateDetails(SqlDataReader rdrShiftDetails)
    {
        string ShiftName, ShiftTime;
        ShiftName = ShiftTime = String.Empty;
        if (rdrShiftDetails.Read())
        {
            ShiftName = rdrShiftDetails["ShiftName"].ToString();
            ShiftTime = rdrShiftDetails["ShiftTime"].ToString();
            txtShiftName.Text = ShiftName;
            txtShiftTime.Text = ShiftTime;
        }
        else
        {
            
        }
    }

    protected void ddlShiftName_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(@"~/EditShift.aspx");
    }


    protected void txtShiftName_TextChanged(object sender, EventArgs e)
    {

    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string ShiftName, ShiftTime;
        ShiftName = ShiftTime = String.Empty;
        string selectShift = ddlSelectShift.SelectedItem.Text;
        ShiftName = txtShiftName.Text;
        ShiftTime = txtShiftTime.Text;
        DateTime UpdatedOn;
        UpdatedOn = DateTime.Now;
        string UpdatedBy = "Amreen";

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();


        if (ShiftName == String.Empty || ShiftTime == String.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('ShiftName/ShiftTime cannot be empty');", true);
        }
        else
        {

            string Query = @"Update tbl_Shift SET ShiftName ='" + ShiftName + "', ShiftTime = '" + ShiftTime
                            + " ',UpdatedOn='" + UpdatedOn + "',UpdatedBy='" + UpdatedBy + "'Where ShiftName like '" + selectShift + "'";

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

        }

        Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Updated Successfully');", true);
        txtShiftName.Text = "";
        txtShiftTime.Text = "";
        Response.AppendHeader("Refresh", "1;URL=EditShift.aspx");

    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string ShiftName = txtShiftName.Text;


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();
        string Query = @"delete from dbo.tbl_Shift where ShiftName = '" + ShiftName + "'";
        try
        {
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Deleted Successfully');", true);

            string Select_ShiftName = "select ShiftName from dbo.tbl_Shift";
            SqlCommand cmd2 = new SqlCommand(Select_ShiftName, con);
            SqlDataAdapter da = new SqlDataAdapter(Select_ShiftName, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddlSelectShift.Items.Add(dr[0].ToString());
                }
            }

            cmd2.Dispose();

        }

        catch (Exception ex)
        {
            Debug.Write(ex.Message);
        }

        finally
        {
            con.Close();

        }

        Response.AppendHeader("Refresh", "1;URL=EditShift.aspx");

 
    }
}





