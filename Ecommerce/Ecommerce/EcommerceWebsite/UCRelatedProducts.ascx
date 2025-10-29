<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCRelatedProducts.ascx.cs" Inherits="EcommerceWebsite.UCRelatedProducts" %>
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
                    <a href="product_detail_page.html">
                        <img data-name="product_image" src="../images/product/product7.jpg" alt="iPod Classic" title="iPod Classic" class="img-responsive">
                        <img src="../images/product/product7-1.jpg" alt="iPod Classic" title="iPod Classic" class="img-responsive">
                    </a>
                    <div class="button-group text-center">
                        <div class="wishlist"><a href="#"><span>wishlist</span></a></div>
                        <div class="quickview"><a href="#"><span>Quick View</span></a></div>
                        <div class="compare"><a href="#"><span>Compare</span></a></div>
                        <div class="add-to-cart"><a href="#"><span>Add to cart</span></a></div>
                    </div>
                </div>
                <div class="caption product-detail text-center">
                    <h6 data-name="product_name" class="product-name mt_20"><a href="#" title="Casual Shirt With Ruffle Hem">New LCDScreen and HD Video Recording</a></h6>
                    <div class="rating">
                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span>
                    </div>
                    <span class="price"><span class="amount"><span class="currencySymbol">><%=((main_master)this.Page.Master).CurrencySymbol %></span>70.00</span>
                    </span>
                </div>
            </div>
        </div>
            </ItemTemplate>

        </asp:Repeater>
    </div>
</div>
