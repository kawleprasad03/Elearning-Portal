<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VideoEditorDelete.aspx.cs" Inherits="ElearningPortal.VideoEditorDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<%--    <asp:Label ID="Label1" runat="server" Text="Select Course Name :"></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />&nbsp;<asp:Label ID="Label2" runat="server" Text="Select Sub Course Name :"></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
    </asp:DropDownList>

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand1">
        <Columns>
    <asp:BoundField DataField="topicName" HeaderText="Topic Name" />
    <asp:BoundField DataField="topicUrl" HeaderText="URL" />
    <asp:TemplateField>
        <ItemTemplate>
            <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' />
            <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="DeleteVideo" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('Are you sure you want to delete this Video?');" />
        </ItemTemplate>
    </asp:TemplateField>
</Columns>
    </asp:GridView>--%>


    <div class="container mt-4">
    <!-- Select Course Name -->
    <div class="form-group row">
        <label for="DropDownList1" class="col-sm-4 col-form-label font-weight-bold">Select Course Name :</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    
    <!-- Select Sub Course Name -->
    <div class="form-group row">
        <label for="DropDownList2" class="col-sm-4 col-form-label font-weight-bold">Select Sub Course Name :</label>
        <div class="col-sm-6">
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
    </div>
    
    <!-- GridView for Topics -->
    <div class="row">
        <div class="col-12">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered mt-4" OnRowCommand="GridView1_RowCommand1">
                <Columns>
                   
                    <asp:BoundField DataField="topicName" HeaderText="Topic Name" HeaderStyle-CssClass="font-weight-bold" ItemStyle-CssClass="text-center" />
                    
                    
                    <asp:BoundField DataField="topicUrl" HeaderText="URL" HeaderStyle-CssClass="font-weight-bold" ItemStyle-CssClass="text-center" />
                    
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-warning btn-sm mx-1" />
                            <asp:Button ID="DeleteButton" runat="server" Text="Delete" CommandName="DeleteVideo" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('Are you sure you want to delete this Video?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>

</asp:Content>
