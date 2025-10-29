<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCBlogsArchives.ascx.cs" Inherits="EcommerceWebsiteB2B.UCBlogsArchives" %>


<div class="row m0 latestPosts">
    <h4 class="heading">Blog Archives</h4>
    <div class="media latestPost">
        <ul style="list-style:none;">
            <asp:Repeater ID="rptBlogArchives" runat="server">
                <ItemTemplate>
                    <div class="media-left">
                        <li>
                             <a href="<%= baseUrl %>blogdetails/<%#Eval("BlogArchive")%>">
                         <%#Eval("BlogArchive", "{0:dd MM yyyy}")%>
                         </a></li>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>