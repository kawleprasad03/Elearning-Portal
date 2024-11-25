<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="MyCourse.aspx.cs" Inherits="ElearningPortal.MyCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <style>
     /* CSS Styles */
     body {
         font-family: Arial, sans-serif;
     }
     
     .container, .course-detail-container {
         max-width: 800px;
         margin: auto;
         padding: 20px;
     }
     
     .course-item {
         display: flex;
         cursor: pointer;
         margin-bottom: 20px;
         border: 1px solid #ccc;
         padding: 10px;
     }
     
     .thumbnail {
         width: 200px;
         height: auto;
         margin-right: 20px;
     }
     
     .course-details {
         flex-grow: 1;
     }
     
     .course-title {
         font-size: 18px;
         margin: 0;
     }
     
     .course-price {
         color: gray;
         font-size: 14px;
     }
     
     .course-description {
         font-size: 14px;
         margin-top: 5px;
     }
     
     .course-detail-container img {
         width: 100%;
         height: auto;
     }
     
     .course-detail-container h2 {
         font-size: 24px;
     }
 </style>
    <h2 class="container">My Courses</h2>

<div class="container">
    
    <asp:Panel ID="PanelCourseList" runat="server" Visible="true">
        <asp:DataList ID="DataListCourses" runat="server" OnItemCommand="DataListCourses_ItemCommand" RepeatLayout="Flow">
            <ItemTemplate>
                <div class="course-item border rounded p-3 mb-4 shadow-sm">
                    <asp:Image ID="CourseImage" runat="server" alt="Profile Image" ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("image")) %>' CssClass="thumbnail" />
                    <div class="course-details">
                        <h2 class="course-title"><%# Eval("courseName") %></h2>
                        <p class="course-price">Price: ₹<%# Eval("totalAmount") %></p>
                      <%--  <p class="course-description"><%# Eval("Description") %></p>--%>
                        <p class="course-expiry">Expiry Date: <%# Eval("expiryDate") %></p>
                        <asp:Button CssClass="btn btn-primary" ID="DetailsButton" runat="server" Text="Start Course" CommandName="ShowDetails" CommandArgument='<%# Eval("courseName") %>' />
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </asp:Panel>

    
   
</div>
   
</asp:Content>
