<%@ Page Language="C#" MasterPageFile= "~/InsideMaster.master" AutoEventWireup="true" CodeFile="AddActivity.aspx.cs" Inherits="AddActivity" %>

<script runat="server">

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>

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
                width: 350px;
            }
            .style3
            {
                width: 350px;
            }
       
    </style>
    <script type = "text/javascript" >
       window.history.forward(1);
       </script>
    
      </asp:Content>
      <asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
          <div style="margin-left:210px; margin-top: 100px">
     <table id="Shift" cellpadding="2" cellspacing="0"  class="outerBorder">
        <tr>
            <td class="outerBorder" align="center" colspan="2" 
                style="background-color: #ccc">
                    <h4 style="margin-top: 3px; margin-bottom: 1px">
                        Add Activity Details</h4>
            </td>
        </tr>
        <tr>
                <td style="width: 78px; height: 20px;" class="error">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;</td>
        </tr>
        <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblActivityName" runat="server" Width="112px"> Activity Name</asp:Label>
                    <br />
                    <br />
                    Team Name</td>
                <td class="style3">
                    <asp:TextBox ID="txtActivityName" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtActivityName" ErrorMessage="only alpha numeric characters" 
                        ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="164px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                </td>
        </tr>
        <tr>
            
                <td style="width: 78px" align="left">
                    <asp:Label ID="lblActivityDesc" runat="server" Width="117px"> Activity Description</asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtActivityDesc" runat="server" MaxLength="25" Width="160px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtActivityDesc" ErrorMessage="only alpha numeric characters" 
                        ValidationExpression="^[0-9A-Za-z ]*$"></asp:RegularExpressionValidator>
                </td>
        </tr>
         <tr>
             <td colspan="2" >
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                   <asp:ImageButton ID="ImageButton2" runat="server" 
                       ImageUrl="~/Include/Images/Save.png" onclick="ImageButton2_Click" />
             </td>
         </tr>
           
             </table>
             
        
        </div>
        </asp:Content>

    <%--<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div style="text-align: center; margin-top: 100px">
      <table id="tbl_Activity" cellpadding="5" style="width: 500px; border-collapse: collapse">
          <tr>
              <td style="margin-top: 100px; padding-left: 5px; font-weight: bold; width: 140px;
                  text-align: left">
                    Activity ID</td>
              <td style="padding-left: 5px; width: 360px; text-align: left">
                    <asp:TextBox ID="txtActivityID" runat="server" MaxLength="4" Width="180px"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="margin-top: 100px; padding-left: 5px; font-weight: bold; width: 140px;
                  text-align: left">
              </td>
              <td style="padding-left: 5px; width: 360px; text-align: left">
                    <asp:RequiredFieldValidator ID="rfvActivityID" runat="server" ControlToValidate="txtActivityID"
                        CssClass="error" Display="Dynamic" ErrorMessage="ActivtyID cannot be empty" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revCorrectActivityID" runat="server" ControlToValidate="txtActivityID"
                        CssClass="error" Display="Dynamic" ErrorMessage="Enter correct ActivityID" SetFocusOnError="True"
                        ValidationExpression="[0-9]{3}"></asp:RegularExpressionValidator></td>
          </tr>
        </table>
        <table id="tblEdit" runat="server" cellpadding="5" style="width: 500px; border-collapse: collapse"
            visible="True">
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 134px; height: 8px; text-align: left">
                    Activity Name</td>
                <td style="padding-left: 5px; width: 350px; height: 8px; text-align: left">
                    <asp:TextBox ID="txtActivityName" runat="server" MaxLength="100" Width="180px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 134px; text-align: left">
                </td>
                <td style="padding-left: 5px; width: 350px; text-align: left">
                    <asp:RequiredFieldValidator ID="rfvActivityName" runat="server" ControlToValidate="txtActivityName"
                        CssClass="error" Display="Dynamic" ErrorMessage="Activity name cannot be empty"
                        SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 134px; text-align: left">
                    Activity Description</td>
                <td style="padding-left: 5px; width: 350px; text-align: left">
                    <asp:TextBox ID="txtActivityDescription" runat="server" Width="180px"></asp:TextBox>&nbsp;
                    </td>
            </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 134px; text-align: left">
                </td>
                <td style="padding-left: 5px; width: 350px; text-align: left">
                    <asp:RequiredFieldValidator ID="rfvActivityDescription" runat="server" ControlToValidate="txtActivityDescription"
                        CssClass="error" Display="Dynamic" ErrorMessage="Activity description cannot be empty"
                        SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 134px; text-align: left">
                </td>
                <td style="padding-left: 5px; width: 350px; text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="padding-left: 5px; font-weight: bold; width: 134px; text-align: left">
                </td>
                <td align="left" >
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/button-save-update.png"
                        OnClick="ImageButton1_Click" /></td>
            </tr>
          </table>
        &nbsp;
        </div>
        </asp:Content>--%>