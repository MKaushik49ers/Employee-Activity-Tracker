<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="AddRole.aspx.cs" Inherits="AddRole" %>


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
            .style4
           {
               color: Red;
               font-size: 11px;
               height: 20px;
               width: 346px;
           }
           .style5
           {
               height: 28px;
               width: 346px;
           }
           .style6
           {
               height: 21px;
               width: 346px;
           }
           .style7
           {
               width: 346px;
           }
       
    </style>
      </asp:Content>
      <asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px; width: 514px;">
           <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
   <table id="Role" cellpadding="2" cellspacing="0"  class="outerBorder" 
                  style="width: 680px; height: 149px;">
        <tr>
            <td class="outerBorder" colspan="3" 
                style="background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Add Role Details</h4>
            </td>
        </tr>
        <tr>
                <td style="width: 78px; height: 20px;" class="error">
                    &nbsp;
                </td>
                <td style="width: 162px; height: 20px;" class="error">
                    &nbsp;</td>
             <td class="style4">
             </td>
        </tr>
        <tr>
            
                <td style="width: 78px; height: 28px;" align="left">
                    <asp:Label ID="lblRoleName" runat="server"> Role Name</asp:Label>
                </td>
                <td style="width: 162px; height: 28px;">
                    <asp:TextBox ID="txtRoleName" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                </td>
                <td align="left" class="style5">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtRoleName" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z ]*$" Display="Dynamic" Width="227px"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvRoleName" runat="server" ControlToValidate="txtRoleName"
                        CssClass="error" Display="Dynamic" ErrorMessage="Role Name cannot be empty" SetFocusOnError="True" Width="189px"></asp:RequiredFieldValidator></td>
         </tr>
         <tr>
                <td style="width: 78px; height: 21px;" align="left">
                    <asp:Label ID="lblRoleDescription" runat="server" Width="113px">  Role Description</asp:Label>
                </td>
                <td style="width: 162px; height: 21px;">
                    <asp:TextBox ID="txtRoleDescription" runat="server" Width="160px" MaxLength="25"></asp:TextBox>
                </td>
                <td align="left" class="style6">
                   <asp:RequiredFieldValidator ID="rfvRoleDescription" runat="server" ControlToValidate="txtRoleDescription"
                        CssClass="error" Display="Dynamic" ErrorMessage="Role Description cannot be empty"
                        SetFocusOnError="True" Width="166px"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtRoleDescription" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z ]*$" Display="Dynamic" Width ="226px"></asp:RegularExpressionValidator>
                    </td>
         </tr>
         <tr>
             <td style="width: 78px">
             </td>
             <td style="width: 162px">
                   <asp:ImageButton ID="btnSave" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="btnSave_Click" /></td>
             <td class="style7">
             </td>
         </tr>
                      
        </table>
        </div>
        </asp:Content>
  <%--<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderHead" runat="Server">
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
      </asp:Content>

    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" <div style="text-align: center; margin-top: 150px">
     <table id="Role" cellpadding="2" cellspacing="0"  class="outerBorder">
        <tr>
            <td class="outerBorder" colspan="4" style="background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                       Add Role Details</h4>
            </td>
        </tr>
        
         <tr>
             <td class="error" style="width: 153px; height: 20px;">
             </td>
                <td style="width: 78px; height: 20px;" class="error">
                  
                </td>
                <td style="width: 162px; height: 20px;" class="error">
                  </td>
             <td class="error" style="width: 162px; height: 20px">
             </td>
            </tr>
            <tr>
                <td style="width: 153px">
                </td>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblRoleId" runat="server" Text=" Role Id"> </asp:Label>
                </td>
                <td style="width: 162px">
                    <asp:TextBox ID="txtRoleID" runat="server" MaxLength="4" Width="100px"></asp:TextBox>
                </td>
                <td align="left" style="width: 162px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        CssClass="error" Display="Dynamic" ErrorMessage="RoleID cannot be empty" ControlToValidate="txtRoleID"></asp:RequiredFieldValidator></td>
           </tr>
            <tr>
                <td style="width: 153px; height: 21px;">
                </td>
                <td style="width: 78px; height: 21px;" align="left">
                    <asp:Label ID="lblRoleDes" runat="server" Text="Role Description"> </asp:Label>
                </td>
                <td style="width: 162px; height: 21px;">
                   <asp:TextBox ID="TextBox1" runat="server" Width="184px"></asp:TextBox>
                </td>
                <td align="left" style="width: 162px; height: 21px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRoleDescription"
                        CssClass="error" Display="Dynamic" ErrorMessage="Role description cannot be empty"
                        SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
         <tr>
             <td style="width: 153px">
             </td>
             <td style="width: 78px">
             </td>
             <td style="width: 162px">
                   <asp:Button ID="btnAdd" runat="server"  CssClass="buttonLogin" Width="133px" OnClick="btnShift_Click"  /></td>
             <td style="width: 162px">
             </td>
         </tr>
            <tr>
                <td colspan="1" style="width: 153px">
                </td>
                <td colspan="2">
                   </td>
                <td colspan="1">
                </td>
            </tr>
            
        </table>            
        
        </div>
    
    
   
            
            <tr>
                <td colspan="2" style="text-align: center">
                    &nbsp;<asp:ImageButton ID="ImgAdd_Click" runat="server" ImageUrl="~/Include/Images/button-save-update.png"
                        OnClick="ImgAdd_Click_Click" />
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/button-back.png" PostBackUrl="~/AdminConsole.aspx" /></td>
            </tr>
        
        </asp:Content>
--%>