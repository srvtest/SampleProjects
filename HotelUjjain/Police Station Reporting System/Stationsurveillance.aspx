<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Stationsurveillance.aspx.cs" Inherits="Police_Station_Reporting_System.Stationsurveillance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btnAction {
            margin-top: 5px;
        }

        .btnGuest {
            width: 192px;
        }

        .modalign {
            align-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">निगरानी में जोड़ी गई आईडी के परिणाम</asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptSurveillance" runat="server" OnItemCommand="rptSurveillance_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example4" class="table table-bordered table-striped nowrap" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>S. No.</th>
                                                    <th>Message</th>
                                                    <th>Date</th>
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
                                            </td>
                                            <td><%#Eval("smessage")%></td>
                                            <td><%#Convert.ToDateTime(Eval("NotificationDate")).ToString("dd-MMM-yyyy")%></td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="अतिथि की जानकारी देखें" class="btn btn-primary waves-effect waves-light btnGuest" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Details" /></br>
                                                <asp:Button ID="Button2" runat="server" Text="इस पर कार्रवाई की जा चुकी है।" class="btn btn-primary waves-effect waves-light btnAction" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Action" OnClientClick="return SaveGuestData();" />
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
        $(function () {
            //$("#example1").DataTable({
            //    "responsive": true, "lengthChange": false, "autoWidth": false,
            //    "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
            //}).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');

        });
    </script>
</asp:Content>
