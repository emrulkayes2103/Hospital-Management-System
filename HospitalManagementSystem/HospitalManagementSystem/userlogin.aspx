<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="HospitalManagementSystem.userlogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grovier Hospital Limited</title>
    <link rel="icon" href="CSS/allCss/Images/favicon.ico" />
    <link href="Admin/admin.css" rel="stylesheet" />
</head>
<body>
    <header>
        <div id="logo" class="logo">
            <img src="Admin/Images/adminPageLogo.png" height="90" width="90" />
            
        </div>
            <h3 style="padding-left: 40%;">Grovier Hospital Management System</h3>
    </header>
    <div id="loginBody" class="loginBody">
        <div id="loginForm" class="loginForm">
            <form id="logForm" runat="server">
               
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" style=" border-radius:3px; color:#6b787e; height:40px;width:350px;background-color:#373e4a; color:#c5ffca; margin-top:10px; padding:5px; border:0.5em;"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPass" runat="server" placeholder="Password"  style="border-radius:3px;color:#6b787e;height:40px;width:350px;background-color:#373e4a; color:#c5ffca; margin-top:10px; padding:5px; border:0.5em;" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="submit" runat="server" style="border-radius:3px; cursor:pointer; color:#6b787e;height:50px;width:360px;background-color:#303641; color:#c5ffca; margin-top:10px; padding:5px; border:0.001em solid white;" Text="Login" CssClass="button" OnClick="submit_Click"/>
            <br />
                <asp:Label ID="errorMsg" runat="server"></asp:Label>
            </form>
            <br />
            <br />
            <a href="#" style="font-family:'Adobe Arabic';
    color:#cacaca;
    font-size:25px;
    display:block;
    padding-left:120px;
    text-decoration:none;">Forgot Password ?</a>
        </div>
    </div>
</body>
</html>
