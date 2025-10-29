<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="blogdetails.aspx.cs" Inherits="EcommerceWebsiteB2B.blogdetails" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<%--<%@ Register Src="~/UCLatestPost.ascx" TagPrefix="uc1" TagName="UCLatestPost" %>
<%@ Register Src="~/UCBlogArchives.ascx" TagPrefix="uc1" TagName="UCBlogArchives" %>--%>
<%@ Register Src="~/UCBlogsArchives.ascx" TagPrefix="uc1" TagName="UCBlogsArchives" %>
<%@ Register Src="~/UCLatestPosts.ascx" TagPrefix="uc1" TagName="UCLatestPosts" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*Pagination css start*/
        .pagination {
            display: inline-block;
            float: right;
            margin-right: 12px;
        }

        .pagination a {
            color: black;
            float: left;
            padding: 8px 16px;
            text-decoration: none;
            transition: background-color .3s;
            border: 1px solid #ddd;
            margin: 0 4px;
        }

        .pagination a.active {
            background-color: #FD405E;
            color: white;
            border: 1px solid #FD405E;
        }

        .pagination a:hover:not(.active) {
            background-color: #ddd;
        }
        /*Pagination css end*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>blog</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">blog</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">blog</li>
                </ul>
            </div>
        </div>
    </section>
    <section class="row contentRowPad">
        <div class="container">
            <div class="row">
                <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
                <div class="col-sm-8 col-md-8">
                    <asp:Repeater ID="rptList" runat="server">
                        <ItemTemplate>
                            <div class="blog row m0">
                                <div class="row m0 titleRow">
                                    <div class="fleft date"><%#Eval("CreatedDate", "{0:dd  MMM}")%></div>
                                    <div class="fleft titlePart">
                                        <a href="single-post.html">
                                            <h4 class="blogTitle heading"><a href="<%= this.Master.baseUrl %>blog/<%#Eval("Name")%>"><%#Eval("Name")%></a></h4>
                                        </a>
                                        <p class="m0">By <a href="#">Admin</a><span>|</span><a href="#">5 Comments</a></p>
                                    </div>
                                </div>
                                <div class="row m0 featureImg">
                                    <a href='blog/<%#Eval("Name")%>'>
                                        <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%#Eval("sPhoto")%>' alt="Blogs"></a>
                                </div>
                                <div class="row m0 excerpt">
                                    <%# Convert.ToString(Eval("sDescription")).Length > 120 ? Convert.ToString(Eval("sDescription")).Substring(0,120) : Convert.ToString(Eval("sDescription")) %>
                                    <a href='blog/<%#Eval("Name")%>'>Read More...</a>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <!--Blog Row End-->
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
