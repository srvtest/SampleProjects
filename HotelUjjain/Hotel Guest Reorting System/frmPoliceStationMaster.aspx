<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmPoliceStationMaster.aspx.cs" Inherits="Hotel_Guest_Reporting_System.frmPoliceStationMaster" Async="true" %>

<%@ MasterType VirtualPath="~/mainHome.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .fontcolour {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdnId" runat="server" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdPoliceStationMasterId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmPoliceStationMaster.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnluserList">
            <div class="col-sm-12">
                <!-- Contextual classes table starts -->
                <div class="card" runat="server" id="tblPoliceStationMaster">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl3" runat="server"></asp:Label></h5>
                        <div class="f-right">
                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="New" OnClick="btnNew_Click" />
                        </div>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-sm-12 table-responsive">
                                <asp:Repeater ID="RptUser" runat="server" OnItemCommand="RptUser_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered" style="width: 100%" id="example">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Police Station Name</th>
                                                    <th>City Name</th>
                                                    <th>District Name</th>
                                                    <th>State Name</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td>
                                                <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("PoliceStationName")%>'></asp:Label>
                                            </td>
                                            <td><%#Eval("CityName")%></td>
                                            <td><%#Eval("DistrictName")%></td>
                                            <td><%#Eval("stateName")%></td>
                                            <td>
                                                <asp:HiddenField ID="hdId" runat="server" Value='<%# Eval("idPoliceStationMaster") %>' />

                                                <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Edit" CommandArgument='<%# Eval("idPoliceStationMaster") %>' CommandName="Update" />
                                                <asp:Button ID="Button2" runat="server" Text="Delete" class="btn btn-default waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Delete" CommandArgument='<%# Eval("idPoliceStationMaster") %>' CommandName="Delete" />
                                                <asp:Button ID="Button3" runat="server" Text="View" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="View" CommandArgument='<%# Eval("idPoliceStationMaster") %>' CommandName="View" />
                                                <asp:Button ID="Button5" runat="server" Text="Reset Password" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="View" CommandArgument='<%# Eval("idPoliceStationMaster") %>' CommandName="Send" />
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
        <div class="row" runat="server" id="Div1">
            <!--Basic Form starts-->
            <div class="col-lg-6">
                <div class="card" runat="server" id="pnlUser">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl4" runat="server"></asp:Label></h5>
                    </div>


                    <div class="card-block">
                        <div class="row">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">State Name</label>


                            <asp:DropDownList ID="ddlStateId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateId_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="ddlStateId" InitialValue="0" ErrorMessage="Please select state" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">District Name</label>


                            <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="ddlDistrict" InitialValue="0" ErrorMessage="Please select District" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">City Name</label>


                            <asp:DropDownList ID="ddlCityId" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="ddlCityId" InitialValue="0" ErrorMessage="Please select city" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Police Station Name</label>


                            <asp:TextBox ID="txtPoliceStationname" runat="server" CssClass="form-control" placeholder="Enter Police Station name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="txtPoliceStationname" ErrorMessage="Please enter police station name" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>




                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Mobile number</label>
                            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-control" placeholder="Enter Mobile number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" runat="server" ControlToValidate="txtMobile" ErrorMessage="Please enter police station mobile number" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Landline number</label>
                            <asp:TextBox ID="txtLandline" runat="server" CssClass="form-control" placeholder="Enter Landline number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" runat="server" ControlToValidate="txtLandline" ErrorMessage="Please enter police station landline number" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="fontcolour" runat="server" ControlToValidate="txtEmail" ErrorMessage="Please enter police station email" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
    <label for="exampleInputPassword" class="form-control-label">Password</label>
    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
</div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Save" OnClick="btnSubmit_Click" ValidationGroup="save" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
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
                        <a href="frmPoliceStationMaster.aspx" class="btn btn-default me-2">No</a>
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
    </script>
</asp:Content>
