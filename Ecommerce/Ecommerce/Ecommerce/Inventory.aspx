<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Ecommerce.Inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css">
    <style>
        .floatRight {
            float: right;
        }

        .fontcolour {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdInventoryId" runat="server" Value="0" />
        <asp:HiddenField ID="hdProductId" runat="server" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Inventory</h1>
        <%--<p class="mb-4">DataTables is a third party plugin that is used to generate the demo table below. For more information about DataTables, please visit the <a target="_blank" href="https://datatables.net">official DataTables documentation</a>.</p>--%>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblInventory">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Inventory Details</h6>
                <%--<asp:Button ID="btnInventory" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnAdditionalLink_Click" />--%>
                <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-danger btn-use floatRight" OnClick="btnUpdate_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstInventory" runat="server" OnItemCommand="lstInventory_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered table-striped display" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th></th>
                                        <th>Name</th>
                                        <th>Category</th>
                                        <th>Quantity</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="chk" runat="server" ClientIDMode="Static" OnCheckedChanged="chk_CheckedChanged" AutoPostBack="true" />
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCategory" runat="server" ClientIDMode="Static" Text='<%#Eval("CategoryName")%>'></asp:Label>
                                </td>
                                <td>
                                    <%--<asp:HiddenField ID="hdnIdInventory" runat="server" Value='<%#Eval("idInventory") %>' />--%>
                                    <asp:HiddenField ID="hdnIdProduct" runat="server" Value='<%#Eval("idProduct") %>' />
                                    <%--<asp:TextBox ID="txtQuantity" runat="server" Text='<%#Eval("Quantity")%>'></asp:TextBox>--%>
                                    <asp:TextBox ID="txtQuantity" runat="server" ClientIDMode="Static"></asp:TextBox>
                                    <asp:HiddenField ID="hdnIdInventory" runat="server" Value='<%#Eval("idInventory") %>' />
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
    </div>
    <!-- Page level plugins -->
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dataTable').DataTable({
                "pagingType": "full_numbers"
            });
            // $('#dataTa').DataTable();
        });
    </script>
</asp:Content>
