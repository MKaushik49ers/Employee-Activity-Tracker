<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="CommentPage.aspx.cs" Inherits="CommentPage" %>

    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script type = "text/javascript" >
       window.history.forward(1);
       </script>
        &nbsp;<table style="width: 444px; height: 130px">
            <tr>
                <td style="width: 440px; height: 18px">
                    <asp:Label ID="Lblreason" runat="server" Font-Bold="True" Height="25px" Text="Enter the Reason for working less/more than SCHEDULED hours"
                        Width="411px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 440px; height: 95px">
                    <asp:TextBox ID="Txtreason" runat="server" Height="66px" TextMode="MultiLine" Width="420px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 440px; height: 42px">
                    <br />
                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Include/Images/Submitbtn.png"
                        OnClick="ImageButton1_Click" />&nbsp;<br />
&nbsp;
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red" 
                        Text="You'll be redirected to the ActivityHome page in 3 seconds..." 
                        Visible="False"></asp:Label>
                    <br />
                </td>
            </tr>
        </table>
        
    </asp:Content>

