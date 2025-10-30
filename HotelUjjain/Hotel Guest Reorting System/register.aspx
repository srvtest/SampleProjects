<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="Hotel_Guest_Reporting_System.register" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center txt-primary">Create an account </h3>
    <div class="row">
        <div class="col-md-6">
            <div class="md-input-wrapper">
                <input type="text" class="md-form-control" required="">
                <label>First Name</label>
            </div>
        </div>
        <div class="col-md-6">
            <div class="md-input-wrapper">
                <input type="text" class="md-form-control" required="">
                <label>Last Name</label>
            </div>
        </div>
    </div>
    <div class="md-input-wrapper">
        <input type="email" class="md-form-control" required="required">
        <label>Email Address</label>
    </div>
    <div class="md-input-wrapper">
        <input type="password" class="md-form-control" required="required">
        <label>Password</label>
    </div>
    <div class="md-input-wrapper">
        <input type="password" class="md-form-control" required="required">
        <label>Confirm Password</label>
    </div>

    <div class="rkmd-checkbox checkbox-rotate checkbox-ripple b-none m-b-20">
        <label class="input-checkbox checkbox-primary">
            <input type="checkbox" id="checkbox">
            <span class="checkbox"></span>
        </label>
        <div class="captions">Remember Me</div>
    </div>
    <div class="col-xs-10 offset-xs-1">
        <button type="submit" class="btn btn-primary btn-md btn-block waves-effect waves-light m-b-20">
            Sign up
        </button>
    </div>
    <div class="row">
        <div class="col-xs-12 text-center">
            <span class="text-muted">Already have an account?</span>
            <a href="<%= this.Master.baseUrl %>login.aspx" class="f-w-600 p-l-5">Sign In Here</a>
        </div>
    </div>
</asp:Content>
