<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="EcommerceWebsite.forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modal-title {
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Forgot Password</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Forgot Password</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <div id="column-left" class="col-sm-4 col-lg-3 hidden-xs">
                <%--<uc1:UCTopCategory runat="server" ID="UCTopCategory" />--%>
                <div class="left_banner left-sidebar-widget mt_30 mb_40">
                    <a href="#">
                        <img src="images/left1.jpg" alt="Left Banner" class="img-responsive" /></a>
                </div>
            </div>
            <div class="col-sm-8 col-lg-9 mtb_20">
                <!-- contact  -->
                <div class="row">
                    <div class="col-md-6 col-md-offset-3">
                        <div class="panel-login panel">
                            <%--<div class="panel-heading">
                                <div class="row mb_20">
                                    <div class="col-xs-6">
                                        <a href="#" class="active" id="login-form-link">Forgot Password</a>
                                    </div>
                                </div>
                                <hr>
                            </div>--%>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                        <div class="card o-hidden border-0 shadow-lg my-5">
                                            <div class="card-body p-0">
                                                <!-- Nested Row within Card Body -->
                                                <div class="row" style="min-height: 453px;">

                                                    <div class="col-lg-12">
                                                        <div class="p-5">
                                                            <div class="text-center mb_20">
                                                                <h1 class="h4 text-gray-900 mb-2">Forgot Your Password?</h1>
                                                                <p class="mb-4">We get it, stuff happens. Just enter your email address below and we'll send you a link to reset your password!</p>
                                                            </div>
                                                            <div class="user">
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtUserName" runat="server" type="text" class="form-control form-control-user" aria-describedby="emailHelp" placeholder="Enter Email Address..."></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter email address."></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtUserName" runat="server" ForeColor="Red" Display="Dynamic" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorMessage="Please enter valid email address."></asp:RegularExpressionValidator>
                                                                </div>
                                                                <asp:Button ID="btnForgetpass" runat="server" Text="Reset Password" class="btn btn-primary btn-user btn-block" OnClick="btnForgetpass_Click" />
                                                            </div>
                                                            <hr>
                                                            <div class="text-center">
                                                                <a class="small" href="../login.aspx">Already have an account? Login!</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <dialog id="myDialog" class="modal-dialog modal-lg" style="background: border-box; border:none;">
        <div >
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Message</h4>
                    <asp:LinkButton ID="btnClose" class="close" runat="server" OnClick="btnOk_Click">&times;</asp:LinkButton>
                </div>
                <div class="modal-body">
                    <p>
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </p>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnOk" runat="server" Text="OK" class="btn" OnClick="btnOk_Click" />
                </div>
            </div>
        </div>
    </dialog>

    <script type="text/javascript">
        function ShowMessageForm() {
            document.getElementById("myDialog").showModal();
        }
    </script>


</asp:Content>
