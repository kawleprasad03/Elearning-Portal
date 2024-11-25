<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="MCQ.aspx.cs" Inherits="ElearningPortal.MCQ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container my-4">
    <h2 class="text-center mb-4">MCQ Questions</h2>
    <asp:Repeater ID="rptQuestions" runat="server" OnItemDataBound="rptQuestions_ItemDataBound">
        <ItemTemplate>
            <div class="question-container p-3 mb-4 border rounded shadow-sm">
                <p class="font-weight-bold">Q<asp:Label ID="lblQuestion" runat="server" Text='<%# Eval("QuestionText") %>'></asp:Label></p>
                
                <asp:RadioButtonList ID="rblOptions" runat="server" RepeatDirection="Vertical" CssClass="list-group list-group-flush mb-3"></asp:RadioButtonList>
                
                <asp:Button ID="btnCheckAnswer" runat="server" Text="Check Answer" CommandArgument='<%# Eval("Id") %>' OnClick="btnCheckAnswer_Click" CssClass="btn btn-primary btn-sm" />
                
                <asp:Label ID="lblAnswer" runat="server" Visible="false"></asp:Label>
            </div>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
</div>


</asp:Content>
