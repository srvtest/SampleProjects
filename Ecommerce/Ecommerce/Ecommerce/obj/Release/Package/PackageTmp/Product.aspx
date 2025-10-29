<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Ecommerce.Product" %>

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
        <asp:HiddenField ID="hdProductId" runat="server" Value="0" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Product</h1>
        <%--<p class="mb-4">DataTables is a third party plugin that is used to generate the demo table below. For more information about DataTables, please visit the <a target="_blank" href="https://datatables.net">official DataTables documentation</a>.</p>--%>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblProduct">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Product Details</h6>
                <asp:Button ID="btnAdd" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnAdd_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstProduct" runat="server" OnItemCommand="lstProduct_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>SEO Name</th>
                                        <th>Category</th>
                                        <th>Feature</th>
                                        <th>ImageURL</th>
                                        <th>IsFeatureProduct</th>
                                        <th>Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("sName")%></td>
                                <td><%#Eval("SEOName")%></td>
                                <td><%#Eval("CategoryName")%></td>
                                <td><%#Eval("Features")%></td>
                                <td>
                                    <img width="50" src='<%# "ProductImage/" + (string.IsNullOrEmpty(Convert.ToString(Eval("ImageURL"))) ? "NoImage.png" : Convert.ToString(Eval("ImageURL"))) %>' /></td>
                                <%--<td><%# Convert.ToBoolean(Eval("IsFeatureProduct")) ? "Active" : "Inactive" %></td>--%>
                                <td>
                                    <a href="#" class="btn btn-<%# Convert.ToBoolean(Eval("IsFeatureProduct")) ? "info" : "secondary"  %> btn-icon-split">
                                        <span class="icon text-white-50">
                                            <i class="fas fa-arrow-right"></i>
                                        </span>
                                        <span class="text">
                                            <asp:Label ID="isFeatureProduct" runat="server" ClientIDMode="Static" Text='<%# Convert.ToBoolean(Eval("IsFeatureProduct")) ? "Active":"InActive" %>'></asp:Label></span>
                                    </a>
                                </td>
                                <%--<td><%# Convert.ToBoolean(Eval("bStatus")) ? "Active" : "Inactive" %></td>--%>
                                <td>
                                    <a class="btn btn-<%# Convert.ToBoolean(Eval("bStatus")) ? "info" : "secondary"  %> btn-icon-split" style="color: white;">
                                        <span class="icon text-white-50">
                                            <i class="fas fa-arrow-right"></i>
                                        </span>
                                        <span class="text">
                                            <asp:Label ID="status" runat="server" ClientIDMode="Static" Text='<%# Convert.ToBoolean(Eval("bStatus")) ? "Active":"InActive" %>'></asp:Label></span>
                                    </a>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="edit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idProduct") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CssClass="btn btn-danger btn-circle btn-sm" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'
                                        CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idProduct") %>'><i class="fas fa-trash"></i></asp:LinkButton>

                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                    <%--<tfoot>
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

        <div class="card shadow mb-4" runat="server" id="frmProduct">
            <div class="card-header py-3">
                Add Product
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Product Name</label>
                        <asp:TextBox ID="txtProductName" runat="server" class="form-control form-control-user" placeholder="Product Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtProductName" runat="server" ErrorMessage="Please Enter Product Name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6">
                        <label>SEO Name</label>
                        <asp:TextBox ID="txtSEOName" runat="server" class="form-control form-control-user" placeholder="SEO Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtSEOName" runat="server" ErrorMessage="Please Enter SEO Name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>MasterCategory</label>
                        <asp:DropDownList ID="ddlMasterCategory" class="form-control form-control-user" runat="server" EnableViewState="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="ddlMasterCategory" runat="server" ErrorMessage="Please Select Master Category" ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Category</label>
                        <asp:DropDownList ID="ddlCategory" class="form-control form-control-user" runat="server" EnableViewState="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="ddlCategory" runat="server" ErrorMessage="Please Select Category" ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>

                </div>
                <div class="form-group row">

                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Collection</label>
                        <asp:DropDownList ID="ddlCollection" class="form-control form-control-user" runat="server" EnableViewState="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="fontcolour" ControlToValidate="ddlCollection" runat="server" ErrorMessage="Please Select Collection" ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Material</label>
                        <asp:DropDownList ID="ddlMaterial" class="form-control form-control-user" runat="server" EnableViewState="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="fontcolour" ControlToValidate="ddlMaterial" runat="server" ErrorMessage="Please Select Material" ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">

                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Gemstone</label>
                        <asp:DropDownList ID="ddlGemstone" class="form-control form-control-user" runat="server" EnableViewState="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" ControlToValidate="ddlGemstone" runat="server" ErrorMessage="Please Select Gemstone" ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Gender</label>
                        <asp:DropDownList ID="ddlGender" class="form-control form-control-user" runat="server" EnableViewState="true"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="fontcolour" ControlToValidate="ddlGender" runat="server" ErrorMessage="Please Select Gender" ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Feature</label>
                        <asp:TextBox ID="txtFeature" runat="server" class="form-control form-control-user" placeholder="Feature" Rows="7" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" ControlToValidate="txtFeature" runat="server" ErrorMessage="Please Enter Feature." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6">
                        <asp:Image runat="server" ID="imgDefault" Width="50px" />
                        <asp:FileUpload ID="imageUpload" runat="server" />
                        <br />
                        <asp:Button runat="server" ID="btnUploadImage" Style="padding: 5px 7px; margin-top: 10px; margin-left: 50px;" CssClass="btn btn-md btn-primary marginTop"
                            Text="Upload Image" OnClick="btnUploadImage_Click" CausesValidation="false" />
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="imageUpload" runat="server" ErrorMessage="Please Upload Image." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <div class="form-group row">
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <div class="custom-control custom-checkbox">
                            <asp:CheckBox ID="chkStatus" runat="server" class="custom-control-input" ClientIDMode="Static" Checked="true" />
                            <label class="custom-control-label" for="chkStatus">Status</label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="chkStatus" runat="server" ErrorMessage="Please Select Status." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="custom-control custom-checkbox">
                            <asp:CheckBox ID="chkIsFeatureProduct" runat="server" class="custom-control-input" ClientIDMode="Static" />
                            <label class="custom-control-label" for="chkIsFeatureProduct">Feature Product</label>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="chkIsFeatureProduct" runat="server" ErrorMessage="Please Select FeatureProduct." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                        </div>
                    </div>
                </div>
                <div class="form-group row">
                    <h4>Product Image</h4>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:FileUpload ID="productImageUpload" runat="server" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Button runat="server" ID="btnUpload" Style="padding: 5px 7px; margin-top: 0px; margin-left: 0px;" CssClass="btn btn-md btn-primary marginTop"
                            Text="Upload image" OnClick="btnUpload_Click" CausesValidation="false" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Repeater runat="server" ID="rptimage" OnItemCommand="rptimage_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>Image</th>
                                            <th>Status</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img width="50" src='<%# "ProductImage/" + (string.IsNullOrEmpty(Convert.ToString(Eval("ImageURL"))) ? "NoImage.png" : Convert.ToString(Eval("ImageURL"))) %>' /></td>
                                    <td>
                                        <a class="btn btn-<%# Convert.ToBoolean(Eval("bStatus")) ? "info" : "secondary"  %> btn-icon-split" style="color: white;">
                                            <span class="icon text-white-50">
                                                <i class="fas fa-arrow-right"></i>
                                            </span>
                                            <span class="text">
                                                <asp:Label ID="status" runat="server" ClientIDMode="Static" Text='<%# Convert.ToBoolean(Eval("bStatus")) ? "Active":"InActive" %>'></asp:Label></span>
                                        </a>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnIdProductImage" Value='<%# Bind("idProductImage") %>' runat="server" />
                                        <asp:HiddenField ID="hdnGuid" Value='<%# Bind("guid") %>' runat="server" />
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idProduct") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-circle btn-sm" OnClientClick='javascript:return confirm("Are you sure you want to delete?")' CommandArgument='<%# DataBinder.Eval(Container.DataItem, "idProduct") %>'><i class="fas fa-trash"></i></asp:LinkButton>
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
                <div class="form-group row">
                    <h4>Product Video</h4>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Video Name :</label>
                        <%--<asp:FileUpload ID="productVideoUpload" runat="server" />--%>
                        <asp:TextBox ID="txtVideoName" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtVideoUrl" runat="server" ErrorMessage="Please Enter Video Url." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Video Url :</label>
                        <asp:TextBox ID="txtVideoUrl" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" ControlToValidate="txtVideoName" runat="server" ErrorMessage="Please Enter Video Name." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Button runat="server" ID="btnAddVideo" Style="padding: 5px 7px; margin-top: 10px; margin-left: 0px;" CssClass="btn btn-md btn-primary marginTop"
                            Text="Add Video" OnClick="btnAddVideo_Click" CausesValidation="false" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <asp:Repeater ID="rptVideo" runat="server" OnItemCommand="rptVideo_ItemCommand">
                            <HeaderTemplate>
                                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th>Image</th>
                                            <th>Video Name</th>
                                            <th>Video Url</th>
                                            <th>Status</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <img width="50" src="http://img.youtube.com/vi/<%#Eval("VideoName")%>/hqdefault.jpg" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblVideoName" runat="server" ClientIDMode="Static" Text='<%#Eval("VideoName")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblVideoUrl" runat="server" ClientIDMode="Static" Text='<%#Eval("Videourl")%>'></asp:Label>
                                    </td>
                                    <%--  <td>
                                        <img width="50" src='<%# "ProductVideo/" + (string.IsNullOrEmpty(Convert.ToString(Eval("Videourl"))) ? "NoImage.png" : Convert.ToString(Eval("Videourl"))) %>' />
                                    </td>--%>
                                    <td>
                                        <a class="btn btn-<%# Convert.ToBoolean(Eval("bStatus")) ? "info" : "secondary"  %> btn-icon-split" style="color: white;">
                                            <span class="icon text-white-50">
                                                <i class="fas fa-arrow-right"></i>
                                            </span>
                                            <span class="text">
                                                <asp:Label ID="status" runat="server" ClientIDMode="Static" Text='<%# Convert.ToBoolean(Eval("bStatus")) ? "Active":"InActive" %>'></asp:Label></span>
                                        </a>
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="hdnidProductVideo" Value='<%# Bind("idProductVideo") %>' runat="server" />
                                        <asp:HiddenField ID="hdnGuid" Value='<%# Bind("guid") %>' runat="server" />
                                        <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-success btn-circle btn-sm"><i class="fas fa-edit"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-circle btn-sm" OnClientClick='javascript:return confirm("Are you sure you want to delete?")'><i class="fas fa-trash"></i></asp:LinkButton>
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
                <div style="height: 40px;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancel_Click" />
                </div>

            </div>
        </div>
    </div>


    <%-- <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="js/sb-admin-2.min.js"></script>
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>    
    <script src="js/demo/datatables-demo.js"></script>
    --%>
    <!-- Page level plugins -->
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>

    <script type="text/javascript">

        //$(document).ready(function () {
        //    $('#dataTable').DataTable({
        //        "pagingType": "full_numbers"
        //    });
        //    // $('#dataTa').DataTable();
        //});
        //function showpreview(input) {

        //    if (input.files && input.files[0]) {

        //        var reader = new FileReader();
        //        reader.onload = function (e) {
        //            $('#imgpreview').css('visibility', 'visible');
        //            $('#imgpreview').attr('src', e.target.result);
        //        }
        //        reader.readAsDataURL(input.files[0]);
        //    }

        //}
        $(document).ready(function () {
            $('#dataTable').DataTable({
                "pagingType": "full_numbers",
                columnDefs: [{
                    orderable: false,
                    className: 'select-checkbox',
                    targets: 0
                }],
                select: {
                    style: 'os',
                    selector: 'td:first-child'
                },
                order: [[1, 'asc']]

            });
        });
        function readURL() {
            var $input = $(this);
            var $newinput = $(this).parent().find('#imgpreview');
            if (this.files && this.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    reset($newinput.next('.delbtn'), true);
                    $newinput.attr('src', e.target.result).show();
                    $newinput.after('<input type="button" class="delbtn removebtn" value="remove">');
                }
                reader.readAsDataURL(this.files[0]);
            }
        }
        //debugger;
        $("#imgUpload").change(readURL);
        $("form").on('click', '.delbtn', function (e) {
            reset($(this));
        });
        $(".delbtn").remove();
        function reset(elm, prserveFileName) {
            if (elm && elm.length > 0) {
                var $input = elm;
                $input.prev('#imgpreview').attr('src', '').hide();
                if (!prserveFileName) {
                    $($input).parent().parent().parent().find('input#imgUpload ').val("");
                    //input.fileUpload and input#uploadre both need to empty values for particular div
                }
                elm.remove();
            }
        }

    </script>
</asp:Content>
