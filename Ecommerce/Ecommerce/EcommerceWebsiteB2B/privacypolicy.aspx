<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="privacypolicy.aspx.cs" Inherits="EcommerceWebsiteB2B.privacypolicy" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .libtn {
            background-color: white;
            border: none;
        }

        li {
            margin-bottom: 10px;
        }
         #accountRow .left-sidebar li {
            margin: 10px auto;
        }

            #accountRow .left-sidebar li a {
                color: #fd405e;
                padding: 6px;
                font-size: 17px;
                display: block;
                border: 1px solid #c3c3c3;
            }

                #accountRow .left-sidebar li a:hover {
                    border: 1px solid #fd405e;
                }

            #accountRow .left-sidebar li.selected {
                background: #fd405e;
            }

                #accountRow .left-sidebar li.selected a {
                    color: #fff;
                    border: 1px solid #fd405e;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Privacy Policy</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Privacy Policy</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">Privacy Policy</li>
                </ul>
            </div>
        </div>
    </section>
    <section id="accountRow" class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="left-sidebar col-lg-3 col-md-4">
                            <ul style="list-style: none;">
                                <li class="selected">
                                    <asp:LinkButton ID="btnPrivacyPolicy" OnClick="btnPrivacyPolicy_Click" runat="server">Privacy Policy</asp:LinkButton>
                                </li>
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
                        <div class="col-lg-9 col-md-8">
                            <asp:Panel ID="pnlPrivacyPolicy" runat="server">
                                <asp:Repeater ID="lstPrivacyPolicy" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblPrivacyPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                        </h1>
                                        <p>
                                            <%#Eval("sContent")%>
                                        </p>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <asp:Panel ID="pnlRefundPolicy" runat="server" Visible="false">
                                <asp:Repeater ID="lstRefundPolicy" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblRefundPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                        </h1>
                                        <p>
                                            <%#Eval("sContent")%>
                                        </p>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <asp:Panel ID="pnlBuyBackPolicy" runat="server" Visible="false">
                                <asp:Repeater ID="lstBuyBackPolicy" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblBuyBackPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                        </h1>
                                        <p>
                                            <%#Eval("sContent")%>
                                        </p>
                                        </div>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <asp:Panel ID="pnlExchangePolicy" runat="server" Visible="false">
                                <asp:Repeater ID="lstExchangePolicy" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblExchangePolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                        </h1>
                                        <p>
                                            <%#Eval("sContent")%>
                                        </p>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <asp:Panel ID="pnlShippingPolicy" runat="server" Visible="false">
                                <asp:Repeater ID="lstShippingPolicy" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblShippingPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                        </h1>
                                        <p>
                                            <%#Eval("sContent")%>
                                        </p>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                            <asp:Panel ID="pnlCancellationPolicy" runat="server" Visible="false">
                                <asp:Repeater ID="lstCancellationPolicy" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCancellationPolicy" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                        </h1>
                                        <p>
                                            <%#Eval("sContent")%>
                                        </p>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
     <script type="text/javascript">
        $(document).ready(function () {
            var pnlPrivacyPolicy = document.getElementById("<%= pnlPrivacyPolicy.ClientID %>");
            var pnlRefundPolicy = document.getElementById("<%= pnlRefundPolicy.ClientID %>");
            var pnlBuyBackPolicy = document.getElementById("<%= pnlBuyBackPolicy.ClientID %>");
            var pnlExchangePolicy = document.getElementById("<%= pnlExchangePolicy.ClientID %>");
            var pnlShippingPolicy = document.getElementById("<%= pnlShippingPolicy.ClientID %>");
            var pnlCancellationPolicy = document.getElementById("<%= pnlCancellationPolicy.ClientID %>");
            $("#accountRow .left-sidebar ul li").removeClass("selected");
            if (pnlPrivacyPolicy) {
                $("#accountRow .left-sidebar ul li:eq(0)").addClass("selected");
            }
            else if (pnlRefundPolicy) {
                $("#accountRow .left-sidebar ul li:eq(1)").addClass("selected");
            }
            else if (pnlBuyBackPolicy) {
                $("#accountRow .left-sidebar ul li:eq(2)").addClass("selected");
            }
            else if (pnlExchangePolicy) {
                $("#accountRow .left-sidebar ul li:eq(3)").addClass("selected");
            }
            else if (pnlShippingPolicy) {
                $("#accountRow .left-sidebar ul li:eq(4)").addClass("selected");
            }
            else if (pnlCancellationPolicy) {
                $("#accountRow .left-sidebar ul li:eq(5)").addClass("selected");
            }
           
            
        });
        

    </script>
</asp:Content>
