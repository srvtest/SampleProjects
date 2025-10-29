<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="AdditionalLink.aspx.cs" Inherits="Ecommerce.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css">
    <style>
        .floatRight {
            float: right;
        }

        .ckeditorwidth {
            width: 1270px;
        }
         .fontcolour{
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdAdditionalLinkId" runat="server" Value="0" />
        <asp:HiddenField ID="hdDescription" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnStatus" runat="server" ClientIDMode="Static" Value="True" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Additional Link</h1>
        <p class="mb-4">Additional Link Description</p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblAdditionalLink">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Additional Link Details</h6>
                <asp:Button ID="btnAdditionalLink" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnAdditionalLink_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstAdditionalLink" runat="server" OnItemCommand="lstAdditionalLink_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Link</th>
                                        <th>Description</th>
                                        <th>Status</th>
                                        <th>MetaTags</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" runat="server" ClientIDMode="Static" Text='<%#Eval("Name")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblLink" runat="server" ClientIDMode="Static" Text='<%#Eval("Link")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" ClientIDMode="Static" Text='<%# Limit(Eval("sDescription"),30) %>' ToolTip='<%# Eval("sDescription") %>'></asp:Label>
                                    <asp:LinkButton ID="ReadMoreLinkButton" runat="server" CommandName="Readmore" Text="Read More" Visible='<%# SetVisibility(Eval("sDescription"), 30) %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <a href="#" class="btn btn-<%# Convert.ToString(Eval("Status"))=="True" ? "info" : "secondary"  %> btn-icon-split">
                                        <span class="icon text-white-50">
                                            <i class="fas fa-arrow-right"></i>
                                        </span>
                                        <span class="text">
                                            <asp:Label ID="LblStatus" runat="server" ClientIDMode="Static" Text='<%# Convert.ToString(Eval("Status"))=="True" ? "Active":"InActive" %>'></asp:Label></span>
                                    </a>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idAdditionalLink") %>' />
                                    <asp:HiddenField ID="hdStatus" runat="server" Value='<%# Convert.ToString(Eval("Status"))=="True" ? "Active":"InActive" %>' />
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="CatEdit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idAdditionalLink") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="CatDelete" CssClass="btn btn-danger btn-circle btn-sm" CommandArgument='<%#Eval("idAdditionalLink") %>' OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>
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

        <div class="card shadow mb-4" runat="server" id="frmAdditionalLink">
            <div class="card-header py-3">
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Name</label>
                        <br />
                        <asp:TextBox ID="txtName" runat="server" class="form-control form-control-user" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"  CssClass="fontcolour" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Link</label>
                        <br />
                        <asp:TextBox ID="txtLink" runat="server" class="form-control form-control-user" placeholder="Link"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  CssClass="fontcolour" ControlToValidate="txtLink" runat="server" ErrorMessage="Please Enter Link." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Description</label>
                        <br />
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" class="form-control form-control-user ckeditor" placeholder="Description"></asp:TextBox>
                        <%--  <script type="text/javascript" lang="javascript">
                            CKEDITOR.replace('<%=txtDescription%>');
                        </script>--%>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2"  CssClass="fontcolour" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chkStatus" runat="server" class="custom-control-input" ClientIDMode="Static" />
                        <label class="custom-control-label" for="chkStatus"></label>
                        <asp:Label ID="lblbStatus" runat="server" ClientIDMode="Static"></asp:Label>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6"  CssClass="fontcolour" ControlToValidate="chkStatus" runat="server" ErrorMessage="Please Select Status." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <asp:Button ID="btnSaveAdditionalLink" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSaveAdditionalLink_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnCancelAdditionalLink" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancelAdditionalLink_Click" />
            </div>
        </div>
    </div>


    <!-- Page level plugins -->
   <%-- <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>--%>
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="ckeditor/config.js"></script>
    <script type="text/javascript" src="scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="ckeditor/adapters/jquery.js"></script>
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>
    <%-- <script type="text/javascript" lang="javascript">
          ckeditor.replace('<%=txtdescription%>');
          editor.resize('100%', '350', true)
                        </script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#dataTable').DataTable({
                "pagingType": "full_numbers"
            });
            // $('#dataTa').DataTable();
        });
      
            <%-- $(function () {
            
            CKEDITOR.replace('<%=txtDescription.ClientID %>');
            CKEDITOR.config.width = 1270;
    });--%>
    </script>
</asp:Content>
