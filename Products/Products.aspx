<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master"  CodeBehind="Products.aspx.cs" Inherits="SimpleERP.Products.Products" %>
<asp:Content ID="Content"  ContentPlaceHolderID="body" runat="server">
       <div>
            <table>
                <tr>
                    <td>ProductName:</td>
                    <td>
                        <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>SupplierID:</td>
                    <td>
                        <asp:DropDownList ID="ddlSupplier" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>CategoryID:</td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>QuantityPerUnit:</td>
                    <td>
                        <asp:TextBox ID="txtQuantityPerUnit" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>UnitPrice:</td>
                    <td>
                        <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>UnitsInStock:</td>
                    <td>
                        <asp:TextBox ID="txtUnitsInStock" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>UnitsOnOrder:</td>
                    <td>
                        <asp:TextBox ID="txtUnitsOnOrder" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>ReorderLevel:</td>
                    <td>
                        <asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Discontinued:</td>
                    <td>
                        <asp:TextBox ID="txtDiscontinued" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false" DataKeyNames="ProductID">
                <Columns>
                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="SupplierID" HeaderText="SupplierID" ItemStyle-Width="100" />
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" ItemStyle-Width="100" />
                    <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" ItemStyle-Width="100" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" ItemStyle-Width="100" />
                    <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" ItemStyle-Width="100" />
                    <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" ItemStyle-Width="100" />
                    <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Discontinued" HeaderText="Discontinued" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
   
</asp:Content>

