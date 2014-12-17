<%@ Control Language="C#" AutoEventWireup="true" CodeFile="pagelink.ascx.cs" Inherits="pagelink" %>
<ul>
    
    <li>
            <asp:HyperLink ID="lnkActivityPage" ForeColor="blue" runat="server" NavigateUrl="~/NewDayUpdate.aspx" CssClass="">Activity Home</asp:HyperLink>
   </li>
   <li>
            <asp:HyperLink ID="lnkViewPage" ForeColor="blue" runat="server" NavigateUrl="~/MyView.aspx">View Report</asp:HyperLink>
   </li>
   <li>
            <asp:HyperLink ID="lnkAdmin" ForeColor="blue" runat="server" NavigateUrl="~/AdminConsole.aspx">Admin Page</asp:HyperLink>
   </li>
   <li>
            <asp:HyperLink ID="HyperLink1" ForeColor="blue" runat="server" NavigateUrl="~/ReportPage.aspx">Generate Report</asp:HyperLink>
   </li>
  
 </ul>
    