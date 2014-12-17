<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="TeamReportPage.aspx.cs" Inherits="Default5" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

<script type = "text/javascript" >
       window.history.forward(1);
</script>

  <style type="text/css">
        #form1
        {
            height: 175px;
            width: 986px;
            margin-left: 0px;
        }
    </style>
    

    <div>
        <table style="width:100%;text-align:center">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" 
                        style="font-weight: 700; font-size: large" Text="Team Report"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ReportPage.aspx">Back</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
    <p>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />

</asp:Content>
