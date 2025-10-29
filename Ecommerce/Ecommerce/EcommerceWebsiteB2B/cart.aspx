<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="cart.aspx.cs" Inherits="EcommerceWebsiteB2B.cart" %>

<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
    <%--<link href="css/rowReorder.dataTables.min.css" rel="stylesheet" />--%>
    <link href="css/responsive.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>SHOPPING CART</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">SHOPPING CART</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">SHOPPING CART</li>
                </ul>
            </div>
        </div>
    </section>
    <section class="row contentRowPad">
        <div class="container">
            <div class="cartPage">
                <h3 class="heading pageHeading">SHOPPING CART</h3>
                <asp:Panel ID="pnlEmpty" runat="server">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3>Your Shopping Cart is empty.</h3>
                            <p>Check your Saved for later items below or continue shopping.</p>
                            <a href="<%= this.Master.baseUrl %>products.aspx" class="addToCart btn btn-primary btn-lg filled">Continue Shopping</a>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlCart" runat="server">
                    <div class="cartTable row m0" style="margin-bottom: 0px;">
                        <asp:HiddenField ID="hdnCartUpdate" runat="server" Value="" />
                        <asp:Repeater ID="rptCartProduct" runat="server" EnableViewState="true" OnItemCommand="rptCartProduct_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-bordered table-responsive" id="example" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th class="productImage text-center">Product image</th>
                                            <th class="productName text-center">Product name</th>
                                            <th class="text-center">price</th>
                                            <th class="text-center">quantity</th>
                                            <th class="text-center">total</th>
                                            <th class="text-center">remove</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="alert" role="alert">
                                    <td class="productImage">
                                        <asp:HiddenField ID="hdnidProduct" runat="server" Value='<%#Eval("idProduct")%>' />
                                        <a href="<%= this.Master.baseUrl %>productdetail/<%#Eval("SEOName")%>">
                                            <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>">
                                        </a>
                                    </td>
                                    <td class="productName">
                                        <h6 class="heading" style="white-space: initial;"><a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></h6>
                                        <div class="row descList m0">
                                            <dl class="dl-horizontal">
                                                <dt>color :</dt>
                                                <dd><%# Eval("Color") %></dd>
                                                <dt>size :</dt>
                                                <dd><%# Eval("Size") %></dd>
                                                <dt>shape :</dt>
                                                <dd><%# Eval("Shape") %></dd>
                                            </dl>
                                        </div>
                                    </td>
                                    <td class="price">
                                        <span class="amount">
                                            <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Price")) %>
                                        </span>
                                        <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice")) ? "<span style='display:none'>" :""%>
                                        <br />
                                        <del style="font-size: x-small;">
                                            <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("APrice")) %>
                                        </del>
                                        <span style="font-size: x-small;">You Save: <%=((main_master)this.Page.Master).CurrencySymbol %><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Convert.ToDecimal(Eval("APrice")) - Convert.ToDecimal(Eval("Price"))) %> (<%#Eval("Discount")%>%)</span>
                                        <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice"))  ? "</span>" :""%>
                                    </td>
                                    <td>
                                        <div class="idcust">
                                            <asp:HiddenField ID="hdnidCustomerCart" runat="server" Value='<%#Eval("idCustomerCart")%>' />
                                        </div>
                                        <div class="input-group spinner">
                                            <input type="text" disabled="disabled" class="form-control" value="<%#Eval("Quantity")%>" style="background: #fff">
                                            <asp:HiddenField ID="hdnQty" Value='<%# Eval("Quantity") %>' runat="server" />
                                            <div class="input-group-btn-vertical">
                                                <button class="btn btn-default"><i class="fas fa-angle-up"></i></button>
                                                <button class="btn btn-default"><i class="fas fa-angle-down"></i></button>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="price">
                                        <span><%=((main_master)this.Page.Master).CurrencySymbol %><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Total")) %></span>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="qtyDelete" class="edit far fa-trash-alt"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                          <%--  <tfoot>
                                <tr>
                                    <td colspan="7">
                                       
                                    </td>
                                </tr>
                            </tfoot>--%>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                    <div class="row m0 mb30">
                        <table class="table table-bordered table-responsive" style="width: 100%">
                            <tr>
                                <td>
                                    <a href="<%= this.Master.baseUrl %>products.aspx" class="btn btn-primary" style="padding: 0 10px;">continue shopping</a>
                                    <asp:LinkButton ID="btnUpdateCart" runat="server" CssClass="btn btn-default fright" Style="padding: 0 10px;" OnClick="btnUpdateCart_Click">update cart</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="row m0">
                        <div class="col-sm-4 col-sm-offset-8" style="padding-right: 0; padding-left: 0;">
                            <div class="row m0 totalCheckout">
                                <div class="descList row m0">
                                    <table class="table">
                                        <tr>
                                            <td>Sub Total</td>
                                            <td><%=((main_master)this.Page.Master).CurrencySymbol %><%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", SubtotalAmount) %></td>
                                        </tr>
                                        <tr>
                                            <td>Shipping</td>
                                            <% if (freeShippingAmount <= SubtotalAmount || freeShippingCount <= productCount)
                                                { %>
                                            <td>Free</td>
                                            <% }
                                                else
                                                { %>
                                            <td><%=((main_master)this.Page.Master).CurrencySymbol %><%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", ShipmentCharges) %></td>
                                            <% } %>
                                        </tr>
                                        <tr class="total">
                                            <td>Total</td>
                                            <td class="total-amount"><%=((main_master)this.Page.Master).CurrencySymbol %><%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", totalAmount) %></td>
                                        </tr>
                                    </table>
                                </div>
                                <a href="<%= this.Master.baseUrl %>checkout.aspx" class="btn btn-default btn-sm">Proceed to Checkout</a>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </section>
    <script src="<%= baseUrl %>js/jquery-3.5.1.js"></script>
    <script src="<%= baseUrl %>js/jquery.dataTables.min.js"></script>
    <%--<script src="<%= baseUrl %>js/dataTables.rowReorder.min.js"></script>--%>
    <script src="<%= baseUrl %>js/dataTables.responsive.min.js"></script>
    <style type="text/css">
        .dl-horizontal dt {
            float: left;
            width: 60px;
            clear: left;
            text-align: right;
            overflow: hidden;
            text-overflow: ellipsis;
            white-space: nowrap;
        }

        .spinner {
            height: 36px;
        }

        /*.cartTable .table {
            white-space: normal;
        }*/
        table.table-responsive.dataTable tbody td.child ul li {
            float: left;
            clear: both;
            display: inline-flex;
        }

            table.table-responsive.dataTable tbody td.child ul li:nth-of-type(2) span.dtr-title, table.table-responsive.dataTable tbody td.child ul li:nth-of-type(4) span.dtr-title {
                line-height: 2.6em;
            }

        /*.cartTable .table tbody td.child {
                text-align: left;
            }

            .cartTable .table tr .pro-qty {
                display: inline-flex;
                float: none;
            }*/

        /*.btn-sqr {
            font-size: inherit;
        }*/

        /*.panelmar {
            margin-bottom: 50px;
        }

        .marbtn {
            margin-left: 10px;
        }*/
    </style>
    <script type="text/javascript">
        //var $dt = jQuery.noConflict();
        //alert("Version: " + $dt.fn.jquery);
        $(document).ready(function () {
            var table = $(".table").dataTable({
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
        $(function () {
            $('#example.table-responsive .spinner .btn:first-of-type').on('click', function () {
                var sVal = $("#<%= hdnCartUpdate.ClientID %>").val();
                var newVal = sVal.split(",")
                for (var i = 0; i < newVal.length; i++) {
                    if (newVal[i].length > 0) {
                        if (newVal[i].split("♠")[0] == $(this).closest('td').children('.idcust').children('input[type=hidden]').val()) {
                            sVal = sVal.replace("," + newVal[i], "");
                        }
                    }
                }
                $("#<%= hdnCartUpdate.ClientID %>").val(sVal);
                $("#<%= hdnCartUpdate.ClientID %>").val($("#<%= hdnCartUpdate.ClientID %>").val() + "," + $(this).closest('td').children('.idcust').children('input[type=hidden]').val() + "♠" + (parseInt($(this).closest('.spinner').children('input[type=hidden]').val(), 10) + 1).toString());//♠=ALT+6
            });
            $("#example.table-responsive .spinner .btn:last-of-type").click(function () {
                if (parseInt($(this).closest('.spinner').children('input[type=hidden]').val(), 10) > 1) {
                    var sVal = $("#<%= hdnCartUpdate.ClientID %>").val();
                    var newVal = sVal.split(",")
                    for (var i = 0; i < newVal.length; i++) {
                        if (newVal[i].length > 0) {
                            if (newVal[i].split("♠")[0] == $(this).closest('td').children('.idcust').children('input[type=hidden]').val()) {
                                sVal = sVal.replace("," + newVal[i], "");
                            }
                        }
                    }
                    $("#<%= hdnCartUpdate.ClientID %>").val(sVal);
                    $("#<%= hdnCartUpdate.ClientID %>").val($("#<%= hdnCartUpdate.ClientID %>").val() + "," + $(this).closest('td').children('.idcust').children('input[type=hidden]').val() + "♠" + (parseInt($(this).closest('.spinner').children('input[type=hidden]').val(), 10) - 1).toString());//♠=ALT+6
                }
            });
        });
    </script>
</asp:Content>
