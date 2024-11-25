<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CheckAllReview.aspx.cs" Inherits="ElearningPortal.CheckAllReview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-4">
    <h2 class="text-center mb-4">Accept Reviews</h2>
    <asp:GridView ID="gvReviews" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowCommand="gvReviews_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="font-weight-bold" />
            <asp:BoundField DataField="Email" HeaderText="Email" HeaderStyle-CssClass="font-weight-bold" />
            <asp:BoundField DataField="MainCourseName" HeaderText="Main Course" HeaderStyle-CssClass="font-weight-bold" />
            <asp:BoundField DataField="SubCourseName" HeaderText="Sub Course" HeaderStyle-CssClass="font-weight-bold" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" HeaderStyle-CssClass="font-weight-bold" />
            <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-CssClass="font-weight-bold" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnAccept" runat="server" CommandName="Accept" CommandArgument='<%# Eval("Id") %>' Text="Accept" CssClass="btn btn-success btn-sm mr-2" />
                    <asp:Button ID="btnReject" runat="server" CommandName="Reject" CommandArgument='<%# Eval("Id") %>' Text="Reject" CssClass="btn btn-danger btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

</asp:Content>
