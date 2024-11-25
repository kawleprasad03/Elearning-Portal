<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddCourse.aspx.cs" Inherits="ElearningPortal.AddCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container mt-4">
        <div class="form-group row">
            <label for="TextBox1" class="col-sm-2 col-form-label font-weight-bold">Course Name :</label>
            <div class="col-sm-6">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group row">
            <label for="FileUpload1" class="col-sm-2 col-form-label font-weight-bold">Course Image :</label>
            <div class="col-sm-6">
                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file"></asp:FileUpload>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-sm-8 text-center">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" CssClass="btn btn-primary btn-lg" />
            </div>
        </div>

    </div>
</asp:Content>
