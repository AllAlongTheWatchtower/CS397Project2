<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part3.5.aspx.cs" Inherits="CS397Project2.Part3__4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carolina State University Student Data System</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" Text="Carolina State University Student Data System"></asp:Label>
        <br />
        <br />
        <asp:Label ID="SearchTbxLbl" runat="server" Text="Please enter the last name of the student you wish to search:"></asp:Label>
        <br />
        <br />
        <asp:TextBox ID="LastNameTbx" runat="server">
        </asp:TextBox>    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" style="width: 61px" />
        <br />
        <br />
        <asp:GridView ID="gvStudents" runat="server"
            horizontalalign="Center" OnRowDataBound ="gvStudents_RowDataBound">
        </asp:GridView>
        <br />
        <asp:RequiredFieldValidator ID="NameRequiredValidator" runat="server" 
            CssClass="error" ControlToValidate="LastNameTbx"
            ErrorMessage="Please enter a last name in the search box"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="ErrorLbl" runat="server" CssClass="error" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>