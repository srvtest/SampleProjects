<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="verification.aspx.cs" Inherits="EcommerceWebsiteB2B.verification" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Verification</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Verification</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">Verification</li>
                </ul>
            </div>
        </div>
    </section>
    <section class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <asp:Panel ID="pnlSuccess" runat="server">
                        <div class="row">
                            <div class="col-lg-12 col-md-8">
                                <h5>
                                    <asp:Label ID="lblHMessage" runat="server"></asp:Label>
                                </h5>
                                <div class="welcome">
                                    <p>
                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                    </p>
                                </div>
                                <p class="mb-0">
                                    Click here to login: <a href="<%= this.Master.baseUrl %>login">Click here</a>
                                </p>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlFailed" runat="server">
                        <div class="row">
                            <div class="col-lg-12 col-md-8">
                                <h5>
                                    <asp:Label ID="lblHMsg" runat="server"></asp:Label>
                                </h5>
                                <div class="welcome">
                                    <p>
                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
