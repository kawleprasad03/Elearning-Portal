<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ElearningPortal.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #e9f5e9; 
            color: #333;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        div {
            background-color: #fff; 
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 300px;
        }

        .aspNetHidden {
            display : none;
        }

        label {
            font-weight: bold;
            margin-top: 10px;
            display: block;
        }
        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            margin: 5px 0 15px 0;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        input[type="submit"], .aspNetDisabled{
            background-color: #4CAF50;
            color: white;
            border: none;
            padding: 10px;
            border-radius: 5px;
            cursor: pointer;
            width: 100%;
            font-size: 16px;
        }
        input[type="submit"]:hover {
            background-color: #45a049; 
        }
        a {
            text-decoration: none;
            color: #4CAF50; 
        }
        a:hover {
            text-decoration: underline;
        }

        .google-btn {
            display: inline-flex;
            align-items: center;
            justify-content: center;
            padding: 10px 20px;
            background-color: #ffffff;
            border: 1px solid #dfdfdf;
            border-radius: 4px;
            color: #333333;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .google-btn img {
            width: 30px;
            margin-right: 10px;
        }

        .google-btn:hover {
            background-color: #f1f1f1;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="TextBox1">Email ID</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <label for="TextBox2">Password</label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>

            <asp:Button ID="Button1" runat="server"  Text="Login" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Register.aspx">Create New Account</asp:HyperLink><br><br />
<br />
             <%--<asp:Button class="google-btn"><img src="https://img.icons8.com/color/16/000000/google-logo.png" ID="GoogleLogin"> Signup Using Google</asp:Button>--%>
            <asp:Button class="google-btn" ID="Button2" runat="server" Text="Signup Using Google" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>
