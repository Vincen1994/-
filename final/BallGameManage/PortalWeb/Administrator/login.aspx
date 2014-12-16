<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="BallGameManage.Administrator.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>登录</title>
    <link href="../styles/layout.css" rel="stylesheet" type="text/css" />
    <link href="../styles/login.css" rel="stylesheet" type="text/css" />
    <!-- Theme Start -->
    <link href="../themes/blue/styles.css" rel="stylesheet" type="text/css" />
    <!-- Theme End -->
</head>
<body>
    <div id="logincontainer">
        <div id="loginbox">
            <div id="loginheader">
            <div style=" font-size:30px;color:White;">系统后台管理</div>
                
            </div>
            <div id="innerlogin">
                <form id="Form1" action="" runat="server">
                <p>
                    请输入您的用户名:</p>
                <asp:TextBox ID="username" runat="server" CssClass="logininput" Text="admin"></asp:TextBox>
                <p>
                    请输入您的密码:</p>
                <asp:TextBox ID="userpassword" runat="server" CssClass="logininput" TextMode="Password"></asp:TextBox>
                <asp:Button ID="user_submit" runat="server" Text="登录" CssClass="loginbtn" OnClick="user_submit_Click" /><br />
                </form>
            </div>
        </div>
        <img src="../img/login_fade.png" alt="Fade" />
    </div>
</body>
</html>
