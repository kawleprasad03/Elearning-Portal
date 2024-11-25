<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="EditVideo.aspx.cs" Inherits="ElearningPortal.EditVideo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-4">
   
    <div class="form-group row">
        <label for="TextBox1" class="col-sm-3 col-form-label font-weight-bold">Topic Name:</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
   
    <div class="form-group row">
        <label for="TextBox2" class="col-sm-3 col-form-label font-weight-bold">Topic URL:</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

   
    <div class="form-group row">
        <div class="col-sm-6 offset-sm-3">
            <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </div>
    </div>
</div>

</asp:Content>
