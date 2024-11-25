<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CourseEditOrDelete.aspx.cs" Inherits="ElearningPortal.CourseEditOrUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container mt-4">
   
    <div class="form-group row">
        <label for="DropDownList1" class="col-sm-4 col-form-label font-weight-bold">Select Course :</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    
    
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered" OnRowCommand="GridView1_RowCommand">
                <Columns>
                   
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:Image ID="Image1" runat="server" CssClass="img-thumbnail" 
                                           ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("image")) %>' 
                                           Width="100px" Height="100px" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    <asp:BoundField DataField="subCourseName" HeaderText="Sub Course Name" />

                    
                    <asp:BoundField DataField="price" HeaderText="Price" />

                  
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="text-center">
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditSubCourse" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning btn-sm" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteSubCourse" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this sub-course?');" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>

</asp:Content>
