<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="account.aspx.cs" Inherits="EcommerceWebsiteB2B.account" %>
<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/jquery.dataTables.min.css" rel="stylesheet" />
    <%--<link href="css/rowReorder.dataTables.min.css" rel="stylesheet" />--%>
    <link href="css/responsive.dataTables.min.css" rel="stylesheet" />
    <style>
        .chkadd input {
            margin-right: 5px;
        }

        #accountRow .left-sidebar li {
            margin: 10px auto;
        }

            #accountRow .left-sidebar li a {
                color: #fd405e;
                padding: 6px;
                font-size: 17px;
                display: block;
                border: 1px solid #c3c3c3;
            }

                #accountRow .left-sidebar li a:hover {
                    border: 1px solid #fd405e;
                }

            #accountRow .left-sidebar li.selected {
                background: #fd405e;
            }

                #accountRow .left-sidebar li.selected a {
                    color: #fff;
                    border: 1px solid #fd405e;
                }

        .text-left {
            text-align: left !important;
        }

        .text-right {
            text-align: right !important;
        }

        .text-center {
            text-align: center !important;
        }
        table.dataTable>tbody>tr.child span.dtr-title {
            min-width: 130px;
        }
       /*div.scroll {
            height: 1000px;
            overflow-y: scroll;
        }*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
    <asp:HiddenField ID="customerID" runat="server" />
    <!-- =====  BREADCRUMB STRAT  ===== -->
    <section id="breadcrumbRow" class="row">
        <h2>My Account</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">My Account</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">My Account</li>
                </ul>
            </div>
        </div>
    </section>
    <!-- =====  BREADCRUMB END===== -->
    <section id="accountRow" class="row contentRowPad">
        <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="left-sidebar col-lg-3 col-md-4">
                            <ul style="list-style: none;padding-left:0">
                                <li class="selected">
                                    <asp:LinkButton ID="btnPersonalInfo" OnClick="btnPersonalInfo_Click" runat="server">Personal Info</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="btnAddresses" OnClick="btnAddresses_Click" runat="server">Addresses</asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="btnOrders" OnClick="btnOrders_Click" runat="server">Orders</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="col-lg-9 col-md-8">
                            <asp:Panel ID="pnlPersonalInfo" runat="server">
                                <div class="row m0" id="personal-info">
                                    <h4 style="border-bottom: 1px dashed #ccc; padding-bottom: 10px; margin-bottom: 25px;">Personal Information
                                    <a id="info-edit" style="margin-left: 10px; color: #0066c0;" href="javascript:void(0);" onclick="editInfo(this);">edit</a></h4>
                                    <div class="col-sm-6 mb15" id="info-customer">
                                        <div class="mb0">
                                            <div class="call mb15">
                                                <i class="fa fa-user" aria-hidden="true"></i>
                                                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                                (<asp:Label ID="lblGender" runat="server" Text=""></asp:Label>)
                                            </div>
                                            <div class="call mb15">
                                                <i class="fa fa-phone" aria-hidden="true"></i>
                                                <asp:Label ID="lblMobile" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="call mb15">
                                                <i class="fa fa-envelope" aria-hidden="true"></i>
                                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-sm-6 mb-3 mb-sm-0" id="info-form" style="display: none">
                                        <div class="card-body">
                                            <h4 class="about-heading"><strong>Personal Information</strong></h4>
                                            <div id="contact_form" style="margin-top: 25px;">
                                                <div class="row m0">
                                                    <div class="row m0" id="contactForm">
                                                        <div class="row m0 mb15">
                                                            <label for="txtName">Name *</label>
                                                            <asp:TextBox ID="txtName" CssClass="form-control" runat="server" placeholder="Name" MaxLength="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter name." ValidationGroup="send"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="row m0 mb15">
                                                            <label for="rbGender">Gender *</label>
                                                            <asp:RadioButtonList ID="rbGender" CssClass="gender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                                                            </asp:RadioButtonList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="rbGender" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please select gender." ValidationGroup="send"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="row m0 mb15">
                                                            <label for="txtEmail">Email *</label>
                                                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Email Address" MaxLength="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtEmail" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter Email Address." ValidationGroup="send"></asp:RequiredFieldValidator>
                                                        </div>
                                                        <div class="row m0 mb15">
                                                            <label for="txtPhoneNo">Phone *</label>
                                                            <asp:TextBox ID="txtPhoneNo" CssClass="form-control" runat="server" placeholder="Phone Number" MaxLength="25"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtPhoneNo" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please Enter Phone Number." ValidationGroup="send"></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="send" ForeColor="Red"
                                                                ControlToValidate="txtPhoneNo" ErrorMessage="Please enter valid phone no." Display="Dynamic"
                                                                ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
                                                        </div>
                                                        <div class="row m0 mb15">
                                                            <label for="txtCurrentPassword">Current Password</label>
                                                             <asp:TextBox ID="txtCurrentPassword" runat="server" type="password" CssClass="form-control" TabIndex="5" placeholder="Current Password" ValidationGroup="send" CausesValidation="true"></asp:TextBox>
                                                        <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCurrentPassword" ValidationGroup="send" ErrorMessage="Please enter current password" ValidateEmptyText="true" ClientValidationFunction="ValidateCurrentPassword" Display="Dynamic" ForeColor="Red"></asp:CustomValidator>
                                                        </div>
                                                        <div class="row m0 mb15">
                                                            <label for="txtNewPassword">New Password</label>
                                                             <asp:TextBox ID="txtNewPassword" runat="server" type="password" CssClass="form-control" TabIndex="6" placeholder="New Password" ValidationGroup="send"></asp:TextBox>
                                                                <asp:CustomValidator ID="CustomValidator2" runat="server" ControlToValidate="txtNewPassword" ValidationGroup="send" ErrorMessage="Please enter new password" Display="Dynamic" ForeColor="Red" ValidateEmptyText="true" ClientValidationFunction="ValidateNewPassword"></asp:CustomValidator>
                                                        </div>
                                                        <div class="row m0 mb15">
                                                            <label for="txtConfirmPassword">Confirm Password</label>
                                                             <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" CssClass="form-control" TabIndex="7" placeholder="Confirm Password" ValidationGroup="send" CausesValidation="true"></asp:TextBox>
                                                                <asp:CompareValidator runat="server" ID="cmpNumbers" ControlToValidate="txtConfirmPassword" ForeColor="Red" Display="Dynamic" ControlToCompare="txtNewPassword" Operator="Equal" Type="String" ErrorMessage="Password and Confirm Password do not match" ValidationGroup="send" />
                                                                <asp:CustomValidator ID="cv_name" runat="server" ControlToValidate="txtConfirmPassword" ValidationGroup="send" ErrorMessage="Password and Confirm Password do not match" Display="Dynamic" ForeColor="Red" ValidateEmptyText="true" ClientValidationFunction="ValidateConfirmPassword"></asp:CustomValidator>
                                                        </div>
                                                    </div>
                                                    <asp:Button ID="btnSend" class="btn btn-primary btn-lg filled" runat="server" Text="Save" OnClick="btnSend_Click" ValidationGroup="send" />
                                                    <button class="btn btn-primary btn-lg filled fright" type="button" onclick="cancelForm();">Cancel</button>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlAllAddress" runat="server" Visible="false">
                                <div class="row m0 contactForm">
                                    <asp:Panel ID="pnlAddress" runat="server">
                                        <h4 style="border-bottom: 1px dashed #ccc; padding-bottom: 10px; margin-bottom: 25px;">Address</h4>
                                        <asp:Repeater ID="rptAddress" runat="server">
                                            <ItemTemplate>
                                                <div class="col-sm-4" style="margin-bottom: 30px;">
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
                                </div>
                                <div class="row m0 contactForm">
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
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="grpAddress" ForeColor="Red" ControlToValidate="txtMobile" ErrorMessage="Please enter valid mobile no." Display="Dynamic" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
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
                                                        <div class="form-group required" style="margin-bottom:60px;">
                                                            <label for="txtAlternateContact" class="col-sm-3 control-label">Alternate Contact</label>
                                                            <div class="col-sm-9">
                                                                <asp:TextBox ID="txtAlternateContact" runat="server" type="text" class="form-control" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                    <asp:Button ID="btnSaveAddress" class="btn mt_30 btn-primary filled btn-sm" runat="server" Text="Save" OnClick="btnSaveAddress_Click" ValidationGroup="grpAddress" />
                                                    <asp:Button ID="btnCancelAddress" class="btn mt_30 btn-primary filled btn-sm float-right" runat="server" Text="Cancel" Style="float: right" OnClick="btnCancelAddress_Click" />

                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="row m0 chkadd" style="margin-top:50px;">
                                    <asp:Panel ID="pnlNewAddress" runat="server">
                                        <asp:CheckBox runat="server" ID="chkAddNewAddress" AutoPostBack="true" OnCheckedChanged="chkAddNewAddress_CheckedChanged" Text=" Add New Address" />
                                    </asp:Panel>
                                </div>
                                <div class="row m0 contactForm">
                                    <asp:Panel ID="pnlNe" runat="server" Visible="false">
                                        <%--<div class="row m0">
                                            <h4 class="contactHeading heading">login</h4>
                                        </div>--%>
                                        <div class="row m0">
                                            <asp:HiddenField ID="hdnidCustomeAddress" runat="server" />
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">Name</label>
                                                <asp:TextBox ID="txtNam" runat="server" type="text" class="form-control" placeholder="Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="txtName" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">Mobile</label>
                                                <asp:TextBox ID="txtMob" runat="server" type="text" class="form-control" placeholder="Mobile"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtMob" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ValidationGroup="grpAddress" ForeColor="Red" ControlToValidate="txtMob" ErrorMessage="Please enter valid mobile no." Display="Dynamic" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">PinCode</label>
                                                <asp:TextBox ID="txtPin" runat="server" type="text" class="form-control" placeholder="PinCode(Optional)"></asp:TextBox>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">Address 1</label>
                                                <asp:TextBox ID="txtAdd1" runat="server" type="text" class="form-control" placeholder="Address 1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtAddress1" runat="server" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">Address 2</label>
                                                <asp:TextBox ID="txtAdd2" runat="server" type="text" class="form-control" placeholder="Address 2(Optional)"></asp:TextBox>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">City</label>
                                                <asp:TextBox ID="txtCty" runat="server" type="text" class="form-control" placeholder="City"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtCity" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">State</label>
                                                <asp:TextBox ID="txtStte" runat="server" type="text" class="form-control" placeholder="State"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtState" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">Land mark</label>
                                                <asp:TextBox ID="txtLandark" runat="server" type="text" class="form-control" placeholder="Land mark(Optional)"></asp:TextBox>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">Address Type</label>
                                                <asp:RadioButtonList ID="rdbAddresType" runat="server">
                                                    <asp:ListItem Selected="True">Home</asp:ListItem>
                                                    <asp:ListItem>Office</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="row m0 mb15">
                                                <label for="input-payment-firstname">Alternate Contact</label>
                                                <asp:TextBox ID="txtAlternatContact" runat="server" type="text" class="form-control" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                                            </div>
                                            <asp:Button ID="btnSavedAddress" class="btn btn-primary filled btn-sm" runat="server" Text="Save Changes" OnClick="btnSaveAddress_Click" ValidationGroup="SAddress" />
                                            <asp:Button ID="btnCanceledAddress" class="btn btn-primary filled btn-sm float-right" runat="server" Text="Cancel" OnClick="btnCancelAddress_Click" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </asp:Panel>

                            <asp:Panel ID="pnlMyOrder" runat="server">
                                <h4 style="border-bottom: 1px dashed #ccc; padding-bottom: 10px; margin-bottom: 25px;">Orders</h4>
                                <asp:Panel ID="pnlEmptyOrder" runat="server">
                                    <p class="saved-message">You have not placed any order yet.</p>
                                </asp:Panel>
                                <asp:Repeater ID="rptOrder" runat="server" OnItemCommand="rptOrder_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-responsive display nowrap text-center" style="width:100%">
                                            <thead>
                                                <tr>
                                                    <th class="text-center" style="border-bottom: 1px solid #ddd;">Order</th>
                                                    <th class="text-center" style="border-bottom: 1px solid #ddd;">Date</th>
                                                    <th class="text-center" style="border-bottom: 1px solid #ddd;">Status</th>
                                                    <th class="text-center" style="border-bottom: 1px solid #ddd;">Total</th>
                                                    <th class="text-center" style="border-bottom: 1px solid #ddd;">View Invoice</th>
                                                    <%--<th>Download Invoice</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hdnidOrder" runat="server" Value='<%#Eval("idCustomerOrder")%>' />
                                        <tr>
                                            <td><%# Convert.ToString(Eval("sOrderNo")) %></td>
                                            <td><%#Convert.ToDateTime(Eval("dtOrder")).ToShortDateString()%></td>
                                            <td>
                                                <%#Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Pending ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Pending): 
                                                   Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Approved? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Approved):
                                                   Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Reject ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Reject):
                                                   Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Shipped ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Shipped):
                                                   Convert.ToInt32(Eval("bStatus")) == (int)EntityLayer.OrderStatus.Delivered ? Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.Delivered): Enum.GetName(typeof(EntityLayer.OrderStatus), EntityLayer.OrderStatus.UserCancel) %>
                                            </td>
                                            <td><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("totalAmount")) %></td>
                                            <td>
                                                <asp:LinkButton ID="btnInvoice" CssClass="btn" CommandArgument='<%#Eval("idCustomerOrder")%>' runat="server">View Invoice</asp:LinkButton>
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
                                <%-- <asp:Repeater ID="rptOrder" runat="server" OnItemDataBound="rptOrder_ItemDataBound" OnItemCommand="rptOrder_ItemCommand">
                                    <ItemTemplate>
                                        <div class="panel panel-default">
                                            <asp:HiddenField ID="hdnidOrder" runat="server" Value='<%#Eval("idCustomerOrder")%>' />
                                            <div class="panel-heading" style="padding:10px 4px;">
                                                <table style="width: 100%; font-size: smaller;">
                                                    <tr>
                                                        <td style="width: 20%">ORDER PLACED<br />
                                                            <%#Convert.ToDateTime(Eval("dtOrder")).ToShortDateString()%></td>
                                                        <td style="width: 20%">SHIP TO
                                                        <br />
                                                            <%#Eval("sName")%></td>
                                                        <td style="width: 20%">STATUS
                                                        <br />
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
                                                                                    <img width="100" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>" class="rounded mx-auto d-block"></a></td>
                                                                                <td class="text-left"><a href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></td>
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
                                    </ItemTemplate>
                                </asp:Repeater>--%>
                                <asp:Panel ID="pnlPaggination" runat="server">
                                    <!-- start pagination area -->
                                    <div class="pagination">
                                        <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                                            <HeaderTemplate>
                                                <asp:LinkButton ID='lnkFirst' class="previous" CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="fa fa-angle-double-left"></i>
                                                </asp:LinkButton>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID='lnkPage' CssClass='<%# ((ListItem)Container.DataItem).Value.Equals(hdPageNo.Value) ? "active" : string.Empty %>'
                                                    CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:LinkButton ID='lnkLast' CommandName="Page" class="next" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="fa fa-angle-double-right"></i>
                                                </asp:LinkButton>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <!-- end pagination area -->
                                </asp:Panel>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
 <%--   <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">
  Launch demo modal
</button>--%>
    <!-- Modal -->
<div class="modal" id="view-invoice" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
  <div class="modal-dialog modal-lg modal-dialog-centered">
    <div class="modal-content" id="invoice-content">
      <div class="modal-header" style="padding: 1rem 3rem; border-bottom: 1px solid #dee2e6;">
        <div class="text-left float-left">
            <h3 class="mb-0">Invoice #<asp:Label ID="lblInvoiceNo" runat="server"></asp:Label></h3>
            Date:
                <asp:Label ID="lblDate" runat="server"></asp:Label>

        </div>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="card">
                    <div class="card-body">
                        <div class="row m0">
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
                                    <table class="table table-striped display nowrap table-responsive" style="width:100%;display:inline-table !important;">
                                        <thead>
                                            <tr style="white-space:nowrap;">
                                                <th>#</th>
                                                <th>Item</th>
                                                <th >Product Price</th>
                                                <th >Purchase Price</th>
                                                <th >Qty</th>
                                                <th >Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Container.ItemIndex + 1 %></td>
                                        <td style="white-space:break-spaces;"><%# Eval("sName") %></td>
                                        <%--<td class="left">
                                            <asp:Label ID="lblFeatures" runat="server" ClientIDMode="Static" Text='<%# Limit(Eval("Features"),30) %>' ToolTip='<%# Eval("Features") %>'></asp:Label>
                                            <asp:LinkButton ID="ReadMoreLinkButton" runat="server" CommandName="Readmore" Text="Read More" Visible='<%# SetVisibility(Eval("Features"), 30) %>'></asp:LinkButton>
                                        </td>--%>
                                        <td ><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductPrice")) %></td>
                                        <td ><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("PurchasePrice")) %></td>
                                        <td ><%# Eval("Quantity") %></td>
                                        <td ><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("ProductTotal")) %></td>
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
                                <table class="table table-clear">
                                    <tbody>
                                        <tr>
                                            <td class="left">
                                                <strong class="text-dark">Subtotal</strong>
                                            </td>
                                            <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <asp:Label ID="lblSubTotal" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td class="left">
                                                <strong class="text-dark">Discount</strong>
                                            </td>
                                            <td class="right"><span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span> <asp:Label ID="lblDiscount" runat="server"></asp:Label></td>
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
      </div>
      <div class="modal-footer">
        <div class="card-footer bg-white fright">
            <button type="button" class="btn btn-primary filled" style="padding: 0 25px;" onclick="DownloadInvoice()">Download</button>
            <button type="button" class="btn btn-primary filled" style="padding: 0 25px;" onclick="printInvoice()">Print</button>
            <button type="button" class="btn btn-primary filled" style="padding: 0 25px;" data-dismiss="modal">Close</button>
        </div>
      </div>
    </div>
  </div>
</div>

    <script src="<%= baseUrl %>js/jquery-3.5.1.js"></script>
    <script src="<%= baseUrl %>js/jquery.dataTables.min.js"></script>
    <%--<script src="<%= baseUrl %>js/dataTables.rowReorder.min.js"></script>--%>
    <script src="<%= baseUrl %>js/dataTables.responsive.min.js"></script>
    <script src="<%= baseUrl %>js/html2pdf.bundle.js"></script>
    <script type="text/javascript">
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
            newWin.document.write('<base href="' + location.origin + location.pathname + '">');
            newWin.document.write('<link rel="stylesheet" href="css/bootstrap.min.css">');
            newWin.document.write('<link rel="stylesheet" href="css/bootstrap-theme.min.css">');
            newWin.document.write('<link rel="stylesheet" href="css/fontawesome-all.min.css">');
            newWin.document.write('<link rel="stylesheet" href="css/style.css">');
            newWin.document.write('<link rel="stylesheet" href="css/responsive.css">');

            newWin.document.write('</head><body onload="window.print()">');
            newWin.document.write(divToPrint.innerHTML);
            newWin.document.write('</body></html>');


            newWin.document.close();
            setTimeout(function () { newWin.close(); }, 10);
            $(".btn-inv").show();
            $(".close").show();
        }

        function ShowInvoice() {
            $("#view-invoice").modal("show");
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            var pnlPersonalInfo = document.getElementById("<%= pnlPersonalInfo.ClientID %>");
            var pnlAllAddress = document.getElementById("<%= pnlAllAddress.ClientID %>");
            var pnlMyOrder = document.getElementById("<%= pnlMyOrder.ClientID %>");
            $("#accountRow .left-sidebar ul li").removeClass("selected");
            if (pnlPersonalInfo) {
                $("#accountRow .left-sidebar ul li:eq(0)").addClass("selected");
            }
            else if (pnlAllAddress) {
                $("#accountRow .left-sidebar ul li:eq(1)").addClass("selected");
            }
            else if (pnlMyOrder) {
                $("#accountRow .left-sidebar ul li:eq(2)").addClass("selected");
            }
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

    </script>
    <style type="text/css">
        td-width {
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
        .cust-address {
            border: 1px solid #c7c7c7;
            padding: 12px 15px;
            height: 240px;
        }

        .cust-address .address-action {
            position: absolute;
            bottom: 6px;
        }

        #contact_form .gender td {
            padding-right: 40px;
        }

        #contact_form .gender td input {
            margin-right: 5px;
        }
        table.dataTable thead th, table.dataTable thead td{
            padding-left:10px;
        }
    </style>
</asp:Content>
