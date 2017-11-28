<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="SaleOrders.aspx.cs" Inherits="SimpleERP.Sales.SaleOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-family: Arial;
            font-size: 10pt;
        }

        .Grid td {
            background-color: #A1DCF2;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }

        .Grid th {
            background-color: #3AC0F2;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }

        .ChildGrid td {
            background-color: #eee !important;
            color: black;
            font-size: 10pt;
            line-height: 200%;
        }

        .ChildGrid th {
            background-color: #6C6C6C !important;
            color: White;
            font-size: 10pt;
            line-height: 200%;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[src*=plus]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "../images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "../images/plus.png");
            $(this).closest("tr").next().remove();
        });
    </script>

</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="body" runat="server">
    <div>
        <table>
            <tr>
                <td>CustomerID:</td>
                <td>
                    <%--<asp:TextBox ID="txtCustomerID" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlCustomerID" runat="server" Width="130px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>EmployeeID:</td>
                <td>
                    <%--<asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlEmployee" runat="server" Width="130px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>OrderDate:</td>
                <td>
                    <asp:TextBox ID="txtOrderDate" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>RequiredDate:</td>
                <td>
                    <asp:TextBox ID="txtRequiredDate" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>ShipName:</td>
                <td>
                    <asp:TextBox ID="txtShipName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>ShipAddress:</td>
                <td>
                    <asp:TextBox ID="txtShipAddress" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>ShipCity:</td>
                <td>
                    <asp:TextBox ID="txtShipCity" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>ShipCountry:</td>
                <td>
                    <asp:TextBox ID="txtShipCountry" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>Order Details</td>
                <td></td>
            </tr>
        </table>
    </div>
    <div>
        <table>
            <tr>
                <td>OrderID:</td>
                <td>
                    <asp:TextBox ID="txtOrderID" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>ProductID:</td>
                <td>
                    <%--<asp:TextBox ID="txtProductID" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddlProducts" runat="server" Width="130px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>UnitPrice:</td>
                <td>
                    <asp:TextBox ID="txtUnitPrice" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Quantity:</td>
                <td>
                    <asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Discount:</td>
                <td>
                    <asp:TextBox ID="txtDiscount" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>OrderType:</td>
                <td>
                    <asp:TextBox ID="txtOrderType" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:Button ID="btnAddProduct" runat="server" Text="Add Products" OnClick="btnAddProduct_Click" /></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="false" DataKeyNames="OrderDetailID">
                        <Columns>
                            <asp:BoundField DataField="OrderDetailID" HeaderText="OrderDetailID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="OrderID" HeaderText="OrderID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ItemStyle-Width="100" />
                            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" ItemStyle-Width="100" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="100" />
                            <asp:BoundField DataField="Discount" HeaderText="Discount" ItemStyle-Width="100" />
                            <asp:BoundField DataField="OrderType" HeaderText="OrderType" ItemStyle-Width="100" />
                        </Columns>
                    </asp:GridView>
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="191px" /></td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </div>
    <div>
        <asp:GridView ID="gvSalesorders" runat="server" AutoGenerateColumns="false" DataKeyNames="SalesOrderID" OnRowDataBound="gvPurchaseorders_RowDataBound" CssClass="Grid">
            <Columns>

                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" style="cursor: pointer" src="../images/plus.png" />
                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                            <asp:GridView ID="gvOrdedetails" runat="server" AutoGenerateColumns="false" DataKeyNames="OrderDetailID" CssClass="ChildGrid">
                                <Columns>
                                    <asp:BoundField DataField="OrderDetailID" HeaderText="OrderDetailID" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="OrderID" HeaderText="OrderID" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="ProductID" HeaderText="ProductID" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="Discount" HeaderText="Discount" ItemStyle-Width="100" />
                                    <asp:BoundField DataField="OrderType" HeaderText="OrderType" ItemStyle-Width="100" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SalesOrderID" HeaderText="SalesOrderID" ItemStyle-Width="100" />
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ItemStyle-Width="100" />
                <asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" ItemStyle-Width="100" />
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" ItemStyle-Width="100" />
                <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" ItemStyle-Width="100" />
                <asp:BoundField DataField="ShipName" HeaderText="ShipName" ItemStyle-Width="100" />
                <asp:BoundField DataField="ShipAddress" HeaderText="ShipAddress" ItemStyle-Width="100" />
                <asp:BoundField DataField="ShipCity" HeaderText="ShipCity" ItemStyle-Width="100" />
                <asp:BoundField DataField="ShipCountry" HeaderText="ShipCountry" ItemStyle-Width="100" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>

