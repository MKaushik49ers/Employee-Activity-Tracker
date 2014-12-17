<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="AddLoginDetails.aspx.cs" Inherits="AddLoginDetails" %>

<script runat="server">

 
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">

    <script type = "text/javascript" >
       window.history.forward(1);
       </script>
        <style type="text/css">
            .outerBorder
        {
            border-style: solid;
                border-color: inherit;
                border-width: 1px;
                border-collapse: collapse;
                width: 656px;
            }
        .error
        {
            color: Red;
            font-size: 11px;
        }
       
            .style2
            {
                width: 348px;
                height: 32px;
            }
       
            .style3
            {
                color: Red;
                font-size: 11px;
                height: 18px;
                width: 69px;
            }
            .style4
            {
                width: 69px;
                height: 20px;
            }
            .style5
            {
                height: 21px;
                width: 69px;
            }
            .style6
            {
                width: 69px;
                height: 32px;
            }
       
            .style7
            {
                color: Red;
                font-size: 11px;
                height: 18px;
                width: 348px;
            }
            .style8
            {
                width: 348px;
                height: 20px;
            }
            .style9
            {
                height: 21px;
                width: 348px;
            }
            .style10
            {
                color: Red;
                font-size: 11px;
                height: 18px;
                width: 137px;
            }
            .style11
            {
                width: 137px;
                height: 20px;
            }
            .style12
            {
                height: 21px;
                width: 137px;
            }
            .style13
            {
                width: 137px;
                height: 32px;
            }
            .style14
            {
                border-style: solid;
                border-color: inherit;
                border-width: 1px;
                border-collapse: collapse;
                width: 348px;
            }
            .style15
            {
                width: 348px;
            }
       
    </style>
      </asp:Content>
    <asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
        <div style="margin-left:210px; margin-top: 100px">
     <table id="Shift" cellpadding="2" cellspacing="0"  class="outerBorder">
        <tr>
            <td class="outerBorder" align="center" colspan="2" 
                style="background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        Add Login Details</h4>
            </td>
            <td class="style14" align="center" 
                style="background-color: #ccc">
                    &nbsp;</td>
        </tr>
        <tr> 
                <td class="style3">
                    &nbsp;
                </td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
        </tr>
        <tr>
            
                <td align="left" class="style4">
                    <asp:Label ID="lblUserId" runat="server"> TPX ID</asp:Label>
                </td>
                <td class="style11">
                    <asp:TextBox ID="txtUserID" runat="server" MaxLength="4" Width="162px" 
                        Height="18px"></asp:TextBox>
                </td>
                <td class="style8">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtUserID" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
                </td>
        </tr> 
        <tr>
                <td align="left" class="style5">
                    <asp:Label ID="lblPassword" runat="server" Width="88px">  Password </asp:Label>
                </td>
                <td class="style12">
                    <asp:TextBox ID="txtPassword" runat="server" Width="162px" Height="18px" 
                        TextMode="Password"></asp:TextBox>
                    <br />
                </td>
                <td class="style9">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtPassword" 
                        ErrorMessage="must be between 4 to 8 characters and  must include at least one upper case letter, one lower case letter,
                         and one numeric." 
                        ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            
                <td align="left" class="style6">
                    <asp:Label ID="lblRoleID" runat="server" Width="80px">Access</asp:Label>
                </td>
                <td class="style13">
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="164px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style2">
                    &nbsp;</td>
        </tr>

        <tr>
            <td colspan="2" style="vertical-align: middle; text-align: center">
                    <asp:ImageButton ID="btnSave" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="btnSave_Click" /></td>
            <td style="vertical-align: middle; text-align: center" class="style15">
                   &nbsp;</td>
         </tr>
           
             </table>
             
        
        </div>
        </asp:Content>
    