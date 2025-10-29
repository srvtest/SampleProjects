<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="HotalManagment.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Dashboard</a></li>
    </ul>
    <div class="row-fluid">
        <div id="idPurpleBox" runat="server" class="quick-button metro yellow span2">
            <i class="icon-group"></i>
            <p>
                Hotels</p>
            <div id="noOfHotels" runat="server" class="badge">
            </div>
        </div>
        <div id="idGreenBox" runat="server" class="quick-button metro red span2">
            <i class="icon-comments-alt"></i>
            <p>
                Today's Booking</p>
            <div id="idBookingdays" runat="server" class="badge">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
        <div id="idBlueBox" runat="server" class="quick-button metro blue span2">
            <i class="icon-shopping-cart"></i>
            <p>
                Weekly Booking</p>
            <div id="idWeekgdays" runat="server" class="badge">
            </div>
        </div>
        <div id="idYellowBox" runat="server" class="quick-button metro green span2">
            <i class="icon-barcode"></i>
            <p>
                MonthlyBooking</p>
            <div id="idMonthdays" runat="server" class="badge">
            </div>
        </div>
       
   
        <div id="idPurpleBox1" runat="server" class="quick-button metro yellow span2" visible="false">
            <i class="icon-group"></i>
            <p>
                Total Rooms</p>
            <div id="idTotalRooms" runat="server" class="badge">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
        <div id="idBlueBox2" runat="server" class="quick-button metro red span2" visible="false">
            <i class="icon-comments-alt"></i>
            <p>
                Room Booked</p>
            <div id="idRoomBooked" runat="server" class="badge">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
        <div id="idYellowBox2" runat="server" class="quick-button metro blue span2" visible="false">
            <i class="icon-shopping-cart"></i>
            <p>
                Available Room</p>
            <div id="idAvailableRoom" runat="server" class="badge">
                <i class="icon-arrow-down"></i>
            </div>
        </div>
        <div id="idGreenBox2" runat="server" class="quick-button metro green span2" visible="false">
            <i class="icon-barcode"></i>
            <p>
                Room Under House Keeping</p>
            <div id="idRoomHK" runat="server" class="badge">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
       
        <div id="idPurpleBox2" runat="server" class="quick-button metro yellow span2" visible="false">
            <i class="icon-group"></i>
            <p>
                Total CheckIn</p>
            <div id="idNoOfChecking" runat="server" class="badge">
                <i class="icon-arrow-up"></i>
            </div>
            
        </div>
        <div id="idGreenBox3" runat="server" class="quick-button metro red span2" visible="false">
            <i class="icon-comments-alt"></i>
            <p>
                Total Checkout</p>
            <div id="idNoOfCheckOut" runat="server" class="badge">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
        <div class="clearfix">
        </div>
    </div>
    <!--/row-->
    <div class="row-fluid sortable">
        <div class="widget green span6" ontablet="span12" ondesktop="span6">
            <h2>
                <span class="glyphicons globe"><i></i></span>Booking Amount</h2>
            <hr>
            <div class="content">
                <div id="BookingAmount" runat="server" class="verticalChart">
                    <i class="icon-arrow-up"></i>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
        <!--/span-->
        <div class="widget blue span6" ontablet="span12" ondesktop="span6">
            <h2>
                <span class="glyphicons globe"><i></i></span>Booking Rooms</h2>
            <hr>
            <div class="content">
                <div id="BookingRoom" runat="server" class="verticalChart">
                    <i class="icon-arrow-up"></i>
                </div>
                <div class="clearfix">
                </div>
            </div>
        </div>
    </div>
    <div class="row-fluid sortable">
        <div class="widget orange span12" ontablet="span12" ondesktop="span12">
            <asp:Repeater ID="RepterDetails" runat="server">
                <HeaderTemplate>
                    <h2>
                        <span class="glyphicons globe"><i></i></span>Weekly Amount</h2>
                    <hr>
                    <div class="content">
                        <div class="verticalChart">
                </HeaderTemplate>
                <ItemTemplate>
                    <div class='singleBar'>
                        <div class='bar'>
                            <div class='value'>
                                <span>
                                    <%#Eval("Amount") %>
                                </span>
                            </div>
                        </div>
                        <div class='title'>
                            <%#Eval("Monday") %>
                            to
                            <%#Eval("Sunday") %>
                        </div>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                    <div class="clearfix">
                    </div>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="icon-user"></i><span class="break"></span>Booking Detail</h2>
            </div>
            <div class="box-content">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#last20">Last 20 Booking</a></li>
                    <li><a href="#Checkin">Today's Check-in's</a></li>
                    <li><a href="#CheckOut">Today's Check-Out's</a></li>
                </ul>
                <div class="tab-content">
                    <div id="last20" class="tab-pane fade in active">
                        <div id="lstlast20" runat="server" class="todo">
                        </div>
                    </div>
                    <div id="Checkin" class="tab-pane fade">
                        <div id="lstCheckin" runat="server" class="todo">
                        </div>
                    </div>
                    <div id="CheckOut" class="tab-pane fade">
                        <div id="lstCheckOut" runat="server" class="todo">
                        </div>
                    </div>
                </div>
                <!--/span-->
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(".nav-tabs a").click(function () {
                $(this).tab('show');
            });
        });
    </script>
</asp:Content>
