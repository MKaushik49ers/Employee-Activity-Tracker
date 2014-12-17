<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="DetailedTeamReportPage.aspx.cs" Inherits="Default4" %>


<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

<script type = "text/javascript" >
       window.history.forward(1);
</script>



    <div style="text-align :center">
        <table style="width:100%;">
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Label ID="Label2" runat="server" 
                        style="font-weight: 700; font-size: large" Text="Detailed Team Report"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ReportPage.aspx">Back</asp:HyperLink>
                </td>
            </tr>
        </table>
    
    </div>
    <p>
       <asp:GridView ID="GridView1" runat="server"/>
    </p>
   

</asp:Content>