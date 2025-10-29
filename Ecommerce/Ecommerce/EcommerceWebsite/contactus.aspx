<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="EcommerceWebsite.contactus" %>

<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .formContact {
            margin-left: 60px;
            margin-top: 50px;
        }

        .fontcolour {
            color: red;
        }
        .labelform{
                margin-left: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Contact Us</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Contact Us</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <%-- <div id="column-left" class="col-sm-4 col-lg-3 hidden-xs">
                <uc1:UCTopCategory runat="server" ID="UCTopCategory" />
                <div class="left_banner left-sidebar-widget mt_30 mb_40">
                    <a href="#">
                        <img src="images/left1.jpg" alt="Left Banner" class="img-responsive" /></a>
                </div>
            </div>--%>

            <%--  <div class="col-sm-8 col-lg-9 mtb_20" style="margin-left: 10px;">--%>

            <!-- contact  -->
            <div class="row">
                <div class="col-sm-3 mb-3 mb-sm-0">

                    <asp:HiddenField ID="hdnContactUsId" runat="server" Value="1" />
                    <asp:Repeater ID="lstContactUs" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="about-text" style="margin-left: 20px;">
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

                </div>
                <%--  <div class="col-md-4 col-xs-12 contact">
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
                    </div>--%>
                <div class="col-sm-8 mb-3 mb-sm-0 ">
                    <div class="card-body">
                        <h2><asp:Label ID="lblContactForm" CssClass="labelform" runat="server" Text="CONTACT FORM"></asp:Label></h2>
                        <div id="contact_form" style="margin-top: 25px; margin-left: 100px;">
                           <%-- <form id="contact_body">--%>
                                <div class="">
                                    
                                    <asp:TextBox ID="txtName" class="full-with-form " runat="server" placeholder="Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="send"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox ID="txtEmail" class="full-with-form " runat="server" TextMode="Email" placeholder="Email Address"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please Enter Email Address." ValidationGroup="send"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox ID="txtPhoneNo" class="full-with-form " runat="server" TextMode="Number" placeholder="Phone Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtPhoneNo" runat="server" ErrorMessage="Please Enter Phone Number." ValidationGroup="send"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox ID="txtSubject" class="full-with-form " runat="server" placeholder="Subject"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtSubject" runat="server" ErrorMessage="Please Enter Subject." ValidationGroup="send"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:TextBox ID="txtMessage" class="full-with-form " runat="server" TextMode="MultiLine" placeholder="Message"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" ControlToValidate="txtMessage" runat="server" ErrorMessage="Please Enter Message." ValidationGroup="send"></asp:RequiredFieldValidator>
                                    
                                </div>
                            <%--</form>--%>
                            <asp:Button ID="btnSend" class="btn mt_30" runat="server" Text="Send Message" OnClick="btnSend_Click" ValidationGroup="send"  />
                            <div id="contact_results"></div>
                        </div>
                    </div>
                    <!-- END Contact FORM -->
                    <%--  </div>--%>
                </div>
            </div>
            <div class="form-group row">
            </div>

            <!-- map  -->
            <%--<div class="row">
                    <div class="col-xs-12 map mb_80">
                        <div id="map"></div>
                    </div>
                </div>--%>

            <%-- </div>--%>
        </div>
    </div>
     <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>
</asp:Content>
