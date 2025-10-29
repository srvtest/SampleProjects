<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="blogpage.aspx.cs" Inherits="EcommerceWebsite.blogpage" %>

<%@ Register Src="UCTopCategory.ascx" TagName="UCTopCategory" TagPrefix="uc1" %>
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
                    <h1>Blog</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Blog</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <div id="column-left" class="col-sm-4 col-lg-3 hidden-xs">
                <%--<uc1:UCTopCategory ID="UCTopCategory1" runat="server" />
                <div class="left_banner left-sidebar-widget mt_30 mb_40">
                    <a href="#">
                        <img src="images/left1.jpg" alt="Left Banner" class="img-responsive" /></a>
                </div>--%>
                <uc1:UCblogcategory runat="server" ID="UCblogcategory" />
                <uc1:UCLatestPost runat="server" ID="UCLatestPost" />
            </div>
            <div class="col-sm-8 col-lg-9 mtb_20">
                <div class="row">
                    <div class="three-col-blog text-left">
                        <asp:Repeater ID="rptBlogs" runat="server">
                            <ItemTemplate>
                                <div class="blog-item col-md-6 mb_30">
                                    <div class="post-format">
                                        <div class="thumb post-img">
                                            <a href='Blog/<%#Eval("Name")%>'>
                                                <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/Blog/<%#Eval("sPhoto")%>' alt="Blogs"></a>
                                        </div>
                                        <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                                    </div>
                                    <div class="post-info mtb_20 ">
                                        <h3 class="mb_10"><a href='Blog/<%#Eval("Name")%>'><%#Eval("Name")%></a> </h3>
                                        <p><%# Convert.ToString(Eval("sDescription")).Length > 120 ? Convert.ToString(Eval("sDescription")).Substring(0,120) : Convert.ToString(Eval("sDescription")) %></p>
                                        <div class="details mtb_20">
                                            <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i><%#Eval("CreatedDate")%></div>
                                            <div class="more pull-right"><a href='Blog/<%#Eval("Name")%>'>Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <%-- <div class="blog-item col-md-6 mb_30">
                            <div class="post-format">
                                <div class="thumb post-img">
                                    <a href="single_blog.html">
                                        <img src="images/blog/blog_img_05.jpg" alt="OYEENok"></a>
                                </div>
                                <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                            </div>
                            <div class="post-info mtb_20 ">
                                <h3 class="mb_10"><a href="single_blog.html">Fashions fade, style is eternal</a> </h3>
                                <p>Aliquam egestas pellentesque est. Etiam a orci Nulla id enim feugiat ligula ullamcorper scelerisque. Morbi eu luctus nisl.</p>
                                <div class="details mtb_20">
                                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                                    <div class="more pull-right"><a href="single_blog.html">Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                </div>
                            </div>
                        </div>
                        <div class="blog-item col-md-6 mb_30">
                            <div class="post-format">
                                <div class="thumb post-img">
                                    <a href="single_blog.html">
                                        <img src="images/blog/blog_img_06.jpg" alt="OYEENok"></a>
                                </div>
                                <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                            </div>
                            <div class="post-info mtb_20 ">
                                <h3 class="mb_10"><a href="single_blog.html">Fashions fade, style is eternal</a> </h3>
                                <p>Aliquam egestas pellentesque est. Etiam a orci Nulla id enim feugiat ligula ullamcorper scelerisque. Morbi eu luctus nisl.</p>
                                <div class="details mtb_20">
                                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                                    <div class="more pull-right"><a href="single_blog.html">Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                </div>
                            </div>
                        </div>
                        <div class="blog-item col-md-6 mb_30">
                            <div class="post-format">
                                <div class="thumb post-img">
                                    <a href="single_blog.html">
                                        <img src="images/blog/blog_img_07.jpg" alt="OYEENok"></a>
                                </div>
                                <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                            </div>
                            <div class="post-info mtb_20 ">
                                <h3 class="mb_10"><a href="single_blog.html">Fashions fade, style is eternal</a> </h3>
                                <p>Aliquam egestas pellentesque est. Etiam a orci Nulla id enim feugiat ligula ullamcorper scelerisque. Morbi eu luctus nisl.</p>
                                <div class="details mtb_20">
                                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                                    <div class="more pull-right"><a href="single_blog.html">Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                </div>
                            </div>
                        </div>
                        <div class="blog-item col-md-6 mb_30">
                            <div class="post-format">
                                <div class="thumb post-img">
                                    <a href="single_blog.html">
                                        <img src="images/blog/blog_img_08.jpg" alt="OYEENok"></a>
                                </div>
                                <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                            </div>
                            <div class="post-info mtb_20 ">
                                <h3 class="mb_10"><a href="single_blog.html">Fashions fade, style is eternal</a> </h3>
                                <p>Aliquam egestas pellentesque est. Etiam a orci Nulla id enim feugiat ligula ullamcorper scelerisque. Morbi eu luctus nisl.</p>
                                <div class="details mtb_20">
                                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                                    <div class="more pull-right"><a href="single_blog.html">Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                </div>
                            </div>
                        </div>
                        <div class="blog-item col-md-6 mb_30">
                            <div class="post-format">
                                <div class="thumb post-img">
                                    <a href="single_blog.html">
                                        <img src="images/blog/blog_img_01.jpg" alt="OYEENok"></a>
                                </div>
                                <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                            </div>
                            <div class="post-info mtb_20 ">
                                <h3 class="mb_10"><a href="single_blog.html">Fashions fade, style is eternal</a> </h3>
                                <p>Aliquam egestas pellentesque est. Etiam a orci Nulla id enim feugiat ligula ullamcorper scelerisque. Morbi eu luctus nisl.</p>
                                <div class="details mtb_20">
                                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                                    <div class="more pull-right"><a href="single_blog.html">Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                </div>
                            </div>
                        </div>
                        <div class="blog-item col-md-6 mb_30">
                            <div class="post-format">
                                <div class="thumb post-img">
                                    <a href="single_blog.html">
                                        <img src="images/blog/blog_img_02.jpg" alt="OYEENok"></a>
                                </div>
                                <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                            </div>
                            <div class="post-info mtb_20 ">
                                <h3 class="mb_10"><a href="single_blog.html">Fashions fade, style is eternal</a> </h3>
                                <p>Aliquam egestas pellentesque est. Etiam a orci Nulla id enim feugiat ligula ullamcorper scelerisque. Morbi eu luctus nisl.</p>
                                <div class="details mtb_20">
                                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                                    <div class="more pull-right"><a href="single_blog.html">Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                </div>
                            </div>
                        </div>
                        <div class="blog-item col-md-6 mb_30">
                            <div class="post-format">
                                <div class="thumb post-img">
                                    <a href="single_blog.html">
                                        <img src="images/blog/blog_img_03.html" alt="OYEENok"></a>
                                </div>
                                <div class="post-type"><i class="fa fa-music" aria-hidden="true"></i></div>
                            </div>
                            <div class="post-info mtb_20 ">
                                <h3 class="mb_10"><a href="single_blog.html">Fashions fade, style is eternal</a> </h3>
                                <p>Aliquam egestas pellentesque est. Etiam a orci Nulla id enim feugiat ligula ullamcorper scelerisque. Morbi eu luctus nisl.</p>
                                <div class="details mtb_20">
                                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                                    <div class="more pull-right"><a href="single_blog.html">Read more <i class="fa fa-arrow-circle-right" aria-hidden="true"></i></a></div>
                                </div>
                            </div>
                        </div>--%>
                    </div>
                </div>
                <div class="pagination-nav text-center mtb_20">
                    <ul>
                        <asp:HiddenField ID="hdnPageNum" runat="server" Value="1" />
                        <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                            <HeaderTemplate>
                                <li>
                                    <asp:LinkButton ID='lnkFirst' CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="fa fa-angle-left"></i>
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
                                    <asp:LinkButton ID='lnkLast' CommandName="Page" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="fa fa-angle-right"></i>
                                    </asp:LinkButton>
                                </li>
                            </FooterTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function SetActiveButton() {
            debugger;
            //alert($(this).attr('id'));
        }
        <%--function addactiveclass() {
            debugger;
            $(<%# lnkPage.client %>).click(function () {
                $('li.active').removeClass('active');
                $(this).parent('li').addClass('active');
            });
        }--%>
    </script>
</asp:Content>
