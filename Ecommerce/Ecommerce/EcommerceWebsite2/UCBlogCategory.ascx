<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBlogCategory.ascx.cs" Inherits="EcommerceWebsite2.UCBlogCategory" %>

<div class="blog-sidebar">
    <h5 class="title">categories</h5>
    <ul class="blog-archive blog-category">
        <asp:Repeater ID="rptBlogCategory" runat="server">
            <ItemTemplate>
                 <li><a href='<%# Eval("URL") %>'><%# Eval("Name") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
        <%--<li><a href="#">Barber (10)</a></li>
        <li><a href="#">fashion (08)</a></li>
        <li><a href="#">handbag (07)</a></li>
        <li><a href="#">Jewelry (14)</a></li>
        <li><a href="#">food (10)</a></li>--%>
    </ul>
</div>