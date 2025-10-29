<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs"
    Inherits="HotalManagment.ForgotPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- start: Meta -->
    <meta charset="utf-8">
    <title>Bootstrap Metro Dashboard by Dennis Ji for ARM demo</title>
    <meta name="description" content="Bootstrap Metro Dashboard" />
    <meta name="author" content="Dennis Ji" />
    <meta name="keyword" content="Metro, Metro UI, Dashboard, Bootstrap, Admin, Template, Theme, Responsive, Fluid, Retina" />
    <!-- end: Meta -->
    <!-- start: Mobile Specific -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- end: Mobile Specific -->
    <!-- start: CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-responsive.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" />
    <link href="css/style-responsive.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800&subset=latin,cyrillic-ext,latin-ext'
        rel='stylesheet' type='text/css' />
    <!-- start: Favicon -->
    <link rel="shortcut icon" href="img/favicon.ico" />
    <!-- end: Favicon -->
    <style type="text/css">
        body
        {
            background: url(img/bg-login.jpg) !important;
        }
    </style>
    <script type="text/javascript">
        function ShowMessageForm() {
            $('#MessageModel').modal('show');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container-fluid-full">
        <div class="row-fluid">
            <div class="row-fluid">
                <div class="login-box">
                    <h2 class="text-center">
                        Login to your account</h2>
                    <div title="Username" style="margin-left: 15px">
                        <span style="color: Red">*</span>
                        <asp:TextBox ID="txtUsername" runat="server" class="input-large span10" name="username"
                            type="text" placeholder="Enter Your username"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-center"
                            ControlToValidate="txtUsername" ErrorMessage="Required!" SetFocusOnError="True"
                            ForeColor="Red" Display="Dynamic" />
                    </div>
                    <div class="clearfix">
                    </div>
                    <div class="text-center" style="margin-bottom: 5px">
                        <asp:Button ID="btnLogin" runat="server" Text="OK" class="btn btn-primary" OnClick="btnLogin_Click" />
                    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
        <!--/.fluid-container-->
    </div>
    <!--/fluid-row-->
    <div class="modal hide fade" id="MessageModel">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Message</h3>
        </div>
        <div class="modal-body">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnOk" runat="server" Text="OK" class="btn" OnClick="btnOk_Click" />
        </div>
    </div>
    <!-- start: JavaScript-->
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
</body>
</html>
