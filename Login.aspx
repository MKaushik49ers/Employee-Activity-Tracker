<%@ Page Language="C#" MasterPageFile="~/LoginMasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
Title="Login Page" %>

<script runat="server">

    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
        <script type = "text/javascript" >
       window.history.forward(1);
       </script>
        <style type="text/css">
            .outerBorder
            {
                border: solid 1px;
                border-collapse: collapse;
            }
            .error
            {
                color: Red; 
                font-size: 11px;
            }
            .body
            {
            overflow: hidden;
            }
            .style3
            {
                border-style: solid;
                border-color: inherit;
                border-width: 1px;
                border-collapse: collapse;
                width: 247px;
            }
            .style4
            {
                color: Red;
                font-size: 11px;
                width: 160px;
            }
            .style5
            {
                width: 160px;
            }
        </style>
</asp:Content>

   
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
<div style="text-align: center; margin-top: 150px"> 
    <table  id="login" cellpadding="2" cellspacing="0" class="style3">
        <tr>
            <td class="outerBorder" colspan="2" style="background-color: #ccc">
                <h4 style="margin-top: 3px; margin-bottom: 1px">
                    Login</h4>
            </td> 
        </tr>
        <tr>
            <td class="error" style="width: 99px">
                &nbsp;
            </td>
            <td class="style4">
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Username cannot be blank."></asp:RequiredFieldValidator>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 99px">
                <asp:Label ID="lblUsername" runat="server">Username:</asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtUsername" runat="server" Width="160px"></asp:TextBox>
            </td>
        </tr>
        <tr class="error">
            <td class="error" style="width: 99px">
                &nbsp;
            </td>
            <td class="style4">
                &nbsp;<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Password cannot be blank."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 99px">
                <asp:Label ID="lblPassword" runat="server">Password:</asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp; &nbsp; &nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/button-login.png"
                    OnClick="ImageButton1_Click" />&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <span style="font-size: small; color: red">
                    <asp:Label ID="lblError" runat="server"></asp:Label></span>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:HyperLink ID="lnkChangePassword" NavigateUrl="~/ChangePassword.aspx" runat="server">Change Password</asp:HyperLink></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: right">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/UpdateMail.aspx">Update Mailing Detail</asp:HyperLink>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>

