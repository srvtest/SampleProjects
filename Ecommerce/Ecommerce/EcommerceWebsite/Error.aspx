<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="EcommerceWebsite.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .navbar, .main-search, .shopcart {
            display: none;
        }

        .err-block {
            margin-top: 60px;
            margin-bottom: 100px;
        }

        .center-block {
        }
        .home-btn{
            width: 200px;
            margin: auto;
            margin-top: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="err-block">
            <div class="center-block text-center">
                <p>Error Page....</p>
            </div>
            <div class="home-btn">
                <a href="/" class="btn btn-primary">Go to Home Page</a>
            </div>
        </div>
    </div>

</asp:Content>
