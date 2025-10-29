<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="verification.aspx.cs" Inherits="EcommerceWebsite2.verification" %>

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
                                <li class="breadcrumb-item active" aria-current="page">Verification</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- breadcrumb area end -->
    <div class="my-account-wrapper section-padding">
        <div class="container">
            <div class="section-bg-color">
                <div class="row">
                    <div class="col-lg-12">
                        <!-- My Account Page Start -->
                        <div class="myaccount-page-wrapper">
                            <!-- My Account Tab Menu Start -->
                            <asp:Panel ID="pnlSuccess" runat="server">
                                <div class="row">
                                    <div class="col-lg-12 col-md-8">
                                        <div class="tab-content" id="myaccountContent">
                                            <!-- Single Tab Content Start -->

                                            <%-- <div class="tab-pane fade show active" id="dashboad" role="tabpanel">--%>
                                            <div class="myaccount-content">
                                                <h5>
                                                    <asp:Label ID="lblHMessage" runat="server"></asp:Label></h5>
                                                <div class="welcome">
                                                    <p>
                                                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                                <div></div>
                                                <p class="mb-0">
                                                    Click here to login: <a href="../login">Click here</a>
                                                </p>

                                            </div>
                                            <%--</div>--%>

                                            <!-- Single Tab Content End -->
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlFailed" runat="server">
                                <div class="row">
                                    <div class="col-lg-12 col-md-8">
                                        <div class="tab-content" id="myContent">
                                            <!-- Single Tab Content Start -->

                                            <%-- <div class="tab-pane fade show active" id="dashboad" role="tabpanel">--%>
                                            <div class="myaccount-content">
                                                <h5>
                                                    <asp:Label ID="lblHMsg" runat="server"></asp:Label></h5>
                                                <div class="welcome">
                                                    <p>
                                                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                                    </p>
                                                </div>
                                                <div></div>
                                                <%--<p class="mb-0">
                                                Click here to login: <a href="../login">Click here</a>
                                            </p>--%>
                                            </div>
                                            <%--</div>--%>

                                            <!-- Single Tab Content End -->
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
