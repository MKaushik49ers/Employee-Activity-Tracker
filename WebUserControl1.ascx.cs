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

public partial class WebUserControl1 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //this.Txtdate2.Text = (string)Session["date"];
        //this.Txtday.Text = (string)Session["day"];



        //DateTime Tesco_Date1 = Convert.ToDateTime(Txtdate2.Text);
        //Session["date1"] = Tesco_Date1;
        //Session["day1"] = Txtday.Text;
        //Session["Team1"] = DropDownList2.SelectedItem.Text;
        //Session["Activity1"] = DropDownList3.SelectedItem.Text;
        //Session["Duration1"] = DropDownList4.SelectedItem.Text;
        //Session["Comments1"] = TextBox6.Text;
    }

    public string DropDownSelectedValue
    {
        get
        {
            return DropDownList3.SelectedValue;
        }
    }
}
