<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UploadVideos.aspx.cs" Inherits="ElearningPortal.UploadVideos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
    
    <div class="form-group row">
        <label for="DropDownList1" class="col-sm-4 col-form-label font-weight-bold">Select Course Name :</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    
   
    <div class="form-group row">
        <label for="DropDownList2" class="col-sm-4 col-form-label font-weight-bold">Select Sub Course Name :</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    
    
    <div class="form-group row">
        <label for="TextBox1" class="col-sm-4 col-form-label font-weight-bold">Topic Name :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
  
    <div class="form-group row">
        <label for="TextBox2" class="col-sm-4 col-form-label font-weight-bold">Topic URL :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
   
    <div class="form-group row">
        <div class="col-sm-12 text-center">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" CssClass="btn btn-primary btn-lg" />
        </div>
    </div>
</div>
</asp:Content>
