<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMasterPage.master" AutoEventWireup="true" CodeFile="UpdateMail.aspx.cs" Inherits="Default7" %>



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
            .body
            {
            overflow: hidden;
            }
            .style3
            {
                border-style: solid;
                border-color: inherit;
                border-width: 1px;
                border-collapse: collapse;
                width: 336px;
              height: 207px;
          }
            .style4
            {
                color: Red;
                font-size: 11px;
                width: 160px;
            }
            .style6
            {
                color: Red;
                font-size: 11px;
            }
            .style12
          {
              border: solid 1px;
              border-collapse: collapse;
          }
          .style13
          {
              height: 32px;
          }
          .style14
          {
              color: Red;
              font-size: 11px;
              width: 160px;
              height: 32px;
          }
          .style15
          {
              color: Red;
              font-size: 11px;
              height: 32px;
          }
        </style>
</asp:Content>

   
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >
    <div style="text-align: center; margin-top: 150px"> 
    <table  id="login" cellpadding="2" cellspacing="0" class="style3">
        <tr>
            <td class="outerBorder" colspan="2" style="background-color: #ccc">
                <h4 style="margin-top: 3px; margin-bottom: 1px">
                    Update Mail</h4>
            </td> 
            <td class="style12" style="background-color: #ccc">
                </td> 
        </tr>
        <tr>
            <td class="error" style="width: 99px">
                &nbsp;
            </td>
            <td class="style6">
                &nbsp;
            </td>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 99px">
                <asp:Label ID="lblUsername" runat="server">UserTpx:</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="168px"></asp:TextBox>
            </td>
            <td>
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="~/Include/Images/button-Go.png" onclick="ImageButton2_Click" />
            </td>
            <tr>
            <td style="width: 99px">
                <asp:Label ID="lblUsername0" runat="server">Password</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextPassword" runat="server" Height="22px" Width="168px" 
                    TextMode="Password"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <tr class="width: 99px">
          

            <td class="width: 99px">
                <asp:Label ID="Label2" runat="server" Text="UserEmailID"></asp:Label>
                </td>
            <td class="style4">
                <asp:TextBox ID="TextEmail" runat="server" Width="168px"></asp:TextBox>
                </td>
            <td class="style6">
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextEmail" ErrorMessage="someone@in.tesco.com" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        
        <tr class="width: 99px">
          
            <td class="style13">
                <asp:Label ID="Label3" runat="server" Text="Manager"></asp:Label>
                </td>
            <td class="style14">
                <asp:DropDownList ID="DropDownMgr" runat="server" Width="173px">
                </asp:DropDownList>
                </td>
            <td class="style15">
                &nbsp;</td>
        </tr>
        
        <tr>
            <td style="width: 99px">
                &nbsp;</td>
            <td>
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/Include/Images/Save.png" onclick="ImageButton1_Click" Width="126px"
                     /></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp; &nbsp; &nbsp;
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Login Page</asp:HyperLink>
            </td>
        </tr>
        </table>
    </div>
</asp:Content>


