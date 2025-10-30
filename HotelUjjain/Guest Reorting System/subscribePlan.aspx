<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subscribePlan.aspx.cs" Inherits="Guest_Reporting_System.subscribePlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Subscribe Plan</title>
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
    </style>
    <style>
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

        <div id="frmPlan" class="register-box" runat="server" visible="true" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;">
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
                    <div class="col-md-3 col-sm-3">
                        <%--  <div class="pricingTable">
                            <h3 class="title">Six Month</h3>
                            <div class="price-value">
                                <span class="amount">2000.00</span>
                            </div>
                            <asp:LinkButton ID="btnBasic" runat="server" OnClick="btnBasic_Click" class="pricingTable-signup">Pay Now</asp:LinkButton>
                        </div>--%>
                    </div>
                    <div class="col-md-6 col-sm-6">
                        <div class="pricingTable pink">
                            <h3 class="title">12 Month</h3>
                            <div class="price-value">
                                <span id="lblSubAmount" runat="server" class="amount">3500.00</span>
                            </div>
                            <asp:LinkButton ID="btnStandard" runat="server" OnClick="btnStandard_Click" class="pricingTable-signup">Pay Now</asp:LinkButton>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-3">
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


        <script type="text/javascript">

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


        </script>
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
    </form>
</body>
</html>
