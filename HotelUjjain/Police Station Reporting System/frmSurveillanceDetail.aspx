<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="frmSurveillanceDetail.aspx.cs" Inherits="Police_Station_Reporting_System.frmSurveillanceDetail" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
    <style>
        .btnAction {
            margin-top: 5px;
        }

        .btnGuest {
            width: 115px;
        }

        .modalign {
            align-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">सर्विलेंस की जानकारी देखे</asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptSurveillance" runat="server" OnItemCommand="rptSurveillance_ItemCommand" OnItemDataBound="rptSurveillance_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="example3" class="table table-bordered table-striped nowrap" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>S. No.</th>
                                                    <th>Message</th>
                                                    <th>Date</th>
                                                    <th>Status</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %>
                                                <asp:HiddenField ID="hdnidUserNotification" runat="server" Value='<%#Eval("idUserNotification")%>' />
                                                <asp:HiddenField ID="hdnidGuestMaster" runat="server" Value='<%#Eval("idGuestMaster")%>' />
                                                <asp:HiddenField ID="hdnIsRead" runat="server" Value='<%#Eval("isRead")%>' />
                                            </td>
                                            <td><%#Eval("smessage")%></td>
                                            <td><%#Convert.ToDateTime(Eval("NotificationDate")).ToString("dd-MMM-yyyy")%></td>
                                            <td><%#Convert.ToString(Eval("isRead"))=="True"? "एक्शन ले लिया है": "एक्शन अभी नहीं लिया है"%></td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="विवरण" class="btn btn-primary waves-effect waves-light btnGuest" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Details" /></br>
                                                <asp:Button ID="Button2" runat="server" Text="एक्शन ले लिया है" class="btn btn-primary waves-effect waves-light btnAction" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Action" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
    </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                            <!-- /.card-body -->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div class="modal fade modalign" id="saveModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel" style="text-align: center;">Save Records</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <asp:HiddenField ID="hdnIds" runat="server" />
                    <i class="fa fa-exclamation-triangle fa-2x"></i>आपके द्वारा कार्रवाई करने के बाद यहां से जानकारी इस सूची से हटा दी जाएगी।
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <asp:Button ID="Button2" runat="server" Text="इस पर कार्रवाई की जा चुकी है।" class="btn btn-info waves-effect waves-light" data-toggle="tooltip" data-placement="top" title=".icofont-home " OnClick="Button2_Click" />
                    <%--<button type="button" class="btn btn-primary me-2" data-dismiss="modal" aria-label="Close">ठीक है</button>--%>
                    <a href="Stationsurveillance.aspx" class="btn btn-primary me-2">रद्द करें
                    </a>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function SaveGuestData() {
            $('#saveModal').modal('show');
            /*return false;*/

        }

    </script>
</asp:Content>
