<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part4.2.aspx.cs" Inherits="CS397Project2.Part4__1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Muncie Memorial Hospital Research Labs</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" Text="Muncie Memorial Hospital Research Labs"></asp:Label>
        <br />
        <br />
        <asp:Label ID="TitleLbl2" runat="server" Text="Please select a physician specialization."></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="SpecializationDdl" runat="server"
            AutoPostBack="true" OnSelectedIndexChanged="SpecializationDdl_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvPhysicians" runat="server"
            horizontalalign="Center" OnRowDataBound ="gvPhysicians_RowDataBound">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
