<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="blog.aspx.cs" Inherits="EcommerceWebsite2.blog" %>


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
                                <li class="breadcrumb-item"><a href="../blogdetails">blog</a></li>
                                <li class="breadcrumb-item active"><asp:Label ID="lblBlogName" runat="server"></asp:Label></li>
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
                                <input type="text" class="search-field" placeholder="search here" />
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
                    <div class="blog-item-wrapper">
                        <asp:Repeater ID="rptBlogs" runat="server">
                            <ItemTemplate>
                                <!-- blog post item start -->
                                <div class="blog-post-item blog-details-post">
                                    <figure class="blog-thumb">
                                        <%--<img src="assets/img/blog/blog-img3.jpg" alt="blog image">--%>
                                        <a href="../blog/<%#Eval("Name")%>" title='<%#Eval("MetaTags")%>'>
                                            <img src="<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>" alt="<%#Eval("MetaTags")%>" title="<%#Eval("Name")%>" />
                                        </a>
                                    </figure>
                                    <div class="blog-content">
                                        <%--<h3 class="blog-title">Celebrity Daughter Opens Up About Having Her Eye Color Changed</h3>--%>
                                        <h3 class="blog-title"><a href='<%#Eval("URL")%>'><%#Eval("Name")%></a></h3>
                                        <div class="blog-meta">
                                            <%-- <p>25/03/2019 | <a href="#">Corano</a></p>--%>
                                            <p><%#Eval("CreatedDate")%></p>
                                        </div>
                                        <div class="entry-summary">
                                            <%--<p>
                                                Lorem ipsum dolor sit amet consectetur adipisicing elit. Voluptate perferendis
                                            consequuntur illo aliquid nihil ad neque, debitis praesentium libero ullam
                                            asperiores exercitationem deserunt inventore facilis, officiis,
                                            </p>--%>
                                            <p><%#Eval("sDescription")%></p>
                                            <div class="tag-line">
                                                <h6>Tag :</h6>
                                                <a href="#">Necklaces</a>,
                                           
                                                <a href="#">Earrings</a>,
                                           
                                                <a href="#">Jewellery</a>,
                                       
                                            </div>
                                            <div class="blog-share-link">
                                                <h6>Share :</h6>
                                                <div class="blog-social-icon">
                                                    <a href="#" class="facebook"><i class="fa fa-facebook"></i></a>
                                                    <a href="#" class="twitter"><i class="fa fa-twitter"></i></a>
                                                    <a href="#" class="pinterest"><i class="fa fa-pinterest"></i></a>
                                                    <a href="#" class="google"><i class="fa fa-google-plus"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- blog post item end -->
                            </ItemTemplate>
                        </asp:Repeater>
                        <!-- comment area start -->
                        <%--<div class="comment-section section-padding">
                                        <h5>03 Comment</h5>
                                        <ul>
                                            <li>
                                                <div class="author-avatar">
                                                    <img src="assets/img/blog/comment-icon.png" alt="">
                                                </div>
                                                <div class="comment-body">
                                                    <span class="reply-btn"><a href="#">Reply</a></span>
                                                    <h5 class="comment-author">Admin</h5>
                                                    <div class="comment-post-date">
                                                        15 Dec, 2019 at 9:30pm
                                           
                                                    </div>
                                                    <p>
                                                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Enim maiores
                                                adipisci optio ex, laboriosam facilis non pariatur itaque illo sunt?
                                                    </p>
                                                </div>
                                            </li>
                                            <li class="comment-children">
                                                <div class="author-avatar">
                                                    <img src="assets/img/blog/comment-icon.png" alt="">
                                                </div>
                                                <div class="comment-body">
                                                    <span class="reply-btn"><a href="#">Reply</a></span>
                                                    <h5 class="comment-author">Admin</h5>
                                                    <div class="comment-post-date">
                                                        20 Nov, 2019 at 9:30pm
                                           
                                                    </div>
                                                    <p>
                                                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Enim maiores
                                                adipisci optio ex, laboriosam facilis non pariatur itaque illo sunt?
                                                    </p>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="author-avatar">
                                                    <img src="assets/img/blog/comment-icon.png" alt="">
                                                </div>
                                                <div class="comment-body">
                                                    <span class="reply-btn"><a href="#">Reply</a></span>
                                                    <h5 class="comment-author">Admin</h5>
                                                    <div class="comment-post-date">
                                                        25 Jan, 2019 at 9:30pm
                                           
                                                    </div>
                                                    <p>
                                                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Enim maiores
                                                adipisci optio ex, laboriosam facilis non pariatur itaque illo sunt?
                                                    </p>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>--%>
                        <!-- comment area end -->

                        <!-- start blog comment box -->
                        <%--<div class="blog-comment-wrapper">
                                        <h5>Leave a reply</h5>
                                        <p>Your email address will not be published. Required fields are marked *</p>
                                            <div class="comment-post-box">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <label>Comment</label>
                                                        <textarea name="commnet" placeholder="Write a comment"></textarea>
                                                    </div>
                                                    <div class="col-lg-4 col-md-4">
                                                        <label>Name</label>
                                                        <input type="text" class="coment-field" placeholder="Name">
                                                    </div>
                                                    <div class="col-lg-4 col-md-4">
                                                        <label>Email</label>
                                                        <input type="text" class="coment-field" placeholder="Email">
                                                    </div>
                                                    <div class="col-lg-4 col-md-4">
                                                        <label>Website</label>
                                                        <input type="text" class="coment-field" placeholder="Website">
                                                    </div>
                                                    <div class="col-12">
                                                        <div class="coment-btn">
                                                            <input class="btn btn-sqr" type="submit" name="submit" value="Post Comment">
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                    </div>--%>
                        <!-- start blog comment box -->
                        <h3 style="text-align: center">
                            <asp:Label ID="lblNotFound" runat="server" Text="Blog not found!!!" Visible="false"></asp:Label></h3>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- blog main wrapper end -->
</asp:Content>
