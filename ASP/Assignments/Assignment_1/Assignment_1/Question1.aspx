<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question1.aspx.cs" Inherits="Assignment_1.ASP_Assignment_1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="color:darkblue;font-size:20px;text-align:center">Registration Form</h1>
        <div>
        Name: &nbsp;&nbsp;
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" ErrorMessage="Name Cannot be Empty" ForeColor="Red" ValidationGroup="Check">*</asp:RequiredFieldValidator>
        <br />
        <br />
        Family Name: &nbsp;&nbsp;
        <asp:TextBox ID="txtFamilyName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" ControlToValidate="txtFamilyName" ErrorMessage="Family Name Cannot be Empty" ForeColor="Red" ValidationGroup="Check">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="cvFamilyName" runat="server" Operator="NotEqual" ControlToCompare="txtName" ControlToValidate="txtFamilyName"  ErrorMessage="Family Name Should be Different from Name" ForeColor="Red" ValidationGroup="Check">*</asp:CompareValidator>
        <br />
        <br />
        Address: &nbsp;&nbsp;
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address Cannot be Empty" ForeColor="Red" ValidationGroup="Check">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revAddress" runat="server" ValidationExpression=".{2,}" ControlToValidate="txtAddress" ErrorMessage="Address Need atleast 2 characters" ForeColor="Red" ValidationGroup="Check">*</asp:RegularExpressionValidator>
        <br />
        <br />
        City: &nbsp;&nbsp;
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity" ErrorMessage="City Cannot be Empty" ForeColor="Red" ValidationGroup="Check">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revCity" runat="server" ValidationExpression=".{2,}" ControlToValidate="txtCity" ErrorMessage="City Should have atleast 2 characters" ForeColor="Red" ValidationGroup="Check">*</asp:RegularExpressionValidator>
        <br />
        <br />
        Zip Code: &nbsp;&nbsp;
        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode" ErrorMessage="Zip Code Cannot be Empty" ForeColor="Red" ValidationGroup="Check">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revZipCode" runat="server" ValidationExpression="^\d{5}$" ControlToValidate="txtZipCode" ErrorMessage="Enter crt 5 Digit Zip Code" ForeColor="Red" ValidationGroup="Check">*</asp:RegularExpressionValidator>
        <br />
        <br />
        Phone: &nbsp;&nbsp;
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone" ErrorMessage="Phone Number Cannot be Empty" ForeColor="Red" ValidationGroup="Check">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revPhone" runat="server" ValidationExpression="^\d{2,3}-\d{7}$" ControlToValidate="txtPhone" ErrorMessage="Phone number according to the format XX-XXXXXXX or XXX-XXXXXXX" ForeColor="Red" ValidationGroup="Check">*</asp:RegularExpressionValidator>
        <br />
        <br />
        Email: &nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Name Cannot be Empty" ForeColor="Red" ValidationGroup="Check">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
          ControlToValidate="txtEmail" ErrorMessage="Email is not in the Valid Format" ForeColor="Red" ValidationGroup="Check">*</asp:RegularExpressionValidator>
        <br />
        <br />
         <asp:Button ID="btnCheck" Text="Check" runat="server" ValidationGroup="Check" OnClick="btnCheck_Click"/><br /><br />
        <asp:ValidationSummary ID="vsCheck" runat="server" ForeColor="Red" ValidationGroup="Check" />
        </div>
    </form>
</body>
</html>
