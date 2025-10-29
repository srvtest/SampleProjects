<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="EcommerceWebsite2.products" %>

<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>
<%@ Register Src="~/UCPriceRange.ascx" TagPrefix="uc1" TagName="UCPriceRange" %>
<%@ Register Src="~/UCBrand.ascx" TagPrefix="uc1" TagName="UCBrand" %>
<%@ Register Src="~/UCColor.ascx" TagPrefix="uc1" TagName="UCColor" %>
<%@ Register Src="~/UCSize.ascx" TagPrefix="uc1" TagName="UCSize" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .clear-filter {
            margin-bottom: 12px;
            margin-top: 6px;
            text-align: right;
            display: none;
        }

        .search-text {
            display: none;
        }

            .search-text .label {
                font-size: 15px;
                color: #45cfbe;
            }

        .SortWidth {
            width: 150px;
        }

        .LimitWidth {
            width: 75px;
        }

        .Sortlblwidth, .Limitlblwidth {
            width: 60px;
            margin-bottom: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- page main wrapper start -->
    <div class="shop-main-wrapper section-padding">
        <div class="container">
            <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
            <asp:HiddenField ID="hdnSidebar" runat="server" Value="" />
            <%--<asp:HiddenField ID="hdnSearchText" runat="server" Value="" />--%>
            <div class="row">
                <!-- sidebar area start -->
                <div class="col-lg-3 order-2 order-lg-1">
                    <aside class="sidebar-wrapper">
                        <div class="search-text">
                            <span class="label">You search: </span>
                            <asp:Label ID="lblSearchText" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="clear-filter">
                            <asp:LinkButton ID="btnClearFilter" runat="server" OnClientClick="ClearFilter();" OnClick="btnClearFilter_Click"><i class="pe-7s-close-circle"></i> Clear Filter</asp:LinkButton>
                        </div>
                        <!-- single sidebar start -->
                        <asp:Panel ID="pnlSidebar" runat="server">
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Main</h5>
                                <div class="sidebar-body content">
                                    <ul class="shop-categories">
                                        <asp:Repeater ID="rptMain" runat="server">
                                            <ItemTemplate>
                                                <li><%--<a href="<%#Eval("sName")%>"><%#Eval("sName")%></a>--%>
                                                    <asp:CheckBox ID='chk' runat="server" CssClass="sidebar-checkbox" AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--<asp:ListBox ID="ddlMasterCategory" runat="server" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="chk_CheckedChanged"></asp:ListBox>--%>
                                    </ul>
                                </div>
                            </div>
                            <%--<uc1:UCTopCategory runat="server" ID="UCTopCategory" />--%>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">categories</h5>
                                <div class="sidebar-body content">
                                    <ul class="shop-categories">
                                        <asp:Repeater ID="rptCategory" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID='chk' runat="server" CssClass="sidebar-checkbox" AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <%--<li><a href="#">fashionware <span>(10)</span></a></li>
                                    <li><a href="#">kitchenware <span>(5)</span></a></li>
                                    <li><a href="#">electronics <span>(8)</span></a></li>
                                    <li><a href="#">accessories <span>(4)</span></a></li>
                                    <li><a href="#">shoe <span>(5)</span></a></li>
                                    <li><a href="#">toys <span>(2)</span></a></li>--%>
                                    </ul>
                                </div>
                            </div>
                            <!-- single sidebar end -->
                            <!-- single sidebar start -->
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">price</h5>
                                <div class="sidebar-body content">
                                    <asp:HiddenField ID="hdnMinPrice" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnMaxPrice" runat="server" Value="" />

                                    <div class="price-range-wrap">
                                        <div class="price-range" data-min="0" data-max="0" runat="server" id="pRange"></div>
                                        <div class="range-slider">
                                            <div class="d-flex align-items-center justify-content-between">
                                                <div class="price-input">
                                                    <label for="amount">Price: </label>
                                                    <input type="text" id="amount" />
                                                </div>
                                                <asp:LinkButton ID="btnFilter" runat="server" CssClass="filter-btn btn btn-sqr" style="padding:7px 12px;" OnClick="btnFilter_Click">Filter</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- single sidebar end -->
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Collection</h5>
                                <div class="sidebar-body content">
                                    <ul class="shop-categories">
                                        <asp:Repeater ID="rptCollection" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Material</h5>
                                <div class="sidebar-body content">
                                    <ul class="shop-categories">
                                        <asp:Repeater ID="rptMaterial" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Gemstone</h5>
                                <div class="sidebar-body content">
                                    <ul class="shop-categories">
                                        <asp:Repeater ID="rptGemstone" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <!-- single sidebar start -->
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">color</h5>
                                <div class="sidebar-body content">
                                    <ul class="checkbox-container shop-categories">
                                        <asp:Repeater ID="rptColors" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <!-- single sidebar end -->
                            <!-- single sidebar start -->
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">shape</h5>
                                <div class="sidebar-body content">
                                    <ul class="checkbox-container shop-categories">
                                        <asp:Repeater ID="rptShape" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <!-- single sidebar end -->
                            <!-- single sidebar start -->
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">size</h5>
                                <div class="sidebar-body content">
                                    <ul class="checkbox-container shop-categories">
                                        <asp:Repeater ID="rptSize" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <!-- single sidebar end -->
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Gender</h5>
                                <div class="sidebar-body content">
                                    <ul class="shop-categories">
                                        <asp:Repeater ID="rptGender" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <!-- single sidebar start -->
                            <%--<uc1:UCPriceRange runat="server" ID="UCPriceRange" />--%>
                            <!-- single sidebar end -->

                            <!-- single sidebar start -->
                            <%--  <uc1:UCBrand runat="server" ID="ucBrand" />--%>
                            <!-- single sidebar end -->

                            <!-- single sidebar start -->
                            <%-- <uc1:UCColor runat="server" ID="UCColor" />--%>
                            <!-- single sidebar end -->

                            <!-- single sidebar start -->
                            <%-- <uc1:UCSize runat="server" ID="UCSize" />--%>
                            <!-- single sidebar end -->
                        </asp:Panel>
                        <!-- single sidebar start -->
                        <%--  <div class="sidebar-banner">
                            <div class="img-container">
                                <a href="#">
                                    <img src="../assets/img/banner/sidebar-banner.jpg" alt="" />
                                </a>
                            </div>
                        </div>--%>
                        <!-- single sidebar end -->
                    </aside>
                </div>
                <!-- sidebar area end -->

                <!-- shop main wrapper start -->
                <div class="col-lg-9 order-1 order-lg-2">
                    <asp:Panel ID="pnlEmpty" runat="server">
                        <div class="panel-collapse">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-6 mx-auto">
                                        <br />
                                        <h3>Sorry, no results Found.</h3>
                                        <p>Please check the spelling or try searching for something else.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlProducts" runat="server">
                        <div class="shop-product-wrapper">
                            <!-- shop product top wrap start -->
                            <div class="shop-top-bar">
                                <div class="row align-items-center">
                                    <div class="col-lg-5 col-md-6 order-2 order-md-1">
                                        <div class="top-bar-left">
                                            <div class="product-view-mode">
                                                <a class='<%=(ListViewtype=="GRID"?"active":"") %>' href="#" data-target="grid-view" data-toggle="tooltip" title="Grid View" onclick="SetType('GRID');"><i class="fa fa-th"></i></a>
                                                <a class='<%=(ListViewtype=="LIST"?"active":"") %>' href="#" data-target="list-view" data-toggle="tooltip" title="List View" onclick="SetType('LIST');"><i class="fa fa-list"></i></a>
                                                <asp:HiddenField ID="hdnviewType" runat="server" Value="GRID" ClientIDMode="Static" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-7 col-md-6 order-1 order-md-2">
                                        <div class="top-bar-right">
                                            <div class="product-short" style="margin-right: 15px;">
                                                <label class="Limitlblwidth" for="input-limit">Show :</label>
                                                <asp:DropDownList ID="ddlLimit" runat="server" CssClass="LimitWidth" AutoPostBack="true" OnSelectedIndexChanged="ddlLimit_SelectedIndexChanged">
                                                    <asp:ListItem Text="09" Value="9" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                                    <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="product-short">
                                                <label class="Sortlblwidth" for="input-sortby">Sort By : </label>
                                                <asp:DropDownList ID="ddlSort" runat="server" CssClass="SortWidth nice-select" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                                                    <asp:ListItem Text="Default" Value="0_ASC" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="Name (A - Z)" Value="1_ASC"></asp:ListItem>
                                                    <asp:ListItem Text="Name (Z - A)" Value="2_DESC"></asp:ListItem>
                                                    <asp:ListItem Text="Price (Low &gt; High)" Value="3_ASC"></asp:ListItem>
                                                    <asp:ListItem Text="Price (High &gt; Low)" Value="4_DESC"></asp:ListItem>
                                                    <asp:ListItem Text="Newest" Value="5_DESC"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- shop product top wrap start -->

                            <!-- product item list wrapper start -->

                            <div class="shop-product-wrap grid-view row mbn-30">
                                <asp:Repeater ID="RptProducts" runat="server" OnItemCommand="RptProducts_ItemCommand">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />

                                        <!-- product single item start -->
                                        <div class="col-md-4 col-sm-6">
                                            <!-- product grid start -->
                                            <div class="product-item">
                                                <figure class="product-thumb">
                                                    <a href="../productdetail/<%#Eval("SEOName")%>">
                                                        <img data-name="product_image" class="pri-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                        <img class="sec-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                    </a>
                                                    <div class="product-badge">
                                                        <%# Convert.ToBoolean(Eval("isNew")) ? "<div class='product-label new'><span>new</span></div>" : "" %>
                                                        <div class="product-label discount">
                                                            <span><%# Eval("Discount") %>%</span>
                                                        </div>
                                                    </div>
                                                    <div class="button-group">
                                                        <div class="wishlist">
                                                            <asp:LinkButton ID="LinkButton2" runat="server" data-toggle="tooltip" data-placement="left" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && idWishlists.Exists(x=>x.ToString() == Convert.ToString(Eval("idWishList")))  ? "fa fa-heart" : "fa fa-heart-o" %>"></i></asp:LinkButton>
                                                        </div>
                                                        <div class="quickview">
                                                            <a href='../productdetail/<%#Eval("SEOName")%>'><i class="pe-7s-search"></i></a>
                                                        </div>
                                                    </div>
                                                    <div class="cart-hover">
                                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-cart" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa ">add to cart</i></asp:LinkButton>
                                                    </div>
                                                </figure>
                                                <div class="product-caption text-center">
                                                    <div class="product-identity">
                                                        <p class="manufacturer-name"><a href="#"><%# Eval("MaterialName") %></a></p>
                                                    </div>
                                                    <ul class="color-categories">
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
                                                        <a href="../productdetail/<%#Eval("SEOName")%>" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a>
                                                    </h6>
                                                    <div class="price-box">
                                                        <span class="amount">
                                                            <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                                            <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %>
                                                        </span>
                                                        <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                                        <span style="text-decoration: line-through; font-size: small;">
                                                            <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                                            <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- product grid end -->
                                            <!-- product list item end -->
                                            <div class="product-list-item">
                                                <figure class="product-thumb">
                                                    <a href="../productdetail/<%#Eval("SEOName")%>">
                                                        <img data-name="product_image" class="pri-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                        <img class="sec-img" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                                    </a>

                                                    <div class="product-badge">
                                                        <%# Convert.ToBoolean(Eval("isNew")) ? "<div class='product-label new'><span>new</span></div>" : "" %>
                                                        <div class="product-label discount">
                                                            <span><%# Eval("Discount") %>%</span>
                                                        </div>
                                                    </div>
                                                    <div class="button-group">
                                                        <div class="wishlist">
                                                            <asp:LinkButton ID="LinkButton3" runat="server" data-toggle="tooltip" data-placement="left" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList")))  ? "fa fa-heart" : "fa fa-heart-o" %>"></i></asp:LinkButton>
                                                        </div>
                                                        <div class="quickview">
                                                            <a href='../productdetail/<%#Eval("SEOName")%>'><i class="pe-7s-search"></i></a>
                                                        </div>
                                                    </div>
                                                    <div class="cart-hover">
                                                        <asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-cart" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa ">add to cart</i></asp:LinkButton>
                                                    </div>
                                                </figure>
                                                <div class="product-content-list">
                                                    <div class="manufacturer-name">
                                                        <a href="#"><%# Eval("MaterialName") %></a>
                                                    </div>
                                                    <ul class="color-categories">
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

                                                    <h5 class="product-name">
                                                        <a href="../productdetail/<%#Eval("SEOName")%>" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a>
                                                    </h5>
                                                    <div class="price-box">
                                                        <span class="amount">
                                                            <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                                            <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %>
                                                        </span>
                                                        <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                                        <span style="text-decoration: line-through; font-size: small;">
                                                            <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                                            <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %>
                                                        </span>
                                                    </div>
                                                    <p style="border-top: 0px solid white;">
                                                        <asp:Label ID="lblFeatures" runat="server" ClientIDMode="Static" Text='<%# Limit(Eval("Features"),30) %>' ToolTip='<%# Eval("Features") %>'></asp:Label>
                                                        <asp:LinkButton ID="ReadMoreLinkButton" runat="server" CommandName="Readmore" Text="Read More" Visible='<%# SetVisibility(Eval("Features"), 30) %>'></asp:LinkButton>
                                                    </p>
                                                </div>
                                            </div>
                                            <!-- product list item end -->
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>

                            <!-- product item list wrapper end -->

                            <!-- start pagination area -->
                            <div class="paginatoin-area text-center">
                                <ul class="pagination-box">
                                    <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                                        <HeaderTemplate>
                                            <li>
                                                <asp:LinkButton ID='lnkFirst' class="previous" CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="pe-7s-angle-left"></i>
                                                </asp:LinkButton>
                                            </li>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <li class='<%# ((ListItem)Container.DataItem).Value.Equals(hdPageNo.Value) ? "active" : string.Empty %>'>
                                                <asp:LinkButton ID='lnkPage'
                                                    CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                                </asp:LinkButton>
                                            </li>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <li>
                                                <asp:LinkButton ID='lnkLast' CommandName="Page" class="next" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="pe-7s-angle-right"></i>
                                                </asp:LinkButton>
                                            </li>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <!-- end pagination area -->
                        </div>
                    </asp:Panel>
                </div>
                <!-- shop main wrapper end -->
            </div>
        </div>
        <!-- jQuery JS -->
        <script src="../assets/js/vendor/jquery-3.3.1.min.js"></script>
        <script>
            var coll = document.getElementsByClassName("collapsible");
            var i;
            for (i = 0; i < coll.length; i++) {
                if (coll[i].innerHTML == $("#<%= hdnSidebar.ClientID %>").val()) {
                    $(coll[i]).css('color', '#45cfbe')
                    coll[i].classList.toggle("active");
                    var content = coll[i].nextElementSibling;
                    if (content.style.maxHeight) {
                        content.style.maxHeight = null;
                    } else {
                        content.style.maxHeight = content.scrollHeight + "px";
                    }
                }
                coll[i].addEventListener("click", function () {
                    this.classList.toggle("active");
                    var content = this.nextElementSibling;
                    if (content.style.maxHeight) {
                        content.style.maxHeight = null;
                    } else {
                        content.style.maxHeight = content.scrollHeight + "px";
                    }
                });
            }
            for (i = 0; i < $('input[type=checkbox]').length; i++) {
                var checkbox = $('input[type=checkbox]');
                if (checkbox[i].checked) {
                    $(checkbox[i]).parents('.sidebar-single').children('.sidebar-title.collapsible').css('color', '#45cfbe');
                }
            }
            $(document).ready(function () {
                if ($('#hdnviewType').val() === "GRID") {
                    $('.shop-product-wrap').attr('class', 'shop-product-wrap row mbn-30 grid-view');
                } else {
                    $('.shop-product-wrap').attr('class', 'shop-product-wrap row mbn-30 list-view');
                }
                <%--if ($('input:checkbox:checked').length > 0)
                    $("#<%= btnClearFilter.ClientID %>").css('display', 'block');
                else
                    $("#<%= btnClearFilter.ClientID %>").css('display', 'none');--%>
                var url = window.location.href;
                if (url.indexOf('search=') !== -1) {
                    if (url.substring(url.indexOf("=") + 1, url.length).length > 0) {
                        $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'block');
                    $(".search-text").css('display', 'block');
                }
            }
            else if ($("#<%= pnlEmpty.ClientID %>").is(":visible")) {
                $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'block');
                }
            });
        function SetType(typ) {
            $('#hdnviewType').val(typ);
        }
        function SetPriceRange(currency, minP, maxP) {
            if (minP != $("#<%= hdnMinPrice.ClientID %>").val() || maxP != $("#<%= hdnMaxPrice.ClientID %>").val() || $('input:checkbox:checked').length > 0)
                $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'block');
            else
                $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'none');

            $(".price-range-wrap .price-range").attr("data-min", minP);
            $(".price-range-wrap .price-range").attr("data-max", maxP);
            var rangeSlider = $(".price-range"),
            amount = $("#amount"),
            minPrice = rangeSlider.data('min'),
            maxPrice = rangeSlider.data('max');
            rangeSlider.slider({
                range: true,
                min: minPrice,
                max: maxPrice,
                values: [$("#<%= hdnMinPrice.ClientID %>").val(), $("#<%= hdnMaxPrice.ClientID %>").val()],
                slide: function (event, ui) {
                    amount.val(currency + ui.values[0] + " - " + currency + ui.values[1]);
                },
                stop: function (event, ui) {
                    $("#<%= hdnMinPrice.ClientID %>").val(ui.values[0]);
                    $("#<%= hdnMaxPrice.ClientID %>").val(ui.values[1]);
                }
            });

            amount.val(" " + currency + rangeSlider.slider("values", 0) +
                " - " + currency + rangeSlider.slider("values", 1)
            );

        }
            //n.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,")
            //.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ',')
        function ClearFilter() {
                <%--$('input[type=checkbox]').prop('checked', false);
                $(".search-text").css('display', 'none');
                $("#<%= hdnMinPrice.ClientID %>").val($(".price-range").data('min'));
                $("#<%= hdnMaxPrice.ClientID %>").val($(".price-range").data('max'));
                SetPriceRange("<%=this.Master.CurrencySymbol %>", $("#<%= hdnMinPrice.ClientID %>").val(), $("#<%= hdnMaxPrice.ClientID %>").val());--%>
            }
        </script>

    </div>
    <!-- page main wrapper end -->
    <style type="text/css">
        .collapsible {
            cursor: pointer;
        }

            .collapsible:after {
                content: '\002B';
                color: #45cfbe;
                font-weight: bold;
                float: right;
                margin-left: 5px;
            }

            .collapsible.active:after {
                content: "\2212";
            }

        .content {
            max-height: 0;
            overflow: hidden;
            transition: max-height 0.2s ease-out;
        }

        .sidebar-checkbox input[type="checkbox"] {
            margin-right: 3px;
        }

        .price-range-wrap .range-slider .price-input input {
            max-width: 155px;
        }
        .price-range-wrap .price-range {
            margin-right: 3px;
            margin-left: 11px;
        }
    </style>
</asp:Content>
