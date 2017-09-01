<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SimpleERP.Admin.Register" %>

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
                <td>
                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>FirstName:</td>
                <td>
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                 <td>
                    <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ErrorMessage="*" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>LastName:</td>
                <td>
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                 <td>
                    <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ErrorMessage="*" ControlToValidate="txtLastName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnCreateUser" runat="server" Text="Submit" OnClick="btnCreateUser_Click" /></td>
            </tr>
        </table>
    </div>
        <div>
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="User Id" ItemStyle-Width="100" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" ItemStyle-Width="150" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="150" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
