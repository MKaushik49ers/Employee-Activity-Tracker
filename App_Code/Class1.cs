using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Binding
/// </summary>
public class Binding
{
    public Binding()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet DatabindingTeam(string QueryTeam)
    {
        //SqlConnection conn = new SqlConnection("Data Source=INLTE7171;Initial Catalog=Activity_TracKer;User Id=sa;Password=scott;");
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
      
        SqlCommand cmd1 = new SqlCommand(QueryTeam, conn);
        SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
        DataSet ds1 = new DataSet();
        da1.Fill(ds1);
        return ds1;

    }
    public DataSet DatabindingEmployee()
    {
        //SqlConnection conn = new SqlConnection("Data Source=INLTE7171;Initial Catalog=Activity_TracKer;User Id=sa;Password=scott;");
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChecksConnStr"].ToString());
        SqlCommand cmd2 = new SqlCommand("select ActivityName from tbl_Activity", conn);


        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

        DataSet ds2 = new DataSet();

        da2.Fill(ds2);
        return ds2;

    }


}
