<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZipEdit.aspx.cs" Inherits="CrudFast.ZipEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form action="ZipAdd.aspx" method="post">
        <div>
            Zip Code:</br>
            <input runat="server" id="zipcode" type="text" name="zipcode" /></br>
            City:</br>
            <input  runat="server" id="city" type="text" name="city" /></br>
            State:</br>
            <input  runat="server" id="state" type="text" name="state" />
        </div>
        <div><input type="submit" value="Add" /></div>
    </form>
</body>
</html>
