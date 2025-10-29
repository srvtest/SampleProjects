<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="cart.aspx.cs" Inherits="EcommerceWebsite2.cart" %>
<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
                                <li class="breadcrumb-item active">cart</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->
    <!-- cart main wrapper start -->
    <div class="cart-main-wrapper section-padding">
        <div class="container">
            <div class="section-bg-color">
                <asp:Panel ID="pnlEmpty" runat="server">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3>Your Cart is empty.</h3>
                            <p>Check your Saved for later items below or continue shopping.</p>
                            <a href="../products.aspx" class="btn btn-sqr">Continue Shopping</a>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlCart" runat="server" CssClass="panelmar">
                    <div class="row">
                        <div class="col-lg-12">
                            <!-- Cart Table Area -->
                            <div class="cart-table table-responsive">
                                <asp:HiddenField ID="hdnCartUpdate" runat="server" Value="" />
                                <asp:Repeater ID="rptCartProduct" runat="server" EnableViewState="true" OnItemCommand="rptCartProduct_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="tblCart" class="table table-bordered">
                                            <thead>
                                                <tr>
                                                    <th class="pro-thumbnail">Thumbnail</th>
                                                    <th class="pro-title">Product</th>
                                                    <th class="pro-color">Color</th>
                                                    <th class="pro-size">Size</th>
                                                    <th class="pro-shape">Shape</th>
                                                    <th class="pro-price">Price</th>
                                                    <th class="pro-quantity">Quantity</th>
                                                    <th class="pro-subtotal">Total</th>
                                                    <th class="pro-remove">Remove</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="pro-thumbnail details-control"><a href="#">
                                                <img class="img-fluid" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>"></a>
                                                <asp:HiddenField ID="hdnidCustomerCart" runat="server" Value='<%#Eval("idCustomerCart")%>' />
                                            </td>
                                            <td class="pro-title" style="white-space:initial;"><a href="../Productdetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></td>
                                            <td class="pro-Color"><%#Eval("Color")%></td>
                                            <td class="pro-Size"><%#Eval("Size")%></td>
                                            <td class="pro-Shape"><%#Eval("Shape")%></td>
                                            <td class="pro-price"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Price")) %>
                                                    </span>
                                                <asp:HiddenField ID="hdnidProduct" runat="server" Value='<%#Eval("idProduct")%>' />
                                            </td>
                                            <td class="pro-quantity">
                                                <div class="pro-qty">
                                                    <asp:TextBox runat="server" ID="txtQty" ReadOnly="true" Text='<%#Eval("Quantity")%>'></asp:TextBox>
                                                </div>
                                            </td>
                                            <td class="pro-subtotal"><span><%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Total")) %></span></td>
                                            <td class="pro-remove">
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="qtyDelete" OnClientClick="return confirm('Are you sure you want to delete the product.');"><i class="fa fa-trash-o"></i></asp:LinkButton></td>

                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <!-- Cart Update Option -->
                            <div class="cart-update-option d-block d-md-flex justify-content-between">
                                <div class="apply-coupon-wrapper">
                                    <div class="d-block d-md-flex single-input-item">
                                        <input type="text" placeholder="Enter Your Coupon Code" required="required" class="col-sm-4" style="margin-right: 15px;" disabled="disabled" />
                                        <button class="btn btn-sqr" disabled="disabled">Apply Coupon</button>
                                    </div>
                                </div>
                                <div class="cart-update">
                                    <asp:LinkButton ID="btnUpdateCart" runat="server" CssClass="btn btn-sqr" OnClientClick="return SomeFunction();" OnClick="btnUpdateCart_Click">Update Cart</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-5 ml-auto">
                            <!-- Cart Calculation Area -->
                            <div class="cart-calculator-wrapper">
                                <div class="cart-calculate-items">
                                    <h6>Cart Totals</h6>
                                    <div class="table-responsive">
                                        <table class="table">
                                            <tr>
                                                <td>Sub Total</td>
                                                <td><%=((main_master)this.Page.Master).CurrencySymbol %> <%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", SubtotalAmount) %></td>
                                            </tr>
                                            <tr>
                                                <td>Shipping</td>
                                                <% if (freeShippingAmount <= SubtotalAmount || freeShippingCount <= productCount)
                                                    { %>
                                                <td>Free</td>
                                                <% }
                                                    else
                                                    { %>
                                                <td><%=((main_master)this.Page.Master).CurrencySymbol %> <%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", ShipmentCharges) %></td>
                                                <% } %>
                                            </tr>
                                            <tr class="total">
                                                <td>Total</td>
                                                <td class="total-amount"><%=((main_master)this.Page.Master).CurrencySymbol %> <%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", totalAmount) %></td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                                <a href="../products.aspx" class="btn btn-sqr">Continue Shopping</a>
                                <a href="../checkout.aspx" class="btn btn-sqr float-right">Proceed Checkout</a>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <!-- cart main wrapper end -->
    <!-- jQuery JS -->
    <%--<script src="../assets/js/vendor/jquery-3.3.1.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script type="text/javascript">
       
        $(document).ready(function () {
            $(".dec.qtybtn").click(function () {
                //alert(1);
                var sVal = $("#<%= hdnCartUpdate.ClientID %>").val();
                var newVal = sVal.split(",")
                for (var i = 0; i < newVal.length; i++) {
                    if (newVal[i].length > 0) {
                        if (newVal[i].split("♠")[0] == $(this).parents('tr').children('.details-control').children('input[type="hidden"]').val()) {
                            sVal = sVal.replace("," + newVal[i], "");
                        }
                    }
                }
                $("#<%= hdnCartUpdate.ClientID %>").val(sVal);

                $("#<%= hdnCartUpdate.ClientID %>").val($("#<%= hdnCartUpdate.ClientID %>").val() + "," + $(this).parents('tr').children('.details-control').children('input[type="hidden"]').val() + "♠" + $(this).parent('.pro-qty').children('input[type="text"]').val());//ALT+6
                //alert($("#<%= hdnCartUpdate.ClientID %>").val());
            });
            function SomeFunction() {
                var ok = someTestResult;
                if (ok) {
                    return true;
                }
                else {
                    // Display an error message etc...
                    return false;
                }
            }
            $(".inc.qtybtn").click(function () {
                //alert(2);
                var sVal = $("#<%= hdnCartUpdate.ClientID %>").val();
                var newVal = sVal.split(",")
                for (var i = 0; i < newVal.length; i++) {
                    if (newVal[i].length > 0) {
                        if (newVal[i].split("♠")[0] == $(this).parents('tr').children('.details-control').children('input[type="hidden"]').val()) {
                            sVal = sVal.replace("," + newVal[i], "");
                        }
                    }
                }
                $("#<%= hdnCartUpdate.ClientID %>").val(sVal);

                $("#<%= hdnCartUpdate.ClientID %>").val($("#<%= hdnCartUpdate.ClientID %>").val() + "," + $(this).parents('tr').children('.details-control').children('input[type="hidden"]').val() + "♠" + $(this).parent('.pro-qty').children('input[type="text"]').val());//ALT+6
                //alert($("#<%= hdnCartUpdate.ClientID %>").val());
            });
            
            //var table = $(".table").DataTable();
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
    <style type="text/css">
        .cart-table .table{
            white-space:normal;
        }
        .cart-table .table tbody td.child{
            text-align: left;
        }
        .cart-table .table tr .pro-qty{
            display: inline-flex;
            float:none;
        }
        .btn-sqr{
            font-size: inherit;
        }
        .panelmar {
            margin-bottom:50px;
        }
        .marbtn {
            margin-left:10px;
        }
    </style>
</asp:Content>
