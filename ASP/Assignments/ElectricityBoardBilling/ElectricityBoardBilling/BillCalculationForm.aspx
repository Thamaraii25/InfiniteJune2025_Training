<%@ Page Title="Bill Calculation" Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true" CodeBehind="BillCalculationForm.aspx.cs" Inherits="ElectricityBoardBilling.BillCalculationForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Electricity Bill Calculation</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1>Electricity Bill Calculation</h1>
        Enter Number Of Bills To Be Added: &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtBillsToBeAdded" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCountOfBills" runat="server" ControlToValidate="txtBillsToBeAdded" 
            ErrorMessage="Number Of Bills To Be Added field is Needed!!" 
            ForeColor="Red" ValidationGroup="addBill">*</asp:RequiredFieldValidator>
        <br /><br />

        <asp:Button ID="btnGenerateInputs" runat="server" Text="Generate Inputs" OnClick="btnGenerateInputs_Click" />
        <br /><br />

        <asp:PlaceHolder ID="phBillInputs" runat="server"></asp:PlaceHolder>
        <br /><br />

        Enter Last 'N' Number of Bills To Generate: &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtLast_N_Bills" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLast_N_Bills" runat="server" ControlToValidate="txtLast_N_Bills"  
            ErrorMessage="Last 'N' Bills To Generate field is Needed!!" 
            ForeColor="Red" ValidationGroup="addBill">*</asp:RequiredFieldValidator>
        <br /><br />

        <asp:Button ID="btnAddBill" runat="server" Text="Submit" ValidationGroup="addBill" OnClick="btnAddBill_Click"/>
        <br /><br />

        <asp:Label ID="lblOutput" runat="server" ForeColor="Blue"></asp:Label>
        <br /><br />
        <asp:Label ID="lblLastNBills" runat="server" ForeColor="Green"></asp:Label>
        <br /><br />

        <asp:ValidationSummary ID="vs" runat="server" ForeColor="Red" ValidationGroup="addBill"/>
    </div>
</asp:Content>