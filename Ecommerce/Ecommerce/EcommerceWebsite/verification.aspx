<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="verification.aspx.cs" Inherits="EcommerceWebsite.verification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .modal-title {
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Shopping Cart</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">User Verification</li>
                    </ul>
                </div>
            </div>
            <div class="col-sm-8 col-lg-9 mtb_20" style="margin-left: 10px;">
                <div class="panel-group">
                    <asp:Panel ID="Pnl4" runat="server" CssClass="panel panel-default">
                        <div class="panel-heading">
                        </div>
                        <div class="panel-collapse collapse in">
                            <div class="panel-body">
                                <div class="col-sm-12 mb-3 mb-sm-0" style="margin-bottom: 20px;">
                                    <div class="cust-address">
                                        <div class="card-body">
                                            <center>
                                                <br />
                                            <h3><strong><asp:Label ID="lblHMessage" runat="server"></asp:Label></strong></h3>
                                            <h5><strong><asp:Label ID="lblMessage" runat="server"></asp:Label></strong></h5>
                                                <br />
                                            Click here to login: <a href="../login">Click here</a><br /><br />
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
