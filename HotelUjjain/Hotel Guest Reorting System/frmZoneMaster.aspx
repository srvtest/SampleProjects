<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmZoneMaster.aspx.cs" Inherits="Hotel_Guest_Reporting_System.frmZoneMaster" %>

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
        <asp:HiddenField ID="hdZoneId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmZoneMaster.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnluserList">
            <div class="col-sm-12">
                <!-- Contextual classes table starts -->
                <div class="card" runat="server" id="tblZone">
                    <div class="card-header">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl3" runat="server"></asp:Label></h5>
                        <div class="f-right">
                            <asp:Button ID="btnNew" runat="server" Text="New" class="btn btn-success waves-effect waves-light m-r-30" OnClick="btnNew_Click" />
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
                                                    <th>Zone Name</th>
                                                    <th>City Name</th>
                                                    <th>State Name</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td>
                                                <asp:Label ID="lblsName" runat="server" ClientIDMode="Static" Text='<%#Eval("ZoneName")%>'></asp:Label>
                                            </td>
                                            <td><%#Eval("CityName")%></td>
                                            <td><%#Eval("stateName")%></td>
                                            <td>
                                                <asp:HiddenField ID="hdId" runat="server" Value='<%# Eval("idZone") %>' />
                                                <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Update" />
                                                <asp:Button ID="Button2" runat="server" Text="Delete" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Delete" />
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
        <div class="row" runat="server" id="Div1">
            <!--Basic Form starts-->
            <div class="col-lg-6">
                <div class="card" runat="server" id="pnlUser">
                    <div class="card-header">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl4" runat="server"></asp:Label></h5>
                    </div>                   

                    <div class="card-block">
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">State Name</label>
                            <asp:DropDownList ID="ddlStateId" runat="server" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateId_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="ddlStateId" ErrorMessage="Please select state" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">City Name</label>
                            <asp:DropDownList ID="ddlCityId" runat="server" class="form-control"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="ddlCityId" ErrorMessage="Please select city" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Zone Name</label>
                            <asp:TextBox ID="txtZonename" runat="server" class="form-control" placeholder="Enter Zone name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="txtZonename" ErrorMessage="Please select zone" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="chkme" class="form-check-label">
                                <%--<input type="checkbox" class="form-check-input" id="chkme">--%>
                                <asp:CheckBox ID="chkme" class="form-check-input" type="checkbox" runat="server" />
                                Active
                            </label>
                        </div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-success waves-effect waves-light m-r-30" OnClick="btnSubmit_Click" ValidationGroup="save"/>
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-success waves-effect waves-light m-r-30" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
