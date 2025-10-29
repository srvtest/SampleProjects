<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="checkout.aspx.cs" Inherits="EcommerceWebsite2.checkout" %>
<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- breadcrumb area start -->
    <div class="breadcrumb-area">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="breadcrumb-wrap">
                        <nav aria-label="breadcrumb">
                            <ul class="breadcrumb">
                                <li class="breadcrumb-item"><a href="/"><i class="fa fa-home"></i></a></li>
                                <li class="breadcrumb-item"><a href="../products.aspx">shop</a></li>
                                <li class="breadcrumb-item active">checkout</li>
                            </ul>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- breadcrumb area end -->
    <!-- checkout main wrapper start -->
    <div class="checkout-page-wrapper section-padding">
        <asp:HiddenField ID="hdnidAddress" runat="server" />
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <asp:Panel ID="pnlEmpty" runat="server">
                        <div class="row">
                            <div class="col-lg-12">
                                <h3>Your Cart is empty.</h3>
                                <p>Check your Saved for later items below or continue shopping.</p>
                            </div>
                            Continue Shopping <a href="../products.aspx" class="btn btn-sqr d-block">here.</a>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlCoupon" runat="server" CssClass="panel panel-default">
                        <!-- Checkout Login Coupon Accordion Start -->
                        <div class="checkoutaccordion" id="checkOutAccordion">
                            <asp:Panel ID="pnlLogin" runat="server" CssClass="panel panel-default" Visible="false">
                                <div class="card">
                                    <h6>Returning Customer? <span data-toggle="collapse" data-target="#logInaccordion">Click
                                            Here To Login</span></h6>
                                    <div id="logInaccordion" class="collapse" data-parent="#checkOutAccordion">
                                        <div class="card-body">
                                            <p>
                                                If you have shopped with us before, please enter your details in the boxes
                                            below. If you are a new customer, please proceed to the Billing &amp;
                                            Shipping section.
                                            </p>
                                            <div class="login-reg-form-wrap mt-20">
                                                <div class="row">
                                                    <div class="col-lg-7 m-auto">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="single-input-item">
                                                                    <input type="email" placeholder="Enter your Email" required />
                                                                </div>
                                                            </div>

                                                            <div class="col-md-12">
                                                                <div class="single-input-item">
                                                                    <input type="password" placeholder="Enter your Password" required />
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="single-input-item">
                                                            <div class="login-reg-form-meta d-flex align-items-center justify-content-between">
                                                                <div class="remember-meta">
                                                                    <div class="custom-control custom-checkbox">
                                                                        <input type="checkbox" class="custom-control-input" id="rememberMe" required />
                                                                        <label class="custom-control-label" for="rememberMe">
                                                                            Remember
                                                                            Me</label>
                                                                    </div>
                                                                </div>

                                                                <a href="#" class="forget-pwd">Forget Password?</a>
                                                            </div>
                                                        </div>

                                                        <div class="single-input-item">
                                                            <button class="btn btn-sqr">Login</button>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="card">
                                <h6>Have A Coupon? <span data-toggle="collapse" data-target="#couponaccordion">Click
                                            Here To Enter Your Code</span></h6>
                                <div id="couponaccordion" class="collapse" data-parent="#checkOutAccordion">
                                    <div class="card-body">
                                        <div class="cart-update-option">
                                            <div class="apply-coupon-wrapper">
                                                <div class="d-block d-md-flex">
                                                    <input type="text" placeholder="Enter Your Coupon Code" />
                                                    <button class="btn btn-sqr" disabled="disabled">Apply Coupon</button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Checkout Login Coupon Accordion End -->
                    </asp:Panel>

                    <asp:Panel ID="pnlDeliveryAddress" runat="server" CssClass="panel panel-default">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="checkout-billing-details-wrap">
                                    <h5 class="checkout-title">Delivery Address<asp:LinkButton CssClass="new-address" ID="btnNewAddress" OnClick="btnNewAddress_Click" ToolTip="Add new address" runat="server">+</asp:LinkButton></h5>

                                    <div class="row">
                                        <asp:Repeater ID="rptAddress" runat="server" OnItemCommand="rptAddress_ItemCommand" OnItemDataBound="rptAddress_ItemDataBound">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("idCustomerAddress")%>' />
                                                <asp:Label ID="lblAddress" runat="server" Text="" Visible="false"></asp:Label>
                                                <div class="col-sm-6 col-lg-3" style="margin-bottom: 30px;">
                                                    <div class="cust-address">
                                                        <div class="card-body">
                                                            <%--<asp:HiddenField ID="hdnIdCustomerAddress" runat="server" Value='<%# Eval("idCustomerAddress") %>' />--%>
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
                                                            <span class='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("sAddress2"))) ? "show-br" : "hide-br" %>'>
                                                                <br />
                                                            </span>
                                                            <asp:Label ID="lblLandmark" runat="server" Text='<%# Eval("sLandMark") %>'></asp:Label>
                                                            <span class='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("sLandMark"))) ? "show-br" : "hide-br" %>'>
                                                                <br />
                                                            </span>
                                                            <asp:Label ID="lblCity" runat="server" Text='<%# Eval("sCity")%>'></asp:Label>,<asp:Label ID="lblState" runat="server" Text='<%# Eval("sState") %>'></asp:Label><asp:Label ID="lblPincode" runat="server" Text='<%# " " + Eval("PinCode") %>'></asp:Label><br />
                                                            <asp:Label ID="lblCountry" ClientIDMode="Static" runat="server" Text='<%# Eval("CountryName")%>'></asp:Label><br />
                                                            Phone number:
                                                            <asp:Label ID="lblMobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label>
                                                        </div>
                                                        <div class="address-action">
                                                            <asp:Button runat="server" ID="btnSelectAddress" Text="Deliver to this address" class="btn btn-sqr btnmar" CommandName="Deliveraddress" />
                                                        </div>
                                                    </div>
                                                </div>

                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlNewAddress" runat="server" CssClass="panel panel-default panelmar">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="add-new-address">
                                    <asp:HiddenField ID="hdnidCustomerAddress" runat="server" />
                                    <fieldset class="mt-20">
                                        <legend>Add new address</legend>
                                        <div class="row">
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtName" class="required">Name</label>
                                                    <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtMobile" class="required">Mobile</label>
                                                    <asp:TextBox ID="txtMobile" runat="server" type="text" class="required" placeholder="Mobile"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMobile" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="grpAddress" ForeColor="Red" ControlToValidate="txtMobile" ErrorMessage="Please enter valid mobile no." Display="Dynamic" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtAddress1" class="required">Address 1</label>
                                                    <asp:TextBox ID="txtAddress1" runat="server" type="text" placeholder="Address 1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAddress1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtAddress2">Address 2</label>
                                                    <asp:TextBox ID="txtAddress2" runat="server" type="text" placeholder="Address 2(Optional)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtPinCode">PinCode</label>
                                                    <asp:TextBox ID="txtPinCode" runat="server" type="text" placeholder="PinCode(Optional)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtCity" class="required">City</label>
                                                    <asp:TextBox ID="txtCity" runat="server" type="text" placeholder="City"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCity" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtState" class="required">State</label>
                                                    <asp:TextBox ID="txtState" runat="server" type="text" placeholder="State"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtState" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtLandmark">Land mark</label>
                                                    <asp:TextBox ID="txtLandmark" runat="server" type="text" placeholder="Land mark(Optional)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="postcode" class="required">Address Type</label>
                                                    <asp:RadioButtonList ID="rdbAddressType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="rb-list">
                                                        <asp:ListItem Selected="True" Value="Home" Text="Home"></asp:ListItem>
                                                        <asp:ListItem Text="Office" Value="Office"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>
                                            <div class="col-lg-6 col-sm-12">
                                                <div class="single-input-item">
                                                    <label for="txtAlternateContact">Alternate Contact</label>
                                                    <asp:TextBox ID="txtAlternateContact" runat="server" type="text" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="single-input-item">
                                                    <asp:Button runat="server" ID="btnAddAddress" Text="Add address" OnClick="btnAddAddress_Click" class="btn btn-sqr" ValidationGroup="grpAddress" />
                                                    <asp:Button runat="server" ID="btnNewAddressCancel" Text="Cancel" OnClick="btnNewAddressCancel_Click" class="btn btn-sqr float-right" />
                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlBillingShipping" runat="server" CssClass="panel panel-default panelmar">
                        <div class="row">
                            <!-- Checkout Billing Details -->
                            <div class="col-lg-4">
                                <div class="checkout-billing-details-wrap">
                                    <h5 class="checkout-title">Billing Details</h5>
                                    <div class="billing-form-wrap">
                                        <div class="checkout-box-wrap">
                                            <div class="single-input-item">
                                                <i class="fa fa-user"></i>
                                                <asp:Label ID="lblSName" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="single-input-item">
                                                <i class="fa fa-phone"></i>
                                                <asp:Label ID="lblSMobile" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="single-input-item">
                                                <i class="fa fa-address-card"></i>
                                                <asp:Label ID="lblSAddress1" runat="server" Text=""></asp:Label>
                                                &nbsp;<asp:Label ID="lblSAddress2" runat="server" Text=""></asp:Label>
                                                <p>
                                                    <asp:Label ID="lblSLandmark" runat="server" Text=""></asp:Label>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblSCity" runat="server" Text=""></asp:Label>,
                                                &nbsp;<asp:Label ID="lblSState" runat="server" Text=""></asp:Label>
                                                    &nbsp;<asp:Label ID="lblSPincode" runat="server" Text=""></asp:Label>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblSCountry" runat="server" Text=""></asp:Label>
                                                </p>
                                            </div>
                                            <div class="single-input-item">
                                                <i class="fa fa-building"></i>
                                                <asp:Label ID="lblSAddressType" runat="server" Text=""></asp:Label>
                                            </div>
                                            <%--<div class="single-input-item">
                                                <div class="custom-control custom-checkbox">
                                                    <input type="checkbox" class="custom-control-input" id="add_new_address" />
                                                    <label class="custom-control-label" for="add_new_address">
                                                        New Address?</label>
                                                </div>
                                            </div>--%>
                                            <%--<div class="add-new-address single-form-row">
                                                <asp:HiddenField ID="hdnidCustomerAddress" runat="server" />

                                                <div class="single-input-item">
                                                    <label for="txtName" class="required">Name</label>
                                                    <asp:TextBox ID="txtName" runat="server" type="text" placeholder="Name"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="txtMobile" class="required">Mobile</label>
                                                    <asp:TextBox ID="txtMobile" runat="server" type="text" class="required" placeholder="Mobile"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMobile" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="txtPinCode">PinCode</label>
                                                    <asp:TextBox ID="txtPinCode" runat="server" type="text" placeholder="PinCode(Optional)"></asp:TextBox>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="txtAddress1" class="required">Address 1</label>
                                                    <asp:TextBox ID="txtAddress1" runat="server" type="text" placeholder="Address 1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAddress1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="single-input-item">
                                                    <asp:TextBox ID="txtAddress2" runat="server" type="text" placeholder="Address 2(Optional)"></asp:TextBox>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="txtCity" class="required">City</label>
                                                    <asp:TextBox ID="txtCity" runat="server" type="text" placeholder="City"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCity" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="txtState" class="required">State</label>
                                                    <asp:TextBox ID="txtState" runat="server" type="text" placeholder="State"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtState" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="txtLandmark">Land mark</label>
                                                    <asp:TextBox ID="txtLandmark" runat="server" type="text" placeholder="Land mark(Optional)"></asp:TextBox>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="postcode" class="required">Address Type</label>
                                                    <asp:RadioButtonList ID="rdbAddressType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="rb-list">
                                                        <asp:ListItem Selected="True" Value="Home" Text="Home"></asp:ListItem>
                                                        <asp:ListItem Text="Office" Value="Office"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="txtAlternateContact">Alternate Contact</label>
                                                    <asp:TextBox ID="txtAlternateContact" runat="server" type="text" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                                                </div>
                                            </div>--%>
                                            <%--<div class="checkout-box-wrap">
                                                <div class="single-input-item">
                                                    <div class="custom-control custom-checkbox">
                                                        <input type="checkbox" class="custom-control-input" id="create_pwd">
                                                        <label class="custom-control-label" for="create_pwd">
                                                            Create an
                                                    account?</label>
                                                    </div>
                                                </div>
                                                <div class="account-create single-form-row">
                                                    <p>
                                                        Create an account by entering the information below. If you are a
                                                returning customer please login at the top of the page.
                                                    </p>
                                                    <div class="single-input-item">
                                                        <label for="pwd" class="required">Account Password</label>
                                                        <input type="password" id="pwd" placeholder="Account Password" required />
                                                    </div>
                                                </div>
                                            </div>--%>
                                            <%--<div class="single-input-item">
                                                <div class="custom-control custom-checkbox">
                                                    <input type="checkbox" class="custom-control-input" id="ship_to_different" />
                                                    <label class="custom-control-label" for="ship_to_different">
                                                        Ship to a different address?</label>
                                                </div>
                                            </div>
                                            <div class="ship-to-different single-form-row">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="single-input-item">
                                                            <label for="f_name_2" class="required">First Name</label>
                                                            <input type="text" id="f_name_2" placeholder="First Name" />
                                                        </div>
                                                    </div>

                                                    <div class="col-md-6">
                                                        <div class="single-input-item">
                                                            <label for="l_name_2" class="required">Last Name</label>
                                                            <input type="text" id="l_name_2" placeholder="Last Name" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="email_2" class="required">Email Address</label>
                                                    <input type="email" id="email_2" placeholder="Email Address" />
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="com-name_2">Company Name</label>
                                                    <input type="text" id="com-name_2" placeholder="Company Name" />
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="country_2" class="required">Country</label>
                                                    <select name="country" id="country_2">
                                                        <option value="Bangladesh">Bangladesh</option>
                                                        <option value="India">India</option>
                                                        <option value="Pakistan">Pakistan</option>
                                                        <option value="England">England</option>
                                                        <option value="London">London</option>
                                                        <option value="London">London</option>
                                                        <option value="Chaina">Chaina</option>
                                                    </select>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="street-address_2" class="required mt-20">Street address</label>
                                                    <input type="text" id="street-address_2" placeholder="Street address Line 1" />
                                                </div>

                                                <div class="single-input-item">
                                                    <input type="text" placeholder="Street address Line 2 (Optional)" />
                                                </div>

                                                <div class="single-input-item">
                                                    <asp:TextBox ID="TextBox1" runat="server" type="text" placeholder="Address 2(Optional)"></asp:TextBox>
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="town_2" class="required">Town / City</label>
                                                    <input type="text" id="town_2" placeholder="Town / City" />
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="state_2">State / Divition</label>
                                                    <input type="text" id="state_2" placeholder="State / Divition" />
                                                </div>

                                                <div class="single-input-item">
                                                    <label for="postcode_2" class="required">Postcode / ZIP</label>
                                                    <input type="text" id="postcode_2" placeholder="Postcode / ZIP" />
                                                </div>
                                            </div>--%>
                                            <div class="single-input-item">
                                                <label for="ordernote">Order Note</label>
                                                <%--<textarea name="ordernote" id="ordernote" cols="30" rows="3" placeholder="Notes about your order, e.g. special notes for delivery."></textarea>--%>
                                                <asp:TextBox ID="txtOrderNote" TextMode="MultiLine" Rows="3" Columns="30" MaxLength="2000" runat="server" placeholder="Notes about your order, e.g. special notes for delivery."></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- Order Summary Details -->
                            <div class="col-lg-8">
                                <div class="order-summary-details">
                                    <h5 class="checkout-title">Your Order Summary</h5>
                                    <div class="order-summary-content">
                                        <!-- Order Summary Table -->
                                        <div class="order-summary-table table-responsive text-center">
                                            <asp:Repeater ID="rptProductDetail" runat="server">
                                                <HeaderTemplate>
                                                    <table class="table table-bordered">
                                                        <thead>
                                                            <tr>
                                                                <th>Products</th>
                                                                <th>Total</th>
                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <a href="../ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%> <strong>× <%#Eval("Quantity")%></strong></a>
                                                        </td>
                                                        <td><%=this.Master.CurrencySymbol %><%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Total")) %></td>
                                                    </tr>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                                    <tfoot>
                                        <tr>
                                            <td>Sub Total</td>
                                            <td><strong><%=this.Master.CurrencySymbol %><%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", SubtotalAmount) %></strong></td>
                                        </tr>
                                        <tr>
                                            <td>Shipping</td>
                                            <td class="justify-content-center">
                                                <ul class="shipping-type1">
                                                    <% if (freeShippingAmount <= SubtotalAmount || freeShippingCount <= productCount)
                                                        {  %>
                                                    <li>
                                                        <div class="custom-control">
                                                            <%--<input type="radio" id="freeshipping" name="shipping" class="custom-control-input" checked />--%>
                                                            <label class="" for="freeshipping">
                                                                Free 
                                                            </label>
                                                        </div>
                                                    </li>
                                                    <% }
                                                    else
                                                    { %>
                                                    <li>
                                                        <div class="custom-control">
                                                            <%--<input type="radio" id="flatrate" name="shipping" class="custom-control-input" checked />--%>
                                                            <label class="" for="flatrate">
                                                                Flat
                                                                    Rate: <%=this.Master.CurrencySymbol %><%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", ShipmentCharges) %></label>
                                                        </div>
                                                    </li>
                                                    <% } %>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Total Amount</td>
                                            <td><strong><%=this.Master.CurrencySymbol %><%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", totalAmount) %></strong></td>
                                        </tr>
                                    </tfoot>
                                                    </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <!-- Order Payment Method -->
                                        <div class="order-payment-method">
                                            <div class="single-payment-method show">
                                                <div class="payment-method-name">
                                                    <div class="custom-control custom-radio">
                                                        <input type="radio" id="cashon" name="paymentmethod" value="cash" class="custom-control-input" checked />
                                                        <label class="custom-control-label" for="cashon">Cash On Delivery</label>
                                                    </div>
                                                </div>
                                                <div class="payment-method-details" data-method="cash">
                                                    <p>Pay with cash upon delivery.</p>
                                                </div>
                                            </div>
                                            <%--<div class="single-payment-method">
                                                <div class="payment-method-name">
                                                    <div class="custom-control custom-radio">
                                                        <input type="radio" id="directbank" name="paymentmethod" value="bank" class="custom-control-input" />
                                                        <label class="custom-control-label" for="directbank">
                                                            Direct Bank
                                                    Transfer</label>
                                                    </div>
                                                </div>
                                                <div class="payment-method-details" data-method="bank">
                                                    <p>
                                                        Make your payment directly into our bank account. Please use your Order
                                                ID as the payment reference. Your order will not be shipped until the
                                                funds have cleared in our account..
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="single-payment-method">
                                                <div class="payment-method-name">
                                                    <div class="custom-control custom-radio">
                                                        <input type="radio" id="checkpayment" name="paymentmethod" value="check" class="custom-control-input" />
                                                        <label class="custom-control-label" for="checkpayment">
                                                            Pay with
                                                    Check</label>
                                                    </div>
                                                </div>
                                                <div class="payment-method-details" data-method="check">
                                                    <p>
                                                        Please send a check to Store Name, Store Street, Store Town, Store State
                                                / County, Store Postcode.
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="single-payment-method">
                                                <div class="payment-method-name">
                                                    <div class="custom-control custom-radio">
                                                        <input type="radio" id="paypalpayment" name="paymentmethod" value="paypal" class="custom-control-input" />
                                                        <label class="custom-control-label" for="paypalpayment">
                                                            Paypal
                                                <img src="assets/img/paypal-card.jpg" class="img-fluid paypal-card" alt="Paypal" /></label>
                                                    </div>
                                                </div>
                                                <div class="payment-method-details" data-method="paypal">
                                                    <p>
                                                        Pay via PayPal; you can pay with your credit card if you don’t have a
                                                PayPal account.
                                                    </p>
                                                </div>
                                            </div>--%>
                                            <div class="summary-footer-area">
                                                <div class="custom-control custom-checkbox mb-20">
                                                    <input type="checkbox" class="custom-control-input" id="terms" required />
                                                    <label class="custom-control-label" for="terms">
                                                        I have read and agree to
                                                the website <a href="../terms-conditions.aspx">terms and conditions.</a></label>
                                                </div>
                                                <asp:Button runat="server" ID="btnPlaceOrder" Text="Place Order" class="btn btn-sqr" OnClick="btnPlaceOrder_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlMessage" runat="server" CssClass="panel panel-default panelmar">
                        <div class="row">
                            <div class="col-lg-6 mx-auto">
                                <div class="single-input-item text-center">
                                    <h3><strong>Congratulation</strong></h3>
                                    <h5><strong>Your order has been Placed</strong></h5>
                                </div>
                                <hr />
                                <div class="single-input-item">
                                    Order Number :
                                <asp:Label runat="server" ID="lblOrderNo"></asp:Label>
                                </div>
                                <div class="single-input-item">
                                    Your Account : <a href="../account.aspx">Click here</a>
                                </div>
                                <div class="single-input-item">
                                    Continue Shopping : <a href="../index.aspx">Click here</a>
                                </div>
                                <hr />
                                <div class="single-input-item">
                                    <h6>You will receive an email with tracking information once your order Approved and shipped.</h6>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <!-- checkout main wrapper end -->
    <dialog id="myDialog" class="modal-dialog modal-lg" style="background: border-box; border: none;">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">Message</h4>
                <asp:LinkButton ID="btnClose" class="close" runat="server" OnClick="btnOk_Click">&times;</asp:LinkButton>
            </div>
            <div class="modal-body">
                <p>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </p>
            </div>
            <div class="modal-footer">
                <asp:Button ID="btnOk" runat="server" Text="OK" class="btn" OnClick="btnOk_Click" />
            </div>
        </div>
    </dialog>
    <style type="text/css">
        .btnmar {
            margin-left: 28px;
        }

        .panelmar {
            margin-bottom: 50px;
        }

        table.rb-list td {
            padding-right: 50px;
        }
        /*#contact_form label {
            font-weight: normal;
            margin-left: 4px;
        }*/

        .cust-address {
            border: 1px solid #c7c7c7;
            /*padding: 12px 18px;*/
            height: 240px;
        }

        .address-action {
            position: absolute;
            bottom: 7px;
        }

            /*.card-body {
            height: 160px;
        }*/

            .address-action a {
                color: #0066c0;
            }

        .show-br {
            display: inline;
        }

        .hide-br {
            display: none;
        }

        .new-address {
            float: right;
            font-size: 35px;
            line-height: 0.7em;
        }

        .add-new-address .btn-sqr {
            width: 150px;
            background-color: #45cfbe;
            color: #fff;
            border: 0;
        }

            .add-new-address .btn-sqr:hover {
                background-color: #000;
            }

            .add-new-address .btn-sqr:focus {
                background-color: #45cfbe;
            }

        .single-input-item i {
            margin-right: 7px;
        }

        .single-input-item p {
            margin-left: 23px;
        }
    </style>
    <script>
        function ShowMessageForm() {
            document.getElementById("myDialog").showModal();
        }
    </script>
</asp:Content>
