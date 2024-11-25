<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserDelete.aspx.cs" Inherits="ElearningPortal.UserDelete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <h1 class="mb-4">Delete User Profiles</h1>
        <asp:DataList ID="DeleteUserDataList" runat="server" RepeatColumns="3" CellPadding="3" CellSpacing="1">
            <ItemTemplate>
                <div class="border rounded p-3 mb-3">
                   <div class="text-center">
                         <asp:Image ID="CourseImage" runat="server" ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("profilePhoto")) %>' style="width: 100px; height: 100px;" alt="Profile Image"/>
                    </div>
                    <h5 class="font-weight-bold"><%# Eval("name") %></h5>
                    <p style="color: black;"><strong>Email:</strong> <%# Eval("email") %></p>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger mt-2" CommandArgument='<%# Eval("id") %>' OnClick="btnDelete_Click" />
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>

</asp:Content>
