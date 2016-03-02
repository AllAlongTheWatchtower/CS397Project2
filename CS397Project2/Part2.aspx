<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part2.aspx.cs" Inherits="CS397Project2.Part2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to 5th Avenue Parking Garage!</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" Text="5th Avenue Parking Garage"></asp:Label>
        <br />
        <br />
        <asp:Label ID="HoursLbl" runat="server" Text="Number of Hours:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="HoursTbx" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="CalculateCostBtn" runat="server" 
            Text="Calculate Cost" CausesValidation="true" 
            OnClick="CalculateCostBtn_Click" />
        <br />
        <asp:Label ID="CostLbl" runat="server" Text=""></asp:Label>
        <asp:Label ID="ErrorLbl" CssClass="error" runat="server" Text=""></asp:Label>
        <br />
        <asp:RegularExpressionValidator ID="HoursValidator" 
            runat="server" ErrorMessage="Please enter a positive number of hours." 
            CssClass="error" ValidationExpression="^\d*\.{0,1}\d+$" ControlToValidate="HoursTbx" ></asp:RegularExpressionValidator>
        <br />
        <asp:RequiredFieldValidator ID="RequiredHoursValidator" 
            runat="server" ErrorMessage="Please enter a positive number of hours"
            CssClass="error" ControlToValidate="HoursTbx" ></asp:RequiredFieldValidator>
        <br />
    </div>
    </form>
</body>
</html>
