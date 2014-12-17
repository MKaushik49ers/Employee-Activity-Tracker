<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminLinks.ascx.cs" Inherits="AdminLinks" %>
<ul>
    <li>
            <asp:LinkButton ID="LinkButton1" runat="server" 
                PostBackUrl="~/NewDayUpdate.aspx">Acitivity Home
            </asp:LinkButton>
    </li>
</ul>
<ul>
    <li>
            <asp:HyperLink ID="lnkAddActivity" runat="server" NavigateUrl="~/AddActivity.aspx" ForeColor = "blue">Add Activity</asp:HyperLink>
    </li>
    <li>
            <asp:HyperLink ID="lnkEditActivity" runat="server" NavigateUrl="~/EditActivityDetails.aspx" ForeColor = "blue">Edit Activity</asp:HyperLink></li>
    <li>            
            <asp:HyperLink ID="lnkAddUser" runat="server" NavigateUrl="~/AddUserDetails.aspx" ForeColor = "blue">Add User Details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkEditUser" runat="server" NavigateUrl="~/EditUserDetails.aspx" ForeColor = "blue">Edit User details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkAddLogin" runat="server" NavigateUrl="~/AddLoginDetails.aspx" ForeColor = "blue">Add Login details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkEditLogin" runat="server" NavigateUrl="~/EditLoginDetails.aspx" ForeColor = "blue">Edit Login details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkAddShift" runat="server" NavigateUrl="~/AddShiftDetails.aspx" ForeColor = "blue">Add Shift details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkEditShift" runat="server" NavigateUrl="~/EditShift.aspx" ForeColor = "blue">Edit Shift details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkAddTeam" runat="server" NavigateUrl="~/AddTeam.aspx" ForeColor = "blue">Add Team details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkEditTeam" runat="server" NavigateUrl="~/EditTeamDetails.aspx" ForeColor = "blue">Edit team details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkAddRole" runat="server" NavigateUrl="~/AddRole.aspx" ForeColor = "blue">Add Role details</asp:HyperLink></li>
    <li>
            <asp:HyperLink ID="lnkEditRole" runat="server" NavigateUrl="~/EditRole.aspx" ForeColor = "blue">Edit Role details</asp:HyperLink></li>
</ul>
<p>
</p>
<p>
    &nbsp;</p>
