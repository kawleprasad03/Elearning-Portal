<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="SubCourse.aspx.cs" Inherits="ElearningPortal.SubCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <div class="container my-4">
    <asp:DataList ID="DataListSubCourses" runat="server" OnItemCommand="DataListSubCourses_ItemCommand" RepeatColumns="3">
        <ItemTemplate>
            <div class="subcourse-item border rounded p-3 mb-4 shadow-sm text-center" style="margin-right:20px">
                <asp:Image ID="SubCourseImage" runat="server" 
                           ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("image")) %>' 
                           CssClass="img-fluid mb-2" style="width: 80%;height:165px;" />
                
                <h5 class="font-weight-bold"><%# Eval("subCourseName") %></h5>
                <%--<p class="text-muted">Price: ₹<%# Eval("price") %></p>--%>
                <asp:Button ID="WatchButton" runat="server" Text="Watch" 
                            CommandName="WatchCourse" 
                            CommandArgument='<%# Eval("subCourseName") %>' 
                            CssClass="btn btn-primary mt-2" />
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>



</asp:Content>
