<%@ Page Title="" MaintainScrollPositionOnPostback="true" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="Blogs.aspx.cs" Inherits="Ecommerce.Blogs" ValidateRequest="false" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css">
    <style>
        .floatRight {
            float: right;
        }
        .fontcolour{
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdBlogId" runat="server" Value="0" />
        <asp:HiddenField ID="hdDescription" runat="server" ClientIDMode="Static"  />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Blog</h1>
        <p class="mb-4">Blog description</p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblBlog">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Blog Details</h6>
                <asp:Button ID="btnBlog" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnBlog_Click1" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstBlog" runat="server" OnItemCommand="lstBlog_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Description</th>
                                        <th>Photo</th>
                                        <th>CreatedDate</th>
                                        <th>URL</th>
                                        <th>MetaTags</th>
                                        <th>Action</th>
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
                                    <asp:Label ID="lblDescription" runat="server" ClientIDMode="Static" Text='<%# Limit(Eval("sDescription"),30) %>' ToolTip='<%# Eval("sDescription") %>'></asp:Label>
                                    <asp:LinkButton ID="ReadMoreLinkButton" runat="server" CommandName="Readmore" Text="Read More" Visible='<%# SetVisibility(Eval("sDescription"), 30) %>'></asp:LinkButton>
                                </td>
                                <td>
                                     <%--<img width="50" src='<%# "~/Images/Blog/"+Eval("sPhoto") %>'  />--%>
                                    <%--<img width="50" ID="imgPhoto" runat="server" src='<%# "Images/Blog/" + (string.IsNullOrEmpty(Convert.ToString(Eval("sPhoto"))) ? "NoImage.png" : Convert.ToString(Eval("sPhoto"))) %>' />--%>

                             
                                    <asp:Image ID="imgPhoto" Height="50" Width="50" runat="server" ImageUrl='<%# "Images/Blog/"+Eval("sPhoto") %>' AlternateText="Image"  />
                                </td>
                                <td>
                                    <asp:Label ID="lblCreatedDate" runat="server" ClientIDMode="Static" Text='<%# Eval("CreatedDate","{00:dd MMM yyyy}") %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblURL" runat="server" ClientIDMode="Static" Text='<%#Eval("URL")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblMetaTags" runat="server" ClientIDMode="Static" Text='<%#Eval("MetaTags")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("Id") %>' />
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="CatEdit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("Id") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="CatDelete" CssClass="btn btn-danger btn-circle btn-sm" CommandArgument='<%#Eval("Id") %>' OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>
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

        <div class="card shadow mb-4" runat="server" id="frmBlog">
            <div class="card-header py-3">                
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Name</label>
                        <br />
                        <asp:TextBox ID="txtName" runat="server" class="form-control form-control-user" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="save" ></asp:RequiredFieldValidator>
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
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="txtDescription" runat="server" ErrorMessage="Please Enter Description." ValidationGroup="save" ></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Image</label>
                        <br />
                         <asp:Image runat="server" ID="imgDefault" Width="50px" />
                        <asp:FileUpload ID="imageUpload" runat="server" />
                        <br />  
                        <%--<asp:FileUpload ID="imgUpload" runat="server" ClientIDMode="Static" />
                        <asp:Image ID="imgpreview" ClientIDMode="Static" Width="100" ImageUrl='<%# "images/blog/" + System.Convert.ToString(Eval("ImageURL")) %>' runat="server" />--%>
                        <%--<input type="button" class="delbtn removebtn" value="remove" />--%>
                         <asp:Button runat="server" ID="btnUploadImage" Style="padding: 5px 7px; margin-top: 10px; margin-left: 50px;" CssClass="btn btn-md btn-primary marginTop"
                            Text="Upload Image" OnClick="btnUploadImage_Click" CausesValidation="false" />
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" ControlToValidate="imgUpload" runat="server" ErrorMessage="Please Select Image." ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                    </div>
                </div>
                <div class="form-group row">
                    <%--<div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Created Date</label>
                        <asp:TextBox ID="txtCreatedDate" runat="server" class="form-control form-control-user" placeholder="Blog"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtCreatedDate" runat="server" ErrorMessage="Please Enter name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>--%>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>URL</label>
                        <br />
                        <asp:TextBox ID="txtURL" runat="server" class="form-control form-control-user" placeholder="URL"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtURL" runat="server" ErrorMessage="Please Enter URL." ValidationGroup="save" ></asp:RequiredFieldValidator>
                    </div>

                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>MetaTags</label>
                        <br />
                        <asp:TextBox ID="txtMetaTags" runat="server" class="form-control form-control-user" placeholder="MetaTags" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" ControlToValidate="txtMetaTags" runat="server" ErrorMessage="Please Enter MetaTags." ValidationGroup="save" ></asp:RequiredFieldValidator>
                    </div>
                </div>
                <asp:Button ID="btnLogin" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>    

    <!-- Page level plugins -->
 <%--   <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>--%>
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="vendor/jquery/jquery.min.js"></script>
        <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#dataTable').DataTable({
                "pagingType": "full_numbers"
            });
            // $('#dataTa').DataTable();
        });
        function readURL() {
            debugger;
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
