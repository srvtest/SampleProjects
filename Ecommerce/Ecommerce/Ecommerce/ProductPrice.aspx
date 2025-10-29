<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="ProductPrice.aspx.cs" Inherits="Ecommerce.ProductPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <%--   <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <%--  <link href="https://cdn.datatables.net/1.10.22/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css">--%>
    <%--   <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css">

    <style>
        .floatRight {
            float: right;
        }

        .textboxwidth {
            width: 200px;
        }

        .label {
            display: inline;
        }

        .textbox {
            display: inline;
        }

        .search {
            /*background: url(find.png) no-repeat;*/
            padding-right: 18px;
            border: 1px solid #ccc;
        }

        .txtDis {
            padding-right: 18px;
            width: 90%;
            display: inline-block;
        }

        .fontcolour {
            color: red;
        }

        .borderbottom {
            border-bottom: 2px solid black;
        }

        .highlight {
            font-weight: bold;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--  <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdIdProductPrice" runat="server" Value="0" />
        <asp:HiddenField ID="hdIdProduct" runat="server" Value="0" />
        <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Product Price</h1>
        <p class="mb-4">Product Price description</p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblProductPrice">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Product</h6>
                <%--<asp:Button ID="btnProductPrice" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnProductPrice_Click" />--%>
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <%--      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>

                    <asp:Repeater ID="lstProductPrice" runat="server" OnItemDataBound="lstProductPrice_ItemDataBound">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered display" id="dataTa" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th style="width: 450px;">Name</th>
                                        <th>Product Price Details</th>
                                        <%-- <th>Status</th>
                                        <th>Action</th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <input type="checkbox" id="chkbox" class="chkvalue" runat="server" value='<%#Eval("IdProduct")%>' onclick="CheckRequest(this)" />
                                    <%--<asp:CheckBox ID="chk" runat="server" ClientIDMode="Static" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />--%>
                                </td>
                                <td>
                                    <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <td>
                                    <div id="price<%#Eval("idProduct") %>" style="display: none;">
                                        <asp:Repeater ID="lstPrice" runat="server" OnItemDataBound="lstPrice_ItemDataBound">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <div class="form-group row">
                                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                                        <asp:Label ID="lblCounty" CssClass="highlight" runat="server" Text="Country :"></asp:Label>
                                                        <asp:Label ID="lblCountry" runat="server" ClientIDMode="Static" Text='<%#Eval("Country")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdCountry" runat="server" ClientIDMode="Static" Value='<%#Eval("idCountry") %>' />
                                                    </div>
                                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                                        <asp:Label ID="lblCurr" CssClass="highlight" runat="server" Text="Currency :"></asp:Label>
                                                        <asp:Label ID="lblCurrency" runat="server" ClientIDMode="Static" Text='<%#Eval("sNameCurrency")%>'></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-top: 10px">
                                                        <asp:Label ID="lblB2B" CssClass="highlight" runat="server" Text="B2B :"></asp:Label>
                                                        <asp:TextBox ID="txtB2B" runat="server" class="form-control form-control-user" Text='<%#Eval("PriceB2B")%>' ClientIDMode="Static" placeholder="B2B"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtB2B" runat="server" ErrorMessage="Please Enter B2B." ValidationGroup="save" onkeypress="return numeric(event)"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-top: 10px">
                                                        <asp:Label ID="lblB2C" CssClass="highlight" runat="server" Text="B2C :"></asp:Label>
                                                        <asp:TextBox ID="txtB2C" runat="server" class="form-control form-control-user" Text='<%#Eval("priceB2C")%>' ClientIDMode="Static" placeholder="B2C"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtB2C" runat="server" ErrorMessage="Please Enter B2C." ValidationGroup="save" onkeypress="return numeric(event)"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group row">
                                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-top: 10px">
                                                        <asp:Label ID="lblDis" CssClass="highlight" runat="server" Text="Discount :"></asp:Label><br />
                                                        <asp:TextBox ID="txtDiscount" runat="server" class=" form-control form-control-user txtDis" Text='<%#Eval("Discount")%>' ClientIDMode="Static" placeholder="Discount" onkeypress="return numeric(event)"></asp:TextBox><span style="float: right;">%</span>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" ControlToValidate="txtDiscount" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+$" ValidationGroup="save"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-sm-6 mb-3 mb-sm-0" style="margin-top: 10px">
                                                        <asp:Label ID="lblShip" CssClass="highlight" runat="server" Text="Shipment Charges :"></asp:Label>
                                                        <asp:TextBox ID="txtShipmentCharges" runat="server" class="form-control form-control-user" placeholder="ShipmentCharges" Text='<%#Eval("ShipmentCharges")%>' ClientIDMode="Static" onkeypress="return numeric(event)"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="fontcolour" ControlToValidate="txtShipmentCharges" runat="server" ErrorMessage="Please Enter ShipmentCharges." ValidationGroup="save"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="form-group row borderbottom">
                                                    <div class="custom-control custom-checkbox small" style="margin-left: 20px;">
                                                        <asp:CheckBox ID="chkCountryStatus" runat="server" CssClass="custom-control-input" ClientIDMode="Static" Checked="True" />
                                                        <label class="custom-control-label" for="chkCountryStatus">Status</label>
                                                    </div>
                                                </div>
                                                <asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("IdProduct") %>' />
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                                <asp:HiddenField ID="hdnName" runat="server" Value='<%#Eval("IdProduct") %>' />
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("IdProduct") %>' />
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

                    <%-- <div class="pagination-nav text-center mt_50">
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
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <!-- Page level plugins -->
    <%--   <script src="vendor/datatables/jquery.dataTables.min.js"></script>--%>
    <%-- <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>--%>
    <%--    <script src="vendor/jquery/jquery.min.js"></script>--%>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">

        function CheckRequest(chk) {
            var a = $('#hdnId').val();
            var id = $(chk).val();
            // alert(id);

            var valichk = $(chk).is(":checked");
            if (valichk) {
                $('#price' + id).show();
            }
            else {
                $('#price' + id).hide();
            }
        }

        function numeric(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && ((charCode >= 48 && charCode <= 57) || charCode == 46))
                return true;
            else {
                alert('Please Enter Numeric values.');
                return false;
            }
        }
        $(document).ready(function () {
            $('#dataTa').DataTable({
                "pagingType": "full_numbers"
            });
            // $('#dataTa').DataTable();
        });
    </script>


</asp:Content>
