<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNavigation.ascx.cs" Inherits="Hotel_Guest_Reporting_System.usercontrol.ucNavigation" %>

<section class="sidebar scrollsection" id="sidebar-scroll">
    <!-- Sidebar Menu-->
    <asp:Repeater ID="rptNavigation" runat="server">
        <HeaderTemplate>
            <ul class="sidebar-menu">
                <%--  <li class="nav-level">--- Navigation</li>--%>
                <li class="active treeview">
                    <a class="waves-effect waves-dark li-item" href="dashboard.aspx">
                        <i class="icon-speedometer"></i><span>Dashboard</span>
                    </a>                   
                </li>
               <%-- <li class="nav-level li-item">--- Menu Level</li>--%>
        </HeaderTemplate>
        <ItemTemplate>
            <li class="treeview">
                <a class="waves-effect waves-dark li-item" href="<%#Eval("Route")%>">
                    <i class="<%#Eval("Icon")%>"></i><span class="Guesttd"><%#Eval("Label")%></span>
                </a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</section>
