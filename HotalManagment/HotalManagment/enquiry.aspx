<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="enquiry.aspx.cs" Inherits="HotalManagment.enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Enquiry</title>
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
                        Enquiry</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Enquiry</li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <div class="row" id="pnlList" runat="server" clientidmode="Static">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Enquiry</header>
                                <div class="tools">
                                    <a class="form-show btn-color fa fa-plus-square" href="javascript:;"></a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdEnquiryId" runat="server" />
                                    <asp:GridView ID="grdEnquiry" ClientIDMode="Static" runat="server" AutoGenerateColumns="false"
                                        Width="100%" OnRowEditing="grdEnquiry_RowEditing" class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategoryName" runat="server" Text="<%#Bind('CategoryName')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdcatnId" runat="server" Value="<%#Bind('CategoryId') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Check-In">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFromDate" runat="server" Text="<%#Bind('FromDate')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('id') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Check-Out">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblToDate" runat="server" Text="<%#Bind('Todate')%>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EnquiryBy">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEnquiryBy" runat="server" Text="<%#Bind('EnquiryBy')%>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="90px">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:LinkButton ID="btnEdit" CssClass="btn btn-primary btn-xs" runat="server" CausesValidation="false"
                                                            CommandName="Edit" Text=""><i class="fa fa-pencil"></i></asp:LinkButton>
                                                    </center>
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
        <div class="row" id="pnlEdit" runat="server" clientidmode="Static" style="display:none">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Add / Update Enquiry</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtFromDate" runat="server"  class="mdl-textfield__input"
                                    name="From Date" ></asp:TextBox>
                                
                                <label class="mdl-textfield__label">
                                    Room From</label>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtFromDate" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtTodate" runat="server"  class="mdl-textfield__input"
                                    name="To Date" ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtTodate" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Room To</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="form-group">
                                <label>
                                    Category</label>
                                <asp:DropDownList ID="ddCategory" CssClass="form-control" runat="server" OnSelectedIndexChanged="ddCategory_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Required" ControlToValidate="ddCategory" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="form-group">
                                <label>
                                    Rooms</label>
                                <asp:DropDownList ID="ddRoomNo" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Required" ControlToValidate="ddRoomNo" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="form-group">
                                <label>
                                    Booking Source</label>
                                <asp:DropDownList ID="ddBookingSource" CssClass="form-control" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <div class="checkbox checkbox-icon-black">
                                <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                                <label for="rememberChk1">
                                    Status
                                </label>
                            </div>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtEnquiryBy" runat="server"  class="mdl-textfield__input" name="To Date"
                                   ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtEnquiryBy" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Enquiry By</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtContactNo" runat="server"  class="mdl-textfield__input"
                                    MaxLength="15"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtContactNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContactNo"
                                    ValidationExpression="[1-9][0-9]{9,14}" Display="Dynamic" ForeColor="Red" ErrorMessage="Invalid No"></asp:RegularExpressionValidator>
                                <label class="mdl-textfield__label">
                                    Contact No</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20" id="status" runat="server" clientidmode="Static" style="display:none">
                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtNotes" runat="server"  class="mdl-textfield__input"
                                    TextMode="MultiLine" Style="resize: none; height: 70px!important"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                    ErrorMessage="Required" ControlToValidate="txtNotes" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Notes</label>
                            </div>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnsave" runat="server" Text="Save Category" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                OnClick="btnSave_Click" />
                           <%-- <asp:Button ID="btnClose" runat="server" Text="Close" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default"
                                OnClick="btnClose_Click" CausesValidation="false" />--%>
                                <a class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default grid-show" href="javascript:;">Close</a>
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
            $('.grid-show').click(function () {
                $('#pnlEdit').css('display', 'none');
                $('#pnlList').css('display', 'block');
            });
            $('.form-show').click(function () {
                $('.mdl-textfield__input').val('');
                $("select.form-control").prop('selectedIndex', 0);
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
    <%--<ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Enquiry</a></li>
    </ul>--%>
    <%--        <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Enquiry</a></li>
    </ul>

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="icon-user"></i><span class="break"></span>Enquiry List</h2>
                <div class="box-icon">
                    <asp:LinkButton ID="btnPlus" OnClick="btnAddNew_Click" CausesValidation="false" runat="server" CssClass="icon-plus-sign"></asp:LinkButton>
                    <a href="#" class="btn-Enquiry"><i class=""></i></a><a href="#" class="btn-minimize">
                        <i class="icon-chevron-up"></i></a>
                </div>
            </div>
            <div class="box-content">
               
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->
    <div class="modal fade" id="MessageModel" >
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" >
                ×</button>
            <h3>
                Message</h3>
        </div>
        <div class="modal-body">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" data-dismiss="modal">OK</a>
        </div>
    </div>
    <div class="modal fade" id="AddEnquiry" style="width: 75%" data-backdrop="static">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update Enquiry</h3>
        </div>
        <div class="modal-body">
            <form class="form-horizontal">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label" for="From Date">
                            <span style="color: Red">*</span>From Date
                        </label>
                        <div class="col-sm-8">
                           
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label" for="To Date">
                            <span style="color: Red">*</span>To Date
                        </label>
                        <div class="col-sm-8">
                           
                        </div>
                    </div>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="col-sm-4 control-label" for="Category">
                                    <span style="color: Red">*</span>Category
                                </label>
                                <div class="col-sm-8">
                                    
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-6">
                            <div class="form-group">
                                <label class="col-sm-4 control-label" for="Room No">
                                    <span style="color: Red">*</span>Room No
                                </label>
                                <div class="col-sm-8">
                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label" for="Booking Source">
                            Booking Source
                        </label>
                        <div class="col-sm-8">
                           
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label" for="Status">
                            Status</label>
                        <div class="col-sm-8" style="padding-top: 11px;">
                            <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label" for="Enquiry by">
                            <span style="color: Red">*</span>Enquiry by
                        </label>
                        <div class="col-sm-8">
                          
                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label" for="Contact No">
                            <span style="color: Red">*</span>Contact No
                        </label>
                        <div class="col-sm-8">
                           
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <label class="col-sm-4 control-label" for="Notes">
                            <span style="color: Red">*</span>Notes
                        </label>
                        <div class="col-sm-8">
                          
                        </div>
                    </div>
                </div>
            </div>
            </form>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnClose" runat="server" Text="Clear" class="btn" OnClick="btnClose_Click"
                CausesValidation="false" />
            <asp:Button ID="btnsave" runat="server" Text="Save Enquiry" CausesValidation="true" class="btn btn-primary"
                OnClick="btnSave_Click" />
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#grdEnquiry").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                responsive: true,
                sPaginationType: "bootstrap"
            });
        });
    </script>--%>
</asp:Content>
