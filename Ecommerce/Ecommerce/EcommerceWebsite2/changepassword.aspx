<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="EcommerceWebsite2.changepassword" %>

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
                                <li class="breadcrumb-item active">Change Password</li>
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
            <div class="member-area-from-wrap" id="frmChangedPassword">
                <asp:HiddenField ID="hdUserId" runat="server" />
                <asp:HiddenField ID="hdName" runat="server" />
                <asp:HiddenField ID="hdGender" runat="server" />
                <asp:HiddenField ID="hdMobile" runat="server" />
                <asp:HiddenField ID="hdEmail" runat="server" />
                <asp:HiddenField ID="hdUserName" runat="server" />
                <asp:HiddenField ID="hdCurrentPassword" runat="server" />
                <asp:HiddenField ID="hdMessage" runat="server" />
                <div class="row">
                    <div class="col-lg-6 text-center">
                        <asp:Label ID="lblMess" ForeColor="Red" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <!-- Reset Password Start -->
                    <div class="col-lg-6 mx-auto">
                        <%-- <asp:Panel ID="pnlResetPassword" runat="server" DefaultButton="btnResetPassword">--%>
                        <div class="login-reg-form-wrap">
                            <%-- <h5>Change Password</h5>--%>
                            <div class="single-input-item">
                                <asp:TextBox ID="txtCurrentPassword" runat="server" type="password" placeholder="Current Password"></asp:TextBox>
                                <%--<asp:TextBox ID="txtCurrentPassword" runat="server" TextMode="Password" placeholder="CurrentPassword"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtCurrentPassword" runat="server" ErrorMessage="Please Enter Current Password." ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="single-input-item">
                                <asp:TextBox ID="txtNewPassword" runat="server" type="password" placeholder="New Password"></asp:TextBox>
                                <%--<asp:TextBox ID="txtNewPassword" runat="server" placeholder="New Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" ControlToValidate="txtNewPassword" runat="server" ErrorMessage="Please Enter Password." ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <%--<asp:CompareValidator ID="CompareValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRepeatPassword" ControlToCompare="txtPassword" ErrorMessage="Password and Confirm Password do not match."></asp:CompareValidator>--%>
                            </div>
                            <div class="single-input-item">
                                <%-- <asp:TextBox ID="txtConfirmPassword" runat="server" placeholder="Confirm Password"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword" ForeColor="Red" ControlToCompare="txtPassword" ErrorMessage="Password No Match" ToolTip="Password must be the same" Display="Dynamic" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="Please Enter Confirm Password." ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" placeholder="Confirm Password"></asp:TextBox>
                                <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" ControlToCompare="txtNewPassword" Operator="Equal" Type="String" ErrorMessage="Password and Confirm Password do not match" ValidationGroup="Rsave" />
                            </div>
                            <div class="single-input-item">
                                <%--<asp:Button ID="btnResetPassword" runat="server" Text="Submit" class="btn btn-sqr" OnClick="btnResetPassword_Click" />--%>

                                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-sqr" OnClick="btnUpdate_Click" Style="margin-left: 10px;" ValidationGroup="Rsave" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-sqr float-right" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                        <%--</asp:Panel>--%>
                    </div>
                    <!-- Reset Password End -->
                </div>
            </div>
        </div>
    </div>
    <!-- login wrapper end -->
   <%-- <script type="text/javascript">
        function Validate() {
            var password = document.getElementById("txtNewPassword").value;
            var confirmPassword = document.getElementById("txtConfirmPassword").value;
            if (password != confirmPassword) {
                alert("Passwords do not match.");
                return false;
            }
            return true;
        }
        $("#frmChangedPassword").validate({
            rules : {
                password : {
                    minlength : 5,
                    maxlength: 10
                },
                password_confirm : {
                    minlength : 5,
                    maxlength: 10,
                    equalTo : "#password"
                }


            });
    </script>--%>
</asp:Content>
