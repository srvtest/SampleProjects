<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="EcommerceWebsiteB2B.login" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Login</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Login</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">login</li>
                </ul>
            </div>
        </div>
    </section>
    <section id="loginRow" class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 text-center">
                    <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="row m0">
                        <h4 class="contactHeading heading">login</h4>
                    </div>
                    <div class="row m0 contactForm">
                        <div class="row m0" id="contactForm">
                            <div class="row m0 mb15">
                                <label for="txtLEmail">Email *</label>
                                <asp:TextBox ID="txtLEmail" type="text" TabIndex="1" CssClass="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLEmail" ErrorMessage="Please enter email." ForeColor="Red" Display="Dynamic" ValidationGroup="Lsave"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row m0 mb15">
                                <label for="txtlpassword">password *</label>
                                <asp:TextBox ID="txtlpassword" type="password" TabIndex="2" CssClass="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtlpassword" ErrorMessage="Please enter password." ForeColor="Red" Display="Dynamic" ValidationGroup="Lsave"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row m0 mb15">
                                    <div class="remember-meta" style="display:inline-block">
                                        <div class="custom-control custom-checkbox">
                                            <input type="checkbox" tabindex="3" class="custom-control-input" name="remember" id="rememberMe" />
                                            <asp:HiddenField ID="hdnCheckbox" runat="server" Value="0" />
                                            <label class="custom-control-label" for="rememberMe">Remember Me</label>
                                        </div>
                                    </div>
                                    <a href="<%= this.Master.baseUrl %>forgot-password.aspx" tabindex="5" class="forgot-password fright">Forget Password?</a>
                            </div>
                            <div class="row m0">
                                <asp:Button runat="server" ID="btnLogin" ClientIDMode="Static" TabIndex="4" class="btn btn-primary btn-lg filled" OnClick="btnLogin_Click" Text="Login" ValidationGroup="Lsave" />
                                <div style="display: inline-block; margin-left: 20px;">No account? <a href="<%= this.Master.baseUrl %>register.aspx" tabindex="5" class="">Register</a></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
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
