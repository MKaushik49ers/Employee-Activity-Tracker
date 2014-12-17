<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="ViewReport.aspx.cs" Inherits="Default2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type = "text/javascript" >
       window.history.forward(1);
       </script>
    <table style="width: 812px">
        <tr>
            <td style="width: 192px; height: 19px;">
                <asp:Label ID="Label1" runat="server" Text="FROM DATE:" Font-Bold="True" Height="14px" Width="107px"></asp:Label></td>
            <td style="width: 12px; height: 19px;">
            </td>
            <td style="width: 198px; height: 19px;">
                <asp:Label ID="Label2" runat="server" Text="TO DATE:" Font-Bold="True"></asp:Label></td>
            <td style="width: 335px; height: 19px;">
            </td>
        </tr>
        <tr>
            <td style="width: 192px">
                <asp:TextBox ID="TextBox1" runat="server" Height="23px" Width="138px" Enabled="False"></asp:TextBox>
                <asp:ImageButton
                    ID="ImageButton1" runat="server" Height="28px" ImageUrl="~/Include/Images/calendarimages.jpg"
                    OnClick="ImageButton1_Click" Width="32px" /></td>
            <td style="width: 12px">
            </td>
            <td style="width: 198px">
                <asp:TextBox ID="TextBox2" runat="server" Height="23px" Width="148px" Enabled="False"></asp:TextBox>
                <asp:ImageButton
                    ID="ImageButton2" runat="server" Height="26px" ImageUrl="~/Include/Images/calendarimages.jpg"
                    OnClick="ImageButton2_Click" Width="32px" /></td>
            <td style="width: 335px">
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Include/Images/View.png" OnClick="ImageButton3_Click" />
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Include/Images/Reset.png"
                    OnClick="ImageButton4_Click" /></td>
        </tr>
        <tr>
            <td style="width: 192px">
                </td>
            <td style="width: 12px">
            </td>
            <td style="width: 198px">
                </td>
            <td style="width: 335px">
            </td>
        </tr>
        <tr>
            <td style="width: 192px">
                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
                    BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                    Height="140px" NextPrevFormat="ShortMonth" OnSelectionChanged="Calendar1_SelectionChanged1"
                    Width="213px">
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                        ForeColor="White" Height="12pt" />
                </asp:Calendar>
            </td>
            <td style="width: 12px">
            </td>
            <td style="width: 198px">
                <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="Black"
                    BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
                    Height="124px" NextPrevFormat="ShortMonth" OnSelectionChanged="Calendar2_SelectionChanged"
                    Width="223px">
                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                    <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <DayStyle BackColor="#CCCCCC" />
                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                    <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                        ForeColor="White" Height="12pt" />
                </asp:Calendar>
            </td>
            <td style="width: 335px">
                <br />
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" BackColor="Lavender" BorderColor="#400000"
        BorderStyle="Ridge">
    </asp:GridView>
    <br />
    </asp:Content>

