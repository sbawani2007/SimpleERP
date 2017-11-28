<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="Customers.aspx.cs" Inherits="SimpleERP.Customer.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
      <div>
            <table>
                <tr>
                    <td>CompanyName:</td>
                    <td>
                        <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>ContactName:</td>
                    <td>
                        <asp:TextBox ID="txtContactName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>ContactTitle:</td>
                    <td>
                        <asp:TextBox ID="txtContactTitle" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Address:</td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>City:</td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Country:</td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Phone:</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Fax:</td>
                    <td>
                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvCustomers" runat="server" AutoGenerateColumns="false" DataKeyNames="CustomerID">
                <Columns>
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ItemStyle-Width="100" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Width="100" />
                    <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Fax" HeaderText="Fax" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
   
</asp:Content>

