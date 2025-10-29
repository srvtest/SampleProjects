<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="ExpressCheckout.aspx.cs" Inherits="HotalManagment.ExpressCheckout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Express Checkin</title>
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700"
        rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="assets/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <!--bootstrap -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- Material Design Lite CSS -->
    <link rel="stylesheet" href="assets/plugins/material/material.min.css">
    <link rel="stylesheet" href="assets/css/material_style.css">
    <!-- animation -->
    <link href="assets/css/pages/animate_page.css" rel="stylesheet">
    <!-- Template Styles -->
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/theme-color.css" rel="stylesheet" type="text/css" />
    <!-- favicon -->
    <link rel="shortcut icon" href="assets/img/favicon.ico" />
    <link rel="stylesheet" href="assets/plugins/jquery-toast/dist/jquery.toast.min.css">
    <%-- <style type="text/css">
        .task .time
        {
            float: none;
            display: table-cell;
        }
        .task .time .date
        {
            font-size: 17px;
            margin-bottom: 5px;
            font-weight: normal;
        }
        .title
        {
            font-size: 17px;
            margin-bottom: 5px;
            font-weight: normal;
        }
        .task td
        {
            border: 0;
        }
        .task .name
        {
            border-left: 2px solid #FA603D;
        }
        .dataTables_wrapper .row-fluid .span12
        {
            margin-left: 0;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <div class="page-bar">
            <div class="page-title-breadcrumb">
                <div class=" pull-left">
                    <div class="page-title">
                        Express Checkin</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Express Checkin</li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <div id="pnlList" runat="server" class="row" clientidmode="Static">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Express Checkin</header>
                                <div class="tools">
                                    
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdCategoryId" runat="server" Value="0" />
                                    <div class="col-lg-6 p-t-20">
                                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                            <asp:TextBox ID="txtName" runat="server" Style="background: #fff;" class="mdl-textfield__input"
                                                required="required"></asp:TextBox>
                                            <label class="mdl-textfield__label">
                                                Name</label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 p-t-20 text-center">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search by name"       class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                            ValidationGroup="expressSearch" OnClick="btnSearch_Click" />
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="pnlEdit" runat="server" class="row" clientidmode="Static" style="display: none">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Add / Update Express Checkin</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:Repeater ID="RepeaterSearchResult" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-striped bootstrap-datatable datatable">
                                            <thead style="display: none">
                                                <tr>
                                                    <th>
                                                        Name
                                                    </th>
                                                    <th>
                                                        Date
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr class='task high'>
                                            <td class="name">
                                                <div class='title'>
                                                    <asp:LinkButton OnClick="btnName_Click" CommandArgument='<%#Eval("Id") %>' CausesValidation="False"
                                                        ID="btnName" runat="server"><%#Eval("Name") %></asp:LinkButton>
                                                </div>
                                                <div>
                                                    Mobile No:
                                                    <%# !string.IsNullOrEmpty(Convert.ToString(Eval("Mobile")))?Eval("Mobile"):"Not Available" %></div>
                                            </td>
                                            <td class='time'>
                                                <div class='date'>
                                                    <%# Convert.ToDateTime(Eval("ToDate")).ToShortDateString()%></div>
                                                <div>
                                                    <%#Eval("Days")%>
                                                    day(s)</div>
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
            $('.grid-show').click(function () {
                $('#pnlEdit').css('display', 'none');
                $('#pnlList').css('display', 'block');
            });
            $('.form-show').click(function () {
                $('#pnlEdit').css('display', 'block');
                $('#pnlList').css('display', 'none');
                $('#status').css('display', 'none');
            });
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

    </script>
    <%-- <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Express Checkout</a></li>
    </ul>
    <div class="box-content">
        <form class="form-horizontal">
        <div class="row" style="float: right">
            <div class="col-sm-7">
                <div class="form-group">
                    <div class="col-sm-12">
                       
                    </div>
                </div>
            </div>
            <div class="col-sm-5">
               
            </div>
        </div>
        </form>
    </div>
    <div class="row-fluid">
        
    </div>--%>
</asp:Content>
