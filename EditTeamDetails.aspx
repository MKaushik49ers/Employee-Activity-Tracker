<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="EditTeamDetails.aspx.cs" Inherits="EditTeamDetails" %>

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
                width: 142px;
                height: 29px;
            }
            .style2
            {
                width: 151px;
                height: 29px;
            }
            .style3
            {
                width: 40px;
                height: 29px;
            }
        
            .style4
            {
                height: 19px;
                width: 106px;
            }
            .style5
            {
                height: 29px;
                width: 106px;
            }
            .style6
            {
                width: 106px;
            }
        
        </style>
      </asp:Content>
      <asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px; width: 567px; height: 154px;">
     <table id="Team" cellpadding="2" cellspacing="0"  class="outerBorder">
     <tr>
             <td class="outerBorder" align="center" colspan="3" 
                 style="height: 27px; background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        Edit Team Details</h4>
             </td>
         </tr>
         <tr>
             <td class="style4">
             </td>
             <td style="width: 151px; height: 19px">
                    </td>
             <td style="width: 40px; height: 19px">
             </td>
         </tr>
         <tr>
            
                <td align="left" class="style5">
                    <asp:Label ID="lblSelectTeam" runat="server"> Select Team</asp:Label>
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlSelectTeam" runat="server" OnSelectedIndexChanged="ddlSelectTeam_SelectedIndexChanged" Width="168px" Height="22px">
                    </asp:DropDownList></td>
            <td class="style3">
                    <asp:ImageButton ID="btnGo" runat="server" ImageUrl="~/Include/Images/button-Go.png" OnClick="btnGo_Click" /></td>
        </tr>
        <tr>
            
                <td align="left" class="style6">
                    <asp:Label ID="lblTeamName" runat="server"> Team Name</asp:Label>
                </td>
                <td style="width: 151px">
                    <asp:TextBox ID="txtTeamName" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                </td>
            <td style="width: 40px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtTeamName" Width="245px"
                    ErrorMessage="only alpha numeric characters allowed" 
                    ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
            
                <td align="left" class="style6">
                    <asp:Label ID="lblTeamManager" runat="server" > Team Manager</asp:Label>
                </td>
                <td style="width: 151px">
                    <asp:TextBox ID="txtTeamManager" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                </td>
            <td style="width: 40px">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtTeamManager" Width="236px"
                    ErrorMessage="only alpha numeric characters allowed" 
                    ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
             <td colspan="3">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:ImageButton ID="ImageButton2" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="ImageButton2_Click" />
&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Include/Images/delete.png" 
                     onclick="ImageButton3_Click" />
             </td>
         </tr>
                    
            </table>
            </div>
</asp:Content>

