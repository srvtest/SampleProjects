<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmRoleNavigation.aspx.cs" Inherits="Hotel_Guest_Reporting_System.frmRoleNavigation" %>

<%@ MasterType VirtualPath="~/mainHome.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .fontcolour {
        color: red;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdRoleNavigationId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmRoleNavigation.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnluserList">
            <div class="col-sm-12">
                <!-- Contextual classes table starts -->
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl3" runat="server"></asp:Label></h5>
                        <div class="f-right">
                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-success waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="New" OnClick="btnNew_Click" />
                        </div>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-sm-12 table-responsive">
                                <asp:Repeater ID="RptUser" runat="server" OnItemCommand="RptUser_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered" style="width: 100%" id="example">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>RoleID</th>
                                                    <th>NavigationID</th>
                                                    <th>Active</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>2</td>
                                            <td><%#Eval("idRole")%></td>
                                            <td><%#Eval("idNavigation")%></td>
                                            <td>
                                                <a href="#" class="btn <%# Convert.ToString(Eval("bActive"))=="True" ? "active" : "disabled"  %> ">
                                                    <span class="icon text-white-50">
                                                        <i class="fas fa-arrow-right"></i>
                                                    </span>
                                                    <span class="text">
                                                        <%--     <asp:HiddenField ID="hdnStatus" Value='<%# Bind("Status") %>' runat="server" />--%>
                                                        <asp:Label ID="LblStatus" runat="server" ClientIDMode="Static" Text='<%# Convert.ToString(Eval("bActive"))=="True" ? "Active":"InActive" %>'></asp:Label></span>
                                                </a>
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="hduserId" runat="server" Value='<%# Eval("idRoleNavigation") %>' />
                                                <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Edit" CommandName="Update" />
                                                <asp:Button ID="Button2" runat="server" Text="Delete" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Delete" CommandName="Delete" />
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
                </div>
                <!-- Contextual classes table ends -->
            </div>
        </div>
        <!-- Row start -->
        <div class="row" runat="server" id="pnlUser">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl4" runat="server"></asp:Label></h5>
                    </div>

                    <div class="card-block">
                        <%--<p class="m-b-20">
                        Individual form controls automatically receive some global styling. All textual <code>&lt;input&gt;</code>,
                      <code>&lt;textarea&gt;</code>, and <code>&lt;select&gt;</code> elements with <code>.form-control</code> are
                      <code>width: 100%;</code> by default.Labels and controls in <code>.form-group</code> for optimum spacing.
                    </p>--%>

                        <form>
                            <div class="form-group">
                                <label for="exampleInputEmail" class="form-control-label">idRole</label>
                                <asp:TextBox ID="txtidRole" runat="server" class="form-control" placeholder="Enter idRole"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="exampleInputPassword" class="form-control-label">IdNevigation</label>
                                <asp:TextBox ID="txtIdNevigation" runat="server" class="form-control" placeholder="Enter IdNevigation"></asp:TextBox>
                            </div>
                            <div class="">
                                <div class="checkbox checkbox-primary" id="chkremember">
                                    <label for="exampleInputPassword" class="form-control-label">Active</label>
                                    <asp:CheckBox ID="chkbActive" runat="server" />
                                </div>
                            </div>
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-success waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Save" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-success waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Cancel" OnClick="btnCancel_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
