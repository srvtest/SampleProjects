<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="forgot-password.aspx.cs" Inherits="EcommerceWebsiteB2B.forgot_password" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Forgot password</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Forgot password</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">Forgot password</li>
                </ul>
            </div>
        </div>
    </section>
    <section class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 text-center">
                    <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <!-- Reset Password Start -->
                <div class="col-sm-6">
                    <div class="row m0">
                        <h4 class="contactHeading heading">Forgot Password</h4>
                        <p class="mb15">We get it, stuff happens. Just enter your email address below and we'll send you a link to reset your password!</p>
                    </div>
                    <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnForgetpass">
                        <div class="row m0 contactForm">
                            <div class="row m0 mb15">
                                <label for="txtLEmail">Email *</label>
                                <asp:TextBox ID="txtUserName" runat="server" type="text" CssClass="form-control" placeholder="Enter Email Address..." ValidationGroup="forgot"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter email address." ValidationGroup="forgot"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtUserName" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="forgot" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorMessage="Please enter valid email address."></asp:RegularExpressionValidator>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <asp:Button ID="btnForgetpass" runat="server" Text="Reset Password" class="btn btn-primary btn-lg filled" ValidationGroup="forgot" OnClick="btnForgetpass_Click"/>
                                </div>
                                <div class="col-sm-6">
                                    <span class="small" style="line-height: 3.4em;">Already have an account? <a href="<%= this.Master.baseUrl %>login.aspx">Login!</a></span>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <!-- Reset Password End -->
            </div>
        </div>
        <dialog id="myDialog" class="modal-dialog modal-lg" style="background: border-box; border: none;">
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
        </dialog>
    </section>
    <script type="text/javascript">
        function ShowMessageForm() {
            document.getElementById("myDialog").showModal();
        }
    </script>
</asp:Content>
