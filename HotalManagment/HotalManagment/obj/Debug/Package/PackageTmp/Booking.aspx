<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="Booking.aspx.cs" Inherits="HotalManagment.Booking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Booking</title>
        <link rel="stylesheet" href="assets/plugins/jquery-toast/dist/jquery.toast.min.css">
    <style type="text/css">
        .push-bottom
        {
            margin-top: 0px;
            font-size: 30px;
        }
        .info-box-content
        {
            padding: 0;
            margin-left: 0px;
        }
        .info-box-icon
        {
            float: left;
            height: auto;
            width: auto;
            text-align: center;
            font-size: 19px;
            line-height: 55px;
            background: none;
            border-radius: 0;
        }
        .info-box
        {
            text-align: center;
            padding: 0;
            border-radius: 0;
            color: White;
        }
        .state-overview p
        {
            margin-bottom: 0;
        }
        .info-box-number
        {
            font-weight: 200;
            word-wrap: normal;
            font-size: 12px;
        }
        .box-room
        {
            margin-left: 9px;
            overflow: hidden;
            text-overflow: ellipsis;
            padding-left: 5px;
            width: 120px;
        }
        .header
        {
            white-space: nowrap;
            background: rgba(255,255,255,0.2);
            font-size: 13px;
            padding: 0 16px;
        }
        .bg-blueNew
        {
            background-color: #044c8c;
        }
        .bg-purpleNew
        {
            background-color: #868383;
        }
        .bg-redNew
        {
            background-color: #b92936;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <div class="page-bar">
            <div class="page-title-breadcrumb">
                <div class=" pull-left">
                    <div class="page-title">
                        Booking</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Booking </li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
        <div class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Booking</header>
                                <div class="tools">
                                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/TempBooking.aspx">
                                        <i class="material-icons">business_center</i>
                                        <asp:Label ID="lblPrebooking" runat="server" Text=""></asp:Label>
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="card-body ">
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:DropDownList ID="ddCategoryData" runat="server" CssClass="form-control ddCategory"
                                            OnSelectedIndexChanged="ddCategoryData_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2 col-md-offset-8 ">
                                        <asp:TextBox ID="date" runat="server" Style="background: #fff; cursor: pointer;"
                                            class="datepickerAll BookingDate form-control" placeholder="From Date" AutoPostBack="True"
                                            OnTextChanged="txtBookingDate_TextChanged"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red"
                                            ErrorMessage="Required" ControlToValidate="date" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <span class="glyphicon glyphicon-calendar form-control-feedback"></span>
                                    </div>
                                    <div class="col-md-3" style="float: right;">
                                        <asp:CheckBox ID="chkMiltipleBooking" runat="server" Text="Multiple Booking" AutoPostBack="true"
                                            oncheckedchanged="chkMiltipleBooking_CheckedChanged" />
                                        
                                        <asp:HiddenField ID="hdroomId" runat="server" Value=""  ClientIDMode="Static" />
                                    </div>
                                    <div class="col-md-3" style="float: right;">
                                    <asp:Button ID="btnMultipleBooking" runat="server" Text="Book" onclick="btnMultipleBooking_Click" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink" />
                                    </div>
                                </div>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <hr style="margin-top: 0; " />
                                        <div id="lstRoom" class="row" runat="server">
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddCategoryData" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="date" EventName="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </div>
    <script src="assets/plugins/jquery/jquery.min.js"></script>
    <script src="assets/plugins/popper/popper.min.js"></script>
    <script src="assets/plugins/jquery-blockui/jquery.blockui.min.js"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <!-- bootstrap -->
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
    <!-- Common js-->
    <script src="assets/js/app.js"></script>
    <script src="assets/js/layout.js"></script>
    <script src="assets/js/theme-color.js"></script>
    <!-- Material -->
    <script src="assets/plugins/material/material.min.js"></script>
    <!-- animation -->
    <script src="assets/js/pages/ui/animations.js"></script>
    <!-- notifications -->
    <script src="assets/plugins/jquery-toast/dist/jquery.toast.min.js"></script>
    <script src="assets/plugins/jquery-toast/dist/toast.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            //            $("#grdCategory").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
            //                responsive: true,
            //                sPaginationType: "bootstrap"
            //            });
        });

        function Successmsg() {

            var str = $('#hdMessage').val();

            var msgHead = str.split("|")[0];
            var msg = str.split("|")[1];

            $.toast({
                heading: msgHead,
                text: msg,
                position: 'top-center',
                loaderBg: '#ff6849',
                icon: 'success',
                hideAfter: 3500,
                stack: 6
            });

        }

        function Errormsg() {

            var str = $('#hdMessage').val();
            var msgHead = str.split("|")[0];
            var msg = str.split("|")[1];
            $.toast({
                heading: msgHead,
                text: msg,
                position: 'top-center',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500
            });
        }

        function popupmsg() {

            //            var str = $('#hdMessage').val();
            var msgHead = "Pre booking";
            var msg = "This room is pre booked.";
            $.toast({
                heading: msgHead,
                text: msg,
                position: 'top-center',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500
            });
           
        }

    </script>
    <%--   <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Booking</a></li>
    </ul>
    <asp:ScriptManager EnablePageMethods="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="icon-user"></i><span class="break"></span>Booking</h2>
                <div class="box-icon">
                    
                </div>
            </div>
            <div class="box-content">
                <div class="row">
                   

                </div>
                
             
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->--%>


    <script>
        function handleClick(cb) {

            if ($(cb).prop("checked") == true) {
                var str = $('#hdroomId').val();
                if (str == '') {
                    str = $(cb).val();
                } else {
                    str = str + ',' + $(cb).val();
                }
                $('#hdroomId').val(str);
            }
            else if ($(cb).prop("checked") == false) {
                var str = $('#hdroomId').val();
                var value= $(cb).val();
                if (str.indexOf(","+value) != -1) {
                    var res = str.replace(","+value , "");
                    $('#hdroomId').val(res);
                }else if (str.indexOf(value+",") != -1) {
                    var res = str.replace(value + ",", "");
                    $('#hdroomId').val(res);
                } else {
                    var res = str.replace(value, "");
                    $('#hdroomId').val(res);
                }
                



//                if (str == '') {
//                    str = $(cb).val();
//                } else {
//                    str = str + ',' + $(cb).val();
//                }
//                $('#hdroomId').val(str);
            }

            
        }
    </script>
</asp:Content>
