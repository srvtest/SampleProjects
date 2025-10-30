<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="reset-password.aspx.cs" Inherits="Hotel_Guest_Reporting_System.reset_password" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center txt-primary">Reset Password</h3>
    <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
    <div class="md-input-wrapper">
        <asp:TextBox ID="txtPassword" runat="server" type="password" class="md-form-control" placeholder="Password"></asp:TextBox>
        <%--<input type="password" class="md-form-control" required="required">
					<label>Password</label>--%>
    </div>
    <div class="md-input-wrapper">
        <asp:TextBox ID="txtRepeatPassword" runat="server" type="password" class="md-form-control" placeholder="Repeat Password"></asp:TextBox>
        <%--<input type="password" class="md-form-control" required="required">
					<label>Confirm Password</label>--%>
    </div>
    <div class="col-xs-10 offset-xs-1">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary btn-md btn-block waves-effect waves-light m-b-20" data-toggle="tooltip" data-placement="top" title="Submit" OnClick="btnSubmit_Click" />
        <%--	<button type="submit" class="btn btn-primary btn-md btn-block waves-effect waves-light m-b-20">Sign up
					</button>--%>
    </div>
</asp:Content>
