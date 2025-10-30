<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Police_Station_Reporting_System.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mx-auto {
            margin-left: auto;
            margin-right: auto;
        }

        @media screen and (min-width: 480px) {
            body {
                /*background-color: lightgreen;*/
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="cp_body_divSchoolDashboard" class="content">
        <!-- Small boxes (Stat box) -->
        <div class="row" style="padding-top: 10px;">
            <div class="col-lg-6 col-md-6">
                <a href="PendingGuestDetails.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-aqua">
                        <div class="inner">
                            <p id="cp_body_spntotaluser" style="text-align: center; margin-top: 40px; font-size: x-large;">गेस्ट की जानकारी देखे</p>
                            <%--  <p style="text-align: center; font-size: large;">होटल द्वारा भेजी गई चेक इन की जानकारी देखने के लिए</p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-eye"></i>
                        </div>
                        <%-- <a href="GuestDetails.aspx" class="small-box-footer">होटल द्वारा भेजी गई चेक इन की जानकारी देखने के लिए इस लिंक पर क्लिक करें। <i class="fa fa-arrow-circle-right"></i></a>--%>
                        <div class="small-box-footer">यहां क्लिक करें।<i class="fa fa-arrow-circle-right"></i> </div>
                    </div>
                </a>
            </div>
            <div class="col-lg-6 col-md-6">
                <a href="GuestDetails.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-blue">
                        <div class="inner">
                            <p id="cp_body_spntotaluser" style="text-align: center; margin-top: 40px; font-size: x-large;">चेक इन रिपोर्ट देखें</p>
                            <%--  <p style="text-align: center; font-size: large;">होटल द्वारा भेजी गई चेक इन की जानकारी देखने के लिए</p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-download"></i>
                        </div>
                        <%-- <a href="GuestDetails.aspx" class="small-box-footer">होटल द्वारा भेजी गई चेक इन की जानकारी देखने के लिए इस लिंक पर क्लिक करें। <i class="fa fa-arrow-circle-right"></i></a>--%>
                        <div class="small-box-footer">यहां क्लिक करें।<i class="fa fa-arrow-circle-right"></i> </div>
                    </div>
                </a>
            </div>

            <!-- ./col -->
            <div class="col-lg-6 col-md-6">
                <a href="SearchGuests.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-yellow">

                        <div class="inner">
                            <p id="cp_body_spntotalexpense" style="text-align: center; margin-top: 40px; font-size: x-large;">सर्च गेस्ट </p>
                            <%-- <p style="text-align: center; font-size: large;">किसी गेस्ट को सर्च करने के लिए </p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-search"></i>
                        </div>
                        <%--<a href="SearchGuests.aspx" class="small-box-footer">किसी गेस्ट को सर्च करने के लिए यहाँ क्लिक करे | <i class="fa fa-arrow-circle-right"></i></a>--%>
                        <div class="small-box-footer">यहां क्लिक करें।<i class="fa fa-arrow-circle-right"></i> </div>
                    </div>
                </a>
            </div>
            <!-- ./col -->
            <div class="col-lg-6 col-md-6">
                <a href="frmsurveillance.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-red">
                        <div class="inner">
                            <p id="cp_body_spntotalexpense" style="text-align: center; margin-top: 40px; font-size: x-large;">आईडी को निगरानी के लिए जोड़ें </p>
                            <%-- <p style="text-align: center; font-size: large;">किसी आईडी को निगरानी में जोड़ने के लिए </p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-camera-retro"></i>
                        </div>
                        <%--<a href="frmsurveillance.aspx" class="small-box-footer">किसी आईडी को निगरानी में जोड़ने के लिए यहां क्लिक करें। <i class="fa fa-arrow-circle-right"></i></a>--%>
                        <div class="small-box-footer">यहां क्लिक करें।<i class="fa fa-arrow-circle-right"></i> </div>
                    </div>
                </a>
            </div>
            <div class="col-lg-6 col-md-6">
                <a href="GuestList.aspx">
                    <!-- small box -->
                    <div class="admindashwidget small-box bg-green">
                        <div class="inner">
                            <p id="cp_body_spntotalfees" style="text-align: center; margin-top: 40px; font-size: x-large;">चेक इन रिपोर्ट न भेजने वाली होटलो की सूची</p>
                            <%--  <p style="text-align: center; font-size: large;">चेक इन रिपोर्ट न भेजने वाली होटलों की सूची देखने के लिए </p>--%>
                        </div>
                        <div class="icon">
                            <i class="fa fa-warning"></i>
                        </div>
                        <%--<a href="GuestList.aspx" class="small-box-footer">चेक इन रिपोर्ट न भेजने वाली होटलों की सूची देखने के लिए क्लिक करें। <i class="fa fa-arrow-circle-right"></i></a>--%>
                        <div class="small-box-footer">यहां क्लिक करें।<i class="fa fa-arrow-circle-right"></i> </div>
                    </div>
                </a>
            </div>
            <%--  <div class="col-lg-6 col-md-6">
                <!-- small box -->
                <div class="admindashwidget small-box bg-aqua">
                    <div class="inner">
                        <h3 id="cp_body_spntotalfees">महत्वपूर्ण नियम एवं शर्तें: </h3>

                        <p>महत्वपूर्ण नियम एवं शर्तें:</p>
                    </div>
                    <div class="icon">
                        <i class="fa fa-money"></i>
                    </div>
                    <a href="TermsConditions.aspx" class="small-box-footer">Click here <i class="fa fa-arrow-circle-right"></i></a>
                </div>
            </div>--%>
            <!-- ./col -->
        </div>
    </section>
</asp:Content>
