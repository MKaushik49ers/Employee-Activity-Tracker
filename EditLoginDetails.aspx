<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master"  AutoEventWireup="true" CodeFile="EditLoginDetails.aspx.cs" Inherits="EditLoginDetails" %>

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
                
                font-size: 11px;
                height: 20px;
                width: 344px;
            }
            .style2
            {
              width: 83px;
          }
            .style3
            {
                height: 21px;
                width: 403px;
            }
       
          .style4
          {
              height: 20px;
              width: 403px;
              font-size: 11px;
          }
          .style5
          {
              height: 20px;
              width: 181px;
              font-size: 11px;
          }
          .style6
          {
              height: 20px;
              width: 83px;
              font-size: 11px;
          }
          .style7
          {
              width: 181px;
          }
       
    </style>
      </asp:Content>
      <asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px">
     <table id="Login" cellpadding="2" cellspacing="0"  class="outerBorder">
      
         <tr>
             <td class="outerBorder" align="center" colspan="3" 
                 style="height: 27px; background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        Edit Login Details</h4>
             </td>
         </tr>
         <tr>
             <td class="style6">
             </td>
             <td class="style5">
                    </td>
             <td class="style3">
             </td>
         </tr>
        <tr>
            
                <td class="style2">
                    <asp:Label ID="lblUserId" runat="server"> User ID</asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtUserID" runat="server" MaxLength="4" Width="160px"></asp:TextBox>
                &nbsp;</td>
            <td class="style4">
                    <asp:ImageButton ID="btnGo" runat="server" ImageUrl="~/Include/Images/button-Go.png" OnClick="btnGo_Click" />
                </td>
        </tr>
        <tr>
            
                <td class="style2">
                    &nbsp;</td>
                <td class="style7">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="txtUserID" 
                        ErrorMessage="Only alpha numeric characters are allowed" 
                        ValidationExpression="^[0-9A-Za-z]*$"></asp:RegularExpressionValidator>
                </td>
            <td class="style4">
                    &nbsp;</td>
        </tr>
        <tr>
            
                <td class="style2">
                    <asp:Label ID="lblPassword" runat="server"> Password</asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtPassword" runat="server" Width="160px"></asp:TextBox>
                </td>
            <td class="style4">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtPassword" Width="387px"
                    ErrorMessage="at least 4 characters, not more than 8 characters, and must include at least one upper case letter, one lower case letter, and one numeric." 
                    ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$"></asp:RegularExpressionValidator>
            </td>
         </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="lblRoleId" runat="server" Width="85px">Role ID</asp:Label>
                </td>
                <td class="style7">
                    <asp:DropDownList ID="ddlroleID" runat="server" 
                        onselectedindexchanged="ddlroleID_SelectedIndexChanged" Width="166px" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style4">
                </td>
            </tr>
         <tr>
             <td class="style8" colspan="3">
             &nbsp;<asp:ImageButton ID="btnsave" runat="server" Enabled="False" 
                     ImageUrl="~/Include/Images/Save.png" onclick="ImageButton2_Click" />
                     &nbsp;
             &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" 
                     ImageUrl="~/Include/Images/delete.png" onclick="ImageButton2_Click1" />
             </td>
         </tr>
                    
            </table>
            </div>
</asp:Content>
 



  
        
