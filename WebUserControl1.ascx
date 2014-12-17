<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl1.ascx.cs" Inherits="WebUserControl1" %>

<table id="tbl2" border="1" style="font-weight: bold; vertical-align: middle; width: 1032px;
    height: 1px; text-align: center" runat ="server">
    <tr>
        <td style="width: 110px; height: 15px; text-align: center">
            <asp:TextBox ID="Txtdate2" runat="server" Height="20px" Width="69px" ></asp:TextBox></td>
        <td style="width: 142px; height: 15px; text-align: center">
            <asp:TextBox ID="Txtday" runat="server" Height="18px" Width="82px"></asp:TextBox></td>
        <td style="width: 133px; height: 15px; text-align: center">
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource1"
                DataTextField="TeamName" DataValueField="TeamName">
                <asp:ListItem>CE POS Support</asp:ListItem>
                <asp:ListItem>ESEL Support</asp:ListItem>
                <asp:ListItem>UK POS Support</asp:ListItem>
                <asp:ListItem>TB Support</asp:ListItem>
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Activity_TrackerConnectionString %>"
                SelectCommand="SELECT [TeamName] FROM [tbl_Team]"></asp:SqlDataSource>
        </td>
        <td style="width: 100px; height: 15px; text-align: center">
            <asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource2"
                DataTextField="ActivityName" DataValueField="ActivityName" Height="24px" Width="91px">
                <asp:ListItem>Training</asp:ListItem>
                <asp:ListItem>Mails</asp:ListItem>
                <asp:ListItem>Meeting</asp:ListItem>
            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Activity_TrackerConnectionString %>"
                SelectCommand="SELECT [ActivityName] FROM [tbl_Activity]"></asp:SqlDataSource>
        </td>
        <td style="width: 109px; height: 15px; text-align: center">
            <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem>15mins</asp:ListItem>
                <asp:ListItem>30mins</asp:ListItem>
                <asp:ListItem>45mins</asp:ListItem>
                <asp:ListItem>1Hr</asp:ListItem>
                <asp:ListItem>1hr15min</asp:ListItem>
            </asp:DropDownList></td>
        <td style="width: 164px; height: 15px; text-align: center">
            <asp:TextBox ID="TextBox6" runat="server" Height="22px" TextMode="MultiLine" Width="216px"></asp:TextBox></td>
        <td style="width: 83px; height: 15px; text-align: center">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/minus.jpg" Width="37px" Height="36px"></asp:ImageButton></td>
    </tr>
</table>
