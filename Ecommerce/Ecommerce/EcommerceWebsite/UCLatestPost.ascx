<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLatestPost.ascx.cs" Inherits="EcommerceWebsite.UCLatestPost" %>
<div class="left-blog left-sidebar-widget mb_50">
    <div class="heading-part mb_20 ">
        <h2 class="main_title">Latest Post</h2>
    </div>
    <div id="left-blog">
        <div class="row ">
            <asp:Repeater ID="rptLatestPosts" runat="server">
                <ItemTemplate>
                    <div class="blog-item mb_20">
                        <div class="post-format col-xs-4">
                            <div class="thumb post-img">
                                <a href='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/Blog/<%#Eval("Name")%>'>
                                    <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/Blog/<%#Eval("sPhoto")%>' alt="OYEENok"></a>
                            </div>
                        </div>
                        <div class="post-info col-xs-8 ">
                            <h5><a href='../Blog/<%#Eval("Name")%>'><%#Eval("Name")%></a> </h5>
                            <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i><%# Convert.ToDateTime(Eval("CreatedDate")).Day + " " +Convert.ToDateTime(Eval("CreatedDate")).ToString("MMM") + " " +Convert.ToDateTime(Eval("CreatedDate")).Year %> </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <%-- <div class="blog-item mb_20">
                <div class="post-format col-xs-4">
                    <div class="thumb post-img">
                        <a href="single_blog.html">
                            <img src="images/blog/blog_img_02.jpg" alt="OYEENok"></a>
                    </div>
                </div>
                <div class="post-info col-xs-8 ">
                    <h5><a href="single_blog.html">Fashions fade, style is eternal</a> </h5>
                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                </div>
            </div>
            <div class="blog-item mb_20">
                <div class="post-format col-xs-4">
                    <div class="thumb post-img">
                        <a href="single_blog.html">
                            <img src="images/blog/blog_img_03.html" alt="OYEENok"></a>
                    </div>
                </div>
                <div class="post-info col-xs-8 ">
                    <h5><a href="single_blog.html">Fashions fade, style is eternal</a> </h5>
                    <div class="date pull-left"><i class="fa fa-calendar" aria-hidden="true"></i>11 May 2017 </div>
                </div>
            </div>--%>
        </div>
    </div>
</div>
