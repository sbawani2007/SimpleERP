<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CashTransactionReport.aspx.cs" Inherits="SimpleERP.Reports.CashTransactionReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:GridView ID="gvCash" runat="server" AutoGenerateColumns="true" DataKeyNames="">
    </asp:GridView>
    <table style="margin-left:42%">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>&nbsp;</td>
            
            <td style="margin-left:10%">
                <asp:Label ID="lblDebit" runat="server" Text="0.0"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Label ID="lblCredit" runat="server" Text="0.0"></asp:Label></td>
        </tr>
    </table>         
     <table style="margin-left:38%">
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Current Balance"></asp:Label>&nbsp;</td>
            
            <td style="margin-left:10%">
                <asp:Label ID="lblCalculation" runat="server" Text="0.0"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>     
</asp:Content>
