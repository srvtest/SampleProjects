<%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true"
    CodeBehind="RoomMaster.aspx.cs" Inherits="HotalManagment.RoomMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Rooms Master</title>
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
                        Rooms</div>
                </div>
                <ol class="breadcrumb page-breadcrumb pull-right">
                    <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="MainDashBoard.aspx">Home</a>&nbsp;<i
                        class="fa fa-angle-right"></i> </li>
                    <li class="active">Room </li>
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
        <div class="row" id="pnlList" runat="server" clientidmode="Static">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="card card-topline-green">
                            <div class="card-head">
                                <header>Room Master</header>
                                <div class="tools">
                                    <a class="form-show" href="javascript:;"><i class="fa fa-plus-square"></i>New</a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <div class="table-scrollable">
                                    <asp:HiddenField ID="hdnGroupId" runat="server" />
                                    <asp:GridView ID="grdRooms" runat="server" ClientIDMode="Static" Width="100%" OnRowEditing="grdRooms_RowEditing"
                                        AutoGenerateColumns="False" OnRowDeleting="grdRooms_RowDeleting" class="table">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Group Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblGroupName" runat="server" Text="<%#Bind('RoomGroupName')%>"></asp:Label>
                                                    <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Room From">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblRoomFrom" runat="server" Text="<%#Bind('RoomNoFrom')%>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Room To">
                                                <ItemTemplate>
                                                    <center>
                                                        <asp:Label ID="lblRoomTo" runat="server" Text="<%#Bind('RoomNoTo')%>"></asp:Label></center>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnCategoryId" runat="server" Value="<%#Bind('CategoryId') %>" />
                                                    <asp:Label ID="lblCategoryName" runat="server" Text="<%#Bind('CategoryName')%>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          <%--  <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="GST Slab">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnGSTSlabId" runat="server" Value="<%#Bind('GSTSlabId') %>" />
                                                    <asp:Label ID="lblGSTSlab" runat="server" Text="<%#Bind('GSTSlab')%>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Price">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPrice" runat="server" Text="<%#Bind('Price')%>"></asp:Label>
                                                    <asp:HiddenField ID="lblMon" runat="server" Value="<%#Bind('Monday')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblTues" runat="server" Value="<%#Bind('Tuesday')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblWeb" runat="server" Value="<%#Bind('Wednesday')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblThu" runat="server" Value="<%#Bind('Thursday')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblFri" runat="server" Value="<%#Bind('Friday')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblSat" runat="server" Value="<%#Bind('Saturday')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblSun" runat="server" Value="<%#Bind('Sunday')%>"></asp:HiddenField>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Persons">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPerson" runat="server" Text="<%#Bind('Persons')%>"></asp:Label>
                                                    <asp:HiddenField ID="lblEP" runat="server" Value="<%#Bind('EP')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblCP" runat="server" Value="<%#Bind('CP')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblMAP" runat="server" Value="<%#Bind('MAP')%>"></asp:HiddenField>
                                                    <asp:HiddenField ID="lblEBCEP" runat="server" Value="<%#Bind('ExBadChargeEP')%>">
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="lblEBCCP" runat="server" Value="<%#Bind('ExBadChargeCP')%>">
                                                    </asp:HiddenField>
                                                    <asp:HiddenField ID="lblEBCMAP" runat="server" Value="<%#Bind('ExBadChargeMAP')%>">
                                                    </asp:HiddenField>
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
        <div class="row" id="pnlEdit" runat="server" clientidmode="Static" style="display: none">
            <div class="col-sm-12">
                <div class="card-box">
                    <div class="card-head">
                        <header>Add / Update Rooms</header>
                    </div>
                    <div class="card-body row">
                        <div class="col-lg-6 p-t-20">
                            <div class="form-group">
                                <label>
                                    Category</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" class="form-control" ToolTip="Category">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" runat="server"
                                    ValidationGroup="G1" ForeColor="Red" ErrorMessage="Required" ControlToValidate="ddlCategory"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <%-- <div class="col-lg-6 p-t-20">
                            <div class="form-group">
                                <label>
                                    GST Slab</label>
                                <asp:DropDownList ID="ddlGstSlab" class="form-control" runat="server" ToolTip="GST Slab">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" InitialValue="0"
                                    ValidationGroup="G1" ForeColor="Red" ErrorMessage="Required" ControlToValidate="ddlGstSlab"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>--%>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtGroupName" runat="server" class="mdl-textfield__input" ToolTip="Group Name"
                                    MaxLength="100"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtGroupName"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Group Name</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtRoomFrom" runat="server" class="mdl-textfield__input" ToolTip="Room number start"
                                    TextMode="Number" MaxLength="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtRoomFrom"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Room From</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtRoomTo" runat="server" class="mdl-textfield__input" ToolTip="Room number end"
                                    TextMode="Number" MaxLength="4"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtRoomTo" Display="Dynamic"></asp:RequiredFieldValidator>
                                <br />
                                <asp:CompareValidator ID="CompareValidator1" runat="server" Type="Integer" ControlToCompare="txtRoomFrom"
                                    ValidationGroup="G1" ControlToValidate="txtRoomTo" Operator="GreaterThanEqual"
                                    ForeColor="Red" ErrorMessage="To room no. should be greater than from room no."
                                    Display="Dynamic"></asp:CompareValidator>
                                <label class="mdl-textfield__label">
                                    Room to</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPrice" runat="server" class="mdl-textfield__input" ToolTip="Price"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtPrice" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Price</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtPersons" runat="server" class="mdl-textfield__input" ToolTip="No of Person"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtPersons" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Persons</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtEP" runat="server" class="mdl-textfield__input" ToolTip="No of Person"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtPersons" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    EP</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtCP" runat="server" class="mdl-textfield__input" ToolTip="No of Person"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtPersons" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    CP</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtMAP" runat="server" class="mdl-textfield__input" ToolTip="No of Person"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtPersons" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    MAP</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <label class="">
                                    Extra Bed Charges :</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtExBadEP" runat="server" class="mdl-textfield__input" ToolTip="No of Person"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtExBadEP" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    EP</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtExBadCP" runat="server" class="mdl-textfield__input" ToolTip="No of Person"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtExBadCP" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    CP</label>
                            </div>
                        </div>
                        <div class="col-lg-3 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtExBadMAP" runat="server" class="mdl-textfield__input" ToolTip="No of Person"
                                    TextMode="Number" MaxLength="9"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtExBadMAP"
                                    Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    MAP</label>
                            </div>
                        </div>
                        <div class="col-lg-2 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <label class="">
                                    Daywise Price:</label>
                            </div>
                        </div>
                        <div class="col-lg-1 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtMon" runat="server" class="mdl-textfield__input" ToolTip="Monday Price"
                                    TextMode="Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtMon" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Mon</label>
                            </div>
                        </div>
                        <div class="col-lg-1 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtTues" runat="server" class="mdl-textfield__input" ToolTip="Tuesday Price"
                                    TextMode="Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtTues" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Tues</label>
                            </div>
                        </div>
                        <div class="col-lg-1 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtWed" runat="server" class="mdl-textfield__input" ToolTip="Wednesday Price"
                                    TextMode="Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtWed" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Wed</label>
                            </div>
                        </div>
                        <div class="col-lg-1 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtThu" runat="server" class="mdl-textfield__input" ToolTip="Thursday Price"
                                    TextMode="Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtThu" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Thu</label>
                            </div>
                        </div>
                        <div class="col-lg-1 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtFri" runat="server" class="mdl-textfield__input" ToolTip="Friday Price"
                                    TextMode="Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtFri" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Fri</label>
                            </div>
                        </div>
                        <div class="col-lg-1 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtSat" runat="server" class="mdl-textfield__input" ToolTip="Saturday Price"
                                    TextMode="Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtSat" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Sat</label>
                            </div>
                        </div>
                        <div class="col-lg-1 p-t-20">
                            <div class="mdl-textfield mdl-js-textfield mdl-textfield--floating-label txt-full-width">
                                <asp:TextBox ID="txtSun" runat="server" class="mdl-textfield__input" ToolTip="Sunday Price"
                                    TextMode="Number" MaxLength="10"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ForeColor="Red"
                                    ValidationGroup="G1" ErrorMessage="Required" ControlToValidate="txtSun" Display="Dynamic"></asp:RequiredFieldValidator>
                                <label class="mdl-textfield__label">
                                    Sun</label>
                            </div>
                        </div>
                        <div class="col-lg-6 p-t-20" id="status" runat="server" clientidmode="Static">
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
                            <asp:Button ID="btnsave" runat="server" ValidationGroup="G1" Text="Save Category"
                                class="mdl-button mdl-js-button mdl-button--raised mdl-js-ripple-effect m-b-10 m-r-20 btn-pink"
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
    <%-- <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Rooms</a></li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2>
                    <i class="icon-user"></i><span class="break"></span>Rooms</h2>
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
    <div class="modal fade" id="AddRooms" data-backdrop="static">
        <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update Rooms</h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <div class="control-group">
                            <label class="control-label">
                                <span style="color: Red">*</span>Category</label>
                            <div class="controls">
                                
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                <span style="color: Red">*</span>Room number from</label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                <span style="color: Red">*</span>Room number to</label>
                            <div class="controls">
                              
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                <span style="color: Red">*</span>Price</label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                <span style="color: Red">*</span>GST Slab</label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                <span style="color: Red">*</span>Group Name</label>
                            <div class="controls">
                               
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">
                                Status</label>
                            <div class="controls">
                                <label class="checkbox inline" style="padding-top: 10px;">
                                 
                                </label>
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
            $("#grdRooms").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                responsive: true,
                sPaginationType: "bootstrap"
            });
        });
    </script>--%>
</asp:Content>
