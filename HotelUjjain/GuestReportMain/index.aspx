<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="GuestReportMain.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hotel Login</title>
    <link rel="icon" type="image/png" href="New/assets/images/favicon-16x16.png" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <%--<meta http-equiv="refresh" content="10" />--%>
    <link href="newpanel/bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/bower_components/ionicons/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/dist/css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/custom/customcolor.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="newpanel/Plugins/iCheck/square/blue.css" />
    <link href="newpanel/dist/css/skins/skin-blue.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 9]>
          <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
          <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
        <![endif]-->

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700,300italic,400italic,600italic" />
    <link rel="manifest" href="/manifest.json">
    <meta name="theme-color" content="#2196f3" />
    <style type="text/css">
        .vbnpage {
            background: #d2d6de;
            background: url(newpanel/images/bg.jpg) no-repeat;
            background-size: cover;
        }

        @media only screen and (min-width: 600px) {
            .login-box-body {
                width: 355px;
            }
        }
    </style>
</head>
<body id="pageBody" class="hold-transition login-page" style="height: 100px;">
    <form id="form1" runat="server">
        <div>
            <div id="form-login" class="login-box-body" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;">
                <div class="row">
                    <p style="text-align-last: center;">
                        <img src="New/assets/images/madhya_pradesh_police_logo_1.png" style="width: 50px; padding-top: 15px; " />
                    </p>
                    <p style="text-align-last: center;">
                        <img src="New/assets/images/GR_logo.png" style="width: 80px;" />
                    </p>
                </div>
                <%-- <p style="padding-top: 15px;">

                    <%-- <span style="font-size: 20px; color: #1cb8ea;">Hotel Guest Reporting System</span>
                </p>--%>

                <p class="login-box-msg" style="font-size: 20px; font-family: math;">
                    <b>Hotel Guest</b> Reporting System </br>
                    <%--Hotel Login--%>
                </p>
                <p id="spnLink1" runat="server" style="text-align-last: center; margin-top: 15px;"></p>
                <p id="spnLink2" runat="server" style="text-align-last: center; margin-top: 15px;"></p>
                <p id="spnLink3" runat="server" style="text-align-last: center; margin-top: 15px;"></p>
                <%--                <p class="login-box-msg" style="font-size: 15px; font-family: math;"><b>Hotel Login</p>--%>
                <%--  <div id="spnLink1" runat="server"  class="alert alert-info alert-primary">
                </div>
                <div id="spnLink2" runat="server"  class="alert alert-info alert-primary">                    
</div>
                <div id="spnLink3" runat="server" class="alert alert-info alert-primary">
                </div>--%>


                <%--<div class="form-group has-feedback">
                    <label>Mobile Number</label>
                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control required" placeholder="enter mobile number" Style="border-radius: 10px; height: 40px;"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="fontcolour" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter mobile no." ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="row">
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4">
                    </div>
                    <div class="col-md-4" style="padding-left: 30px;">
                        <asp:LinkButton ID="btnSendOTP" runat="server" OnClick="btnSendOTP_Click" ValidationGroup="save">Send OTP</asp:LinkButton>
                        <asp:LinkButton ID="btnResend" Visible="false" runat="server" OnClick="btnSendOTP_Click" ValidationGroup="save">Re-Send OTP</asp:LinkButton>
                    </div>
                </div>
                <div>
                    <label>OTP</label><br />
                    <asp:TextBox ID="txtOTP" runat="server" pattern="\d*" MaxLength="1" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                    <asp:TextBox ID="txtOTP1" runat="server" pattern="\d*" MaxLength="1" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                    <asp:TextBox ID="txtOTP2" runat="server" pattern="\d*" MaxLength="1" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                    <asp:TextBox ID="txtOTP3" runat="server" pattern="\d*" MaxLength="1" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                    <asp:TextBox ID="txtOTP4" runat="server" pattern="\d*" MaxLength="1" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                    <asp:TextBox ID="txtOTP5" runat="server" pattern="\d*" MaxLength="1" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                </div>
                <div class="form-group has-feedback" style="margin-top: 50px;">
                    <asp:Button ID="btnSubmit" runat="server" Text="LOGIN" Style="border-radius: 10px; background: #1AA7FF; font-size: 15px;" class="btn btn-primary btn-block btn-flat" OnClick="btnSubmit_Click" ValidationGroup="saveData" />
                    <p style="text-align-last: center;margin-top: 15px;"">Our Continue WIth</p>
                    <asp:Button ID="Button1" runat="server"
                        class="btn btn-block btn-flat" Style="border-radius: 10px; background: white; border-color: lightgray; background-image: url('New/GLogo.png'); background-position: center; background-repeat: no-repeat; background-size: 70px;" />
                    <p style="text-align-last: center; margin-top: 15px;">
                        Don’t have an account? <a href="HotelRegistration.aspx"><b style="text-decoration-color: #1AA7FF;font-size: x-large;">New Hotel registration</b></a>
                    </p>
                </div>--%>
                <%-- <div class="col-md-8" style="margin-top: 8px;">
                        
                    </div>
                    <!-- /.col -->
                    <div class="col-md-4">
                        
                    </div>
                    <!-- /.col -->--%>
            </div>
            <!-- /.login-box-body -->
        </div>
        <!-- /.login-box -->

        <!-- jQuery 3 -->
        <script src="newpanel/bower_components/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap 3.3.7 -->
        <script src="newpanel/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <!-- iCheck -->
        <script src="newpanel/plugins/iCheck/icheck.min.js"></script>
        <script src="newpanel/comman/js/validation.js" type="text/javascript"></script>
        <script src="newpanel/comman/js/comman.js" type="text/javascript"></script>
        <script src="newpanel/customjs/login.js" type="text/javascript"></script>
        <script>
            var elts = document.getElementsByClassName('test')
            Array.from(elts).forEach(function (elt) {
                elt.addEventListener("keyup", function (event) {
                    // Number 13 is the "Enter" key on the keyboard
                    if (event.keyCode === 13 || elt.value.length == 1) {
                        // Focus on the next sibling
                        elt.nextElementSibling.focus()
                    }
                    if (event.keyCode === 8) {
                        // Focus on the next sibling
                        elt.previousElementSibling.focus()
                    }
                });
            })
        </script>
        <script>
            if ('serviceWorker' in navigator) {
                navigator.serviceWorker
                    .register('/serviceworker.js')
                    .then(function () { console.log('Service Worker Registered'); });
            }
        </script>
        <style>
            .alert {
                margin: 10px 0px !important;
            }
        </style>
    </form>

</body>
</html>
