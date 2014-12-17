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

public partial class AddShiftDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtShiftName.Focus();
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        string ShiftID, ShiftName, ShiftTime;
        DateTime CreatedOn, UpdatedOn;
        ShiftID = ShiftName = ShiftTime = String.Empty;
        //ActivityID = txtActivityID.Text;
        ShiftName = txtShiftName.Text;
        ShiftTime = txtShiftTime.Text;
        CreatedOn = DateTime.Now;
        UpdatedOn = DateTime.Now;

        //string UserID = (string)Session["UserID"];
        //string CreatedBy = UserID;
        //string UpdatedBy = UserID;

        string CreatedBy = "amy";
        string UpdatedBy = "amy";

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());

        string Select_ShiftName = "select count(*) from dbo.tbl_Shift where ShiftTime  ='" + ShiftTime + "'";
        SqlCommand cmd2 = new SqlCommand(Select_ShiftName, con);
        con.Open();
        SqlDataReader rdr = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
        rdr.Read();
        int rolecount = Convert.ToInt16(rdr[0].ToString());
        rdr.Close();
        cmd2.Dispose();

        //    

        if (ShiftName == String.Empty || ShiftTime == String.Empty)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Shift Cannot be empty');", true);

        }
        else
        {
            if (rolecount == 0)
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Clear();
                cmd.CommandText = "InsertShiftDetails";
                //cmd.Parameters.AddWithValue("@ActivityID", ActivityID);
                cmd.Parameters.AddWithValue("@ShiftName", ShiftName);
                cmd.Parameters.AddWithValue("@ShiftTime", ShiftTime);
                cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);
                cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);

                cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
                cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);


                //SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
                //returnValue.Direction = ParameterDirection.ReturnValue;

                // cmd.Parameters.Add(returnValue);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
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

                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Shift Saved');", true);

                Response.AppendHeader("Refresh", "1;URL=AddShiftDetails.aspx");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "popup", "alert('Shift Already present');", true);
            }
        }

    }
}
//    }
    
//    protected void btnShift_Click(object sender, EventArgs e)
//    {
//        string ShiftName, ShiftTime;
//        DateTime CreatedOn, UpdatedOn;
//        ShiftName = ShiftTime = String.Empty;
//        ShiftName = txtShiftName.Text;
//        ShiftTime = txtShiftTime.Text;
//        CreatedOn = DateTime.Now;
//        UpdatedOn = DateTime.Now;

//        string UserID = (string)Session["UserID"];
//        string CreatedBy = UserID;
//        string UpdatedBy = UserID;

//        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
//        SqlCommand cmd = new SqlCommand();
//        cmd.Connection = con;
//        cmd.CommandType = CommandType.StoredProcedure;

//        cmd.Parameters.Clear();
//        cmd.CommandText = "InsertShiftDetails";
//        cmd.Parameters.AddWithValue("@ShiftName", ShiftName);
//        cmd.Parameters.AddWithValue("@ShiftTime", ShiftTime);
//        cmd.Parameters.AddWithValue("@UpdatedOn", UpdatedOn);
//        cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn);

//        cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy);
//        cmd.Parameters.AddWithValue("@UpdatedBy", UpdatedBy);

//        //SqlParameter returnValue = new SqlParameter("@ReturnValue", DbType.Int32);
//        //returnValue.Direction = ParameterDirection.ReturnValue;

//        // cmd.Parameters.Add(returnValue);

//        try
//        {
//            con.Open();
//            cmd.ExecuteNonQuery();

//            // int count = Int32.Parse(cmd.Parameters["@ReturnValue"].Value.ToString());

//            if (ShiftName != null)
//            {
//                Response.Write("Shift details updated successfully!");
//                //tbl_Activity.Visible = false;
//                txtShiftName.Text = String.Empty;
//                txtShiftName.Focus();

//            }
//            else
//            {
//                Response.Write("Error updating Shift!");

//            }
//        }
//        catch (Exception ex)
//        {
//            Response.Write(ex.Message);
//        }
//        finally
//        {
//            con.Close();

//        }

//    }
//}
