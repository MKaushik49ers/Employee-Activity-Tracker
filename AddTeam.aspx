<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="AddTeam.aspx.cs" Inherits="AddTeam" %>

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
       
            .style2
            {
                color: Red;
                font-size: 11px;
                height: 20px;
                width: 155px;
            }
            .style3
            {
                width: 155px;
            }
            .style4
            {
                height: 28px;
                width: 155px;
            }
            .style5
            {
                height: 39px;
                width: 155px;
            }
       
    </style>
    <script type = "text/javascript" >
       window.history.forward(1);
       </script>
      </asp:Content>
      <asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px">
     <table id="Team" cellpadding="2" cellspacing="0"  class="outerBorder">
        <tr>
            <td class="outerBorder" colspan="3" style="background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Add Team Details</h4>
            </td>
        </tr>
        <tr> 
                <td style="width: 78px; height: 20px;" class="error">
                    &nbsp;
                </td>
                <td style="width: 162px; height: 20px;" class="error">
                    &nbsp;</td>
             <td class="style2">
             </td>
        </tr>
        <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblTeamName" runat="server"> Team Name</asp:Label>
                </td>
                <td style="width: 162px">
                    <asp:TextBox ID="txtTeamName" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                </td>
                <td align="left" class="style3">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtTeamName" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z ]*$" Display="Dynamic" Width="223px"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvActivityName" runat="server" ControlToValidate="txtTeamName"
                        CssClass="error" Display="Dynamic" 
                        ErrorMessage="Team Name cannot be empty" SetFocusOnError="True" Width="152px" 
                        Height="16px"></asp:RequiredFieldValidator></td>
        </tr> 
        <tr>
            
                <td style="width: 78px; height: 28px;" align="left">
                    <asp:Label ID="lblTeamManager" runat="server" Width="117px"> Team Manager</asp:Label>
                </td>
                <td style="width: 162px; height: 28px;">
                    <asp:TextBox ID="txtTeamManager" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                </td>
                <td align="left" class="style4">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTeamManager"
                        CssClass="error" Display="Dynamic" 
                        ErrorMessage="Team Manager cannot be empty" SetFocusOnError="True" 
                        Width="169px"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtTeamManager" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z  ]*$" Display="Dynamic" Width="221px"></asp:RegularExpressionValidator>
                    </td>
        </tr>

        <tr>
             <td style="width: 78px; height: 39px;">
             </td>
             <td style="width: 162px; height: 39px;">
                   <asp:ImageButton ID="btnSave" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="btnSave_Click" /></td>
             <td class="style5">
                 </td>
         </tr>
           </table>
             
        
        </div>
        </asp:Content>
    
    <%--<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
     <div style="text-align: center; margin-top: 150px">
    <table id="tbl_Team" cellpadding="5" style="width: 500px; border-collapse: collapse">
        <tr>
            <td colspan="2" style="padding-left: 5px; font-size: 18pt; text-align: center; font-weight: bold;">
                Add Team Details</td>
        </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 140px; text-align: left">
                    Team ID</td>
                <td style="padding-left: 5px; width: 360px; text-align: left">
                    <asp:TextBox ID="txtTeamID" runat="server" MaxLength="25" Width="100px"></asp:TextBox>
                    &nbsp;
                    <br />
                    <asp:RequiredFieldValidator ID="rfvTeamID" runat="server" ControlToValidate="txtTeamID"
                        CssClass="error" Display="Dynamic" ErrorMessage="TeamID cannot be empty" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCorrectTeamID" runat="server" ControlToValidate="txtTeamID"
                        CssClass="error" Display="Dynamic" ErrorMessage="Enter correct TeamID" SetFocusOnError="True"
                        ValidationExpression="[0-9]{3}"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <table id="tblEdit" runat="server" cellpadding="5" style="width: 500px; border-collapse: collapse"
            visible="True">
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 150px; height: 50px; text-align: left">
                    Team Name</td>
                <td style="padding-left: 5px; width: 350px; height: 50px; text-align: left">
                    <asp:TextBox ID="txtTeamName" runat="server" MaxLength="100" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTeamName" runat="server" ControlToValidate="txtTeamName"
                        CssClass="error" Display="Dynamic" ErrorMessage="Team name cannot be empty"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 150px; text-align: left">
                    TeamManager</td>
                <td style="padding-left: 5px; width: 350px; text-align: left">
                    &nbsp;<asp:TextBox ID="txtTeamManager" runat="server" Width="312px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTeamManager" runat="server" ControlToValidate="txtTeamManager"
                        CssClass="error" Display="Dynamic" ErrorMessage="TeamManager cannot be empty"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 150px; text-align: left">
                </td>
                <td style="padding-left: 5px; width: 350px; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    &nbsp;<asp:ImageButton ID="ImgAdd_Click" runat="server" ImageUrl="~/Include/Images/button-save-update.png"
                        OnClick="ImgAdd_Click_Click" />
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/button-back.png" PostBackUrl="~/AdminConsole.aspx" /></td>
            </tr>
        </table>
        &nbsp;
        </div>
        </asp:Content>

--%>