<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs"
    Inherits="HotalManagment.ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- start: Meta -->
    <meta charset="utf-8">
    <title>Reset Password</title>
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
                   <%-- <div class="icons">
                        <a href="MainDashBoard.aspx"><i class="halflings-icon home"></i></a><a href="#"><i class="halflings-icon cog">
                        </i></a>
                    </div>--%>
                    <h2 class="text-center">
                        Set password</h2>
                    <div title="Username" style="margin-left:15px">
                        <%--<span class="add-on"><i class="halflings-icon user"></i></span>--%>
                        <span style="color:Red">*</span>
                        <asp:TextBox ID="txtPassword" runat="server" class="input-large span10" name="password"
                            type="password" placeholder="Enter New password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Required!" Display="Dynamic" ForeColor="Red" />
                    </div>
                    <div title="Password" style="margin-left:15px">
                      <%--  <span class="add-on"><i class="halflings-icon lock"></i></span>--%>
                      <span style="color:Red">*</span>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" class="input-large span10" name="password"
                            type="password" placeholder="Retype password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtConfirmPassword"
                            ErrorMessage="Required!"  Display="Dynamic" ForeColor="Red"/>
                        <asp:CompareValidator ID="comparePasswords" runat="server" ControlToCompare="txtPassword"
                            ControlToValidate="txtConfirmPassword" ErrorMessage="Your passwords do not match up!"
                            Display="Dynamic" ForeColor="Red"/>
                    </div>
                    <div class="text-center" style="margin-bottom:5px">
                        <asp:Button ID="btnChange" runat="server" Text="OK" class="btn btn-primary" OnClick="btnChange_Click" />
                    </div>
                </div>
                <!--/span-->
            </div>
            <!--/row-->
        </div>
        <!--/.fluid-container-->
    </div>
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
            <%--   <a href="#" class="btn" data-dismiss="modal">OK</a>--%>
        </div>
    </div>
    <!--/.fluid-container-->
    <!--/fluid-row-->
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
