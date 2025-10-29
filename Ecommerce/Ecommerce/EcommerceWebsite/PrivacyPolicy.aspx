<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PrivacyPolicy.aspx.cs" Inherits="EcommerceWebsite.PrivacyPolicy" %>

<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Privacy Policy</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Privacy Policy</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <%--<div id="column-left" class="col-sm-4 col-lg-3 hidden-xs">
                <uc1:UCTopCategory runat="server" ID="UCTopCategory" />
                <div class="left_banner left-sidebar-widget mt_30 mb_40">
                    <a href="#">
                        <img src="images/left1.jpg" alt="Left Banner" class="img-responsive" /></a>
                </div>
            </div>--%>
            <div id="column-left" class="col-sm-4 col-lg-3 ">
                <div class="nav-responsive">
                    <%--<div class="heading-part mb_10 ">
                        <h2 class="main_title">My Profile</h2>
                    </div>--%>
                    <div id="left-special" class="owl-carousel">
                        <ul class="nav main-navigation collapse in" style="clear: both">
                            <li>
                                <asp:LinkButton ID="btnRefundPolicy" OnClick="btnRefundPolicy_Click" runat="server">Refund Policy</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="btnBuyBackPolicy" OnClick="btnBuyBackPolicy_Click" runat="server">Buy Back Policy</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="btnExchangePolicy" OnClick="btnExchangePolicy_Click" runat="server">Exchange Policy</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="btnShippingPolicy" OnClick="btnShippingPolicy_Click" runat="server">Shipping Policy</asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="btnCancellationPolicy" OnClick="btnCancellationPolicy_Click" runat="server">Cancellation Policy</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-8 col-lg-8 mtb_20 col-lg-offset-1">
                <asp:Panel ID="pnlPrivacyPolicy" runat="server">
                    <div class="row">
                     <%--   <asp:HiddenField ID="hdnPrivacyPolicyId" runat="server" Value="3" />--%>
                        <asp:Repeater ID="lstPrivacyPolicy" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="about-text">
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
                                <div class="about-text">
                                    <h2 class="about-heading mb_20 ">
                                        <asp:Label ID="lblRefundPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
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
                <asp:Panel ID="pnlBuyBackPolicy" runat="server" Visible="false">
                    <div class="row">
                       <%-- <asp:HiddenField ID="hdnBuyBackPolicyId" runat="server" Value="7" />--%>
                        <asp:Repeater ID="lstBuyBackPolicy" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="about-text">
                                    <h2 class="about-heading mb_20 ">
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
                                <div class="about-text">
                                    <h2 class="about-heading mb_20 ">
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
                                <div class="about-text">
                                     <h2 class="about-heading mb_20 ">
                                        <asp:Label ID="lblShippingPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
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
                <asp:Panel ID="pnlCancellationPolicy" runat="server" Visible="false">
                    <div class="row">
                      <%--  <asp:HiddenField ID="hdnCancellationPolicyId" runat="server" Value="10" />--%>
                        <asp:Repeater ID="lstCancellationPolicy" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="about-text">
                                    <h2 class="about-heading mb_20 ">
                                        <asp:Label ID="lblCancellationPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
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
            </div>
            <div class="col-sm-8 col-lg-9 mtb_20" style="margin-left: 10px;">
                <%--<asp:Panel ID="pnlPrivacyPolicy" runat="server">
                    <div class="row">
                        <asp:HiddenField ID="hdnPrivacyPolicyId" runat="server" Value="3" />
                        <asp:Repeater ID="lstPrivacyPolicy" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="about-text">                                  
                                    <p>
                                        <%#Eval("sContent")%>
                                    </p>                                   
                                </div>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                    </div>
                </asp:Panel>--%>
                
                <!-- contact  -->
                <%--<div class="row">
                    <asp:HiddenField ID="hdnPrivacyPolicyId" runat="server" Value="3" />
                    <asp:Repeater ID="lstPrivacyPolicy" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="about-text">
                             
                                <p>
                                    <%#Eval("sContent")%>
                                </p>                              
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>--%>
                <!-- map  -->
                <%--<div class="row">
                    <div class="col-xs-12 map mb_80">
                        <div id="map"></div>
                    </div>
                </div>--%>
            </div>
        </div>
    </div>

</asp:Content>
