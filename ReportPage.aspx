<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true"  CodeFile="ReportPage.aspx.cs" Inherits="_Default" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>



<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

    <script type = "text/javascript" >
       window.history.forward(1);
       </script>
        <p>
            <br />
            <table style="width: 97%">
                <tr>
                    <td style="width: 111px">
                             <asp:Label ID="Label1" runat="server" style="font-weight: 700" 
                    Text="Report Type"></asp:Label>&nbsp;</td>
                    <td style="width: 70px">
                    </td>
                    <td style="width: 147px">
                    </td>
                    <td style="width: 71px">
                    </td>
                    <td style="width: 157px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 111px; height: 23px">
                       <asp:DropDownList ID="DropDownList6" runat="server" Height="21px" 
                    Width="138px" AutoPostBack="True">
                    <asp:ListItem>Employee Report</asp:ListItem>
                    <asp:ListItem>Team Report</asp:ListItem>
                           <asp:ListItem>DetailedEmployee Report</asp:ListItem>
                           <asp:ListItem>DetailedTeamReport</asp:ListItem>
                </asp:DropDownList></td>
                    <td style="width: 70px; height: 23px">
                        &nbsp;</td>
                    <td style="width: 147px; height: 23px">
                        &nbsp;&nbsp;
                    </td>
                    <td style="width: 71px; height: 23px">
                        &nbsp;</td>
                    <td style="width: 157px; height: 23px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 111px; height: 23px">
                        &nbsp;</td>
                    <td style="width: 70px; height: 23px">
                        &nbsp;</td>
                    <td style="width: 147px; height: 23px">
                    </td>
                    <td style="width: 71px; height: 23px">
                        &nbsp;</td>
                    <td style="width: 157px; height: 23px">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 111px; height: 18px">
                        <asp:Label ID="Label2" runat="server" style="font-weight: 700" Text="Team"></asp:Label></td>
                    <td style="width: 70px; height: 18px">
                        <asp:Label ID="Label3" runat="server" style="font-weight: 700" Text="EmpName"></asp:Label></td>
                    <td style="width: 147px; height: 18px">
                        <asp:Label ID="Label4" runat="server" style="font-weight: 700" Text="Year"></asp:Label></td>
                    <td style="width: 71px; height: 18px">
                        <asp:Label ID="Label6" runat="server" style="font-weight: 700" Text="Period"></asp:Label></td>
                    <td style="width: 157px; height: 18px">
                        <asp:Label ID="Label5" runat="server" style="font-weight: 700" Text="Week"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 111px; height: 47px;">
                        <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ListBox1_SelectedIndexChanged1" 
                            SelectionMode="Multiple" Height="64px" Width="144px">
                        </asp:ListBox></td>
                    <td style="width: 70px; vertical-align: top; height: 47px; text-align: left;">
                        
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="21px" 
                             Width="139px">
                        </asp:DropDownList></td>
                    <td style="width: 147px; vertical-align: top; height: 47px; text-align: left;">
                       
                        <asp:DropDownList ID="DropDownList3" runat="server" Height="21px" 
                            Width="139px" AutoPostBack="True" DataTextField=" " 
                            onselectedindexchanged="DropDownList3_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td style="width: 71px; vertical-align: top; height: 47px; text-align: left;">
                        
                        <asp:DropDownList ID="DropDownList5" runat="server" Height="21px" Width="139px" 
                            AutoPostBack="True" onselectedindexchanged="DropDownList5_SelectedIndexChanged">
                        </asp:DropDownList></td>
                    <td style="width: 157px; vertical-align: top; height: 47px; text-align: left;">
                        
                        <asp:DropDownList ID="DropDownList4" runat="server" Height="21px" Width="137px" 
                            onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                            AutoPostBack="True">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 111px; height: 30px">
                    </td>
                    <td style="width: 70px; height: 30px">
                        &nbsp;</td>
                    <td style="width: 147px; height: 30px">
                    </td>
                    <td style="width: 71px; height: 30px">
                    </td>
                    <td style="width: 157px; height: 30px">
                    </td>
                </tr>
                <tr>
                    <td style="width: 111px; height: 30px">
                    </td>
                    <td style="width: 70px; height: 30px">
                    </td>
                    <td style="width: 147px; height: 30px">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/Generate.png"
                            OnClick="ImageButton1_Click" /></td>
                    <td style="width: 71px; height: 30px">
                    </td>
                    <td style="width: 157px; height: 30px">
                    </td>
                </tr>
            </table>
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<table style="width: 100%">
            <tr>
                <td style="width: 629px">
                    &nbsp;</td>
                <td>

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
    AutoDataBind="true" EnableDatabaseLogonPrompt="false" EnableParameterPrompt="false" />
                </td>
            </tr>
        </table>
        
    </p>
<p>

    </p>
    <p>
       </p>

</asp:Content>
