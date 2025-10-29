<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="UpdateInventory.aspx.cs" Inherits="HotalManagment.UpdateInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <title>Update Inventory</title>
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
                        Update Inventory</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Update Inventory</li>
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
                                <header>Update Inventory</header>
                            </div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="card-body ">
                                <div class="row">
                                    <div class="col-lg-4 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="date" runat="server" class="datepickerAll BookingDate mdl-textfield__input"
                                                placeholder="From Date" AutoPostBack="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red"
                                                ErrorMessage="Required" ControlToValidate="date" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <label class="mdl-textfield__label" for="username">
                                                From Date</label>
                                            <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="date1" runat="server" class="datepickerAll BookingDate mdl-textfield__input"
                                                placeholder="To Date" AutoPostBack="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                                ErrorMessage="Required" ControlToValidate="date" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <label class="mdl-textfield__label" for="username">
                                                To Date</label>
                                            <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                        </div>
                                    </div>
                                     <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30% !important; float: left;">
                                        <asp:TextBox ID="txtRoomAvailable" runat="server" CssClass="mdl-textfield__input" type="number"  ViewStateMode="Enabled"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Room Available</label>
                                        <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                    </div>
                                     <div class="col-lg-4 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:CheckBoxList ID="chkCategory" runat="server" DataTextField="CategoryName" DataValueField="Id">
                                            </asp:CheckBoxList>
                                            <label class="mdl-textfield__label" for="username">
                                                </label>
                                        </div>
                                    </div>



                                    <div class="col-lg-12 p-t-20 text-center">
                                        <asp:Button ID="btnsearch" runat="server" Text="Update Inventory" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                            OnClick="btnSave_Click" />
                                    </div>
                                </div>
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


        function Showmsg(msgHead, msg) {
            $.toast({
                heading: msgHead,
                text: msg,
                position: 'top-center',
                loaderBg: '#ff6849',
                icon: 'error',
                hideAfter: 3500,
                stack: 6
            });

        }


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

        function printEar() {
            var divToPrint = document.getElementById('R1Main');
            var newWin = window.open('', 'Print-Window');
            newWin.document.open();
            newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
            newWin.document.close();
            setTimeout(function () { newWin.close(); }, 10);
        }

        function printExp() {
            var divToPrint = document.getElementById('R2Main');
            var newWin = window.open('', 'Print-Window');
            newWin.document.open();
            newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
            newWin.document.close();
            setTimeout(function () { newWin.close(); }, 10);
        }

        function printRemain() {
            var divToPrint = document.getElementById('R4Main');
            var newWin = window.open('', 'Print-Window');
            newWin.document.open();
            newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');
            newWin.document.close();
            setTimeout(function () { newWin.close(); }, 10);
        }
        

    </script>
</asp:Content>
