<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="ElearningPortal.Assignment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div class="container my-4">
    <h2 class="text-center mb-4">Assignments</h2>
    <asp:GridView ID="gvAssignments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="mainCourseName" HeaderText="Main Course" HeaderStyle-CssClass="font-weight-bold" />
            <asp:BoundField DataField="subCourseName" HeaderText="Sub Course" HeaderStyle-CssClass="font-weight-bold" />
            <asp:TemplateField HeaderText="Download">
                <ItemTemplate>
                    <asp:Button ID="btnDownload" runat="server" Text="Download" CommandArgument='<%# Eval("id") %>' OnClick="btnDownload_Click" CssClass="btn btn-primary btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Upload Solution">
                <ItemTemplate>
                    <asp:FileUpload ID="fuSolution" runat="server" CssClass="form-control-file" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Submit">
                <ItemTemplate>
                    <asp:Button ID="btnUploadSolution" runat="server" Text="Upload Solution" CommandArgument='<%# Eval("id") %>' OnClick="btnUploadSolution_Click" CssClass="btn btn-success btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>


</asp:Content>
