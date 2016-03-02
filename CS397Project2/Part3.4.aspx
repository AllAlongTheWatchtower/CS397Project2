<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part3.4.aspx.cs" Inherits="CS397Project2.Part3__3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carolina University Student Data System</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="SearchStudentsByGenderForm" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" Text="Carolina University Student Data System"></asp:Label>
        <br />
        <br />
        <asp:Label ID="TitleLbl2" runat="server" Text="Please select a gender to view students of that gender."></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="GenderDdl" runat="server" 
            OnSelectedIndexChanged="GenderDdl_SelectedIndexChanged"
            AutoPostBack="True" >
        </asp:DropDownList>    
        <br />
        <br />
        <asp:GridView ID="gvStudents" runat="server" horizontalalign="Center" 
            OnRowDataBound ="gvStudents_RowDataBound"></asp:GridView>
    </div>
    </form>
</body>
</html>
