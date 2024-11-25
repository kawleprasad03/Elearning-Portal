<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ElearningPortal.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 20px;
        }
        .container {
            max-width: 400px;
            margin: auto;
            padding: 20px;
            background: white;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h2 {
            text-align: center;
            color: #333;
        }
        label {
            margin-top: 10px;
            display: block;
        }
        input[type="text"], input[type="password"], input[type="file"] {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        input[type="button"], input[type="submit"] {
            width: 100%;
            padding: 10px;
            margin-top: 10px;
            background-color: #28a745;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
        input[type="button"]:hover, input[type="submit"]:hover {
            background-color: #218838;
        }
        .hidden {
            display: none;
        }
    </style>
    <script type="text/javascript">
        function showFields() {
            document.getElementById('FileUpload1').classList.remove('hidden');
            document.getElementById('TextBox3').classList.remove('hidden');
            document.getElementById('TextBox4').classList.remove('hidden');
            document.getElementById('Button2').classList.remove('hidden');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Sign Up</h2>
            <label for="TextBox1">Email:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="input"></asp:TextBox>

            <asp:Button ID="ButtonSendOtp" runat="server" Text="Send OTP" OnClick="ButtonSendOtp_Click" CssClass="input" />

            <label for="TextBox2">OTP:</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="input"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Verify OTP" OnClientClick="showFields(); return false;" OnClick="Button1_Click" />
            </div>
           <%-- <div id="profileFields" class="hidden">--%>
            <div class="container" id="profileFields" runat="server" visible="false">


                <label for="FileUpload1">Username:</label>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="input"></asp:TextBox>
    <label for="FileUpload1">Profile Photo:</label>
    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="input" />

    <label for="TextBox3">Password:</label>
    <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>

    <label for="TextBox4">Confirm Password:</label>
    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" CssClass="input"></asp:TextBox>

    <asp:Button ID="Button2" runat="server" Text="Sign In" CssClass="input " OnClick="Button2_Click" />
</div>
       
    </form>
</body>
</html>

