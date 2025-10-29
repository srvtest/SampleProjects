<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="additionallink.aspx.cs" Inherits="EcommerceWebsiteB2B.additionallink" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Additional Link</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Additional Link</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">Additional Link</li>
                </ul>
            </div>
        </div>
    </section>
    <section class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdIdProductPrice" runat="server" Value="0" />
                    <asp:HiddenField ID="hdIdAdditionalLink" runat="server" Value="0" />
                    <asp:Repeater ID="lstAdditionalLink" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <h1>
                                <asp:Label ID="lblName" runat="server" ClientIDMode="Static"><%#Eval("Name")%></asp:Label>
                            </h1>
                            <p><%#Eval("sDescription")%>.</p>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
