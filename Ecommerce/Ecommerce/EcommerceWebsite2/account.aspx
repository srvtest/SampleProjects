<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="account.aspx.cs" Inherits="EcommerceWebsite2.account" %>
<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .show-br {
            display: inline;
        }

        .hide-br {
            display: none;
        }

        .user-detail {
            padding-bottom: 10px;
        }

            .user-detail i {
                margin-right: 6px;
            }

        .new-address {
            float: right;
            font-size: 35px;
            line-height: 0.7em;
        }

        div.scroll {
            height: 400px;
            overflow-y: scroll;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
    <asp:HiddenField ID="customerID" runat="server" />
    <!-- breadcrumb area start -->
    <div class="breadcrumb-area">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="breadcrumb-wrap">
                        <nav aria-label="breadcrumb">
                            <ul class="breadcrumb">
                                <li class="breadcrumb-item"><a href="/"><i class="fa fa-home"></i></a></li>
                                <li class="breadcrumb-item active">my-account</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->

    <!-- my account wrapper start -->
    <div class="my-account-wrapper section-padding">
        <div class="container">
            <div class="section-bg-color">
                <div class="row">
                    <div class="col-lg-12">
                        <!-- My Account Page Start -->
                        <div class="myaccount-page-wrapper">
                            <!-- My Account Tab Menu Start -->
                            <div class="row">
                                <div class="col-lg-3 col-md-4">
                                    <div class="myaccount-tab-menu nav" role="tablist">
                                        <%--<a href="#dashboad" data-toggle="tab"><i class="fa fa-dashboard"></i>
                                            Dashboard</a>--%>
                                        <asp:LinkButton ID="btnDashboard" ClientIDMode="Static" OnClick="btnDashboard_Click" runat="server">
                                            <i class="fa fa-dashboard"></i>Dashboard</asp:LinkButton>
                                        <%--<a href="#orders" data-toggle="tab"><i class="fa fa-cart-arrow-down"></i>
                                            Orders</a>--%>
                                        <asp:LinkButton ID="btnOrders" ClientIDMode="Static" OnClick="btnOrders_Click" runat="server">
                                            <i class="fa fa-cart-arrow-down"></i>Orders</asp:LinkButton>
                                        <%-- <a href="#download" data-toggle="tab"><i class="fa fa-cloud-download"></i>
                                            Download</a>--%>
                                        <%--<asp:LinkButton ID="btnDownload" ClientIDMode="Static" OnClick="btnDownload_Click" runat="server">
                                            <i class="fa fa-cloud-download"></i>Download</asp:LinkButton>--%>
                                        <%--<a href="#payment-method" data-toggle="tab"><i class="fa fa-credit-card"></i>
                                            Payment Method</a>--%>
                                        <asp:LinkButton ID="btnPaymentMethod" ClientIDMode="Static" OnClick="btnPaymentMethod_Click" runat="server">
                                            <i class="fa fa-credit-card"></i>Payment Method</asp:LinkButton>
                                        <%--<a href="#address-edit" data-toggle="tab"><i class="fa fa-map-marker"></i>
                                            address</a>--%>
                                        <asp:LinkButton ID="btnAddress" ClientIDMode="Static" OnClick="btnAddress_Click1" runat="server">
                                            <i class="fa fa-map-marker"></i>Address</asp:LinkButton>
                                        <%--<a href="#account-info" data-toggle="tab"><i class="fa fa-user"></i>Account
                                                Details</a>--%>
                                        <asp:LinkButton ID="btnAccountDetails" ClientIDMode="Static" OnClick="btnAccountDetails_Click" runat="server">
                                            <i class="fa fa-user"></i>Account Details</asp:LinkButton>
                                        <a href="../logout.aspx"><i class="fa fa-sign-out"></i>Logout</a>
                                    </div>
                                </div>
                                <!-- My Account Tab Menu End -->

                                <!-- My Account Tab Content Start -->
                                <div class="col-lg-9 col-md-8">
                                    <div class="tab-content" id="myaccountContent">
                                        <!-- Single Tab Content Start -->
                                        <div class="tab-pane fade" id="dashboad" role="tabpanel">
                                            <div class="myaccount-content">
                                                <h5>Dashboard</h5>
                                                <div class="welcome">
                                                    <p>
                                                        Hello, <strong>
                                                            <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label></strong> (If Not <strong>
                                                                <asp:Label ID="lblFullName1" runat="server" Text=""></asp:Label>!</strong><a href="../logout.aspx" class="logout"> Logout</a>)
                                                    </p>
                                                </div>
                                                <p class="mb-0">
                                                    From your account dashboard. you can easily check &
                                                        view your recent orders, manage your shipping and billing addresses
                                                        and edit your password and account details.
                                                </p>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->

                                        <!-- Single Tab Content Start -->
                                        <asp:Panel ID="pnlMyOrder" runat="server">
                                            <div class="tab-pane fade" id="orders" role="tabpanel">
                                                <div class="myaccount-content">
                                                    <h5>Orders</h5>
                                                    <asp:Panel ID="pnlEmptyOrder" runat="server">
                                                        <p class="saved-message">You have not placed any order yet.</p>
                                                    </asp:Panel>
                                                    <div class="myaccount-table table-responsive text-center">
                                                        <asp:Repeater ID="rptOrder" runat="server" OnItemCommand="rptOrder_ItemCommand">
                                                            <HeaderTemplate>
                                                                <table class="table table-bordered" style="width:100%">
                                                                    <thead class="thead-light">
                                                                        <tr>
                                                                            <th>Order</th>
                                                                            <th>Date</th>
                                                                            <th>Status</th>
                                                                            <th>Total</th>
                                                                            <th>View Invoice</th>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:HiddenField ID="hdnidOrder" runat="server" Value='<%#Eval("idCustomerOrder")%>' />
                                                                <tr>
                                                                    <td><%# Convert.ToString(Eval("sOrderNo")) %></td>
                                                                    <td><%#Convert.ToDateTime(Eval("dtOrder")).ToShortDateString()%></td>
                                                                    <td><%#Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Pending ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Pending): 
                                                                        Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Approved? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Approved):
                                                                        Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Reject ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Reject):
                                                                        Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Shipped ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Shipped):
                                                                        Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Delivered ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Delivered): Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.UserCancel) %></td>
                                                                    <td><%=((main_master)this.Page.Master).CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("totalAmount")) %></td>
                                                                    <td>
                                                                        <asp:LinkButton ID="btnInvoice" CssClass="btn btn-sqr" CommandArgument='<%#Eval("idCustomerOrder")%>' runat="server">View Invoice</asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <asp:Repeater ID="rptOrderproduct" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td class="text-center" style="width: 70px"><a href="#">
                                                                                <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>" class="rounded mx-auto d-block"></a></td>
                                                                            <td class="text-left"><a href="../ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></td>
                                                                            <td class="text-right"><%#Eval("Quantity")%></td>
                                                                            <td class="text-right"><%#Eval("sNameCurrency")%><%# Convert.ToDouble(Eval("Quantity"))* Convert.ToDouble(Eval("PurchasePrice"))%></td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </tbody>
                                                    </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                        <!-- start pagination area -->
                                                        <div class="paginatoin-area text-center">
                                                            <ul class="pagination-box">
                                                                <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                                                                    <HeaderTemplate>
                                                                        <li>
                                                                            <asp:LinkButton ID='lnkFirst' class="previous" CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="pe-7s-angle-left"></i>
                                                                            </asp:LinkButton>
                                                                        </li>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <li class='<%# ((ListItem)Container.DataItem).Value.Equals(hdPageNo.Value) ? "active" : string.Empty %>'>
                                                                            <asp:LinkButton ID='lnkPage'
                                                                                CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                                                            </asp:LinkButton>
                                                                        </li>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <li>
                                                                            <asp:LinkButton ID='lnkLast' CommandName="Page" class="next" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="pe-7s-angle-right"></i>
                                                                            </asp:LinkButton>
                                                                        </li>
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </ul>
                                                        </div>
                                                        <!-- end pagination area -->
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <!-- Single Tab Content End -->

                                        <!-- Single Tab Content Start -->
                                        <div class="tab-pane fade" id="payment-method" role="tabpanel">
                                            <div class="myaccount-content">
                                                <h5>Payment Method</h5>
                                                <p class="saved-message">You Can't Save Payment Method yet.</p>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->

                                        <!-- Single Tab Content Start -->
                                        <div class="tab-pane fade" id="address-edit" role="tabpanel">
                                            <div class="myaccount-content">
                                                <h5>Billing Address
                                                    <asp:LinkButton CssClass="new-address" ID="btnNewAddress" OnClick="btnNewAddress_Click" ToolTip="Add new address" runat="server">+</asp:LinkButton>
                                                </h5>
                                                <asp:Panel ID="pnlEmptyAddress" runat="server">
                                                    <p class="saved-message">You have not saved any address.</p>
                                                </asp:Panel>
                                                <div class="row">
                                                    <asp:Repeater ID="rptAddress" runat="server">
                                                        <ItemTemplate>
                                                            <div class="col-lg-4">
                                                                <div class="billing-address">
                                                                    <asp:HiddenField ID="hdnIdCustomerAddress" runat="server" Value='<%# Eval("idCustomerAddress") %>' />
                                                                    <asp:HiddenField ID="hdnAddressType" runat="server" Value='<%# Eval("AddressType") %>' />
                                                                    <asp:HiddenField ID="hdnAlternateNo" runat="server" Value='<%# Eval("AlternateNo") %>' />
                                                                    <address>
                                                                        <h6 style="margin-bottom: 7px;">
                                                                            <strong>
                                                                                <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("sName") %>'></asp:Label></strong>
                                                                            <asp:Label ID="lblDefault" runat="server" Text='<%# (!string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) && Convert.ToInt16(Eval("IsDefaultAddr")) == 1) ? "(Default)" : "" %>'></asp:Label>
                                                                        </h6>
                                                                        <asp:Label ID="lblAddress1" runat="server" Text='<%# Eval("sAddress1") %>'></asp:Label>
                                                                        <span class='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("sAddress1"))) ? "show-br" : "hide-br" %>'>
                                                                            <br />
                                                                        </span>
                                                                        <asp:Label ID="lblAddress2" runat="server" Text='<%# Eval("sAddress2") %>'></asp:Label>

                                                                        <asp:Label ID="lblLandmark" runat="server" Text='<%# Eval("sLandMark") %>'></asp:Label>
                                                                        <span class='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("sLandMark"))) ? "show-br" : "hide-br" %>'>
                                                                            <br />
                                                                        </span>
                                                                        <asp:Label ID="lblCity" runat="server" Text='<%# Eval("sCity")%>'></asp:Label>,<asp:Label ID="lblState" runat="server" Text='<%# Eval("sState") %>'></asp:Label><asp:Label ID="lblPincode" runat="server" Text='<%# " " + Eval("PinCode") %>'></asp:Label><br />
                                                                        <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("CountryName")%>'></asp:Label><br />
                                                                        Phone number:
                                                                        <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label>
                                                                    </address>
                                                                    <div class="address-action">
                                                                        <asp:LinkButton ID="btnEditAddress" OnClick="btnEditAddress_Click" runat="server"><i class="fa fa-edit"></i>Edit</asp:LinkButton>
                                                                        <asp:Label ID="lbl1" runat="server" Text='|'></asp:Label>
                                                                        <asp:LinkButton ID="btnRemove" CommandArgument='<%# Eval("idCustomerAddress") %>' runat="server" OnClick="btnRemove_Click" OnClientClick="return confirm('Are you sure you want to delete the address?');"><i class="fa fa-trash"></i>Remove</asp:LinkButton>
                                                                        <asp:Label ID="lbl2" runat="server" Text='|' Visible='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) || Convert.ToInt16(Eval("IsDefaultAddr")) != 1) ? true : false%>'></asp:Label>
                                                                        <asp:LinkButton ID="btnSetDefault" CommandArgument='<%# Eval("idCustomerAddress") %>' runat="server" OnClick="btnSetDefault_Click" Visible='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) || Convert.ToInt16(Eval("IsDefaultAddr")) != 1) ? true : false%>'><i class="fa fa-shield-alt"></i>Set as default</asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- Single Tab Content End -->

                                        <!-- Single Tab Content Start -->
                                        <div class="tab-pane fade" id="account-info" role="tabpanel">
                                            <div class="myaccount-content">

                                                <h5>Account Details 
                                                <span class="act-edit">(<asp:LinkButton ID="btnAccountEdit" runat="server" OnClick="btnAccountEdit_Click">edit</asp:LinkButton>)</span></h5>
                                                <div class="row">
                                                    <asp:HiddenField ID="hdMessage" runat="server" />
                                                    <div class="col-lg-6 user-detail">
                                                        <i class="fa fa-user"></i>
                                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                                    </div>
                                                    <div class="col-lg-6 user-detail" id="gender" runat="server">
                                                        <i class="fa fa-user"></i>
                                                        <asp:Label ID="lblGender" runat="server" Text=""></asp:Label>
                                                    </div>
                                                    <div class="col-lg-6 user-detail" id="mobile" runat="server">
                                                        <i class="fa fa-phone"></i>
                                                        <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                                    </div>
                                                    <div class="col-lg-6 user-detail">
                                                        <i class="fa fa-envelope"></i>
                                                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- Single Tab Content End -->
                                        </div>
                                        <asp:Panel ID="pnlEditAddress" runat="server" Visible="false">
                                            <div class="add-new-address">
                                                <asp:HiddenField ID="hdnidCustomerAddress" runat="server" />
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtName" class="required">Name</label>
                                                            <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Full Name" ValidationGroup="SAddress"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="SAddress"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtMobile" class="required">Mobile</label>
                                                            <asp:TextBox ID="txtMobile" runat="server" class="required" placeholder="Mobile" ValidationGroup="SAddress"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMobile" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile Number" ValidationGroup="SAddress"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="SAddress" ForeColor="Red" ControlToValidate="txtMobile" ErrorMessage="Please enter valid mobile no." Display="Dynamic" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtAddress1" class="required">Address 1</label>
                                                            <asp:TextBox ID="txtAddress1" runat="server" type="text" placeholder="Address 1" ValidationGroup="SAddress"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAddress1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="SAddress"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtAddress2">Address 2</label>
                                                            <asp:TextBox ID="txtAddress2" runat="server" type="text" placeholder="Address 2(Optional)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtCity" class="required">City</label>
                                                            <asp:TextBox ID="txtCity" runat="server" type="text" placeholder="City" ValidationGroup="SAddress"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCity" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="SAddress"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtState" class="required">State</label>
                                                            <asp:TextBox ID="txtState" runat="server" type="text" placeholder="State" ValidationGroup="SAddress"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtState" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="SAddress"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtCountry">Country</label>
                                                            <asp:TextBox ID="txtCountry" runat="server" type="text" placeholder="Country" Enabled="false"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtPinCode">PinCode</label>
                                                            <asp:TextBox ID="txtPinCode" runat="server" type="text" placeholder="PinCode(Optional)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtLandmark">Land mark</label>
                                                            <asp:TextBox ID="txtLandmark" runat="server" type="text" placeholder="Land mark(Optional)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="postcode" class="required">Address Type</label>
                                                            <asp:RadioButtonList ID="rdbAddressType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="rb-list">
                                                                <asp:ListItem Selected="True" Value="Home" Text="Home"></asp:ListItem>
                                                                <asp:ListItem Text="Office" Value="Office"></asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="txtAlternateContact">Alternate Contact</label>
                                                            <asp:TextBox ID="txtAlternateContact" runat="server" type="text" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <asp:Button ID="btnSaveAddress" class="btn btn-sqr" runat="server" Text="Save Changes" OnClick="btnSaveAddress_Click" ValidationGroup="SAddress" />
                                                            <asp:Button ID="btnCancelAddress" class="btn btn-sqr float-right" runat="server" Text="Cancel" OnClick="btnCancelAddress_Click1" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlEditAccount" runat="server">
                                            <asp:HiddenField ID="hdCurrentPassword" runat="server" />

                                            <div class="account-details-form">
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="first-name" class="required">
                                                                Name</label>
                                                            <asp:TextBox ID="txtFullName" runat="server" type="text" TabIndex="1" placeholder="Full Name" MaxLength="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtFullName" ErrorMessage="Please enter name." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="last-name" class="required">
                                                                Gender</label>
                                                            <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="rb-list">
                                                            </asp:RadioButtonList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="rbGender" ErrorMessage="Please select gender." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="first-name" class="required">
                                                                Email Address</label>
                                                            <asp:TextBox ID="txtREmail" runat="server" type="text" TabIndex="3" placeholder="Email Address" MaxLength="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtREmail" ErrorMessage="Please enter email." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ValidationGroup="send" ForeColor="Red"
                                                                ControlToValidate="txtREmail" ErrorMessage="Please enter valid email." Display="Dynamic"
                                                                ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <label for="last-name" class="required">
                                                                Mobile</label>
                                                            <asp:TextBox ID="txtMobileNum" runat="server" type="text" TabIndex="4" placeholder="Mobile No." MaxLength="25"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtMobileNum" ErrorMessage="Please enter mobile." ValidationGroup="Rsave"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="Rsave" ForeColor="Red"
                                                                ControlToValidate="txtMobileNum" ErrorMessage="Please enter valid mobile no." Display="Dynamic"
                                                                ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$">
                                                            </asp:RegularExpressionValidator>
                                                        </div>
                                                    </div>
                                                </div>

                                                <fieldset class="mt-20">
                                                    <legend>Password change (Optional)</legend>
                                                    <div class="single-input-item">
                                                        <label for="current-pwd">
                                                            Current
                                                                        Password</label>
                                                        <asp:TextBox ID="txtCurrentPassword" runat="server" type="password" TabIndex="5" placeholder="Current Password" ValidationGroup="Rsave" CausesValidation="true"></asp:TextBox>
                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCurrentPassword" ValidationGroup="Rsave" ErrorMessage="Please enter current password" ValidateEmptyText="true" ClientValidationFunction="ValidateCurrentPassword" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="single-input-item">
                                                                <label for="new-pwd">
                                                                    New
                                                                                Password</label>
                                                                <asp:TextBox ID="txtNewPassword" runat="server" type="password" TabIndex="6" placeholder="New Password" ValidationGroup="Rsave"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtNewPassword" ValidationGroup="Rsave" ErrorMessage="Please enter new password" Display="Dynamic" ForeColor="Red" ValidateEmptyText="true" ClientValidationFunction="ValidateNewPassword"></asp:CustomValidator>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="single-input-item">
                                                                <label for="confirm-pwd">
                                                                    Confirm
                                                                                Password</label>
                                                                <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" TabIndex="7" placeholder="Confirm Password" ValidationGroup="Rsave" CausesValidation="true"></asp:TextBox>
                                                                <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" ControlToCompare="txtNewPassword" Operator="Equal" Type="String" ErrorMessage="Password and Confirm Password do not match" ValidationGroup="Rsave" />
                                                                <asp:CustomValidator ID="cv_name" runat="server" ControlToValidate="txtConfirmPassword" ValidationGroup="Rsave" ErrorMessage="Password and Confirm Password do not match" Display="Dynamic" ForeColor="Red" ValidateEmptyText="true" ClientValidationFunction="ValidateConfirmPassword"></asp:CustomValidator>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </fieldset>
                                                <div class="row">
                                                    <div class="col-lg-6">
                                                        <div class="single-input-item">
                                                            <asp:Button ID="btnSend" class="btn btn-sqr" runat="server" Text="Save Changes" OnClick="btnSend_Click" ValidationGroup="Rsave" />
                                                            <asp:Button ID="btnCancel" class="btn btn-sqr float-right" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                                <!-- My Account Tab Content End -->
                            </div>
                            <!-- My Account Page End -->
                        </div>
                        <!-- My Account Page End -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Quick view modal start -->
    <div class="modal" id="invoice_view">
        <div class="modal-dialog modal-lg modal-dialog-centered">
            <div class="modal-content" id="invoice-content">
                <div class="modal-header" style="padding: 1rem 1rem; border-bottom: 1px solid #dee2e6;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <div class="text-left float-left">
                            <h3 class="mb-0">Invoice #<asp:Label ID="lblInvoiceNo" runat="server"></asp:Label></h3>
                            Date:
                            <asp:Label ID="lblDate" runat="server"></asp:Label>

                        </div>
                </div>
                <div class="modal-body">
                    
                    <!-- product details inner end -->
                    
                            <div class="card">
                        <div class="">
                            <div class="row mb-4">
                                <div class="col-sm-6">
                                    <h5 class="mb-3">From:</h5>
                                    <h3 class="text-dark mb-1">
                                        <asp:Label ID="lblNameFrom" runat="server"></asp:Label></h3>
                                    <div>
                                        <asp:Label ID="lblAddressFrom" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="lblCityFrom" runat="server"></asp:Label>
                                        <asp:Label ID="lblStateFrom" runat="server"></asp:Label>
                                        <asp:Label ID="lblPincodeFrom" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        Email:
                                        <asp:Label ID="lblEmailFrom" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        Phone:
                                        <asp:Label ID="lblPhoneFrom" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-sm-6 ">
                                    <h5 class="mb-3">To:</h5>
                                    <h3 class="text-dark mb-1">
                                        <asp:Label ID="lblNameTo" runat="server"></asp:Label></h3>
                                    <div>
                                        <asp:Label ID="lblAddress1To" runat="server"></asp:Label>
                                        <asp:Label ID="lblAddress2To" runat="server"></asp:Label>
                                        <asp:Label ID="lblLandmarkTo" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="lblCityTo" runat="server"></asp:Label>
                                        <asp:Label ID="lblStateTo" runat="server"></asp:Label>
                                        <asp:Label ID="lblPincodeTo" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        Email:
                                        <asp:Label ID="lblEmailTo" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        Phone:
                                        <asp:Label ID="lblMobileTo" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive-sm">
                                <asp:Repeater ID="rptInvoice" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-striped  display nowrap" style="width:100%"">
                                            <thead>
                                                <tr style="white-space:nowrap;">
                                                    <th class="center">#</th>
                                                    <th>Item</th>
                                                    <%--<th>Description</th>--%>
                                                    <th class="right td-width">Product Price</th>
                                                    <th class="right td-width">Purchase Price</th>
                                                    <th class="center">Qty</th>
                                                    <th class="right td-width">Total</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style="border-bottom: 1px solid #dee2e6;">
                                            <td class="center"><%# Container.ItemIndex + 1 %></td>
                                            <td class="left strong" style="white-space:break-spaces;" title='<%# Eval("sName") %>'><%# Eval("sName") %></td>
                                          <%--  <td class="left">
                                               
                                                <asp:Label ID="lblFeatures" runat="server" ClientIDMode="Static" Text='<%# Limit(Eval("Features"),100) %>' ToolTip='<%# Eval("Features") %>'></asp:Label>
                                              
                                            </td>--%>
                                            <td class="right"><span class="currencySymbol"> <%=((main_master)this.Page.Master).CurrencySymbol %> </span><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %></td>
                                            <td class="right"><span class="currencySymbol"> <%=((main_master)this.Page.Master).CurrencySymbol %> </span><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></td>
                                            <td class="center"><%# Eval("Quantity") %></td>
                                            <td class="right"><span class="currencySymbol"> <%=((main_master)this.Page.Master).CurrencySymbol %> </span><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductTotal")) %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                            </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="row">
                                <div class="col-sm-6"></div>
                                <div class="col-sm-6">
                                    <table class="table table-clear mt-0">
                                        <tbody>
                                            <tr>
                                                <td class="left border-top-0">
                                                    <strong class="text-dark">Subtotal</strong>
                                                </td>
                                                <td class="right border-top-0"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <asp:Label ID="lblSubTotal" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="left">
                                                    <strong class="text-dark">Discount</strong>
                                                </td>
                                                <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> -<asp:Label ID="lblDiscount" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="left">
                                                    <strong class="text-dark">Shipping Charges</strong>
                                                </td>
                                                <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <asp:Label ID="lblVat" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="left">
                                                    <strong class="text-dark">Total</strong> </td>
                                                <td class="right">
                                                    <strong class="text-dark"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <asp:Label ID="lblPurchasePrice" runat="server"></asp:Label></strong>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                         <!-- product details inner end -->
                </div>
                <div class="modal-footer">
                    <div class="card-footer bg-white">
                        <button type="button" class="btn btn-inv btn-sqr float-right" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-inv btn-sqr float-right" onclick="printInvoice()">Print</button>
                        <button type="button" class="btn btn-inv btn-sqr float-right" onclick="DownloadInvoice()">Download</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Quick view modal end -->
    <!-- my account wrapper end -->
    <style type="text/css">
        .billing-address {
            border: 1px solid #c7c7c7;
            padding: 12px 15px;
            height: 240px;
            margin-bottom: 20px;
            position: relative;
        }

        .address-action {
            position: absolute;
            bottom: 10px;
        }

        table.rb-list td {
            padding-right: 50px;
        }

        .account-details-form .btn-sqr, .add-new-address .btn-sqr {
            width: 150px;
            background-color: #45cfbe;
            color: #fff;
            border: 0;
        }

            .account-details-form .btn-sqr:hover, .add-new-address .btn-sqr:hover {
                background-color: #000;
            }

            .account-details-form .btn-sqr:focus, .add-new-address .btn-sqr:focus {
                background-color: #45cfbe;
            }
        /*start invoice css*/
        /*.float-right, .ml-auto {
            float: right;
        }*/

        .td-width {
            min-width: 120px;
        }

        .modal-footer {
            text-align: left;
        }

        .modal-title {
            line-height: 3;
        }

        .btn-inv {
            /*padding-top: 6px;
            padding-bottom: 6px;*/
            margin-left: 5px;
        }

        .btnmargin {
            margin-right: 40px;
        }
        table.dataTable>tbody>tr.child span.dtr-title {
            min-width: 130px;
        }
        /*end invoice css*/
    </style>
    <script src="assets/js/vendor/jquery-3.3.1.min.js"></script>
    <script src="assets/js/html2pdf.bundle.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $(".table").DataTable({
                rowReorder: {
                    selector: 'td:nth-child(2)'
                },
                searching: false,
                paging: false,
                info: false,
                ordering: false,
                responsive: true
            });
        });
        function ShowTab(tab) {
            $(".myaccount-tab-menu a").removeClass("active");
            $("#myaccountContent div").removeClass("show active");
            if (tab == 0) {
                $(".myaccount-tab-menu a[id='btnDashboard']").addClass("active");
                $("#dashboad").addClass("show active");
            }
            if (tab == 1) {
                $(".myaccount-tab-menu a[id='btnOrders']").addClass("active");
                $("#orders").addClass("show active");
            }
            if (tab == 2) {
                $(".myaccount-tab-menu a[id='btnDownload']").addClass("active");
                $("#download").addClass("show active");
            }
            if (tab == 3) {
                $(".myaccount-tab-menu a[id='btnPaymentMethod']").addClass("active");
                $("#payment-method").addClass("show active");
            }
            if (tab == 4) {
                $(".myaccount-tab-menu a[id='btnAddress']").addClass("active");
                $("#address-edit").addClass("show active");
                $([document.documentElement, document.body]).animate({
                    scrollTop: $("#<%= pnlEditAddress.ClientID %>").offset().top - 165
                }, 2000);
            }
            if (tab == 5) {
                $(".myaccount-tab-menu a[id='btnAccountDetails']").addClass("active");
                $("#account-info").addClass("show active");
                $([document.documentElement, document.body]).animate({
                    scrollTop: $("#<%= pnlEditAccount.ClientID %>").offset().top - 165
                }, 2000);
            }

        }
        function DownloadInvoice() {
            $(".btn-inv").hide();
            $(".close").hide();
            // Choose the element that our invoice is rendered in.
            var element = document.getElementById('invoice-content');

            var opt = {
                // margin: 1,
                filename: 'Invoice.pdf',
                // image: { type: 'jpeg', quality: 0.98 },
                // html2canvas: { scale: 2 },
                // jsPDF: { unit: 'in', format: 'A4', orientation: 'portrait' }
            };
            // Choose the element and save the PDF for our user.
            // New Promise-based usage:
            html2pdf().set(opt).from(element).save();

            // Old monolithic-style usage:
            //  html2pdf(element, opt);
            $(".btn-inv").show();
            $(".close").show();
        }

        function printInvoice() {
            $(".btn-inv").hide();
            $(".close").hide();
            var divToPrint = document.getElementById('invoice-content');
            var newWin = window.open('', 'Print-Window');
            newWin.document.open();
            //newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

            newWin.document.write('<base href="' + location.origin + location.pathname + '">');
            newWin.document.write('<link rel="stylesheet" href="../assets/css/vendor/bootstrap.min.css">');
            newWin.document.write('<link rel="stylesheet" href="../assets/css/style.css">');
            newWin.document.write('<style type="text/css">.td-width{min-width: 120px;}.modal-footer{text-align:left}</style>');

            newWin.document.write('</head><body onload="window.print()">');
            newWin.document.write(divToPrint.innerHTML);
            newWin.document.write('</body></html>');

            newWin.focus(ShowTab(1));
            newWin.document.close();
            setTimeout(function () { newWin.close(); }, 10);
            $(".btn-inv").show();
            $(".close").show();
        }

        function ShowInvoice() {
            $("#invoice_view").modal("show");
            ShowTab(1);
        }
        function ValidateCurrentPassword(sender, args) {
            var currentPwd = document.getElementById('<%=txtCurrentPassword.ClientID%>').value;
            var newPwd = document.getElementById('<%=txtNewPassword.ClientID%>').value;
            if (currentPwd == '' && newPwd != '') {
                args.IsValid = false;
            }
        }

        function ValidateNewPassword(sender, args) {
            var currentPwd = document.getElementById('<%=txtCurrentPassword.ClientID%>').value;
            var newPwd = document.getElementById('<%=txtNewPassword.ClientID%>').value;
            if (currentPwd != '' && newPwd == '') {
                args.IsValid = false;
            }
        }

        function ValidateConfirmPassword(sender, args) {
            var newPwd = document.getElementById('<%=txtNewPassword.ClientID%>').value;
            var confPwd = document.getElementById('<%=txtConfirmPassword.ClientID%>').value;
            if (newPwd != '' && confPwd == '') {
                args.IsValid = false;
            }
        }
    </script>
</asp:Content>
