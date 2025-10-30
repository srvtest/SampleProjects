<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmHotel.aspx.cs" Async="true" Inherits="Hotel_Guest_Reporting_System.frmHotel" %>

<%@ MasterType VirtualPath="~/mainHome.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/ui-lightness/jquery-ui.css' rel='stylesheet'>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js">    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">    </script>
    <style>
        .fontcolour {
            color: red;
        }

        /*  .btnAction {
            margin-top: 5px;
        }

        .btnGuest {
            width: 192px;
        }*/
        .dropdown {
            position: relative;
            display: inline-block;
        }

        option::selection {
            background: #ff820f;
        }

        .yourdropdown option:active, .yourdropdown option:hover, .yourdropdown option:focus {
            background-color: green;
        }

        /*.yourdropdown { font-size: 20px; color: darkblue; width:200px;         
            -webkit-appearance: none; -moz-appearance: none; appearance: none; 
            background-image: url('../DownArrow.png'); background-repeat: no-repeat; 
            background-position: right .7em top 50%; background-size: .65em auto; }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdnId" runat="server" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdHotelId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmHotel.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnluserList">
            <div class="col-sm-12">
                <!-- Contextual classes table starts -->
                <div class="card">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl3" runat="server"></asp:Label></h5>
                        <%-- <div class="f-right">
                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-success waves-effect waves-light m-r-30" OnClick="btnNew_Click" />
                        </div>--%>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-md-3 form-group">
                                <asp:RadioButton ID="RbAll" runat="server" GroupName="Filter" OnCheckedChanged="RbAll_CheckedChanged" AutoPostBack="true" Checked="true" />
                                <label for="exampleInputEmail" class="form-control-label">All</label>
                            </div>
                            <div class="col-md-3 form-group">
                                <asp:RadioButton ID="RbNew" runat="server" GroupName="Filter" OnCheckedChanged="RbAll_CheckedChanged" AutoPostBack="true" />
                                <label for="exampleInputEmail" class="form-control-label">New</label>
                            </div>
                            <div class="col-md-3 form-group">
                                <asp:RadioButton ID="RBExpired" runat="server" GroupName="Filter" OnCheckedChanged="RbAll_CheckedChanged" AutoPostBack="true" />
                                <label for="exampleInputEmail" class="form-control-label">Expired In</label>
                                <asp:TextBox ID="txtFromDate" runat="server" class="form-control" placeholder="From date" TextMode="Date" AutoPostBack="true" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                <asp:TextBox ID="txtToDate" runat="server" class="form-control" placeholder="To date" TextMode="Date" AutoPostBack="true" OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                            </div>
                            <div class="col-md-3 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Policestation</label>
                                <asp:DropDownList ID="ddlPoliceStationFilter" runat="server" CssClass="form-control dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlPoliceStationFilter_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-12 table-responsive">
                                <asp:Repeater ID="RptHotel" runat="server" OnItemCommand="RptHotel_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered" style="width: 100%" id="example">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Hotel</th>
                                                    <th>Police Station</th>
                                                    <th>Contact</th>
                                                    <th>Created On</th>
                                                    <th>Payment Status</th>
                                                    <th>Valid Upto</th>
                                                    <th>Status</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>

                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td>
                                                <%#Eval("HotelName")%>
                                                <asp:HiddenField ID="hdHotelId" runat="server" Value='<%# Eval("HotelID") %>' />
                                            </td>
                                            <td>
                                                <%#Eval("PoliceStationName")%>
                                            </td>
                                            <td>
                                                <%#Eval("HotelOwnerNumber")%>
                                            </td>
                                            <td>
                                                <%# Eval("CreatedAt").ToString() == "1/1/0001 12:00:00 AM" ? "" : String.Format("{0:dd/MM/yy HH:mm}", Eval("CreatedAt")) %>
                                            </td>
                                            <td>
                                                <%#Eval("PaymentStatus")%>
                                            </td>
                                            <td>
                                                <%# Eval("SubscriptionExpireDate").ToString() == "1/1/0001 12:00:00 AM" ? "New" : String.Format("{0:dd/MM/yyyy}", Eval("SubscriptionExpireDate")) %>

                                                <%--                                                <%#Eval("SubscriptionExpireDate")%>--%>
                                            </td>
                                            <td>
                                                <a href="#" class="btn <%# Eval("Status").ToString() == "True" ? "Active" : "Inactive" %>">

                                                    <span class="icon text-white-50">
                                                        <i class="fas fa-arrow-right"></i>
                                                    </span>
                                                    <span class="text">
                                                        <asp:Label ID="LblStatus" runat="server" ClientIDMode="Static" Text='<%# (Convert.ToString(Eval("Status"))=="True" ? "Active" :"InActive")+(Convert.ToString(Eval("SubscriptionExpireDate"))=="" ? " (New)":"")   %>'></asp:Label></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Edit" CommandArgument='<%# Eval("HotelID") %>' CommandName="Update" />
                                                <asp:Button ID="Button2" runat="server" Text="View" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="View" CommandArgument='<%# Eval("HotelID") %>' CommandName="View" />
                                                <asp:Button ID="Button5" runat="server" Text="Reset Password" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="View" CommandArgument='<%# Eval("HotelID") %>' CommandName="Send" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                </table>
                                   
                                    </FooterTemplate>
                                </asp:Repeater>

                            </div>
                        </div>
                    </div>
                </div>
                <!-- Contextual classes table ends -->
            </div>
        </div>
        <!-- Row start -->
        <div class="row" runat="server" id="pnlUser">
            <!--Basic Form starts-->
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl4" runat="server"></asp:Label></h5>

                    </div>


                    <div class="card-block">
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Hotel Name</label>

                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Hotel Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="txtName" ErrorMessage="Please enter name" ValidationGroup="save"></asp:RequiredFieldValidator>
                                <asp:HiddenField ID="hdnHotelNewId" runat="server"></asp:HiddenField>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Address</label>

                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Address"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="txtAddress" ErrorMessage="Please enter address" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Contact</label>

                                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="Contact" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="txtContact" ErrorMessage="Please enter contact" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Contact Person</label>

                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" placeholder="Contact Person"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="Please enter contact person" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Email Address</label>

                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="EmailAddress"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter email address" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Valid Upto</label>

                                <asp:TextBox ID="txtValidUpto" runat="server" CssClass="form-control" placeholder="ValidUpto" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" runat="server" ControlToValidate="txtValidUpto" ErrorMessage="Please enter valid upto date" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Contact Person Mobile</label>

                                <asp:TextBox ID="txtContactPersonMobile" runat="server" CssClass="form-control" placeholder="Contact Person Mobile"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="fontcolour" runat="server" ControlToValidate="txtContactPersonMobile" ErrorMessage="Please enter Contact Person Mobile" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Website</label>

                                <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" placeholder="Website"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="fontcolour" runat="server" ControlToValidate="txtWebsite" ErrorMessage="Please enter Website" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Password</label>

                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password"></asp:TextBox>
                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="fontcolour" runat="server" ControlToValidate="txtWebsite" ErrorMessage="Please enter Website" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                            </div>

                            <%--   <div class="col-md-4 form-group">
                                <label for="exampleInputEmail" class="form-control-label">filePass</label>
                                <asp:TextBox ID="txtfilePass" runat="server" class="form-control" placeholder="filePass" TextMode="Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="fontcolour" runat="server" ControlToValidate="txtfilePass" ErrorMessage="Please enter valid upto date" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </div>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">Property Type</label>

                                <asp:DropDownList ID="ddlPropertyType" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">State Name</label>

                                <asp:DropDownList ID="ddlStateId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateId_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">District Name</label>

                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">City Name</label>

                                <asp:DropDownList ID="ddlCityId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCityId_SelectedIndexChanged"></asp:DropDownList>
                            </div>

                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">Police Station Name</label>

                                <asp:DropDownList ID="ddlPoliceStation" runat="server" CssClass="form-control dropdown-custom" >
                                    
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputNoOfRoom" class="form-control-label">No. of Room</label>

                                <asp:TextBox ID="txtNoOfRoom" runat="server" CssClass="form-control" placeholder="No. of Room"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="fontcolour" ValidationExpression="^[1-9][0-9]*$" runat="server" ControlToValidate="txtNoOfRoom" ErrorMessage="Please enter valid No. of Room" ValidationGroup="save"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 ">
                                <div class="" id="chkremember">
                                    <asp:CheckBox ID="chkActive" runat="server" />
                                    <label class="m-b-10">
                                        Active
                                   
                                    </label>
                                </div>
                            </div>
                            <div class="col-md-4 ">
                                <div class="col-md-4 form-group">
                                    <label for="exampleInputEmail" class="form-control-label">Subscribed</label>

                                    <asp:TextBox ID="txtSubscribed" runat="server" CssClass="form-control" placeholder="Subscribed"></asp:TextBox>
                                </div>
                            </div>

                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Save" OnClick="btnSubmit_Click" ValidationGroup="save" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Cancel" OnClick="btnCancel_Click" />
                        </div>
                        <div class="row">
                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">Aadhar Front</label></br>
                                <asp:FileUpload ID="FileUploadAadharFront" runat="server" /></br></br>
                                <asp:Image ID="Image1" runat="server" ImageUrl="https://s3.amazonaws.com/github/ribbons/forkme_right_red_aa0000.png" Height="200" Width="200" alt="Aadhar Front" />
                                <%--<img runat="server" id="imgHtlFrunt" src="https://s3.amazonaws.com/github/ribbons/forkme_right_red_aa0000.png" height="200" width="200" alt="Aadhar Frount">--%>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">Aadhar Back</label></br>
                                <asp:FileUpload ID="FileUploadAadharBack" runat="server" /></br></br>
                                <asp:Image ID="Image2" runat="server" ImageUrl="https://s3.amazonaws.com/github/ribbons/forkme_right_red_aa0000.png" Height="200" Width="200" alt="Aadhar Back" />
                                <%--<img runat="server" id="imgHtlBack" src="https://s3.amazonaws.com/github/ribbons/forkme_right_red_aa0000.png" height="200" width="200" alt="Aadhar Back">--%>
                            </div>
                            <div class="col-md-4 form-group">
                                <label for="exampleInputPassword" class="form-control-label">Gumasta</label></br>
                                <asp:FileUpload ID="FileUploadGumasta" runat="server" /></br></br>
                                <asp:Image ID="Image3" runat="server" ImageUrl="https://s3.amazonaws.com/github/ribbons/forkme_right_red_aa0000.png" Height="200" Width="200" alt="Gumasta" />
                                <%--<img runat="server" id="imgHtlGumasta" src="https://s3.amazonaws.com/github/ribbons/forkme_right_red_aa0000.png" height="200" width="200" alt="Aadhar Back">--%>
                            </div>
                            <div class="col-md-4 form-group">
                                <asp:Button ID="btnSaveImage" runat="server" Text="SaveImage" CssClass="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Save" OnClick="btnSaveImage_Click" />
                                <%--<asp:Button ID="btnCancelImage" runat="server" Text="Cancel" CssClass="btn btn-success waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Cancel" OnClick="btnCancel_Click" />--%>
                            </div>
                        </div>
                    </div>

                    <div class="card-block">

                        <div class="row">
                            <!--Basic Form starts-->
                            <div class="col-md-12 grid-margin stretch-card mx-auto">
                                <div class="box box-primary">
                                    <div class="card-body">
                                        <div class="box-body">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail" class="form-control-label">कमरे की श्रेणी</label>
                                                        <asp:TextBox ID="txtRoomCategory" runat="server" CssClass="form-control" placeholder="कमरे की श्रेणी"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="fontcolour" runat="server" ControlToValidate="txtRoomCategory" ErrorMessage="कृपया कमरे की श्रेणी दर्ज करें" ValidationGroup="Catsave" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="hdnidHotelRoomCategory" runat="server" Value='' />
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label for="exampleInputEmail" class="form-control-label">मूल्य</label>
                                                        <asp:TextBox ID="txtRoomPrice" runat="server" CssClass="form-control" placeholder="मूल्य"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="fontcolour" runat="server" ControlToValidate="txtRoomPrice" ErrorMessage="कृपया कमरे का मूल्य दर्ज करें" ValidationGroup="Catsave" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <%--  <label for="exampleInputEmail" class="form-control-label">मूल्य</label>
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="मूल्य"></asp:TextBox>--%>
                                                        <div style="float: right">

                                                            <asp:Button ID="btnSaveCategory" runat="server" Text="Save" CssClass="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Save" OnClick="btnSaveCategory_Click" ValidationGroup="Catsave" />
                                                            <asp:Button ID="btnCancelCategory" runat="server" Text="Cancel" CssClass="btn btn-default waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Cancel" OnClick="btnCancelCategory_Click" ValidationGroup="Catsave_1" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="box-body">
                                            <asp:Repeater ID="rptCategory" runat="server" OnItemCommand="rptCategory_ItemCommand">
                                                <HeaderTemplate>
                                                    <table id="example3" class="table table-bordered table-striped" style="width: 100%">
                                                        <thead class="Guestthead">
                                                            <tr>
                                                                <th class="Guestth">S. No.</th>
                                                                <th class="Guestth">कमरे की श्रेणी</th>
                                                                <th class="Guestth">मूल्य</th>
                                                                <th class="Guestth"></th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="Guesttd"><%# Container.ItemIndex + 1 %>
                                                            <asp:HiddenField ID="hdnidHotelRoomCategory" runat="server" Value='<%#Eval("idHotelRoomCategory")%>' />
                                                            <asp:HiddenField ID="hdnCategoryName" runat="server" Value='<%#Eval("CategoryName")%>' />
                                                            <asp:HiddenField ID="hdniPrice" runat="server" Value='<%#Eval("iPrice")%>' />
                                                        </td>
                                                        <td class="Guesttd"><%#Eval("CategoryName")%></td>
                                                        <td class="Guesttd"><%#Eval("iPrice")%></td>
                                                        <td>

                                                            <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-guestsuccess waves-effect waves-light btnGuest" data-toggle="tooltip" data-placement="top" title="Edit" CommandArgument='<%# Eval("idHotelRoomCategory") %>' CommandName="Update" />
                                                            <asp:Button ID="Button3" runat="server" Text="Delete" class="btn btn-default waves-effect waves-light btnAction" data-toggle="tooltip" data-placement="top" title="Delete" CommandArgument='<%# Eval("idHotelRoomCategory") %>' CommandName="Delete" />
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                </table>
                                               
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
            <!--Basic Form ends-->

        </div>
        <div class="modal fade modal-flex" id="basic-form-Modal1" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title">Message</h5>
                    </div>
                    <!-- end of modal-header -->
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i>Are you sure to delete the records?
                   
                    </div>
                    <!-- end of modal-body -->
                    <div class="modal-footer">
                        <a href="frmHotel.aspx" class="btn btn-default me-2">No</a>
                        <asp:Button ID="Button1" runat="server" Text="Yes" class="btn btn-guestsuccess me-2" data-toggle="tooltip" data-placement="top" title="Yes" OnClick="Button3_Click" />
                    </div>
                </div>
                <!-- end of modal-content -->
            </div>
            <!-- end of modal-dialog -->
        </div>
        <!-- end of modal -->
        <div class="modal fade modal-flex" id="basic-form-Modal2" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title">Message</h5>
                    </div>
                    <!-- end of modal-header -->
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i>Are you sure to submit the records?
                   
                    </div>
                    <!-- end of modal-body -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">No</span>
                        </button>
                        <asp:Button ID="Button4" runat="server" Text="Yes" class="btn btn-guestsuccess me-2" OnClick="Button4_Click" />
                    </div>
                </div>
                <!-- end of modal-content -->
            </div>
            <!-- end of modal-dialog -->
        </div>
        <!-- end of modal -->
        <div class="modal fade modal-flex" id="basic-form-Modal3" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title">Message</h5>
                    </div>
                    <!-- end of modal-header -->
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i>Are you sure to submit the records?
                   
                    </div>
                    <!-- end of modal-body -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">No</span>
                        </button>
                        <asp:Button ID="Button5" runat="server" Text="Yes" class="btn btn-guestsuccess me-2" />
                    </div>
                </div>
                <!-- end of modal-content -->
            </div>
            <!-- end of modal-dialog -->
        </div>
        <!-- end of modal -->
    </div>
    <script type="text/javascript">  
        function QuestionDeleteData(body) {
            $("#basic-form-Modal1 .modal-body").html(body);
            $("#basic-form-Modal1").modal('show');
            return false;
        }
        function QuestionAddData(body) {
            $("#basic-form-Modal2 .modal-body").html(body);
            $("#basic-form-Modal2").modal('show');
            return false;
        }
        function SaveGuestData(body) {
            $("#basic-form-Modal3 .modal-body").html(body);
            $("#basic-form-Modal3").modal('show');
            return false;
        }
        $(document).ready(function () {
            $('#txtValidUpto').datepicker({
                dateFormat: 'dd/MM/yy',
                monthNames: ["Jan", "Feb", "Mar",
                    "April", "May", "Jun", "Jul",
                    "Aug", "Sep", "Oct", "Nov", "Dec"]
            })
        });
    </script>
</asp:Content>


