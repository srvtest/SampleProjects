<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="EcommerceWebsite.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modal-title {
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-6 col-lg-6 mtb_20 col-lg-offset-3">
                <%--<div class="row">
                    <div class="col-md-12 col-md-offset-3">
                        <div class="panel-login panel">
                            <div class="panel-body">--%>
                <%--<div class="row">
                    <div class="col-lg-8">--%>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <div id="login-form">
                    <div>
                        <h4 class="h4 text-gray-900 mb-2">Reset Password</h4>
                        <%--<p class="mb-4">We get it, stuff happens. Just enter your email address below and we'll send you a link to reset your password!</p>--%>
                    </div>
                    <br />
                    <div class="form-group row">
                        <div class="col-sm-12 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control form-control-user" placeholder="Password" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Please enter password."></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-12 mb-3 mb-sm-0">
                            <asp:TextBox ID="txtRepeatPassword" runat="server" type="password" class="form-control form-control-user" placeholder="Repeat Password" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ErrorMessage="Please enter password again."></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ControlToCompare="txtPassword" ErrorMessage="Password did not match."></asp:CompareValidator>
                        </div>
                    </div>
                    <div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary" OnClick="btnSubmit_Click" />
                    </div>
                </div>
                <%-- </div>
                </div>--%>
                <%-- </div>
                        </div>
                    </div>
                </div>--%>
            </div>
        </div>
        <%--<div class="card o-hidden border-0 shadow-lg my-5">
            <div class="card-body p-0">
                <!-- Nested Row within Card Body -->
                <div class="row" style="min-height: 453px;">
                    <div class="col-lg-8 d-none d-lg-block bg-register-image"></div>
                    <div class="col-lg-4">
                        <div class="p-5">
                            <div class="text-center">
                                <h1 class="h4 text-gray-900 mb-4">Reset Password</h1>
                            </div>
                            <div class="user">
                                <div class="form-group row">
                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                        <asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control form-control-user" placeholder="Password" MaxLength="100"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Please enter password."></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-sm-6">
                                        <asp:TextBox ID="txtRepeatPassword" runat="server" type="password" class="form-control form-control-user" placeholder="Repeat Password" MaxLength="100"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ControlToCompare="txtPassword" ErrorMessage="Password did not match."></asp:CompareValidator>
                                    </div>
                                </div>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary btn-user btn-block" OnClick="btnSubmit_Click" />
                            </div>
                            <hr>
                            <div class="text-center">
                                <a class="small" href="forgotpassword.aspx">Forgot Password?</a>
                            </div>
                            <div class="text-center">
                                <a class="small" href="login.aspx">Already have an account? Login!</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>
    </div>
    <dialog id="myDialog" class="modal-dialog modal-lg" style="background: border-box; border:none;">
         <div>
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
