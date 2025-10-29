<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="productdetail.aspx.cs" Inherits="EcommerceWebsiteB2B.productdetail" %>

<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" href="vendors/owl.carousel/css/owl.carousel.min.css" />
    <link href="css/responsive.css" rel="stylesheet" />
    <style>
        .ullist {
            list-style: none;
        }

        .pri-img, .sec-img {
            height: 263px !important;
        }

        .uncheck {
            color: #d3d3d3;
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

        .ullist li {
            display: inline-block;
        }

            .ullist li.selected input, .ullist li:hover input {
                border: 1px solid #fd405e;
            }

            .ullist li input {
                border: 1px solid #c3c3c3;
            }

        .reviewAdd .ratingStars .rb-list input {
            margin-right: 10px;
        }

        .descList dl dt {
            float: left;
            width: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>single product</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">single product</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li><a href="<%= this.Master.baseUrl %>products">Shop</a></li>
                    <li class="active">single product</li>
                </ul>
            </div>
        </div>
    </section>

    <section class="row contentRowPad">
        <div class="container">
            <asp:HiddenField ID="hdnIdpro" runat="server" Value="0" />
            <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound" OnItemCommand="rptProduct_ItemCommand">
                <ItemTemplate>

                    <div class="row singleProduct">
                        <div class="col-sm-7">

                            <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                            <asp:Repeater ID="rptProductImage" runat="server">
                                <HeaderTemplate>
                                    <div class="row m0 flexslider" id="productImageSlider">
                                        <ul class="slides">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <%# Convert.ToString(Eval("type"))=="image" ? ("<div class='pro-large-img img-zoom'><img src='" + DataLayer.CommonControl.GetAdminUrl() + "/ProductImage/" + Eval("url") + "' alt='product-details' /></div>") : ("<div class='embed-responsive embed-responsive-16by9 provid'><iframe src='https://www.youtube.com/embed/"+ Eval("name") + "/hqdefault.jpg' allow='autoplay; encrypted-media' allowfullscreen></iframe></div>") %>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <asp:Repeater ID="rptProductImages" runat="server">
                                <HeaderTemplate>
                                    <div class="row m0 flexslider" id="productImageSliderNav">
                                        <ul class="slides">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <img class='<%#Convert.ToString(Eval("type"))=="image" ? "img-thumbnail" : "vid"%>' src='<%#Convert.ToString(Eval("type"))=="image" ? DataLayer.CommonControl.GetAdminUrl()+"/ProductImage/"+Eval("url") : "http://img.youtube.com/vi/"+Eval("name")+"/hqdefault.jpg"%>' alt="product-details" />
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="col-sm-5">
                            <div class="row m0">
                                <h4 class="heading"><%#Eval("SName")%></h4>
                                <h3 class="heading price">
                                    <span class="price-regular">
                                        <%=this.Master.CurrencySymbol %>
                                        <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %>
                                    </span>
                                    <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                    <span style="text-decoration: line-through; font-size: small;">
                                        <%=this.Master.CurrencySymbol %><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %>
                                    </span>
                                    <br />
                                    <span class="price-old" style="font-size: small;">You Save: <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))) %> (<%#Eval("Discount")%>%)</span>
                                    <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                                </h3>
                                <div class="row m0 starsRow">
                                    <div class="stars fleft" title='<%#Eval("rate")%>'>
                                        <i class='<%# Convert.ToDecimal(Eval("rate")) >= 1 ? "fa fa-star" : "fa fa-star uncheck" %>'></i>
                                        <i class='<%# Convert.ToDecimal(Eval("rate")) >= 2 ? "fa fa-star" : "fa fa-star uncheck" %>'></i>
                                        <i class='<%# Convert.ToDecimal(Eval("rate")) >= 3 ? "fa fa-star" : "fa fa-star uncheck" %>'></i>
                                        <i class='<%# Convert.ToDecimal(Eval("rate")) >= 4 ? "fa fa-star" : "fa fa-star uncheck" %>'></i>
                                        <i class='<%# Convert.ToDecimal(Eval("rate")) >= 5 ? "fa fa-star" : "fa fa-star uncheck" %>'></i>
                                    </div>
                                    <div class="fleft">
                                        <span><%# Eval("Review") %> Reviews</span>
                                    </div>
                                </div>
                                <div class="row descList m0">
                                    <dl class="dl-horizontal">
                                        <dt>size :</dt>
                                        <dd><%# Eval("sSize") %></dd>
                                        <dt>color :</dt>
                                        <dd><%# Eval("sColor") %></dd>
                                        <dt>shape :</dt>
                                        <dd><%# Eval("sShape") %></dd>
                                    </dl>
                                </div>
                                <div class="row m0 shortDesc">
                                    <p class="m0">
                                        <asp:Label ID="lblFeatures" runat="server" ClientIDMode="Static" Text='<%# Limit(Eval("Features"),30) %>' ToolTip='<%# Eval("Features") %>'></asp:Label>
                                        <asp:LinkButton ID="ReadMoreLinkButton" runat="server" CommandName="Readmore" Text="Read More" Visible='<%# SetVisibility(Eval("Features"), 30) %>'></asp:LinkButton>
                                    </p>
                                </div>
                                <div class="row m0">
                                    <ul class="ullist" style="padding-left: 0; margin-top: 20px;">
                                        <asp:Repeater ID="rptSimilarProduct" runat="server">
                                            <ItemTemplate>
                                                <li class='<%# Convert.ToInt32(Eval("idProduct")) == Convert.ToInt32(hdnIdpro.Value) ? "selected" : "" %>'>
                                                    <asp:ImageButton ID="btnProduct" runat="server" Width="50" ToolTip='<%# Eval("SEOName") %>' OnClick="btnProduct_Click" CommandArgument='<%# Eval("idProduct") %>' ImageUrl='<%# DataLayer.CommonControl.GetAdminUrl() + "/ProductImage/" + Eval("ImageURL") %>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                                <div class="row m0">
                                    <ul class="list-inline wce">
                                        <li>
                                            <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"])) ? "fas fa-heart" : "far fa-heart" %>"></i><span> </span><%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"]))  ? "Wishlisted" : "Add to Wishlist" %>Add to Wishlist</asp:LinkButton>
                                        </li>
                                    </ul>
                                </div>
                                <div class="row m0 qtyAtc">
                                    <div class="fleft quantity">
                                        <div class="fleft">Qty <span>=</span></div>
                                        <div class="input-group spinner">
                                            <input type="text" class="form-control" readonly="readonly" value="1" style="background: #fff">
                                            <asp:HiddenField ID="hdnQty" Value='1' runat="server" />
                                            <div class="input-group-btn-vertical">
                                                <button runat="server" class="btn btn-default"><i class="fas fa-angle-up"></i></button>
                                                <button runat="server" class="btn btn-default"><i class="fas fa-angle-down"></i></button>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:LinkButton ID="btnCartAdd" class="btn btn-cart2" ClientIDMode="Static" CommandName="CrtAdd" Text="Add to Cart" runat="server"><img src="<%= this.Master.baseUrl %>images/icons/cart3.png" alt="" /> Add to Cart</asp:LinkButton>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="row m0 tabRow">
                        <ul class="nav nav-tabs" role="tablist" id="shortcodeTab">
                            <li role="presentation" class="active"><a href="#description" aria-controls="description" role="tab" data-toggle="tab">
                                <i class="fas fa-align-left"></i>description
                            </a></li>
                            <li role="presentation"><a href="#review" aria-controls="review" role="tab" data-toggle="tab">
                                <i class="fas fa-thumbs-up"></i>review (1)
                            </a></li>
                            <li role="presentation"><a href="#additionInfo" aria-controls="additionInfo" role="tab" data-toggle="tab">
                                <i class="fas fa-file-text"></i>Additional Information
                            </a></li>
                        </ul>
                        <div class="tab-content shortcodeTabContent">
                            <div role="tabpanel" class="tab-pane row m0 active" id="description">
                                <div class="fleft img">
                                    <img class="img-responsive" src="<%= this.Master.baseUrl %>images/product/10.png" alt="" />
                                </div>
                                <div class="fleft desc">
                                    <h5 class="heading">Product Details</h5>
                                    <p>
                                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                                    </p>
                                </div>
                            </div>
                            <div role="tabpanel" class="tab-pane row m0" id="review">
                                <asp:HiddenField ID="hdnidCustomerReview" runat="server" Value="0" />
                                <div class="row m0 reviewCount">
                                    <h5><%# Eval("Review") %> review for <span><%#Eval("SName")%></span></h5>
                                    <asp:Repeater ID="rptReviews" runat="server" OnItemCommand="rptReviews_ItemCommand">
                                        <ItemTemplate>
                                            <div class="add-review">
                                                <div class="total-reviews">
                                                    <%--<div class="rev-avatar">
                                                        <img src="../assets/img/about/avatar.jpg" alt="">
                                                    </div>--%>
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
                                                    <div class="review-box" style="display: none;">
                                                        <div class="row mb15">
                                                            <div class="col-sm-12">
                                                                <label class="col-form-label">
                                                                    <span class="text-danger">*</span>
                                                                    Headline</label>
                                                                <asp:TextBox ID="txtHeadline" type="text" class="form-control" Text='<%# Eval("headline") %>' runat="server"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHeadline" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter headline" ValidationGroup="updateReview"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row mb15">
                                                            <div class="col-sm-12">
                                                                <label class="col-form-label">
                                                                    <span class="text-danger">*</span>
                                                                    Your Review</label>
                                                                <asp:TextBox TextMode="MultiLine" Rows="7" class="form-control" ID="txtReview" Text='<%# Eval("review") %>' runat="server" Width="100%"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReview" Display="Dynamic" ForeColor="Red" ErrorMessage="Please write a review" ValidationGroup="updateReview"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="help-block pt-10" style="margin-left: 15px;">
                                                                <span
                                                                    class="text-danger">Note:</span>
                                                                HTML is not translated!
                                                            </div>
                                                        </div>
                                                        <div class="row mb15">
                                                            <div id="ratingForm" class="col-sm-12 ratingStars">
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
                                                        <div class="row mb15">
                                                            <div class="col-sm-12">
                                                                <asp:Button ID="btnSubmitReview" class="btn btn-primary filled" type="submit" runat="server" Text="Continue" CommandName="Review" ValidationGroup="updateReview" />
                                                                <a href="javascript:void(0);" class="btn btn-primary filled" onclick="hideReview(this);">Close</a>
                                                            </div>
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
                                        <div class="row m0 reviewAdd">
                                            <h4 class="heading">Add a review</h4>
                                            <div class="row m0 reviewForm">
                                                <div class="row mb15">
                                                    <div class="col-sm-12">
                                                        <label class="col-form-label">
                                                            <span class="text-danger">*</span>
                                                            Headline</label>
                                                        <asp:TextBox ID="txtHeadline" type="text" class="form-control" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHeadline" Display="Dynamic" ForeColor="Red" ErrorMessage="Please enter headline" ValidationGroup="addReview"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row mb15">
                                                    <div class="col-sm-12">
                                                        <label class="col-form-label">
                                                            <span class="text-danger">*</span>
                                                            Your Review</label>
                                                        <asp:TextBox TextMode="MultiLine" Rows="7" class="form-control reviewText" ID="txtReview" runat="server" Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtReview" Display="Dynamic" ForeColor="Red" ErrorMessage="Please write a review" ValidationGroup="addReview"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="help-block pt-10" style="margin-left: 15px;">
                                                        <span
                                                            class="text-danger">Note:</span>
                                                        HTML is not translated!
                                                    </div>
                                                </div>
                                                <div class="row mb15">
                                                    <div id="ratingForm" class="col-sm-12 ratingStars">
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
                                                <div class="row mb15">
                                                    <div class="col-sm-12">
                                                        <asp:Button ID="btnSubmitReview" class="btn btn-primary filled" type="submit" runat="server" Text="Submit" CommandName="Review" ValidationGroup="addReview" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <!-- end of review-form -->
                            </div>
                            <div role="tabpanel" class="tab-pane row m0" id="additionInfo">
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Item Type</div>
                                    <div class="fleft infos"><a style="font-weight: bold;" href="<%= this.Master.baseUrl %>products/main=<%#Eval("MasterCategory")%>"><%#Eval("MasterCategory")%></a></div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Category</div>
                                    <div class="fleft infos"><a style="font-weight: bold;" href="<%= this.Master.baseUrl %>products/category=<%#Eval("CategoryName")%>"><%#Eval("CategoryName")%></a></div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Collection</div>
                                    <div class="fleft infos"><%#Eval("Collection")%></div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Material</div>
                                    <div class="fleft infos"><%#Eval("Material")%></div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Stone </div>
                                    <div class="fleft infos"><%#Eval("gemstone")%></div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">GENDER</div>
                                    <div class="fleft infos"><%#Eval("gender")%></div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Resizable?  </div>
                                    <div class="fleft infos">No</div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Item Height </div>
                                    <div class="fleft infos">4.3 Millimeters </div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Item Width</div>
                                    <div class="fleft infos">2.5 Millimeters </div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Item Width</div>
                                    <div class="fleft infos">2.5 Millimeters </div>
                                </div>
                                <div class="row m0 additionInfoRow">
                                    <div class="fleft infoTitle">Ring Size</div>
                                    <div class="fleft infos">7</div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--Tabs Row-->
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
    <asp:Panel ID="pnlRelatedProduct" runat="server">
        <section id="RelatedProduct" class="row contentRowPad">
            <div class="container">
                <div class="row sectionTitle">
                    <h3>Related Products</h3>
                    <h5>know more about our Related collection</h5>
                </div>

                <div class="col-sm-3 featureCats owl-carousel">
                    <asp:Repeater ID="rptRelated" runat="server" OnItemCommand="pnl_ItemCommand">
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
                                                        <asp:LinkButton ID="btnWishlist" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && !string.IsNullOrEmpty(Convert.ToString(Session["CustomerId"]))  ? "fas fa-heart" : "far fa-heart" %>"></i></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <a href="<%= this.Master.baseUrl %>productdetail/<%#Eval("SEOName")%>" title="Quick View"><i class="fas fa-expand"></i></a>
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
                                            <div class="row m0 proPrice"><i class="fas fa-usd"></i><%=((main_master)this.Page.Master).CurrencySymbol %><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Convert.ToDouble(Eval("PurchasePrice"))) %></div>
                                        </div>
                                    </div>
                                    <div class="row m0 proName"><a href="<%= this.Master.baseUrl %>productdetail/<%#Eval("SEOName")%>" title='<%#Eval("sName")%>'><%# Convert.ToString(Eval("sName")).Length > 60 ? Convert.ToString(Eval("sName")).Substring(0,60) + "..." : Eval("sName") %></a></div>
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
    <script src="vendors/owl.carousel/js/owl.carousel.min.js"></script>
    <script>
        $(document).ready(function () {
            $(".vid").click(function () {
                $(".provid").Show();
            });

            $(".image-additional").click(function () {
                $(".proimg").Show();
            });
        });
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
</asp:Content>
