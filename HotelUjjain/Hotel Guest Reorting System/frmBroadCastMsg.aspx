<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmBroadCastMsg.aspx.cs" Inherits="Hotel_Guest_Reporting_System.frmBroadCastMsg" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdnId" runat="server" />
        <asp:HiddenField ID="hdId" runat="server" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdBroadCastMsgId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmBroadCastMsg.aspx">
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
                                                        <asp:Label ID="lblMsg" runat="server" Text="Msg"></asp:Label></th>
                                                    <th>
                                                        <asp:Label ID="Label1" runat="server" Text="Display From"></asp:Label></th>
                                                    <th>
                                                        <asp:Label ID="Label2" runat="server" Text="Display To"></asp:Label></th>
                                                    <th>
                                                        <asp:Label ID="lblCreatedOn" runat="server" Text="CreatedOn"></asp:Label></th>
                                                     <th>Status</th>
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
                                                <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("Msg")%>'></asp:Label>
                                            </td>
                                            <td>
                                                <%# Eval("DisplayFrom").ToString() == "1/1/0001 12:00:00 AM" ? "" : String.Format("{0:dd/MM/yy HH:mm}", Eval("DisplayFrom")) %>
                                            <td>
                                                <%# Eval("DisplayTo").ToString() == "1/1/0001 12:00:00 AM" ? "" : String.Format("{0:dd/MM/yy HH:mm}", Eval("DisplayTo")) %>
                                            </td>
                                            <td>
                                                <%# Eval("CreatedOn").ToString() == "1/1/0001 12:00:00 AM" ? "" : String.Format("{0:dd/MM/yy HH:mm}", Eval("CreatedOn")) %>
                                            <td>
                                                <a href="#" class="btn <%# Eval("bActive").ToString() == "True" ? "Active" : "Inactive" %>">

                                                    <span class="icon text-white-50">
                                                        <i class="fas fa-arrow-right"></i>
                                                    </span>
                                                    <span class="text">
                                                        <asp:Label ID="LblStatus" runat="server" ClientIDMode="Static" Text='<%# (Convert.ToString(Eval("bActive"))=="True" ? "Active" :"InActive") %>'></asp:Label></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hdBroadCastID" runat="server" Value='<%# Eval("BroadCastMsgID") %>' />
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
                            <label for="exampleInputPassword" class="form-control-label">Message</label>
                            <asp:TextBox ID="txtMsg" runat="server" CssClass="form-control" placeholder="Enter Message"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="txtMsg" ErrorMessage="Please enter Message" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail" class="form-control-label">Display From</label>
                            <asp:TextBox ID="txtDisplayFrom" runat="server" CssClass="form-control" placeholder="DisplayFrom" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" runat="server" ControlToValidate="txtDisplayFrom" ErrorMessage="Please enter Display From date" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail" class="form-control-label">Display To</label>
                            <asp:TextBox ID="txtDisplayTo" runat="server" CssClass="form-control" placeholder="DisplayTo" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="txtDisplayTo" ErrorMessage="Please enter Display To date" ValidationGroup="save"></asp:RequiredFieldValidator>
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
                        <a href="frmDistrictMaster.aspx" class="btn btn-default me-2">No</a>
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
        $(document).ready(function () {
            $('#txtDisplayFrom').datepicker({
                dateFormat: 'dd/MM/yy',
                minDate: 0,
                monthNames: ["Jan", "Feb", "Mar",
                    "April", "May", "Jun", "Jul",
                    "Aug", "Sep", "Oct", "Nov", "Dec"]
            })
            $('#txtDisplayTo').datepicker({
                dateFormat: 'dd/MM/yy',
                monthNames: ["Jan", "Feb", "Mar",
                    "April", "May", "Jun", "Jul",
                    "Aug", "Sep", "Oct", "Nov", "Dec"]
            })
        });
    </script>
</asp:Content>
