<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part4.3.aspx.cs" Inherits="CS397Project2.Part4__2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Muncie Memorial Hospital Research Labs</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="SearchVolunteersByStudy" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" Text="Muncie Memorial Hospital Research Labs"></asp:Label>
        <br />
        <br />
        <asp:Label ID="TitleLbl2" runat="server" Text="Please select a study to see associated volunteers."></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="StudiesDdl" runat="server"
            AutoPostBack="true" OnSelectedIndexChanged="StudiesDdl_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvVolunteers" runat="server"
            horizontalalign="Center">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
