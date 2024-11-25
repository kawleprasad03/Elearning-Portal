<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="ElearningPortal.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://checkout.razorpay.com/v1/checkout.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css">
    <style>
        /* Full-screen container */
        .container {
            width: 90%;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f9f9f9;
            border-radius: 10px;
            font-family: Arial, sans-serif;
        }

        /* Profile Section */
        .profile-section {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 20px;
        }

            .profile-section img {
                width: 100px;
                height: 100px;
                border-radius: 50%;
            }

            .profile-section .upload-section {
                text-align: center;
            }

        .user-info-section {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px;
        }

            .user-info-section label {
                display: block;
                margin-bottom: 5px;
                font-weight: bold;
            }

            .user-info-section input[type="text"], .user-info-section input[type="password"] {
                width: 100%;
                padding: 10px;
                margin-bottom: 10px;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

        .button-section {
            text-align: center;
            margin-top: 20px;
        }

        .btn-save, .btn-reset {
            padding: 10px 20px;
            margin: 10px;
            background-color: #4CAF50;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            transition: 0.3s;
        }

        .btn-reset {
            background-color: #f44336;
        }

        .btn-save:hover {
            background-color: #45a049;
        }

        .btn-reset:hover {
            background-color: #e53935;
        }

        /* Course Section for Udemy-like styling */
        .course-container {
            display: flex;
            overflow-x: auto;
            white-space: nowrap;
            margin-top: 40px;
            padding-bottom: 20px;
        }

        .course-card {
            width: 500px;
            height: 400px;
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 8px;
            margin-right: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            overflow: hidden;
            text-align: center;
            transition: transform 0.2s;
            flex-shrink: 0;
        }


            .course-card:hover {
                transform: scale(1.05);
            }

            .course-card img {
                width: 100%;
                height: 180px; /* Larger image, matching Udemy's 16:9 ratio */
                object-fit: cover;
                border-top-left-radius: 8px;
                border-top-right-radius: 8px;
            }

        .course-details {
            padding: 15px;
        }

        .course-name {
            font-weight: bold;
            font-size: 16px;
            margin: 10px 0;
            color: #333;
        }

        .course-price {
            color: #4CAF50;
            font-weight: bold;
            margin: 10px;
             font-size: 16px;
        }

        .course-description {
            color: #666;
            font-size: 14px;
            margin-bottom: 15px;
        }

        .btn-buy {
            display: block;
            width: 100%;
            background-color: #f44336;
            color: white;
            padding: 10px;
            border: none;
            border-radius: 0 0 8px 8px;
            cursor: pointer;
            text-align: center;
            transition: background-color 0.3s;
        }

            .btn-buy:hover {
                background-color: #e53935;
            }

        /* Scrollbar Styling */
        .course-container::-webkit-scrollbar {
            height: 12px;
        }

        .course-container::-webkit-scrollbar-thumb {
            background: #888;
            border-radius: 6px;
        }

            .course-container::-webkit-scrollbar-thumb:hover {
                background: #555;
            }

     .star-gold {
        color: gold;
        font-size: 20px; /* Adjust size as needed */
    }
    .star-muted {
        color: #d3d3d3; /* Gray for empty stars */
        font-size: 20px;
    }
    </style>

    <div class="container">
        <h2>User Profile</h2>


        <div class="profile-section">
            <asp:Image ID="ProfileImage" runat="server" ImageUrl="~/Images/default.png" />

        </div>


        <div class="user-info-section">

            <div>
                <asp:Label ID="UserName" runat="server" Text="First Name"></asp:Label>

            </div>


            <div>
                <asp:Label ID="Email" runat="server" Text="Last Name"></asp:Label>

            </div>


        </div>



        <h2>Available Courses</h2>
        <div class="course-container">
            <asp:Repeater ID="CourseRepeater" runat="server" OnItemDataBound="CourseRepeater_ItemDataBound">
                <ItemTemplate>
                    <div class="course-card">
                        <asp:Image ID="CourseImage" runat="server" ImageUrl='<%# "data:image/png;base64," + Convert.ToBase64String((byte[])Eval("image")) %>' />
                        <div class="course-details">
                            <div class="course-name">
                                <%# Eval("courseName") %>
                            </div>
                            <div class="course-description">
                                <div id="StarsContainer" runat="server"></div>
                                 <div class="course-price">Rs <%# Eval("totalAmount") %></div>
                            </div>
                            <asp:Button ID="BuyButton" runat="server" Text="Buy Now" CssClass="btn-buy" CommandArgument='<%# Eval("id") + "|" + Eval("courseName") + "|" + Eval("totalAmount") %>' OnCommand="BuyButton_Command" />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>



                 

    </div>
</asp:Content>
