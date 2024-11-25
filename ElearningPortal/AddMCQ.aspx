<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddMCQ.aspx.cs" Inherits="ElearningPortal.AddMCQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
    
    <div class="form-group row">
        <label for="DropDownList1" class="col-sm-4 col-form-label font-weight-bold">Select Course Name :</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    
   
    <div class="form-group row">
        <label for="DropDownList2" class="col-sm-4 col-form-label font-weight-bold">Select Sub Course Name :</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
            </asp:DropDownList>
        </div>
    </div>
    
   
    <div class="form-group row">
        <label for="TextBox1" class="col-sm-4 col-form-label font-weight-bold">Question :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

   
    <div class="form-group row">
        <label for="TextBox2" class="col-sm-4 col-form-label font-weight-bold">Option 1 :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    
    
    <div class="form-group row">
        <label for="TextBox3" class="col-sm-4 col-form-label font-weight-bold">Option 2 :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    
    <div class="form-group row">
        <label for="TextBox4" class="col-sm-4 col-form-label font-weight-bold">Option 3 :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    
    <div class="form-group row">
        <label for="TextBox5" class="col-sm-4 col-form-label font-weight-bold">Option 4 :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

   
    <div class="form-group row">
        <label for="TextBox6" class="col-sm-4 col-form-label font-weight-bold">Answer :</label>
        <div class="col-sm-6">
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

  
    <div class="form-group row">
        <div class="col-sm-6 offset-sm-4">
            <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button1_Click" />
        </div>
    </div>
</div>

</asp:Content>
