<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="AddUserDetails.aspx.cs" Inherits="AddUserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
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
                
                font-size: 11px;
                height: 20px;
                width: 344px;
            }
            .style2
            {
                width: 410px;
            }
            .style3
            {
                height: 21px;
                width: 410px;
            }
       
            .style4
            {
                height: 20px;
                width: 410px;
                font-size: 11px;
            }
       
    </style>
      </asp:Content>
      <asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px">
     <table id="Shift" cellpadding="2" cellspacing="0"  class="outerBorder">
        <tr>
            <td class="outerBorder" align="center" colspan="3" style="background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        &nbsp;Add User Details</h4>
            </td>
        </tr>
        <tr> 
                <td style="width: 78px; height: 20px;" class="error">
                    &nbsp;
                </td>
                <td class="style4">
                    &nbsp;</td>
        </tr>
        <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblUserID" runat="server"> User ID</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtUserID" runat="server" MaxLength="4" Width="160px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUserID" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtUserID" 
                        ErrorMessage="only alpha numeric charcters allowed" 
                        ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
                </td>
        </tr> 
        <tr>
                <td style="width: 78px; height: 21px;" align="left">
                    <asp:Label ID="lblTeamID" runat="server" Width="88px">  Team Name</asp:Label>
                </td>
                <td class="style3">
                    <asp:ListBox ID="ListBox1" runat="server" Height="50px" Width="165px"></asp:ListBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="ListBox1" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                &nbsp;</td>
        </tr>
        <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblFirstName" runat="server" Width="117px"> First Name</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="20" Width="163px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtFirstName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtFirstName" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblLastName" runat="server" Width="117px"> Last Name</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="20" Width="162px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtLastName" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                        ControlToValidate="txtLastName" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
                </td>
        </tr>
            <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblDesignation" runat="server" Width="117px"> Designation</asp:Label>
                </td>
                <td class="style2">
                    <asp:TextBox ID="txtDesignation" runat="server" MaxLength="20" Width="164px" 
                        Height="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtDesignation" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="txtDesignation" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
                </td>
        </tr>
          <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblShiftId" runat="server" Width="117px"> Shift Name</asp:Label>
                </td>
                <td class="style2">
                    <asp:ListBox ID="ListBox2" runat="server" Height="47px" Width="165px"></asp:ListBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="ListBox2" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                </td>
        </tr>
        

        <tr>
             <td style="width: 78px">
             </td>
             <td class="style2">
                   <asp:ImageButton ID="btnSave" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="btnSave_Click" /></td>
         </tr>
        </table>
             
        
        </div>
        <script type = "text/javascript" >
       window.history.forward(1);
    
</script>

        </asp:Content>
    