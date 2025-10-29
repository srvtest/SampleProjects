<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="categorypage.aspx.cs" Inherits="EcommerceWebsite.categorypage" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>
<%@ Register Src="~/UCTopProducts.ascx" TagPrefix="uc1" TagName="UCTopProducts" %>
<%@ Register Src="~/UCbrandcarouse.ascx" TagPrefix="uc1" TagName="UCbrandcarouse" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .product-layout.product-grid {
            min-height: 430px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
        <asp:HiddenField ID="hdMode" runat="server" Value="grid" />
        <%--<asp:HiddenField ID="hdPageSize" runat="server" Value="10" />--%>
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>
                        <asp:Label runat="server" ID="lblCategory"></asp:Label>
                    </h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Products</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <div id="column-left" class="col-sm-4 col-lg-3 ">
                <uc1:UCTopCategory runat="server" ID="UCTopCategory" />
                <uc1:UCTopProducts runat="server" ID="UCTopProducts" />
            </div>

            <div class="col-sm-8 col-lg-9 mtb_20">
                <div class="category-page-wrapper mb_30">
                    <div class="list-grid-wrapper pull-left">
                        <div class="btn-group btn-list-grid">
                            <asp:HiddenField ID="hdnviewType" runat="server" Value="GRID" ClientIDMode="Static" />
                            <button type="button" id="grid-view" class="btn btn-default grid-view <%=(ListViewtype=="GRID"?"active":"") %>" onclick="setType('GRID');"></button>
                            <button type="button" id="list-view" class="btn btn-default list-view <%=(ListViewtype=="GRID"?"":"active") %>"  onclick="setType('LIST');"></button>
                        </div>
                    </div>
                    <div class="page-wrapper pull-right">
                        <label class="control-label" for="input-limit">Show :</label>
                        <div class="limit">
                            <%--<select id="input-limit" class="form-control">
                                <option value="8" selected="selected">08</option>
                                <option value="25">25</option>
                                <option value="50">50</option>
                                <option value="75">75</option>
                                <option value="100">100</option>
                            </select>--%>
                            <asp:DropDownList ID="ddlLimit" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLimit_SelectedIndexChanged">
                                <asp:ListItem Text="09" Value="9" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                <asp:ListItem Text="100" Value="100"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                    </div>
                    <div class="sort-wrapper pull-right">
                        <label class="control-label" for="input-sort">Sort By :</label>
                        <div class="sort-inner">
                            <%--<select id="input-sort" class="form-control">
                                <option value="ASC" selected="selected">Default</option>
                                <option value="ASC">Name (A - Z)</option>
                                <option value="DESC">Name (Z - A)</option>
                                <option value="ASC">Price (Low &gt; High)</option>
                                <option value="DESC">Price (High &gt; Low)</option>
                                <option value="DESC">Rating (Highest)</option>
                                <option value="ASC">Rating (Lowest)</option>
                                <option value="ASC">Model (A - Z)</option>
                                <option value="DESC">Model (Z - A)</option>
                            </select>--%>
                            <asp:DropDownList ID="ddlSort" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                                <asp:ListItem Text="Default" Value="0_ASC" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Name (A - Z)" Value="1_ASC"></asp:ListItem>
                                <asp:ListItem Text="Name (Z - A)" Value="2_DESC"></asp:ListItem>
                                <asp:ListItem Text="Price (Low &gt; High)" Value="3_ASC"></asp:ListItem>
                                <asp:ListItem Text="Price (High &gt; Low)" Value="4_DESC"></asp:ListItem>
                                <asp:ListItem Text="Rating (Highest)" Value="5_DESC"></asp:ListItem>
                                <asp:ListItem Text="Rating (Lowest)" Value="6_ASC"></asp:ListItem>
                                <asp:ListItem Text="Model (A - Z)" Value="7_ASC"></asp:ListItem>
                                <asp:ListItem Text="Model (Z - A)" Value="8_DESC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <span><i class="fa fa-angle-down" aria-hidden="true"></i></span>
                    </div>
                </div>
                <div class="row">
                    <asp:Repeater ID="RptProducts" runat="server" OnItemCommand="RptProducts_ItemCommand">
                        <ItemTemplate>
                            <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                            <div class="product-layout  product-grid  col-md-4 col-sm-6 col-xs-12 ">
                                <div class="item">
                                    <div class="product-thumb clearfix mb_30">
                                        <div class="image product-imageblock" style="min-height:277px;">
                                            <a href="../ProductDetail/<%#Eval("SEOName")%>">
                                                <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" />
                                                <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL2")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" />
                                            </a>
                                            <div class="button-group text-center">
                                                <div class="wishlist">
                                                    <%--<a href="../WishList"><span>wishlist</span></a>--%>
                                                     <asp:LinkButton ID="LinkButton2" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                </div>
                                                <div class="quickview">
                                                    <a href='../ProductDetail/<%#Eval("SEOName")%>'><span>Quick View</span>
                                                        <img data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />
                                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" class="img-responsive" style="visibility: hidden;" />
                                                    </a>

                                                </div>
                                                <%--<div class="compare"><a href="#"><span>Compare</span></a></div>--%>
                                                <div class="add-to-cart">
                                                   <%-- <a href="../cartpage"><span>Add to cart</span></a>--%>                                                    
                                                     <asp:LinkButton ID="LinkButton1" runat="server" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fa "></i></asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="caption product-detail text-center">
                                            <h6 data-name="product_name" class="product-name mt_20"><a href="../ProductDetail/<%#Eval("SEOName")%>" title="Casual Shirt With Ruffle Hem"><%#Eval("sName")%></a></h6>
                                            <div class="rating"><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span></div>
                                            <span class="price">
                                                <span class="amount">
                                                    <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                                    <%#Eval("PurchasePrice")%>
                                                </span>
                                              <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                                <span style="text-decoration: line-through; font-size: small;">
                                                      <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                                    <%#Eval("ProductPrice")%>
                                                </span><br />
                                                <span style="font-size: small;">You Save: <%#Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))%> (<%#Eval("Discount")%>%)</span>
                                                <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                                            </span>
                                            <p class="product-desc mt_20 mb_60"><%#Eval("Features")%></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div class="pagination-nav text-center mt_50">
                    <ul>
                        <%--<li><a href="#"><i class="fa fa-angle-left"></i></a></li>
                        <li class="active"><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#"><i class="fa fa-angle-right"></i></a></li>--%>
                        <%--<asp:HiddenField ID="hdnPageNum" runat="server" Value="1" />--%>
                        <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                            <HeaderTemplate>
                                <li>
                                    <asp:LinkButton ID='lnkFirst' CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="fa fa-angle-left"></i>
                                    </asp:LinkButton>
                                </li>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class='<%# ((ListItem)Container.DataItem).Value.Equals(hdPageNo.Value) ? "active" : string.Empty %>'>
                                    <asp:LinkButton ID='lnkPage'
                                        CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                    </asp:LinkButton>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                <li>
                                    <asp:LinkButton ID='lnkLast' CommandName="Page" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="fa fa-angle-right"></i>
                                    </asp:LinkButton>
                                </li>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>

              </div>
        </div>
        <uc1:UCbrandcarouse runat="server" ID="UCbrandcarouse" />
<script>
    function SetType(typ) {
        $('#hdnviewType').val(typ);
    }
</script>

    </div>

</asp:Content>
