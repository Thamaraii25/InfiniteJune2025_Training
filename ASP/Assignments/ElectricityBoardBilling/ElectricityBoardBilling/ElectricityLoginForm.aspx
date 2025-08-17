<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="ElectricityLoginForm.aspx.cs" Inherits="ElectricityBoardBilling.ElectricityLoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login - Electricity Board</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>Login</h2>
        Email: &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
            ErrorMessage="Email is Required..it can't be null.." ForeColor="Red" ValidationGroup="login">*</asp:RequiredFieldValidator>
        <br /><br />

        Password: &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
            ErrorMessage="Password is Required..it can't be null.." ForeColor="Red" ValidationGroup="login">*</asp:RequiredFieldValidator>
        <br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="login" OnClick="btnLogin_Click" />
        <br /><br />

        <asp:ValidationSummary ID="vs" runat="server" ForeColor="Red" ValidationGroup="login" />
    </div>
</asp:Content>
