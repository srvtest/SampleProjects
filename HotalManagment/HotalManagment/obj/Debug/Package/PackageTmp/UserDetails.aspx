<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="UserDetails.aspx.cs" Inherits="HotalManagment.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User</title>
    <script>
        function ShowEditForm() {
            $('#AddUserDeatils').modal('show');
        }
        function ShowMessageForm() {
            $('#MessageModel').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="breadcrumb">
        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
        </i></li>
        <li><a href="#">Users</a></li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2>
                    <i class="icon-user"></i><span class="break"></span>User</h2>
                <div class="box-icon">
                    <a href="#" class="btn-user"><i class="icon-plus-sign"></i></a><a href="#"
                        class="btn-minimize"><i class="icon-chevron-up"></i></a><a href="#" class="btn-close">
                            <i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <asp:HiddenField ID="hdnUpadteId" runat="server" />
                <asp:GridView ID="grdUserDetails" runat="server" ClientIDMode="Static"  AutoGenerateColumns="false" Width="100%"
                    OnRowEditing="grdUserDetails_RowEditing" 
                    onrowdeleting="grdUserDetails_RowDeleting">
                    <Columns>
                       
                        <asp:TemplateField HeaderText="User Name">
                            <ItemTemplate>
                                <asp:Label ID="lblUserName" runat="server" Text="<%#Bind('Username')%>"></asp:Label>
                                <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                                <asp:HiddenField ID="hdnPassword" runat="server" Value="<%#Bind('Password') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <center>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>'
                                        CssClass="label label-success" />
                                    <asp:Label ID="lblStatus1" runat="server" Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>'
                                        CssClass="label label-warning" />
                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="90px">
                            <ItemTemplate>
                                <center>
                                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-success" runat="server" CausesValidation="false" CommandName="Edit" Text=""><i class="white icon-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server" CausesValidation="false" CommandName="Delete" Text=""><i class="white icon-trash"></i></asp:LinkButton>
                                </center>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->

     <div>
        <link type="text/css" rel="stylesheet" href="https://cdn.datatables.net/1.10.12/css/jquery.dataTables.min.css" />
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
        <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $("#grdUserDetails").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
                $('#grdUserDetails').DataTable({
                    bDestroy: true,
                    bRetrieve: true,
                    stateSave: true
                });
            });
        </script>
    </div>
    <script language="javascript" type="text/javascript">
   
    </script>
    <div class="modal fade" id="MessageModel">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Message</h3>
        </div>
        <div class="modal-body">
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" data-dismiss="modal">OK</a>
        </div>
    </div>
    <div class="modal fade" id="AddUserDeatils" data-backdrop="static">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update User</h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
                <fieldset>
                    <div class="control-group">
                        <div class="controls">
                            <span style="color: Red">*</span><asp:TextBox ID="txtUserName" runat="server" class="input-large span10"
                                placeholder="User Name" ToolTip="User Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <span style="color: Red">*</span><asp:TextBox ID="txtPassword" runat="server" class="input-large span10"
                                placeholder="Password" ToolTip="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" data-dismiss="modal">Close</a>
            <asp:Button ID="btnSave" runat="server" Text="Add" class="btn btn-primary" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
