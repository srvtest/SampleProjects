<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EcommerceWebsite2.login" %>

<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- breadcrumb area start -->
    <div class="breadcrumb-area">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="breadcrumb-wrap">
                        <nav aria-label="breadcrumb">
                            <ul class="breadcrumb">
                                <li class="breadcrumb-item"><a href="/"><i class="fa fa-home"></i></a></li>
                                <li class="breadcrumb-item active">Login</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- login wrapper start -->
    <div class="login-register-wrapper section-padding">
        <div class="container">
            <div class="member-area-from-wrap">
                <div class="row">
                    <div class="col-lg-6 text-center">
                        <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <!-- Login Content Start -->
                    <div class="col-lg-6">
                        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
                            <div class="login-reg-form-wrap">
                                <h5>Sign In</h5>
                                <div class="single-input-item">
                                    <asp:TextBox ID="txtLEmail" type="text" TabIndex="1" placeholder="Email address" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLEmail" ErrorMessage="Please enter email." ForeColor="Red" Display="Dynamic" ValidationGroup="Lsave"></asp:RequiredFieldValidator>
                                </div>
                                <div class="single-input-item">
                                    <asp:TextBox ID="txtlpassword" type="password" TabIndex="2" placeholder="Password" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtlpassword" ErrorMessage="Please enter password." ForeColor="Red" Display="Dynamic" ValidationGroup="Lsave"></asp:RequiredFieldValidator>
                                </div>
                                <div class="single-input-item">
                                    <div class="login-reg-form-meta d-flex align-items-center justify-content-between">
                                        <div class="remember-meta">
                                            <div class="custom-control custom-checkbox">
                                                <input type="checkbox" tabindex="3" class="custom-control-input" name="remember" id="rememberMe" />
                                                <asp:HiddenField ID="hdnCheckbox" runat="server" Value="0" />
                                                <label class="custom-control-label" for="rememberMe">Remember Me</label>
                                            </div>
                                        </div>
                                        <a href="../forgot-password.aspx" tabindex="5" class="forgot-password">Forget Password?</a>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="single-input-item">
                                            <asp:Button runat="server" ID="btnLogin" ClientIDMode="Static" TabIndex="4" class="btn btn-sqr" OnClick="btnLogin_Click" Text="Login" ValidationGroup="Lsave" />
                                            <div style="display: inline-block; margin-left: 20px;">No account? <a href="../register.aspx" tabindex="5" class="">Register</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <!-- Login Content End -->
                </div>
            </div>
        </div>
    </div>
    <!-- login wrapper end -->
    <!-- jQuery JS -->
    <script src="../assets/js/vendor/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#rememberMe").click(function () {
                if ($('#rememberMe').is(":checked")) {
                    $("#<%= hdnCheckbox.ClientID %>").val(1);
                }
                else
                    $("#<%= hdnCheckbox.ClientID %>").val(0);
            });
        });
    </script>
</asp:Content>
