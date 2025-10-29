<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="DiscountCoupon.aspx.cs" Inherits="Ecommerce.DiscountCoupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
<script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <style>
        .floatRight {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnDiscountCouponId" runat="server" Value="0" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Discount Coupon</h1>
        <p class="mb-4">Discount Coupon Description</p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblDiscountCoupon">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Discount Coupon Details</h6>
                <asp:Button ID="btnDiscountCoupon" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnDiscountCoupon_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="rptDiscountCoupon" runat="server" OnItemCommand="rptDiscountCoupon_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>From</th>
                                        <th>To</th>
                                        <th>Coupon Value</th>
                                        <th>Min Cart Value</th>
                                        <th>Max Discount Value</th>
                                        <th>Country</th>
                                        <th>Description</th>
                                        <th>Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblFrom" runat="server" Text='<%#Eval("PeriodFrom")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTo" runat="server" Text='<%#Eval("PeriodTo")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCouponValue" runat="server" Text='<%#Eval("CouponValue")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMinCartValue" runat="server" Text='<%#Eval("MinCartValue")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMaxDiscountValue" runat="server" Text='<%#Eval("MaxDisCountValue")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("sCountryName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                </td>
                                <td>
                                    <a href="#" class="btn btn-<%# Convert.ToBoolean(Eval("bActive")) ? "info" : "secondary"  %> btn-icon-split">
                                        <span class="icon text-white-50">
                                            <i class="fas fa-arrow-right"></i>
                                        </span>
                                        <span class="text">
                                            <asp:Label ID="lblStatus" runat="server" ClientIDMode="Static" Text='<%# Convert.ToBoolean(Eval("bActive")) ? "Active":"InActive" %>'></asp:Label></span>
                                    </a>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idCoupon") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-circle btn-sm" CommandArgument='<%#Eval("idCoupon") %>' OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>
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

        <div class="card shadow mb-4" runat="server" id="frmDiscountCoupon">
            <div class="card-header py-3">
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Name</label>
                        <br />
                        <asp:TextBox ID="txtName" runat="server" class="form-control form-control-user" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Coupon Value</label>
                        <br />
                        <asp:TextBox ID="txtCouponValue" runat="server" class="form-control form-control-user" placeholder="Coupon Value"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ForeColor="Red" ControlToValidate="txtCouponValue" runat="server" ErrorMessage="Please Enter coupon value." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Period From</label>
                        <br />
                        <asp:TextBox ID="txtFrom" runat="server" class="form-control form-control-user date form_datetime" placeholder="From Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ForeColor="Red" ControlToValidate="txtFrom" runat="server" ErrorMessage="Please Enter from date." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Period To</label>
                        <br />
                        <asp:TextBox ID="txtTo" runat="server" class="form-control form-control-user date to_datetime" placeholder="To Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtTo" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter to date." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Min Cart Value</label>
                        <br />
                        <asp:TextBox ID="txtMinCartValue" runat="server" class="form-control form-control-user" placeholder="Min Cart Value"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ForeColor="Red" ControlToValidate="txtMinCartValue" runat="server" ErrorMessage="Please Enter Min Cart Value." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Max Discount Value</label>
                        <br />
                        <asp:TextBox ID="txtMaxDiscountValue" runat="server" class="form-control form-control-user" placeholder="Max Discount Value"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtMaxDiscountValue" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter Max Discount Value." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Country</label>
                        <br />
                        <asp:DropDownList ID="ddlCountry" CssClass="form-control form-control-user" runat="server" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Description</label>
                        <br />
                        <asp:TextBox ID="txtDescription" runat="server" class="form-control form-control-user" placeholder="Description"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chkStatus" runat="server" class="custom-control-input" ClientIDMode="Static" />
                        <label class="custom-control-label" for="chkStatus"></label>
                        <asp:Label ID="lblbStatus" runat="server" ClientIDMode="Static">Active</asp:Label>
                    </div>
                </div>
                <asp:Button ID="btnSaveDiscountCoupon" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSaveDiscountCoupon_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnCancelDiscountCoupon" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancelDiscountCoupon_Click" />
            </div>
        </div>
    </div>

<script>
    $(document).ready(function () {
        alert(4);
        $('.date').datepicker();
    });
</script>
</asp:Content>
