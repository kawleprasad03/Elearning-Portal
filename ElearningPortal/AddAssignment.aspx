<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddAssignment.aspx.cs" Inherits="ElearningPortal.AddAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="container mt-4">
    
    <div class="form-group row">
        <label for="DropDownList1" class="col-sm-3 col-form-label font-weight-bold">Select Course Name:</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>

   
    <div class="form-group row">
        <label for="DropDownList2" class="col-sm-3 col-form-label font-weight-bold">Select Sub Course Name:</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>

   
    <div class="form-group row">
        <label for="FileUpload1" class="col-sm-3 col-form-label font-weight-bold">Assignment File:</label>
        <div class="col-sm-6">
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file" />
        </div>
    </div>

   
    <div class="form-group row">
        <div class="col-sm-6 offset-sm-3">
            <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </div>
    </div>
</div>

</asp:Content>
