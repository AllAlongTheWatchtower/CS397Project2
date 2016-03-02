<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part3.3.aspx.cs" Inherits="CS397Project2.Part3__1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carolina State University Student Database</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="SearchByMajorForm" runat="server">
        <asp:Label ID="TitleLbl" runat="server" Text="Carolina State University Student Database"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Title2Lbl" runat="server" Text="Search Students By Major"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="MajorDdl" runat="server" 
            OnSelectedIndexChanged="MajorDdl_SelectedIndexChanged"
            AutoPostBack="true" >
        </asp:DropDownList>
        <br />
        <br />
        <div>
            <asp:GridView ID="gvStudents" runat="server" horizontalalign="Center"> 
            </asp:GridView>
        </div>
    </form>
</body>
</html>
