<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBlogArchives.ascx.cs" Inherits="EcommerceWebsite2.UCBlogArchives" %>

<div class="blog-sidebar">
    <h5 class="title">Blog Archives</h5>
    <ul class="blog-archive">
        <asp:Repeater ID="rptBlogArchives" runat="server">
            <ItemTemplate>
                <%--<asp:HiddenField ID="hdnDate" runat="server" Value="<%# Eval("CreatedDate") %>" />--%>
                <li>
                     <a href="../blogdetails/<%#Eval("BlogArchive")%>">
                         <%#Eval("BlogArchive", "{0:dd MM yyyy}")%>
                         </a>
                   <%-- <asp:LinkButton ID="btnLink" OnClick="btnLink_Click" runat="server"><%# Eval("BlogArchive") %></asp:LinkButton>--%>
                    
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <%--<li><a href="#">January (10)</a></li>
        <li><a href="#">February (08)</a></li>
        <li><a href="#">March (07)</a></li>
        <li><a href="#">April (14)</a></li>
        <li><a href="#">May (10)</a></li>--%>
    </ul>
</div>