<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="CustomerOrder.aspx.cs" Inherits="Ecommerce.CustomerOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css">
    <style>
        .floatRight {
            float: right;
        }

        .highlight {
            font-weight: bold;
            color: black;
        }

        .fontcolour {
            color: red;
        }

        .fontcolourmargin {
            margin-left: 86px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdIdCustomerOrder" runat="server" Value="0" />
        <asp:HiddenField ID="hdDescription" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdApprove" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdEmail" runat="server" ClientIDMode="Static" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Customer Order</h1>
        <p class="mb-4">Customer Order description</p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblCustomerOrder">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Customer Order Details</h6>
                <%--    <asp:Button ID="btnCustomerOrder" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnCustomerOrder_Click" />--%>
                <div style="float: right">
                    <asp:FileUpload ID="FileUpload1" runat="server" accept="application/vnd.ms-excel,application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" />
                    <asp:Button ID="btnUploadExcel" runat="server" Text="Upload Excel" CssClass="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm" Style="padding: 7px;" OnClick="btnUploadExcel_Click" />
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstCustomerOrder" runat="server" OnItemCommand="lstCustomerOrder_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Order No</th>
                                        <th>Name</th>
                                        <%-- <th>Order</th>--%>
                                        <%-- <th>Approval</th>--%>
                                        <%--  <th>Address</th>--%>
                                        <th>Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" ClientIDMode="Static" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblOrderNo" runat="server" ClientIDMode="Static" Text='<%#Eval("sOrderNo")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <%-- <td>
                                    <asp:Label ID="lblOrder" runat="server" ClientIDMode="Static" Text='<%# Eval("dtOrder","{00:dd MMM yyyy}") %>'></asp:Label>
                                </td>--%>
                                <%-- <td>
                                    <asp:Label ID="lblApproval" runat="server" ClientIDMode="Static" Text='<%# Eval("dtApproval","{00:dd MMM yyyy}") %>'></asp:Label>
                                </td>--%>
                                <%--  <td>
                                    <asp:Label ID="lblAddress" runat="server" ClientIDMode="Static" Text='<%#Eval("sAddress1")%>'></asp:Label>
                                </td>--%>
                                <td>
                                    <asp:Label ID="lblStatus" runat="server" ClientIDMode="Static" Text='<%#
                                         Convert.ToString(Eval("bStatus"))== "0" ? "Pending" :  
                                          Convert.ToString(Eval("bStatus"))== "1"? "Approved":
                                        Convert.ToString(Eval("bStatus"))== "2" ? "Reject":
                                        Convert.ToString(Eval("bStatus"))== "3" ? "Shipped":
                                        Convert.ToString(Eval("bStatus"))== "4" ? "Delivered": "User Cancel"
                                        
                                        
                                        %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idCustomerOrder") %>' />
                                    <asp:HiddenField ID="hdnidCustomer" runat="server" Value='<%#Eval("idCustomer") %>' />
                                    <asp:HiddenField ID="hdnsOrderNo" runat="server" Value='<%#Eval("sOrderNo") %>' />
                                    <asp:HiddenField ID="hdndtOrder" runat="server" Value='<%#Eval("dtOrder") %>' />
                                    <asp:HiddenField ID="hdndtApproval" runat="server" Value='<%#Eval("dtApproval") %>' />
                                    <asp:HiddenField ID="hdnsName" runat="server" Value='<%#Eval("sName") %>' />
                                    <asp:HiddenField ID="hdnEmail" runat="server" Value='<%#Eval("Email") %>' />
                                    <asp:HiddenField ID="hdnMobile" runat="server" Value='<%#Eval("Mobile") %>' />
                                    <asp:HiddenField ID="hdnPinCode" runat="server" Value='<%#Eval("PinCode") %>' />
                                    <asp:HiddenField ID="hdnsAddress1" runat="server" Value='<%#Eval("sAddress1") %>' />
                                    <asp:HiddenField ID="hdnsAddress2" runat="server" Value='<%#Eval("sAddress2") %>' />
                                    <asp:HiddenField ID="hdnsCity" runat="server" Value='<%#Eval("sCity") %>' />
                                    <asp:HiddenField ID="hdnsState" runat="server" Value='<%#Eval("sState") %>' />
                                    <asp:HiddenField ID="hdnsLandMark" runat="server" Value='<%#Eval("sLandMark") %>' />
                                    <asp:HiddenField ID="hdnAddressType" runat="server" Value='<%#Eval("AddressType") %>' />
                                    <asp:HiddenField ID="hdnAlternateNo" runat="server" Value='<%#Eval("AlternateNo") %>' />
                                    <asp:HiddenField ID="hdnCouponCode" runat="server" Value='<%#Eval("CouponCode") %>' />
                                    <asp:HiddenField ID="hdnbStatus" runat="server" Value='<%#Eval("bStatus") %>' />
                                    <asp:HiddenField ID="hdntotalAmount" runat="server" Value='<%#Eval("totalAmount") %>' />
                                    <asp:HiddenField ID="hdnApproveReject" runat="server" Value='<%#Eval("ApproveReject") %>' />
                                    <asp:HiddenField ID="hdnTotalProduct" runat="server" Value='<%#Eval("TotalProduct") %>' />
                                    <asp:HiddenField ID="hdnTotalQuantity" runat="server" Value='<%#Eval("TotalQuantity") %>' />
                                    <asp:HiddenField ID="hdnComment" runat="server" Value='<%#Eval("Comment") %>' />
                                    <asp:HiddenField ID="hdnSpComment" runat="server" Value='<%#Eval("ShippingComment") %>' />
                                    <asp:HiddenField ID="hdnTrackingNumber" runat="server" Value='<%#Eval("TrackingNumber") %>' />
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="CatEdit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idCustomerOrder") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkShipped" runat="server" CommandName="CatShipped" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idCustomerOrder")%>' Visible='<%# (Convert.ToString(Eval("bStatus")) =="1" || Convert.ToString(Eval("bStatus")) =="3")? true:false %>'><i class="fas fa-shipping-fast"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelivered" runat="server" CommandName="CatDelivered" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idCustomerOrder") %>' Visible='<%# (Convert.ToString(Eval("bStatus")) =="3")? true:false %>' OnClientClick="return confirm('Is order deliverd successfully?')"><i class="fas fa-deezer"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="CatDelete" CssClass="btn btn-danger btn-circle btn-sm" CommandArgument='<%#Eval("idCustomerOrder") %>' OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>

                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                   <%-- <tfoot>
                                        <tr>
                                            <th>Name</th>
                                            <th>Salary</th>
                                        </tr>
                                    </tfoot>--%>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>

        <div class="card shadow mb-4" runat="server" id="frmCustomerOrder">
            <div class="card-header py-3">
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
                <%-- <asp:Button ID="btnLogin" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancel_Click" />--%>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Customer Id :</label>
                        <asp:Label ID="lblidCustomer" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Order No :</label>
                        <asp:Label ID="lblOrder" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Name :</label>
                        <asp:Label ID="lblNames" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Email :</label>
                        <asp:Label ID="lblEmail" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Mobile :</label>
                        <asp:Label ID="lblMobile" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">PinCode :</label>
                        <asp:Label ID="lblPinCode" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Address 1 :</label>
                        <asp:Label ID="lblsAddress1" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Address 2 :</label>
                        <asp:Label ID="lblsAddress2" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">City :</label>
                        <asp:Label ID="lblsCity" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">State :</label>
                        <asp:Label ID="lblsState" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">LandMark :</label>
                        <asp:Label ID="lblsLandMark" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Address Type :</label>
                        <asp:Label ID="lblAddressType" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Alternate No :</label>
                        <asp:Label ID="lblAlternateNo" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Coupon Code :</label>
                        <asp:Label ID="lblCouponCode" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Status :</label>
                        <asp:Label ID="lblbStatus" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Total Amount :</label>
                        <asp:Label ID="lbltotalAmount" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <%--<div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Total Product :</label>
                        <asp:Label ID="lblTotalProduct" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Total Quantity :</label>
                        <asp:Label ID="lblTotalQuantity" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>--%>
                </div>
                <div class="form-group row">
                    <div class="table-responsive">
                        <asp:Repeater ID="rptrProductDetails" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>Sr. No.</th>
                                            <th>Name</th>
                                            <th>Product Price</th>
                                            <th>Purchase Price</th>
                                            <th>Discount</th>
                                            <th>Shipping Charge</th>
                                            <th>Quantity</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSerialNo" runat="server" ClientIDMode="Static" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductPrice" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("ProductPrice")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPurchasePrice" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("PurchasePrice") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDiscount" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("Discount")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblShippingCharge" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("ShippingCharge")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblQuantity" runat="server" ClientIDMode="Static" Text='<%#Eval("Quantity")%>'></asp:Label>
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
                <div class="form-group row">
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <label class="highlight">Approve / Reject :</label>
                        <asp:DropDownList ID="ddApproveReject" runat="server" class="vpb_dropdown">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Approve" Value="Approve"></asp:ListItem>
                            <asp:ListItem Text="Reject" Value="Reject"></asp:ListItem>
                            <%--    <asp:ListItem Text="Pending" Value="Pending"></asp:ListItem>
                            <asp:ListItem Text="Delivered" Value="Delivered"></asp:ListItem>--%>
                        </asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="ddApproveReject" runat="server" ErrorMessage="Please select Approve / Reject." ValidationGroup="save"></asp:RequiredFieldValidator>
                        <%--<asp:Label ID="lblmess" runat="server"></asp:Label>--%>
                    </div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <asp:Label ID="lblComment" class="highlight" Style="position: absolute;" ClientIDMode="Static" runat="server" Text="Comment :"></asp:Label>
                        <asp:TextBox ID="txtComment" Rows="5" CssClass="" Style="margin-left: 85px; width: 100%;" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtComment" runat="server" ErrorMessage="Please enter Comment." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <asp:Button ID="btnSave" runat="server" Text="Submit" class="btn btn-success btn-use" OnClick="btnSave_Click" ValidationGroup="save" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow mb-4" runat="server" id="pnlShipping">
            <div class="card-header py-3">
                <asp:Label ID="lblOrderNo" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Order No :</label>
                        <asp:Label ID="lblSOrderNo" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Name :</label>
                        <asp:Label ID="lblSname" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Email :</label>
                        <asp:Label ID="lblSEmail" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Mobile :</label>
                        <asp:Label ID="lblSMobile" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label class="highlight">Address :</label>
                        <asp:Label ID="lblSAddress" ClientIDMode="Static" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="table-responsive">
                        <asp:Repeater ID="rptProductDetail" runat="server">
                            <HeaderTemplate>
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>Sr. No.</th>
                                            <th>Name</th>
                                            <th>Product Price</th>
                                            <th>Purchase Price</th>
                                            <th>Discount</th>
                                            <th>Shipping Charge</th>
                                            <th>Quantity</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSerialNo" runat="server" ClientIDMode="Static" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProductPrice" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("ProductPrice")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPurchasePrice" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("PurchasePrice") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDiscount" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("Discount")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblShippingCharge" runat="server" ClientIDMode="Static" Text='<%# Eval("Currency") + ". " + Eval("ShippingCharge")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblQuantity" runat="server" ClientIDMode="Static" Text='<%#Eval("Quantity")%>'></asp:Label>
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
                <div class="form-group row">
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <label class="highlight">Shipped :</label>
                        <asp:CheckBox ID="chkShipped" runat="server" />
                        <br />
                    </div>
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <asp:Label ID="Label18" class="highlight" Style="position: absolute;" ClientIDMode="Static" runat="server" Text="Comment :"></asp:Label>
                        <asp:TextBox ID="txtShipping" CssClass="" Style="margin-left: 85px; width: 100%;" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtShipping" runat="server" ErrorMessage="Please enter Comment." ValidationGroup="Shipped"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <asp:Label ID="Label2" class="highlight" Style="position: absolute;" ClientIDMode="Static" runat="server" Text="Tracking Numbers :"></asp:Label>                        
                        <asp:TextBox ID="txtTrackingNumbers" CssClass="" Style="margin-left: 150px;" runat="server" ></asp:TextBox>  
                         <br />                     
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="txtTrackingNumbers" runat="server" ErrorMessage="Please enter Tracking Numbers." ValidationGroup="Shipped"></asp:RequiredFieldValidator>
                    </div>                 
                </div>
                <div class="form-group row">
                    <div class="col-sm-4 mb-3 mb-sm-0">
                        <asp:Button ID="btnShipped" runat="server" Text="Submit" class="btn btn-success btn-use" OnClick="btnShipped_Click" ValidationGroup="Shipped" />
                        <asp:Button ID="btnSCancel" runat="server" Text="Cancel" class="btn btn-danger" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="TrackingStatusModel" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content" id="invoice-content">
                <div class="modal-header">
                    <h4 class="modal-title">Update Status</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:Repeater ID="rptTrackingStatus" runat="server">
                        <HeaderTemplate>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th>Tracking Number</th>
                                        <th>Status</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("TrackingNumber") %></td>
                                <td><%# Convert.ToBoolean(Eval("ChangedStatus")) ? "Already Changed" : Convert.ToBoolean(Eval("MatchedStatus")) ? "Status changed successfully" : "Not found" %></td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <asp:Label ID="lblMsgTracking" runat="server" Text="Tracking Number is not found." Visible="false"></asp:Label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="vendor/jquery/jquery.min.js"></script>
    <%-- <script src="vendor/datatables/jquery.dataTables.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>

    <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
        data-toggle="modal" data-target="#TrackingStatusModel" data-backdrop="static" data-keyboard="false">
        Launch modal
    </button>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dataTable').DataTable({
                "pagingType": "full_numbers"
            });
            // $('#dataTa').DataTable();
        });
        function ShowTrackingNumberStatus() {
            $("#btnShowPopup").click();
        }
    </script>
    <style type="text/css">
        .modal-body table thead tr th {
            border-top: 0;
        }
    </style>
</asp:Content>
