<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="Reports.aspx.cs" Inherits="HotalManagment.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Reports</title>
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
                        Report</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Report</li>
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
                                <header>Report</header>
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
                                    <div class="col-lg-12 p-t-20 text-center">
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                            OnClick="btnSave_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default grid-show"
                                            OnClick="btnReset_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="DResult" class="row" runat="server" visible="false">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Result</header>
                            </div>
                            <div class="card-body ">
                                <div class="row">
                                    <div class="col-lg-2 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="txtEarning" runat="server" class="mdl-textfield__input" name="password"
                                                ReadOnly="true" MaxLength="50"></asp:TextBox>
                                            <label class="mdl-textfield__label">
                                                Earning</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="txtExpenses" runat="server" class="mdl-textfield__input" name="password"
                                                ReadOnly="true" MaxLength="50"></asp:TextBox>
                                            <label class="mdl-textfield__label">
                                                Expenses</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-2 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="txtBankTransfer" runat="server" class="mdl-textfield__input" name="password"
                                                ReadOnly="true" MaxLength="50"></asp:TextBox>
                                            <label class="mdl-textfield__label">
                                                Bank Transfer</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="txtBalance" runat="server" class="mdl-textfield__input" name="password"
                                                ReadOnly="true" MaxLength="50"></asp:TextBox>
                                            <label class="mdl-textfield__label">
                                                Balance Amount</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="txtRemainAmount" runat="server" class="mdl-textfield__input" name="password"
                                                ReadOnly="true" MaxLength="50"></asp:TextBox>
                                            <label class="mdl-textfield__label">
                                                Remain Amount (Till Now)</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div id="R1Main" class="col-sm-12">
                                        <div class="card card-topline-green">
                                            <div class="card-head">
                                                <header>Earning</header>
                                                <div class="tools">
                                                    <div class="tools">
                                                        <a onclick="printEar(); return false;" href="#"><i class="fa fa-print"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card-body ">
                                                <div class="table-scrollable">
                                                    <div id="NoRecordsEar" runat="server" visible="false">
                                                        No records are available.
                                                    </div>
                                                    <asp:Repeater ID="rptEarning" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            #
                                                                        </th>
                                                                        <th>
                                                                            Date
                                                                        </th>
                                                                        <th>
                                                                            Particular
                                                                        </th>
                                                                        <th>
                                                                            Amount
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Date")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Particular")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Amount")%>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody> </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="R2Main" class="col-sm-12">
                                        <div class="card card-topline-green">
                                            <div class="card-head">
                                                <header>Expance</header>
                                                <div class="tools">
                                                    <div class="tools">
                                                        <a onclick="printExp(); return false;" href="#"><i class="fa fa-print"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card-body ">
                                                <div class="table-scrollable">
                                                    <div id="NoRecordsExp" runat="server" visible="false">
                                                        No records are available.
                                                    </div>
                                                    <asp:Repeater ID="rptExpance" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            #
                                                                        </th>
                                                                        <th>
                                                                            Date
                                                                        </th>
                                                                        <th>
                                                                            Particular
                                                                        </th>
                                                                        <th>
                                                                            Amount
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Date")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Particular")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Amount")%>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody> </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="R3Main" class="col-sm-12">
                                        <div class="card card-topline-green">
                                            <div class="card-head">
                                                <header>Bank Transfer</header>
                                                <div class="tools">
                                                    <div class="tools">
                                                        <a onclick="printExp(); return false;" href="#"><i class="fa fa-print"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card-body ">
                                                <div class="table-scrollable">
                                                    <div id="NoRecordsBank" runat="server" visible="false">
                                                        No records are available.
                                                    </div>
                                                    <asp:Repeater ID="Repeater1" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            #
                                                                        </th>
                                                                        <th>
                                                                            Date
                                                                        </th>
                                                                        <th>
                                                                            Particular
                                                                        </th>
                                                                        <th>
                                                                            Amount
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Date")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Particular")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Amount")%>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody> </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="R4Main" class="col-sm-12">
                                        <div class="card card-topline-green">
                                            <div class="card-head">
                                                <header>Remain Amount</header>
                                                <div class="tools">
                                                    <div class="tools">
                                                        <a onclick="printRemain(); return false;" href="#"><i class="fa fa-print"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card-body ">
                                                <div class="table-scrollable">
                                                    <div id="NoRecordsRemain" runat="server" visible="false">
                                                        No records are available.
                                                    </div>
                                                    <asp:Repeater ID="rptRemain" runat="server">
                                                        <HeaderTemplate>
                                                            <table class="table" width="100%">
                                                                <thead>
                                                                    <tr>
                                                                        <th>
                                                                            #
                                                                        </th>
                                                                        <th>
                                                                            Date
                                                                        </th>
                                                                        <th>
                                                                            Particular
                                                                        </th>
                                                                        <th>
                                                                            Amount
                                                                        </th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <%#(((RepeaterItem)Container).ItemIndex+1).ToString()%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Date")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Particular")%>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("Amount")%>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody> </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="row">
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
