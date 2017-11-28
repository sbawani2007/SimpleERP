<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="SimpleERP.Admin.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<form id="form1" runat="server">
    <div>
        <table>
                <tr>
                    <td>FirstName:</td>
                    <td><asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox></td>
                </tr>
            <tr>
                    <td>LastName:</td>
                    <td><asp:TextBox ID="txtLastName" runat="server"></asp:TextBox></td>
                </tr>
             <tr>
                    <td>Title:</td>
                    <td><asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></td>
                </tr>
             <tr>
                    <td>Date Of Birth:</td>
                    <td><asp:TextBox ID="txtDOB" runat="server"></asp:TextBox></td>
                </tr>
             <tr>
                    <td>Hire Date:</td>
                    <td><asp:TextBox ID="txtHireDate" runat="server"></asp:TextBox></td>
                </tr>
             <tr>
                    <td>Address:</td>
                    <td><asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
             <tr>
                    <td>Salary:</td>
                    <td><asp:TextBox ID="txtSalary" runat="server"></asp:TextBox></td>
                </tr>
             <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Button" OnClick="btnSubmit_Click" /></td>
                </tr>
        </table>
    </div>
         <div>
            <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" DataKeyNames="EmployeeID">
                <Columns>
                    <asp:BoundField DataField="EmployeeID" HeaderText="User Id" ItemStyle-Width="100" />
                    <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-Width="150" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="150" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="150" />
                </Columns>
            </asp:GridView>
        </div>
    </form>--%>
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
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
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
