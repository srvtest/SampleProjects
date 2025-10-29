<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="BookingInformation.aspx.cs" Inherits="HotalManagment.BookingInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .booking-status table tr td
        {
            padding: 5px;
        }
        .booking-status table tr td:first-child
        {
            background: lightgray;
        }
        .booking-status table
        {
            border: 1px solid lightgray;
            display: block;
        }
        .booking-p
        {
            margin-top: 10px;
            margin-bottom: 10px;
            padding-left: 0;
            padding-right: 0;
        }
        .booking-p table thead tr td, .booking-p table tbody tr td
        {
            padding: 5px;
        }
        .booking-p thead
        {
            background: lightgray;
        }
        .booking-guest
        {
            border: 1px solid gray;
            padding: 10px;
        }
        .book-id
        {
            padding-left: 0;
            padding-right: 0;
        }
        .book-id div
        {
            margin-bottom: 5px;
        }
        .booking-header
        {
            border: 0px solid lightgray;
        }
        .booking
        {
            padding: 17px;
            background: lightgray;
            display: block;
        }
    </style>
    <title>Booking Information</title>
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700"
        rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="assets/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <!--bootstrap -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Material Design Lite CSS -->
    <link rel="stylesheet" href="assets/plugins/material/material.min.css">
    <link rel="stylesheet" href="assets/css/material_style.css">
    <!-- animation -->
    <link href="assets/css/pages/animate_page.css" rel="stylesheet">
    <!-- Template Styles -->
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/theme-color.css" rel="stylesheet" type="text/css" />
    <!-- favicon -->
    <link rel="shortcut icon" href="assets/img/favicon.ico" />
    <link rel="stylesheet" href="assets/plugins/jquery-toast/dist/jquery.toast.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <div class="page-bar">
            <div class="page-title-breadcrumb">
                <div class=" pull-left">
                    <div class="page-title">
                        Booking Information</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Booking Information </li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdGSTPer" runat="server" Value="0" />
        <asp:HiddenField ID="hdType" runat="server" Value="0" />
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                      <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Booking Information</header>
                                <div class="tools">
                                    <div class="tools">
                                        <a onclick="printItem(); return false;" href="#"><i class="fa fa-print"></i>Item</a>
                                        <a onclick="printRoom(); return false;" href="#"><i class="fa fa-print"></i>Receipt</a>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <div id="MainDiv" class="card-body " runat="server" clientidmode="Static">
                                <div class="table-scrollable">
                                    <div class="row-fluid sortable">
                                        <div class="box span12">
                                            <div class="box-content">
                                                <div class="booking-header">
                                                    <asp:Label ID="lblHtml" runat="server" Text="Label"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                    <script>
                        function printRoom() {
                            $(".roomcls").show();
                            $(".itemcls").hide();
                            var divToPrint = document.getElementById('MainDiv');
                            var newWin = window.open('', 'Print-Window');
                            newWin.document.open();
                            newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
                            newWin.document.close();
                            setTimeout(function () { newWin.close(); }, 10);
                            $(".roomcls").show();
                            $(".itemcls").show();
                        }
                        function printItem() {
                            $(".roomcls").hide();
                            $(".itemcls").show();
                            var divToPrint = document.getElementById('MainDiv');
                            var newWin = window.open('', 'Print-Window');
                            newWin.document.open();
                            newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
                            newWin.document.close();
                            setTimeout(function () { newWin.close(); }, 10);
                            $(".roomcls").show();
                            $(".itemcls").show();
                        }
                    </script>
</asp:Content>
