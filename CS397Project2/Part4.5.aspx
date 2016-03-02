<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part4.5.aspx.cs" Inherits="CS397Project2.Part4__5" %>

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
        <asp:Label ID="TitleLbl2" runat="server" Text="Please enter a minimum cholesterol value:"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID ="CholesterolTbx" runat="server" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="SearchBtn" runat="server" Text ="Search" OnClick="SearchBtn_Click" />
        <br />
        <asp:Label ID="ErrorLbl" runat="server" Text="" CssClass="error"></asp:Label>
        <br />
        <asp:RegularExpressionValidator ID="CholesterolValidator" 
            runat="server" CssClass="error"
            ControlToValidate="CholesterolTbx"
            ValidationExpression="^\d*\.{0,1}\d+$"
            ErrorMessage="Please enter a positive number"></asp:RegularExpressionValidator><br />
        <asp:RequiredFieldValidator ID="RequiredCholesterolFieldValidator"
            runat="server" ControlToValidate="CholesterolTbx"
            CssClass="error"
            ErrorMessage="Please enter a positive number"></asp:RequiredFieldValidator>
        <asp:GridView ID="gvVolunteers" runat="server"
            horizontalalign="Center"> </asp:GridView>
    </div>
    </form>
</body>
</html>
