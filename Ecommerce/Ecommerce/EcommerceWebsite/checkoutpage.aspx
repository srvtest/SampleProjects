<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="checkoutpage.aspx.cs" Inherits="EcommerceWebsite.checkoutpage" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<%@ Register Src="~/UCbrandcarouse.ascx" TagPrefix="uc1" TagName="UCbrandcarouse" %>
<%--<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>
<%@ Register Src="~/UCTopProducts.ascx" TagPrefix="uc1" TagName="UCTopProducts" %>--%>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BANNER STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Shopping Cart</h1>
                    <ul>
                        <li><a href="/">Home</a></li>
                        <li class="active">Shopping Cart</li>
                    </ul>
                </div>
            </div>
            <div class="col-sm-8 col-lg-9 mtb_20" style="margin-left: 10px;">
                <div class="panel-group">

                    <asp:Panel ID="pnlEmpty" runat="server">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Cart Detail<i class="fa fa-caret-down"></i></a></h4>
                        </div>
                        <div class="panel-collapse collapse in">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h3>Your Cart is empty.</h3>
                                        <p>Check your Saved for later items below or continue shopping.</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>


                    <asp:Panel ID="pnl1" runat="server" CssClass="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Checkout Options <i class="fa fa-caret-down"></i></a></h4>
                        </div>
                        <div class="panel-collapse collapse in">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-6">
                                        <h3>Customer Detail</h3>
                                        <p>
                                            Name :
                                            <asp:Label runat="server" ID="lblName"></asp:Label>
                                        </p>
                                        <p>
                                            Email :
                                            <asp:Label runat="server" ID="lblEmail"></asp:Label>
                                        </p>
                                        <p>be up to date on an order's status, and keep track of the orders you have previously made.</p>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="pull-right">
                                        <asp:Button runat="server" ID="pnl1Continue" Text="Continue" class="btn" data-loading-text="Loading..." OnClick="pnl1Continue_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Pnl2" runat="server" CssClass="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Delivery Address <i class="fa fa-caret-down"></i></a></h4>
                        </div>
                        <div class="panel-collapse collapse in">
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <asp:Panel ID="pnlExistAddress" runat="server">
                                        <asp:HiddenField ID="hdnidAddress" runat="server" />
                                        <asp:Repeater ID="rptAddress" runat="server" OnItemCommand="rptAddress_ItemCommand" OnItemDataBound="rptAddress_ItemDataBound">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnid" runat="server" Value='<%#Eval("idCustomerAddress")%>' />
                                                <asp:Label ID="lblAddress" runat="server" Text="" Visible="false"></asp:Label>
                                                <%-- <div class="col-sm-6 rounded">
                                                    

                                                    <span style="font-size: medium;"><%#Eval("AddressType")%></span><br />
                                                    <span style="font-size: large;"><%#Eval("sName")%></span><br />
                                                    <span><%#Eval("sAddress1")%></span> , <span><%#Eval("sAddress2")%></span><br />
                                                    <span><%#Eval("sLandMark")%></span><br />
                                                    <span><%#Eval("PinCode")%></span><br />
                                                    <span><%#Eval("sCity")%></span> <span><%#Eval("sState")%></span><br />
                                                    <span><%#Eval("Mobile")%></span> , <span><%#Eval("AlternateNo")%></span><br />
                                                    
                                                </div>--%>

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
                                                            <asp:Button runat="server" ID="btnSelectAddress" Text="Deliver to this address" class="btn" data-loading-text="Loading..." CommandName="Deliveraddress" />
                                                            <%--<asp:LinkButton ID="btnEditAddress" OnClick="btnEditAddress_Click" runat="server">Edit</asp:LinkButton>
                                                            <asp:Label ID="lbl1" runat="server" Text='|'></asp:Label>
                                                            <asp:LinkButton ID="btnRemove" CommandArgument='<%# Eval("idCustomerAddress") %>' runat="server" OnClick="btnRemove_Click" OnClientClick="return confirm('Are you sure you want to delete the address?');">Remove</asp:LinkButton>
                                                            <asp:Label ID="lbl2" runat="server" Text='|' Visible='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) || Convert.ToInt16(Eval("IsDefaultAddr")) != 1) ? true : false%>'></asp:Label>
                                                            <asp:LinkButton ID="btnSetDefault" CommandArgument='<%# Eval("idCustomerAddress") %>' runat="server" OnClick="btnSetDefault_Click" Visible='<%# (string.IsNullOrEmpty(Convert.ToString(Eval("IsDefaultAddr"))) || Convert.ToInt16(Eval("IsDefaultAddr")) != 1) ? true : false%>'>Set as default</asp:LinkButton>--%>
                                                        </div>
                                                    </div>
                                                </div>

                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </asp:Panel>
                                    <br />
                                    <asp:Panel ID="pnlNewAddress" runat="server">
                                        <asp:CheckBox runat="server" ID="chkAddNewAddress" AutoPostBack="true" OnCheckedChanged="chkAddNewAddress_CheckedChanged" />
                                        Add New Address
                                    </asp:Panel>
                                    <asp:Panel ID="pnlNew" runat="server" Visible="false">
                                        <asp:HiddenField ID="hdnidCustomerAddress" runat="server" />
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">Name</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtName" runat="server" type="text" class="form-control" placeholder="Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ForeColor="Red" ErrorMessage="Please Enter Name" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">Mobile</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtMobile" runat="server" type="text" class="form-control" placeholder="Mobile"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtMobile" runat="server" ForeColor="Red" ErrorMessage="Please Enter Mobile" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">PinCode</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtPinCode" runat="server" type="text" class="form-control" placeholder="PinCode(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">Address 1</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAddress1" runat="server" type="text" class="form-control" placeholder="Address 1"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtAddress1" runat="server" ForeColor="Red" ErrorMessage="Please Enter Address 1" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">Address 2</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAddress2" runat="server" type="text" class="form-control" placeholder="Address 2(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">City</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtCity" runat="server" type="text" class="form-control" placeholder="City"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtCity" runat="server" ForeColor="Red" ErrorMessage="Please Enter City" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">State</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtState" runat="server" type="text" class="form-control" placeholder="State"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtState" runat="server" ForeColor="Red" ErrorMessage="Please Enter State" ValidationGroup="grpAddress"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">Land mark</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtLandmark" runat="server" type="text" class="form-control" placeholder="Land mark(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">Address Type</label>
                                            <div class="col-sm-10">
                                                <asp:RadioButtonList ID="rdbAddressType" runat="server">
                                                    <asp:ListItem Selected="True">Home</asp:ListItem>
                                                    <asp:ListItem>Office</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="form-group required">
                                            <label for="input-payment-firstname" class="col-sm-2 control-label">Alternate Contact</label>
                                            <div class="col-sm-10">
                                                <asp:TextBox ID="txtAlternateContact" runat="server" type="text" class="form-control" placeholder="Alternate Contact(Optional)"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="pull-right">
                                            <asp:Button runat="server" ID="btnAddress" Text="Add Address" class="btn" data-loading-text="Loading..." OnClick="btnAddress_Click" ValidationGroup="grpAddress" />
                                        </div>
                                    </asp:Panel>


                                </div>
                            </div>
                        </div>
                        <div class="panel-footer" style="padding: 45px 25px;">
                            <div class="pull-left">
                                <asp:Button runat="server" ID="pnl2Previous" Text="Previous" class="btn" data-loading-text="Loading..." OnClick="pnl2Previous_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Pnl3" runat="server" CssClass="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Confirm Order <i class="fa fa-caret-down"></i></a></h4>
                        </div>
                        <div class="panel-collapse collapse in">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="table-responsive">
                                        <asp:Repeater ID="rptProductDetail" runat="server">
                                            <HeaderTemplate>
                                                <table class="table table-bordered table-hover">
                                                    <thead>
                                                        <tr>
                                                            <td class="text-left">Image</td>
                                                            <td class="text-left">Product Name</td>
                                                            <td class="text-right">Quantity</td>
                                                            <td class="text-right">Unit Price</td>
                                                            <td class="text-right">Total</td>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td class="text-center" style="width: 70px"><a href="#">
                                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>" class="rounded mx-auto d-block"></a></td>
                                                    <td class="text-left"><a href="../ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></td>
                                                    <td class="text-right"><%#Eval("Quantity")%></td>
                                                    <td class="text-right">
                                                        <span class="price">
                                                            <span class="amount">
                                                                <span class="currencySymbol"><%=((main_master)this.Page.Master).CurrencySymbol %></span>
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
                                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%#Eval("Total")%></td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody>
                                            <tfoot>
                                                <tr>
                                                    <td class="text-right" colspan="4"><strong>Sub-Total:</strong></td>
                                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=SubtotalAmount %></td>
                                                </tr>
                                                <tr>
                                                    <td class="text-right" colspan="4"><strong>Flat Shipping Rate:</strong></td>
                                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=ShipmentCharges %></td>
                                                </tr>
                                                <tr>
                                                    <td class="text-right" colspan="4"><strong>Total:</strong></td>
                                                    <td class="text-right"><%=this.Master.CurrencySymbol %><%=totalAmount %></td>
                                                </tr>
                                            </tfoot>
                                                </table>
                                            </FooterTemplate>
                                        </asp:Repeater>





                                    </div>

                                </div>

                                <div class="row">
                                    <h4>Payment Options</h4>
                                    <ul style="padding: 20px;">
                                        <li>
                                            <asp:RadioButton runat="server" Checked="true" />
                                            COD</li>
                                    </ul>
                                </div>
                                <div class="row">
                                    <div class="pull-left">
                                        <asp:Button runat="server" ID="pnl3Previous" Text="Previous" class="btn" data-loading-text="Loading..." OnClick="pnl3Previous_Click" />
                                    </div>
                                    <div class="pull-right">
                                        <asp:Button runat="server" ID="pnl3Continue" Text="Place Order" class="btn" data-loading-text="Loading..." OnClick="pnl3Continue_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="Pnl4" runat="server" CssClass="panel panel-default">
                        <div class="panel-heading">
                        </div>
                        <div class="panel-collapse collapse in">
                            <div class="panel-body">
                                <div class="col-sm-12 mb-3 mb-sm-0" style="margin-bottom: 20px;">
                                    <div class="cust-address">
                                        <div class="card-body">
                                            <center>
                                                <br />
                                            <h3><strong>Congratulation</strong></h3>
                                            <h5><strong>Your order has been Placed</strong></h5>
                                            <hr />
                                                <br />
                                            Order Number : <asp:Label runat="server" id="lblOrderNo"></asp:Label><br />
                                            Your Account : <a href="../account">Click here</a><br />
                                            Continue Shopping : <a href="../index">Click here</a><br /><br />
                                            <hr />
                                            <h6>You will receive an email with tracking information once your order Approved and shipped.</h6>
                                            </center>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
        <uc1:UCbrandcarouse runat="server" ID="UCbrandcarouse" />
    </div>
    <dialog id="myDialog" class="modal-dialog modal-lg" style="background: border-box; border:none;">
        <div >
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
        </div>
    </dialog>
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
            margin-top: 15px;
        }

        .card-body {
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
    </style>
    <script>
        function ShowMessageForm() {
            document.getElementById("myDialog").showModal();
        }
    </script>
</asp:Content>
