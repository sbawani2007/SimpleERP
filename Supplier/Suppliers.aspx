<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site1.Master" CodeBehind="Suppliers.aspx.cs" Inherits="SimpleERP.Supplier.Suppliers" %>

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
                    <td>Mobile:</td>
                    <td>
                        <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Phone:</td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>HomePage:</td>
                    <td>
                        <asp:TextBox ID="txtHomePage" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvSuppliers" runat="server" AutoGenerateColumns="false" DataKeyNames="SupplierID">
                <Columns>
                    <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" ItemStyle-Width="100" />
                    <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ContactName" HeaderText="ContactName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Width="100" />
                    <asp:BoundField DataField="City" HeaderText="City" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Country" HeaderText="Country" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Mobile" HeaderText="Mobile" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="100" />
                    <asp:BoundField DataField="HomePage" HeaderText="HomePage" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
  
</asp:Content>

