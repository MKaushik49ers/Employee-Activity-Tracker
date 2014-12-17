<%@ Page Title="" Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="MyView.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" Runat="Server" ContentPlaceHolderID="ContentPlaceHolder1" >
<script type = "text/javascript" >
       window.history.forward(1);
       </script>
    <br />
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

     <table style="width: 897px; height: 9px" id="TABLE1"  >
                    
         <tr>
                <td style="width: 12px; height: 26px">
                <asp:Label ID="Label1" runat="server" Text="From Date:" Font-Bold="True" Height="14px" Width="107px"></asp:Label></td>
            <td style="width: 198px; height: 19px;">
                <asp:Label ID="Label2" runat="server" Text="To Date:" Font-Bold="True"></asp:Label></td>
            <td style="width: 335px; height: 19px;">
            </td>
        </tr>
        <tr>
            <td style="width: 192px">
                <asp:TextBox ID="TextBox7" tabIndex="1" runat="server" Height="18px" Width="124px" 
                        AutoPostBack="true" ontextchanged="TextBox7_TextChanged" 
                    Font-Bold="True" Font-Size="Small" ForeColor="Black"   ></asp:TextBox>
                        <cc1:calendarextender ID="Calendar1" runat="server" 
           TargetControlID="TextBox7" PopupButtonID="ImageButton1"  >
         </cc1:calendarextender>
                <asp:ImageButton
                    ID="ImageButton1" runat="server" Height="28px" ImageUrl="~/Include/Images/calendarimages.jpg"
                     Width="32px" /></td>
            <td style="width: 198px">
                <asp:TextBox ID="TextBox8" tabIndex="1" runat="server" Height="18px" Width="124px" 
                        AutoPostBack="true" ontextchanged="TextBox8_TextChanged" 
                    Font-Bold="True" Font-Size="Small"   ></asp:TextBox>
                       <cc1:CalendarExtender ID="Calendar2" runat="server" 
           TargetControlID="TextBox8" PopupButtonID="ImageButton2"  >
         </cc1:CalendarExtender> 
                <asp:ImageButton
                    ID="ImageButton2" runat="server" Height="26px" ImageUrl="~/Include/Images/calendarimages.jpg"
                     Width="32px" /></td>
            <td style="width: 335px">
                <asp:ImageButton ID="ImageButton3" runat="server" 
                    ImageUrl="~/Include/Images/View.png" OnClick="ImageButton3_Click" Height="19px" 
                    style="margin-left: 8px" Width="97px" />
                </td>
        </tr>
        <tr>
            <td style="width: 192px">
                <asp:RangeValidator ID="RangeValidator2" runat="server" 
                    ErrorMessage="Selected Date must not be greater than present date" 
                    ControlToValidate="TextBox7" Type="Date"></asp:RangeValidator>
                    <cc1:ValidatorCalloutExtender ID="RangeValidator2_ValidatorCalloutExtender1"
             runat="server" Enabled="True" TargetControlID="RangeValidator2" >
        </cc1:ValidatorCalloutExtender>
                </td>
            <td style="width: 198px">
                    <asp:RangeValidator ID="RangeValidator1" runat="server"
                ControlToValidate="TextBox8" Type="Date" 
                    ErrorMessage="Selected Date must be in Range of From Date and Present Date"></asp:RangeValidator>
        <cc1:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender"
             runat="server" Enabled="True" TargetControlID="RangeValidator1" >
        </cc1:ValidatorCalloutExtender>
                </td>
            <td style="width: 335px">
            </td>
        </tr>
        <tr>
            <td style="width: 192px">
                &nbsp;</td>
            <td style="width: 198px">
                &nbsp;</td>
            <td style="width: 335px">
                <br />
            </td>
        </tr>
    </table>
    <br />
    <br />
     <asp:Panel ID="Panel5" runat="server" GroupingText="Report" 
 Width="90%" HorizontalAlign="Justify" Font-Bold="True" 
        style="margin-bottom: 55px; margin-right: 0px;" Visible="False">
    <asp:GridView ID="grvStudentDetails" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="Black" GridLines="None" 
                Width="100%" 
                Style="text-align: left; margin-left: 0px; margin-bottom: 53px;" 
             Font-Bold="True">
                <RowStyle BackColor="#C6D6FD" />
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDate" runat="server" Font-Bold="True" MaxLength="3" Width="59px" Enabled="false"></asp:TextBox>
                        </ItemTemplate>
                         <FooterStyle HorizontalAlign="Left" />
                        <FooterTemplate>
                       
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Team Name">
                        <ItemTemplate>
                             <asp:DropDownList ID="drpTeam" runat="server" Font-Bold="True" >
                            </asp:DropDownList>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpTeam"
                                ErrorMessage="*" InitialValue="Select" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                         <FooterStyle HorizontalAlign="Left" />
                        <FooterTemplate>  
                     
           
         
                      </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activity Name">
                        <ItemTemplate>
                       <asp:DropDownList ID="drpActivity" runat="server" Font-Bold="True" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="drpActivity"
                                ErrorMessage="*" InitialValue="Select"  SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                         <FooterStyle HorizontalAlign="Left" />
                        <FooterTemplate>
                        
                                
                     <input id="Hidden1" type="hidden" runat="server"/>
                     </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Activity Hours">
                        <ItemTemplate>
                             <asp:DropDownList ID="drpHour" runat="server" Font-Bold="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpHour"
                                ErrorMessage="*" InitialValue="Select" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activity Minutes">
                        <ItemTemplate>
                       <asp:DropDownList ID="drpMin" runat="server" Font-Bold="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpMin"
                                ErrorMessage="*" InitialValue="Select" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComments" runat="server" Font-Bold="True" ForeColor="Black" Font-Size="Medium" Height="55px" TextMode="MultiLine"></asp:TextBox>
                        </ItemTemplate>
                         <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                       
                        </FooterTemplate>
                    </asp:TemplateField>
                       
                    
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
    <br />
     </asp:Panel>
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </asp:Content>

