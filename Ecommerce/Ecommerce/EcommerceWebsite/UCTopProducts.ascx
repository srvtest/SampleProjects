<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCTopProducts.ascx.cs" Inherits="EcommerceWebsite.UCTopProducts" %>
<%@ Register TagPrefix="mp" TagName="MyMP" Src="~/Main.Master" %>
<div class="left-special left-sidebar-widget mb_50">
    <div class="heading-part mb_10 ">
        <h2 class="main_title">Top Products</h2>
    </div>
    <div id="left-special" class="owl-carousel">
        <asp:Repeater ID="rptProducts" runat="server">
            <HeaderTemplate>
                <ul class="row ">
            </HeaderTemplate>
            <ItemTemplate>
                <li class="item product-layout-left mb_20">
                    <div class="product-list col-xs-4">
                        <div class="product-thumb">
                            <div class="image product-imageblock">
                                <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                    <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" />
                                    <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" />
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xs-8">
                        <div class="caption product-detail">
                            <h6 data-name="product_name" class="product-name mt_20"><a href="../ProductDetail/<%#Eval("SEOName")%>" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a></h6>
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
                        </div>
                    </div>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
