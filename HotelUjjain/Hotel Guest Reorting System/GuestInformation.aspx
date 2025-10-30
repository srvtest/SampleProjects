<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="GuestInformation.aspx.cs" Inherits="Hotel_Guest_Reporting_System.GuestInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .GuestInfo {
            list-style-type: none;
            margin: 0;
            padding: 0;
            overflow: hidden;
            /*background-color: #333333;*/
        }

        .hotelinfo {
            float: left;
            padding: 16px;
            display: flex;
        }

        /*li a {
                display: block;*/
        /* color: white;
                text-align: center;*/
        /*padding: 16px;
                text-decoration: none;
            }*/

        /*   li a:hover {
                    background-color: #111111;
                }*/
       

        .card-header {
            padding: 20px;
            background-color: transparent;
            color: #052132;
            border-bottom: none;
        }

        .Guesttext {
            color: #052132;
        }

        h6 {
            color: #052132;
            font-weight: 500;
        }

        .Guesttextlabel {
            color: #979797;
        }

        

       
        /*#979797*/
        .container-fluid {
            margin-left: auto;
            margin-right: auto;
            padding-left: 15px;
            padding-right: 15px;
            background-color: white;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../assets/hotel-detail.component.scss">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div style="float: right; padding-right: 10px; padding-top: 10px; padding-bottom: 10px;">
            <asp:HiddenField ID="hdnDoc" runat="server" ClientIDMode="Static" Value="" />
            <button class="btn btn-guest" onclick="printDiv('printableArea')"><span class="fa fa-print" aria-hidden="true" style="font-size: 15px;">Generate PDF</span></button>
        </div>
        <div id="printableArea">
            <div class="row">
                <div class="col-md-12">
                    <div class="card">
                        <div class="card-header">
                            <h1 id="lblHotelName" runat="server"></h1>
                        </div>
                        <div class="card-body">
                            <ul class="GuestInfo">
                                <li class="hotelinfo">
                                    <div>
                                        <img src="../../../assets/images/address-icon.svg" />
                                    </div>
                                    <div style="margin-left: 10px;">
                                        <label class="Guesttextlabel">Address:</label>
                                        <h6 id="lblHotelAddress" runat="server"></h6>
                                    </div>
                                </li>
                                <li class="hotelinfo">
                                    <div>
                                        <img src="../../../assets/images/telephone-icon.svg" />
                                    </div>
                                    <div style="margin-left: 10px;">
                                        <label class="Guesttextlabel">Mobile Number:</label>
                                        <h6 id="lblHotelContact" runat="server"></h6>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header" style="background-color: #ffe2c8;">
                            <h5><b>अतिथि की जानकारी रिपोर्ट</b>
                            </h5>
                        </div>
                        <div class="card-body">
                            <ul class="GuestInfo">
                                <li class="hotelinfo">
                                    <div>
                                        <img src="../../../assets/images/checkin-date.svg" />
                                    </div>
                                    <div style="margin-left: 10px;">
                                        <label class="Guesttextlabel">चेक इन तारीख :</label>
                                        <h6 id="lblCheckIndate" runat="server"></h6>
                                    </div>
                                </li>
                                <li class="hotelinfo">
                                    <div>
                                        <img src="../../../assets/images/total-number.svg" />
                                    </div>
                                    <div style="margin-left: 10px;">
                                        <label class="Guesttextlabel">कुल व्यक्ति संख्या :</label>
                                        <h6 id="lblTotalGuest" runat="server"></h6>
                                    </div>
                                </li>
                                <li class="hotelinfo">
                                    <div>
                                        <img src="../../../assets/images/report-icon01.svg" />
                                    </div>
                                    <div style="margin-left: 10px;">
                                        <label class="Guesttextlabel">रिपोर्ट सबमिट :</label>
                                        <h6 id="lblisSumbit" runat="server">Yes</h6>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <%-- <div class="row">
            <div class="col-md-12">
                <div class="box box-primary">
                    <div class="box-body box-profile">
                        <div class="col-md-3">
                            <b>चेक इन तारीख </b>: <a id="lblCheckIndate" runat="server" class="text-aqua"></a>
                        </div>
                        <div class="col-md-3">
                            <b>चेक आउट तारीख </b>: <a id="lblCheckOutdate" runat="server" class="text-aqua">20-05-2024</a>
                        </div>
                        <div class="col-md-3">
                            <b>कुल व्यक्ति संख्या </b>: <a id="lblTotalGuest" runat="server" class="text-aqua">1</a>
                        </div>
                        <div class="col-md-3">
                            <b>रिपोर्ट सबमिट</b>: <a id="lblisSumbit" runat="server" class="text-aqua">Yes</a>
                        </div>
                    </div>
                </div>

            </div>
        </div>--%>
                    <div class="row">
                        <div class="col-md-12 table-responsive">
                            <asp:Repeater runat="server" ID="rptGuestDetailTbl">
                                <HeaderTemplate>
                                    <table class="table table-striped" style="width: 100%" id="example1">
                                        <thead class="Guestthead">
                                            <tr>
                                                <th class="Guestth">चेक इन नंबर</th>
                                                <th class="Guestth">नाम</th>
                                                <th class="Guestth">जेंडर</th>
                                                <th class="Guestth">आयु</th>
                                                <th class="Guestth">मोबाइल नंबर</th>
                                                <th class="Guestth">शहर</th>
                                                <th class="Guestth">यात्रा का उद्देश्य</th>
                                                <th class="Guestth">आईडी प्रकार</th>
                                                <th class="Guestth">आईडी नंबर</th>
                                                <th class="Guestth"></th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td class="Guesttd"><%# Eval("BookingID") %></td>
                                        <td class="Guesttd"><%#Eval("guestName")%> </td>
                                        <td class="Guesttd"><%#Eval("gender")%></td>
                                        <td class="Guesttd"><%#Eval("guestAge")%></td>
                                        <td class="Guesttd"><%#Eval("guestMobileNumber")%></td>
                                        <td class="Guesttd"><%#Eval("guestCity")%></td>
                                        <td class="Guesttd"><%#Eval("guestVisitPurpose")%></td>
                                        <td class="Guesttd"><%#Eval("guestIDType")%></td>
                                        <td class="Guesttd"><%#Eval("guestIDNumber")%></td>
                                        <td></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </table>
                        <div style="break-after: page"></div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 table-responsive">
                            <asp:Repeater ID="rptDetail" runat="server" OnItemDataBound="rptDetail_ItemDataBound">
                                <HeaderTemplate>
                                    <table class="table table-striped" style="width: 100%" id="example2">
                                        <thead class="Guestthead">
                                            <tr>
                                                <th class="Guestth">चेक इन नंबर</th>
                                                <th class="Guestth">नाम</th>
                                                <th class="Guestth">बुकिंग टिप्पणी</th>
                                                <th class="Guestth">फ्रंटसाइड आईडी</th>
                                                <th class="Guestth">बैकसाइड आईडी</th>
                                            </tr>
                                        </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%-- <div class="row">
                                        <div class="col-md-12">
                                            <div class="box box-primary">
                                                <div class="box-body box-profile">--%>
                                    <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("guestID")%>' />

                                    <tr>
                                        <td class="Guesttd"><%#Eval("BookingID")%></td>
                                        <td class="Guesttd"><%#Eval("guestName")%></td>
                                        <td class="Guesttd"><%# (Convert.ToString(Eval("BookingComment"))== ""? "NA":Eval("BookingComment"))%></td>
                                        <td>
                                            <asp:Image ID="Image1" runat="server" Width="150px" /></td>
                                        <td>
                                            <asp:Image ID="Image2" runat="server" Width="150px" /></td>
                                    </tr>
                                </ItemTemplate>

                                <%--  </div>
                                            </div>
                                        </div>
                                    </div>--%>
                                <FooterTemplate>
                                    </table>
                                   <%-- <div style="break-after: page"></div>--%>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>

                </div>
                <script>
                    function printDiv(divName) {
                        var DocName = $("#<%=hdnDoc.ClientID%>").val();
                        var printContents = document.getElementById(divName).innerHTML;
                        var originalContents = document.body.innerHTML;

                        document.body.innerHTML = printContents;
                        document.title = DocName;
                        window.print();

                        document.body.innerHTML = originalContents;
                    }
                </script>
            </div>
        </div>
    </div>
</asp:Content>
