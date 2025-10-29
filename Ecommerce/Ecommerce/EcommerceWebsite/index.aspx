<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="EcommerceWebsite.index" MaintainScrollPositionOnPostback="true" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Src="~/UCbrandcarouse.ascx" TagPrefix="uc1" TagName="UCbrandcarouse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .slidersize {
            width: 100%;
            height: 550px;
        }

        .subbtn {
            width: 94px;
        }

        .fontcolour {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- =====  BANNER STRAT  ===== -->
    <div class="banner slidersize">
        <%-- <div class="banner" style="width:100%;" >--%>
        <asp:Repeater ID="pgBanner" runat="server">
            <HeaderTemplate>
                <div class="main-banner owl-carousel">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="item">
                    <a href="<%#Eval("URL")%>" target="_blank">
                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/Images/HomeSlider/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" class="img-responsive" /></a>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <!-- =====  BANNER END  ===== -->
    <div class="container">
        <div class="row ">
            <div class="col-sm-12 mtb_10">
                <!-- =====  PRODUCT TAB  ===== -->
                <div id="product-tab" class="mt_50">
                    <div class="heading-part mb_10 ">
                        <h2 class="main_title">New Arrivals</h2>
                    </div>
                    <div class="tab-content clearfix box">
                        <div class="tab-pane active" id="nArrivals">
                            <asp:Repeater ID="pnlnArrivals" runat="server" OnItemCommand="pnl_ItemCommand">
                                <HeaderTemplate>
                                    <div class="nArrivals owl-carousel">
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <div class="product-grid">
                                        <div class="item">
                                            <div class="product-thumb">
                                                <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                                                <div class="image product-imageblock">
                                                    <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                        <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                    </a>
                                                    <div class="button-group text-center">
                                                        <div class="wishlist">
                                                            <%-- <a href="../WishList"><span>wishlist</span></a>--%>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                        </div>
                                                        <div class="quickview">
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>"><span>Quick View</span>
                                                                <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />
                                                                <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />

                                                            </a>
                                                        </div>
                                                        <%-- <div class="compare"><a href="#"><span>Compare</span></a></div>--%>
                                                        <div class="add-to-cart">
                                                            <%-- <a href="cartpage.aspx"><span>Add to cart</span></a>--%>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                                <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                    <div class="caption product-detail text-center">
                                                        <h6 data-name="product_name" class="product-name mt_20"><a href="../ProductDetail/<%#Eval("SEOName")%>" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a></h6>
                                                        <div class="rating">
                                                            <span class="fa fa-stack">
                                                                <i class="fa fa-star-o fa-stack-1x"></i>
                                                                <i class="fa fa-star fa-stack-1x"></i>
                                                            </span>
                                                            <span class="fa fa-stack">
                                                                <i class="fa fa-star-o fa-stack-1x"></i>
                                                                <i class="fa fa-star fa-stack-1x"></i>
                                                            </span>
                                                            <span class="fa fa-stack">
                                                                <i class="fa fa-star-o fa-stack-1x"></i>
                                                                <i class="fa fa-star fa-stack-1x"></i>
                                                            </span>
                                                            <span class="fa fa-stack">
                                                                <i class="fa fa-star-o fa-stack-1x"></i>
                                                                <i class="fa fa-star fa-stack-1x"></i>
                                                            </span>
                                                            <span class="fa fa-stack">
                                                                <i class="fa fa-star-o fa-stack-1x"></i>
                                                                <i class="fa fa-star fa-stack-x"></i>
                                                            </span>
                                                        </div>
                                                        <span class="price">
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <span class="amount">
                                                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                                    <%#Eval("PurchasePrice")%>  
                                                                </span>
                                                            </a>
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                                                <span style="text-decoration: line-through; font-size: small;">
                                                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                                    <%#Eval("ProductPrice")%>
                                                                </span>
                                                            </a>
                                                            <br />
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <span style="font-size: small;">You Save: <%#Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))%> (<%#Eval("Discount")%>%)</span>
                                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                                                            </a>
                                                        </span>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>


                    </div>
                </div>

                <div id="product-tab" class="mt_50">
                    <div class="heading-part mb_10 ">
                        <h2 class="main_title">Bestsellers</h2>
                    </div>

                    <div class="tab-content clearfix box">
                        <div class="tab-pane active" id="Bestsellers">
                            <asp:Repeater ID="pnlBestSeller" runat="server" OnItemCommand="pnl_ItemCommand">
                                <HeaderTemplate>
                                    <div class="Bestsellers owl-carousel">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="product-grid">
                                        <div class="item">
                                            <div class="product-thumb  mb_30">
                                                <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                                                <div class="image product-imageblock">
                                                    <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                        <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                    </a>
                                                    <div class="button-group text-center">
                                                        <div class="wishlist">
                                                            <%-- <a href="../WishList"><span>wishlist</span></a>--%>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                        </div>
                                                        <div class="quickview">
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>"><span>Quick View</span>
                                                                <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />
                                                                <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />

                                                            </a>
                                                        </div>
                                                        <%--    <div class="compare"><a href="#"><span>Compare</span></a></div>--%>
                                                        <div class="add-to-cart">
                                                            <%--<a href="#"><span>Add to cart</span></a>--%>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                                <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                    <div class="caption product-detail text-center">
                                                        <h6 data-name="product_name" class="product-name mt_20"><a href="#" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a></h6>
                                                        <div class="rating"><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span></div>
                                                        <span class="price">
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <span class="amount">
                                                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                                    <%#Eval("PurchasePrice")%>                                                                
                                                                </span>
                                                            </a>
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                                                <span style="text-decoration: line-through; font-size: small;">
                                                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                                    <%#Eval("ProductPrice")%>
                                                                </span>
                                                            </a>
                                                            <br />
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <span style="font-size: small;">You Save: <%#Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))%> (<%#Eval("Discount")%>%)</span>
                                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                                                            </a>
                                                        </span>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div id="product-tab" class="mt_50">
                    <div class="heading-part mb_10 ">
                        <h2 class="main_title">Featured</h2>
                    </div>
                    <div class="tab-content clearfix box">
                        <div class="tab-pane active" id="Featured">
                            <asp:Repeater ID="pnlFeatured" runat="server" OnItemCommand="pnl_ItemCommand">
                                <HeaderTemplate>
                                    <div class="Featured owl-carousel">
                                </HeaderTemplate>
                                <ItemTemplate>

                                    <div class="product-grid">
                                        <div class="item">
                                            <div class="product-thumb  mb_30">
                                                <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                                                <div class="image product-imageblock">
                                                    <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                        <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                    </a>
                                                    <div class="button-group text-center">
                                                        <div class="wishlist">
                                                            <%--<a href="../WishList"><span>wishlist</span></a>--%>
                                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                        </div>
                                                        <div class="quickview">
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>"><span>Quick View</span>
                                                                <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />
                                                                <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />

                                                            </a>
                                                        </div>
                                                        <%--   <div class="compare"><a href="#"><span>Compare</span></a></div>--%>
                                                        <div class="add-to-cart">
                                                            <%--<a href="#"><span>Add to cart</span></a>--%>
                                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                                <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                    <div class="caption product-detail text-center">
                                                        <h6 data-name="product_name" class="product-name mt_20"><a href="#" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a></h6>
                                                        <div class="rating"><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span></div>
                                                        <span class="price">
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <span class="amount">
                                                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                                    <%#Eval("PurchasePrice")%>
                                                                </span>
                                                            </a>
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                                                <span style="text-decoration: line-through; font-size: small;">
                                                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                                    <%#Eval("ProductPrice")%>
                                                                </span>
                                                            </a>
                                                            <br />
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                                <span style="font-size: small;">You Save: <%#Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))%> (<%#Eval("Discount")%>%)</span>
                                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                                                            </a>
                                                        </span>
                                                    </div>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>


                <!-- =====  PRODUCT TAB  END ===== -->
                <!-- =====  SUB BANNER  STRAT ===== -->
                <div class="row">
                    <div class="cms_banner mt_50">
                        <div class="col-sm-12 mt_10">
                            <div id="subbanner3" class="sub-hover">
                                <div class="sub-img">
                                    <a href="#">
                                        <img src="images/sub6.jpg" alt="Sub Banner3" class="img-responsive"></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- =====  SUB BANNER END  ===== -->
                <!-- =====  Blog ===== -->
                <div id="Blog" class="mt_50">
                    <div class="heading-part mb_10 ">
                        <h2 class="main_title">Latest News</h2>
                    </div>
                    <div class="blog-contain box">
                        <div class="blog owl-carousel ">
                            <asp:Repeater ID="rptBlogs" runat="server">
                                <ItemTemplate>
                                    <div class="item">
                                        <div class="box-holder">
                                            <div class="thumb post-img">
                                                <a href="#">
                                                    <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>' alt="Blogs">
                                                </a>
                                                &nbsp;&nbsp;&nbsp;<div class="date-time text-center">
                                                    <div class="day"><%# Convert.ToDateTime(Eval("CreatedDate")).Day %></div>
                                                    <div class="month"><%# Convert.ToDateTime(Eval("CreatedDate")).ToString("MMM") %></div>
                                                </div>
                                                <a href='Blog/<%#Eval("Name")%>'>
                                                    <div class="post-image-hover"></div>
                                                </a>
                                                <div class="post-info">
                                                    <h6 class="mb_10 text-uppercase"><a href='<%#Eval("URL")%>'><%#Eval("Name")%></a> </h6>
                                                    <div class="view-blog">
                                                        <div class="write-comment pull-left"><a href='Blog/<%#Eval("Name")%>'>0 Comments</a> </div>
                                                        <div class="read-more pull-right"><a href='Blog/<%#Eval("Name")%>'><i class="fa fa-link"></i>read more</a> </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <%--<div class="item">
                                <div class="box-holder">
                                    <div class="thumb post-img">
                                        <a href="#">
                                            <img src="images/blog/blog_img_02.jpg" alt="OYEENok">
                                        </a>
                                        <div class="date-time text-center">
                                            <div class="day">11</div>
                                            <div class="month">Aug</div>
                                        </div>
                                        <div class="post-image-hover"></div>
                                        <div class="post-info">
                                            <h6 class="mb_10 text-uppercase"><a href="single_blog.html">Fashions fade, style is eternal</a> </h6>
                                            <div class="view-blog">
                                                <div class="write-comment pull-left"><a href="single_blog.html">0 Comments</a> </div>
                                                <div class="read-more pull-right"><a href="single_blog.html"><i class="fa fa-link"></i>read more</a> </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <div class="box-holder">
                                    <div class="thumb post-img">
                                        <a href="#">
                                            <img src="images/blog/blog_img_01.jpg" alt="OYEENok">
                                        </a>
                                        <div class="date-time text-center">
                                            <div class="day">11</div>
                                            <div class="month">Aug</div>
                                        </div>
                                        <div class="post-image-hover"></div>
                                        <div class="post-info">
                                            <h6 class="mb_10 text-uppercase"><a href="single_blog.html">Fashions fade, style is eternal</a> </h6>
                                            <div class="view-blog">
                                                <div class="write-comment pull-left"><a href="single_blog.html">0 Comments</a> </div>
                                                <div class="read-more pull-right"><a href="single_blog.html"><i class="fa fa-link"></i>read more</a> </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="item">
                                <div class="box-holder">
                                    <div class="thumb post-img">
                                        <a href="#">
                                            <img src="images/blog/blog_img_02.jpg" alt="OYEENok">
                                        </a>
                                        <div class="date-time text-center">
                                            <div class="day">11</div>
                                            <div class="month">Aug</div>
                                        </div>
                                        <div class="post-image-hover"></div>
                                        <div class="post-info">
                                            <h6 class="mb_10 text-uppercase"><a href="single_blog.html">Fashions fade, style is eternal</a> </h6>
                                            <div class="view-blog">
                                                <div class="write-comment pull-left"><a href="single_blog.html">0 Comments</a> </div>
                                                <div class="read-more pull-right"><a href="single_blog.html"><i class="fa fa-link"></i>read more</a> </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                    <!-- =====  Blog end ===== -->
                </div>
            </div>
        </div>
        <!-- =====  SUB BANNER  STRAT ===== -->
        <div class="row">
            <div class="cms_banner mt_10">
                <div class="col-xs-4 mt_10">
                    <div id="subbanner1" class="sub-hover">
                        <div class="sub-img">
                            <a href="../Category/Chain">
                                <img src="images/sub1.jpg" alt="Sub Banner1" class="img-responsive"></a>
                        </div>
                        <div class="bannertext text-center">
                            <a class="btn mb_10 cms_btn" href="../Category/Chain">View product</a>
                            <h2>Chain</h2>
                            <p class="mt_10">Wide veriety of sizes,colors</p>
                        </div>
                    </div>
                    <div id="subbanner2" class="sub-hover mt_20">
                        <div class="sub-img">
                            <a href="../Category/Earrings">
                                <img src="images/sub2.jpg" alt="Sub Banner2" class="img-responsive"></a>
                        </div>
                        <div class="bannertext text-center">
                            <a class="btn mb_10 cms_btn" href="../Category/Earrings">View product</a>
                            <h2>Earrings</h2>
                            <p class="mt_10">Shop collection of designer</p>
                        </div>
                    </div>
                </div>
                <div class="col-xs-4 mt_10">
                    <div id="subbanner3" class="sub-hover">
                        <div class="sub-img">
                            <a href="#">
                                <img src="images/sub3.jpg" alt="Sub Banner3" class="img-responsive"></a>
                        </div>
                    </div>
                </div>
                <div class="col-xs-4 mt_10">
                    <div id="subbanner4" class="sub-hover">
                        <div class="sub-img">
                            <a href="../Category/Finger Ring">
                                <img src="images/sub4.jpg" alt="Sub Banner4" class="img-responsive"></a>
                        </div>
                        <div class="bannertext text-center">
                            <a class="btn mb_10 cms_btn" href="../Category/Ring">View product</a>
                            <h2>Ring</h2>
                            <p class="mt_10">Ring for men & women only</p>
                        </div>
                    </div>
                    <div id="subbanner5" class="sub-hover mt_20">
                        <div class="sub-img">
                            <a href="../Category/Pendant">
                                <img src="images/sub5.jpg" alt="Sub Banner5" class="img-responsive"></a>
                        </div>
                        <div class="bannertext text-center">
                            <a class="btn mb_10 cms_btn" href="../Category/Pendant">View product</a>
                            <h2>Pendant</h2>
                            <p class="mt_10">Over 400 luxury designers</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- =====  SUB BANNER END  ===== -->

        <uc1:UCbrandcarouse runat="server" ID="UCbrandcarouse" />
        <div class="newsletters mb_50">
            <div class="row">
                <div class="col-sm-6">
                    <div class="news-head pull-left">
                        <h2>SIGN UP FOR NEWSLETTER</h2>
                        <div class="new-desc">Be the First to know about our Fresh Arrivals and much more!</div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <asp:ScriptManager ID="smMgr" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="pnlData1" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="pnlSubscibe" runat="server" DefaultButton="btnSubmit">
                                <div class="news-form pull-right">
                                    <%--<form onsubmit="return validatemail();" method="post">--%>
                                    <div class="form-group required">
                                        <asp:HiddenField ID="hdIdSubscribe" runat="server" Value="0" />
                                        <%--<input name="email" id="email" placeholder="Enter Your Email" class="form-control input-lg" required="" type="email">--%>
                                        <asp:TextBox ID="txtEmail" placeholder="Enter Your Email" TextMode="Email" AutoCompleteType="Email" CssClass="form-control input-lg" runat="server"></asp:TextBox>
                                        <%--<button type="submit" class="btn btn-default btn-lg">Subscribe</button>--%>
                                        <asp:Button ID="btnSubmit" CssClass="btn btn-default btn-lg" runat="server" Text="Subscribe" OnClick="btnSubmit_Click" />
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please Enter Email." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                                        <asp:HiddenField ID="hdMessage" runat="server" />
                                        <br />
                                        <asp:Label ID="lblMessage" CssClass="fontcolour" runat="server"></asp:Label>
                                    </div>
                                    <%-- </form>--%>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
