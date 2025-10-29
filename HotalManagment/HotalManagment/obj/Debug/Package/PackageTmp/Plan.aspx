<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="Plan.aspx.cs" Inherits="HotalManagment.Plan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>Plan</title>
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
                        Plan</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Plan </li>
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
                                <header>Plan</header>
                                <div class="tools">
                                   <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i> New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdnPlanId" runat="server" />
                                    <asp:GridView ID="grdPlan" runat="server" ClientIDMode="Static" Width="100%" OnRowEditing="grdPlan_RowEditing"
                                        AutoGenerateColumns="False"  class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Plan Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlan" runat="server" Text="<%#Bind('PlanName')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblPrice" runat="server" Text="<%#Bind('Price')%>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Days">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblduration" runat="server" Text="<%#Bind('Duration')%>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                          
                                          
                                            <asp:TemplateField HeaderText="Plan Status" HeaderStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? true : false %>' Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>'
                                                        CssClass="label label-info label-mini" />
                                                    <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? false :true   %>'  Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>'
                                                        CssClass="label label-warning label-mini" />
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
        <div class="row" id="pnlEdit" runat="server" clientidmode="Static" style="display:none">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Add / Update Plan</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPlan" runat="server" class="mdl-textfield__input" ToolTip="Room number start"
                                    ></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"  ValidationGroup="G1"
                                    ErrorMessage="Required" ControlToValidate="txtPlan" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Plan Name</label>
                            </div>
                        </div>
                       
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPrice" runat="server" class="mdl-textfield__input" 
                                    ToolTip="Price" TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"  ValidationGroup="G1"
                                    ErrorMessage="Required" ControlToValidate="txtPrice" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Price</label>
                            </div>
                        </div>
                       
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtDuration" runat="server" class="mdl-textfield__input" 
                                    ToolTip="Group Name" MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"  ValidationGroup="G1"
                                    ErrorMessage="Required" ControlToValidate="txtDuration" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Duration (In Days)</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20" id="status" runat="server" clientidmode="Static">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                            <div class="checkbox checkbox-icon-black">
                                <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                                <label for="rememberChk1">
                                    Plan Status
                                </label>
                            </div>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnsave" runat="server"  ValidationGroup="G1" Text="Save Category" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
                                OnClick="btnSave_Click" />
                           <%-- <asp:Button ID="btnClose" runat="server" Text="Close" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 btn-default"
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
