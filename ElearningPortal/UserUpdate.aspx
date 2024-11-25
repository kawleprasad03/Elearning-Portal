<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserUpdate.aspx.cs" Inherits="ElearningPortal.UserUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <div class="container">
        <h1>Update User Profiles</h1>
        <asp:DataList ID="EditUserDataList" runat="server">
            <ItemTemplate>
                <div class="user-profile">
                    <asp:TextBox ID="txtName" runat="server" Text='<%# Eval("username") %>'></asp:TextBox>


                     <img src='<%# Eval("profile_img") %>' alt="Profile Photo" width="100" height="100" />
                    <asp:FileUpload ID="fileUpload" runat="server" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" CommandArgument='<%# Eval("id") %>' OnClick="btnSave_Click" />
                </div>
            </ItemTemplate>

        </asp:DataList>
    </div>--%>

   <div class="container">
    <h1 class="my-4">Update User Profiles</h1>
    <asp:DataList ID="EditUserDataList" runat="server" RepeatColumns="3">
        <ItemTemplate>
            <div class="mb-3 p-3 border rounded bg-light">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txtName" Text="Username" CssClass="font-weight-bold" />
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Text='<%# Eval("username") %>'></asp:TextBox>
                </div>
                
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="fileUpload" Text="Profile Photo" CssClass="font-weight-bold" />
                    <asp:FileUpload ID="fileUpload" runat="server" CssClass="form-control-file" />
                </div>
                
                <asp:Button ID="btnSave" runat="server" Text="Save" CommandArgument='<%# Eval("id") %>' OnClick="btnSave_Click" CssClass="btn btn-primary mt-2" />
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
</asp:Content>
