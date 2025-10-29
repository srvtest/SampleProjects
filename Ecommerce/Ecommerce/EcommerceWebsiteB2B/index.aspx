<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="index.aspx.cs" Inherits="EcommerceWebsiteB2B.index" %>
<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .fash {
            font-weight:100;
        }
        #shopRings .dc-inner img {
            height: 279px;
        }

        .product .productInner img {
            height: 331px;
        }

        .product .productInner .proName a {
            line-height: inherit;
        }

        .product .productInner .row.m0.proName {
            min-height: 41px;
        }

        .product {
            margin-bottom: 0px;
            padding: 0 15px;
        }
        .textshow {
            display:block;
        }
        .texthide {
            display:none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="slider" class="row">
        <div class="row sliderCont flexslider m0">
            <ul class="slides nav">
                <asp:Repeater ID="pgBanner" runat="server">
                    <ItemTemplate>
                        <li>
                            <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/Images/HomeSlider/<%#Eval("ImageURL")%>" alt="" />
                            <div class="text_lines row m0 <%#Convert.ToInt32(Eval("isShowHide")) == 1  ? "textshow" : "texthide" %>">
                                <div class="container p0 <%#Eval("sAlign")%>">
                                    <h3><%#Eval("sText1")%></h3>
                                    <h2><%#Eval("sText2")%></h2>
                                    <h4><a class="theme_btn with_i" href="<%= this.Master.baseUrl %>/products.aspx"><i class="fas fa-plus-circle"></i>Shop now</a></h4>
                                </div>
                            </div>
                            <!--Text Lines-->
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </section>
    <!--Slider-->
    <asp:Panel ID="pnlNewArrivels" runat="server">
        <section id="shopRings">
            <div class="sectionTitle">
                <h3>New arrivels</h3>
                <h5>know more about our latest collection</h5>
            </div>
            <div class="d-carousel-cener owl-carousel">
                <asp:Repeater ID="rptNewArrivels" runat="server" OnItemCommand="rpt_ItemCommand">
                    <ItemTemplate>
                        <div class="dc-inner">
                            <asp:HiddenField ID="hdnIdProduct" runat="server" Value='<%#Eval("idProduct") %>' />
                            <a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>">
                                <img alt="<%#Eval("SEOName")%>" src="<%= DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" title="<%#Eval("sName")%>" />
                                <div class="dc-containt">
                                    <h2><%#Eval("sName")%></h2>
                                    <p>Bar Set Anniversary Ring</p>
                                </div>
                            </a>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </section>
    </asp:Panel>
    <section id="shopFeatures_new">
        <div class=" shopFeatures_new container">
            <ul>
                <li class="sf_first">
                    <img alt="" class="img-responsive" src="<%= this.Master.baseUrl %>images/feature/1.jpg" />
                    <div class="sf_box">
                        <div class="sf_box_inner">
                            <h2>free shipping</h2>
                            <h3>on orders over $299</h3>
                            <p>This offer is valid on all our store items</p>
                        </div>
                    </div>
                </li>
                <li>
                    <a href="javascript:void(0);">
                        <img alt="" class="img-responsive" src="<%= this.Master.baseUrl %>images/feature/2.jpg" />
                        <div class="sf_box">
                            <div class="sf_box_inner">
                                <h3>shop & save</h3>
                                <p>On all our store items</p>
                            </div>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="javascript:void(0);">
                        <img alt="" class="img-responsive" src="<%= this.Master.baseUrl %>images/feature/3.jpg" />
                        <div class="sf_box">
                            <div class="sf_box_inner">
                                <h3>Product catalog</h3>
                            </div>
                        </div>
                    </a>
                </li>
                <li>
                    <a href="javascript:void(0);">
                        <img alt="" class="img-responsive" src="<%= this.Master.baseUrl %>images/feature/4.jpg" />
                        <div class="sf_box">
                            <div class="sf_box_inner">
                                <h3>product list</h3>
                                <p>Lorem ipsum dolor sit amet</p>
                            </div>
                        </div>
                    </a>
                </li>
            </ul>
        </div>
    </section>
    <asp:Panel ID="pnlFeatured" runat="server">
        <section id="featureProducts" class="row contentRowPad">
            <div class="container">
                <div class="row sectionTitle">
                    <h3>featured products</h3>
                    <h5>know more about our latest collection</h5>
                </div>
                <div class="owl-carousel featureCats row m0">
                    <asp:Repeater ID="rptFeatured" runat="server" OnItemCommand="rpt_ItemCommand">
                        <ItemTemplate>
                            <div class="product">
                                <div class="productInner row m0">
                                    <asp:HiddenField ID="hdnIdProduct" runat="server" Value='<%#Eval("idProduct") %>' />
                                    <div class="row m0 imgHov">
                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                        <div class="row m0 hovArea">
                                            <div class="row m0 icons">
                                                <ul class="list-inline">
                                                    <li>
                                                        <asp:LinkButton ID="btnWishlist" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? "fas fa-heart" : "far fa-heart" %>"></i></asp:LinkButton>
                                                    </li>
                                                  <%--  <li>
                                                        <asp:LinkButton ID="btnCart" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart"><i class="fas fa-shopping-cart-alt"></i></asp:LinkButton>
                                                    </li>--%>
                                                    <li>
                                                        <a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>" title="Quick View"><i class="fas fa-expand"></i></a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="row m0 proType"><a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></div>
                                            <div class="row m0 proRating">
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                            </div>
                                            <div class="row m0 proPrice"><i class="fas fa-usd"></i><%=((main_master)this.Page.Master).CurrencySymbol %><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></div>
                                        </div>
                                    </div>
                                    <div class="row m0 proName"><a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>" title='<%#Eval("sName")%>'><%#Convert.ToString(Eval("sName")).Length > 60 ? Convert.ToString(Eval("sName")).Substring(0,60) + "..." :Eval("sName")%></a></div>
                                    <div class="row m0 proBuyBtn">
                                        <asp:LinkButton ID="btnAddToCart" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart" class="addToCart btn">add to cart</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!--Feature Products 4 Collumn-->
    <asp:Panel ID="pnlFeatureCategory" runat="server">
        <section id="featureCategory" class="row contentRowPad">
            <div class="container">
                <div class="row m0 sectionTitle">
                    <h3>our featured categories</h3>
                    <h5>make easy shop with our categories</h5>
                </div>
                <div class="owl-carousel featureCats row m0">
                    <asp:Repeater ID="rptFeatureCategory" runat="server">
                        <ItemTemplate>
                            <div class="item">
                                <div class="row m0 imgHov">
                                    <img height="275" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="">
                                    <div class="row m0 hovArea">
                                        <i class="fas fa-heart-o"></i>
                                        <br>
                                        <h4><%#Eval("Num")%> items</h4>
                                        <a href="<%= this.Master.baseUrl %>products/category=<%#Eval("sName")%>">shop now</a>
                                    </div>
                                </div>
                                <div class="cat_h">
                                    <a href="<%= this.Master.baseUrl %>products/category=<%#Eval("sName")%>">
                                        <h4><%#Eval("sName")%></h4>
                                        <span>See the Collection</span>
                                    </a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!--Feature Categories-->
    <asp:Panel ID="pnlBestSeller" runat="server">
        <section id="D-Shine" class="row contentRowPad">
            <div class="container">
                <div class="row sectionTitle">
                    <h3>this is best seller products</h3>
                    <h5>shop over our best brands</h5>
                </div>
                <div class="owl-carousel featureCats row m0">
                    <asp:Repeater ID="rptBestSeller" runat="server" OnItemCommand="rpt_ItemCommand">
                        <ItemTemplate>
                            <div class="product">
                                <div class="productInner row m0">
                                    <div class="row m0 imgHov">
                                        <asp:HiddenField ID="hdnIdProduct" runat="server" Value='<%#Eval("idProduct") %>' />
                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>">
                                        <div class="row m0 hovArea">
                                            <div class="row m0 icons">
                                                <ul class="list-inline">
                                                    <li>
                                                        <asp:LinkButton ID="btnWishlist" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? "fas fa-heart" : "far fa-heart" %>"></i></asp:LinkButton>
                                                    </li>
                                                   <%-- <li>
                                                        <asp:LinkButton ID="btnCart" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart"><i class="fas fa-shopping-cart-alt"></i></asp:LinkButton>
                                                    </li>--%>
                                                    <li>
                                                        <a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>" title="Quick View"><i class="fas fa-expand"></i></a>
                                                    </li>
                                                </ul>
                                            </div>
                                            <div class="row m0 proType"><a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></div>
                                            <div class="row m0 proRating">
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                                <i class="fas fa-star-o"></i>
                                            </div>
                                            <div class="row m0 proPrice"><i class="fas fa-usd"></i><%=((main_master)this.Page.Master).CurrencySymbol %><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></div>
                                        </div>
                                    </div>
                                    <div class="row m0 proName"><a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>" title='<%#Eval("sName")%>'><%#Convert.ToString(Eval("sName")).Length > 60 ? Convert.ToString(Eval("sName")).Substring(0,60) + "..." :Eval("sName")%></a></div>
                                    <div class="row m0 proBuyBtn">
                                        <asp:LinkButton ID="btnAddToCart" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart" class="addToCart btn">add to cart</asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!--Feature Products 4 Collumn-->
    <asp:Panel ID="pnlTestimonials" runat="server" Visible="false">
        <section id="testimonialTabs" class="row contentRowPad">
            <div class="container">
                <div class="row sectionTitle">
                    <h3>some words from our customers</h3>
                    <h5>we satisfied more than 700 customers</h5>
                </div>
                <div class="row">
                    <div class="tab-content testiTabContent">
                        <div role="tabpanel" class="tab-pane active" id="testi1">
                            <p><span class="t_q_start">“</span> D-Shine is really excellent site for jewellery. I am very happy with the D-Shine products and dedicated services from them. D-Shine is really excellent site for jewellery. <span class="t_q_end">”</span></p>
                            <h5 class="customerName">Dwayne johnson</h5>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="testi2">
                            <p><span class="t_q_start">“</span> Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum vestibulum justo accumsan felis faucibus vestibulum. Integer a ex orci. Cras sit amet efficitur nisl, et vestibulum orci. <span class="t_q_end">”</span></p>
                            <h5 class="customerName">Jonh add</h5>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="testi3">
                            <p><span class="t_q_start">“</span> D-Shine is really excellent site for jewellery. I am very happy with the D-Shine products and dedicated services from them. D-Shine is really excellent site for jewellery. <span class="t_q_end">”</span></p>
                            <h5 class="customerName">william parker</h5>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="testi4">
                            <p><span class="t_q_start">“</span> Donec in velit eget lacus convallis dapibus. Nulla ultrices nulla sit amet justo pretium, ut tristique diam ultrices. Nunc efficitur mauris sit amet imperdiet <span class="t_q_end">”</span></p>
                            <h5 class="customerName">Will smith</h5>
                        </div>
                        <div role="tabpanel" class="tab-pane" id="testi5">
                            <p><span class="t_q_start">“</span> D-Shine is really excellent site for jewellery. I am very happy with the D-Shine products and dedicated services from them. D-Shine is really excellent site for jewellery. <span class="t_q_end">”</span></p>
                            <h5 class="customerName">Dwayne johnson</h5>
                        </div>
                    </div>
                    <ul class="nav nav-tabs" role="tablist" id="testiTab">
                        <li role="presentation" class="active">
                            <a href="#testi1" aria-controls="testi1" role="tab" data-toggle="tab">
                                <img src="<%= this.Master.baseUrl %>images/testimonial/1.png" alt="" />
                            </a>
                            <div class="testi_rating">
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star-half"></i>
                            </div>
                        </li>
                        <li role="presentation">
                            <a href="#testi2" aria-controls="testi2" role="tab" data-toggle="tab">
                                <img src="<%= this.Master.baseUrl %>images/testimonial/2.png" alt="" />
                            </a>
                            <div class="testi_rating">
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star-o"></i>
                                <i class="fas fa-star-o"></i>
                            </div>
                        </li>
                        <li role="presentation">
                            <a href="#testi3" aria-controls="testi3" role="tab" data-toggle="tab">
                                <img src="<%= this.Master.baseUrl %>images/testimonial/3.png" alt="" />
                            </a>
                            <div class="testi_rating">
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                            </div>
                        </li>
                        <li role="presentation">
                            <a href="#testi4" aria-controls="testi4" role="tab" data-toggle="tab">
                                <img src="<%= this.Master.baseUrl %>images/testimonial/4.png" alt="" />
                            </a>
                            <div class="testi_rating">
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star-o"></i>
                            </div>
                        </li>
                        <li role="presentation">
                            <a href="#testi5" aria-controls="testi5" role="tab" data-toggle="tab">
                                <img src="<%= this.Master.baseUrl %>images/testimonial/5.png" alt="" />
                            </a>
                            <div class="testi_rating">
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star"></i>
                                <i class="fas fa-star-o"></i>
                                <i class="fas fa-star-o"></i>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </section>
    </asp:Panel>
    <!--Testimonial Tabs-->
    <asp:Panel ID="pnlBrands" runat="server" Visible="false">
        <section id="brands" class="row contentRowPad">
            <div class="container">
                <div class="row sectionTitle">
                    <h3>our brands</h3>
                    <h5>choose best with our favorite brands</h5>
                </div>
                <div class="row brands">
                    <ul class="nav navbar-nav">
                        <li><a href="#">
                            <img src="<%= this.Master.baseUrl %>images/brands/1.png" alt="" /></a></li>
                        <li><a href="#">
                            <img src="<%= this.Master.baseUrl %>images/brands/2.png" alt="" /></a></li>
                        <li><a href="#">
                            <img src="<%= this.Master.baseUrl %>images/brands/3.png" alt="" /></a></li>
                        <li><a href="#">
                            <img src="<%= this.Master.baseUrl %>images/brands/4.png" alt="" /></a></li>
                        <li><a href="#">
                            <img src="<%= this.Master.baseUrl %>images/brands/5.png" alt="" /></a></li>
                        <li><a href="#">
                            <img src="<%= this.Master.baseUrl %>images/brands/2.png" alt="" /></a></li>
                    </ul>
                </div>
            </div>
        </section>
    </asp:Panel>
    <asp:Panel ID="pnlBlogs" runat="server">
        <section id="homeBlog">
            <div class="container blog_j">
                <div class="row sectionTitle">
                    <h3>Blog Updates</h3>
                    <h5>we satisfied more than 700 customers</h5>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="blog_inner single">
                            <div class="blog_j_img">
                                <asp:Image ID="imgBlog" CssClass="img-responsive" runat="server" />
                                <div class="btn_readmore">
                                    <asp:HyperLink ID="lnkReadMore" runat="server">Read more</asp:HyperLink>
                                </div>
                            </div>
                            <div class="blog_j_text">
                                <p>
                                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                </p>
                                <span>
                                    <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <asp:Repeater ID="rptBlogs" runat="server">
                                <HeaderTemplate>
                                    <div class="col-sm-6">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="blog_inner">
                                        <div class="blog_j_img">
                                            <img alt="blog image" class="img-responsive" src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>'>
                                            <div class="btn_readmore">
                                                <a href='<%= this.Master.baseUrl %>Blog/<%#Eval("Name")%>'>Read more</a>
                                            </div>
                                        </div>
                                        <div class="blog_j_text">
                                            <p>
                                                <%# Convert.ToDateTime(Eval("CreatedDate")).ToString("dd MMM yyyy") %> | <span title='<%#Eval("Name")%>'><%#Eval("Name")%></span>
                                            </p>
                                        </div>
                                    </div>
                                    <%# (Container.ItemIndex + 1) % 2 == 0 ? "</div><div class='col-sm-6'>" : "" %>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </asp:Panel>
</asp:Content>
