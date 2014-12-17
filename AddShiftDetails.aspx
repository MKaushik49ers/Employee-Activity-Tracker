<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="AddShiftDetails.aspx.cs" Inherits="AddShiftDetails" %>


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
                width: 241px;
            }
            .style3
            {
                width: 241px;
            }
            .style4
            {
                height: 21px;
                width: 241px;
            }
       
    </style>
      </asp:Content>
    
    <asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

        <script type = "text/javascript" >
       window.history.forward(1);
       </script>
   <div style="margin-left:210px; margin-top: 100px">
     <table id="Shift" cellpadding="2" cellspacing="0"  class="outerBorder">
        <tr>
            <td class="outerBorder"  colspan="3" 
                style="background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;Add Shift Details</h4>
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
                    <asp:Label ID="lblShiftname" runat="server"> Shift Name</asp:Label>
                </td>
                <td style="width: 162px">
                    <asp:TextBox ID="txtShiftName" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                </td>
                <td align="left" class="style3">
                    <asp:RequiredFieldValidator ID="rfvShiftName" runat="server" ControlToValidate="txtShiftName"
                        CssClass="error" Display="Dynamic" ErrorMessage="ShiftName cannot be empty" SetFocusOnError="True">
                        </asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtShiftName" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
                </td>
           </tr>
            <tr>
                <td style="width: 78px; height: 21px;" align="left">
                    <asp:Label ID="lblShiftTime" runat="server">   Shift Time</asp:Label>
                </td>
                <td style="width: 162px; height: 21px;">
                    <asp:TextBox ID="txtShiftTime" runat="server" Width="160px"></asp:TextBox>
                </td>
                <td align="left" class="style4">
                   <asp:RequiredFieldValidator ID="rfvShiftTime" runat="server" ControlToValidate="txtShiftTime"
                        CssClass="error" Display="Dynamic" ErrorMessage="Shift Time cannot be empty"
                        SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtShiftTime" 
                        ErrorMessage="only alpha numeric characters allowed" 
                        ValidationExpression="^[0-9:-]*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 78px; height: 21px;" align="left">
                    &nbsp;</td>
                <td style="width: 162px; height: 21px;">
                    <asp:Label ID="Label1" runat="server" Text="(Ex:- 6:00-15:00)"></asp:Label>
                </td>
                <td align="left" class="style4">
                    &nbsp;</td>
            </tr>
         <tr>
             <td style="width: 78px">
             </td>
             <td style="width: 162px">
                   <asp:ImageButton ID="btnsave" runat="server" 
                     ImageUrl="~/Include/Images/Save.png" onclick="btnSave_Click" /></td>
             <td class="style3">
                 &nbsp;</td>
         </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td colspan="1" class="style3">
                </td>
            </tr>
            
        </table>
             
        
        </div>
        </asp:Content>
