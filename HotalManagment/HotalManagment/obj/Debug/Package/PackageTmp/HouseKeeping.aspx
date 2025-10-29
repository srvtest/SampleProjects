<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="HouseKeeping.aspx.cs" Inherits="HotalManagment.HouseKeeping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>House Keeping</title>
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
                        House Keeping</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">House Keeping </li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <div class="row" id="pnlList" runat="server" clientidmode="Static" >
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>House Keeping</header>
                                <div class="tools">
                                     <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i> New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdnUpadteId" runat="server" />
                                    <asp:GridView ID="grdHouseKeeping" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"
                                        Width="100%" OnRowEditing="grdHouseKeeping_RowEditing" class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Room No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRoomNo" runat="server" Text="<%#Bind('RoomNo')%>"></asp:Label></center>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCategory" runat="server" Text="<%#Bind('CategoryName')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnCategoryId" runat="server" Value="<%#Bind('CategoryId') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                   <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? true : false %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>' CssClass="label label-info label-mini" />
                                                    <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? false :true   %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>' CssClass="label label-warning label-mini" />
                                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-CssClass="btn-action" HeaderStyle-Width="65px">
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
       

        <div class="row" id="pnlEdit" runat="server" clientidmode="Static" >
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Add / Update House Rooms</header>
                        <%--<button id="panel-button" class="mdl-button mdl-js-button mdl-button--icon pull-right"
                            data-upgraded=",MaterialButton">
                            <i class="material-icons">more_vert</i>
                        </button>--%>
                    </div>
                    <div class="card-body row">
                      <%--  <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                                <div class="col-lg-6 p-t-20">
                                    <div class="form-group">
                                        <label>
                                            Category</label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlCategory_selectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" InitialValue="0" ValidationGroup="G1"
                                            ForeColor="Red" ErrorMessage="Required" ControlToValidate="ddlCategory"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-6 p-t-20">
                                    <div class="form-group">
                                        <label>
                                            Room No</label>
                                        <asp:DropDownList ID="ddlRoomNo" runat="server" class="form-control" placeholder="Room No"
                                            ToolTip="RoomNo">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="0" ValidationGroup="G1"
                                            ForeColor="Red" ErrorMessage="Required" ControlToValidate="ddlRoomNo"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                          <%--  </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        <div class="col-lg-6" id="status" runat="server" clientidmode="Static" style="display:none">
                        <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <div class="checkbox checkbox-icon-black">
                                <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                                <label for="rememberChk1">
                                    Status
                                </label>
                            </div>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnsave" runat="server" ValidationGroup="G1" Text="Save HouseKeeping" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                OnClick="btnSave_Click" />
                            <%--<asp:Button ID="btnClose" runat="server" Text="Close" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default"
                                OnClick="btnClose_Click" CausesValidation="false" />--%>
                               <asp:Button ID="btnClose" runat="server" Text="Close" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default grid-show"
                                OnClick="btnClose_Click" />
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

//            $('.grid-show').click(function () {
//                $('#pnlEdit').css('display', 'none');
//                $('#pnlList').css('display', 'block');
//            });
            $('.form-show').click(function () {
              //  $("select.form-control").prop('selectedIndex', 0);
                $('#pnlEdit').css('display', 'block');
                $('#pnlList').css('display', 'none');
             //   $('#status').css('display', 'none');
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
        <li><a href="#">House Keeping</a></li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2>
                    <i class="icon-user"></i><span class="break"></span>House Keeping</h2>
                <div class="box-icon">
                    <asp:LinkButton ID="btnPlus" OnClick="btnAddNew_Click" CausesValidation="false" runat="server"
                        CssClass="icon-plus-sign"></asp:LinkButton>
                    <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                </div>
            </div>
            <div class="box-content">
                
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->
    <div class="modal fade" id="MessageModel">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
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
    <div class="modal fade" id="AddUpdateHouseKeeping" data-backdrop="static">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update House Keeping Rooms</h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="control-group" style="margin-bottom: 0px">
                                    <label class="control-label" for="typeahead">
                                        <span style="color: Red">*</span>Category Type
                                    </label>
                                    <div class="controls">
                                      
                                    </div>
                                </div>
                                <br />
                                <div class="control-group" style="margin-bottom: 0px">
                                    <label class="control-label" for="typeahead">
                                        <span style="color: Red">*</span>Room No
                                    </label>
                                    <div class="controls">
                                       
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">
                                        Status</label>
                                    <div class="controls">
                                        <label class="checkbox inline" style="padding-top: 10px;">
                                            <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                                        </label>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnClose" runat="server" Text="Close" class="btn" CausesValidation="false"
                OnClick="btnClose_Click" />
            <%-- <a href="#" class="btn" data-dismiss="modal">Close</a>--%>
    <%--  <asp:Button ID="btnSave" runat="server" Text="Add" class="btn btn-primary" OnClick="btnSave_Click" />
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#grdHouseKeeping").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                responsive: true,
                sPaginationType: "bootstrap"
            });
        });
    </script>--%>--%>
</asp:Content>
