<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="BookingItemDetail.aspx.cs" Inherits="HotalManagment.BookingItemDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Booking Items(POS)</title>
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
                        Booking Items</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Booking Items </li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdBookingId" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
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
        <div class="row" id="pnlEdit" runat="server" clientidmode="Static" style="display: none">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Add / Update Items</header>
                         <div class="tools">
                             <asp:Label ID="lblRommNo" runat="server" Text="Label"></asp:Label>
                                </div>
                    </div>
                    <div class="card-body ">
                        <div class="table-scrollable">
                            <asp:GridView ID="grdBookedItem" AutoGenerateColumns="false" runat="server" Width="100%"
                                ClientIDMode="Static" OnRowDataBound="grdBookedItem_RowDataBound" OnRowCommand="grdBookedItem_RowCommand"
                                OnRowUpdating="grdBookedItem_RowUpdating" OnRowCancelingEdit="grdBookedItem_RowCancelingEdit">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Item" HeaderStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblItemName" runat="server" Text="<%#Bind('ItemName')%>"></asp:Label>
                                            <asp:HiddenField ID="hdbitemId" runat="server" Value="<%#Bind('Id') %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Price" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPrice" runat="server" Text="<%#Bind('Price')%>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Quantity" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQuantity" runat="server" Text="<%#Bind('Quantity')%>"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("Status").ToString().Equals("1") ? true : false %>'
                                                Text='Order' CssClass="label label-success" />
                                            <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("Status").ToString().Equals("2") ? true : false %>'
                                                Text='Delivered' CssClass="label label-warning" />
                                            <asp:Label ID="Label1" runat="server" Visible='<%# Eval("Status").ToString().Equals("3") ? true : false %>'
                                                Text='Cancelled' CssClass="label label-danger" />
                                            <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('status') %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Button ID="btnItemDelivered" runat="server" Visible='<%# Eval("Status").ToString().Equals("1") ? true : false %>'
                                                CssClass="btn btn-primary btn-xs" CausesValidation="false" CommandName="Update"
                                                Text="Deliver" />
                                            <asp:Button ID="btnOderCancel" runat="server" Visible='<%# Eval("Status").ToString().Equals("1") ? true : false %>'
                                                CssClass="btn btn-danger btn-xs" CausesValidation="false" CommandName="Cancel"
                                                Text="Cancel" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-4 p-t-20">
                            <div class="form-group">
                                <label>
                                    Item Name</label>
                                <asp:DropDownList ID="cboNewItemName" ToolTip="Select Items" runat="server" CausesValidation="true"
                                    class="form-control" AutoPostBack="true" OnSelectedIndexChanged="cboNewItemName_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPrice" runat="server" ToolTip="Price" TextMode="Number" Style="background: #fff"
                                    class="mdl-textfield__input"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtPrice" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Price</label>
                            </div>
                        </div>
                        <div class="col-lg-4 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtQty" required="required" ToolTip="Quantity"
                                    TextMode="Number" runat="server" class="mdl-textfield__input" onkeyup="SetButtonStatus(this,'btnsave')"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtQty" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Quantity</label>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnsave" runat="server" Text="Save Item" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                OnClick="btnsave_Click" ClientIDMode="Static" style="padding: 5px 7px;margin: 20px; border:1px solid #ff4081;color: White; background-color: #ff4081" Enabled="false"/>
                            <%--<asp:Button ID="btnClose" runat="server" Text="Close" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default"
                                OnClick="btnClose_Click" CausesValidation="false" />--%>
                            <a class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default grid-show"
                                href="javascript:;">Close</a>
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

        function SetButtonStatus(sender, target) {
            var first = document.getElementById('<%=txtQty.ClientID %>');
            // alert(target);
            //Condition to check whether user enters text in two textboxes or not
            if ((sender.value >= 1 && first.value >= 1))
                document.getElementById(target).disabled = false;
            else
                document.getElementById(target).disabled = true;
            //   alert('please enter number only')

        }

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
