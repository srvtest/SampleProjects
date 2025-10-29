<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="error.aspx.cs" Inherits="EcommerceWebsiteB2B.error" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
         <h2>404</h2>
         <div class="row pageTitle m0">
            <div class="container">
               <h4 class="fleft">404</h4>
               <ul class="breadcrumb fright">
                  <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                  <li class="active">404</li>
               </ul>
            </div>
         </div>
      </section>
      <section id="page404" class="row contentRowPad">
         <div class="container">
            <img src="<%= this.Master.baseUrl %>images/404.png" alt="" />
            <h1>Error 404</h1>
            <h2>Oops! page not found</h2>
         </div>
      </section>
</asp:Content>
