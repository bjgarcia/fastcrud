<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZipList.aspx.cs" Inherits="CrudFast.ZipList" %>
<%@ Import Namespace="CrudFast.Data.Domain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/Content/Site.css" media="screen" />
</head>
<body>
    <div id="content">
        <table>
            <caption>Zip Codes</caption>
            <thead>
                <tr><th>City</th><th>State</th><th>Zip Code</th><th></th><th></th></tr>
            </thead>
            <tbody>
                <%foreach (ZipCode zip in GetZipCodes())
                    {
                        Response.Write("<tr class='item'>");
                        Response.Write(string.Format("<td>{0}</td>",zip.city));
                        Response.Write(string.Format("<td>{0}</td>",zip.state));
                        Response.Write(string.Format("<td>{0}</td>",zip.zipcodeid));
                        Response.Write(string.Format("<td><a href='/ZipAdd.aspx' id={0}>Edit</a></td>",zip.zipcodeid));
                        Response.Write(string.Format("<td><a href='/ZipDelete.aspx' id={0}>Delete</a></td>",zip.zipcodeid));
                        Response.Write("</tr>");
                    } %>
            </tbody>
        </table>
        
        <div class="pager">
            <% for (int i = 1; i <= MaxPage; i++) {
                    Response.Write(string.Format("Page: <a href='~/ZipList.aspx?page={0}' {1}>{2}</a>",
                        i, i == CurrentPage ? "class='selected'" : "", i));
                } %>
            <a href="/ZipAdd.aspx">Add</a>
        </div>
    </div>
</body>
</html>
