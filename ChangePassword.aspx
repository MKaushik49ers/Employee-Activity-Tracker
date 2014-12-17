<%@ Page Language="C#" MasterPageFile="~/LoginMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
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
        </style>
        <script type = "text/javascript" >
       window.history.forward(1);
       </script>
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
  
    <div style="text-align: center; margin-top: 100px">
    <table id="login" cellpadding="2" cellspacing="0" class="outerBorder" style="width: 463px; height: 301px;">
        <tr>
            <td class="outerBorder" colspan="2" style="background-color: #ccc">
                <h4 style="margin-top: 3px; margin-bottom: 1px">
                    Change Password</h4>
            </td>
        </tr>
        <tr>
            <td class="error" style="padding-left: 10px; width: 175px; text-align: left; height: 21px;">
                &nbsp;
            </td>
            <td class="error" style="width: 267px; height: 21px;">
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Username cannot be blank."></asp:RequiredFieldValidator>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; width: 175px; text-align: left">
                <asp:Label ID="lblUsername" runat="server">Username:</asp:Label>
            </td>
            <td style="width: 267px">
                <asp:TextBox ID="txtUsername" runat="server" Width="160px"></asp:TextBox>
            </td>
        </tr>
        <tr class="error">
            <td class="error" style="padding-left: 10px; width: 175px; text-align: left">
                &nbsp;
            </td>
            <td class="error" style="width: 267px">
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Old Password cannot be blank."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; width: 175px; text-align: left">
                <asp:Label ID="lblPassword" runat="server">Old Password:</asp:Label>
            </td>
            <td style="width: 267px">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
            </td>
        </tr>
        <tr class="error">
            <td class="error" style="padding-left: 10px; width: 175px; height: 20px; text-align: left">
                &nbsp;
            </td>
            <td class="error" style="width: 267px; height: 20px">
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPssword"
                    ErrorMessage="New Password cannot be blank."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; width: 175px; text-align: left">
                <asp:Label ID="lblNewPassword" runat="server">New Password:</asp:Label>
            </td>
            <td style="width: 267px">
                <asp:TextBox ID="txtNewPssword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
            </td>
        </tr>
        <tr class="error">
            <td class="error" style="padding-left: 10px; width: 175px; text-align: left">
                &nbsp;
            </td>
            <td class="error" style="width: 267px">
                <asp:RequiredFieldValidator ID="rfvConfirmNewPassword" runat="server" ControlToValidate="txtConfirmNewPassword"
                    ErrorMessage="New Password cannot be blank."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; width: 175px; text-align: left">
                <asp:Label ID="lblConfirmNewPassword" runat="server">Confirm New Password:</asp:Label>
            </td>
            <td style="width: 267px">
                <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
            </td>
        </tr>
        <tr class="error">
            <td class="error" style="padding-left: 10px; width: 175px; text-align: left">
                &nbsp;
            </td>
            <td class="error" style="width: 267px">
                <asp:CompareValidator ID="cvNewPassword" runat="server" ControlToCompare="txtNewPssword"
                    ControlToValidate="txtConfirmNewPassword" ErrorMessage="Passwords do not match."></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/button-save-update.png"
                    OnClick="ImageButton1_Click" /></td>
        </tr>
        <tr>
            <td colspan="2">
                <span style="font-size: small; color: red">
                    <asp:Label ID="lblError" runat="server"></asp:Label></span>
            </td>
        </tr>
       
        <tr>
            <td style="text-align: left"colspan="2">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login</asp:HyperLink>
            </td>
        </tr>
       
    </table>
     </div>
</asp:Content>


