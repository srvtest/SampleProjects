<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLatestPost.ascx.cs" Inherits="EcommerceWebsite2.UCLatestPost" %>

<div class="blog-sidebar">
    <h5 class="title">recent post</h5>
    <div class="recent-post">
        <asp:Repeater ID="rptLatestPost" runat="server">
            <ItemTemplate>
                <div class="recent-post-item">
                    <figure class="product-thumb">
                        <a href='<%# Eval("URL") %>'>
                            <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%# Eval("sPhoto") %>' alt="blog image">
                        </a>
                    </figure>
                    <div class="recent-post-description">
                        <div class="product-name">
                            <h6><a href='../blog/<%# Eval("Name") %>'><%# Eval("Name") %></a></h6>
                            <p><%# Convert.ToDateTime(Eval("CreatedDate")).ToString("MMMM") %> <%# Convert.ToDateTime(Eval("CreatedDate")).Day %>, <%# Convert.ToDateTime(Eval("CreatedDate")).Year %></p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <%--<div class="recent-post-item">
            <figure class="product-thumb">
                <a href="blog-details.html">
                    <img src="assets/img/blog/blog-img1.jpg" alt="blog image">
                </a>
            </figure>
            <div class="recent-post-description">
                <div class="product-name">
                    <h6><a href="blog-details.html">Auctor gravida enim</a></h6>
                    <p>march 10 2019</p>
                </div>
            </div>
        </div>
        <div class="recent-post-item">
            <figure class="product-thumb">
                <a href="blog-details.html">
                    <img src="assets/img/blog/blog-img2.jpg" alt="blog image">
                </a>
            </figure>
            <div class="recent-post-description">
                <div class="product-name">
                    <h6><a href="blog-details.html">gravida auctor dnim</a></h6>
                    <p>march 18 2019</p>
                </div>
            </div>
        </div>
        <div class="recent-post-item">
            <figure class="product-thumb">
                <a href="blog-details.html">
                    <img src="assets/img/blog/blog-img3.jpg" alt="blog image">
                </a>
            </figure>
            <div class="recent-post-description">
                <div class="product-name">
                    <h6><a href="blog-details.html">enim auctor gravida</a></h6>
                    <p>march 14 2019</p>
                </div>
            </div>
        </div>--%>
    </div>
</div>