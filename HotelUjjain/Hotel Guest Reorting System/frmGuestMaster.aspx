<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmGuestMaster.aspx.cs" Inherits="Hotel_Guest_Reporting_System.frmGuestMaster" %>

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
        <asp:HiddenField ID="hdGuestMasterId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmGuestMaster.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnluserList">
            <div class="col-sm-12">
                <!-- Contextual classes table starts -->
                <div class="card" runat="server" id="tblGuestMaster">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl3" runat="server"></asp:Label></h5>
                        <div class="f-right">
                            <asp:Button ID="btnNew" runat="server" Text="Update All" class="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="New" OnClick="btnNew_Click" />
                        </div>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-sm-12 table-responsive">
                                <asp:Repeater ID="RptUser" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-bordered" style="width: 100%" id="example">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Guest Name</th>
                                                    <th>ContactNo</th>
                                                    <th>IdentificationNo</th>
                                                    <%--  <th>Address</th>                                                   
                                                    <th>IdentificationType</th>
                                                    <th>CheckInDate</th>
                                                    <th>CheckOutDate</th>
                                                    <th>EnterDate</th>
                                                    <th>Description</th>
                                                    <th>isSubmited</th>--%>
                                                    <%-- <th>Hotel Name</th>--%>
                                                    <%--<th>Action</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td>
                                                <asp:HiddenField ID="hdHotelId" runat="server" Value='<%# Eval("GuestId") %>' />
                                                <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("GuestName")%>'></asp:Label>
                                            </td>
                                            <td><%#Eval("GuestMobileNumber")%></td>
                                            <td><%#Eval("IDProofNumber")%></td>
                                          <%--  <td>

                                                <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Edit" CommandName="Update" />
                                                <asp:Button ID="Button2" runat="server" Text="Delete" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Delete" CommandName="Delete" />
                                            </td>--%>
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
        <%--<!-- Row start -->
        <div class="row" runat="server" id="pnlUser">
            <!--Basic Form starts-->
            <div class="col-lg-12">
                <div class="card" runat="server">
                    <div class="card-header">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl4" runat="server"></asp:Label></h5>
                    </div>
                    <div class="card-block">
                        <div class="form-inline">

                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Guest Name</label>
                                <asp:TextBox ID="txtGuestName" runat="server" class="form-control" placeholder="Enter Guest Name"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" class="form-control" placeholder="Enter Address"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Contact No</label>
                                <asp:TextBox ID="txtContactNo" runat="server" class="form-control" placeholder="Enter ContactNo"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Identification No</label>
                                <asp:TextBox ID="txtIdentificationNo" runat="server" class="form-control" placeholder="Enter Identification No"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Identification Type</label>
                                <asp:TextBox ID="txtIdentificationType" runat="server" class="form-control" placeholder="Enter Identification Type"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Check In Date</label>
                                <asp:TextBox ID="txtCheckInDate" runat="server" class="form-control" placeholder="Enter Check In Date" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Check Out Date</label>
                                <asp:TextBox ID="txtCheckOutDate" runat="server" class="form-control" placeholder="Enter Check Out Date" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Enter Date</label>
                                <asp:TextBox ID="txtEnterDate" runat="server" class="form-control" placeholder="Enter Date" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">Description</label>
                                <asp:TextBox ID="txtDEscription" runat="server" class="form-control" placeholder="Enter Description"></asp:TextBox>
                            </div>
                            <div class="form-group m-r-15">
                                <label for="exampleInputEmail" class="block form-control-label">No of Additional Guest</label>
                                <asp:TextBox ID="TxtNoofGuest" runat="server" class="form-control" placeholder="No of Guest" TextMode="Number" OnTextChanged="TxtNoofGuest_TextChanged" AutoPostBack="true"></asp:TextBox>
                            </div>
                            <div class="">
                                <div class="checkbox checkbox-primary" id="chkremember">
                                    <asp:CheckBox ID="chkActive" runat="server" />
                                    <label class="m-b-10">
                                        Active
                                    </label>
                                </div>
                            </div>
                            <asp:Repeater ID="rptGuest" runat="server">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="card-block">
                                        <div class="form-inline">
                                            <div class="form-group m-r-15">
                                                <label for="exampleInputEmail" class="block form-control-label">Name</label>
                                                <asp:TextBox ID="txtAddGuestName" runat="server" class="form-control" placeholder="Enter Name"></asp:TextBox>
                                            </div>
                                            <div class="form-group m-r-15">
                                                <label for="exampleInputEmail" class="block form-control-label">Identification Type</label>
                                                <asp:TextBox ID="txtAddGuestType" runat="server" class="form-control" placeholder="Enter Identification Type"></asp:TextBox>
                                            </div>
                                            <div class="form-group m-r-30">
                                                <label for="exampleInputEmail" class="block form-control-label">Identification No</label>
                                                <asp:TextBox ID="txtAddGuestIdno" runat="server" class="form-control" placeholder="Enter Identification No"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>

                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-success waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Save" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-success waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-header">
                        <h5 class="card-header-text">Guest Detail</h5>

                    </div>
                    <div class="modal fade modal-flex" id="basic-form-Modal1" tabindex="-1" role="dialog">
                        <div class="modal-dialog modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">&times;</span>
                                    </button>
                                    <h5 class="modal-title">Code Explanation for Basic Form</h5>
                                </div>
                                <!-- end of modal-header -->
                                <div class="modal-body">
                                </div>
                                <!-- end of modal-body -->
                            </div>
                            <!-- end of modal-content -->
                        </div>
                        <!-- end of modal-dialog -->
                    </div>
                    <!-- end of modal -->
                </div>
            </div>
        </div>--%>
</asp:Content>
