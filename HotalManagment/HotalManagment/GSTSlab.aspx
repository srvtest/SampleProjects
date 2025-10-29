<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="GSTSlab.aspx.cs" Inherits="HotalManagment.GSTSlab" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>GST Slab</title>
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
                        GST Slab</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">GST Slab </li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdSKey" runat="server" ClientIDMode="Static" Value=0 />
        <div id="pnlSKey" runat="server" class="row" clientidmode="Static" >
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
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div id="pnlList" runat="server" clientidmode="Static" class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>GST Slab</header>
                                <div class="tools">
                                    <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i>New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdnGSTSlabId" runat="server" />
                                    <asp:GridView ID="grdGSTSlab" DataKeyNames="ID" AutoGenerateColumns="false" runat="server"
                                        Width="100%" OnRowEditing="grdGSTSlab_RowEditing" ClientIDMode="Static" class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="GST Slab">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGstSlab" runat="server" Text="<%#Bind('GSTSlab')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Percentage">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblParcentage" runat="server" Text="<%#Bind('Percentage')%>"></asp:Label></center>
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
                        <header>Add/Update GST Slab</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtGstSlab" runat="server" class="mdl-textfield__input"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    GST Slab</label>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                ValidationGroup="G1" ForeColor="Red" ControlToValidate="txtGstSlab" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="TxtPercent" TextMode="Number" min="0" max="100" runat="server" class="mdl-textfield__input"
                                    name="Percentage"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Percentage</label>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                ValidationGroup="G1" ForeColor="Red" ControlToValidate="TxtPercent" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20" id="status" runat="server">
                            <div class="checkbox checkbox-icon-black">
                                <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                                <label for="rememberChk1">
                                    IsActive
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnsave" runat="server" ValidationGroup="G1" Text="Save GST Slab"
                                class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                OnClick="btnSave_Click" />
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
    <%--  <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">GST Slab</a></li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2>
                    <i class="icon-user"></i><span class="break"></span>GST Slab</h2>
                <div class="box-icon">
                    <asp:LinkButton ID="btnPlus" OnClick="btnAddNew_Click" CausesValidation="false" runat="server" CssClass="icon-plus-sign"></asp:LinkButton>
                    <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                </div>
            </div>
            <div class="box-content">
                <asp:HiddenField ID="hdnGSTSlabId" runat="server" />
                <asp:GridView ID="grdGSTSlab" DataKeyNames="ID" AutoGenerateColumns="false"  runat="server"
                    Width="100%" OnRowEditing="grdGSTSlab_RowEditing" OnRowDeleting="grdGSTSlab_RowDeleting"
                    ClientIDMode="Static">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="GST Slab">
                            <ItemTemplate>
                                <asp:Label ID="lblGstSlab"  runat="server" Text="<%#Bind('GSTSlab')%>"></asp:Label>
                                <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Percentage">
                            <ItemTemplate>
                                <center>
                                    <asp:Label ID="lblParcentage" runat="server" Text="<%#Bind('Percentage')%>"></asp:Label></center>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>'
                                        CssClass="label label-success" />
                                    <asp:Label ID="lblStatus1" runat="server" Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>'
                                        CssClass="label label-warning" />
                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="65px">
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-success" runat="server" CausesValidation="false"
                                        CommandName="Edit" Text=""><i class="white icon-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server" CausesValidation="false"
                                        CommandName="Delete" Text=""><i class="white icon-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="modal fade" id="AddGstSlab" data-backdrop="static">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update GST Slab</h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                GST Slab
                            </label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                Percentage
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
                    </fieldset>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" data-dismiss="modal">Close</a>
            <asp:Button ID="btnsave" OnClick="btnsave_Click" runat="server" Text="Save GST Slab"
                class="btn btn-primary" />
        </div>
    </div>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#grdGSTSlab").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                responsive: true,
                sPaginationType: "bootstrap"
            });
        });
    </script>--%>
</asp:Content>
