<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="NewDayUpdate.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1" >

<script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
        <br />
        <table style="width: 974px; height: 2px" id="TABLE1"  >
                    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
        <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


            <tr>
                <td style="width: 12px; height: 37px">
        <asp:Label ID="lblname" runat="server" Height="20px" Text="Name:" Width="51px" Font-Bold="True"></asp:Label></td>
                <td style="width: 360px; height: 37px">
                    <asp:Label ID="lblnameval" runat="server" Height="21px" Text="Employee Name" 
                        Width="261px" Font-Bold="True"></asp:Label></td>
                <td style="width: 56px; height: 37px">
                    <asp:Label ID="Label1" runat="server" Height="21px" Text="TPX ID :" 
                        Width="62px" Font-Bold="True"></asp:Label></td>
                <td style="width: 55px; height: 37px">
                    <asp:Label
            ID="Lbltpx" runat="server" Height="21px" Text="AB12" Width="70px" Font-Bold="True"></asp:Label></td>
                <td style="width: 87px; height: 37px">
                </td>
                <td style="width: 125px; height: 37px">
                    </td>
                <td style="width: 68px; height: 37px">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Height="21px" 
                        Text="Designation:" Width="88px"></asp:Label>
                </td>
                <td style="width: 139px; height: 37px">
                    <asp:Label ID="Lbldesig" runat="server" Font-Bold="True" Height="20px" 
                        Text="Software Engineer" Width="218px"></asp:Label>
                    </td>
                <td style="width: 136px; height: 37px">
                </td>
            </tr>
            <tr>
                <td style="width: 12px; height: 30px;">
        <asp:Label ID="Label5" runat="server" Height="21px" Text="Shift" Width="52px" Font-Bold="True"></asp:Label></td>
                <td style="width: 360px; height: 30px;">
                    <asp:DropDownList
            ID="DropDownList1" runat="server" Height="24px" Width="130px" 
                        onselectedindexchanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
                </td>
                <td style="width: 56px; height: 30px;">
                </td>
                <td style="width: 55px; height: 30px;">
                </td>
                <td style="width: 87px; height: 30px;">
                </td>
                <td style="width: 125px; height: 30px;">
                    &nbsp;</td>
                <td style="width: 68px; height: 30px;">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Scheduled Hours:" 
                        Width="124px"></asp:Label>
                </td>
                <td style="width: 139px; height: 30px;">
                    <asp:TextBox ID="TextBox7" runat="server" Enabled="False" Height="17px" 
                        Width="55px" ></asp:TextBox>
                </td>
                <td style="width: 136px; height: 30px">
                </td>
            </tr>
            <tr>
                <td style="width: 12px; height: 27px;">
        <asp:Label ID="Label7" runat="server" Height="18px" Text="Date" Width="47px" Font-Bold="True"></asp:Label></td>
                <td style="width: 360px; height: 27px;">
        <asp:TextBox ID="txtdate" tabIndex="1" runat="server" Height="18px" Width="124px" 
                        AutoPostBack="true" ontextchanged="txtdate_TextChanged" ></asp:TextBox>
        <asp:ImageButton ID="calendar2" runat="server" Height="23px" 
                        ImageUrl="~/Include/Images/calendarimages.jpg" Width="31px" onclick="calendar2_Click" 
                         />
             <cc1:CalendarExtender ID="Calendar1" runat="server" TargetControlID="txtdate"  PopupButtonID="calendar2"  >
         </cc1:CalendarExtender>
             </td>
                <td style="width: 56px; height: 27px;">
                </td>
                <td style="width: 55px; height: 27px;">
                </td>
                <td style="width: 87px; height: 27px;">
                </td>
                <td style="width: 125px; height: 27px;">
                    &nbsp;</td>
                <td style="width: 68px; height: 27px;">
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" Height="20px" 
                        Text="Reported Hours:" Width="123px"></asp:Label>
                </td>
                <td style="width: 139px; height: 27px">
                    <asp:TextBox ID="TextBox8" runat="server" Enabled="False" Height="17px" 
                        Width="56px"  ></asp:TextBox>
                    </td>
                <td style="width: 136px; height: 27px">
                </td>
            </tr>
            <tr>
                <td style="width: 12px; height: 11px">
        </td>
                <td style="width: 360px; height: 11px">
                
                    <asp:RangeValidator ID="RangeValidator1" runat="server" 
                        ErrorMessage="The date selected is out of range/closed for changes . Select a valid date" 
                        ControlToValidate="txtdate" Type="Date"></asp:RangeValidator>
                     <%--  <cc1:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender1"
             runat="server" Enabled="True" TargetControlID="RangeValidator1" >
        </cc1:ValidatorCalloutExtender>--%>
                
                    </td>
                <td style="width: 56px; height: 11px">
                    &nbsp;</td>
                <td style="width: 55px; height: 11px">
                    &nbsp;</td>
                <td style="width: 87px; height: 11px">
                </td>
                <td style="width: 125px; height: 11px">
                    </td>
                <td style="width: 68px; height: 11px">
                    </td>
                <td style="width: 139px; height: 11px">
                </td>
                <td style="width: 136px; height: 11px">
                </td>
            </tr>
        </table>
       
     
<br />
        
        <asp:Panel ID="Panel5" runat="server" GroupingText="User Entry" 
 Width="97%" HorizontalAlign="Justify" Font-Bold="True" style="margin-bottom: 55px">
<br />
        
       <asp:GridView ID="grvStudentDetails" runat="server" ShowFooter="True" AutoGenerateColumns="False"
                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="grvStudentDetails_RowDeleting" 
                Width="97%" 
                Style="text-align: center; margin-left: 0px; margin-bottom: 53px;">
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="SNo" />
                    <asp:TemplateField HeaderText="Date"  >
                        <ItemTemplate>
                            <asp:TextBox ID="txtDate" runat="server" MaxLength="3" Width="66px" Enabled="false" ></asp:TextBox>
                        </ItemTemplate>
                         <FooterStyle HorizontalAlign="Left" />
                        <FooterTemplate>
                       
                        <asp:ImageButton ID="btnSave" runat="server" Height="24px" ImageUrl="~/Include/Images/Save.png" OnClick="btnSave_Click" Width="100px" OnClientClick = "Confirm()" />
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Team Name" >
                        <ItemTemplate>
                             <asp:DropDownList ID="drpTeam" runat="server" >
                            </asp:DropDownList>
                        </ItemTemplate>
                         <FooterStyle HorizontalAlign="Left" />
                        <FooterTemplate>  
                     
           
         
         <asp:ImageButton ID="Button4" runat="server" Height="24px" ImageUrl="~/Include/Images/View.png" onclick="Button4_Click" Width="100px" />
                      </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activity Name" >
                        <ItemTemplate>
                       <asp:DropDownList ID="drpActivity" runat="server" Width="120px" >
                            </asp:DropDownList>
                        </ItemTemplate>
                         <FooterStyle HorizontalAlign="Left" />
                        <%--<FooterTemplate>
                     
                     <asp:ImageButton ID="Button3" runat="server"  onclick="Button3_Click" Height="24px" ImageUrl="~/Include/Images/Submitbtn.png" Width="100px" />
                     
                     <input id="Hidden1" type="hidden" runat="server"/>
                     </FooterTemplate>--%>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Activity Hours" >
                        <ItemTemplate>
                             <asp:DropDownList ID="drpHour" runat="server" >
                            </asp:DropDownList>
                        </ItemTemplate>
                       
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Activity Minutes" >
                        <ItemTemplate>
                       <asp:DropDownList ID="drpMin" runat="server" >
                            </asp:DropDownList>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                     
                    <asp:TemplateField HeaderText="Comments">
                        <ItemTemplate>
                            <asp:TextBox ID="txtComments" runat="server" Height="55px" TextMode="MultiLine"></asp:TextBox>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                       
                   <asp:TemplateField HeaderText="Delete">
        <ItemTemplate>
               
                  <asp:ImageButton ID="deleteButton" runat="server" CommandName="Delete" Height="30px" ImageUrl="~/Include/Images/minus.jpg" Width="30px" /><br />
        </ItemTemplate>
         <FooterStyle HorizontalAlign="center" />
                        <FooterTemplate>
                       
                          <asp:ImageButton ID="ButtonAdd" runat="server"  OnClick="ButtonAdd_Click"    Height="24px" ImageUrl="~/Include/Images/plus.jpg" Width="23px" />
                       
                        </FooterTemplate>
</asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            </asp:Panel>
            <%--</asp:Panel>--%>
   
        <br />
        <br />
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        </asp:Content>
        
        
       

