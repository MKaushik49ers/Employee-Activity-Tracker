<%@ Page Language="C#" MasterPageFile="~/DaySheetMaster.master" AutoEventWireup="true" CodeFile="EmployeeReportPage.aspx.cs" Inherits="Default2" %>

<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">

<script type = "text/javascript" >
       window.history.forward(1);
     
         </script>
          
       <style type="text/css">
        .style1
        {
            
            font-weight: bold;
            font-size: large;
            
        }
        </style>

<%--<form id="form1" runat="server">--%>
    <div style="height:  34px; width: 1069px ; text-align : center"> 
        <table style="width:100%;">
            <tr>
            <td>
                    <asp:Label ID="Label2" runat="server" 
                        style="font-weight: 700; font-size: large" Text="Employee Report"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ReportPage.aspx">Back</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    <p>
       
    </p>
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="true" oninit="CrystalReportViewer1_Init" />
        <%--</form>--%>
        
 </asp:Content>

