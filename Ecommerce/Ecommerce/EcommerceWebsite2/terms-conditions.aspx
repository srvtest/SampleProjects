<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="terms-conditions.aspx.cs" Inherits="EcommerceWebsite2.TermsConditions" %>

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
    <div class="my-account-wrapper section-padding">
        <div class="container">
            <div class="section-bg-color">
                <div class="row">
                    <div class="col-lg-12">
                        <!-- My Account Page Start -->
                        <div class="myaccount-page-wrapper">
                            <!-- My Account Tab Menu Start -->
                            <div class="row">
                                <div class="col-lg-12 col-md-8">
                                    <div class="tab-content" id="myaccountContent">
                                        <!-- Single Tab Content Start -->
                                        <asp:HiddenField ID="hdnTermsConditionsId" runat="server" Value="5" />
                                        <asp:Repeater ID="lstTermsConditions" runat="server">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%--<div class="tab-pane fade show active" id="dashboad" role="tabpanel">--%>
                                                <div class="myaccount-content">
                                                    <h5> <asp:Label ID="lblTermsConditions" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label></h5>
                                                    <%--<div class="welcome">
                                                        <p>
                                                            Hello, <strong>Erik Jhonson</strong> (If Not <strong>Jhonson
                                                            !</strong><a href="login-register.html" class="logout"> Logout</a>)
                                                        </p>
                                                    </div>--%>
                                                    <p class="mb-0">
                                                        <%#Eval("sContent")%>
                                                    </p>
                                                </div>
                                                <%--  </div>--%>
                                            </ItemTemplate>
                                            <FooterTemplate></FooterTemplate>
                                        </asp:Repeater>
                                        <!-- Single Tab Content End -->
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
