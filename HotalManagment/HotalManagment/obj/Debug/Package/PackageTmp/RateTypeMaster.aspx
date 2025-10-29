<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="RateTypeMaster.aspx.cs" Inherits="HotalManagment.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>RateType</title>
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
                        RateType</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">RateType</li>
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
        <div id="pnlList" runat="server" class="row" clientidmode="Static">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>RateType</header>
                                <div class="tools">
                                    <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i>New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdRateId" runat="server" Value="0" />
                                    <asp:GridView ID="grdRateType" runat="server" ClientIDMode="Static" AutoGenerateColumns="false"
                                        Width="100%" OnRowEditing="grdRateType_RowEditing1" class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text="<%#Bind('Name')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="RateTypeId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRateTypeId" runat="server" Text="<%#Bind('RateTypeId')%>"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="PlanName">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPlanName" runat="server" Text="<%#Bind('PlanName')%>"></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? true : false %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>' CssClass="label label-info label-mini" />
                                                    <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? false :true   %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>' CssClass="label label-warning label-mini" />
                                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="50px"></HeaderStyle>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="65px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-primary btn-xs" runat="server" CausesValidation="false"
                                                        CommandName="Edit" Text=""><i class="fa fa-pencil"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <HeaderStyle Width="65px"></HeaderStyle>
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
                        <header>Add / Update RateType</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtName" runat="server" class="mdl-textfield__input" name="password"
                                    MaxLength="50"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Name</label>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                ValidationGroup="G1" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtRateTypeId" runat="server" class="mdl-textfield__input" name="password"
                                    MaxLength="50"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    RateTypeId</label>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                ValidationGroup="G1" ControlToValidate="txtRateTypeId" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:DropDownList ID="ddlPlanName" runat="server">
                                    <asp:ListItem Value="1" Text="EP">EP</asp:ListItem>
                                    <asp:ListItem Value="2" Text="CP">CP</asp:ListItem>
                                    <asp:ListItem Value="3" Text="MAP">MAP</asp:ListItem>
                                </asp:DropDownList>
                                <label class="mdl-textfield__label">
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20" id="status" runat="server" clientidmode="Static" style="display: none">
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
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="G1" Text="Save Rate" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
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
