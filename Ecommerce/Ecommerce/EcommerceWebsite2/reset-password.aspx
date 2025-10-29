<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="reset-password.aspx.cs" Inherits="EcommerceWebsite2.reset_password" %>

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
                                <li class="breadcrumb-item active">Reset Password</li>
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
                    <!-- Reset Password Start -->
                    <div class="col-lg-6">
                        <asp:Panel ID="pnlResetPassword" runat="server" DefaultButton="btnResetPassword">
                            <div class="login-reg-form-wrap">
                                <h5>Reset Password</h5>
                                <div class="single-input-item">
                                    <asp:TextBox ID="txtPassword" runat="server" type="password" placeholder="Password" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Please enter password."></asp:RequiredFieldValidator>
                                </div>
                                <div class="single-input-item">
                                    <asp:TextBox ID="txtRepeatPassword" runat="server" type="password" placeholder="Confirm Password" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ErrorMessage="Please enter confirm password."></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ControlToCompare="txtPassword" ErrorMessage="Password and Confirm Password do not match."></asp:CompareValidator>
                                </div>
                                <div class="single-input-item">
                                    <asp:Button ID="btnResetPassword" runat="server" Text="Submit" class="btn btn-sqr" OnClick="btnResetPassword_Click" />
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <!-- Reset Password End -->
                </div>
            </div>
        </div>
    </div>
    <!-- login wrapper end -->
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
