<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="WishList.aspx.cs" Inherits="EcommerceWebsite.WishList" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .colour{
                color: blue;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Wish List</h1>
                    <ul>
                        <li><a href="../index">Home</a></li>
                        <li class="active">Wish List</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <%--<div id="column-left" class="col-sm-4 col-lg-3 hidden-xs">
                <uc1:UCTopCategory runat="server" ID="UCTopCategory" />
                <div class="left_banner left-sidebar-widget mb_50 mt_30"><a href="#">
                    <img src="images/left1.jpg" alt="Left Banner" class="img-responsive" /></a> </div>
                <uc1:UCTopProducts runat="server" ID="UCTopProducts" />
            </div>--%>
            <div class="col-sm-8 col-lg-9 mtb_20" style="margin-left: 10px;">
                <div>
                    <asp:Panel ID="pnlEmpty" runat="server">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">WishList Detail<i class="fa fa-caret-down"></i></a></h4>
                        </div>
                        <div class="panel-collapse collapse in">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h3>Your WishList is empty.</h3>
                                        <p>Check your Saved for later items below or continue shopping.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="PnlCart" runat="server">
                        <asp:Repeater ID="rptWishlistProduct" runat="server" OnItemCommand="rptWishlistProduct_ItemCommand">
                            <HeaderTemplate>
                                <div class="table-responsive">
                                    <table class="table table-bordered" style="width:100%">
                                        <thead>
                                           <%-- <tr>
                                                <td class="text-center">Image</td>
                                                <td class="text-left">Product Name</td>
                                                <td class="text-left">Quantity</td>
                                                <td class="text-right">Unit Price</td>
                                                <td class="text-right">Total</td>
                                            </tr>--%>
                                        </thead>
                                        <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td class="text-center" style="width: 120px;"><a href="#">
                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>"></a></td>
                                    <td class="text-left">
                                        <a href"../ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a><br />
                                        <div class="rating"><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span></div>
                                          <span class="price">
                                            <span class="amount">
                                                <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %>.</span>
                                                <%#Eval("Price")%>
                                            </span>
                                            <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice")) ? "<span style='display:none'>" :""%>
                                            <span style="text-decoration: line-through; font-size: x-small;">
                                                <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                                <%#Eval("APrice")%>
                                            </span>
                                            <br />
                                            <span style="font-size: x-small;">You Save: <%#Convert.ToDouble(Eval("APrice"))- Convert.ToDouble(Eval("Price"))%> (<%#Eval("Discount")%>%)</span>
                                            <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice"))  ? "</span>" :""%>
                                        </span>
                                    </td>
                                    <td class="text-left">
                                        <asp:HiddenField ID="hdnidProduct" runat="server" Value='<%#Eval("idProduct")%>' />
                                        <asp:HiddenField ID="hdnidCustomerCart" runat="server" Value='<%#Eval("idWishList")%>' />
                                        <div style="max-width: 200px;" class="input-group btn-block">
                                            
                                            <%--<asp:TextBox runat="server" ID="txtQty" CssClass="qtytextboxsize" Text='<%#Eval("Quantity")%>' class="form-control quantity"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter quentity." ControlToValidate="txtQty"></asp:RequiredFieldValidator>                                            --%>
                                             <span class="input-group-btn">
                                               <asp:LinkButton ID="lnkEdit" runat="server" CommandName="qtyUpdate" CssClass="btn btn-success btn-circle btn-sm">Add to Cart</asp:LinkButton>
                                                 <br />
                                                 <br />
                                                 <br />
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="qtyDelete" CssClass="colour">Remove item</asp:LinkButton>
                                            </span>
                                        </div>
                                    </td>
                                  
                                    <%--<td class="text-right">
                                      
                                    </td>--%>
                                   <%-- <td class="text-right"><%=this.Master.CurrencySymbol %><%#Eval("Total")%></td>--%>
                                </tr>
                               
                            </ItemTemplate>
                            <FooterTemplate>
                              <%--  <tr>
                                    <td class="text-right" colspan="4"><strong>Sub-Total:</strong></td>
                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=SubtotalAmount %></td>
                                </tr>
                                <tr>
                                    <td class="text-right" colspan="4"><strong>Shipping</strong></td>
                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=ShipmentCharges %></td>
                                </tr>
                                <tr>
                                    <td class="text-right" colspan="4"><strong>Total</strong></td>
                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=totalAmount %></td>
                                </tr>--%>

                                </tbody>
                        </table>
                    </div>
                            </FooterTemplate>
                        </asp:Repeater>
                       <%-- <a class="btn pull-left mt_30" href="../index">Continue Shopping</a>
                        <a class="btn pull-right mt_30" href="../checkoutpage">Checkout</a>--%>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <%--<uc1:UCbrandcarouse runat="server" ID="UCbrandcarouse" />--%>
    </div>
</asp:Content>
