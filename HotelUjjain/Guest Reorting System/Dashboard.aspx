<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Guest_Reporting_System.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .card-primary.card-outline {
            border-top: 3px solid #007bff;
        }

        .small-box > .small-box-header {
            color: #fff;
            /*background: rgba(0, 0, 0, 0.1);*/
        }

            .small-box > .small-box-header:hover {
                color: #fff;
                background: rgba(0, 0, 0, 0.15);
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="cp_body_divSchoolDashboard" class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row" style="padding-top: 10px;">
            <div class="col-lg-6 col-md-6">
                <a href="AddGuest.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-blue">
                        <div class="inner small-box-header">
                            <p id="cp_body_spntotaluser" class="" style="text-align: center; margin-top: 40px; font-size: x-large;">गेस्ट की जानकारी दर्ज करें</p>
                            <%-- <p>गेस्ट की जानकारी दर्ज करें |</p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-user-plus"></i>
                        </div>
                        <div class="small-box-footer">गेस्ट की जानकारी दर्ज करने के लिए यहाँ क्लिक करे | <i class="fa fa-arrow-circle-right"></i></div>
                    </div>
                </a>
            </div>
            <!-- ./col -->
            <%-- <div class="col-lg-6 col-md-6">
                <!-- small box -->
                <div class="admindashwidget small-box bg-green">
                    <div class="inner">
                        <h3 id="cp_body_spntotalteacher">रिपोर्ट में गेस्ट जोड़े</h3>

                        <p>रिपोर्ट में और गेस्ट को ऐड करने के लिए यहाँ पे जाये</p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-user-secret"></i>
                    </div>
                    <a href='AddGuest.aspx' class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>--%>
            <!-- ./col -->

            <!-- ./col -->
            <div class="col-lg-6 col-md-6">
                <a href="GuestList.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-yellow">
                        <div class="inner small-box-header">
                            <p id="cp_body_spntotalexpense" style="text-align: center; margin-top: 40px; font-size: x-large;">सर्च गेस्ट </p>

                            <%-- <p>किसी गेस्ट को सर्च करने के लिए </p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-search"></i>
                        </div>
                        <div class="small-box-footer">किसी गेस्ट को सर्च करने के लिए यहाँ क्लिक करे | <i class="fa fa-arrow-circle-right"></i></div>
                    </div>
                </a>
            </div>
            <!-- ./col -->
            <div class="col-lg-6 col-md-6">
                <a href="SubmitedData.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-red">
                        <div class="inner small-box-header">
                            <p id="cp_body_spntotalexpense" style="text-align: center; margin-top: 40px; font-size: x-large;">सब्मिटेड रिपोर्ट को डाउनलोड करे या देखे</p>

                            <%-- <p>सब्मिटेड रिपोर्ट को डाउनलोड करे या देखे |</p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-download"></i>
                        </div>
                        <div class="small-box-footer">सब्मिटेड रिपोर्ट को डाउनलोड करने या देखने के लिए यहाँ क्लिक करे | <i class="fa fa-arrow-circle-right"></i></div>
                    </div>
                </a>
            </div>
            <div class="col-lg-6 col-md-6">
                <a href="pendingSummery.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-green">
                        <div class="inner small-box-header">
                            <p id="cp_body_spntotalfees" style="text-align: center; margin-top: 40px; font-size: x-large;">पेंडिंग रिपोर्ट</p>

                            <%-- <p>इस लिंक से आप पेडिंग रिपोर्ट जो आपने अभी तक सबमिट नहीं करी है वो देख सकते है |</p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-eye"></i>
                        </div>
                        <div class="small-box-footer">पेंडिंग रिपोर्ट देखने के लिए यहाँ क्लिक करे | <i class="fa fa-arrow-circle-right"></i></div>
                    </div>
                </a>
            </div>
            <div class="col-lg-6 col-md-6">
                <a href="ZeroCheckIn.aspx?YcheckIn=a18qp9ytr">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-orange">
                        <div class="inner small-box-header">
                            <p id="cp_body_spntotalfees" style="text-align: center; margin-top: 40px; font-size: x-large;">जीरो चेक इन रिपोर्ट</p>

                            <%--<p>कल के जीरो  चेक इन रिपोर्ट को पुलिस स्टेशन में सबमिट करें।</p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-check"></i>
                        </div>
                        <div class="small-box-footer">कल के जीरो चेक इन रिपोर्ट को पुलिस स्टेशन में सबमिट करने के लिए यहाँ क्लिक करे | <i class="fa fa-arrow-circle-right"></i></div>
                    </div>
                </a>
            </div>
            <!-- ./col -->
            <div class="col-lg-6 col-md-6">
                <a href="Important.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-aqua">
                        <div class="inner small-box-header">
                            <p id="cp_body_spntotalfees" style="text-align: center; margin-top: 40px; font-size: x-large;">महत्वपूर्ण नियम एवं शर्तें </p>

                            <%--<p>महत्वपूर्ण नियम एवं शर्तें:</p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-book"></i>
                        </div>
                        <div class="small-box-footer">पोर्टल के महत्वपूर्ण नियम एवं शर्तें जानने के लिए यहाँ क्लिक करे | <i class="fa fa-arrow-circle-right"></i></div>
                    </div>
                </a>
            </div>
            <%-- <div class="row" style="padding-top: 30px;">--%>
            <div class="col-lg-6 col-md-6">
                <asp:LinkButton ID="btnStandard" runat="server" OnClick="btnStandard_Click">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-maroon">
                        <div class="inner small-box-header">
                            <p id="cp_body_spntotaluser" style="text-align: center; margin-top: 20px; font-size: x-large;">मैनेज सब्क्रिप्शन</p>
                            <p style="text-align: center; font-size: large;">
                                प्लान एन्ड डेट - <span id="lblValidUpTo" runat="server"></span>
                            </p>
                        </div>
                        <div class="icon">
                            <i class="fa fa-rupee"></i>
                        </div>
                        <div class="small-box-footer">
                            Pay Now
                        </div>
                    </div>
                </asp:LinkButton>
            </div>
            <%--</div>--%>
        </div>
    </section>
</asp:Content>
