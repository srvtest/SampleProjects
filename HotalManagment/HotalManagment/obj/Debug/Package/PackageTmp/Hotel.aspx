<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="Hotel.aspx.cs" Inherits="HotalManagment.Hotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Hotel</title>
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
                        Hotel</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Hotel </li>
                </ol>
            </div>
        </div>
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <div id="pnlList" runat="server" clientidmode="Static" class="row">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Hotel Master</header>
                                <div class="tools">
                                    <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i>New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdnUpadteId" runat="server" />
                                    <asp:GridView ID="grdHotelDetails" DataKeyNames="ID" ClientIDMode="Static" runat="server"
                                        AutoGenerateColumns="false" CellSpacing="0" Width="100%" OnRowEditing="grdHotelDetails_RowEditing"
                                        class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Hotel Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblHotelName" runat="server" Text="<%#Bind('HotelName')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="EmailId">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmailId" runat="server" Text="<%#Bind('EmailId') %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAddress" runat="server" Text="<%#Bind('Address') %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="PhoneNo">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblPhoneNo" runat="server" Text="<%#Bind('PhoneNo') %>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="GSTNo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGSTNo" runat="server" Text="<%#Bind('GSTNo') %>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="GSTNo" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpassword" runat="server" Text="<%#Bind('Password') %>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="CpHotelId" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCpHotelId" runat="server" Text="<%#Bind('CpHotelId') %>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="CpAuthenticationCode" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCpAuthenticationCode" runat="server" Text="<%#Bind('CpAuthenticationCode') %>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobileNo" runat="server" Text="<%#Bind('MobileNo') %>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="StateName" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStateId" runat="server" Text="<%#Bind('StateId') %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Logo">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgLogo" Height="50" Width="50" runat="server" ImageUrl='<%# "HotelLogo/"+Eval("Logo") %>'
                                                        AlternateText="Image" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? true : false %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>' CssClass="label label-info label-mini" />
                                                    <asp:Label ID="lblStatus1" runat="server" Visible='<%# Eval("Status").ToString().Equals("True") ? false :true   %>'
                                                        Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>' CssClass="label label-warning label-mini" />
                                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                                                    <asp:HiddenField ID="hdnPropertyName" runat="server" Value="<%#Bind('PropertyName') %>" />
                                                    <asp:HiddenField ID="hdnReviewLink" runat="server" Value="<%#Bind('ReviewLink') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-Width="100px">
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
                        <header>Add / Update Hotel</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtHotelName" runat="server" class="mdl-textfield__input" ToolTip="HotelName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                    ForeColor="Red" Display="Dynamic" ControlToValidate="txtHotelName"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Hotel Name</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:FileUpload ID="imgUpload" class="mdl-textfield__input" runat="server" />
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtEmailId" runat="server" class="mdl-textfield__input" ToolTip="Email"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                    ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmailId"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid email"
                                    Display="Dynamic" ControlToValidate="txtEmailId" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <label class="mdl-textfield__label">
                                    Email Id</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtAddress" runat="server" class="mdl-textfield__input" ToolTip="Address"
                                    Style="resize: none"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Address</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPhoneNo" runat="server" class="mdl-textfield__input" ToolTip="Phone No"
                                    MaxLength="15"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Phone no</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtMobileNo" runat="server" class="mdl-textfield__input" ToolTip="Mobile No"
                                    MaxLength="15"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Mobile no</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtGSTNo" runat="server" class="mdl-textfield__input" ToolTip="GST No"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    GST no</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="form-group">
                                <label>
                                    State</label>
                                <asp:DropDownList ID="drpState" runat="server" class="form-control" placeholder="State"
                                    ToolTip="State">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtCpHotelId" runat="server" class="mdl-textfield__input" ToolTip="Cp Hotel Id"
                                    MaxLength="15"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Cp Hotel Id</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtCpAuthenticationCode" runat="server" class="mdl-textfield__input" ToolTip="Cp Authentication Code"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Cp Authentication Code</label>
                            </div>
                        </div>

                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPropertyName" runat="server" class="mdl-textfield__input" ToolTip="Property Name"
                                    MaxLength="15"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Property Name</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtReviewLink" runat="server" class="mdl-textfield__input" ToolTip="Review Link"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Review Link</label>
                            </div>
                        </div>

                        <div class="col-lg-6 p-t-20" id="status" runat="server">
                            <div class="checkbox checkbox-icon-black">
                                <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                                <label for="rememberChk1">
                                    Status
                                </label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                style="width: 40%!important; float: left;">
                                <label class="">
                                    Old Password : 
                                    <asp:Label ID="lblOldpassword" runat="server" Font-Bold="true"></asp:Label>
                                </label>
                            </div>
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width"
                                style="width: 60%!important; float: left;">
                                <asp:TextBox ID="txtPassword" runat="server" class="mdl-textfield__input" ToolTip="Password"
                                    TextMode="Password"></asp:TextBox>
                                <label class="mdl-textfield__label">
                                    Password</label>
                            </div>
                        </div>
                        <div class="col-lg-12 p-t-20 text-center">
                            <asp:Button ID="btnsave" runat="server" Text="Add" class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
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
    <%-- <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Hotel</a></li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="icon-user"></i><span class="break"></span>Hotels</h2>
                <div class="box-icon">
                    <asp:LinkButton ID="btnPlus" OnClick="btnAddNew_Click" CausesValidation="false" runat="server" CssClass="icon-plus-sign"></asp:LinkButton>
                    <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                </div>
            </div>
            <div class="box-content">
                
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->
    <script language="javascript" type="text/javascript">
   
    </script>
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
    <div class="modal fade" id="AddHotelDeatils" data-backdrop="static">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update Hotel</h3>
        </div>
        <div class="modal-body" style="max-height: 458px  !important">
            <div class="box-content" style="height: 434px !important">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                <span style="color: Red">*</span>Hotel Name
                            </label>
                            <div class="controls">
                             
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                Logo
                            </label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                <span style="color: Red">*</span>Email
                            </label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                Address
                            </label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                Phone No
                            </label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                Mobile No
                            </label>
                            <div class="controls">
                                
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                GST No
                            </label>
                            <div class="controls">
                              
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead">
                                State
                            </label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label" for="typeahead" style="margin-top: -12px;">
                                Status
                            </label>
                            <div class="controls">
                                <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnClose" runat="server" Text="Close" class="btn" OnClick="btnClose_Click"
                CausesValidation="false" />
            <asp:Button ID="btnSave" runat="server" Text="Add" class="btn btn-primary" OnClick="btnSave_Click" />
        </div>
    </div>
  
    <script type="text/javascript">
        $(document).ready(function () {
            $("#grdHotelDetails").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                        responsive:true,
                        sPaginationType: "bootstrap"
            });
        });  

    </script> --%>
</asp:Content>
