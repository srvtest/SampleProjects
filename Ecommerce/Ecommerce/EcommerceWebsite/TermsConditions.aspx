<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TermsConditions.aspx.cs" Inherits="EcommerceWebsite.TermsConditions" %>
<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Terms & Conditions</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Terms & Conditions</li>
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
            <div class="col-sm-8 col-lg-9 mtb_20" style="margin-left:10px;">
                <!-- contact  -->
                <div class="row">
                    <asp:HiddenField ID="hdnTermsConditionsId" runat="server" Value="5" />
                    <asp:Repeater ID="lstTermsConditions" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="about-text">
                               <%-- <div class="about-heading-wrap">
                                    <h2 class="about-heading mb_20 ">
                                        <asp:Label ID="lblAboutUs" runat="server" Text='<%#Eval("sMasterPage")%>'></asp:Label>
                                    </h2>
                                </div>--%>
                                <p>
                                    <%#Eval("sContent")%>
                                </p>
                                <%--<button type="button" class="btn mt_30">HIRE ME</button>--%>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                    <%-- <div class="col-md-4 col-xs-12 contact">
                        <div class="location mb_50">
                            <h5 class="capitalize mb_20"><strong>Our Location</strong></h5>
                            <div class="address">
                                Office address
                  <br>
                                124,Lorem Ipsum has been
                  <br>
                                text ever since the 1500
                            </div>
                            <div class="call mt_10"><i class="fa fa-phone" aria-hidden="true"></i>+91-9987-654-321</div>
                        </div>
                        <div class="Career mb_50">
                            <h5 class="capitalize mb_20"><strong>Careers</strong></h5>
                            <div class="address">dummy text ever since the 1500s, simply dummy text of the typesetting industry. </div>
                            <div class="email mt_10"><i class="fa fa-envelope" aria-hidden="true"></i><a href="mailto:careers@yourdomain.com" target="_top">careers@yourdomain.com</a></div>
                        </div>
                        <div class="Hello mb_50">
                            <h5 class="capitalize mb_20"><strong>Say Hello</strong></h5>
                            <div class="address">simply dummy text of the printing and typesetting industry.</div>
                            <div class="email mt_10"><i class="fa fa-envelope" aria-hidden="true"></i><a href="mailto:info@yourdomailname.com" target="_top">info@yourdomailname.com</a></div>
                        </div>
                    </div>
                    <div class="col-md-8 col-xs-12 contact-form mb_50">
                        <!-- Contact FORM -->
                        <div id="contact_form">
                            <form id="contact_body" method="post" action="http://html.lionode.com/queenok/contact_me.php">
                                <!--                                <label class="full-with-form" ><span>Name</span></label>
-->
                                <input class="full-with-form " type="text" name="name" placeholder="Name" data-required="true" />
                                <!--                <label class="full-with-form" ><span>Email Address</span></label>
-->
                                <input class="full-with-form  mt_30" type="email" name="email" placeholder="Email Address" data-required="true" />
                                <!--                <label class="full-with-form" ><span>Phone Number</span></label>
-->
                                <input class="full-with-form  mt_30" type="text" name="phone1" placeholder="Phone Number" maxlength="15" data-required="true" />
                                <!--                <label class="full-with-form" ><span>Subject</span></label>
-->
                                <input class="full-with-form  mt_30" type="text" name="subject" placeholder="Subject" data-required="true">
                                <!--                                <label class="full-with-form" ><span>Attachment</span></label>
-->
                                <!--                                <label class="full-with-form" ><span>Message</span></label>
-->
                                <textarea class="full-with-form  mt_30" name="message" placeholder="Message" data-required="true"></textarea>
                                <button class="btn mt_30" type="submit">Send Message</button>
                            </form>
                            <div id="contact_results"></div>
                        </div>
                        <!-- END Contact FORM -->
                    </div>--%>
                </div>
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