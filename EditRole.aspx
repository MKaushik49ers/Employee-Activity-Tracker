<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="EditRole.aspx.cs" Inherits="EditRole" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
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
                width: 536px;
            }
        .error
        {
            color: Red;
            font-size: 11px;
        }
        
            .style2
            {
                height: 21px;
                width: 104px;
            }
            .style3
            {
                width: 104px;
            }
        
            .style4
            {
                height: 21px;
                width: 231px;
            }
            .style5
            {
                width: 231px;
            }
        
            .style6
            {
                height: 21px;
                width: 147px;
            }
            .style7
            {
                width: 147px;
            }
        
        </style>
      </asp:Content>
      <asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px">
     <table id="Role" cellpadding="2" cellspacing="0"  class="outerBorder">
      
         <tr>
             <td class="outerBorder" colspan="3" 
                 style="height: 27px; background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Edit Role Details</h4>
             </td>
         </tr>
         <tr>
            
                <td class="style2">
                    &nbsp;</td>
                <td align="center" class="style6">
                    &nbsp;</td>
            <td class="style4">
                    </td>
        </tr>
         <tr>
             <td class="style3">
                    <asp:Label ID="lblSelectRole" runat="server"> Select Role</asp:Label></td>
             <td class="style7">
                 <asp:DropDownList ID="ddlRoleName" runat="server" OnSelectedIndexChanged="ddlRoleName_SelectedIndexChanged" Width="168px" Height="22px" >
                    </asp:DropDownList></td>
             <td class="style5">
                    <asp:ImageButton ID="btnGo" runat="server" ImageUrl="~/Include/Images/button-Go.png" OnClick="btnGo_Click" /></td>
         </tr>
         <tr>
             <td class="style3">
                    <asp:Label ID="RoleName" runat="server"> Role Name</asp:Label></td>
             <td class="style7">
                    <asp:TextBox ID="txtRoleName" runat="server" Width="160px" Visible="true"></asp:TextBox></td>
             <td class="style5">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                     ControlToValidate="txtRoleName" Width="252px"
                     ErrorMessage="only alpha numeric characters are allowed" 
                     ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
             </td>
             
         </tr>
         <tr>
             <td class="style3">
                    <asp:Label ID="lblRoledesc" runat="server"> Role Description</asp:Label></td>
             <td class="style7">
                    <asp:TextBox ID="txtRoleDescription" runat="server" Width="160px" ></asp:TextBox></td>
             <td class="style5">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                     ControlToValidate="txtRoleDescription" Width="250px"
                     ErrorMessage="only alpha numeric characters are allowed" 
                     ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
             </td>
         </tr>
          <tr>
             <td colspan="3">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:ImageButton ID="ImageButton2" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="ImageButton2_Click" />
&nbsp;
                 <asp:ImageButton ID="ImageButton3" runat="server" 
                     ImageUrl="~/Include/Images/delete.png" onclick="ImageButton3_Click" />
             </td>
         </tr>
            
        
            </table>
            </div>
</asp:Content>
