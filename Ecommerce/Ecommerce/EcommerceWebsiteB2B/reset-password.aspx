<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="reset-password.aspx.cs" Inherits="EcommerceWebsiteB2B.reset_password" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Reset password</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Reset password</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">Reset password</li>
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
                <div class="col-lg-6">
                    <asp:Panel ID="pnlResetPassword" runat="server" DefaultButton="btnResetPassword">
                        <div>
                            <h5>Reset Password</h5>
                            <div>
                                <asp:TextBox ID="txtPassword" runat="server" type="password" placeholder="Password" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtPassword" ErrorMessage="Please enter password."></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:TextBox ID="txtRepeatPassword" runat="server" type="password" placeholder="Confirm Password" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ErrorMessage="Please enter confirm password."></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ControlToCompare="txtPassword" ErrorMessage="Password and Confirm Password do not match."></asp:CompareValidator>
                            </div>
                            <div>
                                <asp:Button ID="btnResetPassword" runat="server" Text="Submit" class="btn btn-primary btn-lg filled" OnClick="btnResetPassword_Click" />
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
