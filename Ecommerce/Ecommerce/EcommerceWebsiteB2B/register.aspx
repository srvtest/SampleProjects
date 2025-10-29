<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="EcommerceWebsiteB2B.register" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>register</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">register</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">register</li>
                </ul>
            </div>
        </div>
    </section>
    <section id="registerRow" class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 text-center">
                    <asp:Label ID="lblMessage" ForeColor="Red" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="row m0">
                        <h4 class="contactHeading heading">register</h4>
                    </div>
                    <div class="row m0 contactForm">
                        <div class="row m0" id="contactForm">
                            <div class="row m0 mb15">
                                <label for="txtRname">Name *</label>
                                <asp:TextBox ID="txtRname" runat="server" type="text" TabIndex="1" CssClass="form-control" placeholder="Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRName" ErrorMessage="Please enter name." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row m0 mb15">
                                <label for="txtREmail">Email *</label>
                                <asp:TextBox ID="txtREmail" runat="server" type="email" TabIndex="1" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtREmail" ErrorMessage="Please enter email." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row mb15">
                                <div class="col-sm-6">
                                    <label for="txtRPassword">Password *</label>
                                    <asp:TextBox ID="txtRPassword" runat="server" type="password" TabIndex="2" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtRPassword" ErrorMessage="Please enter password." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-sm-6">
                                    <label for="txtRConfirmPassword">Confirm Password *</label>
                                    <asp:TextBox ID="txtRConfirmPassword" runat="server" type="password" TabIndex="2" CssClass="form-control" placeholder="Confirm Password"></asp:TextBox>
                                    <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtRPassword" ForeColor="Red" Display="Dynamic" ControlToCompare="txtRConfirmPassword" Operator="Equal" Type="String" ErrorMessage="Password and Confirm Password do not match." ValidationGroup="Rsave" />
                                </div>
                            </div>
                            <div class="row m0 mb15">
                                <div class="remember-meta">
                                    <div class="custom-control custom-checkbox">
                                        <input type="checkbox" class="custom-control-input" id="subnewsletter" />
                                        <asp:HiddenField ID="hdnCheckbox" runat="server" Value="0" />
                                        <label class="custom-control-label" for="subnewsletter" style="display: inline-block">
                                            Subscribe
                                                Our Newsletter</label>
                                    </div>
                                </div>
                            </div>
                            <div class="row m0">
                                <asp:Button runat="server" ID="btnrSubmit" TabIndex="4" class="btn btn-primary btn-lg filled" Text="Register" ValidationGroup="Rsave" OnClick="btnrSubmit_Click" />
                                <div style="display: inline-block; margin-left: 20px;">Already have an accout? <a href="<%= this.Master.baseUrl %>login.aspx" tabindex="5" class="">Login</a></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#subnewsletter").click(function () {
                if ($('#subnewsletter').is(":checked")) {
                    $("#<%= hdnCheckbox.ClientID %>").val(1);
                }
                else
                    $("#<%= hdnCheckbox.ClientID %>").val(0);
            });
        });
    </script>
</asp:Content>
