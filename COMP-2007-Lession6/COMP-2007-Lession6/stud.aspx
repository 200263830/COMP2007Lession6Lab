<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="stud.aspx.cs" Inherits="COMP_2007_Lession6.stud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student details</h1>
    <fieldset>
        <label for="txtLastname" class="col-sm-2">Last Name</label>
        <asp:TextBox ID="txtLastname" runat="server" required MaxLength="50"></asp:TextBox>
    </fieldset>
    <fieldset>
        <label for="txtfirstmidname" class="col-sm-2">First Name</label>
        <asp:TextBox ID="txtfirstname" runat="server" required MaxLength="50"></asp:TextBox>
    </fieldset>
    <fieldset>
        <label for="enrolmentDate" class="col-sm-2">Enrollment Date:</label>
        <asp:TextBox ID="txtenrlldate" runat="server" required MaxLength="50" ></asp:TextBox>
        <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Must be a date" ControlToValidate="txtenrlldate" CssClass="alert alert-danger" Type="Date" MinimumValue="01/01/2000" MaximumValue="01/01/2999"></asp:RangeValidator>
    </fieldset>
    <div> 
        <asp:Button ID="btnsave" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnsave_Click" />
    </div>
</asp:Content>
