
<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true"  CodeFile="EditActivityDetails.aspx.cs" Inherits="_Default" %>

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
       
            .style2
            {
                height: 19px;
                width: 173px;
            }
            .style3
            {
                width: 173px;
            }
            .style4
            {
                height: 19px;
                width: 96px;
            }
            .style5
            {
                width: 96px;
            }
            .style6
            {
                height: 19px;
                width: 133px;
            }
            .style7
            {
                width: 133px;
            }
       
    </style>
    <script type = "text/javascript" >
       window.history.forward(1);
       </script>
      </asp:Content>
      <asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px; width: 607px;">
     <table id="Activity" cellpadding="2" cellspacing="0"  class="outerBorder" 
                  style="width: 602px; height: 163px">
      
         <tr>
             <td class="outerBorder" align="center" colspan="3" style="height: 27px; background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        Edit Activity Details</h4>
             </td>
         </tr>
         <tr>
             <td class="style4">
             </td>
             <td class="style6">
                    </td>
             <td class="style2">
             </td>
         </tr>
        <tr>
            
                <td class="style5">
                    Select
                    Team</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList1" runat="server" 
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="168px" 
                        Height="28px" AutoPostBack="True">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
            <td class="style3">
                    <asp:ImageButton ID="btnGo" runat="server" ImageUrl="~/Include/Images/button-Go.png" OnClick="btnGo_Click" /></td>
        </tr>
        <tr>
            
                <td class="style5">
                    <asp:Label ID="lblActivityId" runat="server" Height="22px" Width="91px">Select Activity</asp:Label></td>
                <td class="style7">
                    <asp:DropDownList ID="ddlActivityName" runat="server" 
                        OnSelectedIndexChanged="ddlActivityName_SelectedIndexChanged" Width="166px" 
                        Height="28px" >
                    </asp:DropDownList></td>
            <td class="style3">
                    &nbsp;</td>
        </tr>
        <tr>
            
                <td class="style5">
                    <asp:Label ID="lblActivityName" runat="server" Height="23px" Width="90px">Activity Name</asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtActivityName" runat="server" Width="164px"></asp:TextBox>
                </td>
            <td class="style3">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtActivityName" Width="229px"
                    ErrorMessage="only alpha numeric characters allowed" 
                    ValidationExpression="^[0-9A-Za-z   -]*$"></asp:RegularExpressionValidator>
            </td>
         </tr>
            <tr>
                <td class="style5">
                    <asp:Label ID="lblActivityDesc" runat="server" Width="117px">Activity Description</asp:Label>
                </td>
                <td class="style7">
                    <asp:TextBox ID="txtActivityDesc" runat="server" Width="164px"></asp:TextBox>
                </td>
                <td class="style3">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="txtActivityDesc" Width="222px"
                    ErrorMessage="only alpha numeric characters allowed" 
                    ValidationExpression="^[0-9A-Za-z  ]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style5">
                    Team Name</td>
                <td class="style7">
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="166px">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
            </tr>
         <tr>
             <td colspan="3">
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:ImageButton 
                     ID="ImageButton2" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="ImageButton2_Click" />
&nbsp;
                 <asp:ImageButton ID="ImageButton3" runat="server" 
                     ImageUrl="~/Include/Images/delete.png" onclick="ImageButton3_Click" />
                 </td>
         </tr>
        
            </table>
            </div>
</asp:Content>
 

