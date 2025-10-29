<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="CountryConfig.aspx.cs" Inherits="Ecommerce.CountryConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <%-- <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css">
    <style>
        .floatRight {
            float: right;
        }

        .fontcolour {
            color: red;
        }

        .highlight {
            font-weight: bold;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdIdCountryConfig" runat="server" Value="0" />
        <asp:HiddenField ID="hdIdConfig" runat="server" Value="0" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Country Config</h1>
        <p class="mb-4">Country Config description</p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblConfig">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Config</h6>
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstConfig" runat="server" OnItemDataBound="lstConfig_ItemDataBound">
                        <HeaderTemplate>
                            <table class="table table-bordered display" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Name</th>
                                        <th>Country Config Details</th>
                                        <%-- <th>Status</th>
                                        <th>Action</th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%--<asp:CheckBox ID="chk" runat="server" ClientIDMode="Static" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />--%>
                                    <input type="checkbox" id="chkbox" class="chkvalue" runat="server" value='<%#Eval("idConfig")%>' onclick="CheckRequest(this)" />
                                </td>
                                <td>
                                    <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <td>
                                    <div id="Country<%#Eval("idConfig") %>" style="display: none;">
                                        <asp:Repeater ID="lstCountryConfig" runat="server" OnItemDataBound="lstCountryConfig_ItemDataBound">
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>

                                                <%--   <asp:Repeater ID="lstCountryConfigList" runat="server" OnItemDataBound="lstCountryConfigList_ItemDataBound">
                                                <HeaderTemplate>
                                                </HeaderTemplate>
                                                <ItemTemplate>--%>

                                                <div class="form-group row">
                                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                                        <asp:Label ID="lblCounty" CssClass="highlight" runat="server" Text="Country :"></asp:Label>
                                                        <asp:Label ID="lblCountry" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                                        <asp:HiddenField ID="hdCountry" runat="server" ClientIDMode="Static" Value='<%#Eval("idCountry") %>' />
                                                        <%--<asp:DropDownList ID="ddCountry" runat="server" class="form-control form-control-user" ClientIDMode="Static"></asp:DropDownList>--%>
                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="ddCountry" runat="server" ErrorMessage="Please Select country." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                                                    </div>

                                                    <div class="col-sm-6 mb-3 mb-sm-0">
                                                        <asp:Label ID="lblVal" CssClass="highlight" runat="server" Text="Value"></asp:Label>
                                                        <asp:TextBox ID="txtValue" runat="server" class="form-control form-control-user" Text='<%#Eval("sValue")%>' ClientIDMode="Static" placeholder="B2B"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtValue" runat="server" ErrorMessage="Please Enter Value." ValidationGroup="save" onkeypress="return numeric(event)"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <%--  </ItemTemplate>
                                                <FooterTemplate>
                                                </FooterTemplate>
                                            </asp:Repeater>--%>
                                                <%--<asp:HiddenField ID="hdId" runat="server" Value='<%#Eval("idConfig") %>' />--%>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>

                                <td>
                                    <asp:HiddenField ID="hdnName" runat="server" Value='<%#Eval("idConfig") %>' />
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idConfig") %>' />
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
        <%-- <div class="card shadow mb-4" runat="server" id="tblCountryConfig">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Product Price</h6>
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
                <asp:Button ID="btnAddCountryConfig" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" Style="margin-left: 10px;" OnClick="btnAddCountryConfig_Click" />
                <asp:Button ID="btnCancelCountryConfig" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancelCountryConfig_Click" />
                <asp:Button ID="btnLogin" runat="server" Text="Save" class="btn btn-danger btn-use floatRight" OnClick="btnSave_Click1" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstCountryConfig" runat="server" OnItemCommand="lstCountryConfig_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Country</th>
                                        <th>Value</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk" runat="server" ClientIDMode="Static" Text='<%#Eval("idConfig") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblCountry" runat="server" ClientIDMode="Static" Text='<%#Eval("Country")%>'></asp:Label>
                                    <asp:HiddenField ID="hdCountry" runat="server" ClientIDMode="Static" Value='<%#Eval("idCountry") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblValue" runat="server" ClientIDMode="Static" Text='<%#Eval("Value")%>'></asp:Label>
                                    <asp:TextBox ID="txtValue" runat="server"></asp:TextBox>
                                </td>
                                
                                <td>
                                    <asp:HiddenField ID="hdnIdCountryConfig" runat="server" Value='<%#Eval("idCountryConfig") %>' />
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="CatEdit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idCountryConfig") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="CatDelete" CssClass="btn btn-danger btn-circle btn-sm" CommandArgument='<%#Eval("idCountryConfig") %>' OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>
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
        </div>--%>
        <%--<div class="card shadow mb-4" runat="server" id="frmCountryConfig">
            <div class="card-header py-3">
                 Add Product Price
                <asp:Label ID="lblMess" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:DropDownList ID="ddConfigList" runat="server" class="form-control form-control-user" OnSelectedIndexChanged="ddConfigList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="ddConfigList" runat="server" ErrorMessage="Please Select Config." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="lblConfigName" runat="server"></asp:Label>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        Country
                        <asp:DropDownList ID="ddCountry" runat="server" class="form-control form-control-user"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="ddCountry" runat="server" ErrorMessage="Please Select country." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        Value
                        <asp:TextBox ID="txtValue" runat="server" class="form-control form-control-user" placeholder="Value"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtValue" runat="server" ErrorMessage="Please Enter Value." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnFrmCancel" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnFrmCancel_Click" />
            </div>
        </div>--%>
    </div>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>


    <script type="text/javascript">

        function CheckRequest(chk) {
            debugger;
            var a = $('#hdnId').val();
            var id = $(chk).val();
            // alert(id);

            var valichk = $(chk).is(":checked");
            if (valichk) {
                $('#Country' + id).show();
            }
            else {
                $('#Country' + id).hide();
            }
        }
       


        $(document).ready(function () {
            $('#dataTable').DataTable({
                "pagingType": "full_numbers"
            });
            // $('#dataTa').DataTable();
        });
   

    </script>
</asp:Content>
