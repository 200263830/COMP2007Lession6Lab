<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="addDept.aspx.cs" Inherits="COMP_2007_Lession6.addDept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department details</h1>
    <fieldset>
        <label for="txtDeptName" class="col-sm-2">Department Name:</label>
        <asp:TextBox ID="txtDeptName" runat="server" required MaxLength="50"></asp:TextBox>
    </fieldset>
    <fieldset>
        <label for="txtBudget" class="col-sm-2">Budget Amount:</label>
        <asp:TextBox ID="txtBudget" runat="server" required MaxLength="50"></asp:TextBox>
    </fieldset>
    
    <div> 
        <asp:Button ID="btnDeptsave" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnDeptsave_Click"  />
    </div>
</asp:Content>
