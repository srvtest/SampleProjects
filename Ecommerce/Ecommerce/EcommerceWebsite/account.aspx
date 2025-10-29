<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="EcommerceWebsite.account" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<style>
        .colour {
            color: blue;
        }

        .scroll {
            height: 200px;
            overflow-y: scroll;
        }
        .btnCrt{
            font-weight: 600;
        }
        .btnDel{
                font-weight: 600;
        }

        .holder {
            margin: 15px 0;
        }

            .holder a {
                font-size: 12px;
                cursor: pointer;
                margin: 0 5px;
                color: #333;
            }

                .holder a:hover {
                    background-color: #222;
                    color: #fff;
                }

                .holder a.jp-previous {
                    margin-right: 15px;
                }

                .holder a.jp-next {
                    margin-left: 15px;
                }

                .holder a.jp-current, a.jp-current:hover {
                    color: #FF4242;
                    font-weight: bold;
                }

                .holder a.jp-disabled, a.jp-disabled:hover {
                    color: #bbb;
                }

                .holder a.jp-current, a.jp-current:hover, .holder a.jp-disabled, a.jp-disabled:hover {
                    cursor: default;
                    background: none;
                }

            .holder span {
                margin: 0 5px;
            }
    </style>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
        <asp:HiddenField ID="customerID" runat="server" />
        <div class="row ">
            <!-- =====  BREADCRUMB STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>My Account</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">My Account</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <div class="col-sm-12">
                <div class="alert alert-success alert-dismissible fade hide">
                    <strong>Success! </strong>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                </div>
            </div>
            <div id="column-left" class="col-sm-4 col-lg-3 ">
                <div class="nav-responsive">
                    <%--<div class="heading-part mb_10 ">
                        <h2 class="main_title">My Profile</h2>
                    </div>--%>
                    <div id="left-special" class="owl-carousel">
                        <ul class="nav main-navigation collapse in" style="clear: both">
                            <li>
                                <asp:LinkButton ID="btnPersonalInfo" OnClick="btnPersonalInfo_Click" runat="server">Personal Information</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="btnMyAddress" OnClick="btnMyAddress_Click" runat="server">My Address</asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="btnMyOrder" OnClick="btnMyOrder_Click" runat="server">My Orders</asp:LinkButton></li>
                            <li>
                                <%-- <a href="../WishList">My Wishlist</a>--%>
                                <asp:LinkButton ID="btnMywishlist" OnClick="btnMywishlist_Click" runat="server">My Wishlist</asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="col-sm-8 col-lg-8 mtb_20 col-lg-offset-1">
                <!-- contact  -->
                <asp:Panel ID="pnlPersonalInfo" runat="server">
                    <div class="row" id="personal-info">
                        <div class="col-sm-6 mb-3 mb-sm-0 contact" id="info-customer">
                            <div class="location mb_50">
                                <h5 class="capitalize mb_20 about-heading"><strong>Personal Information</strong></h5>
                                <a id="info-edit" style="margin-left: 10px; color: #0066c0;" href="javascript:void(0);" onclick="editInfo(this);">Edit</a>
                                <div class="call mt_10">
                                    <i class="fa fa-user" aria-hidden="true"></i>
                                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                    (<asp:Label ID="lblGender" runat="server" Text=""></asp:Label>)
                                </div>
                                <div class="call mt_10">
                                    <i class="fa fa-phone" aria-hidden="true"></i>
                                    <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                </div>
                                <div class="call mt_10">
                                    <i class="fa fa-envelope" aria-hidden="true"></i>
                                    <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-6 mb-3 mb-sm-0" id="info-form" style="display: none">
                            <div class="card-body">
                                <h4 class="about-heading"><strong>Personal Information</strong></h4>
                                <div id="contact_form" style="margin-top: 25px;">
                                    <div class="">
                                        <asp:TextBox ID="txtName" class="full-with-form " runat="server" placeholder="Name" MaxLength="200"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter name." ValidationGroup="send"></asp:RequiredFieldValidator>
                                        <br />
                                        <br />
                                        <asp:RadioButtonList ID="rbGender" runat="server" RepeatDirection="Horizontal">
                                        </asp:RadioButtonList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rbGender" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please select gender." ValidationGroup="send"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:TextBox ID="txtEmail" class="full-with-form " runat="server" placeholder="Email Address" MaxLength="200"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter Email Address." ValidationGroup="send"></asp:RequiredFieldValidator>
                                        <br />
                                        <br />
                                        <asp:TextBox ID="txtPhoneNo" class="full-with-form " runat="server" placeholder="Phone Number" MaxLength="25"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPhoneNo" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter Phone Number." ValidationGroup="send"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="send" ForeColor="Red"
                                            ControlToValidate="txtPhoneNo" ErrorMessage="Please enter valid phone no." Display="Dynamic"
                                            ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
                                    </div>
                                    <asp:Button ID="btnSend" class="btn mt_30" runat="server" Text="Save" OnClick="btnSend_Click" ValidationGroup="send" />
                                    <asp:Button ID="btnCancel" class="btn mt_30" runat="server" Text="Cancel" Style="float: right" OnClientClick="cancelForm();" />

                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlAllAddress" runat="server" Visible="false">
                    <asp:Panel ID="pnlAddress" runat="server">
                        <asp:Repeater ID="rptAddress" runat="server">
                            <ItemTemplate>
                                <div class="col-sm-6 mb-3 mb-sm-0" style="margin-bottom: 20px;">
                                    <div class="cust-address">
                                        <div class="card-body">
                                            <asp:HiddenField ID="hdnIdCustomerAddress" runat="server" Value='<%# Eval("idCustomerAddress") %>' />
                                            <asp:HiddenField ID="hdnAddressType" runat="server" Value='<%# Eval("AddressType") %>' />
                                            <asp:HiddenField ID="hdnAlternateNo" runat="server" Value='<%# Eval("AlternateNo") %>' />
                                            <h6><strong>
                                                <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("sName") %>'></asp:Label></strong>
                                                <asp:Label ID="lblDefault" runat="server" Text='<%# (!string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) && Convert.ToInt16(Eval("IsDefaultAddr")) == 1) ? "(Default)" : "" %>'></asp:Label></h6>
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
                                        </div>
                                        <div class="address-action">
                                            <asp:LinkButton ID="btnEditAddress" OnClick="btnEditAddress_Click" runat="server">Edit</asp:LinkButton>
                                            <asp:Label ID="lbl1" runat="server" Text='|'></asp:Label>
                                            <asp:LinkButton ID="btnRemove" CommandArgument='<%# Eval("idCustomerAddress") %>' runat="server" OnClick="btnRemove_Click" OnClientClick="return confirm('Are you sure you want to delete the address?');">Remove</asp:LinkButton>
                                            <asp:Label ID="lbl2" runat="server" Text='|' Visible='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) || Convert.ToInt16(Eval("IsDefaultAddr")) != 1) ? true : false%>'></asp:Label>
                                            <asp:LinkButton ID="btnSetDefault" CommandArgument='<%# Eval("idCustomerAddress") %>' runat="server" OnClick="btnSetDefault_Click" Visible='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) || Convert.ToInt16(Eval("IsDefaultAddr")) != 1) ? true : false%>'>Set as default</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </asp:Panel>
                    <asp:Panel ID="pnlEditAddress" runat="server" Visible="false">
                        <div class="col-sm-12 mb-3 mb-sm-0" id="address-form">
                            <div class="card-body">
                                <h4 class="about-heading"><strong>Address</strong></h4>
                                <div style="margin-top: 25px;">
                                    <asp:Panel ID="pnlNew" runat="server">
                                        <asp:HiddenField ID="hdnidCustomerAddress" runat="server" />
                                        <div class="form-group required">
                                            <label for="txtCustName" class="col-sm-3 control-label">Name</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCustName" runat="server" type="text" class="form-control" placeholder="Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtCustName" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtMobile" class="col-sm-3 control-label">Mobile</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtMobile" runat="server" type="text" class="form-control" placeholder="Mobile"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtMobile" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtPinCode" class="col-sm-3 control-label">PinCode</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtPinCode" runat="server" type="text" class="form-control" placeholder="PinCode(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtAddress1" class="col-sm-3 control-label">Address 1</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtAddress1" runat="server" type="text" class="form-control" placeholder="Address 1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtAddress1" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtAddress2" class="col-sm-3 control-label">Address 2</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtAddress2" runat="server" type="text" class="form-control" placeholder="Address 2(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtCity" class="col-sm-3 control-label">City</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtCity" runat="server" type="text" class="form-control" placeholder="City"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtCity" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtState" class="col-sm-3 control-label">State</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtState" runat="server" type="text" class="form-control" placeholder="State"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtState" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtLandmark" class="col-sm-3 control-label">Land mark</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtLandmark" runat="server" type="text" class="form-control" placeholder="Land mark(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="rdbAddressType" class="col-sm-3 control-label">Address Type</label>
                                            <div class="col-sm-9">
                                                <asp:RadioButtonList ID="rdbAddressType" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">Home</asp:ListItem>
                                                    <asp:ListItem>Office</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="form-group required">
                                            <label for="txtAlternateContact" class="col-sm-3 control-label">Alternate Contact</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtAlternateContact" runat="server" type="text" class="form-control" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <%--<div class="pull-right">
                                        <asp:Button runat="server" ID="btnAddress" Text="Add Address" class="btn" data-loading-text="Loading..." OnClick="btnAddress_Click" ValidationGroup="grpAddress" />
                                    </div>--%>
                                    </asp:Panel>
                                    <asp:Button ID="btnSaveAddress" class="btn mt_30" runat="server" Text="Save" OnClick="btnSaveAddress_Click" ValidationGroup="grpAddress" />
                                    <asp:Button ID="btnCancelAddress" class="btn mt_30" runat="server" Text="Cancel" Style="float: right" OnClick="btnCancelAddress_Click" />

                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlNewAddress" runat="server">
                        <asp:CheckBox runat="server" ID="chkAddNewAddress" AutoPostBack="true" OnCheckedChanged="chkAddNewAddress_CheckedChanged" />
                        Add New Address
                    </asp:Panel>
                    <asp:Panel ID="pnlNe" runat="server" Visible="false">
                        <asp:HiddenField ID="hdnidCustomeAddress" runat="server" />
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">Name</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtNam" runat="server" type="text" class="form-control" placeholder="Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtName" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">Mobile</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtMob" runat="server" type="text" class="form-control" placeholder="Mobile"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtMobile" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">PinCode</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtPin" runat="server" type="text" class="form-control" placeholder="PinCode(Optional)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">Address 1</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtAdd1" runat="server" type="text" class="form-control" placeholder="Address 1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtAddress1" runat="server" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">Address 2</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtAdd2" runat="server" type="text" class="form-control" placeholder="Address 2(Optional)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">City</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtCty" runat="server" type="text" class="form-control" placeholder="City"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtCity" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">State</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtStte" runat="server" type="text" class="form-control" placeholder="State"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtState" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">Land mark</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtLandark" runat="server" type="text" class="form-control" placeholder="Land mark(Optional)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">Address Type</label>
                            <div class="col-sm-10">
                                <asp:RadioButtonList ID="rdbAddresType" runat="server">
                                    <asp:ListItem Selected="True">Home</asp:ListItem>
                                    <asp:ListItem>Office</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="form-group required">
                            <label for="input-payment-firstname" class="col-sm-2 control-label">Alternate Contact</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtAlternatContact" runat="server" type="text" class="form-control" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="pull-right">
                            <asp:Button runat="server" ID="btnAddress" Text="Add Address" class="btn" data-loading-text="Loading..." OnClick="btnAddress_Click" ValidationGroup="grpAddress" />
                        </div>
                    </asp:Panel>
                </asp:Panel>

                <asp:Panel ID="pnlMyOrder" runat="server">

                    <asp:Repeater ID="rptOrder" runat="server" OnItemDataBound="rptOrder_ItemDataBound" OnItemCommand="rptOrder_ItemCommand">
                        <%--  <HeaderTemplate>
                           
                            <div class="">
                                
                        </HeaderTemplate>--%>
                        <ItemTemplate>

                            <div class="panel panel-default">
                                <asp:HiddenField ID="hdnidOrder" runat="server" Value='<%#Eval("idCustomerOrder")%>' />
                                <div class="panel-heading">

                                    <table style="width: 100%; font-size: smaller;">
                                        <tr>
                                            <td style="width: 20%">ORDER PLACED<br />
                                                <%#Convert.ToDateTime(Eval("dtOrder")).ToShortDateString()%></td>

                                            <td style="width: 20%">SHIP TO
                                    <br />
                                                <%#Eval("sName")%></td>
                                            <td style="width: 20%">STATUS
                                    <br />
                                                <%--<%#Eval("ApproveReject")%>--%>
                                                <%#Convert.ToString(Eval("bStatus"))== "0" ? "Pending" :  
                                          Convert.ToString(Eval("bStatus"))== "1"? "Approved":
                                        Convert.ToString(Eval("bStatus"))== "2" ? "Reject":
                                        Convert.ToString(Eval("bStatus"))== "3" ? "Shipped":
                                        Convert.ToString(Eval("bStatus"))== "4" ? "Delivered": "User Cancel" %>
                                            </td>
                                            <td style="width: 20%">
                                                <asp:LinkButton ID="btnInvoice" CssClass="btn" CommandArgument='<%#Eval("idCustomerOrder")%>' runat="server">View Invoice</asp:LinkButton></td>
                                            <td style="width: 20%"><span style="float: right;">ORDER # <%# Convert.ToString(Eval("sOrderNo"))%></span></td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <div class="col-sm-12 mb-3 mb-sm-0">

                                            <div class="card-body">
                                                <table class="table table-bordered table-hover" style="margin-bottom: 0">
                                                    <tbody>
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
                                                    </tbody>
                                                    <tfoot>
                                                        <tr>
                                                            <td class="text-right" colspan="3"><strong>Total:</strong></td>
                                                            <td class="text-right"><%#Eval("totalAmount")%></td>
                                                        </tr>
                                                    </tfoot>
                                                </table>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%--         <div class="pagination">
                        </div>--%>
                        </ItemTemplate>
                        <%-- <FooterTemplate>
                            <div class="pagination">
                        </div>
                            </FooterTemplate>--%>
                    </asp:Repeater>
                    <asp:Panel ID="pnlPaggination" runat="server">
                        <div class="pagination-nav text-center mt_50">
                            <ul>
                                <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                                    <HeaderTemplate>
                                        <li>
                                            <asp:LinkButton ID='lnkFirst' CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="fa fa-angle-left"></i>
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
                                            <asp:LinkButton ID='lnkLast' CommandName="Page" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="fa fa-angle-right"></i>
                                            </asp:LinkButton>
                                        </li>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ul>
                        </div>
                    </asp:Panel>

                </asp:Panel>
                <asp:Panel ID="pnlWishlist" runat="server">

                    <asp:Repeater ID="rptWishlistProduct" runat="server" OnItemCommand="rptWishlistProduct_ItemCommand">
                        <HeaderTemplate>
                            <div class="table-responsive">
                                <table class="table table-bordered" style="width: 100%">
                                    <thead>
                                        <%-- <tr>
                                                <td class="text-center">Image</td>
                                                <td class="text-left">Product Name</td>
                                                <td class="text-left">Quantity</td>
                                                <td class="text-right">Unit Price</td>
                                                <td class="text-right">Total</td>
                                            </tr>--%>
                                    </thead>
                                    <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td class="text-center" style="width: 120px;"><a href="#">
                                    <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>"></a></td>
                                <td class="text-left">
                                    <a href="../ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a><br />
                                    <div class="rating"><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span><span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span></div>
                                    <span class="price">
                                        <span class="amount">
                                            <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %>.</span>
                                            <%#Eval("Price")%>
                                        </span>
                                        <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice")) ? "<span style='display:none'>" :""%>
                                        <span style="text-decoration: line-through; font-size: x-small;">
                                            <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
                                            <%#Eval("APrice")%>
                                        </span>
                                        <br />
                                        <span style="font-size: x-small;">You Save: <%#Convert.ToDouble(Eval("APrice"))- Convert.ToDouble(Eval("Price"))%> (<%#Eval("Discount")%>%)</span>
                                        <%# Convert.ToString(Eval("Price")) == Convert.ToString(Eval("APrice"))  ? "</span>" :""%>
                                    </span>
                                </td>
                                <td class="text-left">
                                    <asp:HiddenField ID="hdnidProduct" runat="server" Value='<%#Eval("idProduct")%>' />
                                    <asp:HiddenField ID="hdnidCustomerCart" runat="server" Value='<%#Eval("idWishList")%>' />
                                    <div style="max-width: 200px;" class="input-group btn-block">

                                        <%--<asp:TextBox runat="server" ID="txtQty" CssClass="qtytextboxsize" Text='<%#Eval("Quantity")%>' class="form-control quantity"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter quentity." ControlToValidate="txtQty"></asp:RequiredFieldValidator>                                            --%>
                                        <span class="input-group-btn">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="qtyUpdate" CssClass="btn btn-success btn-circle btn-sm btnCrt">Add to Cart</asp:LinkButton>
                                            <br />
                                            <br />
                                            <br />
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="qtyDelete" CssClass="btn btn-success btn-circle btn-sm btnDel">Remove item</asp:LinkButton>
                                        </span>
                                    </div>
                                </td>

                                <%--<td class="text-right">
                                      
                                    </td>--%>
                                <%-- <td class="text-right"><%=this.Master.CurrencySymbol %><%#Eval("Total")%></td>--%>
                            </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            <%--  <tr>
                                    <td class="text-right" colspan="4"><strong>Sub-Total:</strong></td>
                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=SubtotalAmount %></td>
                                </tr>
                                <tr>
                                    <td class="text-right" colspan="4"><strong>Shipping</strong></td>
                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=ShipmentCharges %></td>
                                </tr>
                                <tr>
                                    <td class="text-right" colspan="4"><strong>Total</strong></td>
                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=totalAmount %></td>
                                </tr>--%>

                                </tbody>
                        </table>
                    </div>
                        </FooterTemplate>
                    </asp:Repeater>

                </asp:Panel>
            </div>
        </div>
    </div>

     <dialog id="myDialog" class="modal-dialog modal-lg" style="background: border-box; border:none;">
        <div >
            <div class="modal-content" id="invoice-content">
                <div class="modal-header">
                    <div class="card-header p-4">
                        <%-- <a class="pt-2 d-inline-block modal-title" href="https://silverrockcreations.com" data-abc="true">silverrockcreations.com</a>--%>
                        <div class="float-right">
                            <h3 class="mb-0">Invoice #<asp:Label ID="lblInvoiceNo" runat="server"></asp:Label></h3>
                            Date:
                            <asp:Label ID="lblDate" runat="server"></asp:Label>

                        </div>
                    </div>
                </div>
                <div class="modal-body">
                    <div class="card">

                        <div class="card-body">
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
                                    <div>Email:
                                        <asp:Label ID="lblEmailFrom" runat="server"></asp:Label></div>
                                    <div>Phone:
                                        <asp:Label ID="lblPhoneFrom" runat="server"></asp:Label></div>
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
                                    <div>Email:
                                        <asp:Label ID="lblEmailTo" runat="server"></asp:Label></div>
                                    <div>Phone:
                                        <asp:Label ID="lblMobileTo" runat="server"></asp:Label></div>
                                </div>
                            </div>
                            <div class="table-responsive-sm">
                                <asp:Repeater ID="rptInvoice" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-striped">
                                            <thead>
                                                <tr>
                                                    <th class="center">#</th>
                                                    <th>Item</th>
                                                    <th>Description</th>
                                                    <th class="right td-width">Product Price</th>
                                                     <th class="right td-width">Purchase Price</th>
                                                    <th class="center">Qty</th>
                                                    <th class="right td-width">Total</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="center"><%# Container.ItemIndex + 1 %></td>
                                            <td class="left strong"><%# Eval("sName") %></td>
                                            <td class="left"><%# Eval("Features") %></td>
                                            <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><%# Eval("ProductPrice") %></td>
                                            <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><%# Eval("PurchasePrice") %></td>
                                            <td class="center"><%# Eval("Quantity") %></td>
                                            <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><%# Eval("ProductTotal") %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                            </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <div class="row">
                                <div class="col-lg-4 col-sm-5">
                                </div>
                                <div class="col-lg-4 col-sm-5 ml-auto">
                                    <table class="table table-clear">
                                        <tbody>
                                            <tr>
                                                <td class="left">
                                                    <strong class="text-dark">Subtotal</strong>
                                                </td>
                                                <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><asp:Label ID="lblSubTotal" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="left">
                                                    <strong class="text-dark">Discount (20%)</strong>
                                                </td>
                                                <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><asp:Label ID="lblDiscount" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="left">
                                                    <strong class="text-dark">Shipping Charges (10%)</strong>
                                                </td>
                                                <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><asp:Label ID="lblVat" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td class="left">
                                                    <strong class="text-dark">Total</strong> </td>
                                                <td class="right">
                                                    <strong class="text-dark"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span><asp:Label ID="lblPurchasePrice" runat="server"></asp:Label></strong>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="card-footer bg-white">
                        <%--<p class="mb-0" style="display:inline-block"><a href="https://silverrockcreations.com" data-abc="true">silverrockcreations.com</a></p>--%>
                        <button type="button" class="btn btn-inv float-right" data-dismiss="modal" onclick="closeInvoice()">Close</button>
                        <asp:Button ID="btnInvoiceDownload" CssClass="btn btn-inv float-right" runat="server" Text="Print" OnClientClick="printInvoice()" />
                    </div>
                </div>
            </div>
        </div>
    </dialog>


   
    <script type="text/javascript">
        function printInvoice() {
            $(".btn-inv").hide();
            var divToPrint = document.getElementById('invoice-content');
            var newWin = window.open('', 'Print-Window');
            newWin.document.open();
            //newWin.document.write('<html><body onload="window.print()">' + divToPrint.innerHTML + '</body></html>');

            newWin.document.write('<base href="' + location.origin + location.pathname + '">');
            newWin.document.write('<link rel="stylesheet" href="css/bootstrap.css">');
            newWin.document.write('<style type="text/css">.float-right,.ml-auto{float:right;}.td-width{min-width: 110px;}.modal-footer{text-align:left}</style>');

            newWin.document.write('</head><body onload="window.print()">');
            newWin.document.write(divToPrint.innerHTML);
            newWin.document.write('</body></html>');


            newWin.document.close();
            setTimeout(function () { newWin.close(); }, 10);
        }

        function ShowInvoice() {
            document.getElementById("myDialog").showModal();
        }
        function closeInvoice() {
            $('#myDialog').hide();
        }
    </script>
    
    <script type="text/javascript">
        function editInfo(e) {
            $('#info-customer').hide();
            $('#info-form').css('display', 'block');
            $('#<%= txtName.ClientID %>').val($('#<%= lblName.ClientID %>').text());
            var radio = $("#<%= rbGender.ClientID %> label:contains('" + $('#<%= lblGender.ClientID %>').text() + "')").closest("td").find("input");
            radio.attr("checked", "checked");
            $('#<%= txtEmail.ClientID %>').val($('#<%= lblEmail.ClientID %>').text());
            $('#<%= txtPhoneNo.ClientID %>').val($('#<%= lblMobile.ClientID %>').text());
        }
        function cancelForm() {
            $('#info-customer').show();
            $('#info-form').css('display', 'none');
        }

        /* when document is ready */
        //$(function () {
        //    /* initiate the plugin */
        //    $("div.holder").jPages({
        //        containerID: "pnlMyOrder",
        //        perPage: 3,
        //        startPage: 1,
        //        startRange: 1,
        //        midRange: 5,
        //        endRange: 1
        //    });
        //});
        <%--function showPersonalInfo() {
            $('#personal-info').show();
            $('#all-addresses').hide();
        }
        function showAllAddresses() {
            $('#personal-info').hide();
            $('#all-addresses').show();
        }
        function editAddress(idCustomerAddress) {
            //$('#personal-info').hide();
            //$('#all-addresses').show();
            $('#addresses').hide();
            $('#address-form').show();
            $.ajax({
                type: "POST",
                url: "account.aspx/EditAddress",
                data: '{idCustomerAddress: "' + idCustomerAddress + '" }',
                contentType: "application/json; charset=utf-8",
                //dataType: "json",
                success: function (response) {
                    alert(response.d);
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(JSON.stringify(jqXHR));
                }
            });
        }
        function showData() {
            $.ajax({
                type: "post",
                url: 'account.aspx/RegisterUser',
                //url: '<%= ResolveUrl("account.aspx/search") %>',
                //dataType:"json",                
                contentType: "application/json; charset=utf-8",
                //crossDomain: true,
                success: function (response) {
                    alert("success:" + response);
                },
                error: function (response, status, xhr) {
                    alert("error:" + response);
                    alert("status:" + status);
                    alert("xhr:" + xhr);
                }
            });
        }--%>
    </script>
    <style type="text/css">
        #contact_form label {
            font-weight: normal;
            margin-left: 4px;
        }

        .cust-address {
            border: 1px solid #c7c7c7;
            padding: 12px 18px;
            height: 240px;
        }

        .address-action {
            margin-top: 35px;
        }

        .cust-address .card-body {
            height: 160px;
        }

        .address-action a {
            color: #0066c0;
        }

        .show-br {
            display: inline;
        }

        .hide-br {
            display: none;
        }

        /*start invoice css*/
        .float-right, .ml-auto {
            float: right;
        }

        .td-width {
            min-width: 110px;
        }

        .modal-footer {
            text-align: left;
        }

        .modal-title {
            line-height: 3;
        }

        .btn-inv {
            padding-top: 6px;
            padding-bottom: 6px;
            margin-left: 5px;
        }
        /*end invoice css*/
    </style>
</asp:Content>
