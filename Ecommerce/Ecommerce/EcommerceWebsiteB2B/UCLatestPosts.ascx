<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLatestPosts.ascx.cs" Inherits="EcommerceWebsiteB2B.UCLatestPosts" %>
<%--<%@ MasterType VirtualPath="~/Main.Master" %>--%>
<div class="row m0 latestPosts">
    <h4 class="heading">Latest post</h4>

    <asp:Repeater ID="rptLatestPost" runat="server">
        <ItemTemplate>
            <div class="media latestPost">
                <div class="media-left">
                    <a href='<%= baseUrl %>blog/<%# Eval("URL") %>'>
                        <img src='<%=DataLayer.CommonControl.GetImagesUrlAdmin() %>/blog/<%# Eval("sPhoto") %>' alt="blog image">
                    </a>
                </div>
                <div class="media-body">
                    <h6 class="heading"><a href='<%= baseUrl %>blog/<%# Eval("Name") %>'><%# Eval("Name") %></a></h6>
                    <p><%# Convert.ToDateTime(Eval("CreatedDate")).ToString("MMMM") %> <%# Convert.ToDateTime(Eval("CreatedDate")).Day %>, <%# Convert.ToDateTime(Eval("CreatedDate")).Year %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</div>