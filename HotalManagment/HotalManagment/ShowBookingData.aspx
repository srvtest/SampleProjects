<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="ShowBookingData.aspx.cs" Inherits="HotalManagment.ShowBookingData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Show Booking Data</title>
    <link href="js/calendar/fullcalendar.min.css" rel="stylesheet" type="text/css" />
    <script src="js/calendar/moment.min.js" type="text/javascript"></script>
    <script src="js/calendar/fullcalendar.min.js" type="text/javascript"></script>
    <style type="text/css">
        .fc-time
        {
            display: none;
        }
        .fc-title
        {
            margin-left: 3px;
        }
    </style>
    <script type="text/javascript">
        var events;
        function GetEvents() {
            var userId = '<%= Session["UserId"] %>';
            $.ajax({
                type: "POST",
                url: "ShowBookingData.aspx/GetEvents",
                async: false,
                data: '{userId:' + userId + '}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //alert("success:"+JSON.stringify(response.d));
                    events = response.d;
                },
                failure: function (response) {
                    alert("error:" + response.d);
                }
            });
        }

        $(document).ready(function () {
            GetEvents();
            $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay,listWeek'
                },
                defaultDate: $.now(), //'2018-02-12',
                navLinks: true, // can click day/week names to navigate views
                editable: false,
                eventLimit: true, // allow "more" link when too many events
                events: events,
                eventClick: function (event) {
                    if (event.BookingId) {
                        window.open("BookingInformation.aspx?id=" + event.BookingId);
                    }
                }
            });

        });

    </script>
    <%--<style type="text/css">
        #calendar
        {
            max-width: 900px;
            margin: 0 auto;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <div class="page-bar">
            <div class="page-title-breadcrumb">
                <div class=" pull-left">
                    <div class="page-title">
                        Rooms Information</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Room Information </li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Calendar</header>
                                <div class="tools">
                                   <label class="bg-primary" style="color:White; font-weight:normal; ">&nbsp;&nbsp;Room Booked&nbsp;&nbsp;</label>&nbsp;&nbsp;  
                                   <label class="bg-success" style="color:White;">&nbsp;&nbsp;Room CheckIn&nbsp;&nbsp;</label>&nbsp;&nbsp;
                                   <label class="bg-info" style="color:White;">&nbsp;&nbsp;Boonking Complete&nbsp;&nbsp;</label>&nbsp;&nbsp;
                                   <label class="bg-orange" style="color:White;">&nbsp;&nbsp;Booking Cancel&nbsp;&nbsp;</label> 
                                   
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="row-fluid sortable">
                                    <div class="box span12">
                                        <div id='calendar'>
                                        </div>
                                    </div>
                                    <!--/span-->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
