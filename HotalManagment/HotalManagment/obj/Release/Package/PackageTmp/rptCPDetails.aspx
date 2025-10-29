<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="rptCPDetails.aspx.cs" Inherits="HotalManagment.rptCPDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-wrapper">
        <div class="page-container">
            <div class="page-content-wrapper">
                <div class="page-content">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card card-box">
                                <div class="card-head">
                                    <header>CHANNEL PARTNER DETAILS</header>
                                    <div class="tools">
                                        <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a><a class="t-collapse btn-color fa fa-chevron-down"
                                            href="javascript:;"></a><a class="t-close btn-color fa fa-times" href="javascript:;">
                                            </a>
                                    </div>
                                </div>
                                <div class="card-body ">
                                    <asp:Repeater ID="rptCPdetail" runat="server">
                                        <HeaderTemplate>
                                            <table id="dataTable" class="display full-width">
                                                <tr>
                                                    <th style="width: 50px">
                                                        BookingID
                                                    </th>
                                                    <th>
                                                        Booking Vendor
                                                    </th>
                                                    <th>
                                                        Booking Status
                                                    </th>
                                                    <th>
                                                        Customer Name
                                                    </th>
                                                    <th>
                                                        Check-in
                                                    </th>
                                                    <th>
                                                        Check-out
                                                    </th>
                                                    <th>
                                                        Booked On
                                                    </th>
                                                    <th>
                                                        PAH Booking
                                                    </th>
                                                    <th>
                                                        Room name (Rate Plan)
                                                    </th>
                                                    <th>
                                                        No. of Rooms
                                                    </th>
                                                    <th>
                                                        No. of Nights
                                                    </th>
                                                    <th>
                                                        Extra Adult/Child Charges (B)
                                                    </th>
                                                    <th>
                                                        Gross Payable (A+B+C-D)
                                                    </th>
                                                    <th>
                                                        Amount collected from guest
                                                    </th>
                                                    <th>
                                                        Hotel To pay to travinities
                                                    </th>
                                                    <th>
                                                        Trav to pay to hotel
                                                    </th>
                                                </tr>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <%#Eval("BookingID") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Booking Vendor") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Booking Status") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Customer Name") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Check-in") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Check-out") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Booked On") %>
                                                </td>
                                                <td>
                                                    <%#Eval("PAH Booking") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Room name") %>
                                                </td>
                                                <td>
                                                    <%#Eval("No of Rooms") %>
                                                </td>
                                                <td>
                                                    <%#Eval("No of Nights") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Extra Adult") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Gross Payable") %>
                                                </td>
                                                <td>
                                                    <%#Eval("amount collected from guest") %>
                                                </td>
                                                <td>
                                                    <%#Eval("Hotel To pay to travinities") %>
                                                </td>
                                                <td>
                                                    <%#Eval("trav to pay to hotel") %>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
