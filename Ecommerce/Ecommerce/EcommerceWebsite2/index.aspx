<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EcommerceWebsite2.index" %>
<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Src="~/UCBrands.ascx" TagPrefix="uc1" TagName="UCBrands" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .pri-img, .sec-img {
            height: 263px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- hero slider area start -->
    <section class="slider-area">
        <div class="hero-slider-active slick-arrow-style slick-arrow-style_hero slick-dot-style">
            <div class="hero-single-slide hero-overlay">
                <div class="hero-slider-item bg-img">
                    <div id="container">
                        <div class="img1">
                            <img src="../assets/img/banner/50_dici_banner_opt.png" />
                            <div class="content">
                                <span style="font-size: 72px">SUMMER SALE</span>
                                <h3>JULY 15TH - AUGUST 30TH</h3>
                                <br />
                                <asp:Button ID="btnLearnMore" runat="server" CssClass="btn btn-sqr" Text="Shop Now" OnClick="btnLearnMore_Click" />
                                <%--<button class="btn btn-sqr" onclick="">Learn More</button>--%>
                            </div>
                        </div>
                        <div class="img2">
                            <img src="../assets/img/banner/ring_1.png" />
                        </div>
                        <div class="img3">
                            <img src="../assets/img/banner/ring_2.png" />
                        </div>
                        <div class="img4">
                            <img src="../assets/img/banner/ring_2.png" />
                        </div>
                        <div class="img5">
                            <img src="../assets/img/banner/ring_3.png" />
                        </div>
                        <div class="img6">
                            <img src="../assets/img/banner/ring_3.png" />
                        </div>
                        <div class="img7">
                            <img src="../assets/img/banner/ring_6.png" />
                        </div>
                        <!-- <div class="slide one"></div> -->
                    </div>
                </div>
            </div>
            <asp:Repeater ID="pgBanner" runat="server">
                <ItemTemplate>
                    <!-- single slider item start -->
                    <div class="hero-single-slide hero-overlay">
                        <div class="hero-slider-item bg-img" data-bg="<%=DataLayer.CommonControl.GetAdminUrl() %>/Images/HomeSlider/<%#Eval("ImageURL")%>">
                        </div>
                    </div>
                    <!-- single slider item start -->
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
    <!-- hero slider area end -->

    <!-- service policy area start -->
    <div class="service-policy section-padding">
        <div class="container">
            <div class="row mtn-30">
                <div class="col-sm-6 col-lg-3">
                    <div class="policy-item">
                        <div class="policy-icon">
                            <i class="pe-7s-plane"></i>
                        </div>
                        <div class="policy-content">
                            <h6>Free Shipping</h6>
                            <p>Free shipping all order</p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3">
                    <div class="policy-item">
                        <div class="policy-icon">
                            <i class="pe-7s-help2"></i>
                        </div>
                        <div class="policy-content">
                            <h6>Support 24/7</h6>
                            <p>Support 24 hours a day</p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3">
                    <div class="policy-item">
                        <div class="policy-icon">
                            <i class="pe-7s-back"></i>
                        </div>
                        <div class="policy-content">
                            <h6>Money Return</h6>
                            <p>30 days for free return</p>
                        </div>
                    </div>
                </div>
                <div class="col-sm-6 col-lg-3">
                    <div class="policy-item">
                        <div class="policy-icon">
                            <i class="pe-7s-credit"></i>
                        </div>
                        <div class="policy-content">
                            <h6>100% Payment Secure</h6>
                            <p>We ensure secure payment</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- service policy area end -->

    <!-- new arrival product area start -->
    <asp:Panel ID="pnlNewArrival" runat="server">
        <section class="feature-product">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <!-- section title start -->
                        <div class="section-title text-center">
                            <h2 class="title">new arrival products</h2>
                            <p class="sub-title">This is new arrival products.</p>
                        </div>
                        <!-- section title start -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="product-carousel-4 slick-row-10 slick-arrow-style">
                            <asp:Repeater ID="rptNewArrivals" runat="server" OnItemCommand="pnl_ItemCommand">
                                <ItemTemplate>

                                    <!-- product item start -->
                                    <div class="product-item">
                                        <asp:HiddenField ID="hdnIdProduct" runat="server" Value='<%#Eval("idProduct") %>' />
                                        <figure class="product-thumb">
                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                <img class="pri-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                                <img class="sec-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                            </a>
                                            <div class="product-badge">
                                                <%# Convert.ToBoolean(Eval("isNew")) ? "<div class='product-label new'><span>new</span></div>" : "" %>

                                                <div class="product-label discount">
                                                    <span><%# Eval("Discount") %>%</span>
                                                </div>
                                            </div>
                                            <div class="button-group">
                                                 <div class="wishlist">
                                                      <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? "fa fa-heart" : "fa fa-heart-o" %>"></i></asp:LinkButton>
                                                     </div>
                                                <%--<a href="wishlist.html" data-toggle="tooltip" data-placement="left" title="Add to wishlist"><i class="pe-7s-like"></i></a>--%> 
                                                <%--<a href="compare.html" data-toggle="tooltip" data-placement="left" title="Add to Compare"><i class="pe-7s-refresh-2"></i></a>--%>
                                                <%--<a href="#" data-toggle="modal" data-target="#quick_view"><span data-toggle="tooltip" data-placement="left" title="Quick View"><i class="pe-7s-search"></i></span></a>--%>
                                               <div class="quickview">
                                                   <a href="../ProductDetail/<%#Eval("SEOName")%>" title="Quick View"><i class="pe-7s-search"></i></a>
                                               </div>
                                                  
                                            </div>
                                            <div class="cart-hover">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart" class="btn btn-cart">add to cart</asp:LinkButton>
                                            </div>
                                        </figure>
                                        <div class="product-caption text-center">
                                            <div class="product-identity">
                                                <p class="manufacturer-name"><a href="#"><%# Eval("MaterialName") %></a></p>
                                            </div>
                                            <ul class="color-categories">
                                                <%--<asp:Repeater ID="rptColor" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a class='c-<%# Eval("sName") %>' href="#" title='<%# Eval("sTitle") %>'></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>--%>
                                                <li>
                                                    <a class="c-lightblue" href="#" title="LightSteelblue"></a>
                                                </li>
                                                <li>
                                                    <a class="c-darktan" href="#" title="Darktan"></a>
                                                </li>
                                                <li>
                                                    <a class="c-grey" href="#" title="Grey"></a>
                                                </li>
                                                <li>
                                                    <a class="c-brown" href="#" title="Brown"></a>
                                                </li>
                                            </ul>
                                            <h6 class="product-name">
                                                <a href="../ProductDetail/<%#Eval("SEOName")%>" title="<%#Eval("sName")%>"><%#Eval("sName")%></a>
                                            </h6>
                                            <div class="price-box">
                                                <span class="price-regular"><%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></span>
                                                <span class="price-old"><del><%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %></del></span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- product item end -->
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!-- new arrival product area end -->

    <!-- group product start -->
    <section class="group-product-area section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-4">
                    <div class="group-product-banner">
                        <figure class="banner-statistics">
                            <a href="javascript:void(0);">
                                <img src="../assets/img/banner/banner_1.jpg" alt="product banner" />
                            </a>
                        </figure>
                    </div>
                </div>
                <div class="col-lg-8">
                    <div class="group-product-banner">
                        <figure class="banner-statistics">
                            <a href="javascript:void(0);">
                                <img src="../assets/img/banner/banner2.jpg" alt="product banner" />
                            </a>
                            <div class="banner-content banner-content_style3 text-center">
                                <h6 class="banner-text1">BEAUTIFUL</h6>
                                <h2 class="banner-text2">Wedding Rings</h2>
                                <a href="../products/category=Rings" class="btn btn-text">Shop Now</a>
                            </div>
                        </figure>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- group product end -->

    <!-- best seller product area start -->
    <asp:Panel ID="pnlBestSeller" runat="server">
        <section class="feature-product">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <!-- section title start -->
                        <div class="section-title text-center">
                            <h2 class="title">Best sellers</h2>
                            <p class="sub-title">This is a best sellers.</p>
                        </div>
                        <!-- section title start -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="product-carousel-4 slick-row-10 slick-arrow-style">
                            <asp:Repeater ID="rptBestSeller" runat="server" OnItemCommand="pnl_ItemCommand">
                                <ItemTemplate>

                                    <!-- product item start -->
                                    <div class="product-item">
                                        <asp:HiddenField ID="hdnIdProduct" runat="server" Value='<%#Eval("idProduct") %>' />
                                        <figure class="product-thumb">
                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                <img class="pri-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                                <img class="sec-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                            </a>
                                            <div class="product-badge">
                                                <%# Convert.ToBoolean(Eval("isNew")) ? "<div class='product-label new'><span>new</span></div>" : "" %>
                                                <div class="product-label discount">
                                                    <span><%# Eval("Discount") %>%</span>
                                                </div>
                                            </div>
                                            <div class="button-group">
                                                <%--<a href="wishlist.html" data-toggle="tooltip" data-placement="left" title="Add to wishlist"><i class="pe-7s-like"></i></a>--%>
                                               
                                                <%--<a href="compare.html" data-toggle="tooltip" data-placement="left" title="Add to Compare"><i class="pe-7s-refresh-2"></i></a>--%>
                                                <%--<a href="#" data-toggle="modal" data-target="#quick_view"><span data-toggle="tooltip" data-placement="left" title="Quick View"><i class="pe-7s-search"></i></span></a>--%>
                                                
                                                <div class="wishlist">
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? "fa fa-heart" : "fa fa-heart-o" %>"></i></asp:LinkButton>
                                                        </div>
                                                        <div class="quickview">
                                                           <a href="../ProductDetail/<%#Eval("SEOName")%>" title="Quick View"><i class="pe-7s-search"></i></a>
                                                        </div>
                                            </div>
                                            <div class="cart-hover">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart" class="btn btn-cart">add to cart</asp:LinkButton>
                                            </div>
                                        </figure>
                                        <div class="product-caption text-center">
                                            <div class="product-identity">
                                                <p class="manufacturer-name"><a href="#"><%# Eval("MaterialName") %></a></p>
                                            </div>
                                            <ul class="color-categories">
                                                <%--<asp:Repeater ID="rptColor" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a class='c-<%# Eval("sName") %>' href="#" title='<%# Eval("sTitle") %>'></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>--%>
                                                <li>
                                                    <a class="c-lightblue" href="#" title="LightSteelblue"></a>
                                                </li>
                                                <li>
                                                    <a class="c-darktan" href="#" title="Darktan"></a>
                                                </li>
                                                <li>
                                                    <a class="c-grey" href="#" title="Grey"></a>
                                                </li>
                                                <li>
                                                    <a class="c-brown" href="#" title="Brown"></a>
                                                </li>
                                            </ul>
                                            <h6 class="product-name">
                                                <a href="../ProductDetail/<%#Eval("SEOName")%>" title="<%#Eval("sName")%>"><%#Eval("sName")%></a>
                                            </h6>
                                            <div class="price-box">
                                                <span class="price-regular"><%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></span>
                                                <span class="price-old"><del><%=((main_master)this.Page.Master).CurrencySymbol %>
                                                    <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %></del></span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- product item end -->
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!-- best seller product area end -->

    <!-- featured product area start -->
    <asp:Panel ID="pnlFeatured" runat="server">
        <section class="feature-product section-padding">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <!-- section title start -->
                        <div class="section-title text-center">
                            <h2 class="title">featured products</h2>
                            <p class="sub-title">Add featured products to weekly lineup</p>
                        </div>
                        <!-- section title start -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="product-carousel-4 slick-row-10 slick-arrow-style">
                            <asp:Repeater ID="rptFeatured" runat="server" OnItemCommand="pnl_ItemCommand">
                                <ItemTemplate>
                                    <!-- product item start -->
                                    <div class="product-item">
                                        <asp:HiddenField ID="hdnIdProduct" runat="server" Value='<%#Eval("idProduct") %>' />
                                        <figure class="product-thumb">
                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                <img class="pri-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                                <img class="sec-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                            </a>
                                            <div class="product-badge">
                                                <%# Convert.ToBoolean(Eval("isNew")) ? "<div class='product-label new'><span>new</span></div>" : "" %>
                                                <div class="product-label discount">
                                                    <span><%# Eval("Discount") %>%</span>
                                                </div>
                                            </div>
                                            <div class="button-group">
                                               
                                               
                                                <div class="wishlist">
                                                             <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? "fa fa-heart" : "fa fa-heart-o" %>"></i></asp:LinkButton>
                                                        </div>
                                                        <div class="quickview">
                                                           <a href="../ProductDetail/<%#Eval("SEOName")%>" title="Quick View"><i class="pe-7s-search"></i></a>
                                                        </div>
                                            </div>
                                            <div class="cart-hover">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart" class="btn btn-cart">add to cart</asp:LinkButton>
                                            </div>
                                        </figure>
                                        <div class="product-caption text-center">
                                            <div class="product-identity">
                                                <p class="manufacturer-name"><a href="#"><%# Eval("MaterialName") %></a></p>
                                            </div>
                                            <ul class="color-categories">
                                                <%--<asp:Repeater ID="rptColor" runat="server">
                                                    <ItemTemplate>
                                                        <li>
                                                            <a class='c-<%# Eval("sName") %>' href="#" title='<%# Eval("sTitle") %>'></a>
                                                        </li>
                                                    </ItemTemplate>
                                                </asp:Repeater>--%>
                                                <li>
                                                    <a class="c-lightblue" href="#" title="LightSteelblue"></a>
                                                </li>
                                                <li>
                                                    <a class="c-darktan" href="#" title="Darktan"></a>
                                                </li>
                                                <li>
                                                    <a class="c-grey" href="#" title="Grey"></a>
                                                </li>
                                                <li>
                                                    <a class="c-brown" href="#" title="Brown"></a>
                                                </li>
                                            </ul>
                                            <h6 class="product-name">
                                                <a href="../ProductDetail/<%#Eval("SEOName")%>" title="<%#Eval("sName")%>"><%#Eval("sName")%></a>
                                            </h6>
                                            <div class="price-box">
                                                <span class="price-regular"><%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></span>
                                                <span class="price-old"><del><%=((main_master)this.Page.Master).CurrencySymbol %>
                                                    <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %></del></span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- product item end -->
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!-- featured product area end -->

    <!-- group product start -->
    <section class="group-product-area">
        <div class="container">
            <div class="row">
                <div class="col-lg-6">
                    <div class="group-product-banner">
                        <figure class="banner-statistics">
                            <a href="javascript:void(0);">
                                <img src="../assets/img/banner/main_b_1_gg.jpg" alt="product banner" />
                            </a>
                            <div class="banner-content banner-content_style3 text-center">
                                <h6 class="banner-text1">She Said</h6>
                                <h2 class="banner-text2">"YES"</h2>
                                <a href="../products/category=Rings" class="btn btn-text">Shop Now</a>
                            </div>
                        </figure>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="group-product-banner">
                        <figure class="banner-statistics">
                            <a href="javascript:void(0);">
                                <img src="../assets/img/banner/main_b_2_m_m.jpg" alt="product banner" />
                            </a>
                            <div class="banner-content banner-content_style2 text-center" style="top: 45px">
                                <h6 class="banner-text1">Happy Ever After</h6>
                                <a href="../products/category=Rings" class="btn btn-text">Click here</a>
                            </div>
                        </figure>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- group product end -->

    <!-- banner statistics area start -->
    <div class="banner-statistics-area section-padding">
        <div class="container">
            <div class="row row-20 mtn-20">
                <div class="col-sm-6">
                    <figure class="banner-statistics mt-20">
                        <a href="../products/category=Rings">
                            <img height="250" src="../images/Ring.jpg" alt="Sub Banner1" />
                        </a>
                        <div class="banner-content text-right">
                            <h5 class="banner-text1">Ring</h5>
                            <h2 class="banner-text2" style="text-align: right;">Wedding<span>Rings</span></h2>
                            <a href="../products/category=Rings" class="btn btn-text">Shop Now</a>
                        </div>
                    </figure>
                </div>
                <div class="col-sm-6">
                    <figure class="banner-statistics mt-20">
                        <a href="../products/category=Earrings">
                            <img height="250" src="../images/Earring.jpg" alt="Sub Banner2" />
                        </a>
                        <div class="banner-content text-right">
                            <h5 class="banner-text1">Earrings</h5>
                            <h2 class="banner-text2" style="text-align: right;">Tangerine Floral<span>Earring</span></h2>
                            <a href="../products/category=Earrings" class="btn btn-text">Shop Now</a>
                        </div>
                    </figure>
                </div>
                <div class="col-sm-6">
                    <figure class="banner-statistics mt-20">
                        <a href="../products/category=Chains">
                            <img height="250" src="images/necklace2.jpg" alt="Sub Banner4" />
                        </a>
                        <div class="banner-content text-right">
                            <h5 class="banner-text1">Necklace</h5>
                            <h2 class="banner-text2" style="text-align: right;">Pearl<span>Necklaces</span></h2>
                            <a href="../products/category=Chains" class="btn btn-text">Shop Now</a>
                        </div>
                    </figure>
                </div>
                <div class="col-sm-6">
                    <figure class="banner-statistics mt-20">
                        <a href="../products/category=Pendants">
                            <img height="250" src="images/necklace.jpg" alt="Sub Banner5" />
                        </a>
                        <div class="banner-content text-right">
                            <h5 class="banner-text1">Pendant</h5>
                            <h2 class="banner-text2" style="text-align: right;">Diamond<span>Jewelry</span></h2>
                            <a href="../products/category=Pendants" class="btn btn-text">Shop Now</a>
                        </div>
                    </figure>
                </div>
            </div>
        </div>
    </div>
    <!-- banner statistics area end -->

    <!-- latest blog area start -->
    <asp:Panel ID="pnlBlogs" runat="server">
        <section class="latest-blog-area section-padding" style="padding-top: 0">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <!-- section title start -->
                        <div class="section-title text-center">
                            <h2 class="title">latest blogs</h2>
                            <p class="sub-title">There are latest blog posts</p>
                        </div>
                        <!-- section title start -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="blog-carousel-active slick-row-10 slick-arrow-style">
                            <asp:Repeater ID="rptBlogs" runat="server">
                                <ItemTemplate>
                                    <!-- blog post item start -->
                                    <div class="blog-post-item">
                                        <figure class="blog-thumb">
                                            <a href='Blog/<%#Eval("Name")%>'>
                                                <img height="220" src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>' alt="blog image">
                                            </a>
                                        </figure>
                                        <div class="blog-content">
                                            <div class="blog-meta">
                                                <p><%# Convert.ToDateTime(Eval("CreatedDate")).ToShortDateString() %> | <a href="#">Silver Rock Creation</a></p>
                                            </div>
                                            <h5 class="blog-title">
                                                <a href='Blog/<%#Eval("Name")%>'><%#Eval("Name")%></a>
                                            </h5>
                                        </div>
                                    </div>
                                    <!-- blog post item end -->
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!-- latest blog area end -->

    <!-- brand logo area start -->
    <asp:Panel ID="pnlBrands" runat="server" Visible="false">
        <uc1:UCBrands runat="server" ID="UCBrands" />
    </asp:Panel>
    <!-- brand logo area end -->
    <script>
        //$(document).on('click', 'ul li', function () {
        //    $(this).addClass('active').siblings().removeClass('active')
        //});
        //const currentlocation = location.href;
        //const menuitem = document.querySelectorAll('a');
        //const menulenth = menuitem.length;
        //for (let i = 0; i < menulenth; i++) {
        //    if (menuitem[i].href === currentlocation) {
        //        menuitem[i].className = "active"
        //    }
        //}
        //function refreshPage() {
        //    debugger;
        //    var page_y = $( document ).scrollTop;
        //    window.location.href = window.location.href.split('?')[0] + '?page_y=' + page_y;
        //}
        //window.onload = function () {
        //    setTimeout(refreshPage, 35000);
        //    if (window.location.href.indexOf('page_y') != -1) {
        //        var match = window.location.href.split('?')[1].split("&")[0].split("=");
        //        document.getElementsByTagName("body")[0].scrollTop = match[1];
        //    }
        //}
        //$(window).scroll(function () {
        //    sessionStorage.scrollTop = $(this).scrollTop();
        //});

        //$(document).ready(function () {
        //    if (sessionStorage.scrollTop != "undefined") {
        //        $(window).scrollTop(sessionStorage.scrollTop);
        //    }
        //});
    </script>
</asp:Content>
