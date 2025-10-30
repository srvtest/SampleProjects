<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HotelLogin.aspx.cs" Inherits="Hotel_Guest_Reporting_System.HotelLogin" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="text-center txt-primary">होटल लॉगिन स्क्रीन
    </h3>
    <div class="row">
        <div class="col-md-12">
            <div class="md-input-wrapper">
                <asp:TextBox ID="txtUserName" runat="server" class="md-form-control" required="required" OnTextChanged="txtUserName_TextChanged"></asp:TextBox>
                <label>मोबाइल नंबर</label>
            </div>
        </div>
        <div class="col-md-12">
            <div class="md-input-wrapper">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="md-form-control" required="required"></asp:TextBox>
                <label>ओ.टी.पी</label>
            </div>
        </div>
        <div class="col-sm-6 col-xs-12">
            <div class="rkmd-checkbox checkbox-rotate checkbox-ripple m-b-25">
                <label class="input-checkbox checkbox-primary">
                    <input type="checkbox" id="checkbox">
                    <span class="checkbox"></span>
                </label>
                <div class="captions">Remember Me</div>
            </div>
        </div>
        <div class="col-sm-6 col-xs-12 forgot-phone text-right">
            <a href="<%= this.Master.baseUrl %>forgot-password.aspx" class="text-right f-w-600">Forget Password?</a>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-10 offset-xs-1">
            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-primary btn-md btn-block waves-effect text-center m-b-20" data-toggle="tooltip" data-placement="top" title="Login" OnClick="btnLogin_Click" />
        </div>
    </div>
    <!-- <div class="card-footer"> -->
    <div class="col-sm-12 col-xs-12 text-center">
        <span class="text-muted">Don't have an account?</span>
        <a href="<%= this.Master.baseUrl %>register.aspx" class="f-w-600 p-l-5">Sign up Now</a>
    </div>
    <div class="modal fade modal-flex" id="basic-form-Modal" tabindex="-1" role="dialog">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                    <h5 class="modal-title">Message</h5>
                </div>
                <div class="modal-body">
                    <%-- <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

