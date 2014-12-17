<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="EditShift.aspx.cs" Inherits="EditShift" %>

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
                width: 554px;
            }
        .error
        {
            color: Red;
            font-size: 11px;
        }
       
            .style2
            {
                height: 20px;
                width: 123px;
            }
            .style3
            {
                width: 123px;
            }
       
            .style4
            {
                height: 20px;
                width: 30px;
            }
            .style5
            {
                width: 30px;
            }
       
    </style>
      </asp:Content>
      <asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px">
     <table id="Login" cellpadding="2" cellspacing="0"  class="outerBorder">
      
         <tr>
             <td class="outerBorder" colspan="3" 
                 style="height: 27px; background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Edit Shift Details</h4>
             </td>
         </tr>
        <tr>
            
                <td class="style2">
                    &nbsp;</td>
                <td style="width: 151px; height: 20px;">
                    &nbsp;</td>
            <td class="style4">
                    </td>
        </tr>
         <tr>
             <td class="style3">
                    <asp:Label ID="lblSelectShift" runat="server"> Select Shift</asp:Label></td>
             <td style="width: 151px">
                 <asp:DropDownList ID="ddlSelectShift" runat="server" OnSelectedIndexChanged="ddlShiftName_SelectedIndexChanged" Width="168px" Height="22px">
                    </asp:DropDownList></td>
             <td class="style5">
                    <asp:ImageButton ID="btnGo" runat="server" ImageUrl="~/Include/Images/button-Go.png" OnClick="btnGo_Click" /></td>
         </tr>
         <tr>
             <td class="style3">
                    <asp:Label ID="lblShiftName" runat="server" Visible="true"> Shift Name</asp:Label></td>
             <td style="width: 151px">
                    <asp:TextBox ID="txtShiftName" runat="server" MaxLength="25" Width="160px" Visible="true" OnTextChanged="txtShiftName_TextChanged"></asp:TextBox></td>
             <td class="style5">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                     ControlToValidate="txtShiftName" Width="247px"
                     ErrorMessage="only alpha numeric characters are allowed" 
                     ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
             </td>
         </tr>
        <tr>
            
                <td class="style3">
                    <asp:Label ID="lblShiftTime" runat="server"> Shift Time</asp:Label>
                </td>
                <td style="width: 151px">
                    <asp:TextBox ID="txtShiftTime" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                </td>
            <td class="style5">
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                     ControlToValidate="txtShiftTime" Width="264px"
                     ErrorMessage="only numeric(0-9)(:)(-)characters are allowed" 
                     ValidationExpression="^[0-9:-]*$"></asp:RegularExpressionValidator>
            </td>
         </tr>
         <tr>
             <td style="height: 39px;" colspan="3">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:ImageButton ID="ImageButton2" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="ImageButton2_Click" />
&nbsp;
                 <asp:ImageButton ID="ImageButton3" runat="server" Height="24px" 
                     ImageUrl="~/Include/Images/delete.png" onclick="ImageButton3_Click" 
                     Width="132px" />
             </td>
         </tr>
                    
            </table>
            </div>
</asp:Content>
 
    <%--<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table style="width: 100%; height: 100%">
            <tr>
                <td style="vertical-align: top; width: 85%; text-align: center">
                    <h4>
                        Edit Shift Details</h4>
                    <table id="tbl_Activity" cellpadding="5" style="width: 500px; border-collapse: collapse">
                        <tr>
                            <td style="padding-left: 5px; font-weight: bold; width: 140px; text-align: left">
                                Shift ID</td>
                            <td style="padding-left: 5px; width: 360px; text-align: left">
                                <asp:TextBox ID="txtShiftID" runat="server" MaxLength="4" Width="100px"></asp:TextBox>
                                <asp:Button ID="btnGetDetails" runat="server" CssClass="buttonDetails" OnClick="btnGetDetails_Click" style="background-attachment: fixed; background-repeat: repeat; background-position: center center; font-size: small; left: 516px; top: 61px;" BorderStyle="None" Height="25px" Text="Get Details" Width="129px" />&nbsp;
                                <br />
                                <asp:RequiredFieldValidator ID="rfvShiftID" runat="server" ControlToValidate="txtShiftID"
                                    CssClass="error" Display="Dynamic" ErrorMessage="ShiftID cannot be empty"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table id="tblEdit" runat="server" cellpadding="5" style="width: 500px; border-collapse: collapse"
                        visible="false">
                        <tr>
                            <td style="padding-left: 5px; font-weight: bold; width: 150px; height: 50px; text-align: left">
                                Shift Time</td>
                            <td style="padding-left: 5px; width: 350px; height: 50px; text-align: left">
                                <asp:TextBox ID="txtShiftTime" runat="server" MaxLength="100" Width="300px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvShiftTime" runat="server" ControlToValidate="txtShiftTime"
                                    CssClass="error" Display="Dynamic" ErrorMessage="Shift Time cannot be empty"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td colspan="2" style="text-align: center">
                                &nbsp;<asp:ImageButton ID="ImgAdd_Click" runat="server" ImageUrl="~/Include/Images/button-save-update.png"
                                    OnClick="ImageButton1_Click" />
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/button-back.png" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        &nbsp;</asp:Content>
--%>