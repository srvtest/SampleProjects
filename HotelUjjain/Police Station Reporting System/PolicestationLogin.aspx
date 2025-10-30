<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicestationLogin.aspx.cs" Inherits="Police_Station_Reporting_System.PolicestationLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Police Station Login</title>
    <link rel="icon" type="image/png" href="New/favicon-32x32.png" />
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <%-- <meta http-equiv="refresh" content="10" />--%>
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
</head>
<body id="pageBody" class="hold-transition login-page" style="height: 100px;">
    <form id="form1" runat="server">
        <div>
            <div id="form-login" class="login-box-body" style="border: solid; border-color: lightgray; padding: 0px 18px 20px; border-radius: 10px; margin: 25px auto;">
                <div class="row">
                    <img src="New/madhya_pradesh_police_logo_1.png" style="width: 50px; padding-top: 15px; padding-left: 15px;" />
                    <p style="text-align-last: center;">
                        <img src="New/GR_logo.png" style="width: 80px;" />
                    </p>
                </div>
                <p class="login-box-msg" style="font-size: 20px; font-family: math;"><b>Hotel Guest</b> Reporting System </br>
                    Police Station Login
                </p>
                <div id="spnmsg" runat="server" visible="false" class="alert alert-danger alert-dismissable">
                </div>
                <div id="spnmsgSuccess" runat="server" class="alert alert-info alert-primary" visible="false">
                </div>
                <div class="form-group has-feedback">
                    <label>Mobile Number</label>
                    <asp:TextBox ID="txtMobileNo" runat="server" MaxLength="10" class="form-control required" placeholder="enter mobile number" Style="border-radius: 10px; height: 40px;"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="fontcolour" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Please enter mobile no." ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:LinkButton ID="btnSendOTP" runat="server" style="position: absolute; right: 13px; top: 36px;" OnClick="btnSendOTP_Click" ValidationGroup="save">Send OTP</asp:LinkButton>
                    <asp:LinkButton ID="btnResend" Visible="false" runat="server" style="position: absolute; right: 13px; top: 36px;" OnClick="btnSendOTP_Click" ValidationGroup="save">Re-Send OTP</asp:LinkButton>
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
                    <asp:Button ID="btnSubmit" runat="server" Text="LOGIN" Style="border-radius: 10px; background: #1AA7FF; font-size: 15px;" class="btn btn-primary btn-block btn-flat" OnClick="btnSubmit_Click" ValidationGroup="saveData" />
                   <%-- <p style="text-align-last: center;margin-top: 15px;"">Our Continue WIth</p>
                    <asp:Button ID="Button1" runat="server"
                        class="btn btn-block btn-flat" Style="border-radius: 10px; background: white; border-color: lightgray; background-image: url('New/GLogo.png'); background-position: center; background-repeat: no-repeat; background-size: 70px;" />--%>
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
        <script>
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
            setTimeout(function () {
                $("#spnmsg").fadeTo(2000, 500).slideUp(500, function () {
                    $("#spnmsg").remove();
                });
            }, 5000);//5000=5 seconds
            setTimeout(function () {
                $("#spnmsgSuccess").fadeTo(2000, 500).slideUp(500, function () {
                    $("#spnmsgSuccess").remove();
                });
            }, 10000);//5000=5 seconds
        </script>
        <style>
            .alert {
                margin: 10px 0px !important;
            }
        </style>
    </form>

</body>
</html>
