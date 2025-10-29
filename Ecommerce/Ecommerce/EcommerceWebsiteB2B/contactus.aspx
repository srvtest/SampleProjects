<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="EcommerceWebsiteB2B.contactus" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style>
        .fontcolour {
            color: red;
        }
        /*.txtstyle {
            width: 100%;
            height: 40px;
                margin-bottom: 10px;
        }*/

        /*.textareastyle {
            width: 100%;
            height: 300px;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>contact us</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">contact us</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">contact us</li>
                </ul>
            </div>
        </div>
    </section>
    <section id="contactRow" class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-sm-6">
                    <div class="row m0">
                        <h4 class="contactHeading heading">contact form style</h4>
                    </div>
                    <div class="row m0 contactForm">
                        <div class="row m0" id="contactForm">
                            <div class="row m0 mb15">
                                <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="Name *"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="send" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row m0 mb15">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" TextMode="Email" placeholder="Email Address"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please Enter Email Address." ValidationGroup="send" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row m0 mb15">
                                <asp:TextBox ID="txtSubject" runat="server" class="form-control" placeholder="Subject"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtSubject" runat="server" ErrorMessage="Please Enter Subject." ValidationGroup="send" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="row m0 mb15">
                                <asp:TextBox ID="txtMessage" runat="server" class="form-control" CssClass="" Rows="3" TextMode="MultiLine" placeholder="Message"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" ControlToValidate="txtMessage" runat="server" ErrorMessage="Please Enter Message." ValidationGroup="send" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <asp:Button ID="btnSend" class="btn btn-primary btn-lg filled" runat="server" Text="Send Message" OnClick="btnSend_Click" ValidationGroup="send" />
                        </div>
                        <div id="success">
                            <span class="green textcenter">Your message was sent successfully! I will be in touch as soon as I can.
                            </span>
                        </div>
                        <div id="error">
                            <span>Something went wrong, try refreshing and submitting the form again.
                            </span>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <asp:HiddenField ID="hdnContactUsId" runat="server" Value="1" />
                    <asp:Repeater ID="lstContactUs" runat="server" OnItemCommand="lstContactUs_ItemCommand" OnItemDataBound="lstContactUs_ItemDataBound">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="row m0">
                                <h4 class="contactHeading heading">contact info style</h4>
                            </div>
                            <div class="media contactInfo">
                                <div class="media-left">
                                    <i class="fas fa-map-marker"></i>
                                </div>
                                <div class="media-body">
                                    <h5 class="heading">where to reach us</h5>
                                    <p>You can reach us at the following address:</p>
                                    <h5>
                                        <%#Eval("sContent")%>
                                    </h5>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </section>
    <section id="googleMapRow" class="row">
        <div class="row m0" id="mapBox"></div>
    </section>
    
    <!--Google Maps-->
    <script src="https://maps.googleapis.com/maps/api/js"></script>
    <!--Google Map JS-->
    <script src="<%= this.Master.baseUrl %>js/google-map.js"></script>
</asp:Content>
