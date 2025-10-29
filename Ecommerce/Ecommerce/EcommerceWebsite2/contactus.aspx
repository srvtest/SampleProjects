<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="contactus.aspx.cs" Inherits="EcommerceWebsite2.contactus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*.formContact {
            margin-left: 60px;
            margin-top: 50px;
        }*/

        .fontcolour {
            color: red;
        }
        /*.labelform{
                margin-left: 100px;
        }*/
        .txtstyle {
            width: 100%;
            height: 40px;
        }

        .textareastyle {
            width: 100%;
            height: 300px;
        }
    </style>
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
                                <li class="breadcrumb-item active">contact us</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- google map start -->
    <div class="map-area section-padding">
        <div id="google-map"></div>
    </div>
    <!-- google map end -->

    <!-- contact area start -->
    <div class="contact-area section-padding pt-0">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="contact-message">
                        <h4 class="contact-title">Tell Us Your Project</h4>
                        <form id="contact-form" action="http://whizthemes.com/mail-php/genger/mail.php" method="post" class="contact-form">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <%--<input id="txtName" name="first_name" placeholder="Name *" type="text" />--%>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="txtstyle" placeholder="Name *"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="send"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <%--<input id="txtPhoneNo" name="phone" placeholder="Phone *" type="text"/>--%>
                                    <asp:TextBox ID="txtPhoneNo" runat="server" TextMode="Phone" CssClass="txtstyle" placeholder="Phone Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtPhoneNo" runat="server" ErrorMessage="Please Enter Phone Number." ValidationGroup="send"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <%--<input id="txtEmail" name="email_address" placeholder="Email *" type="text"/>--%>
                                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="txtstyle" placeholder="Email Address"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please Enter Email Address." ValidationGroup="send"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-6 col-md-6 col-sm-6">
                                    <%--<input id="txtSubject" name="contact_subject" placeholder="Subject *" type="text"/>--%>
                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="txtstyle" placeholder="Subject"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtSubject" runat="server" ErrorMessage="Please Enter Subject." ValidationGroup="send"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-12">
                                    <div class="contact2-textarea text-center">
                                        <%--<textarea id="txtMessage" placeholder="Message *" name="message" class="form-control2"></textarea>--%>
                                        <asp:TextBox ID="txtMessage" class="form-control2 " runat="server" CssClass="textareastyle" TextMode="MultiLine" placeholder="Message"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" ControlToValidate="txtMessage" runat="server" ErrorMessage="Please Enter Message." ValidationGroup="send"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="contact-btn">
                                        <%-- <button class="btn btn-sqr" type="submit">Send Message</button>--%>
                                        <asp:Button ID="btnSend" class="btn btn-sqr" runat="server" Text="Send Message" OnClick="btnSend_Click" ValidationGroup="send" />
                                    </div>
                                </div>
                                <div class="col-12 d-flex justify-content-center">
                                    <p class="form-messege"></p>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="contact-info">
                        <asp:HiddenField ID="hdnContactUsId" runat="server" Value="1" />
                        <asp:Repeater ID="lstContactUs" runat="server">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <h4 class="contact-title">Contact Us</h4>
                                <p>
                                    <%#Eval("sContent")%>
                                </p>
                              <%--<ul>
                                <li><i class="fa fa-fax"></i> Address : No 40 Baria Sreet 133/2 NewYork City</li>
                                <li><i class="fa fa-phone"></i> E-mail: info@yourdomain.com</li>
                                <li><i class="fa fa-envelope-o"></i> +88013245657</li>
                            </ul>--%>
                              <%--<div class="working-time">
                                <h6>Working Hours</h6>
                                <p><span>Monday – Saturday:</span>08AM – 22PM</p>
                            </div>--%>
                            </ItemTemplate>
                            <FooterTemplate></FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- contact area end -->
    <%--<script src="assets/js/googleapijs.js"></script>--%>
    <%--<script src="assets/js/google-map.js"></script>--%>
</asp:Content>
