<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="EditUserDetails.aspx.cs" Inherits="EditUserDetails" %>

<script runat="server">

 
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
        
            .style1
            {
                height: 19px;
                width: 149px;
            }
            .style2
            {
                height: 36px;
                width: 149px;
            }
            .style3
            {
                width: 149px;
            }
            .style4
            {
                height: 28px;
                width: 149px;
            }
        
        .style5
    {
        height: 19px;
        width: 102px;
    }
    .style6
    {
        height: 36px;
        width: 102px;
    }
    .style7
    {
        width: 102px;
    }
    .style8
    {
        height: 28px;
        width: 102px;
    }
        
        </style>
      </asp:Content>
      <asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px">
     <table id="User" cellpadding="2" cellspacing="0"  class="outerBorder" 
           style="width: 349px">
     <tr>
             <td class="outerBorder" align="center" colspan="3" 
                 style="height: 27px; background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px; width: 271px;">
                        Edit User Details</h4>
             </td>
         </tr>
<tr>
             <td style="width: 70px; height: 19px">
             </td>
             <td class="style1">
                    </td>
             <td class="style5">
                 &nbsp;</td>
         </tr>
         <tr>
            
                <td style="width: 70px; height: 36px;" align="left">
                    <asp:Label ID="lblUserID" runat="server" Width="76px">User TPX ID</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtUserID" runat="server"  MaxLength="20" Width="196px" 
                        ontextchanged="txtUserID_TextChanged"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtUserID" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
                </td>
            <td class="style6">
                    <asp:ImageButton ID="btnGo" runat="server" 
                        ImageUrl="~/Include/Images/button-Go.png" OnClick="btnGo_Click" 
                        Width="58px" Height="30px" /></td>
        </tr>
        <tr>
            
                <td style="width: 70px" align="left">
                    <asp:Label ID="lblTeamID" runat="server" Width="74px"> Team Name</asp:Label>
                </td>
                <td class="style3">
                    <asp:ListBox ID="ListBox1" runat="server" Height="48px" Width="196px" 
                        SelectionMode="Multiple"></asp:ListBox>
                </td>
            <td class="style7">
                &nbsp;</td>
         </tr>
         <tr>
            
                <td style="width: 70px; height: 28px;" align="left">
                    <asp:Label ID="lblFirstName" runat="server"> First Name</asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="25" Width="196px"></asp:TextBox>
                </td>
            <td class="style8">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtFirstName" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
            
                <td style="width: 70px; height: 28px;" align="left">
                    <asp:Label ID="lblLastName" runat="server"> Last Name </asp:Label>
                </td>
                <td class="style4">
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="25" Width="196px"></asp:TextBox>
                </td>
            <td class="style8">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txtLastName" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
            
                <td style="width: 70px" align="left">
                    <asp:Label ID="lblDesignation" runat="server"> Designation </asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtDesignation" runat="server" MaxLength="25" Width="197px"></asp:TextBox>
                </td>
            <td class="style7">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="txtDesignation" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
            
                <td style="width: 70px" align="left">
                    <asp:Label ID="lblShiftID" runat="server">Shift Time</asp:Label>
                </td>
                <td class="style3">
                    <asp:ListBox ID="ListBox2" runat="server" Height="56px" Width="197px"></asp:ListBox></td>
            <td class="style7">
            </td>
         </tr>
         <tr>
             <td colspan="3">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:ImageButton ID="ImageButton2" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="ImageButton2_Click" />
&nbsp;
                 <asp:ImageButton ID="ImageButton3" runat="server" 
                     ImageUrl="~/Include/Images/delete.png" onclick="ImageButton3_Click" />
             </td>
         </tr>
        
            </table>
            </div>
            <script type = "text/javascript" >
       window.history.forward(1);
       </script> 
</asp:Content>




    