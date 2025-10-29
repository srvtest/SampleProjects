<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="EcommerceWebsite.Blog" %>

<%--<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>--%>
<%@ Register Src="~/UCblogcategory.ascx" TagPrefix="uc1" TagName="UCblogcategory" %>
<%@ Register Src="~/UCLatestPost.ascx" TagPrefix="uc1" TagName="UCLatestPost" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1><asp:Label ID="lblBlogName1" runat="server"></asp:Label></h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li><a href="../blogpage">blog</a></li>
                        <li class="active"><asp:Label ID="lblBlogName" runat="server"></asp:Label></li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <div id="column-left" class="col-sm-4 col-lg-3 hidden-xs">
                <%--<uc1:UCTopCategory runat="server" ID="UCTopCategory" />--%>
                <%--<div class="left_banner left-sidebar-widget mt_30 mb_40">
                    <a href="#">
                        <img src="images/left1.jpg" alt="Left Banner" class="img-responsive" /></a>
                </div>--%>
                <uc1:UCblogcategory runat="server" ID="UCblogcategory" />
                <uc1:UCLatestPost runat="server" ID="UCLatestPost" />
            </div>
            <div class="col-sm-8 col-lg-9 mtb_20">
                <asp:Repeater ID="rptBlogs" runat="server">
                    <ItemTemplate>
                        <div class="row">
                            <div class="blog-item listing-effect col-md-12 mb_50">
                                <div class="post-format">
                                    <div class="thumb post-img">
                                         <a href="../Blog/<%#Eval("Name")%>" title='<%#Eval("MetaTags")%>'>
                                                <img data-name="Blog" src="<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/Blog/<%#Eval("sPhoto")%>" alt="<%#Eval("MetaTags")%>" title="<%#Eval("Name")%>" class="img-responsive" />
                                             <%--   <img src="<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/Blog/<%#Eval("sPhoto")%>" alt="<%#Eval("MetaTags")%>" title="<%#Eval("Name")%>" class="img-responsive" />--%>
                                            </a>
                                     <%--   <a href="#" title='<%#Eval("MetaTags")%>'>
                                            <img src='../images/blog/<%#Eval("sPhoto")%>' alt='Blog'></a>--%>
                                    </div>
                                    <%--<div class="post-type"><i class="fa fa-picture-o" aria-hidden="true"></i></div>--%>
                                </div>
                                <div class="post-info mtb_20 ">
                                    <h2 class="mb_10"><a href='<%#Eval("URL")%>'><%#Eval("Name")%></a> </h2>
                                    <p><%#Eval("sDescription")%></p>
                                </div>
                                <div class="details mtb_20">
                                    <div class="date"><i class="fa fa-calendar" aria-hidden="true"></i><%#Eval("CreatedDate")%></div>
                                </div>
                               <%-- <div class="author-about mt_50">
                                    <h3 class="author-about-title">About the Author</h3>
                                    <div class="author mtb_30">
                                        <div class="author-avatar">
                                            <img alt="" src="/images/user1.jpg">
                                        </div>
                                        <div class="author-body">
                                            <h5 class="author-name"><a href="#">Radley Lobortis</a></h5>
                                            <div class="author-content mt_10">Vivamus imperdiet ex sed lobortis luctus. Aenean posuere nulla in turluctus. Aenean posuere nulla in tur pis porttitor laoreet. Quisque finibus aliquet purus. Ut et mi eu ante interdum .</div>
                                        </div>
                                    </div>
                                </div>--%>
                                <%--<div id="comments" class="comments-area mt_50">
                                    <h3 class="comment-title">3 comments</h3>
                                    <ul class="comment-list mt_30">
                                        <li class="comment">
                                            <hr>
                                            <article class="comment-body mtb_20">
                                                <div class="comment-avatar">
                                                    <img alt="" src="/images/user2.jpg">
                                                </div>
                                                <div class="comment-main">
                                                    <h5 class="author-name"><a href="#" class="comment-name">Radley Lobortis</a> <small class="comment-date">8 months ago</small> </h5>
                                                    <div class="comment-reply pull-right"><a href="#"><i class="fa fa-reply" aria-hidden="true"></i>Reply</a> </div>
                                                    <div class="comment-content mt_10">Sed lobortis rpi luctus. Aenean posuere nulla in turluctus. Aenean posuere nulla in turs porttitor larpis porttitor larpis porttitor lauctus. Aenean posuere nulla in turpis porttitor laoreet.</div>
                                                </div>
                                            </article>
                                            <hr>
                                            <ol class="children">
                                                <li class="comment">
                                                    <article class="comment-body mtb_20">
                                                        <div class="comment-avatar">
                                                            <img alt="" src="/images/user3.jpg">
                                                        </div>
                                                        <div class="comment-main">
                                                            <h5 class="author-name"><a href="#" class="comment-name">Lobortis Radley</a> <small class="comment-date">1 months ago</small> </h5>
                                                            <div class="comment-reply pull-right"><a href="#"><i class="fa fa-reply" aria-hidden="true"></i>Reply</a> </div>
                                                            <div class="comment-content mt_10">Dcenas euismod faucibus dolor a finibus.Maecenas euismod faucibus dolor a finibus.Maecenas euismod faucibus dolor a finibus.Maecenas euismod faucibus.</div>
                                                        </div>
                                                    </article>
                                                </li>
                                            </ol>
                                        </li>
                                        <li class="comment">
                                            <hr>
                                            <article class="comment-body mtb_20">
                                                <div class="comment-avatar">
                                                    <img alt="" src="/images/user1.jpg">
                                                </div>
                                                <div class="comment-main">
                                                    <h5 class="author-name"><a href="#" class="comment-name">Sradle Vivamus </a><small class="comment-date">8 days ago</small> </h5>
                                                    <div class="comment-reply pull-right"><a href="#"><i class="fa fa-reply" aria-hidden="true"></i>Reply</a> </div>
                                                    <div class="comment-content mt_10">Vivamus imperdiet ex sed lobortis luctus. Aenean posuere nulla in turpis porttitor laoreet. Quisque finibus aliquet purus. Ut et mi eu ante interdum dignissim pellentesque a mi.</div>
                                                </div>
                                            </article>
                                        </li>
                                    </ul>
                                    <div class="leave-form">
                                        <h3 class="comment-title mt_50 mb_30" id="reply-title">Leave A Comment</h3>
                                        <!-- Comment Form -->
                                        <div class="form-style" id="contact_form">
                                            <div id="contact_results"></div>
                                            <div class="row">
                                                <form id="contact_body" method="post">
                                                    <div class="col-sm-6">
                                                        <input class="full-with-form" type="text" name="name" placeholder="Name" data-required="true" />
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <input class="full-with-form" type="email" name="email" placeholder="Email Address" data-required="true" />
                                                    </div>
                                                    <div class="col-sm-12 mt_30">
                                                        <textarea class="full-with-form" name="message" placeholder="Message" data-required="true"></textarea>
                                                    </div>
                                                    <div class="col-sm-6">
                                                        <button class="btn mt_30" type="submit">Leave Comment</button>
                                                    </div>
                                                </form>
                                            </div>
                                        </div>
                                        <!-- End Comment Form -->
                                    </div>
                                </div>--%>

                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <h3 style="text-align:center"><asp:Label ID="lblNotFound" runat="server" Text="Blog not found!!!" Visible="false"></asp:Label></h3>
            </div>
        </div>
    </div>

</asp:Content>
