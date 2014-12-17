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

public partial class AddActivity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            txtActivityName.Focus();
            SqlConnection ServerConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
            try
            {
                string QueryTeam = "select TeamName from dbo.tbl_Team order by TeamName";
                SqlDataAdapter daTeam = new SqlDataAdapter(QueryTeam, ServerConnection);
                DataTable dtTeam = new DataTable();
                daTeam.Fill(dtTeam);
                foreach (DataRow dr in dtTeam.Rows)
                {
                    DropDownList1.Items.Add(dr[0].ToString());
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
   
 
    protected void btnActivity_Click(object sender, EventArgs e)
    {
        
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string ActivityID, ActivityName, ActivityDescription;
        DateTime CreatedOn, UpdatedOn;
        ActivityID = ActivityName = ActivityDescription = String.Empty;
        //ActivityID = txtActivityID.Text;
        ActivityName = txtActivityName.Text;
        ActivityDescription = txtActivityDesc.Text;
        CreatedOn = DateTime.Now;
        UpdatedOn = DateTime.Now;

        string UserID = (string)Session["UserID"];
        string CreatedBy = UserID;
        string UpdatedBy = UserID;

        //string CreatedBy = "amy";
        //string UpdatedBy = "amy";

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        string Select_ActivityName = "";
        if (DropDownList1.SelectedValue != "All")
        {
           Select_ActivityName = "select count(*) from dbo.tbl_Activity where ActivityName  ='" + ActivityName + "'";

        }
        else
        {
           Select_ActivityName = "select count(*) from dbo.tbl_Activity where ActivityName  ='" + ActivityName + "' and TeamID in (select TeamID from dbo.tbl_Team where TeamName='" + DropDownList1.SelectedValue + "')";
        }
            SqlCommand cmd2 = new SqlCommand(Select_ActivityName, con);
        con.Open();
        SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
        rdr.Read();
        int actcount = Convert.ToInt16(rdr[0].ToString());
        rdr.Close();
        cmd2.Dispose();

        //    

        if (ActivityName == String.Empty || ActivityDescription == String.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Activity Cannot be empty');", true);

        }
        else
        {
             
            if (actcount == 0)
            {
                try
                    {
                if (DropDownList1.SelectedItem.Value == "All")
                {
                  
                   
                        string QueryTeam = "select TeamID from dbo.tbl_Team order by TeamID";
                        SqlDataAdapter daTeam = new SqlDataAdapter(QueryTeam, con);
                        DataTable dtTeam = new DataTable();
                        daTeam.Fill(dtTeam);
                        ArrayList Teamval = new ArrayList();
                        foreach (DataRow dr in dtTeam.Rows)
                        {
                            Teamval.Add(dr[0].ToString());
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.Clear();
                            cmd.CommandText = "InsertActivityDetails";
                            //cmd.Parameters.AddWithValue("@ActivityID", ActivityID);
                            cmd.Parameters.AddWithValue("@TeamID", dr[0].ToString());
                            cmd.Parameters.AddWithValue("@CommonActivityID", 1);
                            cmd.Parameters.AddWithValue("@ActivityName", ActivityName);
                            cmd.Parameters.AddWithValue("@ActivityDescription", ActivityDescription);
                            cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                            cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);

                            cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                            cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            //cmd.Dispose();
                            con.Close();

                        }

                    }

                else
                {
                    int TeamID=0;
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con;
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Clear();
                    cmd1.CommandText = "InsertActivityDetails";
                    //cmd.Parameters.AddWithValue("@ActivityID", ActivityID);
                    try
                    {
                        string QueryTeam = "select TeamID from dbo.tbl_Team where TeamName='"+DropDownList1.SelectedItem.Value+"'order by TeamID";
                        SqlDataAdapter daTeam = new SqlDataAdapter(QueryTeam, con);
                        DataTable dtTeam = new DataTable();
                        daTeam.Fill(dtTeam);
                        foreach (DataRow dr in dtTeam.Rows)
                        {
                             TeamID=Convert.ToInt16(dr[0].ToString());
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
                    cmd1.Parameters.AddWithValue("@TeamID",TeamID);
                    cmd1.Parameters.AddWithValue("@CommonActivityID", 0);
                    cmd1.Parameters.AddWithValue("@ActivityName", ActivityName);
                    cmd1.Parameters.AddWithValue("@ActivityDescription", ActivityDescription);
                    cmd1.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                    cmd1.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);

                    cmd1.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                    cmd1.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);


                    //SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
                    //returnValue.Direction = ParameterDirection.ReturnValue;

                    // cmd.Parameters.Add(returnValue);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                   // cmd1.Dispose();
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
                try
                {
                   
                }
                // int count = Int32.Parse(cmd.Parameters["@ReturnValue"].Value.ToString());

               // if (ActivityName != null)
                // {
                //     //tbl_Activity.Visible = false;
                //     //txtActivityID.Text = String.Empty;
                //     txtActivityName.Text = String.Empty;
                //     txtActivityDesc.Text = String.Empty;
                //     txtActivityName.Focus();

               ////     Response.Write("Activity details updated successfully!");
                // }
                // else
                // {
                //     Response.Write("Error updating activity!");

               // }

                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                finally
                {
                    con.Close();
                }

                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Activity Saved');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Activity Already present');", true);
            }
        }

        txtActivityName.Text = "";
        txtActivityDesc.Text = "";

    }
}

