<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HackerNews.aspx.cs" Inherits="Nextech.HackerNews" %>

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
            <td>
                <asp:Button ID="btnRefresh" runat="server" Text="Get Latest News" OnClick="btnRefresh_Click" />
            </td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
        </tr>
        <tr>
            <td>
                Title:
            </td>
            <td>
                <asp:HyperLink ID="hlTitle" runat="server" Text="Title" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                 Author:
            </td>
            <td>
                <asp:Label ID="lblAuthor" runat="server" Text="Author"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
