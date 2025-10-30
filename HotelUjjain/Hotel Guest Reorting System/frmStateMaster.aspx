<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmStateMaster.aspx.cs" Inherits="Hotel_Guest_Reporting_System.frmStateMaster" %>

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
        <asp:HiddenField ID="hdId" runat="server" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdStateId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmZoneMaster.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnluserList">
            <div class="col-sm-12">
                <!-- Contextual classes table starts -->
                <div class="card" runat="server" id="tblState">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl3" runat="server"></asp:Label></h5>
                        <div class="f-right">
                            <asp:Button ID="btnNew" runat="server" lng-tag="New" Text="New" class="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="New" OnClick="btnNew_Click" />
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
                                                    <th>
                                                        <asp:Label ID="lblStateName" runat="server" Text="State Name"></asp:Label></th>
                                                    <th>
                                                        <asp:Label ID="lblCountryName" runat="server" Text="Country Name"></asp:Label></th>
                                                    <th>
                                                        <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td>
                                                <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("stateName")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCName" runat="server" ClientIDMode="Static" Text='<%#Eval("countryName")%>'></asp:Label></td>
                                            <td>
                                                <asp:HiddenField ID="hdId" runat="server" Value='<%# Eval("StateID") %>' />
                                                <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Edit" CommandName="Update" />
                                                <asp:Button ID="Button2" runat="server" Text="Delete" class="btn btn-default waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Delete" CommandName="Delete" />
                                                <asp:Button ID="Button3" runat="server" Text="View" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="View" CommandName="View" />
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
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Country Name</label>
                            <asp:DropDownList ID="ddlCountryId" runat="server" CssClass="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="ddlCountryId" ErrorMessage="Please select country" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">State Name</label>
                            <asp:TextBox ID="txtStatename" runat="server" CssClass="form-control" placeholder="Enter state name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="txtStatename" ErrorMessage="Please enter state name" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="chkme" class="form-check-label">
                                <%--<input type="checkbox" class="form-check-input" id="chkme">--%>
                                <asp:CheckBox ID="chkme" CssClass="form-check-input" type="checkbox" runat="server" />
                                Active
                            </label>
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
                        <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
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
                        <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
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
