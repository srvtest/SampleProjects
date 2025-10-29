<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="TempBooking.aspx.cs" Inherits="HotalManagment.TempBooking" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Pre Booking</title>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-content">
        <div class="page-bar">
            <div class="page-title-breadcrumb">
                <div class=" pull-left">
                    <div class="page-title">
                        Pre Booking</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Pre Booking</li>
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
                                <header>Pre Booking</header>
                                <div class="tools">
                                     <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i> New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdPreBookingId" runat="server" Value="0" />
                                    <asp:GridView ID="grdPreBooking" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"
                                        Width="100%" OnRowEditing="grdPreBooking_RowEditing" class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Contact Person">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblContactName" runat="server" Text="<%#Bind('ContactPerson')%>"></asp:Label>
                                                     <asp:HiddenField ID="hdContactNo" runat="server" Value="<%#Bind('ContactNo') %>" />
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="From Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFromDate" runat="server" Text="<%#Bind('FromDate')%>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="To Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblToDate" runat="server" Text="<%#Bind('ToDate')%>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryName" runat="server" Text="<%#Bind('CategoryName')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdCategoryId" runat="server" Value="<%#Bind('CategoryId') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Booking Source">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBookingSource" runat="server" Text="<%#Bind('BookingSourceName')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdBookingSourceId" runat="server" Value="<%#Bind('BookingSourceId') %>" />
                                                    <asp:HiddenField ID="hdBookingId" runat="server" Value="<%#Bind('BookingId') %>" />
                                                    <asp:HiddenField ID="hdNotes" runat="server" Value="<%#Bind('Notes') %>" />
                                                     <asp:HiddenField ID="hdRefNo" runat="server" Value="<%#Bind('RefNo') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("Status").ToString().Equals("1") ? true : false %>'
                                                        Text="Pending" CssClass="label label-info label-mini" />
                                                    <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("Status").ToString().Equals("2") ? true : false  %>'
                                                        Text="Complete" CssClass="label label-warning label-mini" />
                                                        <asp:Label ID="lblStatus2" runat="server" Visible='<%# Eval("Status").ToString().Equals("3") ? true : false  %>'
                                                        Text="Cancel" CssClass="label label-warning label-mini" />
                                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="65px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-primary btn-xs" runat="server" CausesValidation="false"
                                                        CommandName="Edit" Text=""><i class="fa fa-pencil"></i></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
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
                        <header>Add / Update Pre Booking</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtFromDate" runat="server" Style="background: #fff; cursor: pointer;"
                                    class="datepickerFrom mdl-textfield__input txtFromDate"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    From Date</label>
                                <%--<span class="mdl-textfield__error">Enter From Date!</span>--%>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Required"
                                ValidationGroup="G1" ControlToValidate="txtFromDate" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtTodate" runat="server" Style="background: #fff; cursor: pointer"
                                    class="datepickerTo mdl-textfield__input txtTodate"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    To Date</label>
                                <span class="mdl-textfield__error">Enter To Date!</span>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                ValidationGroup="G1" ControlToValidate="txtTodate" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:DropDownList ID="ddCategory" runat="server" CssClass=" ddCategory mdl-textfield__input">
                                </asp:DropDownList>
                                <label class="mdl-textfield__label" for="username">
                                    Category</label>
                                <span class="mdl-textfield__error">Enter Category!</span>
                            </div>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                ValidationGroup="G1" ControlToValidate="ddCategory" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                style="width: 60%!important; float: left;">
                                <asp:DropDownList ID="ddBookingSource" CssClass=" ddCategory mdl-textfield__input"
                                    runat="server">
                                </asp:DropDownList>
                                <label class="mdl-textfield__label" for="username">
                                    Booking Source</label>
                            </div>
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                style="width: 30%!important; float: right;">
                                <asp:TextBox ID="txtrefNo" runat="server" Style="background: #fff;" class="mdl-textfield__input"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Ref. No</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtContactPerson" runat="server" class="mdl-textfield__input" name="password"
                                    MaxLength="50"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Contact Person</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtContactNo" runat="server" class="mdl-textfield__input" name="password"
                                    MaxLength="50"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Contact No</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20" id="Div1" runat="server" clientidmode="Static">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <div class="checkbox checkbox-icon-black">
                                    <asp:DropDownList ID="ddSataus" runat="server" CssClass=" ddCategory mdl-textfield__input">
                                        <asp:ListItem Text="Pending" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Complete" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="Cancel" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label class="mdl-textfield__label" for="rememberChk1">
                                        Booking Status
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="TxtBoonigId" runat="server" class="mdl-textfield__input" name="password"
                                    MaxLength="50"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Booked Room Id</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20" id="status" runat="server" clientidmode="Static" style="display: none;">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <div class="checkbox checkbox-icon-black">
                                    <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                                    <label for="rememberChk1">
                                        Booking Status
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtNotes" runat="server" class="mdl-textfield__input" name="password"
                                    TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Notes</label>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnsave" runat="server" ValidationGroup="G1" Text="Save Category" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                OnClick="btnSave_Click" />
                            <asp:Button ID="btnClose" runat="server" Text="Close" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default grid-show"
                                OnClick="btnClose_Click" />
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
</asp:Content>
