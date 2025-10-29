<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="HotalManagment.login" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- start: Meta -->
    <meta charset="utf-8">
    <title>Login</title>
    <meta name="description" content="Bootstrap Metro Dashboard" />
    <meta name="author" content="Dennis Ji" />
    <meta name="keyword" content="Metro, Metro UI, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina" />
    <!-- end: Meta -->
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <!-- google font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700"
        rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link rel="stylesheet" href="assets/plugins/iconic/css/material-design-iconic-font.min.css">
    <!-- bootstrap -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- style -->
    <link rel="stylesheet" href="assets/css/pages/extra_pages.css">
    <!-- favicon -->
    <link rel="shortcut icon" href="assets/img/favicon.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="limiter">
        <div class="container-login100 page-background">
            <div class="wrap-login100">
                <form class="login100-form validate-form">
                <span class="login100-form-logo"><i class="zmdi zmdi-flower"></i></span><span class="login100-form-title p-b-34 p-t-27">
                    Log in </span>
                <div class="wrap-input100 validate-input" data-validate="Enter username">
                    <asp:TextBox ID="txtUsername" runat="server" class="input100" name="username"
                        type="text" placeholder="Username"></asp:TextBox>
                    <span class="focus-input100" data-placeholder="&#xf207;"></span>
                </div>
                <div class="wrap-input100 validate-input" data-validate="Enter password">
                    <asp:TextBox ID="txtpassword" runat="server" class="input100" name="password"
                            type="password" placeholder="Password"></asp:TextBox>
                    <span class="focus-input100" data-placeholder="&#xf191;"></span>
                </div>
                <div class="contact100-form-checkbox">
                    <asp:Label ID="lbError" runat="server" ForeColor="White"></asp:Label>
                </div>
                <div class="container-login100-form-btn">
                 <asp:Button ID="btnLogin" runat="server" Text="Login"  class="login100-form-btn" OnClick="btnLogin_Click" />
                </div>
                <div class="text-center p-t-90">
                    <a class="txt1" href="ForgotPassword.aspx">Forgot Password? </a>
                </div>
                </form>
            </div>
        </div>
    </div>
    <!-- start js include path -->
    <script src="assets/plugins/jquery/jquery.min.js"></script>
    <!-- bootstrap -->
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/js/pages/extra_pages/login.js"></script>
    <!-- end js include path -->
    </form>
</body>
</html>
