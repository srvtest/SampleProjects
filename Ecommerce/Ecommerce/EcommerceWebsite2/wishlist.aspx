<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="wishlist.aspx.cs" Inherits="EcommerceWebsite2.wishlist" %>
<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .nice-select {
            width: 100px !important;
        }
        .cart-table .table {
            white-space: normal !important;
        }
        .table-responsive{
            overflow-x:inherit;
        }
        .cart-table .table tbody td.child{
            text-align: left;
        }
        .cart-table .table tr .dtr-data{
            display: inline-flex;
            float:none;
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
                                    <li class="breadcrumb-item active">wishlist</li>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- breadcrumb area end -->

        <!-- wishlist main wrapper start -->
        <div class="wishlist-main-wrapper section-padding">
            <div class="container">
                <!-- Wishlist Page Content Start -->
                <div class="section-bg-color">
                    <asp:Panel ID="pnlEmpty" runat="server">
                        <div class="row">
                            <div class="col-lg-12">
                                <h3>Your Wishlist is empty.</h3>
                                <p>Check your Saved for later items below or continue shopping.</p>
                                <a href="../products.aspx" class="btn btn-sqr">Continue Shopping</a>
                            </div>
                            
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PnlWishlist" runat="server">
                        <div class="row">
                            <div class="col-lg-12">
                                <!-- Wishlist Table Area -->
                                <div class="cart-table table-responsive">
                                    <asp:Repeater ID="rptWishlistProduct" runat="server" OnItemCommand="rptWishlistProduct_ItemCommand" OnItemDataBound="rptWishlistProduct_ItemDataBound">
                                        <HeaderTemplate>
                                            <table class="table table-bordered">
                                                <thead>
                                                    <tr>
                                                        <th class="pro-thumbnail">Thumbnail</th>
                                                        <th class="pro-title">Product</th>
                                                        <th class="pro-color">Color</th>
                                                        <th class="pro-size">Size</th>
                                                        <th class="pro-shape">Shape</th>
                                                        <th class="pro-price">Price</th>
                                                        <th class="pro-quantity">Status</th>
                                                        <th class="pro-subtotal">Add to Cart</th>
                                                        <th class="pro-remove">Remove</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td class="pro-thumbnail">
                                                    <asp:HiddenField ID="hdnidProduct" runat="server" Value='<%#Eval("idProduct")%>' />
                                                    <asp:HiddenField ID="hdnidCustomerCart" runat="server" Value='<%#Eval("idWishList")%>' />
                                                    <a href="#">
                                                        <img class="img-fluid" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>">
                                                    </a>
                                                </td>
                                                <td class="pro-title" style="white-space:initial;">
                                                    <a href="../ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a>
                                                </td>
                                                <td class="pro-Color">
                                                    <span class="text-dark"><%# Eval("Color") %></span>
                                                </td>
                                                <td class="pro-Size">
                                                    <span class="text-dark"><%# Eval("Size") %></span>
                                                </td>
                                                <td class="pro-Shape">
                                                    <span class="text-dark"><%# Eval("Shape") %></span>
                                                </td>
                                                <td class="pro-price">
                                                    <span class="amount">
                                                        <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                        <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Price")) %>
                                                    </span>
                                                    <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice")) ? "<span style='display:none'>" :""%>
                                                    <br />
                                                    <span style="text-decoration: line-through; font-size: x-small;">
                                                        <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                        <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("APrice")) %>
                                                    </span>
                                                    <br />
                                                    <span style="font-size: x-small;white-space: nowrap;">You Save: <%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Convert.ToDouble(Eval("APrice")) - Convert.ToDouble(Eval("Price"))) %> (<%#Eval("Discount")%>%)</span>
                                                    <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice"))  ? "</span>" :""%>
                                                </td>
                                                <td class="pro-quantity">
                                                    <span class="text-success">In Stock</span>
                                                </td>
                                                <td class="pro-subtotal">
                                                    <%--<a href="cart.html" class="btn btn-sqr">Add to Cart</a>--%>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" class="btn btn-sqr" CommandName="qtyUpdate">Add to Cart</asp:LinkButton>
                                                </td>
                                                <td class="pro-remove">
                                                    <%--<a href="#">
                                                    <i class="fa fa-trash-o"></i>
                                                </a>--%>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="qtyDelete" class="fa fa-trash-o"></asp:LinkButton>
                                                </td>
                                            </tr>

                                            <%-- <tr>
                                            <td class="pro-thumbnail"><a href="#">
                                                <img class="img-fluid" src="assets/img/product/product-8.jpg" alt="Product" /></a></td>
                                            <td class="pro-title"><a href="#">Diamond Exclusive Ornament</a></td>
                                            <td class="pro-price"><span>$110.00</span></td>
                                            <td class="pro-quantity"><span class="text-success">In Stock</span></td>
                                            <td class="pro-subtotal"><a href="cart.html" class="btn btn-sqr">Add to
                                                    Cart</a></td>
                                            <td class="pro-remove"><a href="#"><i class="fa fa-trash-o"></i></a></td>
                                        </tr>--%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                    </table>
                          
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <!-- Wishlist Page Content End -->
            </div>
        </div>
        <!-- wishlist main wrapper end -->
    <%--<script src="../assets/js/vendor/jquery-3.3.1.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script>
        $(document).ready(function () {
            <%--$("#<%= PnlWishlist.ClientID %> table tbody tr td.pro-thumbnail .h-size input[type='hidden']").val($("#<%= PnlWishlist.ClientID %> table tbody tr:first td.pro-Size select.nice-select").val());
            $('table tbody').on('change', 'select.nice-select.p-size', function () {
                $(this).parents('tbody').children('.h-size input').val(this.value);
                debugger;
            });
            
            $("#<%= PnlWishlist.ClientID %> table tbody tr td.pro-thumbnail .h-color input[type='hidden']").val($("#<%= PnlWishlist.ClientID %> table tbody tr:first td.pro-Color select.nice-select").val());
            $('table tbody').on('change', 'select.nice-select.p-color', function () {
                $(this).parents('tbody').children('.h-color input').val(this.value);
            });--%>
            var table = $(".table").DataTable({
                rowReorder: {
                    selector: 'td:nth-child(2)'
                },
                searching: false,
                paging: false,
                info: false,
                ordering: false,
                responsive: true
            });
        });
    </script>

</asp:Content>
