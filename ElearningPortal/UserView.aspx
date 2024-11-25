<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserView.aspx.cs" Inherits="ElearningPortal.UserView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

  <div class="container">
    <h1>User Profiles</h1>
    <asp:DataList ID="DataList1" runat="server" RepeatColumns="3">
        <ItemTemplate>
            <div class="border rounded mb-3 p-3" style="margin:10px">
                <div class="text-center">
                    <img src='<%# Eval("profile_img") %>' class="img-fluid mb-2" style="width: 100px; height: 100px;" alt="Profile Image">
                </div>
                <h5 class="font-weight-bold"><%# Eval("username") %></h5>
                <p><strong>Email:</strong> <%# Eval("email") %></p>
          
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
</asp:Content>
