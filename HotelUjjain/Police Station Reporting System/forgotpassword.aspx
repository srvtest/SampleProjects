<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="forgotpassword.aspx.cs" Inherits="Police_Station_Reporting_System.forgotpassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card-header text-center">
        <a href="../../index2.html" class="h1"><b>Admin</b>LTE</a>
    </div>
    <div class="card-body">
        <p class="login-box-msg">You forgot your password? Here you can easily retrieve a new password.</p>
        <form action="recover-password.html" method="post">
            <div class="input-group mb-3">
                <%--<input type="email" class="form-control" placeholder="Email">--%>
                 <asp:TextBox ID="txtUsername" runat="server" type="text" class="form-control" placeholder="Username"></asp:TextBox>
                <div class="input-group-append">
                    <div class="input-group-text">
                        <span class="fas fa-envelope"></span>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-12">
                     <asp:Button ID="btnSubmit" runat="server" Text="Sign In" type="submit" class="btn btn-primary btn-block" OnClick="btnSubmit_Click" />
                    <%--<button type="submit" class="btn btn-primary btn-block">Request new password</button>--%>
                </div>
                <!-- /.col -->
            </div>
        </form>
        <p class="mt-3 mb-1">
            <a href="policestationlogin.aspx">Login</a>
        </p>
    </div>
</asp:Content>
