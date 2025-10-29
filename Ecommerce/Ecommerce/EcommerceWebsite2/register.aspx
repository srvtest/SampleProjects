<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="EcommerceWebsite2.register" %>

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
                                <li class="breadcrumb-item active">Register</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- register wrapper start -->
    <div class="login-register-wrapper section-padding">
        <div class="container">
            <div class="member-area-from-wrap">
                <div class="row">
                    <div class="col-lg-6 text-center">
                        <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <!-- Register Content Start -->
                    <div class="col-lg-6">
                        <asp:Panel ID="pnlRegister" runat="server" DefaultButton="btnrSubmit">
                            <div class="login-reg-form-wrap">
                                <h5>Sign up Form</h5>
                                <div class="single-input-item">
                                    <asp:TextBox ID="txtRname" runat="server" type="text" TabIndex="1" placeholder="Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRName" ErrorMessage="Please enter name." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                </div>
                                <div class="single-input-item">
                                    <asp:TextBox ID="txtREmail" runat="server" type="email" TabIndex="1" placeholder="Email Address"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtREmail" ErrorMessage="Please enter email." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="single-input-item">
                                            <asp:TextBox ID="txtRPassword" runat="server" type="password" TabIndex="2" placeholder="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRPassword" ErrorMessage="Please enter password." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="single-input-item">
                                            <asp:TextBox ID="txtRConfirmPassword" runat="server" type="password" TabIndex="2" placeholder="Confirm Password"></asp:TextBox>
                                            <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtRPassword" ForeColor="Red" Display="Dynamic" ControlToCompare="txtRConfirmPassword" Operator="Equal" Type="String" ErrorMessage="Password and Confirm Password do not match." ValidationGroup="Rsave" />
                                        </div>
                                    </div>
                                </div>
                                <div class="single-input-item">
                                    <div class="login-reg-form-meta">
                                        <div class="remember-meta">
                                            <div class="custom-control custom-checkbox">
                                                <input type="checkbox" class="custom-control-input" id="subnewsletter" />
                                                <asp:HiddenField ID="hdnCheckbox" runat="server" Value="0" />
                                                <label class="custom-control-label" for="subnewsletter" style="display: inline-block">
                                                    Subscribe
                                                        Our Newsletter</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="single-input-item">
                                            <asp:Button runat="server" ID="btnrSubmit" TabIndex="4" class="btn btn-sqr" Text="Register" ValidationGroup="Rsave" OnClick="btnrSubmit_Click" />
                                            <div style="display: inline-block; margin-left: 20px;">Already have an accout? <a href="../login.aspx" tabindex="5" class="">Login</a></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <!-- Register Content End -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- register wrapper end -->
    <!-- jQuery JS -->
    <script src="../assets/js/vendor/jquery-3.3.1.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#subnewsletter").click(function () {
                if ($('#subnewsletter').is(":checked")) {
                    $("#<%= hdnCheckbox.ClientID %>").val(1);
                    }
                    else
                        $("#<%= hdnCheckbox.ClientID %>").val(0);
                });
            });
    </script>
</asp:Content>
