<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EcommerceWebsite.Login" %>

<%--<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>--%>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Login</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Login</li>
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
                            <div class="panel-heading">
                                <div class="row mb_20">
                                    <div class="col-xs-6">
                                        <a href="#" class="active" id="login-form-link">Login</a>
                                    </div>
                                    <div class="col-xs-6">
                                        <a href="#" id="register-form-link">Register</a>
                                    </div>
                                </div>
                                <hr>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                                        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin">
                                            <div id="login-form" class="mt_10">
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtLEmail" type="email" TabIndex="1" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtLEmail" ErrorMessage="Please enter email." ForeColor="Red" Display="Dynamic" ValidationGroup="Lsave"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group">
                                                    <asp:TextBox ID="txtlpassword" type="password" TabIndex="2" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtlpassword" ErrorMessage="Please enter password." ForeColor="Red" Display="Dynamic" ValidationGroup="Lsave"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="form-group text-center">
                                                    <input type="checkbox" tabindex="3" class="" name="remember" id="remember">
                                                    <label for="remember">Remember Me</label>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-sm-6 col-sm-offset-3">
                                                            <asp:Button runat="server" ID="btnLogin" TabIndex="4" class="form-control btn btn-login" OnClick="btnLogin_Click" Text="Login" ValidationGroup="Lsave" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="text-center">
                                                                <a href="../forgotpassword.aspx" tabindex="5" class="forgot-password">Forgot Password?</a>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <div id="register-form" action="#" method="post">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtRname" runat="server" type="text" TabIndex="1" class="form-control" placeholder="Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRName" ErrorMessage="Please enter name." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtREmail" runat="server" type="email" TabIndex="1" class="form-control" placeholder="Email Address"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtREmail" ErrorMessage="Please enter email." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtRPassword" runat="server" type="password" TabIndex="2" class="form-control" placeholder="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRPassword" ErrorMessage="Please enter password." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtRConfirmPassword" runat="server" type="password" TabIndex="2" class="form-control" placeholder="Confirm Password"></asp:TextBox>
                                                <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtRPassword" ForeColor="Red" Display="Dynamic" ControlToCompare="txtRConfirmPassword" Operator="Equal" Type="String" ErrorMessage="Password and Confirm Password do not match" ValidationGroup="Rsave" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRConfirmPassword" ErrorMessage="Please enter Confirm Password." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="form-group">
                                                <div class="row">
                                                    <div class="col-sm-6 col-sm-offset-3">
                                                        <asp:Button runat="server" ID="btnrSubmit" TabIndex="4" class="form-control btn btn-register" Text="Register Now" ValidationGroup="Rsave" OnClick="btnrSubmit_Click" />
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
</asp:Content>
