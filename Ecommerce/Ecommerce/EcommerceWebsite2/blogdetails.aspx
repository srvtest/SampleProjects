<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="blogdetails.aspx.cs" Inherits="EcommerceWebsite2.blogdetails" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Src="~/UCBlogCategory.ascx" TagPrefix="uc1" TagName="UCBlogCategory" %>
<%@ Register Src="~/UCBlogArchives.ascx" TagPrefix="uc1" TagName="UCBlogArchives" %>
<%@ Register Src="~/UCLatestPost.ascx" TagPrefix="uc1" TagName="UCLatestPost" %>
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
                                <li class="breadcrumb-item active" aria-current="page">blog list</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- blog main wrapper start -->
    <div class="blog-main-wrapper section-padding">
        <div class="container">
            <div class="row">
                <div class="col-lg-3 order-2 order-lg-1">
                    <aside class="blog-sidebar-wrapper">
                        <div class="blog-sidebar">
                            <h5 class="title">search</h5>
                            <div class="sidebar-serch-form">
                                    <input type="text" class="search-field" placeholder="search here">
                                    <button type="submit" class="search-btn"><i class="fa fa-search"></i></button>
                            </div>
                        </div>
                        <!-- single sidebar end -->
                         <uc1:UCBlogCategory ID="ucBlogCategory" runat="server" />
                        <!-- single sidebar end -->
                        <uc1:UCBlogArchives ID="ucBlogArchives" runat="server" />
                        <!-- single sidebar end -->
                        <uc1:UCLatestPost ID="ucLatestPost" runat="server" />
                        <!-- single sidebar end -->
                        <div class="blog-sidebar">
                            <h5 class="title">Tags</h5>
                            <ul class="blog-tags">
                                <li><a href="#">camera</a></li>
                                <li><a href="#">computer</a></li>
                                <li><a href="#">bag</a></li>
                                <li><a href="#">watch</a></li>
                                <li><a href="#">smartphone</a></li>
                                <li><a href="#">shoes</a></li>
                            </ul>
                        </div>
                        <!-- single sidebar end -->
                    </aside>
                </div>
                <div class="col-lg-9 order-1 order-lg-2">
                    <div class="blog-item-wrapper blog-list-inner">
                        <div class="shop-top-bar">
                            <div class="row align-items-center">
                                <div class="col-lg-5 col-md-6 order-2 order-md-1">
                                    <div class="top-bar-left">
                                        <div class="product-view-mode">
                                            <a class="active" href="#" data-target="grid-view" data-toggle="tooltip" title="Grid View"><i class="fa fa-th"></i></a>
                                            <a href="#" data-target="list-view" data-toggle="tooltip" title="List View"><i class="fa fa-list"></i></a>
                                            <asp:HiddenField ID="hdnviewType" runat="server" Value="GRID" ClientIDMode="Static" />
                                            <%-- <button type="button" id="grid-view" data-target="grid-view" data-toggle="tooltip" title="Grid View" class="btn btn-default grid-view fa fa-th <%=(ListViewtype=="GRID"?"active":"") %>" onclick="SetType('GRID');"></button>
                                                <button type="button" id="list-view" data-target="list-view" data-toggle="tooltip" title="List View" class="btn btn-default list-view fa fa-list <%=(ListViewtype=="GRID"?"":"active") %>" onclick="SetType('LIST');"></button>--%>
                                        </div>
                                        <%--  <div class="product-amount">
                                                <p>Showing 1–16 of 21 results</p>
                                            </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- blog item wrapper end -->
                        <div class="shop-product-wrap grid-view row mbn-30">

                            <asp:Repeater ID="rptList" runat="server">
                                <ItemTemplate>
                                    <div class="col-md-4 col-sm-6">
                                        <%--<div class="col-12">--%>
                                        <!-- blog post item start -->
                                        <div class="product-list-item mb-30">
                                            <figure class="blog-thumb">
                                                <%-- <a href="blog-details.html">
                                                    <img src="assets/img/blog/blog-img1.jpg" alt="blog image">
                                                </a>--%>
                                                <a href='blog/<%#Eval("Name")%>'>
                                                    <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>' alt="Blogs"></a>
                                            </figure>
                                            <div class="blog-content" style="margin-left:20px;">
                                                <h4 class="blog-title">
                                                    <%-- <a href="blog-details.html">Celebrity Daughter Opens Up About Having Her Eye Color Changed</a>--%>
                                                    <a href='blog/<%#Eval("Name")%>'><%#Eval("Name")%></a>
                                                </h4>
                                                <div class="blog-meta">
                                                    <%--<p>10/04/2019 | <a href="#">Corano</a></p>--%>
                                                    <p><%#Eval("CreatedDate")%></p>
                                                </div>
                                                <%--<p>Donec vitae hendrerit arcu, sit amet faucibus nisl. Cras pretium arcu ex. Aenean posuere libero eu augue condimentum rhoncus. Praesent ornare tortor ac ante egestas hendrerit. Aliquam et metus pharetra</p>--%>
                                                <p><%# Convert.ToString(Eval("sDescription")).Length > 120 ? Convert.ToString(Eval("sDescription")).Substring(0,120) : Convert.ToString(Eval("sDescription")) %></p>
                                                <%-- <a class="blog-read-more" href="blog-details.html">Read More...</a>--%>
                                                <a href='blog/<%#Eval("Name")%>'>Read More...</a>
                                            </div>
                                        </div>
                                        <!-- blog post item end -->
                                        <%-- </div>--%>

                                        <%--<div class="col-md-6">--%>
                                        <!-- blog post item start -->
                                        <div class="product-item mb-30">
                                            <figure class="blog-thumb">
                                                <%-- <a href="blog-details.html">
                                                <img src="assets/img/blog/blog-img1.jpg" alt="blog image">
                                            </a>--%>
                                                <a href='blog/<%#Eval("Name")%>'>
                                                    <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>' alt="Blogs"></a>
                                            </figure>
                                            <div class="blog-content">
                                                <div class="blog-meta">
                                                    <%--<p>10/04/2019 | <a href="#">Corano</a></p>--%>
                                                    <p><%#Eval("CreatedDate")%></p>
                                                </div>
                                                <h4 class="blog-title">
                                                    <%--<a href="blog-details.html">Celebrity Daughter Opens Up About Having Her Eye Color Changed</a>--%>
                                                    <a href='blog/<%#Eval("Name")%>'><%#Eval("Name")%></a>
                                                </h4>
                                            </div>
                                        </div>
                                        <!-- blog post item end -->
                                        <%--</div>--%>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>

                        <!-- blog item wrapper end -->

                        <!-- start pagination area -->
                        <div class="paginatoin-area text-center">
                            <%--<ul class="pagination-box">
                                    <li><a class="previous" href="#"><i class="pe-7s-angle-left"></i></a></li>
                                    <li class="active"><a href="#">1</a></li>
                                    <li><a href="#">2</a></li>
                                    <li><a href="#">3</a></li>
                                    <li><a class="next" href="#"><i class="pe-7s-angle-right"></i></a></li>
                                </ul>--%>
                            <ul class="pagination-box">
                                <asp:HiddenField ID="hdnPageNum" runat="server" Value="1" />
                                <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                                    <HeaderTemplate>
                                        <li>
                                            <asp:LinkButton ID='lnkFirst' class="previous" CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="pe-7s-angle-left"></i>
                                            </asp:LinkButton>
                                        </li>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li class='<%# ((ListItem)Container.DataItem).Value.Equals(hdnPageNum.Value) ? "active" : string.Empty %>'>
                                            <asp:LinkButton ID='lnkPage'
                                                CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                            </asp:LinkButton>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <li>
                                            <asp:LinkButton ID='lnkLast' class="next" CommandName="Page" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="pe-7s-angle-right"></i>
                                            </asp:LinkButton>
                                        </li>
                                    </FooterTemplate>
                                </asp:Repeater>

                            </ul>
                        </div>
                        <!-- end pagination area -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- blog main wrapper end -->
    <script>
        //$(document).ready(function () {
        //    $("#List").click(function () {
        //        $('#dGrid').hide();
        //        $('#dList').show();
        //    });
        //    $("#Grid").click(function () {
        //        $('#dGrid').show();
        //        $('#dList').hide();
        //    });
        //});
        //function listView() {
        //    $('#rptGrid').hide();
        //    $('#rptList').show();
        //}

        //// Grid View 
        //function gridView() {
        //    $('#rptGrid').show();
        //    $('#rptList').hide();
        //}
    </script>
</asp:Content>
