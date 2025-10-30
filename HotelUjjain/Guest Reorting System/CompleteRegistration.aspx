<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompleteRegistration.aspx.cs" Inherits="Guest_Reporting_System.CompleteRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Complete Registration</title>
    <link rel="icon" type="image/png" href="New/assets/images/favicon-16x16.png" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="NewPanel/plugins/fontawesome-free/css/all.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="NewPanel/dist/css/adminlte.min.css" />
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
    <!-- Google Font -->

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <style type="text/css">
        .vbnpage {
            background: #d2d6de;
            background: url(newpanel/images/bg.jpg) no-repeat;
            background-size: cover;
        }

        @media only screen and (min-width: 600px) {
            .login-box-body {
                width: 410px;
            }
        }

        .lblCtrl {
            text-align: center;
            display: block;
        }
    </style>
</head>
<body id="pageBody" class="hold-transition login-page" style="width: 100%;">
    <form id="form1" runat="server">
        <div id="form-login" class="login-box-body" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;">
            <div class="row">
                <img src="New/assets/images/madhya_pradesh_police_logo_1.png" style="width: 50px; padding-top: 15px; padding-left: 15px;" />
                <p style="text-align-last: center;">
                    <img src="New/assets/images/GR_logo.png" style="width: 80px;" />
                </p>
            </div>
            <%-- <p style="padding-top: 15px;">

             <%-- <span style="font-size: 20px; color: #1cb8ea;">Hotel Guest Reporting System</span>
         </p>--%>

            <p class="login-box-msg" style="font-size: 20px; font-family: math;">
                <b>Hotel Guest</b> Reporting System </br>
             Complete Registration
            </p>
            <asp:Label ID="Label2" runat="server" CssClass="lblCtrl"><b>धन्यवाद</b></asp:Label><br />
            <br />
            आपकी जानकारी  हमें प्राप्त हो गयी है |
            <br />
            <br />
            1. हमारी टीम आपकी जानकारी की जांच करेगी।<br />
            <br />
            2. आपकी जानकारी सही पाए जाने पर आपका खाता सक्रिय कर दिया जाएगा।<br />
            <br />
            3. इस प्रक्रिया में 1-2 दिन का समय लग सकता है।<br />
            <br />
            4 .किसी भी प्रकार की पूछताछ के लिए हमसे संपर्क करें:<br />
            <br />
            ईमेल:info@guestreport.in<br />
            फोन: 8989006759
        </div>
        <!-- /.login-box-body -->

        <!-- jQuery 3 -->
        <script src="newpanel/bower_components/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap 3.3.7 -->
        <script src="newpanel/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <!-- iCheck -->
        <script src="newpanel/plugins/iCheck/icheck.min.js"></script>
        <script src="newpanel/comman/js/validation.js" type="text/javascript"></script>
        <script src="newpanel/comman/js/comman.js" type="text/javascript"></script>
        <script src="newpanel/customjs/login.js" type="text/javascript"></script>

        <style>
            .alert {
                margin: 10px 0px !important;
            }
        </style>
    </form>
</body>
</html>
