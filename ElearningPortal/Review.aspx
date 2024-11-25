<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="ElearningPortal.Review" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" rel="stylesheet" />

    <style>
        body {
            margin: 0;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #f5f5f5;
            font-family: Arial, sans-serif;
        }

        .container {
            display:flex;
            justify-content:center;
        
        }


        .review-box {
            width: 400px;
            padding: 30px;
            background-color: white;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .star-rating {
            display: flex;
            justify-content: flex-start;
            gap: 5px;
            cursor: pointer;
        }

            .star-rating label {
                font-size: 40px;
                color: gold;
                transition: color 0.3s;
            }

                .star-rating label.selected,
                .star-rating label:hover,
                .star-rating label:hover ~ label {
                    color: gold;
                }

        .submit-button {
            width: 100%;
            background-color: green;
            color: white;
            border: none;
            padding: 10px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 5px;
            transition: background-color 0.3s;
            margin-top: 15px;
        }

            .submit-button:hover {
                background-color: darkgreen;
            }

        .form-group {
            margin-bottom: 15px;
        }

        textarea {
            width: 100%;
            border: 1px solid #ccc;
            border-radius: 5px;
            padding: 10px;
            resize: none;
            font-family: Arial, sans-serif;
        }
    </style>
    <div class="container">
        <div class="review-box">
            <h2>Submit Your Review</h2>

            <div class="form-group">
                <asp:Label ID="lblMainCourse" runat="server" Text="Main Course: "></asp:Label>
                <asp:Label ID="lblMainCourseValue" runat="server" Text=""></asp:Label><br />

                <asp:Label ID="lblSubCourse" runat="server" Text="Sub Course: "></asp:Label>
                <asp:Label ID="lblSubCourseValue" runat="server" Text=""></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="lblRating" runat="server" Text="Rating: "></asp:Label>
                <asp:RadioButtonList ID="rblRating" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="5">5 <i class="fas fa-star" style="color:gold"></i></asp:ListItem>
                    <asp:ListItem Value="4">4 <i class="fas fa-star" style="color:gold"></i></asp:ListItem>
                    <asp:ListItem Value="3">3 <i class="fas fa-star" style="color:gold"></i></asp:ListItem>
                    <asp:ListItem Value="2">2 <i class="fas fa-star" style="color:gold"></i></asp:ListItem>
                    <asp:ListItem Value="1">1 <i class="fas fa-star" style="color:gold"></i></asp:ListItem>
                </asp:RadioButtonList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblDescription" runat="server" Text="Description: "></asp:Label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="5"
                    Columns="30"></asp:TextBox>
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit Review"
                OnClick="btnSubmit_Click" CssClass="submit-button" />

            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
        </div>
        </div>
</asp:Content>
