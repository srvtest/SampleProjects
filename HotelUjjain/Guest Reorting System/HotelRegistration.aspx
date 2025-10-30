<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HotelRegistration.aspx.cs" Inherits="Guest_Reporting_System.HotelRegistration" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Hotel Register</title>
    <link rel="icon" type="image/png" href="New/assets/images/favicon-16x16.png" />
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
    <style>
        .modalign {
            align-content: center;
        }

        .li-item {
            text-decoration: none;
        }

        body {
            top: 0px !important;
        }

        .goog-logo-link {
            display: none !important;
        }

        .trans-section {
            margin: 100px;
        }

        .skiptranslate iframe {
            display: none !important;
        }

        .goog-te-gadget {
            color: transparent !important;
        }

        @media only screen and (min-width: 600px) {
            .register-box {
                width: 800px;
            }
        }

        @media only screen and (min-width: 600px) {
            .login-box-bodyData {
                width: 410px;
            }
        }

        a {
            text-decoration: none;
        }

        .pricingTable {
            padding: 25px 10px 70px;
            margin: 0 15px;
            text-align: center;
            z-index: 1;
            position: relative
        }

            .pricingTable:after,
            .pricingTable:before {
                content: "";
                position: absolute;
                left: 0
            }

            .pricingTable .price-value .amount {
                display: inline-block;
                font-size: 50px;
                font-weight: 700
            }

            .pricingTable .price-value .month {
                display: block;
                font-size: 20px;
                font-weight: 500;
                line-height: 10px;
                text-transform: uppercase
            }

            .pricingTable:before {
                width: 100%;
                height: 100%;
                background: #fff;
                top: 0;
                z-index: -1;
                -webkit-clip-path: polygon(100% 0, 100% 85%, 50% 100%, 0 85%, 0 0);
                clip-path: polygon(100% 0, 100% 85%, 50% 100%, 0 85%, 0 0)
            }

            .pricingTable:after {
                width: 70px;
                height: 30px;
                background: #1daa72;
                margin: 0 auto;
                top: 70px;
                right: 0;
                -webkit-clip-path: polygon(50% 100%, 0 0, 100% 0);
                clip-path: polygon(50% 100%, 0 0, 100% 0)
            }

            .pricingTable .title {
                padding: 15px 0;
                margin: 0 -25px 30px;
                background: #1daa72;
                font-size: 25px;
                font-weight: 600;
                color: #fff;
                text-transform: uppercase;
                position: relative
            }

                .pricingTable .title:after,
                .pricingTable .title:before {
                    border-top: 15px solid #51836d;
                    border-bottom: 15px solid transparent;
                    position: absolute;
                    bottom: -30px;
                    content: ""
                }

                .pricingTable .title:before {
                    border-left: 15px solid transparent;
                    left: 0
                }

                .pricingTable .title:after {
                    border-right: 15px solid transparent;
                    right: 0
                }

            .pricingTable .price-value {
                margin-bottom: 25px;
                color: #1daa72
            }

            .pricingTable .currency {
                display: inline-block;
                font-size: 30px;
                vertical-align: top;
                margin-top: 8px
            }

        .price-value .amount {
            display: inline-block;
            font-size: 50px;
            font-weight: 700
        }

        .price-value .month {
            display: block;
            font-size: 20px;
            font-weight: 500;
            line-height: 10px;
            text-transform: uppercase
        }

        .pricingTable .pricing-content {
            padding: 0;
            margin: 0 0 25px;
            list-style: none;
            border-top: 1px solid #8f8f8f;
            border-bottom: 1px solid #8f8f8f
        }

            .pricingTable .pricing-content li {
                font-size: 17px;
                color: #8f8f8f;
                line-height: 55px
            }

        .pricingTable .pricingTable-signup {
            display: inline-block;
            padding: 10px 30px;
            background: #1daa72;
            font-size: 18px;
            font-weight: 600;
            color: #fff;
            overflow: hidden;
            position: relative;
            transition: all .7s ease 0s
        }

            .pricingTable .pricingTable-signup:before {
                content: "";
                display: inline-block;
                width: 100%;
                height: 100%;
                background: linear-gradient(to bottom, rgba(255, 255, 255, 0) 0, rgba(255, 255, 255, 1) 50%, rgba(255, 255, 255, 0) 100%);
                position: absolute;
                top: 0;
                left: 0;
                opacity: 0;
                transform: translate(0, 100%);
                transition: all .6s ease-in-out 0s
            }

            .pricingTable .pricingTable-signup:hover:before {
                opacity: 1;
                transform: translate(0, -100%)
            }

        .pricingTable.blue .pricingTable-signup,
        .pricingTable.blue .title,
        .pricingTable.blue:after {
            background: #49b0ca
        }

            .pricingTable.blue .title:after,
            .pricingTable.blue .title:before {
                border-top: 15px solid #407a88
            }

        .pricingTable.blue .price-value {
            color: #49b0ca
        }

        .pricingTable.pink .pricingTable-signup,
        .pricingTable.pink .title,
        .pricingTable.pink:after {
            background: #f06ace
        }

        .pricingTable.pink .price-value {
            color: #f06ace
        }

        .pricingTable.pink .title:after,
        .pricingTable.pink .title:before {
            border-top: 15px solid #773667
        }

        @media only screen and (max-width:990px) {
            .pricingTable {
                margin-bottom: 30px
            }
        }

        .lblCtrl {
            text-align: center;
            display: block;
        }
        /* hide spinner */
        #otp-input input::-webkit-outer-spin-button,
        #otp-input input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        #otp-input input[type=number] {
            -moz-appearance: textfield; /* Firefox */
        }
    </style>
    <script>
        function SetSteps(step) {
            $("#stp1").removeClass("step-success step-active");
            $("#stp2").removeClass("step-success step-active");
            $("#stp3").removeClass("step-success step-active");
            $("#stp4").removeClass("step-success step-active");


            if (step == 1) {
                $("#stp1").addClass("step-active");
            } else if (step == 2) {
                $("#stp1").addClass("step-success");
                $("#stp2").addClass("step-active");

            } else if (step == 3) {
                $("#stp1").addClass("step-success");
                $("#stp2").addClass("step-success");
                $("#stp3").addClass("step-active");

            } else if (step == 4) {
                $("#stp1").addClass("step-success");
                $("#stp2").addClass("step-success");
                $("#stp3").addClass("step-success");
                $("#stp4").addClass("step-active");
            }

        }

    </script>
    <link href="NewPanel/bootstrap-steps.min.css" rel="stylesheet" />
</head>
<body id="pageBody" class="hold-transition login-page" style="width: 100%;">
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdnHotelNewId" runat="server" />
        <asp:HiddenField ID="hdnHotelName" runat="server" />
        <asp:HiddenField ID="hdnRMobileNo" runat="server" />
        <asp:HiddenField ID="hdnNoRoom" runat="server" />
        <p>
            <ul class="steps">
                <li id="stp1" class="step step-success">
                    <div class="step-content">
                        <span class="step-circle"></span>
                        <span class="step-text">Step 1</span>
                    </div>
                </li>
                <li id="stp2" class="step step-active">
                    <div class="step-content">
                        <span class="step-circle"></span>
                        <span class="step-text">Step 2</span>
                    </div>
                </li>
                <li id="stp3" class="step">
                    <div class="step-content">
                        <span class="step-circle"></span>
                        <span class="step-text">Step 3</span>
                    </div>
                </li>
                <li id="stp4" class="step">
                    <div class="step-content">
                        <span class="step-circle"></span>
                        <span class="step-text">Step 4</span>
                    </div>
                </li>
            </ul>
        </p>
        <div id="formloginMobile" class="login-box-body login-box-bodyData" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;" runat="server">
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
                    Property Registration Page
            </p>
            <p class="box-header">
                <asp:Label ID="Label2" runat="server" CssClass="lblCtrl"><b>|| कृपया ध्यान दें ||</b></asp:Label></br>
    <asp:Label ID="Label1" runat="server">आप इस नंबर को बाद में बदल नहीं पाएंगे। हमारे पोर्टल से सभी संदेश इसी नंबर पर भेजे जाएंगे।</asp:Label>
            </p>
            <%--                <p class="login-box-msg" style="font-size: 15px; font-family: math;"><b>Hotel Login</p>--%>
            <div id="spnmsgMob" runat="server" visible="false" class="alert alert-danger alert-dismissable">
            </div>
            <div id="spnmsgOtp" runat="server" visible="false" class="alert alert-danger alert-dismissable">
            </div>
            <div id="spnmsgSuccessMob" runat="server" class="alert alert-info alert-primary" visible="false">
            </div>
            <div class="form-group has-feedback">
                <label>Enter Primary Mobile Number</label>
                <asp:TextBox ID="txtVMobileNo" runat="server" class="form-control required" placeholder="संपर्क नंबर दर्ज करें।" Style="border-radius: 10px; height: 40px;"></asp:TextBox>
                <%--  <span class="glyphicon glyphicon-phone form-control-feedback"></span>--%>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="fontcolour" runat="server" ControlToValidate="txtVMobileNo" ErrorMessage="कृपया संपर्क नंबर दर्ज करें।" ValidationGroup="SendOTP" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtVMobileNo" ErrorMessage="कृपया वैध संपर्क नंबर दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[0-9 ]{10}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:LinkButton ID="btnSendOTP" runat="server" Style="position: absolute; right: 13px; top: 36px;" OnClick="btnSendOTP_Click" ValidationGroup="SendOTP">Send OTP</asp:LinkButton>
                <asp:LinkButton ID="btnResend" Visible="false" runat="server" Style="position: absolute; right: 13px; top: 36px;" OnClick="btnSendOTP_Click" ValidationGroup="SendOTP">Re-Send OTP</asp:LinkButton>
            </div>
            <%-- <div class="row">
                <div class="col-md-4">
                </div>
                <div class="col-md-4">
                </div>
                <div class="col-md-4" style="padding-left: 30px;">
                   
                </div>
            </div>--%>
            <div id="otp-input">
                <label>OTP</label><br />
                <asp:TextBox ID="txtOTP" runat="server" pattern="\d*" MaxLength="1" type="number" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                <asp:TextBox ID="txtOTP1" runat="server" pattern="\d*" MaxLength="1" type="number" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                <asp:TextBox ID="txtOTP2" runat="server" pattern="\d*" MaxLength="1" type="number" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                <asp:TextBox ID="txtOTP3" runat="server" pattern="\d*" MaxLength="1" type="number" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                <asp:TextBox ID="txtOTP4" runat="server" pattern="\d*" MaxLength="1" type="number" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                <asp:TextBox ID="txtOTP5" runat="server" pattern="\d*" MaxLength="1" type="number" class="form-control required test" Style="border-radius: 10px; height: 40px; width: 50px; display: block; float: left; margin-right: 2px; text-align: center; font-size: large;"></asp:TextBox>
                <%-- <span class="glyphicon glyphicon-lock form-control-feedback"></span>--%>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="txtOTP" ErrorMessage="Please enter OTP" ValidationGroup="saveData" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
            </div>
            <div class="form-group has-feedback" style="margin-top: 50px;">
                <asp:Button ID="btnSubmit" runat="server" Text="Start Registration" Style="border-radius: 10px; background: #1AA7FF; font-size: 15px;" class="btn btn-primary btn-block btn-flat" OnClick="btnSubmit_Click" ValidationGroup="saveData" />
            </div>
            <%-- <div class="col-md-8" style="margin-top: 8px;">
                        
                    </div>
                    <!-- /.col -->
                    <div class="col-md-4">
                        
                    </div>
                    <!-- /.col -->--%>
        </div>

        <div class="register-box" id="frmRegData" runat="server" visible="false" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;">
            <div id="formlogin" class="login-box-body SecGuest" style="margin-top: 10px; padding: 0px 20px 20px;" runat="server">
                <p class="login-box-msg" style="padding-top: 10px;">
                    <span style="font-size: 20px; color: #1cb8ea;">Hotel Guest Reporting System</span>
                </p>
                <p class="login-box-msg" style="font-weight: bold; font-size: 25px;">Property Registration Form</p>
                <div id="spnmsg" runat="server" visible="false" class="alert alert-danger alert-dismissable">
                </div>
                <div id="spnmsgSuccess" runat="server" class="alert alert-info alert-primary" visible="false">
                </div>
                <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
                <div class="row">
                    <div class="col-md-4 form-group has-feedback">
                        <label>होटल  का नाम <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtHotelName" runat="server" class="form-control required" placeholder="Hotel name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="txtHotelName" ErrorMessage="कृपया होटल का नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtHotelName" ErrorMessage="कृपया होटल का नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[A-Za-z0-9 ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                        <%--  <asp:CustomValidator ID="CustomValidator3" runat="server"
                            ForeColor="Red"
                            ControlToValidate="txtHotelName"
                            ClientValidationFunction="checkValidationRpt"></asp:CustomValidator>--%>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>होटल  का पता <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtAddress" runat="server" class="form-control required" placeholder="Hotel address"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" runat="server" ControlToValidate="txtAddress" ErrorMessage="कृपया पता दर्ज करें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtAddress" ErrorMessage="कृपया पता दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^.{1,100}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>रजिस्टर मोबाइल नंबर <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtMobileno" runat="server" class="form-control form-control-lg border-left-0" placeholder="Mobile number" Enabled="false"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileno" ForeColor="Red"
                            ErrorMessage="अमान्य मोबाइल नंबर। कृपया केवल अंग्रेजी अक्षर डालें।"
                            ValidationExpression="^([0-9 ]{10})$">
                        </asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="fontcolour" runat="server" ControlToValidate="txtMobileno" ErrorMessage="कृपया मोबाइल नंबर दर्ज करें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group has-feedback">
                        <label>होटल मालिक का नाम <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtContactPerson" runat="server" class="form-control form-control-lg border-left-0" placeholder="Contact Person"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="fontcolour" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="कृपया संपर्क व्यक्ति दर्ज करें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="कृपया संपर्क व्यक्ति दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[A-Za-z0-9 ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>होटल मालिक का मोबाइल नंबर <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtContactPersonMobile" runat="server" class="form-control form-control-lg border-left-0" placeholder="Contact Person"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="fontcolour" runat="server" ControlToValidate="txtContactPersonMobile" ErrorMessage="कृपया संपर्क नंबर दर्ज करें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtContactPersonMobile" ForeColor="Red"
                            ErrorMessage="अमान्य मोबाइल नंबर। कृपया केवल अंग्रेजी अक्षर डालें।"
                            ValidationExpression="^([0-9 ]{10})$">
                        </asp:RegularExpressionValidator>

                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>होटल वेबसाइट</label>
                        <asp:TextBox ID="txtWebsite" runat="server" class="form-control form-control-lg border-left-0" placeholder="Website"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="txtWebsite" ErrorMessage="कृपया वेबसाइट दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^((https?|ftp|smtp):\/\/)?(www.)?[a-z0-9]+(\.[a-z]{2,}){1,3}(#?\/?[a-zA-Z0-9#]+)*\/?(\?[a-zA-Z0-9-_]+=[a-zA-Z0-9-%]+&?)?$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group has-feedback">
                        <label>होटल मेल आईडी <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-lg border-left-0" placeholder="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="fontcolour" runat="server" ControlToValidate="txtEmail" ErrorMessage="कृपया ईमेल दर्ज करें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtEmail" ErrorMessage="कृपया ईमेल दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>

                    <div class="col-md-4 form-group has-feedback">
                        <label>प्रॉपर्टी प्रकार <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlPropertyType" runat="server" class="form-control" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="fontcolour" runat="server" ControlToValidate="ddlPropertyType" ErrorMessage="कृपया प्रॉपर्टी टाइप चुनें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>कमरों की कुल संख्या <span class="text-danger">*</span></label>
                        <asp:TextBox ID="txtNoOfRoom" runat="server" class="form-control form-control-lg border-left-0" placeholder="" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" CssClass="fontcolour" runat="server" ControlToValidate="txtNoOfRoom" ErrorMessage="कृपया कमरों की संख्या दर्ज करें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="txtNoOfRoom" ErrorMessage="कृपया कमरों की संख्या दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[0-9 ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group has-feedback">
                        <label>राज्य <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlStateId" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateId_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="ddlStateId" ErrorMessage="कृपया राज्य चुनें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>ज़िला <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlDistrictId" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictId_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="ddlDistrictId" ErrorMessage="कृपया जिला चुनें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>शहर <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlCityId" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCityId_SelectedIndexChanged"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="ddlCityId" ErrorMessage="कृपया शहर चुनें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-4 form-group has-feedback">
                        <label>थाना <span class="text-danger">*</span></label>
                        <asp:DropDownList ID="ddlPoliceStation" runat="server" class="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" runat="server" ControlToValidate="ddlPoliceStation" ErrorMessage="कृपया पुलिस स्टेशन चुनें।" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="row">
                    <div class="col-md-6 form-group has-feedback">
                        <label>होटल का गुमस्ता अपलोड करे <span class="text-danger">*</span></label>
                        <asp:FileUpload ID="FileGumasta" runat="server" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."/>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" CssClass="fontcolour" runat="server" ControlToValidate="FileGumasta" ErrorMessage="कृपया दस्तावेज़ चुनें। केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="cvvalidate" runat="server"
                            ToolTip="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ForeColor="Red"
                            ErrorMessage="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."
                            ControlToValidate="FileGumasta"
                            ClientValidationFunction="checksize"></asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileGumasta" ForeColor="Red"
                            ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।"
                            ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-6 form-group has-feedback">
                        <label>मालिक का फ्रंटसाइड आधार कार्ड अपलोड करें<span class="text-danger">*</span></label>
                        <asp:FileUpload ID="FileAdhar" runat="server" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="fontcolour" runat="server" ControlToValidate="FileAdhar" ErrorMessage="आधार कार्ड का Front अपलोड करें। केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator1" runat="server"
                            ToolTip="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ForeColor="Red"
                            ErrorMessage="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."
                            ControlToValidate="FileAdhar"
                            ClientValidationFunction="checksize1"></asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileAdhar" ForeColor="Red"
                            ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।"
                            ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                        </asp:RegularExpressionValidator>
                    </div>
                    <div class="col-md-6 form-group has-feedback">
                        <label>मालिक का बैकसाइड आधार कार्ड अपलोड करें<span class="text-danger">*</span></label>
                        <asp:FileUpload ID="FileAdharBack" runat="server" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="fontcolour" runat="server" ControlToValidate="FileAdharBack" ErrorMessage="आधार कार्ड का Back अपलोड करें। केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CustomValidator ID="CustomValidator2" runat="server"
                            ToolTip="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ForeColor="Red"
                            ErrorMessage="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."
                            ControlToValidate="FileAdharBack"
                            ClientValidationFunction="checksize2"></asp:CustomValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="FileAdharBack" ForeColor="Red"
                            ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।"
                            ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                        </asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 form-group has-feedback">
                        <asp:Label ID="lblStSpam" runat="server">दोनों नंबरों का योग दर्ज़  करें।</asp:Label><br />
                        <b>
                            <asp:Label ID="lblStopSpam" runat="server"></asp:Label></b>
                        <asp:TextBox ID="txtStopSpam" runat="server" class="form-control form-control-lg border-left-0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ErrorMessage="कृपया अपना उत्तर दर्ज करें।"
                            ValidationGroup="save" ControlToValidate="txtStopSpam" runat="server" Display="Dynamic" ForeColor="Red" />
                        <asp:CompareValidator ID="CompareValidator1" ErrorMessage="Invalid text format."
                            ValidationGroup="save" ControlToValidate="txtStopSpam" runat="server"
                            Operator="DataTypeCheck" Type="Integer" Display="Dynamic" ForeColor="Red" />
                        <asp:CompareValidator ID="CompareValidator2" ErrorMessage="Invalid ."
                            ValidationGroup="save" ControlToValidate="txtStopSpam" runat="server"
                            Operator="DataTypeCheck" Type="Integer" Display="Dynamic" ForeColor="Red" />
                    </div>
                </div>
                <div class="mb-4">
                    <div class="form-check">
                        <label class="form-check-label text-muted">
                            <input type="checkbox" class="form-check-input" required />
                            <a href="TermsConditionsMain.aspx" class="text-primary">I agree to all Terms & Conditions</a>
                        </label>
                    </div>
                </div>
                <div class="mt-3" style="padding-bottom: 5px;">
                    <asp:Button ID="btnRegistration" runat="server" Text="Save & Next" class="btn btn-primary btn-block btn-flat" OnClientClick="return Validate()" OnClick="btnRegistration_Click" ValidationGroup="save" />
                </div>
                <div class="text-center mt-4 font-weight-light">
                    Already have an account? <a href="HotelLogin.aspx" class="text-primary">Login</a>
                </div>
            </div>
        </div>

        <div class="register-box" id="frmCategory" runat="server" visible="false" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;">
            <div id="Div1" class="login-box-body" style="margin-top: 10px; padding: 0px 20px 20px;" runat="server">
                <p class="login-box-msg" style="padding-top: 10px;">
                    <span style="font-size: 20px; color: #1cb8ea;">Hotel Guest Reporting System</span><br />
                    <span style="font-size: 16px; color: #1cb8ea;">होटल की रूम कैटेगरी और रेट प्लान बनाए</span>
                </p>
                <p class="box-header">
                    <asp:Label ID="Label3" runat="server" CssClass="lblCtrl"><b>|| कृपया ध्यान दें ||</b></asp:Label></br></br>
                    <asp:Label ID="Label4" runat="server"> एक बार रूम कैटेगरी और रेट डालने के बाद आप इसे अपडेट नहीं कर पाएंगे।</asp:Label>
                </p>
                <div class="row">
                    <!--Basic Form starts-->
                    <div class="col-md-12 grid-margin stretch-card mx-auto">
                        <div class="box box-primary">
                            <div class="card-body">
                                <div class="box-body">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail" class="form-control-label">कमरे की श्रेणी</label>
                                                <asp:TextBox ID="txtRoomCategory" runat="server" CssClass="form-control" placeholder="कमरे की श्रेणी"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" CssClass="fontcolour" runat="server" ControlToValidate="txtRoomCategory" ErrorMessage="कृपया कमरे की श्रेणी दर्ज करें" ValidationGroup="Catsave" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="hdnidHotelRoomCategory" runat="server" Value='' />
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label for="exampleInputEmail" class="form-control-label">मूल्य</label>
                                                <asp:TextBox ID="txtRoomPrice" runat="server" CssClass="form-control" placeholder="मूल्य" TextMode="Number"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" CssClass="fontcolour" runat="server" ControlToValidate="txtRoomPrice" ErrorMessage="कृपया कमरे का मूल्य दर्ज करें" ValidationGroup="Catsave" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <div style="float: right">
                                                    <asp:Button ID="btnSaveCategory" runat="server" Text="Add Room" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClick="btnSaveCategory_Click" ValidationGroup="Catsave" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="box-body">
                                    <asp:Repeater ID="rptCategory" runat="server">
                                        <HeaderTemplate>
                                            <table id="example3" class="table table-bordered table-striped" style="width: 100%">
                                                <thead>
                                                    <tr>
                                                        <th>S. No.</th>
                                                        <th>कमरे की श्रेणी</th>
                                                        <th>मूल्य</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex + 1 %>
                                                    <asp:HiddenField ID="hdnidHotelRoomCategory" runat="server" Value='<%#Eval("idHotelRoomCategory")%>' />
                                                    <asp:HiddenField ID="hdnCategoryName" runat="server" Value='<%#Eval("CategoryName")%>' />
                                                    <asp:HiddenField ID="hdniPrice" runat="server" Value='<%#Eval("iPrice")%>' />
                                                </td>
                                                <td><%#Eval("CategoryName")%></td>
                                                <td><%#Eval("iPrice")%></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mt-12" style="padding-bottom: 5px;">
                    <center>
                        <asp:Button ID="btnSkip" runat="server" Text="Skip" CssClass="btn btn-primary btn-flat" OnClick="btnSkip_Click" />
                        <asp:Button ID="btnInsertCategory" runat="server" Text="Next" CssClass="btn btn-primary btn-flat" OnClick="btnInsertCategory_Click" ValidationGroup="save" />
                    </center>
                </div>
            </div>
        </div>

        <div id="frmPlan" class="register-box" runat="server" visible="false" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;">
            <div id="Div3" class="login-box-body" style="margin-top: 10px; padding: 0px 20px 20px;" runat="server">
                <p class="login-box-msg" style="padding-top: 10px;">
                    <span style="font-size: 20px; color: #1cb8ea;">Hotel Guest Reporting System</span>
                    <br />
                    <br />
                    <span style="font-size: 20px; color: #1cb8ea;">कृपया अपना सब्सक्रिप्शन चुनें</span>
                </p>
            </div>
            <div>
                <div class="row">
                    <div class="col-md-4 form-group has-feedback">
                        <label>होटल  का नाम -</label>
                        <asp:Label ID="lblHotelName" runat="server"></asp:Label>
                        <%--  <asp:Label ID="lblHotelName" runat="server" CssClass="form-control required" Enabled="false" placeholder="Hotel name"></asp:Label>--%>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>रजिस्टर मोबाइल नंबर -</label>
                        <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                        <%--<asp:Label ID="lblMobileNo" runat="server" CssClass="form-control required" Enabled="false" placeholder="Hotel name"></asp:Label>--%>
                    </div>
                    <div class="col-md-4 form-group has-feedback">
                        <label>कमरों की कुल संख्या -</label>
                        <asp:Label ID="lblNoRoom" runat="server"></asp:Label>
                        <%--<asp:Label ID="lblNoRoom" runat="server" CssClass="form-control required" Enabled="false" placeholder="Hotel name"></asp:Label>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 col-sm-6">
                        <div class="pricingTable">
                            <h3 class="title">7 days free trail</h3>
                            <div class="price-value">
                                <span class="amount">0</span>
                            </div>
                            <asp:LinkButton ID="btnBasic" runat="server" OnClick="btnBasic_Click" class="pricingTable-signup">Activate Now</asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <div class="pricingTable pink">
                            <h3 class="title">12 Month</h3>
                            <div class="price-value">
                                <span class="amount" id="lblSubAmount" runat="server">3500.00</span>
                            </div>
                            <asp:LinkButton ID="btnStandard" runat="server" OnClick="btnStandard_Click" class="pricingTable-signup">Pay Now</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- jQuery 3 -->
        <script src="newpanel/bower_components/jquery/dist/jquery.min.js"></script>
        <!-- Bootstrap 3.3.7 -->
        <script src="newpanel/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
        <!-- iCheck -->
        <script src="newpanel/plugins/iCheck/icheck.min.js"></script>
        <script src="newpanel/comman/js/validation.js" type="text/javascript"></script>
        <script src="newpanel/comman/js/comman.js" type="text/javascript"></script>
        <script src="newpanel/customjs/login.js" type="text/javascript"></script>
        <script></script>
        <style>
            .alert {
                margin: 10px 0px !important;
            }
        </style>

        <div class="modal fade modalign" id="saveCompleteModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <h5 class="modal-title" id="saveModalLabel" style="text-align: center;">Hotel Register </h5>
                        <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i>धन्यवाद, आपकी जानकारी सफलतापूर्वक सुरक्षित कर ली गई है। अब आप अगले चरण में अपनी रूम कैटेगरी जोड़ सकते हैं।
                    </div>
                    <div class="modal-footer" style="text-align: center;">
                        <%--<asp:Button ID="btnAddGuest" runat="server" Text="लॉगिन" class="btn btn-info me-2" OnClick="btnAddGuest_Click" />--%>
                        <button type="button" class="btn btn-primary me-2" data-dismiss="modal">ठीक है</button>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade modalign" id="saveCompleteError" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <h5 class="modal-title" id="saveModalLabelError" style="text-align: center;">Hotel Register </h5>
                        <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i><span id="idError" runat="server"></span>
                    </div>
                    <div class="modal-footer" style="text-align: center;">
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade modalign" id="saveComplete" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <h5 class="modal-title" id="saveModal" style="text-align: center;">Hotel Register </h5>
                        <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i>आपका आज से 7 दिनों का ट्रायल शुरू हो गया है। 
                        अब आप लॉगिन करके चेक-इन रिपोर्ट बना सकते हैं। 
                        धन्यवाद। 
                    </div>
                    <div class="modal-footer" style="text-align: center;">
                        <%--<asp:Button ID="btnAddGuest" runat="server" Text="लॉगिन" class="btn btn-info me-2" OnClick="btnAddGuest_Click" />--%>
                        <a href="HotelLogin.aspx" class="btn btn-primary me-2">ठीक है</a>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            $("#txtNoOfRoom").on("keypress keyup", function () {
                if ($(this).val() == '0') {
                    $(this).val('');
                }
            });
            function SaveGuestData() {
                if (Page_ClientValidate()) {
                    $('#saveCompleteModal').modal('show');
                    return false;
                }
                return true;
            }
            function SaveGuestError() {
                if (Page_ClientValidate()) {
                    $('#saveCompleteError').modal('show');
                    return false;
                }
                return true;
            }
            function SaveGuestSub() {
                $('#saveComplete').modal('show');
            }
            function checksize(source, arguments) {
                arguments.IsValid = false;
                var size = document.getElementById("<%=FileGumasta.ClientID%>").files[0].size;
                if (size > 2097152) {
                    arguments.IsValid = false;
                    return false;
                }
                else {
                    arguments.IsValid = true;
                    return true;
                }
            }
            function checksize1(source, arguments) {
                arguments.IsValid = false;
                var size = document.getElementById("<%=FileAdhar.ClientID%>").files[0].size;
                if (size > 2097152) {
                    arguments.IsValid = false;
                    return false;
                }
                else {
                    arguments.IsValid = true;
                    return true;
                }
            }
            function checksize2(source, arguments) {
                arguments.IsValid = false;
                var size = document.getElementById("<%=FileAdharBack.ClientID%>").files[0].size;
                if (size > 2097152) {
                    arguments.IsValid = false;
                    return false;
                }
                else {
                    arguments.IsValid = true;
                    return true;
                }
            }
            //var elts = document.getElementsByClassName('test')
            //Array.from(elts).forEach(function (elt) {
            //    elt.addEventListener("keyup", function (event) {
            //        // Number 13 is the "Enter" key on the keyboard
            //        if (event.keyCode === 13 || elt.value.length == 1) {
            //            // Focus on the next sibling
            //            elt.nextElementSibling.focus()
            //        }
            //        if (event.keyCode === 8) {
            //            // Focus on the next sibling
            //            elt.previousElementSibling.focus()
            //        }
            //    });
            //})
            setTimeout(function () {
                $("#spnmsgMob").fadeTo(2000, 500).slideUp(500, function () {
                    $("#spnmsgMob").remove();
                    //  $("#spnmsgOtp")..prop("disabled", true);
                    //  $("#spnmsgSuccessMob").prop("disabled", true);
                });
            }, 5000);//5000=5 seconds
            setTimeout(function () {
                $("#spnmsgOtp").fadeTo(2000, 500).slideUp(500, function () {
                    // $("#spnmsgMob").prop("disabled", true);
                    $("#spnmsgOtp").remove();
                    $("#spnmsgSuccessMob").prop("disabled", true);
                });
            }, 5000);//5000=5 seconds
            setTimeout(function () {
                $("#spnmsgSuccessMob").fadeTo(2000, 500).slideUp(500, function () {
                    //  $("#spnmsgMob").prop("disabled", true);
                    //  $("#spnmsgOtp").prop("disabled", true);
                    $("#spnmsgSuccessMob").remove();
                });
            }, 10000);//10000=10 seconds

            // otp script below
            (function () {
                const inputs = document.querySelectorAll("#otp-input input");

                for (let i = 0; i < inputs.length; i++) {
                    const input = inputs[i];

                    input.addEventListener("input", function () {
                        // handling normal input
                        if (input.value.length == 1 && i + 1 < inputs.length) {
                            inputs[i + 1].focus();
                        }

                        // if a value is pasted, put each character to each of the next input
                        if (input.value.length > 1) {
                            // sanitise input
                            if (isNaN(input.value)) {
                                input.value = "";
                                updateInput();
                                return;
                            }

                            // split characters to array
                            const chars = input.value.split('');

                            for (let pos = 0; pos < chars.length; pos++) {
                                // if length exceeded the number of inputs, stop
                                if (pos + i >= inputs.length) break;

                                // paste value
                                let targetInput = inputs[pos + i];
                                targetInput.value = chars[pos];
                            }

                            // focus the input next to the last pasted character
                            let focus_index = Math.min(inputs.length - 1, i + chars.length);
                            inputs[focus_index].focus();
                        }
                        updateInput();
                    });

                    input.addEventListener("keydown", function (e) {
                        // backspace button
                        if (e.keyCode == 8 && input.value == '' && i != 0) {
                            // shift next values towards the left
                            for (let pos = i; pos < inputs.length - 1; pos++) {
                                inputs[pos].value = inputs[pos + 1].value;
                            }

                            // clear previous box and focus on it
                            inputs[i - 1].value = '';
                            inputs[i - 1].focus();
                            updateInput();
                            return;
                        }

                        // delete button
                        if (e.keyCode == 46 && i != inputs.length - 1) {
                            // shift next values towards the left
                            for (let pos = i; pos < inputs.length - 1; pos++) {
                                inputs[pos].value = inputs[pos + 1].value;
                            }

                            // clear the last box
                            inputs[inputs.length - 1].value = '';
                            input.select();
                            e.preventDefault();
                            updateInput();
                            return;
                        }

                        // left button
                        if (e.keyCode == 37) {
                            if (i > 0) {
                                e.preventDefault();
                                inputs[i - 1].focus();
                                inputs[i - 1].select();
                            }
                            return;
                        }

                        // right button
                        if (e.keyCode == 39) {
                            if (i + 1 < inputs.length) {
                                e.preventDefault();
                                inputs[i + 1].focus();
                                inputs[i + 1].select();
                            }
                            return;
                        }
                    });
                }

                function updateInput() {
                    let inputValue = Array.from(inputs).reduce(function (otp, input) {
                        otp += (input.value.length) ? input.value : ' ';
                        return otp;
                    }, "");
                    document.querySelector("input[name=otp]").value = inputValue;
                }
            })();

            //$(function () {
            //    $("#txtHotelName").keypress(function (e) {
            //        alert("hello");
            //        var keyCode = e.keyCode || e.which;

            //        $("#spnmsg").html("");

            //        //Regex for Valid Characters i.e. Alphabets and Numbers.
            //        var regex = /^[A-Za-z0-9]+$/;

            //        //Validate TextBox value against the Regex.
            //        var isValid = regex.test(String.fromCharCode(keyCode));
            //        if (!isValid) {
            //            $("#spnmsg").html("Only Alphabets and Numbers allowed.");
            //        }

            //        return isValid;
            //    });
            //});
            //$(document).ready(function () {
            //    $("#btnRegistration").click(function () {
            //        var fn = $("#txtHotelName").val();
            //        var regex = /^[0-9a-zA-Z\_]+$/
            //        alert(regex.test(fn));
            //    });
            //});
            //function checkValidationRpt(source, arguments) {
            //    arguments.IsValid = false;
            //    var valid = $(source).closest('.SecGuest').children('.col-md-4').find('input').val();
            //    var vaLUE = $(source).closest('.form-group').children('input').val();
            //    $(valid).bind('keyup blur', function () {
            //        $(this).val($(this).val().replace(/[^A-Za-z0-9]/g, ''))
            //        arguments.IsValid = true;
            //        return true;
            //    });

            //    arguments.IsValid = false;
            //    return false;
            //}
            //function Validate() {
            //    //myFunction();
            //    //var valid = $(source).closest('.Cat').children('.col-md-4:first-child').find('input').val();
            //    //console.log(valid);
            //    //Reference the Table containing Group of CheckBoxes.
            //    var table = document.getElementById("formlogin");
            //    var checkBoxes = $(table).find('input[type="input"]')
            //    $(checkBoxes).bind('keyup blur', function () {
            //        $(this).val($(this).val().replace(/[^A-Za-z0-9]/g, ''))
            //    });

            //    //Reference the Group of CheckBoxes.
            //    //var checkBoxes = table.getElementsByTagName("input[type='checkbox']");
            //    //Set the Valid Flag to False initially.
            //    //var isValid = false;

            //    ////Loop and verify whether at-least one CheckBox is checked.
            //    //for (var i = 0; i < checkBoxes.length; i++) {
            //    //    if (checkBoxes[i].checked) {
            //    //        isValid = true;
            //    //        break;
            //    //    }
            //    //}

            //    //Display error message if no CheckBox is checked.
            //    // document.getElementById("spnError").style.display = isValid ? "none" : "block";
            //    return isValid;
            //}
            //var btns = $('#txtHotelName,#txtAddress,#txtContactPerson');
            //$(btns).bind('keyup blur', function () {
            //    $(this).val($(this).val().replace(/[^A-Za-z0-9]/g, ''))
            //});
            //var btns1 = $('#txtMobileno,#txtContactPersonMobile,#txtNoOfRoom');
            //$(btns1).bind('keyup blur', function () {
            //    $(this).val($(this).val().replace(/[^0-9]/g, ''))
            //});
            //var btns2 = $('#txtEmail');
            //$(btns2).bind('keyup blur', function () {
            //    $(this).val($(this).val().replace(/[^[A-Za-z0-9\._%+\-]+@[A-Za-z0-9\.\-]+\.[A-Za-z]{2,}]/g, ''))
            //});

        </script>
    </form>
</body>
</html>
