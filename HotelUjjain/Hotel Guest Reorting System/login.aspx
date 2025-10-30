<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Hotel_Guest_Reporting_System.login" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center">Hotel Guest Reporting System </br>Admin Login
    </h3>
    <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
    <div class="row">
        <div class="col-md-12">
            <div class="md-input-wrapper">
                <%-- <label>Username</label>--%>
                <asp:TextBox ID="txtUserName" runat="server" class="md-form-control" placeholder="Username" required="required"></asp:TextBox>               
            </div>
        </div>
        <div class="col-md-12">
            <div class="md-input-wrapper">
               <%-- <label>Password</label>--%>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="md-form-control" placeholder="Password" required="required"></asp:TextBox>                
            </div>
        </div>
        <%-- <div class="col-sm-6 col-xs-12">
            <div class="rkmd-checkbox checkbox-rotate checkbox-ripple m-b-25">
                <label class="input-checkbox checkbox-primary">
                    <input type="checkbox" id="checkbox">
                    <span class="checkbox"></span>
                </label>
                <div class="captions">Remember Me</div>
            </div>
        </div>--%>
        <%-- <div class="col-sm-6 col-xs-12 forgot-phone text-right">
            <a href="<%= this.Master.baseUrl %>forgot-password.aspx" class="text-right f-w-600">Forget Password?</a>
        </div>--%>
    </div>
    <div class="row">
        <div class="col-xs-10 offset-xs-1">
            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-guestsuccess btn-md btn-block waves-effect text-center m-b-20" data-toggle="tooltip" data-placement="top" title="Login" OnClick="btnLogin_Click" />
        </div>
    </div>
    <!-- <div class="card-footer"> -->
    <%-- <div class="col-sm-12 col-xs-12 text-center">
        <span class="text-muted">Don't have an account?</span>
        <a href="<%= this.Master.baseUrl %>register.aspx" class="f-w-600 p-l-5">Sign up Now</a>
    </div>--%>
</asp:Content>
