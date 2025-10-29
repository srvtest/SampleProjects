<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="productdetail.aspx.cs" Inherits="EcommerceWebsite2.ProductDetail" %>

<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>
<%@ Register Src="~/UCPriceRange.ascx" TagPrefix="uc1" TagName="UCPriceRange" %>
<%@ Register Src="~/UCBrand.ascx" TagPrefix="uc1" TagName="UCBrand" %>
<%@ Register Src="~/UCColor.ascx" TagPrefix="uc1" TagName="UCColor" %>
<%@ Register Src="~/UCSize.ascx" TagPrefix="uc1" TagName="UCSize" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .pri-img, .sec-img {
            height: 263px !important;
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
                                <li class="breadcrumb-item"><a href="../products.aspx">shop</a></li>
                                <li class="breadcrumb-item active">product details</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- page main wrapper start -->
    <div class="shop-main-wrapper section-padding pb-0">
        <div class="container">
            <div class="row">

                <asp:HiddenField ID="hdnUpdatedQuantity" runat="server" Value="" />
                <asp:HiddenField ID="hdnIdpro" runat="server" Value="0" />
                <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound" OnItemCommand="rptProduct_ItemCommand">
                    <ItemTemplate>
                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                        <!-- product details wrapper start -->
                        <div class="col-lg-12 order-1 order-lg-2">
                            <!-- product details inner end -->
                            <div class="product-details-inner">
                                <div class="row">
                                    <div class="col-lg-5">
                                        <asp:Repeater ID="rptProductImage" runat="server">
                                            <HeaderTemplate>
                                                <div class="product-large-slider">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# Convert.ToString(Eval("type"))=="image" ? ("<div class='pro-large-img img-zoom'><img src='" + DataLayer.CommonControl.GetAdminUrl() + "/ProductImage/" + Eval("url") + "' alt='product-details' /></div>") : ("<div class='embed-responsive embed-responsive-16by9 provid'><iframe src='https://www.youtube.com/embed/"+ Eval("name") + "/hqdefault.jpg' allow='autoplay; encrypted-media' allowfullscreen></iframe></div>") %>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </div>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                        <asp:Repeater ID="rptProductImages" runat="server">
                                            <HeaderTemplate>
                                                <div class="pro-nav slick-row-10 slick-arrow-style">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="pro-nav-thumb">
                                                    <img class='<%#Convert.ToString(Eval("type"))=="image" ? "image-additional" : "vid"%>' src='<%#Convert.ToString(Eval("type"))=="image" ? DataLayer.CommonControl.GetAdminUrl()+"/ProductImage/"+Eval("url") : "http://img.youtube.com/vi/"+Eval("name")+"/hqdefault.jpg"%>' alt="product-details" />
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </div>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>

                                    <div class="col-lg-7">
                                        <div class="product-details-des">
                                            <%--<div class="manufacturer-name">
                                                <a href="product-details.html">HasTech</a>
                                            </div>--%>
                                            <h3 class="product-name">
                                                <%--Handmade Golden Necklace Full Family Package--%>
                                                <a href="#" title='<%#Eval("SName")%>'>
                                                    <%#Eval("SName")%>
                                                </a>
                                            </h3>
                                            <div class="ratings d-flex">
                                                <span><i class='<%# Convert.ToDecimal(Eval("rate")) >= 1 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                <span><i class='<%# Convert.ToDecimal(Eval("rate")) >= 2 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                <span><i class='<%# Convert.ToDecimal(Eval("rate")) >= 3 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                <span><i class='<%# Convert.ToDecimal(Eval("rate")) >= 4 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                <span><i class='<%# Convert.ToDecimal(Eval("rate")) >= 5 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                <div class="pro-review">
                                                    <span><%# Eval("Review") %> Reviews</span>
                                                </div>
                                            </div>
                                            <div class="price-box">
                                                <%--<span class="price-regular">$70.00</span>
                                            <span class="price-old"><del>$90.00</del></span>--%>
                                                <span class="price-regular">
                                                    <%--<span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>--%>
                                                    <%=this.Master.CurrencySymbol %>
                                                    <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %>
                                                </span>
                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                                <span style="text-decoration: line-through; font-size: small;">
                                                    <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                                    <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %>
                                                </span>
                                                <br />
                                                <span class="price-old" style="font-size: small;">You Save: <%=this.Master.CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))) %> (<%#Eval("Discount")%>%)</span>
                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                                            </div>
                                            <%--<h5 class="offer-text"><strong>Hurry up</strong>! offer ends in:</h5>
                                            <div class="product-countdown" data-countdown="2019/12/20"></div>
                                            <div class="availability">
                                                <i class="fa fa-check-circle"></i>
                                                <span>200 in stock</span>
                                            </div>--%>
                                            <p class="pro-desc">
                                                <asp:Label ID="lblFeatures" runat="server" ClientIDMode="Static" Text='<%# Limit(Eval("Features"),30) %>' ToolTip='<%# Eval("Features") %>'></asp:Label>
                                                <asp:LinkButton ID="ReadMoreLinkButton" runat="server" CommandName="Readmore" Text="Read More" Visible='<%# SetVisibility(Eval("Features"), 30) %>'></asp:LinkButton>
                                                <%-- <%#Eval("Features")%>--%>
                                            </p>
                                            <div class="quantity-cart-box d-flex align-items-center">
                                                <h6 class="option-title">qty:</h6>
                                                <div class="quantity">
                                                    <div class="pro-qty">
                                                        <asp:TextBox ID="txtQty" runat="server" Text="1" ReadOnly="true"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="action_link">
                                                    <asp:LinkButton ID="btnCartAdd" class="btn btn-cart2" ClientIDMode="Static" CommandName="CrtAdd" Text="Add to Cart" runat="server"></asp:LinkButton>
                                                </div>
                                            </div>
                                            <div class="pro-size">
                                                <h6 class="option-title">size :</h6>
                                                <span><%# Eval("sSize") %></span>
                                            </div>
                                            <div class="color-option">
                                                <h6 class="option-title">color :</h6>
                                                <span><%# Eval("sColor") %></span>
                                            </div>
                                            <div class="color-option">
                                                <h6 class="option-title">shape :</h6>
                                                <span><%# Eval("sShape") %></span>
                                            </div>
                                            <div class="similar-product">
                                                <ul class="color-categories">
                                                    <asp:Repeater ID="rptSimilarProduct" runat="server">
                                                        <ItemTemplate>
                                                            <li class='<%# Convert.ToInt32(Eval("idProduct")) == Convert.ToInt32(hdnIdpro.Value) ? "selected" : "" %>'>
                                                                <asp:ImageButton ID="btnProduct" runat="server" Width="50" ToolTip='<%# Eval("SEOName") %>' OnClick="btnProduct_Click" CommandArgument='<%# Eval("idProduct") %>' ImageUrl='<%# DataLayer.CommonControl.GetAdminUrl() + "/ProductImage/" + Eval("ImageURL") %>' />
                                                            </li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </div>
                                            <div class="useful-links">
                                                <%--<a href="#" data-toggle="tooltip" title="Compare"><i
                                                class="pe-7s-refresh-2"></i>compare</a>--%>
                                                <%--<a href="#" data-toggle="tooltip" title="Wishlist"><i
                                                class="pe-7s-like"></i>wishlist</a>--%>
                                                <%--<asp:Button ID="btnWishlistAdd" runat="server" class="pe-7s-like" ClientIDMode="Static" CommandName="WishAdd" Text="Add to WishList" />--%>
                                                <%-- <button id="btnWishlistAdd" runat="server" commandname="WishAdd" CommandArgument='<%#Eval("idProduct")%>'><i class="pe-7s-like"></i><span> </span>wishlist</button>--%>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"]))  ? "fa fa-heart" : "fa fa-heart-o" %>"></i><span> </span><%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"]))  ? "Wishlisted" : "Add to Wishlist" %></asp:LinkButton>
                                            </div>
                                            <div class="like-icon">
                                                <a class="facebook" href="https://www.facebook.com/"><i class="fa fa-facebook"></i>like</a>
                                                <a class="twitter" href="https://twitter.com/?lang=en"><i class="fa fa-twitter"></i>tweet</a>
                                                <a class="pinterest" href="https://in.pinterest.com/"><i class="fa fa-pinterest"></i>save</a>
                                                <a class="google" href="https://www.google.com/"><i class="fa fa-google-plus"></i>share</a>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!-- product details inner end -->

                            <!-- product details reviews start -->
                            <div class="product-details-reviews section-padding pb-0" style="margin-bottom: 50px;">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="product-review-info">
                                            <ul class="nav review-tab">
                                                <li>
                                                    <a class="active" data-toggle="tab" href="#tab_one">description</a>
                                                </li>
                                                <li>
                                                    <a data-toggle="tab" href="#tab_two">information</a>
                                                </li>
                                                <li>
                                                    <a data-toggle="tab" href="#tab_three">reviews</a>
                                                </li>
                                            </ul>
                                            <div class="tab-content reviews-tab">
                                                <div class="tab-pane fade show active" id="tab_one">
                                                    <div class="tab-one">
                                                        <p>
                                                            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                                                        </p>
                                                    </div>
                                                </div>
                                                <div class="tab-pane fade" id="tab_two">
                                                    <div style="margin-top: 40px;">
                                                        <table style="width: 390px;">
                                                            <tr style="border-top: 1px solid #ddd; border-bottom: 1px solid #ddd;">
                                                                <th>Item Type :
                                                                </th>
                                                                <td>
                                                                    <a style="color: #77c6b5; font-weight: bold;" href="../products/main=<%#Eval("MasterCategory")%>"><%#Eval("MasterCategory")%></a>
                                                                </td>
                                                            </tr>
                                                            <tr style="border-bottom: 1px solid #ddd;">
                                                                <th>Category : </th>
                                                                <td>
                                                                    <a style="color: #77c6b5; font-weight: bold;" href="../products/category=<%#Eval("CategoryName")%>"><%#Eval("CategoryName")%></a>
                                                                </td>
                                                            </tr>
                                                            <tr style="border-bottom: 1px solid #ddd;">
                                                                <th>Collection : </th>
                                                                <td>
                                                                    <%#Eval("Collection")%>
                                                                </td>
                                                            </tr>
                                                            <tr style="border-bottom: 1px solid #ddd;">
                                                                <th>Material : </th>
                                                                <td>
                                                                    <%#Eval("Material")%>
                                                                </td>
                                                            </tr>
                                                            <tr style="border-bottom: 1px solid #ddd;">
                                                                <th>GEMSTONE : </th>
                                                                <td>
                                                                    <%#Eval("gemstone")%>
                                                                </td>
                                                            </tr>
                                                            <tr style="border-bottom: 1px solid #ddd;">
                                                                <th>GENDER : </th>
                                                                <td>
                                                                    <%#Eval("gender")%>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </div>
                                                    <%-- <table class="table table-bordered">
                                                        <tbody>
                                                            <tr style="border-top: 1px solid #ddd; border-bottom: 1px solid #ddd;">
                                                                <td>size :</td>
                                                                <td><%# Eval("sSize") %></td>
                                                            </tr>
                                                            <tr style="border-bottom: 1px solid #ddd;">
                                                                <td>color :</td>
                                                                <td><%# Eval("sColor") %></td>
                                                            </tr>
                                                            <tr style="border-bottom: 1px solid #ddd;">
                                                                <td>shape :</td>
                                                                <td><%# Eval("sShape") %></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>--%>
                                                </div>
                                                <div class="tab-pane fade" id="tab_three">
                                                    <asp:HiddenField ID="hdnidCustomerReview" runat="server" Value="0" />
                                                    <div class="review-form">
                                                        <h5><%# Eval("Review") %> review for <span><%#Eval("SName")%></span></h5>
                                                        <asp:Repeater ID="rptReviews" runat="server" OnItemCommand="rptReviews_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="add-review">
                                                                    <div class="total-reviews">
                                                                        <div class="rev-avatar">
                                                                            <img src="../assets/img/about/avatar.jpg" alt="">
                                                                        </div>
                                                                        <div class="review-box">
                                                                            <%# !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) && Convert.ToInt32(Eval("idCustomer")) == Convert.ToInt32(DataLayer.CommonControl.Decrypt(Convert.ToString(Session["CustomerId"]))) ? "<a class='float-right edit-review' href='javascript:void(0);' onclick='editReview(this);'>edit review</a>" : "" %>
                                                                            <div class="ratings">
                                                                                <span class="good"><i class='<%# Convert.ToInt16(Eval("starRating")) >= 1 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                                                <span class="good"><i class='<%# Convert.ToInt16(Eval("starRating")) >= 2 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                                                <span class="good"><i class='<%# Convert.ToInt16(Eval("starRating")) >= 3 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                                                <span class="good"><i class='<%# Convert.ToInt16(Eval("starRating")) >= 4 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                                                <span class="good"><i class='<%# Convert.ToInt16(Eval("starRating")) >= 5 ? "fa fa-star" : "fa fa-star-o" %>'></i></span>
                                                                            </div>
                                                                            <div class="post-author">
                                                                                <p><span><%# Eval("sName") %> -</span> <%# Convert.ToDateTime(Eval("dtCreated")).Day + " " + Convert.ToDateTime(Eval("dtCreated")).ToString("MMMM") +", "+Convert.ToDateTime(Eval("dtCreated")).Year  %></p>
                                                                            </div>
                                                                            <p>
                                                                                <%# Eval("review") %>
                                                                            </p>
                                                                        </div>
                                                                    </div>
                                                                    <asp:Panel ID="pnlReview" CssClass="pnlReview" runat="server" Visible='<%# !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) && Convert.ToInt32(Eval("idCustomer")) == Convert.ToInt32(DataLayer.CommonControl.Decrypt(Convert.ToString(Session["CustomerId"]))) ? true : false %>'>
                                                                        <div class="review-box" style="border: 1px solid #efefef; padding: 10px; box-shadow: 0px 0px 2px #45cfbe; margin-bottom: 20px; display: none;">
                                                                            <div class="form-group row">
                                                                                <div class="col">
                                                                                    <label class="col-form-label">
                                                                                        <span class="text-danger">*</span>
                                                                                        Headline</label>
                                                                                    <asp:TextBox ID="txtHeadline" type="text" class="form-control" Text='<%# Eval("headline") %>' runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHeadline" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter headline" ValidationGroup="updateReview"></asp:RequiredFieldValidator>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <div class="col">
                                                                                    <label class="col-form-label">
                                                                                        <span class="text-danger">*</span>
                                                                                        Your Review</label>
                                                                                    <asp:TextBox TextMode="MultiLine" Rows="7" class="form-control" ID="txtReview" Text='<%# Eval("review") %>' runat="server" Width="100%"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReview" Display="Dynamic" ForeColor="Red" ErrorMessage="Please write a review" ValidationGroup="updateReview"></asp:RequiredFieldValidator>
                                                                                    <div class="help-block pt-10">
                                                                                        <span
                                                                                            class="text-danger">Note:</span>
                                                                                        HTML is not translated!
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group row">
                                                                                <div id="ratingForm" class="col">
                                                                                    <label class="col-form-label">
                                                                                        <span class="text-danger">*</span>
                                                                                        Rating</label>
                                                                                    &nbsp;&nbsp;&nbsp; Bad&nbsp;
                                                                                    <asp:RadioButtonList ID="rblRating" runat="server" SelectedValue='<%# Eval("starRating") %>' RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rb-list">
                                                                                        <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="2"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="3"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="4"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="5"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                    &nbsp;Good
                                                                                </div>
                                                                            </div>
                                                                            <div class="buttons">
                                                                                <asp:Button ID="btnSubmitReview" class="btn btn-sqr" type="submit" runat="server" Text="Continue" CommandName="Review" ValidationGroup="updateReview" />
                                                                                <a href="javascript:void(0);" class="btn btn-sqr" onclick="hideReview(this);">Close</a>
                                                                            </div>
                                                                        </div>
                                                                    </asp:Panel>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <asp:Panel ID="pnlLogin" runat="server">
                                                            <p class="saved-message">
                                                                Write a review
                                                                <asp:LinkButton ID="lnkLogin" runat="server" OnClick="lnkLogin_Click">Login</asp:LinkButton>
                                                            </p>
                                                        </asp:Panel>
                                                        <asp:Panel ID="pnlReviewNew" CssClass="pnlReviewNew" runat="server">
                                                            <div class="review-box" style="border: 1px solid #efefef; padding: 10px; box-shadow: 0px 0px 2px #45cfbe; margin-bottom: 20px;">
                                                                <div class="form-group row">
                                                                    <div class="col">
                                                                        <label class="col-form-label">
                                                                            <span class="text-danger">*</span>
                                                                            Headline</label>
                                                                        <asp:TextBox ID="txtHeadline" type="text" class="form-control" runat="server"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHeadline" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter headline" ValidationGroup="addReview"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <div class="col">
                                                                        <label class="col-form-label">
                                                                            <span class="text-danger">*</span>
                                                                            Your Review</label>
                                                                        <asp:TextBox TextMode="MultiLine" Rows="7" class="form-control" ID="txtReview" runat="server" Width="100%"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReview" Display="Dynamic" ForeColor="Red" ErrorMessage="Please write a review" ValidationGroup="addReview"></asp:RequiredFieldValidator>
                                                                        <div class="help-block pt-10">
                                                                            <span
                                                                                class="text-danger">Note:</span>
                                                                            HTML is not translated!
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group row">
                                                                    <div id="ratingForm" class="col">
                                                                        <label class="col-form-label">
                                                                            <span class="text-danger">*</span>
                                                                            Rating</label>
                                                                        &nbsp;&nbsp;&nbsp; Bad&nbsp;
                                                                                    <asp:RadioButtonList ID="rblRating" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" CssClass="rb-list">
                                                                                        <asp:ListItem Text="" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="2"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="3"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="4"></asp:ListItem>
                                                                                        <asp:ListItem Text="" Value="5" Selected="True"></asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                        &nbsp;Good
                                                                    </div>
                                                                </div>
                                                                <div class="buttons">
                                                                    <asp:Button ID="btnSubmitReview" class="btn btn-sqr" type="submit" runat="server" Text="Continue" CommandName="Review" ValidationGroup="addReview" />
                                                                </div>
                                                            </div>
                                                        </asp:Panel>
                                                    </div>
                                                    <!-- end of review-form -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- product details reviews end -->
                        </div>
                        <!-- product details wrapper end -->
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
    </div>
    <!-- page main wrapper end -->

    <!-- related products area start -->
    <asp:Panel ID="pnlRelatedProduct" runat="server">
        <section class="related-products section-padding">
            <div class="container">
                <%--<uc2:ucrelatedproduct id="UCRelatedProduct1" runat="server" />--%>
                <div class="row">
                    <div class="col-12">
                        <!-- section title start -->
                        <div class="section-title text-center">
                            <h2 class="title">Related Products</h2>
                            <p class="sub-title">This is a new Related products.</p>
                        </div>
                        <!-- section title start -->
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="product-carousel-4 slick-row-10 slick-arrow-style">
                            <asp:Repeater ID="rptRelated" runat="server" OnItemCommand="pnl_ItemCommand">
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
                                                <%-- <%# Convert.ToBoolean(Eval("isNew")) ? "<div class='product-label new'><span>new</span></div>" : "" %>--%>

                                                <div class="product-label discount">
                                                    <span><%# Eval("Discount") %>%</span>
                                                </div>
                                            </div>
                                            <div class="button-group">
                                                <%--<a href="wishlist.html" data-toggle="tooltip" data-placement="left" title="Add to wishlist"><i class="pe-7s-like"></i></a>--%>
                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? "fa fa-heart" : "fa fa-heart-o" %>"></i></asp:LinkButton>
                                                <%--<a href="compare.html" data-toggle="tooltip" data-placement="left" title="Add to Compare"><i class="pe-7s-refresh-2"></i></a>--%>
                                                <%--<a href="#" data-toggle="modal" data-target="#quick_view"><span data-toggle="tooltip" data-placement="left" title="Quick View"><i class="pe-7s-search"></i></span></a>--%>
                                                <a href="../ProductDetail/<%#Eval("SEOName")%>" title="Quick View"><i class="pe-7s-search"></i></a>
                                            </div>
                                            <div class="cart-hover">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>' title="Add to cart" class="btn btn-cart">add to cart</asp:LinkButton>
                                            </div>
                                        </figure>
                                        <div class="product-caption text-center">
                                            <div class="product-identity">
                                                <%--<p class="manufacturer-name"><a href="#"><%# Eval("MaterialName") %></a></p>--%>
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
                                                <span class="price-regular"><%=((main_master)this.Page.Master).CurrencySymbol %><%#Eval("PurchasePrice")%></span>
                                                <span class="price-old"><del><%=((main_master)this.Page.Master).CurrencySymbol %>
                                                    <%#Eval("ProductPrice")%></del></span>
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
    <script src="../assets/js/vendor/jquery-3.3.1.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".vid").click(function () {
                // $(".proimg").hide();
                $(".provid").Show();
            });

            $(".image-additional").click(function () {
                $(".proimg").Show();
                // $(".provid").hide();
            });

            $("#<%= hdnUpdatedQuantity.ClientID %>").val(1);
            $(".pro-qty .qtybtn").click(function () {
                $("#<%= hdnUpdatedQuantity.ClientID %>").val($(this).parent('.pro-qty').children('input[type="text"]').val());
            });

            <%--$("#<%= hdnSize.ClientID %>").val($('.pro-size .nice-select span.current').text());
            $('select.nice-select').on('change', function () {
                $("#<%= hdnSize.ClientID %>").val(this.value);
            });

            $("#<%= hdnColor.ClientID %>").val($(".color-option ul.color-categories li.selected").children('a').attr('name'));
            $(".color-option ul.color-categories li").click(function () {
                $(this).parent().children('li').removeClass('selected');
                $(this).addClass('selected');
                $("#<%= hdnColor.ClientID %>").val($(this).children('a').attr('name'));
            });--%>
            $(".similar-product ul.color-categories li").click(function () {
                $(this).parent().children('li').removeClass('selected');
                $(this).addClass('selected');
            });
            //$(".shop-main-wrapper .product-details-inner .pro-nav.slick-row-10.slick-arrow-style .slick-track").css('transform', 'translate3d(117px, 0px, 0px)');
        });
        //$(window).on("load", function () {
        //    $(".embed-responsive-16by9").hide();
        //});
        function editReview(e) {
            $(e).closest(".add-review").children(".pnlReview").children(".review-box").css("display", "block");
            //$(".pnlReview .review-box").css("display", "block");
            //$(e).closest(".add-review").append($(".pnlReview").html());
            //$(".pnlReview .review-box").css("display", "none");
        }
        function hideReview(e) {
            $(e).closest(".review-box").css("display", "none");
            //$(".review-form .add-review > .review-box").css("display", "none");
        }
    </script>
    <!-- related products area end -->
    <style type="text/css">
        .color-categories li.selected {
            border-color: #45cfbe;
        }

        span.rb-list input[type="radio"]:not(:last-child) {
            margin-right: 10px;
        }

        .color-categories {
            line-height: 0;
            margin-bottom: 18px;
        }

            .color-categories li {
                border-radius: initial;
                margin-right: 5px;
                border-color: #dfdfdf;
            }

        .product-details-reviews #tab_three .total-reviews {
            padding-bottom: 10px;
        }
    </style>
</asp:Content>
