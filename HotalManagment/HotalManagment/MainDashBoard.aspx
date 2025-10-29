<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="MainDashBoard.aspx.cs" Inherits="HotalManagment.MainDashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard</title>
    <link href="assets/plugins/summernote/summernote.css" rel="stylesheet" />
    <link href="assets/plugins/morris/morris.css" rel="stylesheet" type="text/css" />
    <script src="assets/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script src="assets/js/pages/sparkline/sparkline-data.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <div class="page-bar">
            <div class="page-title-breadcrumb">
                <div class=" pull-left">
                    <div class="page-title">
                        Dashboard</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Dashboard</li>
                </ol>
            </div>
        </div>
        <!-- start widget -->
        <div class="state-overview">
            <div class="row" id="idHotelDetail" runat="server">
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-blue">
                        <span class="info-box-icon push-bottom"><i class="material-icons">style</i></span>
                        <div id="idTotalHotel" runat="server" class="info-box-content">
                        </div>
                    </div>
                </div>
                <!-- /.col -->
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-orange">
                        <span class="info-box-icon push-bottom"><i class="material-icons">card_travel</i></span>
                        <div id="idTotalHotelActive" runat="server" class="info-box-content">
                        </div>
                    </div>
                </div>
                <!-- /.col -->
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-purple">
                        <span class="info-box-icon push-bottom"><i class="material-icons">phone_in_talk</i></span>
                        <div id="idTotalHotelExp" runat="server" class="info-box-content">
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-success">
                        <span class="info-box-icon push-bottom"><i class="material-icons">monetization_on</i></span>
                        <div id="idTotalHotelExpMonth" runat="server" class="info-box-content">
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
            </div>
            <div class="row" id="idRoomsDetail" runat="server">
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-blue">
                        <span class="info-box-icon push-bottom"><i class="material-icons">style</i></span>
                        <div id="idTotalRooms" runat="server" class="info-box-content">
                        </div>
                    </div>
                </div>
                <!-- /.col -->
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-orange">
                        <span class="info-box-icon push-bottom"><i class="material-icons">card_travel</i></span>
                        <div id="idRoomBooked" runat="server" class="info-box-content">
                        </div>
                    </div>
                </div>
                <!-- /.col -->
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-purple">
                        <span class="info-box-icon push-bottom"><i class="material-icons">phone_in_talk</i></span>
                        <div id="idAvailableRoom" runat="server" class="info-box-content">
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
                <div class="col-xl-3 col-md-6 col-12">
                    <div class="info-box bg-success">
                        <span class="info-box-icon push-bottom"><i class="material-icons">monetization_on</i></span>
                        <div id="idRoomHK" runat="server" class="info-box-content">
                        </div>
                        <!-- /.info-box-content -->
                    </div>
                    <!-- /.info-box -->
                </div>
                <!-- /.col -->
            </div>
        </div>
        <!-- end widget -->
        <!-- chart start -->
        <div id="idBookingDetail" runat="server" class="row">
            <div class="col-md-12">
                <div class="card card-box">
                    <div class="card-head">
                        <header>Booking</header>
                    </div>
                    <div class="card-body no-padding height-9">
                        <div class="row text-center">
                            <div class="col-sm-3 col-6">
                                <h4 class="margin-0">
                                    <span id="TodayIncome" runat="server"></span>
                                </h4>
                                <p class="text-muted">
                                    Today's Revenue</p>
                            </div>
                            <div class="col-sm-3 col-6">
                                <h4 class="margin-0">
                                    <span id="WeekIncome" runat="server"></span>
                                </h4>
                                <p class="text-muted">
                                    This Week's Revenue</p>
                            </div>
                            <div class="col-sm-3 col-6">
                                <h4 class="margin-0">
                                    <span id="MonthIncome" runat="server"></span>
                                </h4>
                                <p class="text-muted">
                                    This Month's Revenue</p>
                            </div>
                        </div>
                        <div class="row">
                            <asp:HiddenField ID="hdWeekltData" runat="server" ClientIDMode="Static" />
                            <div id="WeeklyChart" class="width-100">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Chart end -->
        <div class="row">
            <div id="idBookingDetails" runat="server" class="col-md-4 col-sm-12 col-12">
                <div class="card bg-info">
                    <div class="text-white py-3 px-4">
                        <h6 class="card-title text-white mb-0">
                            Rooms Booking
                        </h6>
                        <asp:HiddenField ID="hdBookingRooms" runat="server" ClientIDMode="Static" />
                        <p>
                            <span id="valBookingRooms" runat="Server"></span>
                        </p>
                        <div id="sparklineBookingRooms">
                        </div>
                        <small class="text-white">Month Wise</small>
                    </div>
                </div>
                <div class="card bg-success">
                    <div class="text-white py-3 px-4">
                        <h6 class="card-title text-white mb-0">
                            Booking Amount</h6>
                        <asp:HiddenField ID="hdBookingAmount" runat="server" ClientIDMode="Static" />
                        <p>
                            <span id="valBookingAmount" runat="Server"></span>
                        </p>
                        <div id="sparklineBookingAmount">
                        </div>
                        <small class="text-white">Month Wise</small>
                    </div>
                </div>
            </div>
            <div id="isPlanActive" runat="server" class="col-md-4 col-sm-12 col-12">
                <div class="card  card-box">
                    <div class="card-head">
                        <header>Plans Active</header>
                    </div>
                    <div class="card-body no-padding height-9">
                        <div class="row text-center">
                            <asp:HiddenField ID="hdPlanActive" runat="server" ClientIDMode="Static" />
                        </div>
                        <div class="row">
                            <div id="chartPlanActive" class="width-100 height-250">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="idPlanAmount" runat="server" class="col-md-4 col-sm-12 col-12">
                <div class="card  card-box">
                    <div class="card-head">
                        <header>Plans Amount</header>
                    </div>
                    <div class="card-body no-padding height-9">
                        <div class="row text-center">
                            <asp:HiddenField ID="hdPlanUsed" runat="server" ClientIDMode="Static" />
                        </div>
                        <div class="row">
                            <div id="chartPlanUsed" class="width-100 height-250">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="idEarning" runat="server" class="col-md-4 col-sm-12 col-12">
                <div class="card  card-box">
                    <div class="card-head">
                        <header>Occupancy</header>
                    </div>
                    <div class="card-body no-padding height-9">
                        <div class="row text-center">
                            <asp:HiddenField ID="hdOTAWalkin" runat="server" ClientIDMode="Static" />
                            <div class="col-sm-6 col-6">
                                <h4 class="margin-0">
                                    <span id="idbookingTypeWalkInTotal" runat="server"></span>
                                </h4>
                                <p class="text-muted">
                                    Walkin
                                </p>
                            </div>
                            <div class="col-sm-6 col-6">
                                <h4 class="margin-0">
                                    <span id="idbookingTypeOTATotal" runat="server"></span>
                                </h4>
                                <p class="text-muted">
                                    OTA</p>
                            </div>
                        </div>
                        <div class="row">
                            <div id="OTAWalkinChart" class="width-100 height-250">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="idOTABooking" runat="server" class="col-md-4 col-sm-12 col-12">
                <div class="card  card-box">
                    <div class="card-head">
                        <header>OTA Booking</header>
                    </div>
                    <div class="card-body no-padding height-9">
                        <div class="row text-center">
                            <asp:HiddenField ID="hdOTAList" runat="server" ClientIDMode="Static" />
                            <asp:Repeater ID="RepeaterOTA" runat="server">
                                <ItemTemplate>
                                    <div class="col-sm-4 col-6">
                                        <h4 class="margin-0">
                                            <%#Eval("Total") %>
                                        </h4>
                                        <p class="text-muted">
                                            <%#Eval("BookingSourceName") %></p>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div class="row">
                            <div id="OTAchart" class="width-100 height-250">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- start Payment Details -->
        <div id="isAdmin11" runat="server" class="row">
            <div class="col-md-12 col-sm-12">
                <div class="borderBox light bordered card-box">
                    <div class="borderBox-title tabbable-line">
                        <div class="caption">
                            <span class="caption-subject font-dark bold uppercase">Booking Details</span>
                        </div>
                        <ul class="nav nav-tabs">
                            <li class="nav-item"><a href="#borderBox_tab1" data-toggle="tab" class="active">Upcoming Booking</a></li>
                            <li class="nav-item"><a href="#borderBox_tab2" data-toggle="tab">Check-in </a></li>
                            <li class="nav-item"><a href="#borderBox_tab3" data-toggle="tab">Check out</a></li>
                        </ul>
                    </div>
                    <div class="borderBox-body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="borderBox_tab1">
                                <div class="table-wrap">
                                    <div class="table-responsive">
                                        <table class="table display product-overview mb-30" id="Table1">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        No
                                                    </th>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Booking Date
                                                    </th>
                                                    <th>
                                                        Room Type
                                                    </th>
                                                    <th>
                                                        Status
                                                    </th>
                                                    <th>
                                                        Amount
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="BookingDetail" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="borderBox_tab2">
                                <div class="table-wrap">
                                    <div class="table-responsive">
                                        <table class="table display product-overview mb-30" id="Table2">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        No
                                                    </th>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Booking Date
                                                    </th>
                                                    <th>
                                                        Room Type
                                                    </th>
                                                    <th>
                                                        Status
                                                    </th>
                                                    <th>
                                                        Amount
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="CheckinDetail" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="borderBox_tab3">
                                <div class="table-wrap">
                                    <div class="table-responsive">
                                        <table class="table display product-overview mb-30" id="Table3">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        No
                                                    </th>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Booking Date
                                                    </th>
                                                    <th>
                                                        Room Type
                                                    </th>
                                                    <th>
                                                        Status
                                                    </th>
                                                    <th>
                                                        Amount
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="CheckOutDetail" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="isAdmin12" runat="server" class="row">
            <div class="col-md-12 col-sm-12">
                <div class="borderBox light bordered card-box">
                    <div class="borderBox-title tabbable-line">
                        <div class="caption">
                            <span class="caption-subject font-dark bold uppercase">Hotel Details</span>
                        </div>
                        <ul class="nav nav-tabs">
                            <li class="nav-item"><a href="#borderBox_tab11" data-toggle="tab" class="active">Hotels</a></li>
                            <li class="nav-item"><a href="#borderBox_tab21" data-toggle="tab">Plan Expired</a></li>
                            <li class="nav-item"><a href="#borderBox_tab31" data-toggle="tab">Plan Expire in this
                                week</a></li>
                        </ul>
                    </div>
                    <div class="borderBox-body">
                        <div class="tab-content">
                            <div class="tab-pane active" id="borderBox_tab11">
                                <div class="table-wrap">
                                    <div class="table-responsive">
                                        <table class="table display product-overview mb-30" id="Table4">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        No
                                                    </th>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Start Date
                                                    </th>
                                                    <th>
                                                        Expire Date
                                                    </th>
                                                    <th>
                                                        Duration
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="HotelDetail" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="borderBox_tab21">
                                <div class="table-wrap">
                                    <div class="table-responsive">
                                        <table class="table display product-overview mb-30" id="Table5">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        No
                                                    </th>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Email
                                                    </th>
                                                    <th>
                                                        Contact No
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="expHotelDetail" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="borderBox_tab31">
                                <div class="table-wrap">
                                    <div class="table-responsive">
                                        <table class="table display product-overview mb-30" id="Table6">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        No
                                                    </th>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Email
                                                    </th>
                                                    <th>
                                                        Contact No
                                                    </th>
                                                    <th>
                                                        Expire Date
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody id="ExpHotelDetailInMonth" runat="server">
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- end Payment Details -->
    </div>
    <!-- start js include path -->
    <script src="assets/plugins/jquery/jquery.min.js"></script>
    <script src="assets/plugins/popper/popper.min.js"></script>
    <script src="assets/plugins/jquery-blockui/jquery.blockui.min.js"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- bootstrap -->
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <script src="assets/plugins/sparkline/jquery.sparkline.min.js"></script>
    <script src="assets/js/pages/sparkline/sparkline-data.js"></script>
    <!-- Common js-->
    <script src="assets/js/app.js"></script>
    <script src="assets/js/layout.js"></script>
    <script src="assets/js/theme-color.js"></script>
    <!-- material -->
    <script src="assets/plugins/material/material.min.js"></script>
    <!-- animation -->
    <script src="assets/js/pages/ui/animations.js"></script>
    <!-- morris chart -->
    <script src="assets/plugins/morris/morris.min.js"></script>
    <script src="assets/plugins/morris/raphael-min.js"></script>
    <script src="assets/js/pages/chart/morris/morris_home_data.js"></script>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {


            var str = $('#hdBookingRooms').val();
           
            if (typeof str === 'undefined' || str === null) { } else {

                var element = str.split(",");

                var keys = [];

                for (var i = element.length - 1; i > 0; i--) {
                    keys.push(element[i]);

                }

                $("#sparklineBookingRooms").sparkline(keys, {
                    type: 'line',
                    width: '100%',
                    fillColor: '#5fc29d54',
                    lineColor: '#ffffff',
                    lineWidth: 1,
                    spotRadius: 2,
                    spotColor: '#ffffff',
                    minSpotColor: '#ffffff',
                    maxSpotColor: '#ffffff',
                    highlightSpotColor: '#ffffff',
                    highlightLineColor: '#ffffff',
                    height: '45'
                });
            }



            var str1 = $('#hdBookingAmount').val();
            if (typeof str1 === 'undefined' || str1 === null) { } else {
                var element1 = str1.split(",");
                var keys1 = [];
                for (var i = element1.length - 1; i > 0; i--) {
                    keys1.push(element1[i]);
                }
                $("#sparklineBookingAmount").sparkline(keys1, {
                    type: 'line',
                    width: '100%',
                    fillColor: '#5fc29d54',
                    lineColor: '#ffffff',
                    lineWidth: 1,
                    spotRadius: 2,
                    spotColor: '#ffffff',
                    minSpotColor: '#ffffff',
                    maxSpotColor: '#ffffff',
                    highlightSpotColor: '#ffffff',
                    highlightLineColor: '#ffffff',
                    height: '45'
                });
            }




            var WeeklyDetail = [];

            var str3 = $('#hdWeekltData').val();
            if (typeof str3 === 'undefined' || str3 === null) { } else {
                var element3 = str3.split(",");
                var weekstr = '';
                for (var i = 1; i < element3.length; i++) {
                    weekstr = (element3.length - i) + ' Week ';
                    weekstr += element3[i].split("-")[0];

                    WeeklyDetail.push({
                        'week': weekstr,
                        'value': element3[i].split("-")[1]
                    });

                }


                Morris.Area({
                    element: "WeeklyChart",
                    behaveLikeLine: true,
                    data: WeeklyDetail,
                    xkey: 'week',
                    ykeys: ['value'],
                    labels: ['Amount'],
                    pointSize: 0,
                    lineWidth: 0,
                    resize: true,
                    fillOpacity: 0.8,
                    behaveLikeLine: true,
                    gridLineColor: '#e0e0e0',
                    hideHover: 'auto',
                    lineColors: ['rgb(0, 206, 209)']
                })

                $("text[text-anchor^='middle']").attr("display", "none");
            }


            var OTAList = [];
            var str2 = $('#hdOTAList').val();
            if (typeof str2 === 'undefined' || str2 === null) { } else {
                var element2 = str2.split(",");
                for (var i = 0; i < element2.length; i++) {
                    OTAList.push({
                        'label': element2[i].split("-")[0],
                        'value': element2[i].split("-")[1]
                    });
                }
                Morris.Donut({
                    element: "OTAchart",
                    data: OTAList,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)'],
                    formatter: function (y) {
                        return y + '%'
                    }
                });
            }


            var OTAWalkInList = [];
            var str4 = $('#hdOTAWalkin').val();
            if (typeof str4 === 'undefined' || str4 === null) { } else {
                var element4 = str4.split(",");
                for (var i = 0; i < element4.length; i++) {
                    OTAWalkInList.push({
                        'label': element4[i].split("-")[0],
                        'value': element4[i].split("-")[1]
                    });
                }
                Morris.Donut({
                    element: "OTAWalkinChart",
                    data: OTAWalkInList,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)'],
                    formatter: function (y) {
                        return y + '%'
                    }
                });
            }

           
            var ActivePlanList = [];
            var str3 = $('#hdPlanActive').val();
            if (typeof str3 === 'undefined' || str3 === null) { } else {
                var element3 = str3.split(",");
                for (var i = 0; i < element3.length; i++) {
                    ActivePlanList.push({
                        'label': element3[i].split("-")[0],
                        'value': element3[i].split("-")[1]
                    });
                }
                Morris.Donut({
                    element: "chartPlanActive",
                    data: ActivePlanList,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)'],
                    formatter: function (y) {
                        return y + '%'
                    }
                });
            }


            var ActiveUseList = [];
            var str4 = $('#hdPlanUsed').val();
            if (typeof str4 === 'undefined' || str4 === null) { } else {
                var element4 = str4.split(",");
                for (var i = 0; i < element4.length; i++) {
                    ActiveUseList.push({
                        'label': element4[i].split("-")[0],
                        'value': element4[i].split("-")[1]
                    });
                }
                Morris.Donut({
                    element: "chartPlanUsed",
                    data: ActiveUseList,
                    colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)'],
                    formatter: function (y) {
                        return y + 'Rs.'
                    }
                });
            }
        });
    </script>
</asp:Content>
