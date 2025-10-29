<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="privacy-policy.aspx.cs" Inherits="EcommerceWebsite2.PrivacyPolicy" %>

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
                                <li class="breadcrumb-item active">Privacy Policy</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- my account wrapper start -->
    <div class="my-account-wrapper section-padding">
        <div class="container">
            <div class="section-bg-color">
                <div class="row">
                    <div class="col-lg-12">
                        <!-- My Account Page Start -->
                        <div class="myaccount-page-wrapper">
                            <!-- My Account Tab Menu Start -->
                            <div class="row">
                                <div class="col-lg-3 col-md-4">
                                    <div class="myaccount-tab-menu nav" role="tablist">
                                        <%--<a href="#dashboad" class="active" data-toggle="tab"><i class="fa fa-dashboard"></i>
                                                Dashboard</a>
                                            <a href="#orders" data-toggle="tab"><i class="fa fa-cart-arrow-down"></i>
                                                Orders</a>
                                            <a href="#download" data-toggle="tab"><i class="fa fa-cloud-download"></i>
                                                Download</a>
                                            <a href="#payment-method" data-toggle="tab"><i class="fa fa-credit-card"></i>
                                                Payment
                                                Method</a>
                                            <a href="#address-edit" data-toggle="tab"><i class="fa fa-map-marker"></i>
                                                address</a>
                                            <a href="#account-info" data-toggle="tab"><i class="fa fa-user"></i> Account
                                                Details</a>
                                            <a href="login-register.html"><i class="fa fa-sign-out"></i> Logout</a>--%>
                                        <asp:LinkButton ID="btnPrivacyPolicy" OnClick="btnPrivacyPolicy_Click" runat="server">Privacy Policy</asp:LinkButton>

                                        <asp:LinkButton ID="btnRefundPolicy" OnClick="btnRefundPolicy_Click" runat="server">Refund Policy</asp:LinkButton>

                                        <asp:LinkButton ID="btnBuyBackPolicy" OnClick="btnBuyBackPolicy_Click" runat="server">Buy Back Policy</asp:LinkButton>

                                        <asp:LinkButton ID="btnExchangePolicy" OnClick="btnExchangePolicy_Click" runat="server">Exchange Policy</asp:LinkButton>

                                        <asp:LinkButton ID="btnShippingPolicy" OnClick="btnShippingPolicy_Click" runat="server">Shipping Policy</asp:LinkButton>

                                        <asp:LinkButton ID="btnCancellationPolicy" OnClick="btnCancellationPolicy_Click" runat="server">Cancellation Policy</asp:LinkButton>

                                    </div>
                                </div>
                                <!-- My Account Tab Menu End -->

                                <!-- My Account Tab Content Start -->
                                <div class="col-lg-9 col-md-8">
                                    <div class="tab-content" id="myaccountContent">

                                        <!-- Single Tab Content Start -->
                                        <%--<div class="tab-pane fade show active" id="dashboad" role="tabpanel">
                                            <div class="myaccount-content">
                                                <h5>Dashboard</h5>
                                                <div class="welcome">
                                                    <p>
                                                        Hello, <strong>Erik Jhonson</strong> (If Not <strong>Jhonson
                                                            !</strong><a href="login-register.html" class="logout"> Logout</a>)
                                                    </p>
                                                </div>
                                                <p class="mb-0">
                                                    From your account dashboard. you can easily check &
                                                        view your recent orders, manage your shipping and billing addresses
                                                        and edit your password and account details.
                                                </p>
                                            </div>
                                        </div>--%>
                                        <!-- Single Tab Content End -->
                                        <asp:Panel ID="pnlPrivacyPolicy" runat="server">
                                            <div class="row">
                                                <%--   <asp:HiddenField ID="hdnPrivacyPolicyId" runat="server" Value="3" />--%>
                                                <asp:Repeater ID="lstPrivacyPolicy" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="myaccount-content">
                                                            <h5>
                                                                <asp:Label ID="lblPrivacyPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                                            </h5>
                                                            <p>
                                                                <%#Eval("sContent")%>
                                                            </p>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlRefundPolicy" runat="server" Visible="false">
                                            <div class="row">
                                                <%--  <asp:HiddenField ID="hdnRefundPolicyId" runat="server" Value="6" />--%>
                                                <asp:Repeater ID="lstRefundPolicy" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="myaccount-content">
                                                            <h5>
                                                                <asp:Label ID="lblRefundPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                                            </h5>
                                                            <p>
                                                                <%#Eval("sContent")%>
                                                            </p>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlBuyBackPolicy" runat="server" Visible="false">
                                            <div class="row">
                                                <%-- <asp:HiddenField ID="hdnBuyBackPolicyId" runat="server" Value="7" />--%>
                                                <asp:Repeater ID="lstBuyBackPolicy" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="myaccount-content">
                                                            <h5>
                                                                <asp:Label ID="lblBuyBackPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                                            </h2>
                                                            <p>
                                                                <%#Eval("sContent")%>
                                                            </p>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlExchangePolicy" runat="server" Visible="false">
                                            <div class="row">
                                                <%-- <asp:HiddenField ID="hdnExchangePolicyId" runat="server" Value="8" />--%>
                                                <asp:Repeater ID="lstExchangePolicy" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="myaccount-content">
                                                            <h5>
                                                                <asp:Label ID="lblExchangePolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                                            </h2>
                                                            <p>
                                                                <%#Eval("sContent")%>
                                                            </p>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlShippingPolicy" runat="server" Visible="false">
                                            <div class="row">
                                                <%-- <asp:HiddenField ID="hdnShippingPolicyId" runat="server" Value="9" />--%>
                                                <asp:Repeater ID="lstShippingPolicy" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="myaccount-content">
                                                            <h5>
                                                                <asp:Label ID="lblShippingPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                                            </h5>
                                                            <p>
                                                                <%#Eval("sContent")%>
                                                            </p>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlCancellationPolicy" runat="server" Visible="false">
                                            <div class="row">
                                                <%--  <asp:HiddenField ID="hdnCancellationPolicyId" runat="server" Value="10" />--%>
                                                <asp:Repeater ID="lstCancellationPolicy" runat="server">
                                                    <HeaderTemplate>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <div class="myaccount-content">
                                                            <h5>
                                                                <asp:Label ID="lblCancellationPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                                            </h5>
                                                            <p>
                                                                <%#Eval("sContent")%>
                                                            </p>
                                                        </div>
                                                    </ItemTemplate>
                                                    <FooterTemplate></FooterTemplate>
                                                </asp:Repeater>
                                            </div>
                                        </asp:Panel>

                                    </div>
                                </div>
                                <!-- My Account Tab Content End -->
                            </div>
                        </div>
                        <!-- My Account Page End -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- my account wrapper end -->

</asp:Content>
