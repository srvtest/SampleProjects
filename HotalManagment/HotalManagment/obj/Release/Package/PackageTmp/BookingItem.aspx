<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="BookingItem.aspx.cs" Inherits="HotalManagment.BookingItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>BookingItems</title>
    <script type="text/javascript">
        function ShowEditForm() {
            $('#AddBookingItem').modal('show');
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
        <li><a href="#">Booking Item</a></li>
    </ul>
    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header" data-original-title>
                <h2>
                    <i class="icon-user"></i><span class="break"></span>Booking Item</h2>
                <div class="box-icon"><a href="#" class="btn-minimize"><i class="icon-chevron-up"></i></a>
                </div>
            </div>
            <div class="box-content">
                <asp:HiddenField ID="hdBookingId" runat="server" />
                <asp:GridView ID="grdBookingDetail" DataKeyNames="ID" AutoGenerateColumns="false"
                    runat="server" Width="100%" ClientIDMode="Static" OnRowEditing="grdBookingDetail_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Category Name">
                            <ItemTemplate>
                                <asp:Label ID="lblcategoryName" runat="server" Text="<%#Bind('categoryName')%>"></asp:Label>
                                <asp:HiddenField ID="hdnId" runat="server" Value="<%#Bind('Id') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Room No">
                            <ItemTemplate>
                                    <asp:Label ID="lblRoomNo" runat="server" Text=" <%#Bind('RoomNo')%>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="From Date">
                            <ItemTemplate>
                                    <asp:Label ID="lblFromDate" runat="server" Text="<%#Bind('FromDate')%>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To Date">
                            <ItemTemplate>
                                    <asp:Label ID="lblToDate" runat="server" Text="<%#Bind('ToDate')%>"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="50px">
                            <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status").ToString().Equals("True") ? "Active" : "" %>'
                                        CssClass="label label-success" />
                                    <asp:Label ID="lblStatus1" runat="server" Text='<%# Eval("Status").ToString().Equals("True") ? "" : "Inactive" %>'
                                        CssClass="label label-warning" />
                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('Status') %>" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" CssClass="btn btn-success" runat="server" CausesValidation="false"
                                        CommandName="Edit" Text=""><i class="white icon-plus"></i></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="modal fade" id="AddBookingItem" style="width: 62%" data-backdrop="static">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal">
                ×</button>
            <h3>
                Add/Update Booking Item</h3>
        </div>
        <div class="modal-body">
            <div class="box-content">
                <div class="form-horizontal">
                    <fieldset>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="grdBookedItem" AutoGenerateColumns="false" runat="server" 
                                    Width="100%" ClientIDMode="Static" OnRowDataBound="grdBookedItem_RowDataBound"
                                    OnRowCommand="grdBookedItem_RowCommand" OnRowUpdating="grdBookedItem_RowUpdating"
                                    OnRowCancelingEdit="grdBookedItem_RowCancelingEdit">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Item" HeaderStyle-Width="25%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblItemName" runat="server" Text="<%#Bind('ItemName')%>"></asp:Label>
                                                <asp:HiddenField ID="hdbitemId" runat="server" Value="<%#Bind('Id') %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Price" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text="<%#Bind('Price')%>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="Quantity" HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblQuantity" runat="server" Text="<%#Bind('Quantity')%>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" HeaderStyle-Width="15%">
                                            <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("status").ToString().Equals("1") ? "Order" : "" %>'
                                                        CssClass="label label-success" />
                                                    <asp:Label ID="lblStatus1" runat="server" Text='<%# Eval("status").ToString().Equals("2") ? "Delivered" : "" %>'
                                                        CssClass="label label-warning" />
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("status").ToString().Equals("3") ? "Cancelled" : "" %>'
                                                        CssClass="label label-danger" />
                                                    <asp:HiddenField ID="hdnStatusId" runat="server" Value="<%#Bind('status') %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-Width="20%">
                                            <ItemTemplate>
                                                <asp:Button ID="btnItemDelivered" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                                                    CommandName="Update" Text="Deliver" />
                                                <asp:Button ID="btnOderCancel" runat="server" CssClass="btn btn-danger" CausesValidation="false"
                                                    CommandName="Cancel" Text="Cancel" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:DropDownList ID="cboNewItemName" ToolTip="Select Items" runat="server" CausesValidation="true"
                                    AutoPostBack="true" OnSelectedIndexChanged="cboNewItemName_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtPrice" runat="server" ToolTip="Price" Enabled="false" Style="background: #fff"></asp:TextBox>
                                <asp:TextBox ID="txtQty" min="1" Text="1" required="required" ToolTip="Quantity" TextMode="Number" runat="server"></asp:TextBox>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </fieldset>
                </div>
            </div>
        </div>
        <div class="modal-footer">
            <a href="#" class="btn" data-dismiss="modal">Close</a>
            <asp:Button ID="btnsave" runat="server" Text="Save Book Item" class="btn btn-primary"
                OnClick="btnsave_Click" />
        </div>
    </div>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#grdBookingDetail").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable({
                responsive: true,
                sPaginationType: "bootstrap"
            });
        });
    </script>
</asp:Content>
