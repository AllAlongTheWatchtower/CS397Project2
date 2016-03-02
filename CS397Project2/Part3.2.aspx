<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part3.2.aspx.cs" Inherits="CS397Project2.Part3__2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carolina State University Student Data System</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="SearchByStateForm" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" 
            Text="Carolina State University Student Data System"></asp:Label>
        <br />
        <br />
        <asp:Label ID="TitleLbl2" runat="server" 
            Text="Please select a state to see students enrolled from that state"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="StateDdl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="StateDdl_SelectedIndexChanged" >
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="gvStudents" runat="server" horizontalalign="Center">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
