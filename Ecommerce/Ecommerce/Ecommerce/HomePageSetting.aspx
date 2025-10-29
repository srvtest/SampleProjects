<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="HomePageSetting.aspx.cs" Inherits="Ecommerce.HomePageSetting" %>

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
        <asp:HiddenField ID="hdHomeImageSliderId" runat="server" Value="0" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Home Page Setting</h1>
        <p class="mb-4"></p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="lstHomePageSlider">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Home Page Slider</h6>
                <asp:Button ID="btnUpload" runat="server" Text="Add Page Slider" class="btn btn-success btn-use floatRight" OnClick="btnUpload_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Image</th>
                                        <th>Image</th>
                                        <th>Status</th>
                                        <th>Url</th>
                                        <th>IsB2B</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <td>
                                    <%#Eval("ImageURL")%>

                                </td>
                                <td><a href="#" class="btn btn-<%# Convert.ToString(Eval("Status"))=="True" ? "info" : "secondary"  %> btn-icon-split">
                                    <span class="icon text-white-50">
                                        <i class="fas fa-arrow-right"></i>
                                    </span>
                                    <span class="text">
                                        <asp:Label ID="LblStatus" runat="server" ClientIDMode="Static" Text='<%# Convert.ToString(Eval("Status"))=="True" ? "Active":"InActive" %>'></asp:Label></span>
                                </a></td>
                                <td>
                                    <asp:Label ID="lblUrl" runat="server" ClientIDMode="Static" Text='<%#Eval("URL")%>'></asp:Label>
                                </td>
                                <td><a href="#" class="btn btn-<%# Convert.ToString(Eval("IsB2B"))=="True" ? "info" : "secondary"  %> btn-icon-split">
                                    <span class="icon text-white-50">
                                        <i class="fas fa-arrow-right"></i>
                                    </span>
                                    <span class="text">
                                        <asp:Label ID="lblIsB2B" runat="server" ClientIDMode="Static" Text='<%# Convert.ToString(Eval("IsB2B"))=="True" ? "Active":"InActive" %>'></asp:Label></span>
                                </a></td>
                                <td>
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idHomeSlider") %>' />
                                    <asp:HiddenField ID="hdnText1" runat="server" Value='<%#Eval("sText1") %>' />
                                    <asp:HiddenField ID="hdnText2" runat="server" Value='<%#Eval("sText2") %>' />
                                    <asp:HiddenField ID="hdnAlign" runat="server" Value='<%#Eval("sAlign") %>' />
                                    <asp:HiddenField ID="hdnShow" runat="server" Value='<%#Eval("isShowHide") %>' />
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="CatEdit" CssClass="btn btn-success btn-circle btn-sm"><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="CatDelete" CssClass="btn btn-danger btn-circle btn-sm" OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>
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
        </div>

        <div class="card shadow mb-4" runat="server" id="frmHomePageSlider">
            <div class="card-header py-3">
                Add Slider Image
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:TextBox ID="txtHomeSlider" runat="server" class="form-control form-control-user" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtHomeSlider" runat="server" ErrorMessage="Please Enter name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chkStatus" runat="server" CssClass="custom-control-input" ClientIDMode="Static" />
                        <label class="custom-control-label" for="chkStatus">Active</label>

                        <%--  <asp:CustomValidator ID="CustomValidator1" runat="server" CssClass="fontcolour" ErrorMessage="Required" ValidationGroup="save"></asp:CustomValidator>--%>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="chkStatus" runat="server" ErrorMessage="Required" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtUrl" runat="server" class="form-control form-control-user" placeholder="URL"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtUrl" runat="server" ErrorMessage="Please Enter URl." ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group custom-control custom-checkbox">
                    <%-- <asp:TextBox ID="txtIsB2B" runat="server" class="form-control form-control-user" placeholder="IsB2B"></asp:TextBox>--%>
                    <asp:CheckBox ID="chkIsB2B" runat="server" CssClass="custom-control-input" ClientIDMode="Static" />
                    <label class="custom-control-label" for="chkIsB2B">IsB2B</label>
                </div>
                <div class="form-group custom-control custom-checkbox">
                    <%-- <asp:TextBox ID="txtIsB2B" runat="server" class="form-control form-control-user" placeholder="IsB2B"></asp:TextBox>--%>
                    <asp:CheckBox ID="chkShowHide" runat="server" CssClass="custom-control-input" ClientIDMode="Static" />
                    <label class="custom-control-label" for="chkShowHide">Show Text</label>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtText1" runat="server" class="form-control form-control-user" placeholder="Text1"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtUrl" runat="server" ErrorMessage="Please Enter URl." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtText2" runat="server" class="form-control form-control-user" placeholder="Text2"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" ControlToValidate="txtUrl" runat="server" ErrorMessage="Please Enter URl." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtAlign" runat="server" class="form-control form-control-user" placeholder="Align"></asp:TextBox>
                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" ControlToValidate="txtUrl" runat="server" ErrorMessage="Please Enter URl." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                </div>
                <div class="form-group">
                    <asp:FileUpload ID="imgUpload" runat="server" class="form-control form-control-user" placeholder="Image" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="imgUpload" runat="server" ErrorMessage="Please Upload Image." ValidationGroup="save"></asp:RequiredFieldValidator>
                </div>
                <asp:Button ID="btnsave" runat="server" Text="Save" class="btn btn-success btn-use floatRight" Style="margin-left: 10px;" OnClick="btnsave_Click" ValidationGroup="save" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
    <!-- Page level plugins -->
    <%-- <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>--%>
    <script src="vendor/jquery/jquery.min.js"></script>
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
    <%-- <script type = "text/javascript">
        function ValidateCheckBox(sender, args) {
            if (document.getElementById("<%=chkStatus.ClientID %>").checked == false) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }
    </script>--%>
</asp:Content>
