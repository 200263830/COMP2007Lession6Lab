<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="dept.aspx.cs" Inherits="COMP_2007_Lession6.dept" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department</h1>
    <a href="addDept.aspx">Add Department</a>
    <asp:GridView ID="GrdDepartment" runat="server" CssClass="table table-bordered table-hover" AutoGenerateColumns="false"
        OnRowDeleting="GrdDepartment_RowDeleting" DataKeyNames="DepartmentID">
        <Columns>
            <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" />
            <asp:BoundField DataField="Name" HeaderText="Department Name" />
            <asp:BoundField DataField="Budget" HeaderText="Department Budget"  DataFormatString="{0:C}"/>
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/dept.aspx"
                DataNavigateUrlFields="DepartmentID" DataNavigateUrlFormatString="addDept.aspx?DepartmentID={0}"/>
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
