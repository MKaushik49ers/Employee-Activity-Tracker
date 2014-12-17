using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Form.DefaultButton = btnGo.UniqueID;
        //  txtActivityID.Focus();

        ddlActivityName.Enabled = false;
        ImageButton2.Enabled = false;
        ImageButton3.Enabled = false;
        txtActivityName.Enabled = false;
        txtActivityDesc.Enabled = false;
        DropDownList2.Enabled = false;
        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            string Select_TeamName = "";
            Select_TeamName = "select TeamName from dbo.tbl_Team  order by TeamName";
            SqlDataAdapter da = new SqlDataAdapter(Select_TeamName, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DropDownList1.Items.Add(dr[0].ToString());
                    DropDownList2.Items.Add(dr[0].ToString());
                }

            }
            DropDownList1.Items.Insert(0,"--Select One--");
            // rfvActivityName.Visible = false;
        }
    }
    protected void btnActivity_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnGo_Click(object sender, ImageClickEventArgs e)
    {
        if (DropDownList1.SelectedValue == "--Select One--")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please select valid Team');", true);

        }
        else
        {
            DropDownList2.Enabled = true;
            //SqlDataReader rdrActivityDetails;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string Query = "select ActivityName,ActivityDescription,TeamName from dbo.tbl_Activity a,dbo.tbl_Team b WHERE ActivityName = '" + ddlActivityName.SelectedItem.Text + "' and a.TeamID=b.TeamID and b.TeamID in (select TeamID from dbo.tbl_Activity where ActivityName='" + ddlActivityName.SelectedItem.Text + "')";
                //SqlCommand cmd = new SqlCommand(Query, new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString()));
                //cmd.Connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtActivityName.Text = dr[0].ToString();
                        txtActivityDesc.Text = dr[1].ToString();
                        DropDownList1.SelectedValue = "All";

                    }
                }
                else if (dt.Rows.Count == 1)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtActivityName.Text = dr[0].ToString();
                        txtActivityDesc.Text = dr[1].ToString();
                        DropDownList1.SelectedValue = dr[2].ToString();
                        DropDownList2.SelectedValue = dr[2].ToString();

                    }
                }
                //rdrActivityDetails = cmd.ExecuteReader();

                //PopulateDetails(rdrActivityDetails);

                //cmd.Connection.Close();
                //cmd.Connection.Dispose();
                ImageButton2.Enabled = true;
                ImageButton3.Enabled = true;
                txtActivityName.Enabled = true;
                txtActivityDesc.Enabled = true;
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
   

    protected void ddlActivityName_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
       // Response.Redirect(@"~/EditActivityDetails.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (DropDownList1.SelectedValue == "--Select One--")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Please select valid Team');", true);

        }
        else
        {
            string ActivityName, ActivityDescription, ActivityID;
            ActivityID = ActivityName = ActivityDescription = String.Empty;
            //     ActivityID = txtActivityID.Text;
            string selectactivity = ddlActivityName.SelectedItem.Text;
            ActivityName = txtActivityName.Text;
            ActivityDescription = txtActivityDesc.Text;
            DateTime UpdatedOn;
            UpdatedOn = DateTime.Now;
            string UserID = (string)Session["UserID"];
            //     string CreatedBy = UserID;
            string UpdatedBy = UserID;

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

            if (ActivityName == String.Empty || ActivityDescription == String.Empty)
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('ActivityName/ActivityDescription cannot be empty');", true);
            }
            else
            {
                string Query = "";
                string Select_TeamID = "";
                Select_TeamID = "select TeamID from dbo.tbl_Team where TeamName='" + DropDownList2.SelectedValue + "' order by TeamName";
                SqlDataAdapter da = new SqlDataAdapter(Select_TeamID, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string teamID = "";
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        teamID = (dr[0].ToString());
                    }

                }

                if (DropDownList1.SelectedValue != "All")
                {
                    Query = @"Update tbl_Activity SET ActivityName ='" + ActivityName + "', ActivityDescription = '" + ActivityDescription
                                    + "',CommonActivityID='0',TeamID='" + teamID + "',UpdatedOn='" + UpdatedOn + "',UpdatedBy='" + UpdatedBy + "'Where ActivityName like '" + selectactivity + "' and TeamID='" + DropDownList1.SelectedValue + "'";
                }
                else
                {
                    Query = @"Update tbl_Activity SET ActivityName ='" + ActivityName + "', ActivityDescription = '" + ActivityDescription
                        + "',CommonActivityID='1',UpdatedOn='" + UpdatedOn + "',UpdatedBy='" + UpdatedBy + "'Where ActivityName like '" + selectactivity + "'";

                }
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
            txtActivityDesc.Text = String.Empty;
            txtActivityName.Text = String.Empty;
            //Response.Redirect(@"~/EditActivityDetails.aspx");
            Response.AppendHeader("Refresh", "1;URL=EditActivityDetails.aspx");
        }
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string ActivityName = String.Empty;
        string Query = "";
        string TeamName = "";
        string selectactivity = ddlActivityName.SelectedItem.Text;
        ActivityName = txtActivityName.Text;
        TeamName = DropDownList2.SelectedValue;
      
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        con.Open();
        if (TeamName == "All")
        {
             Query = @"delete from  dbo.tbl_Activity where ActivityName= '" + ActivityName + "' ";

        }
        else
        {
            Query = @"delete from  dbo.tbl_Activity where ActivityName= '" + ActivityName + "' and TeamID in (select TeamID from dbo.tbl_Team where TeamName='"+TeamName+"')";
        }
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

      
        txtActivityDesc.Text = String.Empty;
        txtActivityName.Text = String.Empty;

        Response.AppendHeader("Refresh", "1;URL=EditActivityDetails.aspx");

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlActivityName.Enabled = true;
         SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string Select_ActivityName="";
                if (DropDownList1.SelectedValue == "All")
                {
                   Select_ActivityName = "select ActivityName from dbo.tbl_Activity  order by ActivityName";

                }
                else
                {
                    Select_ActivityName = "select ActivityName from dbo.tbl_Activity where TeamID in (select TeamID from dbo.tbl_Team where TeamName='" + DropDownList1.SelectedValue + "') order by ActivityName";
                }
                    SqlCommand cmd2 = new SqlCommand(Select_ActivityName, con);
                SqlDataAdapter da = new SqlDataAdapter(Select_ActivityName, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ddlActivityName.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlActivityName.Items.Add(dr[0].ToString());
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
