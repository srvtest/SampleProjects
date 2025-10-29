<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="deliveryinformation.aspx.cs" Inherits="EcommerceWebsiteB2B.deliveryinformation" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Delivery Information</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Delivery Information</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">Delivery Information</li>
                </ul>
            </div>
        </div>
    </section>
    <section class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <asp:HiddenField ID="hdnDeliveryInformationId" runat="server" Value="4" />
                    <asp:Repeater ID="lstDeliveryInformation" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <h1>
                                <asp:Label ID="lblDeliveryInformation" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                            </h1>
                            <p><%#Eval("sContent")%></p>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
