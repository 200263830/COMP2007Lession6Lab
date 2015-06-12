<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="COMP_2007_Lession6.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student</h1>
    <a href="stud.aspx">Add Student</a>
    <asp:GridView ID="grstudent" runat="server" CssClass="table table-bordered table-hover"  AutoGenerateColumns="false"  
        OnRowDeleting="grstudent_RowDeleting" DataKeyNames="StudentID">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" DataFormatString="{0:MM-dd-yyyy}"/>
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/stud.aspx"
                DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="stud.aspx?StudentID={0}"/>
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
