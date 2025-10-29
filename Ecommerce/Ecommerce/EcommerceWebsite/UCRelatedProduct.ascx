<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRelatedProduct.ascx.cs" Inherits="EcommerceWebsite.UCRelatedProduct" %>
<%@ Register TagPrefix="mp" TagName="MyMP" Src="~/Main.Master" %>
<div class="heading-part text-center mb_10">
    <h2 class="main_title mt_50">Related Products</h2>
</div>
<div class="related_pro box">
    <div class="product-layout  product-grid related-pro  owl-carousel mb_50 ">

        <asp:Repeater runat="server" ID="rptProducts">
            <ItemTemplate>
                <div class="item">
                    <div class="product-thumb">
                        <div class="image product-imageblock">
                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;" />
                                <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="min-height: 272px; max-height: 272px;"/>
                            </a>
                            <div class="button-group text-center">
                                <div class="wishlist"><a href="#"><span>wishlist</span></a></div>
                                <div class="quickview"><a href="#"><span>Quick View</span></a></div>
                                <div class="compare"><a href="#"><span>Compare</span></a></div>
                                <div class="add-to-cart"><a href="#"><span>Add to cart</span></a></div>
                            </div>
                        </div>
                        <div class="caption product-detail text-center">
                            <h6 data-name="product_name" class="product-name mt_20"><a href="#" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a></h6>
                            <div class="rating"><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span></div>
                            <span class="price">
                                <span class="amount">
                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                    <%#Eval("PurchasePrice")%>
                                </span>
                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                <span style="text-decoration: line-through; font-size: x-small;">
                                    <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                    <%#Eval("ProductPrice")%>
                                </span>
                                <br />
                                <span style="font-size: x-small;">You Save: <%#Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))%> (<%#Eval("Discount")%>%)</span>
                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                            </span>
                            <p class="product-desc mt_20 mb_60"><%#Eval("Features")%></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>

        </asp:Repeater>
    </div>
</div>
