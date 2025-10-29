<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="HotalManagment.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Change Password</title>
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700"
        rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="assets/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <!--bootstrap -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Material Design Lite CSS -->
    <link rel="stylesheet" href="assets/plugins/material/material.min.css">
    <link rel="stylesheet" href="assets/css/material_style.css">
    <!-- animation -->
    <link href="assets/css/pages/animate_page.css" rel="stylesheet">
    <!-- Template Styles -->
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/theme-color.css" rel="stylesheet" type="text/css" />
    <!-- favicon -->
    <link rel="shortcut icon" href="assets/img/favicon.ico" />
    <link rel="stylesheet" href="assets/plugins/jquery-toast/dist/jquery.toast.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <div class="page-bar">
            <div class="page-title-breadcrumb">
                <div class=" pull-left">
                    <div class="page-title">
                        Change Password</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Change Password</li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Change Password</header>
                        
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtpassword" runat="server" class="mdl-textfield__input" name="password"
                                    type="password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="passwordReq" runat="server" ControlToValidate="txtpassword"
                                    ForeColor="Red" ErrorMessage="Password is required!" Display="Dynamic" />
                                <label class="mdl-textfield__label">
                                    Password</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtNewPassword" runat="server" class="mdl-textfield__input" name="password"
                                    type="password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="confirmPasswordReq" runat="server" ControlToValidate="txtNewPassword"
                                    ForeColor="Red" ErrorMessage="New Password required!" Display="Dynamic" />
                                <label class="mdl-textfield__label">
                                    New password</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtReInsertPassword" runat="server" class="mdl-textfield__input"
                                    name="password" type="password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredReInsertPassword" runat="server" ControlToValidate="txtReInsertPassword"
                                    ForeColor="Red" ErrorMessage="Required!" Display="Dynamic" />
                                <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtNewPassword"
                                    ControlToValidate="txtReInsertPassword" ForeColor="Red" ErrorMessage="Your passwords do not match up!"
                                    Display="Dynamic" />
                                <label class="mdl-textfield__label">
                                    Re-Enter Password</label>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 p-t-20 text-center">
                        <asp:Button ID="Button1" runat="server" Text="Save Profile" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                            OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <%--<div>
                    <h2>  Change Password of your account</h2>
                                
                    <div class="input-prepend" title="Password">
                        <span class="add-on"><i class="icon-lock"></i></span>
                       
                    <div class="clearfix">
                    </div>
                    <div class="input-prepend" title="New Password">
                        <span class="add-on"><i class="icon-lock"></i></span>
                        
                    <div class="clearfix">
                    </div>
                    <div class="input-prepend" title="Re-Enter Password">
                        <span class="add-on"><i class="icon-lock"></i></span>
                       
        
                    <div class="clearfix">
                    </div>
                    
                    <div class="button-Submit">
                        <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-primary" 
                            onclick="btnSave_Click" />
                    </div>
                    <div class="clearfix">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                </div>
           
    <script src="js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="js/jquery-migrate-1.0.0.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui-1.10.0.custom.min.js" type="text/javascript"></script>
    <script src="js/jquery.ui.touch-punch.js" type="text/javascript"></script>
    <script src="js/modernizr.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.cookie.js" type="text/javascript"></script>
    <script src='js/fullcalendar.min.js' type="text/javascript"></script>
    <script src='js/jquery.dataTables.min.js' type="text/javascript"></script>
    <script src="js/excanvas.js" type="text/javascript"></script>
    <script src="js/jquery.flot.js" type="text/javascript"></script>
    <script src="js/jquery.flot.pie.js" type="text/javascript"></script>
    <script src="js/jquery.flot.stack.js" type="text/javascript"></script>
    <script src="js/jquery.flot.resize.min.js" type="text/javascript"></script>
    <script src="js/jquery.chosen.min.js" type="text/javascript"></script>
    <script src="js/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="js/jquery.cleditor.min.js" type="text/javascript"></script>
    <script src="js/jquery.noty.js" type="text/javascript"></script>
    <script src="js/jquery.elfinder.min.js" type="text/javascript"></script>
    <script src="js/jquery.raty.min.js" type="text/javascript"></script>
    <script src="js/jquery.iphone.toggle.js" type="text/javascript"></script>
    <script src="js/jquery.uploadify-3.1.min.js" type="text/javascript"></script>
    <script src="js/jquery.gritter.min.js" type="text/javascript"></script>
    <script src="js/jquery.imagesloaded.js" type="text/javascript"></script>
    <script src="js/jquery.masonry.min.js" type="text/javascript"></script>
    <script src="js/jquery.knob.modified.js" type="text/javascript"></script>
    <script src="js/jquery.sparkline.min.js" type="text/javascript"></script>
    <script src="js/counter.js" type="text/javascript"></script>
    <script src="js/retina.js" type="text/javascript"></script>
    <script src="js/custom.js" type="text/javascript"></script>
    <!-- end: JavaScript-->

    </form>

    --%>
       <script src="assets/plugins/jquery/jquery.min.js"></script>
    <script src="assets/plugins/popper/popper.min.js"></script>
    <script src="assets/plugins/jquery-blockui/jquery.blockui.min.js"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- bootstrap -->
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <!-- Common js-->
    <script src="assets/js/app.js"></script>
    <script src="assets/js/layout.js"></script>
    <script src="assets/js/theme-color.js"></script>
    <!-- Material -->
    <script src="assets/plugins/material/material.min.js"></script>
    <!-- animation -->
    <script src="assets/js/pages/ui/animations.js"></script>
    <!-- notifications -->
    <script src="assets/plugins/jquery-toast/dist/jquery.toast.min.js"></script>
    <script src="assets/plugins/jquery-toast/dist/toast.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //            $("#grdCategory").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
            //                responsive: true,
            //                sPaginationType: "bootstrap"
            //            });
        });

        function Successmsg() {

            var str = $('#hdMessage').val();

            var msgHead = str.split("|")[0];
            var msg = str.split("|")[1];

            $.toast({
                heading: msgHead,
                text: msg,
                position: 'top-center',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 3500,
                stack: 6
            });

        }

        function Errormsg() {

            var str = $('#hdMessage').val();
            var msgHead = str.split("|")[0];
            var msg = str.split("|")[1];
            $.toast({
                heading: msgHead,
                text: msg,
                position: 'top-center',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500
            });
        }

    </script></asp:Content>
