<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="ClientMaster.aspx.cs" Inherits="Ecommerce.ClientMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <%--<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" type="text/css">--%>
    <link href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap.min.css" rel="stylesheet" type="text/css">
    <style>
        .floatRight {
            float: right;
        }
        .table-responsive{
            overflow:hidden;
        }
        .ddl-cls{
            margin-top: 10px;
            margin-left: 45%;
        }
          .fontcolour{
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnClientMasterId" runat="server" Value="0" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Client Master</h1>
        <%--<p class="mb-4">Additional Link Description</p>--%>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblClientMaster">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Client Master Details</h6>
                <asp:Button ID="btnClientMaster" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnClientMaster_Click" />
            </div>
            <div class="ddl-cls">
                <asp:DropDownList ID="ddlCountry" CssClass="form-control form-control-user" Width="200px" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="rptClientMaster" runat="server" OnItemCommand="rptClientMaster_ItemCommand">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-sm-10 mb-3 mb-sm-0">
                                    <div class="card-body">
                                        <table class="table table-bordered">
                                            <tr>
                                                <td>
                                                    <strong>Name:</strong></td>
                                                <td>
                                                    <asp:Label ID="lblName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label></td>
                                                <td><strong>Logo:</strong></td>
                                                <td>
                                                    <%--<asp:Label ID="lblLogo" runat="server" ClientIDMode="Static" Text='<%#Eval("slogo")%>'></asp:Label>--%>
                                                    <img width="50" src='<%# "Images/" + (string.IsNullOrEmpty(Convert.ToString(Eval("slogo"))) ? "NoImage.png" : Convert.ToString(Eval("slogo"))) %>' alt='<%#Eval("slogo")%>' />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><strong>City:</strong></td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" ClientIDMode="Static" Text='<%#Eval("sCity")%>'></asp:Label></td>
                                                <td><strong>State:</strong></td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" ClientIDMode="Static" Text='<%#Eval("sState")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Zip:</strong></td>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" ClientIDMode="Static" Text='<%#Eval("sZip")%>'></asp:Label></td>
                                                <td><strong>Email:</strong></td>
                                                <td>
                                                    <asp:Label ID="Label8" runat="server" ClientIDMode="Static" Text='<%#Eval("sEmail")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Phone:</strong></td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" ClientIDMode="Static" Text='<%#Eval("sPhoneNumber")%>'></asp:Label></td>
                                                <td><strong>Mobile:</strong></td>
                                                <td>
                                                    <asp:Label ID="Label7" runat="server" ClientIDMode="Static" Text='<%#Eval("sMobilenumber")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Address:</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblAddress" runat="server" ClientIDMode="Static" Text='<%#Eval("sAddress")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Facebook Url:</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label9" runat="server" ClientIDMode="Static" Text='<%#Eval("sFBURL")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Google Url:</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label10" runat="server" ClientIDMode="Static" Text='<%#Eval("sGURL")%>'></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td><strong>Linkedin Url:</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label11" runat="server" ClientIDMode="Static" Text='<%#Eval("sLinkdinURL")%>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><strong>Twitter Url:</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label12" runat="server" ClientIDMode="Static" Text='<%#Eval("sTwitterURL")%>'></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td><strong>Host :</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label1" runat="server" ClientIDMode="Static" Text='<%#Eval("host")%>'></asp:Label></td>

                                            </tr>
                                            <tr>
                                                <td><strong>From Email:</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label2" runat="server" ClientIDMode="Static" Text='<%#Eval("fromEmail")%>'></asp:Label></td>
                                            </tr>
                                            <asp:HiddenField ID="hdnpassword" runat="server" Value='<%#Eval("password")%>' />
                                           <%-- <tr>
                                                <td><strong>Password</strong></td>
                                                <td colspan="3">
                                                    <asp:Label ID="Label13" runat="server"  ClientIDMode="Static" Text='<%#Eval("password")%>'></asp:Label></td>

                                            </tr>--%>
                                        </table>
                                    </div>
                                </div>
                                <div class="col-sm-2 mb-3 mb-sm-0">
                                    <table class="table table-borderless">
                                        <tr>
                                            <td>
                                                <a href="#" class="btn btn-<%# Convert.ToString(Eval("bActive"))=="1" ? "info" : "secondary"  %> btn-icon-split">
                                                    <span class="icon text-white-50">
                                                        <i class="fas fa-arrow-right"></i>
                                                    </span>
                                                    <span class="text">
                                                        <asp:Label ID="LblStatus" runat="server" ClientIDMode="Static" Text='<%# Convert.ToString(Eval("bActive"))=="1" ? "Active":"InActive" %>'></asp:Label></span>
                                                </a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idClientMaster") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-circle btn-sm" CommandArgument='<%#Eval("idClientMaster") %>' OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="card-header py-3">
                        <asp:Label ID="lblNoRecordMsg" class="m-0 font-weight-bold text-primary" Text="No records found." Visible="false" runat="server"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <div class="card shadow mb-4" runat="server" id="frmClientMaster">
            <div class="card-header py-3">
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Name</label>
                        <br />
                        <asp:TextBox ID="txtName" runat="server" class="form-control form-control-user" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Logo</label>
                        <br />
                        <asp:FileUpload ID="imageUpload" runat="server" ClientIDMode="Static" />
                        <asp:Image runat="server" ID="imgpreview" ClientIDMode="Static" Width="50" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>City</label>
                        <br />
                        <asp:TextBox ID="txtCity" runat="server" class="form-control form-control-user" placeholder="City"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="txtCity" runat="server" ErrorMessage="Please Enter City." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>State</label>
                        <br />
                        <asp:TextBox ID="txtState" runat="server" class="form-control form-control-user" placeholder="State"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtState" runat="server" ErrorMessage="Please Enter State." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Zip</label>
                        <br />
                        <asp:TextBox ID="txtZip" runat="server" class="form-control form-control-user" placeholder="Zip"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" ControlToValidate="txtZip" runat="server" ErrorMessage="Please Enter Zip." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Country</label>
                        <br />
                        <asp:DropDownList CssClass="form-control form-control-user" ID="ddlCountryFrm" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Email</label>
                        <br />
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control form-control-user" placeholder="Email"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" ControlToValidate="txtEmail" runat="server" ErrorMessage="Please Enter Email." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Phone</label>
                        <br />
                        <asp:TextBox ID="txtPhone" runat="server" class="form-control form-control-user" placeholder="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" ControlToValidate="txtPhone" runat="server" ErrorMessage="Please Enter Phone." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Mobile</label>
                        <br />
                        <asp:TextBox ID="txtMobile" runat="server" class="form-control form-control-user" placeholder="Mobile"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="fontcolour" ControlToValidate="txtMobile" runat="server" ErrorMessage="Please Enter Mobile." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Address</label>
                        <br />
                        <asp:TextBox ID="txtAddress" runat="server" class="form-control form-control-user" placeholder="Address"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="fontcolour" ControlToValidate="txtAddress" runat="server" ErrorMessage="Please Enter Address." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Facebook Url</label>
                        <br />
                        <asp:TextBox ID="txtFacebookUrl" runat="server" class="form-control form-control-user" placeholder="Facebook link"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Google Url</label>
                        <br />
                        <asp:TextBox ID="txtGoogleUrl" runat="server" class="form-control form-control-user" placeholder="Google link"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Linkedin Url</label>
                        <br />
                        <asp:TextBox ID="txtLinkedinUrl" runat="server" class="form-control form-control-user" placeholder="Linkedin link"></asp:TextBox>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Twitter Url</label>
                        <br />
                        <asp:TextBox ID="txtTwitterUrl" runat="server" class="form-control form-control-user" placeholder="Twitter link"></asp:TextBox>
                    </div>
                </div>
                 <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Host</label>
                        <br />
                        <asp:TextBox ID="txtHost" runat="server" class="form-control form-control-user" placeholder="Host"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="fontcolour" ControlToValidate="txtHost" runat="server" ErrorMessage="Please Enter Host." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>From Email</label>
                        <br />
                        <asp:TextBox ID="txtFromEmail" runat="server" class="form-control form-control-user" placeholder="From Email"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="fontcolour" ControlToValidate="txtFromEmail" runat="server" ErrorMessage="Please Enter From Email." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                 <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Password</label>
                        <br />
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-user" TextMode="Password" placeholder="Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="fontcolour" ControlToValidate="txtPassword" runat="server" ErrorMessage="Please Enter Password." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chkStatus" runat="server" class="custom-control-input" ClientIDMode="Static" />
                        <label class="custom-control-label" for="chkStatus"></label>
                        <asp:Label ID="lblbStatus" runat="server" ClientIDMode="Static">Active</asp:Label>
                    </div>
                </div>
                <asp:Button ID="btnSaveClientMaster" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSaveClientMaster_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnCancelClientMaster" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancelClientMaster_Click" />
            </div>
        </div>
    </div>


    <!-- Page level plugins -->
    <%--<script type="text/javascript" src="scripts/jquery-1.3.2.js"></script>--%>
     <script src="vendor/jquery/jquery.min.js"></script>
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap.min.js"></script>
    <script type="text/javascript">
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
        $(document).ready(function () {
            $("#imageUpload").change(readURL);
            $("form").on('click', '.delbtn', function (e) {
                reset($(this));
            });
            $(".delbtn").remove();
        });
    </script>
</asp:Content>
