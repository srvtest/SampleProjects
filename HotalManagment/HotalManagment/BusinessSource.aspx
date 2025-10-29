<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BusinessSource.aspx.cs" Inherits="HotalManagment.BusinessSource" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Business Source</title>
    <script type="text/javascript">
        function ShowEditForm() {
            $('#AddBusinessSource').modal('show');
        } function ShowMessageForm() {
            $('#MessageModel').modal('show');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<ul class="breadcrumb">
                        <li><i class="icon-home"></i><a href="MainDashBoard.aspx">Home</a> <i class="icon-angle-right">
                        </i></li>
                        <li><a href="#">Business Source</a></li>
                    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header">
                <h2>
                    <i class="icon-user"></i><span class="break"></span>Business Source</h2>
                <div class="box-icon">
                    <asp:LinkButton ID="btnPlus" OnClick="btnAddNew_Click" CausesValidation="false" runat="server" CssClass="icon-plus-sign"></asp:LinkButton>
                    <a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                </div>
            </div>
            <div class="box-content">
                <asp:HiddenField ID="hdnBusinessSourceId" runat="server" />
                <asp:GridView ID="grdBusinessSource" runat="server" AutoGenerateColumns="false" Width="100%"
                    OnRowEditing="grdBusinessSource_RowEditing" 
                    onrowdeleting="grdBusinessSource_RowDeleting" ClientIDMode="Static">
                    <Columns>
                        
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Business Source">
                            <ItemTemplate>
                                <asp:Label ID="lblBusinessSource" runat="server" Text="<%#Bind('BusinessSourceName')%>"></asp:Label>
                                <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                      <asp:label id="lblStatus" runat="server" text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>'  CssClass="label label-success"/>
                                      <asp:label id="lblStatus1" runat="server" text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>'  CssClass="label label-warning"/>
                                      <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="65px">
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-success" runat="server" CausesValidation="false" CommandName="Edit" Text=""><i class="white icon-edit"></i></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" CssClass="btn btn-danger" runat="server" CausesValidation="false" CommandName="Delete" Text=""><i class="white icon-trash"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <!--/span-->
    </div>
    <!--/row-->
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
    <div class="modal fade" id="AddBusinessSource" data-backdrop="static">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update Business Source</h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
            <div  class="form-horizontal">
                <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="typeahead">
                            <span style="color: Red">*</span>Business Source
                        </label>
                        <div class="controls">
                            <asp:TextBox ID="txtBusinessSource" runat="server" class="input-large span10" ToolTip="Business Source"
                                placeholder="Business Source"></asp:TextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtBusinessSource" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="control-group">
                         <label class="control-label">Status</label>
                            <div class="controls">
                            <label class="checkbox inline" style="padding-top:10px;">
									 <asp:CheckBox ID="chkStatus" runat="server" ToolTip="Status" CssClass="myCheckbox"/>
								  </label>
                            </div>
                        </div>
                </fieldset>
            </div></div>
        </div>
        <div class="modal-footer">
            <asp:Button ID="btnClose" runat="server" Text="Close"  class="btn" 
                onclick="btnClose_Click" CausesValidation="false" />
            <asp:Button ID="btnsave" runat="server" Text="Save Business Source" class="btn btn-primary"
                OnClick="btnSave_Click" />
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#grdBusinessSource").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                responsive: true,
                sPaginationType: "bootstrap"
            });
        });
    </script>
</asp:Content>
