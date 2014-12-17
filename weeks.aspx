<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="weeks.aspx.cs" Inherits="weeks" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Height="23px" Text="Wagon Generation Options"
        Width="239px"></asp:Label><br />
    <br />
    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
        <asp:ListItem>Team1</asp:ListItem>
        <asp:ListItem>Team2</asp:ListItem>
        <asp:ListItem>Team2</asp:ListItem>
    </asp:CheckBoxList><br />
    &nbsp;<br />
    <asp:Label ID="Label2" runat="server" Height="22px" Text="Select Team" Width="92px"></asp:Label><asp:DropDownList
        ID="DropDownList1" runat="server" Height="24px" Width="143px">
        <asp:ListItem>CE POS</asp:ListItem>
    </asp:DropDownList>
    &nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Height="22px" Text="Select Employee"
        Width="109px"></asp:Label><asp:DropDownList ID="DropDownList2" runat="server" Height="23px"
            Width="121px">
            <asp:ListItem>abc</asp:ListItem>
        </asp:DropDownList>
    &nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="Label4" runat="server" Height="22px" Text="Select Activity"
        Width="92px"></asp:Label><asp:DropDownList ID="DropDownList3" runat="server">
            <asp:ListItem>Training</asp:ListItem>
        </asp:DropDownList><br />
    <br />
    <asp:Label ID="Label5" runat="server" Height="21px" Text="Date" Width="30px"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Height="15px" OnTextChanged="TextBox1_TextChanged"
        Width="85px">12/12/2012</asp:TextBox>
    &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label6" runat="server" Height="22px" Text="Week"
        Width="37px"></asp:Label>
    <asp:DropDownList ID="DropDownList4" runat="server">
        <asp:ListItem>2</asp:ListItem>
    </asp:DropDownList>
    &nbsp; &nbsp; &nbsp;
    <asp:Label ID="Label7" runat="server" Height="22px" Text="Period" Width="40px"></asp:Label>
    <asp:DropDownList ID="DropDownList5" runat="server">
        <asp:ListItem Value="3"></asp:ListItem>
    </asp:DropDownList>
    &nbsp; &nbsp; &nbsp; &nbsp;<asp:Label ID="Label8" runat="server" Height="22px" Text="Year"
        Width="30px"></asp:Label>
    <asp:DropDownList ID="DropDownList6" runat="server">
        <asp:ListItem>2012</asp:ListItem>
    </asp:DropDownList>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="Button1"
        runat="server" Text="Generate Report" />
    &nbsp;&nbsp;
    <br />
    <br />
    <br />
    </asp:Content>

