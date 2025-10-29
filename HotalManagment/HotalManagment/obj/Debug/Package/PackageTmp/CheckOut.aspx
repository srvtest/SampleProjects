<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="CheckOut.aspx.cs" Inherits="HotalManagment.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Checkout</title>
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
                        Check Out</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Check Out</li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdBookingId" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnBookingId" runat="server" Value="0" />
        <asp:HiddenField ID="hdTotal" runat="server" Value="0" />
        <asp:HiddenField ID="hdnTotalPP" runat="server" Value="0" />
        <asp:HiddenField ID="hdBasePrice" runat="server" Value="0" />
        <asp:HiddenField ID="hdExBadChargesEP" runat="server" Value="0" />
        <asp:HiddenField ID="hdExBadChargesCP" runat="server" Value="0" />
        <asp:HiddenField ID="hdExBadChargesMAP" runat="server" Value="0" />
        <asp:HiddenField ID="hdEPCharge" runat="server" Value="0" />
        <asp:HiddenField ID="hdCPCharge" runat="server" Value="0" />
        <asp:HiddenField ID="hdMAPCharge" runat="server" Value="0" />
        <asp:HiddenField ID="hdPresons" runat="server" Value="0" />
        <div class="row" id="pnlList" runat="server" clientidmode="Static">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Room</header>
                                <div class="tools">
                                </div>
                            </div>
                            <div class="card-body row">
                                <div class="col-lg-12 p-t-20">
                                    <div class="form-group">
                                        <label>
                                            Room No.</label>
                                        <asp:DropDownList ID="ddRoomList" runat="server" OnSelectedIndexChanged="ddRoomList_SelectedIndexChanged"
                                            AutoPostBack="true" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="pnlSKey" runat="server" class="row" clientidmode="Static" style="display: none" >
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Authentication</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20" id="Div2" runat="server" clientidmode="Static" >
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <div class="checkbox checkbox-icon-black">
                                     <asp:TextBox ID="txtSKey" runat="server" class="mdl-textfield__input" name="password" TextMode=Password
                                    MaxLength="50"></asp:TextBox>
                                    <label for="rememberChk1">
                                        Authentication key
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnSKey" runat="server" Text="Submit"
                                class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                OnClick="btnsKey_Click" />
                           <asp:Button ID="btnClose" runat="server" Text="Close" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default grid-show"
                                OnClick="btnClose_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row" id="pnlEdit" runat="server" clientidmode="Static" style="display: none">
            <div class="row">
                <div class="col-sm-12">
                    <div class="card-box">
                        <div id="body1" runat="server" class="card-body row" style="display: none">
                            <asp:HiddenField ID="hdGSTPer" runat="server" Value="0" />
                            <asp:HiddenField ID="hdItemAmount" runat="server" Value="0" />
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                    style="width: 60% !important; float: left;">
                                    <asp:TextBox ID="txtCheckinDate" runat="server" Style="background: #fff; cursor: pointer"
                                        class="datepickerCheckin mdl-textfield__input txtCheckinDate"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Checkin Date/Time</label>
                                    <span class="mdl-textfield__error">Enter Checkin Date/Time!</span>
                                </div>
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                    style="width: 30%!important; float: right;">
                                    <asp:TextBox ID="txtCheckinTime" runat="server" Style="background: #fff; cursor: pointer"
                                        class="timepicker10 mdl-textfield__input"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Checkin Time</label>
                                    <span class="mdl-textfield__error">Enter Checkin Time!</span>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtCheckoutTime" runat="server" Style="background: #fff; cursor: pointer"
                                        class="timepicker10 mdl-textfield__input"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Checkout Time</label>
                                    <span class="mdl-textfield__error">Enter Checkout Time!</span>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:DropDownList ID="ddCategory" runat="server" CssClass=" ddCategory mdl-textfield__input">
                                    </asp:DropDownList>
                                    <label class="mdl-textfield__label" for="username">
                                        Category</label>
                                    <span class="mdl-textfield__error">Enter Category!</span>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:DropDownList ID="ddRoomNo" CssClass="mdl-textfield__input ddRoomNo" runat="server">
                                    </asp:DropDownList>
                                    <label class="mdl-textfield__label" for="username">
                                        Room No</label>
                                    <span class="mdl-textfield__error">Enter Room No!</span>
                                </div>
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                    style="width: 30%!important; float: right;">
                                    <asp:DropDownList ID="ddRoomPlan" runat="server" CssClass=" ddCategory mdl-textfield__input">
                                    </asp:DropDownList>
                                    <label class="mdl-textfield__label" for="username">
                                        Room Plan</label>
                                </div>
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                    style="width: 30%!important; float: right;">
                                    <asp:DropDownList ID="ddExtrabad" runat="server" CssClass=" ddCategory mdl-textfield__input">
                                        <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    </asp:DropDownList>
                                    <label class="mdl-textfield__label" for="username">
                                        Extra Bad</label>
                                </div>
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                    style="width: 30%!important; float: right;">
                                    <asp:TextBox ID="txtExtrabadCharges" runat="server" CssClass="mdl-textfield__input"
                                        type="number" AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Exrea Bad Charges</label>
                                    <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                        ErrorMessage="Required" ControlToValidate="txtRoomCharges" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:DropDownList ID="ddBookingStatus" CssClass="mdl-textfield__input" runat="server">
                                    </asp:DropDownList>
                                    <label class="mdl-textfield__label" for="username">
                                        Booking Status</label>
                                    <span class="mdl-textfield__error">Enter Booking Status!</span>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                    style="width: 60%!important; float: left;">
                                    <asp:DropDownList ID="ddBookingSource" CssClass=" ddCategory mdl-textfield__input"
                                        runat="server">
                                    </asp:DropDownList>
                                    <label class="mdl-textfield__label" for="username">
                                        Booking Source</label>
                                    <span class="mdl-textfield__error">Enter Room No!</span>
                                </div>
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                    style="width: 30%!important; float: right;">
                                    <asp:TextBox ID="txtBookingSourceId" runat="server" Style="background: #fff;" class="mdl-textfield__input"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Booking Source</label>
                                    <span class="mdl-textfield__error">Enter Room No!</span>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtRoomCharges" runat="server" CssClass="mdl-textfield__input" type="number"
                                        AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Room Charges</label>
                                    <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                        ErrorMessage="Required" ControlToValidate="txtRoomCharges" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtTax" runat="server" CssClass="mdl-textfield__input" type="number"
                                        ReadOnly="true"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Tax</label>
                                    <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtArrivalFrom" runat="server" Style="background: #fff; cursor: pointer"
                                        class="mdl-textfield__input"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Arrival from</label>
                                    <%--<span class="mdl-textfield__error">Enter Arrival from!</span>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="0" runat="server"
                                        ForeColor="Red" ErrorMessage="Required" ControlToValidate="txtArrivalFrom" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtDepartureTo" runat="server" Style="background: #fff; cursor: pointer"
                                        class="mdl-textfield__input"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Departure to</label>
                                    <%--<span class="mdl-textfield__error">Enter Departure to!</span>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server"
                                        ForeColor="Red" ErrorMessage="Required" ControlToValidate="txtDepartureTo" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtAdvance" runat="server" CssClass="mdl-textfield__input" type="number"
                                        AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Advance</label>
                                    <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                </div>
                            </div>
                        </div>
                        <div id="Head4" runat="server" class="card-head">
                            <header>Payment</header>
                            <div class="tools">
                                <asp:LinkButton ID="lnkCheckout" runat="server" OnClick="btnSubmit_Click"><i class="fa fa-shopping-cart"></i> Checkout</asp:LinkButton>
                            </div>
                        </div>
                        <div id="body4" runat="server" class="card-body row">
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtFromDate" runat="server" Style="background: #fff; cursor: pointer;"
                                        class="datepickerFrom mdl-textfield__input txtFromDate" ReadOnly="true"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        From Date</label>
                                    <%--<span class="mdl-textfield__error">Enter From Date!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtTodate" runat="server" Style="background: #fff; cursor: pointer"
                                        class="datepickerTo mdl-textfield__input txtTodate" ></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        To Date</label>
                                    <span class="mdl-textfield__error">Enter To Date!</span>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtEarlyCheckin" runat="server" class="mdl-textfield__input" type="number"
                                        AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Early Checkin Charges</label>
                                    <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtLateCheckout" runat="server" class="mdl-textfield__input" type="number"
                                        AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Late Checkout Charges</label>
                                    <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtAdjust" runat="server" class="mdl-textfield__input" type="number"
                                        AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Adjustments</label>
                                    <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-6 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtDiscount" runat="server" class="mdl-textfield__input" type="number"
                                        placeholder="Discounts" AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Discount in Rs.</label>
                                    <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-3 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtNetTotal" runat="server" class="mdl-textfield__input" type="number"
                                        ReadOnly="true"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Total Amount</label>
                                </div>
                            </div>
                            <div class="col-lg-3 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtPaidAmount" runat="server" class="mdl-textfield__input" type="number"
                                        ReadOnly="true"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Paid Amount</label>
                                </div>
                            </div>
                            <div class="col-lg-3 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    Due Amount : <asp:Label ID="lblDueAmount" runat="server" Text="0"></asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-3 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtDueAmount" runat="server" class="mdl-textfield__input" type="number"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Amount Received</label>
                                    <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-3 p-t-20" style="display: none;">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtTotalPay" runat="server" class="mdl-textfield__input" type="number"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Total</label>
                                    <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-3 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtPayment" runat="server" class="mdl-textfield__input" type="number"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Payment Amount</label>
                                    <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-7 p-t-20">
                                <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                    <asp:TextBox ID="txtDescription" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                    <label class="mdl-textfield__label" for="username">
                                        Description</label>
                                    <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                </div>
                            </div>
                            <div class="col-lg-2" style="padding-top: 30px">
                                <asp:Button ID="btnPartialPay" CssClass="btn btn-md btn-primary" runat="server" OnClick="btnPartialPay_OnClick"
                                    Text="Partial Payment" />
                            </div>
                        </div>
                        <div id="Head3" runat="server" class="card-head">
                            <header>Account Information</header>
                        </div>
                        <div id="body3" runat="server" class="card-body row">
                            <div id="IdRoomDetail" runat="server" class="col-md-12">
                                <div class="card card-topline-red">
                                    <div class="card-head">
                                        <header>Room Rent</header>
                                    </div>
                                    <div class="card-body ">
                                        <div class="table-scrollable">
                                            <table class="table table-striped table-hover">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            #
                                                        </th>
                                                        <th>
                                                            No Of Days
                                                        </th>
                                                        <th>
                                                            Plan
                                                        </th>
                                                        <th>
                                                            Room Charge
                                                        </th>
                                                        <th>
                                                            No Of persons
                                                        </th>
                                                        <th>
                                                            Tax
                                                        </th>
                                                        <th>
                                                            Total
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            1
                                                        </td>
                                                        <td>
                                                            <span id="lblNoOfDays" runat="server" class="number"></span>
                                                        </td>
                                                        <td>
                                                            <span id="lblPlanName" runat="server" class="number"></span>
                                                        </td>
                                                        <td>
                                                            <span id="lblRoomCharge" runat="server" class="number"></span>
                                                        </td>
                                                        <td>
                                                            <span id="lblNoofPersons" runat="server" class="number"></span>
                                                        </td>
                                                        <td>
                                                            <span id="lblTax" runat="server" class="number"></span>
                                                        </td>
                                                        <td>
                                                            <span id="lblTotal" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                    <tr id="idExBadCharges" runat="server" visible="false">
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Extra Bad Charges (+)</b>
                                                        </td>
                                                        <td>
                                                            <span id="idExBadChargesAmt" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                    <tr id="idEcharges" runat="server" visible="false">
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Early Chaeckin Charges (+)</b>
                                                        </td>
                                                        <td>
                                                            <span id="lblEcharges" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                    <tr id="idLcharges" runat="server" visible="false">
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Late Checkout Charges (+)</b>
                                                        </td>
                                                        <td>
                                                            <span id="lblLCharges" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                    <tr id="idAdjestment" runat="server" visible="false">
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Adjestment (-)</b>
                                                        </td>
                                                        <td>
                                                            <span id="lblAdjestmentCharge" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Advance (-)</b>
                                                        </td>
                                                        <td>
                                                            <span id="lblAdvance" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Discount (-)</b>
                                                        </td>
                                                        <td>
                                                            <span id="lblDiscount" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Grand Total</b>
                                                        </td>
                                                        <td>
                                                            <span id="lblGrandTotal" runat="server" class="number"></span>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="IdItemsDetail" runat="server" class="col-md-12">
                                <div class="card card-topline-red">
                                    <div class="card-head">
                                        <header>Order items and Services</header>
                                    </div>
                                    <div class="card-body ">
                                        <div class="table-scrollable">
                                            <asp:Repeater ID="RepterDetails" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-striped table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    #
                                                                </th>
                                                                <th>
                                                                    Particular
                                                                </th>
                                                                <th>
                                                                    Rate
                                                                </th>
                                                                <th>
                                                                    Quantity
                                                                </th>
                                                                <th>
                                                                    GST
                                                                </th>
                                                                <th>
                                                                    Ordered
                                                                </th>
                                                                <th>
                                                                    Delivered
                                                                </th>
                                                                <th>
                                                                    Total Amount
                                                                </th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <%#Container.ItemIndex + 1 %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("Itemname") %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("Price") %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("Quantity") %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("Tax") %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("CreationDate") %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("ModificationDate") %>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblitemAmount" runat="server" Text='<%# ((decimal)Eval("Price") * (decimal)Eval("Quantity")) + (decimal)Eval("Tax")%>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <b>Grand Total</b>
                                                        </td>
                                                        <td>
                                                            <%#totalAmount()%>
                                                        </td>
                                                    </tr>
                                                    </tbody> </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="IdPaymentDetail" runat="server" class="col-md-12">
                                <div class="card card-topline-red">
                                    <div class="card-head">
                                        <header>Payment Details</header>
                                    </div>
                                    <div class="card-body ">
                                        <div class="table-scrollable">
                                            <asp:Repeater ID="repeterPayment" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-striped table-hover">
                                                        <thead>
                                                            <tr>
                                                                <th>
                                                                    #
                                                                </th>
                                                                <th>
                                                                    Payment Date
                                                                </th>
                                                                <th>
                                                                    Description
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
                                                            <%#Container.ItemIndex + 1 %>
                                                        </td>
                                                        <td>
                                                            <%#Eval("CreationDate")%>
                                                        </td>
                                                        <td>
                                                            <%#Eval("Description")%>
                                                        </td>
                                                        <td>
                                                            <%#Eval("Amount") %>
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
                $('.mdl-textfield__input').val('');
                $('#pnlEdit').css('display', 'block');
                $('#pnlList').css('display', 'none');
                $('#status').css('display', 'none');
            });

            $(document).on("wheel", "input[type=number]", function (e) {
                $(this).blur();
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
