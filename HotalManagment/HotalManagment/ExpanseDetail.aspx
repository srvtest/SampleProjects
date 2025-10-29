<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="ExpanseDetail.aspx.cs" Inherits="HotalManagment.ExpanseDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Expanse Detail</title>
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
                        Expanse Detail</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Expanse Detail </li>
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
                                <header>Expanse Detail</header>
                                <div class="tools">
                                     <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i> New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdItemId" runat="server" />
                                    <asp:GridView ID="grdExpanse" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"
                                        Width="100%" OnRowEditing="grdExpanse_RowEditing" 
                                        class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Expanse Head">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblgrdExpanseHead" runat="server" Text="<%#Bind('ExpanseHead')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                    <asp:HiddenField ID="hdnExpanseHeadId" runat="server" Value="<%#Bind('ExpanseHeadId') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblPrice" runat="server" Text="<%#Bind('Amount')%>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblCode" runat="server" Text="<%#Bind('ExpanseDate')%>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="50px" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? true : false %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>' CssClass="label label-info label-mini" />
                                                    <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? false :true   %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>' CssClass="label label-warning label-mini" />
                                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="65px" Visible="false">
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
        <div class="row" id="pnlEdit" runat="server" clientidmode="Static" style="display:none">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Add / Update Expanse</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-4 p-t-20">
                            <div class="form-group">
                                <label>
                                    Expanse Head</label>
                                <asp:DropDownList ID="ddlExpanseHead" class="form-control" runat="server" ToolTip="Expanse Head">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0" ValidationGroup="G1"
                                    ForeColor="Red" ErrorMessage="Required" ControlToValidate="ddlExpanseHead" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-4 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtDate" runat="server"  name="Item" class="datepickerAll mdl-textfield__input"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ValidationGroup="G1"
                                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                                     <label class="mdl-textfield__label">
                                    Date</label>
                            </div>
                        </div>
                        <div class="col-lg-4 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPrice" runat="server"  name="price"
                                    class="mdl-textfield__input" TextMode="Number"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ValidationGroup="G1"
                                    Display="Dynamic" ForeColor="Red" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                                     <label class="mdl-textfield__label">
                                    Amount</label>
                            </div>
                        </div>
                        
                        
                        <div class="col-lg-6 p-t-20" id="status" runat="server" clientidmode="Static" style="display:none">
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
                            <asp:Button ID="btnsave" runat="server" ValidationGroup="G1" Text="Save Category" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
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
    
</asp:Content>
