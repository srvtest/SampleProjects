<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="forgot-password.aspx.cs" Inherits="Hotel_Guest_Reporting_System.forgot_password" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-primary text-center m-b-25">Recover your password</h3>
    <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
    <div class="md-group">
        <div class="md-input-wrapper">
            <asp:TextBox ID="txtUserName" runat="server" type="text" CssClass="md-form-control" placeholder="Enter Username..." ValidationGroup="forgot"></asp:TextBox>
            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter Username." ValidationGroup="forgot"></asp:RequiredFieldValidator>--%>
        </div>
    </div>
    <div class="btn-forgot">
        <asp:Button ID="btnSubmit" runat="server" Text="SEND RESET LINK" class="btn btn-primary btn-md waves-effect waves-light text-center" data-toggle="tooltip" data-placement="top" title="SEND RESET LINK" OnClick="btnSubmit_Click" />
    </div>
    <div class="row">
        <div class="col-xs-12 text-center m-t-25">
            <a href="<%= this.Master.baseUrl %>login.aspx" class="f-w-600 p-l-5">Sign In Here</a>
        </div>
    </div>
</asp:Content>
