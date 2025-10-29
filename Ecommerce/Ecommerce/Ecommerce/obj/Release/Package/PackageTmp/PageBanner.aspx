<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="PageBanner.aspx.cs" Inherits="Ecommerce.PageBanner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet" />
    <style>
        .floatRight {
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnPageBannerId" runat="server" Value="0" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Page Banner</h1>
        <%--<p class="mb-4">Additional Link Description</p>--%>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblPageBanner">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Page Banner Details</h6>
                <asp:Button ID="btnPageBanner" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnPageBanner_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="rptPageBanner" runat="server" OnItemCommand="rptPageBanner_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>Name</th>
                                        <th>Image</th>
                                        <th>Dimension</th>
                                        <th>Status</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <td>
                                    <img width="100" src='<%# "Images/Banners/" + (string.IsNullOrEmpty(Convert.ToString(Eval("ImageURL"))) ? "NoImage.png" : Convert.ToString(Eval("ImageURL"))) %>' alt='<%#Eval("ImageURL")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("sDimension")%>'></asp:Label>
                                </td>
                                <td>
                                    <a href="#" class="btn btn-<%# Convert.ToBoolean(Eval("bActive")) ? "info" : "secondary"  %> btn-icon-split">
                                        <span class="icon text-white-50">
                                            <i class="fas fa-arrow-right"></i>
                                        </span>
                                        <span class="text">
                                            <asp:Label ID="lblStatus" runat="server" ClientIDMode="Static" Text='<%# Convert.ToBoolean(Eval("bActive")) ? "Active":"InActive" %>'></asp:Label></span>
                                    </a>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CssClass="btn btn-success btn-circle btn-sm" CommandArgument='<%#Eval("idBanner") %>'><i class="fas fa-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CssClass="btn btn-danger btn-circle btn-sm" CommandArgument='<%#Eval("idBanner") %>' OnClientClick="return confirm('Are you sure you want delete');"><i class="fas fa-trash"></i></asp:LinkButton>
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

        <div class="card shadow mb-4" runat="server" id="frmPageBanner">
            <div class="card-header py-3">
                <asp:Label ID="lblMessage" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Name</label>
                        <br />
                        <asp:TextBox ID="txtName" runat="server" class="form-control form-control-user" placeholder="Name"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" ControlToValidate="txtName" runat="server" ErrorMessage="Please Enter name." ValidationGroup="save"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Banner</label>
                        <br />
                        <asp:FileUpload ID="imageUpload" runat="server" ClientIDMode="Static" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="imageUpload" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please select image for banner." ValidationGroup="save"></asp:RequiredFieldValidator>
                        <asp:Image runat="server" ID="imgpreview" ClientIDMode="Static" Width="50" />
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        <label>Dimension</label>
                        <br />
                        <asp:TextBox ID="txtDimension" runat="server" class="form-control form-control-user" placeholder="(Width)X(Height)"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtDimension" runat="server" Display="Dynamic" ForeColor="Red" ErrorMessage="Please Enter Dimension." ValidationGroup="save"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtDimension" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter valid demension like (Width)X(Height)" ValidationGroup="save" ValidationExpression="^\d+(\.\d+)?X\d+(\.\d+)?|^\d+(\.\d+)?x\d+(\.\d+)?"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="custom-control custom-checkbox">
                        <asp:CheckBox ID="chkStatus" runat="server" class="custom-control-input" ClientIDMode="Static" />
                        <label class="custom-control-label" for="chkStatus"></label>
                        <asp:Label ID="lblbStatus" runat="server" ClientIDMode="Static">Active</asp:Label>
                    </div>
                </div>
                <asp:Button ID="btnSavePageBanner" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSavePageBanner_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnCancelPageBanner" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancelPageBanner_Click" />
            </div>
        </div>
    </div>
</asp:Content>
