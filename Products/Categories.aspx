<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site1.Master" CodeBehind="Categories.aspx.cs" Inherits="SimpleERP.Products.Categories" %>
<asp:Content ID="Content"  ContentPlaceHolderID="body" runat="server">
     <div>
            <table>
                <tr>
                    <td>CategoryName:</td>
                    <td>
                        <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Description:</td>
                    <td>
                        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="false" DataKeyNames="CategoryID">
                <Columns>
                    <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" ItemStyle-Width="100" />
                    <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
    </asp:Content>

