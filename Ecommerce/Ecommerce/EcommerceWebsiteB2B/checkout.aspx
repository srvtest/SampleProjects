<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="checkout.aspx.cs" Inherits="EcommerceWebsiteB2B.checkout" %>

<%@ Import Namespace="System.Globalization" %>
<%@ MasterType VirtualPath="~/Main.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cust-address {
            border: 1px solid #c7c7c7;
            height: 240px;
            padding: 12px;
        }

        .address-action {
            position: absolute;
            bottom: 7px;
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

        .new-address {
            float: right;
            font-size: 35px;
            line-height: 0.7em;
        }

        #billingAddress .row label {
            font-weight: initial;
        }

        table.rb-list tr td input {
            margin-right: 5px;
        }

        table.rb-list tr td {
            padding-right: 35px;
        }

        .checkoutaccordion {
            margin-bottom: 46px;
        }

            .checkoutaccordion h6 {
                background-color: #f7f7f7;
                border-top: 3px solid #fd405e;
                font-size: 14px;
                padding: 15px 20px;
                position: relative;
                text-transform: capitalize;
                margin-bottom: 0;
            }

                .checkoutaccordion h6 span {
                    color: #fd405e;
                    cursor: pointer;
                    -webkit-transition: 0.4s;
                    -o-transition: 0.4s;
                    transition: 0.4s;
                    margin-left: 10px;
                }

        @media only screen and (max-width: 479.98px) {
            .checkoutaccordion h6 span {
                display: block;
                padding-top: 5px;
                margin-left: 0;
            }
        }

        .checkoutaccordion h6 span:hover {
            color: #222222;
        }
        .orderSummary h4.heading.order-summary{
                padding-left: 40px;
            }
        @media only screen and (max-width: 479.98px) {
            .checkoutaccordion h6 {
                font-size: 14px;
            }
            .orderSummary h4.heading.order-summary{
                padding-left: 0;
            }
        }

        .checkoutaccordion .card {
            border: none;
            padding: 0;
            -webkit-transition: 0.4s;
            -o-transition: 0.4s;
            transition: 0.4s;
            margin-bottom: 30px;
        }

            .checkoutaccordion .card:last-child {
                margin-bottom: 0;
            }

            .checkoutaccordion .card .card-body {
                border: 1px solid #ccc;
                font-size: 14px;
                padding: 20px;
            }

                .checkoutaccordion .card .card-body .cart-update-option {
                    border: none;
                    padding: 0;
                }

                    .checkoutaccordion .card .card-body .cart-update-option .apply-coupon-wrapper input {
                        padding: 12px 10px;
                        background-color: #f7f7f7;
                        border: 1px solid #ccc;
                        margin-right: 15px;
                    }

        @media only screen and (max-width: 479.98px) {
            .checkoutaccordion .card .card-body .cart-update-option .apply-coupon-wrapper input {
                margin-bottom: 15px;
            }
        }

        .checkoutForm .orderSummary .orderSummaryInner.table-responsive table.table-condensed tbody tr td {
            border-top: 1px solid #ddd;
        }

        .checkoutForm .orderSummary .orderSummaryInner.table-responsive .table-condensed thead tr th:last-of-type {
            min-width: 120px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="breadcrumbRow" class="row">
        <h2>checkout</h2>
        <div class="row pageTitle m0">
            <div class="container">
                <h4 class="fleft">checkout</h4>
                <ul class="breadcrumb fright">
                    <li><a href="<%= this.Master.baseUrl %>">home</a></li>
                    <li class="active">checkout</li>
                </ul>
            </div>
        </div>
    </section>

    <section class="row contentRowPad">
        <asp:HiddenField ID="hdnidAddress" runat="server" />
        <div class="container">
            <div class="row">
                <asp:Panel ID="pnlEmpty" runat="server">
                    <div class="row">
                        <div class="col-lg-12">
                            <h3>Your Cart is empty.</h3>
                            <p>Check your Saved for later items below or continue shopping.</p>
                        </div>
                        Continue Shopping <a href="<%= this.Master.baseUrl %>products.aspx" class="btn btn-sqr d-block">here.</a>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlCoupon" runat="server" CssClass="panel">
                    <div class="checkoutaccordion" id="checkoutaccordion">
                        <div class="card">
                            <h6>Have A Coupon? <span data-toggle="collapse" data-target="#couponaccordion">Click
                                            Here To Enter Your Code</span></h6>
                            <div id="couponaccordion" class="collapse" data-parent="#checkOutAccordion">
                                <div class="card-body">
                                    <div class="cart-update-option">
                                        <div class="apply-coupon-wrapper">
                                            <div class="d-block d-md-flex">
                                                <input type="text" placeholder="Enter Your Coupon Code" disabled="disabled" />
                                                <button class="btn btn-primary filled btn-md" style="margin-right:0">Apply Coupon</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlBillingShipping" runat="server" CssClass="panel checkoutForm">
                    <div class="col-sm-4 orderSummaryRow">
                        <div class="row orderSummary m0">
                            <h4 class="heading">Billing Details</h4>
                            <div class="billing-form-wrap">
                                <div class="checkout-box-wrap">
                                    <div class="row m0 mb15">
                                        <i class="fa fa-user"></i>
                                        &nbsp;<asp:Label ID="lblSName" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="row m0 mb15">
                                        <i class="fa fa-phone"></i>
                                        <asp:Label ID="lblSMobile" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="row m0 mb15">
                                        <i class="fa fa-address-card"></i>
                                        <asp:Label ID="lblSAddress1" runat="server" Text=""></asp:Label>
                                        &nbsp;<asp:Label ID="lblSAddress2" runat="server" Text=""></asp:Label>
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblSLandmark" runat="server" Text=""></asp:Label>
                                        <asp:Label ID="lblSCity" runat="server" Text=""></asp:Label>,
                                                <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblSState" runat="server" Text=""></asp:Label>
                                        -
                                            <asp:Label ID="lblSPincode" runat="server" Text=""></asp:Label>,
                                            <asp:Label ID="lblSCountry" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="row m0 mb15">
                                        <i class="fa fa-building"></i>
                                        &nbsp;<asp:Label ID="lblSAddressType" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="row m0 mb15">
                                        <label for="ordernote">Order Note</label>
                                        <br />
                                        <%--<textarea name="ordernote" id="ordernote" cols="30" rows="3" placeholder="Notes about your order, e.g. special notes for delivery."></textarea>--%>
                                        <asp:TextBox ID="txtOrderNote" TextMode="MultiLine" Rows="3" CssClass="form-control" Columns="30" MaxLength="2000" runat="server" placeholder="Notes about your order, e.g. special notes for delivery."></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-sm-8 orderSummaryRow">
                        <div class="row orderSummary m0">
                            <h4 class="heading order-summary">Order summary</h4>
                            <div class="row m0 orderSummaryInner table-responsive" style="padding-top: 0">
                                <asp:Repeater ID="rptProductDetail" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-condensed">
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
                                            <td><a style="white-space: initial;" href="<%= this.Master.baseUrl %>ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%> <strong>× <%#Eval("Quantity")%></strong></a></td>
                                            <td><%=this.Master.CurrencySymbol %> <%# String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", Eval("Total"))%></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>                               
                                    <tfoot>
                                        <tr>
                                            <td>cart subtotal</td>
                                            <td><strong><%=this.Master.CurrencySymbol %> <%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", SubtotalAmount) %></strong></td>
                                        </tr>
                                        <tr>
                                            <td>shipping</td>
                                            <td>
                                                <% if (freeShippingAmount <= SubtotalAmount || freeShippingCount <= productCount)
                                                    {  %>
                                                                Free 
                                                    <% }
                                                        else
                                                        { %>
                                                                Flat
                                                                    Rate: <%=this.Master.CurrencySymbol %> <%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", ShipmentCharges) %>
                                                <% } %>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>order total price</td>
                                            <td><strong><%=this.Master.CurrencySymbol %> <%= String.Format(CultureInfo.InvariantCulture,"{0:0,0.00}", totalAmount) %></strong></td>
                                        </tr>
                                    </tfoot>
                                        </table>    
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                    <div class="row m0 paymentMethodMode" style="margin-top: 20px;">
                        <div class="col-sm-12">
                            <h4 class="heading">select payment mode</h4>
                            <div class="row m0">
                                <label>
                                    <%--<input type="radio" name="pamentMode" id="paypal">--%>
                                    <input type="radio" id="cashon" name="pamentMode" value="cash" checked="checked" />
                                    Cash On Delivery<br />
                                    <p class="m0">Pay with cash upon delivery.</p>
                                </label>
                                <label>
                                    <input type="radio" name="pamentMode" id="directBank" disabled="disabled" />
                                    Direct Bank Transfer
                                    <br>
                                    <p class="m0">
                                        Make your payment directly into our bank account. Please use your Order ID as the payment reference. Your order wont be shipped until 
                                    the funds have cleared in our account.
                                    </p>
                                </label>
                                <label>
                                    <input type="radio" name="pamentMode" id="cheque" disabled="disabled" />
                                    Cheque Payment
                               
                                </label>
                                <label>
                                    <input type="radio" name="pamentMode" id="paypal" disabled="disabled" />
                                    Paypal
                                    <img src="<%= this.Master.baseUrl %>images/card.png" alt="" />
                                </label>
                            </div>
                        </div>
                    </div>
                    <div class="row m0 mb15">
                        <div class="col-sm-12">
                            <input type="checkbox" class="custom-control-input" id="terms" required="required" />
                            <label class="custom-control-label" for="terms">
                                I have read and agree to
                                                the website <a href="<%= this.Master.baseUrl %>termscondition.aspx">terms and conditions.</a></label>
                        </div>
                    </div>
                    <div class="row m0">
                        <div class="col-sm-12">
                            <%--   <button class="btn btn-primary filled btn-sm" type="submit">submit</button>--%>
                            <asp:Button runat="server" ID="btnPlaceOrder" Text="Place Order" class="btn btn-primary filled btn-sm" OnClick="btnPlaceOrder_Click" />
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlMessage" runat="server" CssClass="panel">
                    <div class="row">
                        <div class="col-sm-12 col-lg-6 col-lg-offset-3">
                            <div class="text-center">
                                <h3><strong>Congratulation</strong></h3>
                                <h5><strong>Your order has been Placed</strong></h5>
                            </div>
                            <hr />
                            <div class="row m0 mb15">
                                Order Number :
                                <asp:Label runat="server" ID="lblOrderNo"></asp:Label>
                            </div>
                            <div class="row m0 mb15">
                                Your Account : <a href="<%= this.Master.baseUrl %>account.aspx">Click here</a>
                            </div>
                            <div class="row m0 mb15">
                                Continue Shopping : <a href="<%= this.Master.baseUrl %>products.aspx">Click here</a>
                            </div>
                            <hr />
                            <div class="">
                                <h6>You will receive an email with tracking information once your order Approved and shipped.</h6>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <%--<div class="row">
                <div class="col-lg-4" id="alert-message" style="display: none;">
                    <button type="button" class="close" data-dismiss="alert">x</button>
                    <span class="alert-message"></span>
                </div>
            </div>--%>
            <asp:Panel ID="pnlDeliveryAddress" runat="server" CssClass="panel">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="checkout-billing-details-wrap">
                            <h4 class="contactHeading heading">Delivery Address<asp:LinkButton CssClass="new-address" ID="btnNewAddress" OnClick="btnNewAddress_Click" ToolTip="Add new address" runat="server">+</asp:LinkButton></h4>

                            <div class="row" style="margin-top: 30px;">
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
                                                    <h5><strong>
                                                        <asp:Label ID="lblCustName" runat="server" Text='<%# Eval("sName") %>'></asp:Label></strong>
                                                        <asp:Label ID="lblDefault" runat="server" Text='<%# (!string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) && Convert.ToInt16(Eval("IsDefaultAddr")) == 1) ? "(Default)" : "" %>'></asp:Label></h5>
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
                                                    <asp:Button runat="server" ID="btnSelectAddress" Text="Deliver to this address" class="btn btn-primary filled btn-sm btndeli" CommandName="Deliveraddress" />
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
            <asp:Panel ID="pnlNewAddress" runat="server" CssClass="panel row checkoutForm">
                <div class="row m0">
                    <asp:HiddenField ID="hdnidCustomerAddress" runat="server" />
                    <div class="col-sm-5" id="billingAddress">
                        <h4 class="contactHeading heading">Add New Address</h4>

                        <div class="row m0 mb15">
                            <label for="txtName" class="required">Name</label>
                            <asp:TextBox ID="txtName" runat="server" type="text" class="form-control" placeholder="Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row mb15">
                            <div class="col-sm-6">
                                <label for="txtAddress1" class="required">Address 1</label>
                                <asp:TextBox ID="txtAddress1" runat="server" class="form-control" type="text" placeholder="Address 1"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAddress1" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-sm-6">
                                <label for="txtAddress2">Address 2</label>
                                <asp:TextBox ID="txtAddress2" runat="server" class="form-control" type="text" placeholder="Address 2(Optional)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row m0 mb15">
                            <label for="txtCity" class="required">City</label>
                            <asp:TextBox ID="txtCity" runat="server" type="text" class="form-control" placeholder="City"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCity" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row m0 mb15">
                            <label for="txtState" class="required">State</label>
                            <asp:TextBox ID="txtState" runat="server" type="text" class="form-control" placeholder="State"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtState" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                        </div>
                        <div class="row m0 mb15">
                            <label for="txtLandmark">Land mark</label>
                            <asp:TextBox ID="txtLandmark" runat="server" type="text" class="form-control" placeholder="Land mark(Optional)"></asp:TextBox>
                        </div>
                        <div class="row m0 mb15">
                            <label for="txtAlternateContact">Alternate Contact</label>
                            <asp:TextBox ID="txtAlternateContact" runat="server" type="text" class="form-control" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                        </div>



                        <%--  <input type="text" name="companyName" id="companyName" placeholder="Company Name" class="form-control">
                        <input type="text" name="address" id="address" placeholder="Address" class="form-control">
                        <input type="text" name="townCity" id="townCity" placeholder="Town / City" class="form-control">
                        <input type="text" name="stateCountry" id="stateCountry" placeholder="State / Country" class="form-control">--%>
                        <div class="row mb15">
                            <div class="col-sm-6">
                                <%-- <input type="text" name="zipcode" id="zipcode" placeholder="Postcode / ZIP" class="form-control">--%>
                                <label for="txtPinCode">PinCode</label>
                                <asp:TextBox ID="txtPinCode" runat="server" class="form-control" type="text" placeholder="PinCode(Optional)"></asp:TextBox>
                            </div>
                            <div class="col-sm-6">
                                <%--<input type="tel" name="phone" id="phone" placeholder="Phone" class="form-control">--%>
                                <label for="txtMobile" class="required">Mobile</label>
                                <asp:TextBox ID="txtMobile" runat="server" type="text" class="form-control required" placeholder="Mobile"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMobile" Display="Dynamic" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationGroup="grpAddress" ForeColor="Red" ControlToValidate="txtMobile" ErrorMessage="Please enter valid mobile no." Display="Dynamic" ValidationExpression="^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="row m0 mb15">
                            <label for="postcode" class="required">Address Type</label>
                            <asp:RadioButtonList ID="rdbAddressType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table" CssClass="rb-list">
                                <asp:ListItem Selected="True" Value="Home" Text="Home"></asp:ListItem>
                                <asp:ListItem Text="Office" Value="Office"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <asp:Button runat="server" ID="btnAddAddress" Text="Add address & continue" OnClick="btnAddAddress_Click" class="btn btn-primary filled btn-sm" ValidationGroup="grpAddress" />
                        <asp:Button runat="server" ID="btnNewAddressCancel" Text="Cancel" OnClick="btnNewAddressCancel_Click" class="btn btn-primary filled btn-sm fright" />

                        <%-- <input type="checkbox" name="shippingAddressEscape" id="shippingAddressEscape">
                        <label for="shippingAddressEscape">Ship Items To The Above Billing Address</label>--%>
                    </div>
                </div>
            </asp:Panel>


        </div>
    </section>
    <%-- <dialog id="myDialog" class="modal-dialog modal-lg" style="background: border-box; border: none;">
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
    </dialog>--%>
    <script>
        function ShowFormNewAddress() {
            $([document.documentElement, document.body]).animate({
                scrollTop: $(".checkoutForm").offset().top - 65
            }, 2000);
        }
        //function showAlertMessage(type, message) {
        //    $("#alert-message").removeClass('alert alert-success');
        //    var msgType = "";
        //    if (type == 'success') {
        //        $("#alert-message").addClass('alert alert-success')
        //        msgType = "<strong>Success! </strong>";
        //    }
        //    else if (type == 'danger') {
        //        $("#alert-message").addClass('alert alert-danger')
        //        msgType = "<strong>Error! </strong>";
        //    }
        //    else if (type == 'warning') {
        //        $("#alert-message").addClass('alert alert-warning')
        //        msgType = "<strong>Warning! </strong>";
        //    }
        //    $(".alert-message").html(msgType + message);
        //    $("#alert-message").fadeTo(2000, 500).slideUp(500, function () {
        //        $("#alert-message").slideUp(500);
        //    });
        //}
    </script>
</asp:Content>
