<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part4.4.aspx.cs" Inherits="CS397Project2.Part4__4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Muncie Memorial Hospital Research Labs</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="Search" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" Text="Muncie Memorial Hospital Research Labs"></asp:Label>
        <br />
        <br />
        <asp:Label ID="TitleLbl2" runat="server" Text="Please select a study to see associated physicians."></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="StudiesDdl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StudiesDdl_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="TitleLbl3" runat="server" Text="Select physician ID:"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="PhysiciansDdl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PhysiciansDdl_SelectedIndexChanged"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="TitleLbl5" runat="server" Text="Physician Name:"></asp:Label>
        <br />
        <asp:Label ID="PhysicianNameLbl" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="ErrorLbl" runat="server" Text="" CssClass="error"></asp:Label>
    </div>
    </form>
</body>
</html>
