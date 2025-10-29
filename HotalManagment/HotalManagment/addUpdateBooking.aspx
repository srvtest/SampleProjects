<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="addUpdateBooking.aspx.cs" Inherits="HotalManagment.addUpdateBooking"
    MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .col-lg-6 {
            float: left;
        }

        .wizard > .steps > ul > li {
            width: auto;
        }

        .ddHeight {
            height: 36px;
        }
    </style>
    <title>Room Booking</title>
    <!-- THIS LINE -->
    <link href="Styles/timepicki.css" rel="stylesheet" type="text/css" />
    <!-- favicon -->
    <link rel="shortcut icon" href="assets/img/favicon.ico" />
    <link rel="stylesheet" href="assets/plugins/jquery-toast/dist/jquery.toast.min.css">
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
                        Booking
                    </div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li><a class="parent-item" href="#">Booking</a>&nbsp;<i class="fa fa-angle-right"></i>
                    </li>
                </ol>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField ID="hdnBookingId" runat="server" Value="0" />
        <asp:HiddenField ID="hdTotal" runat="server" Value="0" />
        <asp:HiddenField ID="hdCalcAmount" runat="server" Value="0" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <!-- basic wizard -->
        <div class="row">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Booking Wizard</header>
                    </div>
                    <div class="card-body row">
                        <div class="wizard clearfix">
                            <div class="steps clearfix">
                                <ul>
                                    <li id="li1" runat="server" class="done" style="width: auto">
                                        <asp:LinkButton ID="lnkpage1" runat="server" OnClick="lnkpage1_Click"><span class="number">1.</span>Booking Information</asp:LinkButton>
                                    </li>
                                    <li id="li2" runat="server" class="done">
                                        <asp:LinkButton ID="lnkpage2" runat="server" OnClick="lnkpage2_Click"><span class="number">2.</span>Profile Information</asp:LinkButton>
                                    </li>
                                    <li id="li3" runat="server" class="done" style="display: none;">
                                        <asp:LinkButton ID="lnkpage3" runat="server" OnClick="lnkpage3_Click"><span class="number">3.</span>Account Information</asp:LinkButton>
                                    </li>
                                    <li id="li4" runat="server" class="done pull-right">
                                        <asp:LinkButton ID="LinkButton1" runat="server" Style="background-color: rgba(158, 33, 33, 0.6);"
                                            OnClick="btnSubmit_Click">Submit</asp:LinkButton>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div id="Head1" runat="server" class="card-head">
                        <header>Booking Information</header>
                    </div>
                    <div id="body1" runat="server" class="card-body row">
                        <asp:HiddenField ID="hdGSTPer" runat="server" Value="0" />
                        <asp:HiddenField ID="hdItemAmount" runat="server" Value="0" />
                        <asp:HiddenField ID="hdBasePrice" runat="server" Value="0" />
                        <asp:HiddenField ID="hdExBadChargesEP" runat="server" Value="0" />
                        <asp:HiddenField ID="hdExBadChargesCP" runat="server" Value="0" />
                        <asp:HiddenField ID="hdExBadChargesMAP" runat="server" Value="0" />
                        <asp:HiddenField ID="hdEPCharge" runat="server" Value="0" />
                        <asp:HiddenField ID="hdCPCharge" runat="server" Value="0" />
                        <asp:HiddenField ID="hdMAPCharge" runat="server" Value="0" />
                        <asp:HiddenField ID="hdPresons" runat="server" Value="0" />
                        <asp:HiddenField ID="hdRoomCharges" runat="server" Value="0" />
                        <asp:HiddenField ID="hdMultipleBookingDetail" runat="server" Value="" />
                        <asp:HiddenField ID="hdMultipleBookingDetail_all" runat="server" Value="" />
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtBookingDate" runat="server" Style="background: #fff; cursor: pointer;"
                                    ReadOnly="true" class="mdl-textfield__input txtFromDate"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Booking Date</label>
                                <%--<span class="mdl-textfield__error">Enter From Date!</span>--%>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                style="width: 30%!important; float: left;">
                                <div class="checkbox checkbox-icon-black">
                                    <asp:CheckBox ID="chkCheckedIn" runat="server" ToolTip="Status" />
                                    <label for="rememberChk1">
                                        Checked In
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width  is-dirty">
                                <asp:TextBox ID="txtFromDate" runat="server" Style="background: #fff; cursor: pointer;" ViewStateMode="Enabled"
                                    class="datepickerFrom mdl-textfield__input txtFromDate" ClientIDMode="Static"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    From Date</label>
                                <%--<span class="mdl-textfield__error">Enter From Date!</span>--%>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width  is-dirty">
                                <asp:TextBox ID="txtTodate" runat="server" Style="background: #fff; cursor: pointer" ViewStateMode="Enabled"
                                    ClientIDMode="Static" class="datepickerTo mdl-textfield__input txtTodate" OnTextChanged="txtTodate_TextChanged"
                                    AutoPostBack="true"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    To Date</label>
                                <span class="mdl-textfield__error">Enter To Date!</span>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                style="width: 60% !important; float: left;">
                                <asp:TextBox ID="txtCheckinDate" runat="server" Style="background: #fff; cursor: pointer" ViewStateMode="Enabled"
                                    ClientIDMode="Static" class="datepickerCheckin mdl-textfield__input txtCheckinDate"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Checkin Date/Time</label>
                                <span class="mdl-textfield__error">Enter Checkin Date/Time!</span>
                            </div>
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                style="width: 30%!important; float: right;">
                                <asp:TextBox ID="txtCheckinTime" runat="server" Style="background: #fff; cursor: pointer" ViewStateMode="Enabled"
                                    ClientIDMode="Static" class="timepicker10 mdl-textfield__input"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Checkin Time</label>
                                <span class="mdl-textfield__error">Enter Checkin Time!</span>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtExCheckoutTime" runat="server" Style="background: #fff; cursor: pointer" ViewStateMode="Enabled"
                                    ClientIDMode="Static" class="timepicker10 mdl-textfield__input"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Exepected Checkout Time</label>
                                <span class="mdl-textfield__error">Enter Checkout Time!</span>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 60% !important; float: left;">
                                        <asp:DropDownList ID="ddCategory" runat="server" CssClass=" ddCategory mdl-textfield__input ddHeight"
                                            ClientIDMode="Static" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged" ViewStateMode="Enabled"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <label class="mdl-textfield__label" for="username">
                                            Category</label>
                                        <span class="mdl-textfield__error">Enter Category!</span>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30%!important; float: right;">
                                        <asp:DropDownList ID="ddRoomPlan" runat="server" CssClass=" ddCategory mdl-textfield__input ddHeight"
                                            ClientIDMode="Static" OnSelectedIndexChanged="ddRoomPlan_SelectedIndexChanged" ViewStateMode="Enabled"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <label class="mdl-textfield__label" for="username">
                                            Room Plan</label>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30% !important; float: left;">
                                        <asp:DropDownList ID="ddRoomNo" CssClass="mdl-textfield__input ddRoomNo ddHeight"
                                            ClientIDMode="Static" runat="server" OnSelectedIndexChanged="ddRoomNo_SelectedIndexChanged" ViewStateMode="Enabled"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                        <input id="iChangeRoom" type="button" class="mybutton btn btn-primary" onclick="showModal()" value="Change Room" style="display:none;" />
                                        <label class="mdl-textfield__label" for="username">
                                            Room No</label>
                                        <span class="mdl-textfield__error">Enter Room No!</span>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30% !important; float: left;">
                                        <asp:TextBox ID="txtNoOfPerson" runat="server" CssClass="mdl-textfield__input" type="number" ViewStateMode="Enabled"
                                            ClientIDMode="Static"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            No Of Person</label>
                                        <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30%!important; float: right;">
                                        <asp:DropDownList ID="ddExtrabad" runat="server" CssClass=" ddCategory mdl-textfield__input ddHeight" ViewStateMode="Enabled"
                                            ClientIDMode="Static" OnSelectedIndexChanged="ddRoomPlan_SelectedIndexChanged"
                                            AutoPostBack="true">
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
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:Panel ID="pnlRoom" runat="server">
                                                </asp:Panel>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <label class="mdl-textfield__label" for="username">
                                            Rooms:</label>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 50%!important; float: left;">
                                        <asp:DropDownList ID="ddBookingStatus" CssClass="mdl-textfield__input" runat="server" ViewStateMode="Enabled"
                                            ClientIDMode="Static">
                                        </asp:DropDownList>
                                        <label class="mdl-textfield__label" for="username">
                                            Booking Status</label>
                                        <span class="mdl-textfield__error">Enter Booking Status!</span>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 40%!important; float: right;">
                                        <asp:DropDownList ID="ddBookingSource" CssClass=" ddCategory mdl-textfield__input" ViewStateMode="Enabled"
                                            ClientIDMode="Static" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddBookingSource_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <label class="mdl-textfield__label" for="username">
                                            Booking Source</label>
                                        <span class="mdl-textfield__error">Enter Room No!</span>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 60%!important; float: left;">
                                        <asp:TextBox ID="txtBookingSourceId" runat="server" Style="background: #fff;" class="mdl-textfield__input"
                                            ViewStateMode="Enabled" ClientIDMode="Static"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Booking Source</label>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30%!important; float: right;">
                                        <asp:TextBox ID="txtcommission" runat="server" Style="background: #fff;" class="mdl-textfield__input"
                                            ViewStateMode="Enabled" ClientIDMode="Static" type="number"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Charge</label>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width" id="roomcharges" runat="server"
                                        style="width: 40%!important; float: left;">
                                        <label class="">
                                            Room Charges:
                                            <asp:Label ID="baseRoomCharges" runat="server"></asp:Label>
                                        </label>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 60%!important; float: left;">
                                        <asp:TextBox ID="txtRoomCharges" runat="server" CssClass="mdl-textfield__input" type="number"
                                            ViewStateMode="Enabled" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Room Charges</label>
                                        <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                            ErrorMessage="Required" ControlToValidate="txtRoomCharges" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                        style="width: 30%!important; float: left;">
                                        <div class="checkbox checkbox-icon-black">
                                            <asp:CheckBox ID="chkInclusive" runat="server" ToolTip="Status" AutoPostBack="true"
                                                ViewStateMode="Enabled" ClientIDMode="Static" OnCheckedChanged="chkInclusive_CheckedChanged" />
                                            <label for="rememberChk1">
                                                Inclusive Tax
                                            </label>
                                        </div>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30%!important; float: left;">
                                        <asp:TextBox ID="txtTax" runat="server" CssClass="mdl-textfield__input" type="number"
                                            ViewStateMode="Enabled" ClientIDMode="Static" ReadOnly="true"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Tax</label>
                                        <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                    </div>
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty"
                                        style="width: 30%!important; float: right;">
                                        <asp:TextBox ID="txtExtrabadCharges" runat="server" CssClass="mdl-textfield__input"
                                            ViewStateMode="Enabled" ClientIDMode="Static" type="number" AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Extra Bad Charges</label>
                                        <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                            ErrorMessage="Required" ControlToValidate="txtRoomCharges" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty">
                                        <asp:TextBox ID="txtArrivalFrom" runat="server" Style="background: #fff; cursor: pointer"
                                            ViewStateMode="Enabled" ClientIDMode="Static" class="mdl-textfield__input"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Arrival from</label>
                                        <%--<span class="mdl-textfield__error">Enter Arrival from!</span>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="0" runat="server"
                                            ForeColor="Red" ErrorMessage="Required" ControlToValidate="txtArrivalFrom" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty">
                                        <asp:TextBox ID="txtDepartureTo" runat="server" Style="background: #fff; cursor: pointer"
                                            ViewStateMode="Enabled" ClientIDMode="Static" class="mdl-textfield__input"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Departure to</label>
                                        <%--<span class="mdl-textfield__error">Enter Departure to!</span>--%>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server"
                                            ForeColor="Red" ErrorMessage="Required" ControlToValidate="txtDepartureTo" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20" id="dvAdvance">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty">
                                        <asp:TextBox ID="txtAdvance" runat="server" CssClass="mdl-textfield__input" type="number"
                                            ViewStateMode="Enabled" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Advance</label>
                                        <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty">
                                        <asp:TextBox ID="txtEarlyCheckin" runat="server" class="mdl-textfield__input" type="number"
                                            ViewStateMode="Enabled" ClientIDMode="Static" AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Early Checkin Charges</label>
                                        <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty">
                                        <asp:TextBox ID="txtDiscount" runat="server" class="mdl-textfield__input" type="number"
                                            ViewStateMode="Enabled" ClientIDMode="Static" placeholder="Discounts" AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Discounts in Rs.</label>
                                        <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width is-dirty">
                                        <asp:TextBox ID="txtSpRequest" runat="server" class="mdl-textfield__input" TextMode="MultiLine"
                                            ViewStateMode="Enabled" ClientIDMode="Static"></asp:TextBox>
                                        <label class="mdl-textfield__label" for="username">
                                            Special Request</label>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                        style="width: 40%!important; float: left;">
                                        <label class="">
                                            Total :
                                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                                        </label>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div id="Head2" runat="server" class="card-head">
                        <header>Profile Information</header>
                    </div>
                    <div id="body2" runat="server" class="card-body row">
                        <asp:HiddenField ID="hdnContactIdForDocument" runat="server" />
                        <asp:GridView ID="grdContactInfo" runat="server" ClientIDMode="Static" AutoGenerateColumns="False"
                            class="table" Width="100%" OnRowEditing="grdContactInfo_RowEditing" OnRowDeleting="grdContactInfo_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No." HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSerialNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="First Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFirstName" runat="server" Text="<%#Bind('FirstName')%>"></asp:Label>
                                        <asp:HiddenField ID="hdnContactId" runat="server" Value="<%#Bind('ContactId') %>" />
                                        <asp:HiddenField ID="hdGstno" runat="server" Value="<%#Bind('GSTno') %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Last Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLastName" runat="server" Text="<%#Bind('LastName') %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Age">
                                    <ItemTemplate>
                                        <asp:Label ID="lblAge" runat="server" Text="<%#Bind('Age') %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Gender">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGender" runat="server" Text="<%#Bind('Gender') %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Email">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEmail" runat="server" Text="<%#Bind('EmailId') %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Mobile">
                                    <ItemTemplate>
                                        <asp:Label ID="lblMobile" runat="server" Text='<%# (Eval("MobileNo") == DBNull.Value && Eval("MobileNo").ToString().Equals("0"))?"Not Available":Eval("MobileNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Photo" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:Image ID="imgCustomer" Height="30" Width="30" runat="server" ImageUrl='<%# "Cust_Photos/"+Eval("CustomerPhoto") %>'
                                            AlternateText="Image" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("bIsActive").ToString().Equals("True") ? true : false %>'
                                            Text='<%# Eval("bIsActive").ToString().Equals("True") ? "Active" : "" %>' CssClass="label label-info label-mini" />
                                        <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("bIsActive").ToString().Equals("True") ? false :true   %>'
                                            Text='<%# Eval("bIsActive").ToString().Equals("True") ? "" : "Inactive" %>' CssClass="label label-warning label-mini" />
                                        <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('IsActive') %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnEdit" CssClass="btn btn-primary btn-xs" runat="server" CausesValidation="false"
                                            CommandName="Edit" Text=""><i class="fa fa-pencil"></i></asp:LinkButton>
                                        <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger btn-xs" runat="server" CausesValidation="false"
                                            CommandName="Delete" Text=""><i class="white icon-trash"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtFirstName" runat="server" class="mdl-textfield__input" type="text"
                                    pattern="([a-zA-Z]{3,30}\s*)+"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    First Name</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtFirstName" Display="Dynamic" ValidationGroup="contact"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter First Name"
                                    Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z\s]*" ControlToValidate="txtFirstName"
                                    ValidationGroup="contact">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtLastName" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Last Name</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtLastName" Display="Dynamic" ValidationGroup="contact"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Enter Last Name"
                                    Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z\s]*" ControlToValidate="txtLastName"
                                    ValidationGroup="contact">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <label for="optionsRadios1">
                                Gender
                            </label>
                            <div class="radio p-0">
                                <asp:RadioButtonList ID="rbtGender" RepeatDirection="Horizontal" runat="server">
                                    <asp:ListItem Value="M"><span>Male</span></asp:ListItem>
                                    <asp:ListItem Value="F"><span>FeMale</span></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtAge" runat="server" class="mdl-textfield__input" TextMode="Number"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Age</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtAge" Display="Dynamic" ValidationGroup="contact"></asp:RequiredFieldValidator>--%>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Enter Age Between 18-125 "
                                    ControlToValidate="txtAge" ValidationGroup="contact" MinimumValue="18" MaximumValue="125"
                                    Type="Integer" ForeColor="Red">
                                </asp:RangeValidator>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtEmail" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Email Address</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtEmail" Display="Dynamic" ValidationGroup="contact"></asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Enter Valid Email Address "
                                    Display="Dynamic" ForeColor="Red" ValidationExpression="^[A-Za-z0-9]+([\._]?[A-Za-z0-9]+)*@\w+(\.\w{2,3})+$"
                                    ControlToValidate="txtEmail" ValidationGroup="contact">
                                </asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtMobile" runat="server" class="mdl-textfield__input" MaxLength="10"
                                    TextMode="Number"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Mobile NO.</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ControlToValidate="txtMobile" ValidationGroup="contact" ForeColor="Red">
                                 </asp:RequiredFieldValidator>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Valid Mobile Number."
                                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtMobile" ValidationGroup="contact"
                                    ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <label class="mdl-textfield__label" for="username">
                                    Photo</label>
                                <asp:HiddenField ID="hdnCustomerPhoto" runat="server" />
                                <asp:FileUpload ID="fileUploadPhotos" runat="server" CssClass="wizard btn btn-info" />
                                <asp:Image ID="Image1" runat="server" Height="50" Width="50" AlternateText="Customer Image"
                                    ImageUrl="~/Cust_Photos/NoImage.png" CssClass="imgCustomer img-rounded marginTop"
                                    Style="background-image: url(~/Cust_Photos/NoImage.png);" />
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <label class="mdl-textfield__label" for="username">
                                    Documents</label>
                                <asp:FileUpload ID="fileUploadDocuments" Multiple="multiple" CssClass="wizard btn btn-info"
                                    runat="server" />
                                <asp:TextBox ID="txtDocNo" runat="server" class="form-control" placeholder="Document No"></asp:TextBox>
                                <asp:GridView ID="grdDocumentList" CssClass="marginTop" Style="overflow-y: auto; max-height: 178px"
                                    runat="server" BorderStyle="None" CellPadding="5" ShowHeader="False"
                                    OnRowDeleting="grdDocumentList_RowDeleting" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/img/delete-16.png" CommandName="Delete" />
                                        <asp:TemplateField HeaderText="Document Name">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnId" Value="<%#Bind('Id') %>" runat="server" />
                                                <asp:HiddenField ID="hdnUID" Value="<%#Bind('DocumentUID') %>" runat="server" />
                                                <asp:Label ID="lblDocumentName" Style="padding: 3px" runat="server" Text="<%#Bind('DocumentName') %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtGSTno" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    GST No.</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Enter Valid GST Number."
                                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtGSTno" ValidationGroup="contact"
                                    ValidationExpression="([0][1-9]|[1-2][0-9]|[3][0-5])([a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}[1-9a-zA-Z]{1}[zZ]{1}[0-9a-zA-Z]{1})"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <asp:Button ID="btnAddContact" runat="server" Text="Add Guest" CssClass="btn btn-primary"
                                Style="float: right; margin-right: 10px" OnClick="btnAddContact_Click" ValidationGroup="contact" />
                        </div>
                    </div>
                    <div id="Head4" runat="server" class="card-head">
                        <header>Payment</header>
                    </div>
                    <div id="body4" runat="server" class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtLateCheckout" runat="server" class="mdl-textfield__input" type="number"
                                    AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Late Checkout Chages</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtAdjust" runat="server" class="mdl-textfield__input" type="number"
                                    AutoPostBack="True" OnTextChanged="txtCalculation"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Adjustment</label>
                                <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
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
                                <asp:TextBox ID="txtDueAmount" runat="server" class="mdl-textfield__input" type="number"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Due Amount</label>
                                <%--<span class="mdl-textfield__error">Enter Room Charges!</span>--%>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtTotalPay" runat="server" class="mdl-textfield__input" type="number"></asp:TextBox>
                                <label class="mdl-textfield__label" for="username">
                                    Total</label>
                                <%--<span class="mdl-textfield__error">Enter Tax!</span>--%>
                            </div>
                        </div>
                    </div>
                    <div id="Head3" runat="server" class="card-head">
                        <header>Account Information</header>
                    </div>
                    <div id="body3" runat="server" class="card-body row">
                        <div class="col-md-12">
                            <div class="card card-topline-red">
                                <div class="card-head">
                                    <header>Room Rent</header>
                                </div>
                                <div class="card-body ">
                                    <div class="table-scrollable">
                                        <table class="table table-striped table-hover">
                                            <thead>
                                                <tr>
                                                    <th>#
                                                    </th>
                                                    <th>No Of Days
                                                    </th>
                                                    <th>Room Charge
                                                    </th>
                                                    <th>Tax
                                                    </th>
                                                    <th>Total
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>1
                                                    </td>
                                                    <td>
                                                        <span id="lblNoOfDays" runat="server" class="number"></span>
                                                    </td>
                                                    <td>
                                                        <span id="lblRoomCharge" runat="server" class="number"></span>
                                                    </td>
                                                    <td>
                                                        <span id="lblTax" runat="server" class="number"></span><span id="lblEarlyCheckinCharges"
                                                            runat="server" class="number"></span>
                                                    </td>
                                                    <td>
                                                        <span id="lblExtraBad" runat="server" class="number"></span>
                                                    </td>
                                                    <td>
                                                        <span id="lblTotal" runat="server" class="number"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <b>Advance</b>
                                                    </td>
                                                    <td>
                                                        <span id="lblAdvance" runat="server" class="number"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td>
                                                        <b>Discount</b>
                                                    </td>
                                                    <td>
                                                        <span id="lblDiscount" runat="server" class="number"></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
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
                        <div class="col-md-12">
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
                                                            <th>#
                                                            </th>
                                                            <th>Particular
                                                            </th>
                                                            <th>Rate
                                                            </th>
                                                            <th>Quantity
                                                            </th>
                                                            <th>GST
                                                            </th>
                                                            <th>Ordered
                                                            </th>
                                                            <th>Delivered
                                                            </th>
                                                            <th>Total Amount
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
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="exampleModalLabel">Change Room</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    
                </div>
                <div class="modal-body">
                    Room : 
                    <asp:DropDownList ID="ddChangeRoom" CssClass="mdl-textfield__input ddRoomNo ddHeight"
                        ClientIDMode="Static" runat="server" ViewStateMode="Enabled" >
                    </asp:DropDownList>
                    <asp:Button ID="btnChangeRoom" runat="server" Text="Change Room" OnClick="btnChangeRoom_Click" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- notifications -->
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


            var bsId = $('#txtBookingSourceId');

            if (length(bsId.val()) > 0) {
                DisableControls();
            }

            $(document).on("wheel", "input[type=number]", function (e) {
                $(this).blur();
            });

            function UpdateImg(input) {
                if (input.files && input.files[0]) {
                    var reader = new FileReader();
                    reader.onload = function (e) { $('.imgCustomer').attr('src', e.target.result); }
                    reader.readAsDataURL(input.files[0]);
                } else {
                    $('.imgCustomer').attr('src', '');
                }
            } $(".imgUpload").change(function () { UpdateImg(this); });
        }); </script>
    <script type="text/javascript">
        function showModal() {
            $('#myModal').modal('show');
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

        function DisableControls() {
            // alert('aaa');
            $('#txtFromDate').addClass('is-disabled');
            $("#txtFromDate").attr("readonly", "readonly");
            $('#txtFromDate').removeClass('datepickerFrom');


            $('#txtTodate').addClass('is-disabled');
            $("#txtTodate").attr("readonly", "readonly");
            $('#txtTodate').removeClass('datepickerTo');

            $("#txtCheckinDate").attr("readonly", "readonly");
            $("#txtCheckinDate").addClass("is-disabled");

            $("#txtCheckinTime").attr("readonly", "readonly");
            $("#txtCheckinTime").addClass("is-disabled");

            $("#txtBookingDate").attr("readonly", "readonly");
            $("#txtBookingDate").addClass("is-disabled");

            $("#txtDiscount").attr("readonly", "readonly");
            $("#txtDiscount").addClass("is-disabled");

            $("#txtAdjust").attr("readonly", "readonly");
            $("#txtAdjust").addClass("is-disabled");

            $("#txtAdvance").attr("readonly", "readonly");
            $("#txtAdvance").addClass("is-disabled");

            $("#txtLateCheckout").attr("readonly", "readonly");
            $("#txtLateCheckout").addClass("is-disabled");

            $("#txtEarlyCheckin").attr("readonly", "readonly");
            $("#txtEarlyCheckin").addClass("is-disabled");

            $("#chkInclusive").attr("readonly", "readonly");

            $("#txtNoOfPerson").attr("readonly", "readonly");
            $("#txtNoOfPerson").addClass("is-disabled");

            $("#ddRoomPlan").attr("readonly", "readonly");
            $("#ddRoomPlan").addClass("is-disabled");

            $("#ddExtrabad").attr("readonly", "readonly");
            $("#ddExtrabad").addClass("is-disabled");

            $("#ddBookingStatus").attr("readonly", "readonly");
            $("#ddBookingStatus").addClass("is-disabled");

            $("#ddBookingSource").attr("readonly", "readonly");
            $("#ddBookingSource").addClass("is-disabled");

            $("#txtBookingSourceId").attr("readonly", "readonly");
            $("#txtBookingSourceId").addClass("is-disabled");

            $("#txtcommission").attr("readonly", "readonly");
            $("#txtcommission").addClass("is-disabled");

            $("#txtRoomCharges").attr("readonly", "readonly");
            $("#txtRoomCharges").addClass("is-disabled");

            $("#txtTax").attr("readonly", "readonly");
            $("#txtTax").addClass("is-disabled");

            $("#txtExtrabadCharges").attr("readonly", "readonly");
            $("#txtExtrabadCharges").addClass("is-disabled");


            document.getElementById("dvAdvance").style.display = "none";
            
            document.getElementById("iChangeRoom").style.display = "block";


        }

    </script>
</asp:Content>
