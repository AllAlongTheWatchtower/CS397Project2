<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Part1.aspx.cs" Inherits="CS397Project2.Part1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Value Car Rental, Inc.</title>
    <link href="Project2StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="CarRental" runat="server">
    <div>
        <asp:Label ID="TitleLbl" runat="server" Text="Value Car Rental, Inc."></asp:Label>
        <br />
        <br />
        <asp:Label ID="CarTypeLbl" runat="server" 
            Text="Please select the type of car you would like to rent:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="CarTypeDdl" runat="server"></asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="DaysLbl" runat="server" Text="Number of Days:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="DaysTbx" runat="server"> </asp:TextBox>
        <br />
        <br />
        <asp:Button ID="CalculateBtn" runat="server" Text="Calculate Your Total" OnClick="CalculateBtn_Click" />
        <br />
        <br />
        <asp:Label ID="RentalCostLbl" runat="server" Text=""></asp:Label>
        <asp:Label ID="ErrorLbl" runat="server" Text="" CssClass="error"></asp:Label>   
        <br />
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="DaysTbx" 
            ErrorMessage="Only whole numbers of days may be used.  Please round up where necessary." 
            ValidationExpression="^[0-9]*$" CssClass="error"> </asp:RegularExpressionValidator>        
        <br />
        <asp:RequiredFieldValidator ID="RequiredDaysValidator" runat="server" 
            ErrorMessage="Please enter a whole number of days"  CssClass="error"
            ControlToValidate="DaysTbx"></asp:RequiredFieldValidator>
        <br /> 
    </div>
    </form>
</body>
</html>