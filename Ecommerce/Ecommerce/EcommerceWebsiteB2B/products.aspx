<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="products.aspx.cs" Inherits="EcommerceWebsiteB2B.products" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Import Namespace="System.Collections" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .clear-filter {
            margin-bottom: 12px;
            margin-top: 6px;
            text-align: right;
            display: none;
        }

        .search-text {
            display: none;
        }

            .search-text .label {
                font-size: 15px;
                color: #fd405e;
                padding-left: 0;
            }

        .sidebar-single {
            margin-bottom: 35px;
        }

            .sidebar-single .sidebar-title {
                font-weight: bold;
                font-size: 20px;
                border-bottom: 1px solid #eee;
                padding-bottom: 15px;
            }

        .sidebar-checkbox input[type="checkbox"] {
            margin-right: 3px;
        }

        .sidebar-single .sidebar-body ul {
            list-style: none;
            padding-left: 0;
        }

        .sidebar-body .sidebar-checkbox label {
            font-weight: initial;
        }

        .productIntro span.price del {
            color: #777;
            margin-right: 5px;
        }

        .productIntro span.price {
            float: right;
            font-size: 14px;
            color: #fd405e;
        }

        .product2 .thumbnail .productIntro .heading {
            height: 35px;
            line-height: 15px;
        }

        .productIntro .proCat {
            margin-top: 20px !important;
        }

        .top-filter .form-control {
            display: inline-block;
            width: inherit;
        }

        @media only screen and (max-width: 479.98px) {
            .top-filter .form-control {
                display: block;
                margin-right: 10px;
            }

            .top-filter label.Sortlblwidth {
                margin-right: 10px;
            }
        }

        .top-filter {
            text-align: right;
            margin-right: 16px;
            margin-bottom: 13px;
        }

            .top-filter .product-short {
                display: inline-block;
            }

        .price-range-wrap {
            margin-top: 18px;
        }

            .price-range-wrap .price-range {
                margin-top: 13px;
            }

            .price-range-wrap .btn-filter {
                margin-top: 18px;
            }

                .price-range-wrap .btn-filter a {
                    padding: 0 10px;
                }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>product page</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">product page</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">product page</li>
                </ul>
            </div>
        </div>
    </section>

    <section class="row contentRowPad greybg">
        <div class="container">
            <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
            <asp:HiddenField ID="hdnSidebar" runat="server" Value="" />
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-3 col-md-4">
                        <div class="search-text">
                            <span class="label">You search: </span>
                            <asp:Label ID="lblSearchText" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="clear-filter">
                            <asp:LinkButton ID="btnClearFilter" runat="server" OnClientClick="ClearFilter();" OnClick="btnClearFilter_Click"><i class="fa fa-times-circle"></i> Clear Filter</asp:LinkButton>
                        </div>
                        <asp:Panel ID="pnlSidebar" runat="server">
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Main</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptMain" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID='chk' runat="server" CssClass="sidebar-checkbox" AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Categories</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptCategory" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID='chk' runat="server" CssClass="sidebar-checkbox" AutoPostBack="true" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible prc">Price</h5>
                                <div class="sidebar-body content">
                                    <asp:HiddenField ID="hdnMinPrice" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnMaxPrice" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnLowerPrice" runat="server" Value="" />
                                    <asp:HiddenField ID="hdnHigherPrice" runat="server" Value="" />
                                    <div class="price-range-wrap">
                                        <div id="slider-range" style="margin-right: 7px; margin-left: 8px;"></div>
                                        <div class="price-range fleft">
                                            <label for="amount">Price:</label>
                                            <input type="text" class="price-range" id="amount" readonly="readonly" style="border: 0; color: #f6931f; font-weight: bold; width: 153px;" />
                                        </div>
                                        <div class="btn-filter">
                                            <asp:LinkButton ID="btnFilter" runat="server" CssClass="btn btn-primary btn-sm filled" OnClick="btnFilter_Click">Filter</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Collection</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptCollection" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Material</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptMaterial" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Gemstone</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptGemstone" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Color</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptColors" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Shape</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptShape" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Size</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptSize" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                            <div class="sidebar-single">
                                <h5 class="sidebar-title collapsible">Gender</h5>
                                <div class="sidebar-body content">
                                    <ul>
                                        <asp:Repeater ID="rptGender" runat="server">
                                            <ItemTemplate>
                                                <li>
                                                    <asp:CheckBox ID="chk" runat="server" AutoPostBack="true" CssClass="sidebar-checkbox" OnCheckedChanged="chk_CheckedChanged" Text='<%# Eval("sName")%>' />
                                                    <asp:HiddenField ID="hdChk" ClientIDMode="Static" runat="server" Value='<%#Eval("ID")%>' />
                                                    <asp:HiddenField ID="hdName" ClientIDMode="Static" runat="server" Value='<%#Eval("sName")%>' />
                                                </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                    <div class="col-lg-9 col-md-8">
                        <div class="row">
                            <asp:Panel ID="pnlEmpty" runat="server">
                                <div class="panel-collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-sm-6 mx-auto">
                                                <br />
                                                <h3>Sorry, no results Found.</h3>
                                                <p>Please check the spelling or try searching for something else.</p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlProducts" runat="server">
                                <div class="top-filter">
                                    <div class="product-short" style="margin-right: 15px;">
                                        <label class="Limitlblwidth" for="input-limit">Show :</label>
                                        <asp:DropDownList ID="ddlLimit" runat="server" CssClass="LimitWidth form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlLimit_SelectedIndexChanged">
                                            <asp:ListItem Text="09" Value="9" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                            <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                            <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="product-short">
                                        <label class="Sortlblwidth" for="input-sortby">Sort By : </label>
                                        <asp:DropDownList ID="ddlSort" runat="server" CssClass="SortWidth nice-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSort_SelectedIndexChanged">
                                            <asp:ListItem Text="Default" Value="0_ASC" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Name (A - Z)" Value="1_ASC"></asp:ListItem>
                                            <asp:ListItem Text="Name (Z - A)" Value="2_DESC"></asp:ListItem>
                                            <asp:ListItem Text="Price (Low &gt; High)" Value="3_ASC"></asp:ListItem>
                                            <asp:ListItem Text="Price (High &gt; Low)" Value="4_DESC"></asp:ListItem>
                                            <asp:ListItem Text="Newest" Value="5_DESC"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <asp:Repeater ID="RptProducts" runat="server" OnItemCommand="RptProducts_ItemCommand">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                                        <div class="col-sm-4 product2">
                                            <div class="row m0 thumbnail">
                                                <div class="row m0 imgHov">
                                                    <img height="200" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("SEOName")%>" title="<%#Eval("sName")%>" />
                                                    <div class="hovArea row m0">
                                                        <div class="links row m0">
                                                            <a href="<%= this.Master.baseUrl %>productdetail/<%#Eval("SEOName")%>" title="View"><i class="fas fa-link"></i></a>
                                                            <asp:LinkButton ID="lnkWishlist" runat="server" CommandName="WishAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="<%# !string.IsNullOrEmpty(Convert.ToString(Eval("idWishList"))) && idWishlists.Exists(x=>x.ToString() == Convert.ToString(Eval("idWishList")))  ? "fas fa-heart" : "far fa-heart" %>"></i></asp:LinkButton>
                                                        </div>
                                                        <div class="row m0 getlike">
                                                            <asp:LinkButton ID="btnAddToCart" runat="server" class="fleft" CommandName="CrtAdd" CommandArgument='<%#Eval("idProduct") %>'><i class="fas fa-shopping-cart"></i>Add to cart</asp:LinkButton>
                                                            <a href="#" class="fright"><i class="fas fa-sliders"></i></a>
                                                            <a href="#" class="fright"><i class="fas fa-heart-o"></i></a>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row m0 productIntro">
                                                    <h5 class="heading">
                                                        <a href="<%= this.Master.baseUrl %>productdetail/<%#Eval("SEOName")%>" title='<%#Eval("sName")%>'><%# Convert.ToString(Eval("sName")).Length > 45 ? Convert.ToString(Eval("sName")).Substring(0,45) + "..." : Convert.ToString(Eval("sName")) %></a></h5>
                                                    <span class="price"><del><%=this.Master.CurrencySymbol %>
                                                        <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %></del> <%=this.Master.CurrencySymbol %>
                                                        <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></span>
                                                    <h5 class="proCat"><%# Eval("MaterialName") %></h5>
                                                    <div class="row stars m0">
                                                        <i class='<%# Convert.ToInt16(Eval("starRating")) >= 1 ? "fas fa-star stared" : "fas fa-star" %>'></i>
                                                        <i class='<%# Convert.ToInt16(Eval("starRating")) >= 2 ? "fas fa-star stared" : "fas fa-star" %>'></i>
                                                        <i class='<%# Convert.ToInt16(Eval("starRating")) >= 3 ? "fas fa-star stared" : "fas fa-star" %>'></i>
                                                        <i class='<%# Convert.ToInt16(Eval("starRating")) >= 4 ? "fas fa-star stared" : "fas fa-star" %>'></i>
                                                        <i class='<%# Convert.ToInt16(Eval("starRating")) >= 5 ? "fas fa-star stared" : "fas fa-star" %>'></i>
                                                        <span class="vote">(<%# Eval("nReview") %>)</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <!-- start pagination area -->
                                <div class="pagination">
                                    <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID='lnkFirst' class="previous" CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="fa fa-angle-double-left"></i>
                                            </asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:LinkButton ID='lnkPage' CssClass='<%# ((ListItem)Container.DataItem).Value.Equals(hdPageNo.Value) ? "active" : string.Empty %>'
                                                CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID='lnkLast' CommandName="Page" class="next" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="fa fa-angle-double-right"></i>
                                            </asp:LinkButton>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- end pagination area -->
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script>
        $(document).ready(function () {
            SetPriceRange("<%= this.Master.CurrencySymbol %>", $("#<%= hdnLowerPrice.ClientID %>").val(), $("#<%= hdnHigherPrice.ClientID %>").val());
            var url = window.location.href;
            if (url.indexOf('search=') !== -1) {
                if (url.substring(url.indexOf("=") + 1, url.length).length > 0) {
                    $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'block');
                    $(".search-text").css('display', 'block');
                }
            }
            else if ($("#<%= pnlEmpty.ClientID %>").is(":visible")) {
                $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'block');
            }
        });
    function SetPriceRange(currency, minP, maxP) {
        if (minP != $("#<%= hdnMinPrice.ClientID %>").val() || maxP != $("#<%= hdnMaxPrice.ClientID %>").val())
                $(".sidebar-single .sidebar-title.collapsible.prc").css('color', '#fd405e');
            if (minP != $("#<%= hdnMinPrice.ClientID %>").val() || maxP != $("#<%= hdnMaxPrice.ClientID %>").val() || $('input:checkbox:checked').length > 0)
                $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'block');
        else
            $("#<%= btnClearFilter.ClientID %>").parent().css('display', 'none');
        var rangeSlider = $("#slider-range"),
        amount = $("#amount");
        rangeSlider.slider({
            range: true,
            min: parseInt(minP),
            max: parseInt(maxP),
            values: [parseInt($("#<%= hdnMinPrice.ClientID %>").val()), parseInt($("#<%= hdnMaxPrice.ClientID %>").val())],
                slide: function (event, ui) {
                    amount.val(currency + ui.values[0] + " - " + currency + ui.values[1]);
                },
                stop: function (event, ui) {
                    $("#<%= hdnMinPrice.ClientID %>").val(ui.values[0]);
                    $("#<%= hdnMaxPrice.ClientID %>").val(ui.values[1]);
                }
            });

            amount.val(" " + currency + rangeSlider.slider("values", 0) +
                " - " + currency + rangeSlider.slider("values", 1)
            );

        }
    </script>
    <script>
        var coll = document.getElementsByClassName("collapsible");
        var i;
        for (i = 0; i < coll.length; i++) {
            if (coll[i].innerHTML == $("#<%= hdnSidebar.ClientID %>").val()) {
                $(coll[i]).css('color', '#fd405e')
                coll[i].classList.toggle("active");
                var content = coll[i].nextElementSibling;
                if (content.style.maxHeight) {
                    content.style.maxHeight = null;
                } else {
                    content.style.maxHeight = content.scrollHeight + "px";
                }
            }
            coll[i].addEventListener("click", function () {
                this.classList.toggle("active");
                var content = this.nextElementSibling;
                if (content.style.maxHeight) {
                    content.style.maxHeight = null;
                } else {
                    content.style.maxHeight = content.scrollHeight + "px";
                }
            });
        }
        for (i = 0; i < $('input[type=checkbox]').length; i++) {
            var checkbox = $('input[type=checkbox]');
            if (checkbox[i].checked) {
                $(checkbox[i]).parents('.sidebar-single').children('.sidebar-title.collapsible').css('color', '#fd405e');
            }
        }
    </script>
    <style>
        .collapsible {
            cursor: pointer;
        }

            .collapsible:after {
                content: '\002B';
                color: #fd405e;
                font-weight: bold;
                float: right;
                margin-left: 5px;
            }

            .collapsible.active:after {
                content: "\2212";
            }

        .content {
            max-height: 0;
            overflow: hidden;
            transition: max-height 0.2s ease-out;
        }
    </style>
</asp:Content>
