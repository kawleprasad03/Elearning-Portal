<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditSubCourse.aspx.cs" Inherits="ElearningPortal.EditSubCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-4">
   
    <div class="form-group row">
        <label for="TextBox1" class="col-sm-4 col-form-label font-weight-bold">Sub Course Name :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
  
    <div class="form-group row">
        <label for="TextBox2" class="col-sm-4 col-form-label font-weight-bold">Price :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
   
    <div class="form-group row">
        <label for="FileUpload1" class="col-sm-4 col-form-label font-weight-bold">Course Image :</label>
        <div class="col-sm-6">
            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control-file"></asp:FileUpload>
        </div>
    </div>
    
    
    <div class="form-group row">
        <div class="col-sm-6 offset-sm-4">
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" CssClass="btn btn-primary" />
        </div>
    </div>
</div>
</asp:Content>
