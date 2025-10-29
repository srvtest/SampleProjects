<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="blog.aspx.cs" Inherits="EcommerceWebsiteB2B.blog" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<%--<%@ Register Src="~/UCLatestPost.ascx" TagPrefix="uc1" TagName="UCLatestPost" %>
<%@ Register Src="~/UCBlogArchives.ascx" TagPrefix="uc1" TagName="UCBlogArchives" %>--%>
<%@ Register Src="~/UCBlogsArchives.ascx" TagPrefix="uc1" TagName="UCBlogsArchives" %>
<%@ Register Src="~/UCLatestPosts.ascx" TagPrefix="uc1" TagName="UCLatestPosts" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>single blog</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">single post</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li><a href="<%= this.Master.baseUrl %>blogdetails">Blog</a></li>
                    <li class="active"><asp:Label ID="lblBlogName" runat="server"></asp:Label></li>
                </ul>
            </div>
        </div>
    </section>

    <section class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-sm-8 col-md-8">
                    <div class="blog row m0 single_post">
                        <asp:Repeater ID="rptBlogs" runat="server">
                            <ItemTemplate>
                                <div class="row m0 titleRow">
                                    <div class="fleft date">
                                        <%#Eval("CreatedDate", "{0:dd  MMM}")%>
                                    </div>
                                    <div class="fleft titlePart">
                                        <a href="single-post.html">
                                            <h4 class="blogTitle heading">
                                                <a href='<%= this.Master.baseUrl %>blog/<%#Eval("Name")%>'><%#Eval("Name")%></a>
                                            </h4>
                                        </a>
                                        <p class="m0">By <a href="#">Admin</a><span>|</span><a href="#">5 Comments</a></p>
                                    </div>
                                </div>
                                <div class="row m0 featureImg">
                                    <a href="<%= this.Master.baseUrl %>blog/<%#Eval("Name")%>" title='<%#Eval("MetaTags")%>'>
                                            <img src="<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>" alt="<%#Eval("MetaTags")%>" title="<%#Eval("Name")%>" />
                                        </a>
                                </div>
                                <div class="row m0 excerpt">
                                    <%#Eval("sDescription")%>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <h3 style="text-align: center">
                            <asp:Label ID="lblNotFound" runat="server" Text="Blog not found!!!" Visible="false"></asp:Label></h3>
                    </div>
                    <!--Blog Row End-->
                    <div class="shareRow row m0">
                        <h4 class="heading fleft">Share this post</h4>
                        <ul class="list-inline">
                            <li><a href="#"><i class="fab fa-facebook-f"></i></a></li>
                            <li><a href="#"><i class="fab fa-twitter"></i></a></li>
                            <li><a href="#"><i class="fab fa-linkedin"></i></a></li>
                            <li><a href="#"><i class="fab fa-tumblr"></i></a></li>
                        </ul>
                    </div>
                    <!--Share Widget-->

                    <div class="media authorBox">
                        <div class="media-left authorImg">
                            <a href="#">
                                <img src="<%= this.Master.baseUrl %>images/blog/author.png" alt="" />
                            </a>
                        </div>
                        <div class="media-body">
                            <h5 class="heading">About <a href="#">Dwayne Johnson</a></h5>
                            <p>We provide the best Quality of products to you.We are always here to help our lovely customers. We ship our products anywhere with more secure. We provide the best Quality of products to you.</p>
                        </div>
                        <div class="row m0">
                            <ul class="list-inline">
                                <li><a href="#"><i class="fab fa-facebook-f"></i>Facebook</a></li>
                                <li><a href="#"><i class="fab fa-twitter"></i>twitter</a></li>
                                <li><a href="#"><i class="fab fa-google-plus"></i>google+</a></li>
                                <li><a href="#"><i class="fas fa-envelope"></i>Email</a></li>
                            </ul>
                        </div>
                    </div>
                    <!--Author Box - Shortcode Item -> Single Blog Page-->

                    <div class="row m0 comments">
                        <h4 class="heading commentCount">3 Comments</h4>

                        <div class="media commentBox">
                            <div class="media-left">
                                <a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/blog/comenter1.png" alt=""/>
                                </a>
                            </div>
                            <div class="media-body">
                                <h5 class="heading">Dwayne</h5>
                                <h6>Dec 15, 2018   <span>|</span>   <a href="#replyForm">Reply</a></h6>
                                <p>Beats all you've ever saw been in trouble with the law since the day they was born. Fleeing from the Cylon tyranny the last Battlestar – Galactica - leads a rag-tag fugitive fleet on a lonely Beats all you've ever saw been in trouble with the law.</p>
                            </div>
                        </div>
                        <!--Comment Box - Shortcode Item -> Single Blog Page-->

                        <div class="media commentBox innerComment">
                            <div class="media-left">
                                <a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/blog/comenter2.png" alt=""/>
                                </a>
                            </div>
                            <div class="media-body">
                                <h5 class="heading">johnson</h5>
                                <h6>Dec 15, 2018   <span>|</span>   <a href="#replyForm">Reply</a></h6>
                                <p>Beats all you've ever saw been in trouble with the law since the day they was born. Fleeing from the Cylon tyranny the last Battlestar – Galactica - leads a rag-tag fugitive fleet on a lonely Beats all you've ever saw been in trouble with the law.</p>
                            </div>
                        </div>
                        <!--Comment Box - Shortcode Item -> Single Blog Page-->
                        <div class="media commentBox">
                            <div class="media-left">
                                <a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/blog/comenter3.png" alt=""/>
                                </a>
                            </div>
                            <div class="media-body">
                                <h5 class="heading">lisa</h5>
                                <h6>Dec 14, 2018   <span>|</span>   <a href="#replyForm">Reply</a></h6>
                                <p>Beats all you've ever saw been in trouble with the law since the day they was born. Fleeing from the Cylon tyranny the last Battlestar – Galactica - leads a rag-tag fugitive fleet on a lonely Beats all you've ever saw been in trouble with the law.</p>
                            </div>
                        </div>
                        <!--Comment Box - Shortcode Item -> Single Blog Page-->
                    </div>
                    <!--Comments here-->

                    <div class="row m0" id="replyForm">
                        <h4 class="heading">leave a comment</h4>
                        <form action="#" method="post" role="form">
                            <div class="row">
                                <div class="col-sm-4">
                                    <label for="commenterName">Name *</label>
                                    <input type="text" class="form-control" name="commenterName" id="commenterName">
                                </div>
                                <div class="col-sm-4">
                                    <label for="commenterEmail">Email *</label>
                                    <input type="email" class="form-control" name="commenterEmail" id="commenterEmail">
                                </div>
                                <div class="col-sm-4">
                                    <label for="commenterUrl">Website</label>
                                    <input type="url" class="form-control" name="commenterUrl" id="commenterUrl">
                                </div>
                            </div>
                            <div class="row m0">
                                <label for="comments">Comment</label>
                                <textarea name="comments" id="comments" class="form-control"></textarea>
                            </div>
                            <button class="btn btn-primary btn-default filled" type="submit">post comment</button>
                        </form>
                    </div>

                </div>
                <div class="col-sm-4 col-md-4">
                    <div class="row m0 sidebar">
                        <form action="#" class="searchForm row m0">
                            <div class="input-group">
                                <input type="search" class="form-control" placeholder="Search">
                                <span class="input-group-addon p0">
                                    <button type="submit"><i class="fas fa-search"></i></button>
                                </span>
                            </div>
                        </form>
                        <!--Shortcode Element-->
                        <div class="row m0 categories">
                            <h4 class="heading">categories</h4>
                            <ul class="list-unstyled">
                                <li>Architecture</li>
                                <li>Beauty</li>
                                <li>Cars</li>
                                <li>Entertainment</li>
                                <li>People</li>
                                <li>Templates</li>
                                <li>Tour</li>
                            </ul>
                        </div>
                        <!--Shortcode Element-->
                       <%-- <uc1:UCLatestPost runat="server" ID="UCLatestPost" />
                        <uc1:UCBlogArchives runat="server" ID="UCBlogArchives" />--%>
                        <uc1:UCBlogsArchives runat="server" ID="UCBlogsArchives" />
                        <uc1:UCLatestPosts runat="server" ID="UCLatestPosts" />
                        <!--Shortcode Element-->

                        <div class="row m0 tags">
                            <h4 class="heading">tags</h4>
                            <ul class="nav tagsNav">
                                <li><a href="#">Art</a></li>
                                <li><a href="#">Beauty</a></li>
                                <li><a href="#">Business</a></li>
                                <li><a href="#">Gallery</a></li>
                                <li><a href="#">Games</a></li>
                                <li><a href="#">Images</a></li>
                                <li><a href="#">People</a></li>
                                <li><a href="#">Travelling</a></li>
                            </ul>
                        </div>
                        <!--Shortcode Element-->

                        <div class="row m0 flickrPhoto">
                            <h4 class="heading">flickr photostream</h4>
                            <ul class="list-inline">
                                <li><a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/flickr/1.png" alt=""/></a></li>
                                <li><a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/flickr/2.png" alt=""/></a></li>
                                <li><a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/flickr/3.png" alt=""/></a></li>
                                <li><a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/flickr/4.png" alt=""/></a></li>
                                <li><a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/flickr/5.png" alt=""/></a></li>
                                <li><a href="#">
                                    <img src="<%= this.Master.baseUrl %>images/flickr/6.png" alt=""/></a></li>
                            </ul>
                        </div>
                        <!--Shortcode Element-->
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
