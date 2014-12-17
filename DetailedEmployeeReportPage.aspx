<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="DetailedEmployeeReportPage.aspx.cs" Inherits="Default3" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

    <script type = "text/javascript" >
       window.history.forward(1);
       </script>
    <title>Untitled Page</title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-weight: bold;
            font-size: large;
            
        }
        </style>
    
    <div style="height:  34px; width: 1069px ; text-align : center"> 
        <table style="width:100%;">
            <tr>
            <td>
                    <asp:Label ID="Label2" runat="server" 
                        style="font-weight: 700; font-size: large" Text="Detailed Employee Report"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ReportPage.aspx">Back</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
    <p>
        <asp:GridView ID="GridView1" runat="server" Height="222px" 
            onselectedindexchanged="GridView1_SelectedIndexChanged" Width="466px" 
            Font-Names="Verdana">
        </asp:GridView>
    </p>
   
</asp:Content>
