<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="wishlist.aspx.cs" Inherits="EcommerceWebsiteB2B.wishlist" %>

<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="css/rowReorder.dataTables.min.css" rel="stylesheet" />
    <link href="css/responsive.dataTables.min.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>Wishlist</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">Wishlist</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">Wishlist</li>
                </ul>
            </div>
        </div>
    </section>
    <section class="row contentRowPad">
        <div class="container">
            <div class="cartPage">
                <h3 class="heading pageHeading">Wishlist</h3>
                <asp:Panel ID="pnlEmpty" runat="server">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3>Your Wishlist is empty.</h3>
                            <p>Check your Saved for later items below or continue shopping.</p>
                            <a href="<%= this.Master.baseUrl %>products.aspx" class="addToCart btn btn-primary btn-lg filled">Continue Shopping</a>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="PnlWishlist" runat="server">
                    <div class="cartTable row m0">
                        <asp:Repeater ID="rptWishlistProduct" runat="server" OnItemCommand="rptWishlistProduct_ItemCommand" OnItemDataBound="rptWishlistProduct_ItemDataBound">
                            <HeaderTemplate>
                                <table class="table table-bordered table-responsive" id="example" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <%-- <th>Seq.</th>--%>
                                            <th class="productImage text-center">Product image</th>
                                            <th class="productName text-center">Product name</th>
                                            <%--  <th class="text-center">color</th>
                                            <th class="text-center">size</th>
                                            <th class="text-center">shape</th>--%>
                                            <th class="text-center">price</th>
                                            <th class="text-center">Stock Status</th>
                                            <th class="text-center">Add to cart</th>
                                            <th class="text-center">remove</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr class="alert" role="alert">
                                    <%-- <td><%# Container.ItemIndex + 1 %></td>--%>
                                    <td class="productImage">
                                        <asp:HiddenField ID="hdnidProduct" runat="server" Value='<%#Eval("idProduct")%>' />
                                        <asp:HiddenField ID="hdnidCustomerCart" runat="server" Value='<%#Eval("idWishList")%>' />
                                        <img src="<%= this.Master.baseUrl %>images/product/single/l1.png" alt="" />
                                        <a href="#">
                                            <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>">
                                        </a>
                                    </td>
                                    <td class="productName">
                                        <h6 class="heading" style="white-space:initial;">
                                            <a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a>
                                        </h6>
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
                                    <%-- <td><%# Eval("Color") %></td>
                                    <td><%# Eval("Size") %></td>
                                    <td><%# Eval("Shape") %></td>--%>
                                    <td class="price">
                                        <span class="amount">
                                            <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %> </span>
                                            <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Price")) %>
                                        </span>
                                        <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice")) ? "<span style='display:none'>" :""%>
                                        <br />
                                        <span style="text-decoration: line-through; font-size: x-small;">
                                            <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                            <%#String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("APrice"))%>
                                        </span>
                                        <br />
                                        <span style="font-size: x-small;">You Save: <%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Convert.ToDouble(Eval("APrice"))- Convert.ToDouble(Eval("Price"))) %> (<%#Eval("Discount")%>%)</span>
                                        <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice"))  ? "</span>" :""%>
                                    </td>
                                    <td>
                                        <span class="text-success">In Stock</span>
                                    </td>
                                    <td>
                                        <asp:Button ID="lnkEdit" runat="server" class="btn btn-primary btn-lg filled" CommandName="qtyUpdate" Text="Add to Cart" />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="qtyDelete" class="edit far fa-trash-alt"></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                        </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </asp:Panel>
            </div>
        </div>
    </section>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
   <script src="<%= baseUrl %>js/jquery-3.5.1.js"></script> 
     <script src="<%= baseUrl %>js/jquery.dataTables.min.js"></script>    
    <script src="<%= baseUrl %>js/dataTables.rowReorder.min.js"></script>
   <script src="<%= baseUrl %>js/dataTables.responsive.min.js"></script>
    <script>
        //var table = $(".table").DataTable({
        //    searching: false,
        //    paging: false,
        //    info: false,
        //    ordering: false,
        //    responsive: true,
        //    columnDefs: [
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null,
        //        null
        //    ]
        //});
        //$(document).ready(function () {
        //    var table = $('#example').DataTable({
        //        rowReorder: {
        //            selector: 'td:nth-child(2)'
        //        },
        //        responsive: true
        //    });
        //});
        //$(document).ready(function () {
        //    var table = $('#example').DataTable({
        //        responsive: true
        //    });

        //    new $.fn.dataTable.FixedHeader(table);
        //});
        $(document).ready(function () {
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
        .cartTable .table {
            white-space: normal;
        }

            .cartTable .table tbody td.child {
                text-align: left;
            }

            .cartTable .table tr .pro-qty {
                display: inline-flex;
                float: none;
            }

        .btn-sqr {
            font-size: inherit;
        }

        .panelmar {
            margin-bottom: 50px;
        }

        .marbtn {
            margin-left: 10px;
        }
         /*.descList dl dt {	
                float: left;
                width: 160px;
            }*/
    </style>
</asp:Content>
