<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="frmRequestResponseLogs.aspx.cs" Inherits="Hotel_Guest_Reporting_System.frmRequestResponseLogs" %>

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
        <asp:HiddenField ID="hdnId" runat="server" />
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdRequestResponseLogId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label>
                    </h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>frmRequestResponseLogs.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label>
                        </a>
                        </li>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnluserList">
            <div class="col-sm-12">
                <!-- Contextual classes table starts -->
                <div class="card" runat="server" id="tblCity">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl3" runat="server"></asp:Label>
                        </h5>
                        <div class="f-right">
                            <asp:DropDownList ID="ddlFilter" runat="server" CssClass="form-control dropdown" AutoPostBack="true" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
                                <asp:ListItem Text="Please select a Filter" Value="Please select a Filter"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                <asp:ListItem Text="200" Value="200"></asp:ListItem>
                                <asp:ListItem Text="300" Value="300"></asp:ListItem>
                                <asp:ListItem Text="400" Value="400"></asp:ListItem>
                                <asp:ListItem Text="500" Value="500"></asp:ListItem>
                                <asp:ListItem Text="600" Value="600"></asp:ListItem>
                                <asp:ListItem Text="700" Value="700"></asp:ListItem>
                                <asp:ListItem Text="800" Value="800"></asp:ListItem>
                                <asp:ListItem Text="900" Value="900"></asp:ListItem>
                                <asp:ListItem Text="1000" Value="1000"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="card-block">
                       <%-- <div class="row">
                            <div class="col-md-3 form-group">
                                <label for="exampleInputEmail" class="form-control-label">Filter data</label>

                            </div>
                        </div>--%>
                        <div class="row">
                            <div class="col-sm-12 table-responsive">
                                <asp:Repeater ID="RptUser" runat="server" OnItemCommand="RptUser_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered" style="width: 100%" id="example">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>RequestAPIType</th>
                                                    <th>RequestAPIName</th>
                                                    <th>RequestBody</th>
                                                    <th>ResponseBody</th>
                                                    <th>Created On</th>
                                                    <%-- <th>Action</th>--%>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td style="word-break: break-all;">
                                                <asp:HiddenField ID="hdId" runat="server" Value='<%# Eval("RequestResponseLogId") %>' />
                                                <%#Eval("RequestAPIType")%>
                                            </td>
                                            <td style="word-break: break-all;">
                                                <%#Eval("RequestAPIName")%>
                                            </td>
                                            <td style="word-break: break-all;">
                                                <%-- <%#Eval("RequestBody")%>--%>
                                                <span class="shortText">
                                                    <%# Eval("RequestBody").ToString().Length > 40 ? Eval("RequestBody").ToString().Substring(0, 40) + "..." : Eval("RequestBody") %>
                                                </span>
                                                <span class="fullText" style="display: none;">
                                                    <%# Eval("RequestBody") %>
                                                </span>
                                                <%#(String.IsNullOrEmpty(Eval("RequestBody").ToString()) ? "" : "<a href=\"javascript:void(0);\" onclick=\"toggleText(this)\">Read More</a>")%>                                                
                                            </td>
                                            <td style="word-break: break-all;">
                                                <%--<%#Eval("ResponseBody")%>--%>
                                                <span class="shortText">
                                                    <%# Eval("ResponseBody").ToString().Length > 40 ? Eval("ResponseBody").ToString().Substring(0, 40) + "..." : Eval("ResponseBody") %>
                                                </span>
                                                <span class="fullText" style="display: none;">
                                                    <%# Eval("ResponseBody") %>
                                                </span>
                                                <%#(String.IsNullOrEmpty(Eval("ResponseBody").ToString()) ? "" : "<a href=\"javascript:void(0);\" onclick=\"toggleText(this)\">Read More</a>")%> 
                                            </td>
                                            <td style="word-break: break-all;"><%#Eval("CreatedOn").ToString() == "1/1/0001 12:00:00 AM" ? "" : String.Format("{0:dd/MM/yy HH:mm}", Eval("CreatedOn")) %></td>
                                            <%--<td>
                                                <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Edit" CommandArgument='<%# Eval("idErrorLog") %>' CommandName="Update" />
                                                <asp:Button ID="Button2" runat="server" Text="Delete" class="btn btn-default waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="Delete" CommandArgument='<%# Eval("idErrorLog") %>' CommandName="Delete" />
                                                 <asp:Button ID="Button3" runat="server" Text="View" class="btn btn-guestsuccess waves-effect waves-light" data-toggle="tooltip" data-placement="top" title="View" CommandArgument='<%# Eval("idErrorLog") %>' CommandName="View" />
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
        <!-- Row start -->
        <%-- <div class="row">
            <!--Basic Form starts-->
            <div class="col-lg-6">
                <div class="card" runat="server" id="pnlUser">
                    <div class="card-header" style="background-color: #ffe2c8;">
                        <h5 class="card-header-text">
                            <asp:Label ID="lbl4" runat="server"></asp:Label></h5>
                    </div>
                    <div class="card-block">
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Method</label>
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Enter Method"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please enter Method" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Error Message</label>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Enter Error Message"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please enter Error Message" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">Error Type</label>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Enter Error Type"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please enter Error Type" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword" class="form-control-label">dt Created</label>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Enter dtCreated"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please enter dtCreated" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </div>

                        <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-guestsuccess waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Save" OnClick="btnSubmit_Click" ValidationGroup="save" />
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-default waves-effect waves-light m-r-30" data-toggle="tooltip" data-placement="top" title="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
        </div>--%>
        <%--<div class="modal fade modal-flex" id="basic-form-Modal1" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title">Message</h5>
                    </div>
                    <!-- end of modal-header -->
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i>Are you sure to delete the records?
                    </div>
                    <!-- end of modal-body -->
                    <div class="modal-footer">
                        <a href="frmCityMaster.aspx" class="btn btn-default me-2">No</a>
                        <asp:Button ID="Button1" runat="server" Text="Yes" class="btn btn-guestsuccess me-2" data-toggle="tooltip" data-placement="top" title="Yes" OnClick="Button3_Click" />
                    </div>
                </div>
                <!-- end of modal-content -->
            </div>
            <!-- end of modal-dialog -->
        </div>
        <!-- end of modal -->
        <div class="modal fade modal-flex" id="basic-form-Modal2" tabindex="-1" role="dialog">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h5 class="modal-title">Message</h5>
                    </div>
                    <!-- end of modal-header -->
                    <div class="modal-body">
                        <i class="fa fa-exclamation-triangle fa-2x"></i>Are you sure to submit the records?
                    </div>
                    <!-- end of modal-body -->
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">No</span>
                        </button>
                        <asp:Button ID="Button4" runat="server" Text="Yes" class="btn btn-guestsuccess me-2" OnClick="Button4_Click" />
                    </div>
                </div>
                <!-- end of modal-content -->
            </div>
            <!-- end of modal-dialog -->
        </div>--%>
        <!-- end of modal -->
    </div>
    <script type="text/javascript">  
        //function QuestionDeleteData(body) {
        //    $("#basic-form-Modal1 .modal-body").html(body);
        //    $("#basic-form-Modal1").modal('show');
        //    return false;
        //}
        //function QuestionAddData(body) {
        //    $("#basic-form-Modal2 .modal-body").html(body);
        //    $("#basic-form-Modal2").modal('show');
        //    return false;
        //}
        function toggleText(link) {
            var container = link.parentElement;
            var shortText = container.querySelector(".shortText");
            var fullText = container.querySelector(".fullText");

            if (shortText.style.display === "none") {
                shortText.style.display = "inline";
                fullText.style.display = "none";
                link.textContent = "Read More";
            } else {
                shortText.style.display = "none";
                fullText.style.display = "inline";
                link.textContent = "Read Less";
            }
        }
    </script>
</asp:Content>


