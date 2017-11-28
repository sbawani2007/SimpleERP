<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleERP.Default" MasterPageFile="~/Site1.Master" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>UserName:</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>FirstName:</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>LastName:</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>CreatedOn:</td>
                    <td>
                        <asp:TextBox ID="txtCreatedOn" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <%--<asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />--%></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="gvJhol" runat="server" AutoGenerateColumns="false" DataKeyNames="Userid">
                <Columns>
                    <asp:BoundField DataField="Userid" HeaderText="Userid" ItemStyle-Width="100" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="FirstName" HeaderText="FirstName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="LastName" HeaderText="LastName" ItemStyle-Width="100" />
                    <asp:BoundField DataField="CreatedOn" HeaderText="CreatedOn" ItemStyle-Width="100" />
                </Columns>
            </asp:GridView>
        </div>
    </form>


</body>
</html>
