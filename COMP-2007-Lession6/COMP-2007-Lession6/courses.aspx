<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="courses.aspx.cs" Inherits="COMP_2007_Lession6.courses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Courses</h1>
    <a href="addCourse.aspx">Add Course</a>
    <div>
        <label for="ddlPageSize">Records Per Page:</label>
        <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
            <asp:ListItem Value="3" Text="3"></asp:ListItem>
            <asp:ListItem Value="5" Text="5"></asp:ListItem>
            <asp:ListItem Value="999999" Text="All"></asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:GridView ID="grcourses" runat="server" CssClass="table table-bordered table-hover"
        DataKeyNames="CourseID" AllowPaging="true" PageSize="3" OnPageIndexChanging="grcourses_PageIndexChanged" AllowSorting="true"
         OnSorting="grcourses_Sorting" OnRowDataBound="grcourses_RowDataBound">
        <Columns>
            <asp:BoundField DataField="CourseID" HeaderText="Course ID" SortExpression="CourseID" />
            <asp:BoundField DataField="Title" HeaderText="Title"  SortExpression="Title"/>
            <asp:BoundField DataField="Credits" HeaderText="Credits" SortExpression="Credits" />
            <asp:BoundField DataField="Name" HeaderText="Department Name"  SortExpression="Name"/>
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/stud.aspx"
                DataNavigateUrlFields="CourseID" DataNavigateUrlFormatString="assCourse.aspx?CourseID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true" />
        </Columns>
    </asp:GridView>
</asp:Content>
