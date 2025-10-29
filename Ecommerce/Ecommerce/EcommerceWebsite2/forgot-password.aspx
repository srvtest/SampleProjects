<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="forgot-password.aspx.cs" Inherits="EcommerceWebsite2.forgot_password" %>

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
                                <li class="breadcrumb-item active">Forgot Password</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->
    <!-- forgot-password wrapper start -->
    <div class="login-register-wrapper section-padding">
        <div class="container">
            <div class="member-area-from-wrap">
                <div class="row">
                    <div class="col-lg-6 text-center">
                        <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <!-- forgot-password Content Start -->
                    <div class="col-lg-6">
                        <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnForgetpass">
                            <div class="login-reg-form-wrap">
                                <h5>Forgot Password</h5>
                                <p class="mb-4">We get it, stuff happens. Just enter your email address below and we'll send you a link to reset your password!</p>
                                <div class="single-input-item">
                                    <asp:TextBox ID="txtUserName" runat="server" type="text" aria-describedby="emailHelp" placeholder="Enter Email Address..."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter email address."></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtUserName" runat="server" ForeColor="Red" Display="Dynamic" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" ErrorMessage="Please enter valid email address."></asp:RegularExpressionValidator>
                                </div>
                                <div class="row">
                                    <div class="col-lg-6">
                                        <div class="single-input-item">
                                            <asp:Button ID="btnForgetpass" runat="server" Text="Reset Password" class="btn btn-sqr" OnClick="btnForgetpass_Click" />
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="single-input-item">
                                            <a class="small" style="line-height: 3.4em;" href="../login.aspx">Already have an account? Login!</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <!-- forgot-password Content End -->
                </div>
            </div>
        </div>
    </div>
    <!-- forgot-password wrapper end -->

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

    <script type="text/javascript">
        function ShowMessageForm() {
            document.getElementById("myDialog").showModal();
        }
    </script>
</asp:Content>
