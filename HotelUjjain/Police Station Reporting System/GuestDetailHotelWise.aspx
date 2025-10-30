<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GuestDetailHotelWise.aspx.cs" Inherits="Police_Station_Reporting_System.GuestDetailHotelWise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        tr.group,
        tr.group:hover {
            background-color: rgba(0, 0, 0, 0.1) !important;
        }

        :root.dark tr.group,
        :root.dark tr.group:hover {
            background-color: rgba(0, 0, 0, 0.75) !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card">
        <div class="card-header">
            <h3 class="card-title">Guest details</h3>
        </div>
        <!-- /.card-header -->
        <div class="card-body">
            <div class="row invoice-info">
                <div class="col-sm-4 invoice-col">
                    Month- Year :
                    <asp:TextBox ID="txtFormDate" runat="server" type="month"></asp:TextBox>
                </div>
                <div class="col-sm-4 invoice-col">
                    Hotel :
                    <asp:DropDownList ID="ddlHotel" runat="server" ></asp:DropDownList>
                </div>
                <!-- /.col -->
                <div class="col-sm-4 invoice-col">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                </div>
                <!-- /.col -->
            </div>
        </div>
    </div>

    <div class="card">
        <!-- /.card-header -->
        <div class="card-body">
            <asp:Repeater ID="rptGuest" runat="server" OnItemDataBound="rptGuest_ItemDataBound">
                <HeaderTemplate>
                    <table id="example3" class="table table-bordered table-striped" style="width: 100%">
                        <thead>
                            <tr>
                                <th>S. No.</th>
                                <th>Hotel Name</th>
                                <th>Type</th>
                                <th>Guest Name</th>
                                <th>Contact</th>
                                <th>Address</th>
                                <th>Date</th>
                                <th>Additional Guests</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Container.ItemIndex + 1 %>
                            <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("idGuestMaster")%>' />
                        </td>
                        <td><%#Eval("HotelName")%></td>
                        <td class="py-1">
                            <img src="../../images/faces/face1.jpg" alt="image" />
                        </td>
                        <td><%#Eval("GuestName")%></td>
                        <td><%#Eval("ContactNo")%></td>
                        <td><%#Eval("Address")%></td>
                        <td>Check-In : <%#Eval("CheckInDate")%>
                            <br />
                            Check-Out : <%#Eval("CheckOutDate")%>
                        </td>
                        <td>
                            <asp:Label ID="lblAddGuest" runat="server" Text=""></asp:Label>
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
    <script>
        var groupColumn = 1;
        var table = $('#example').DataTable({
            columnDefs: [{ visible: false, targets: groupColumn }],
            order: [[groupColumn, 'asc']],
            displayLength: 25,
            drawCallback: function (settings) {
                var api = this.api();
                var rows = api.rows({ page: 'current' }).nodes();
                var last = null;

                api.column(groupColumn, { page: 'current' })
                    .data()
                    .each(function (group, i) {
                        if (last !== group) {
                            $(rows)
                                .eq(i)
                                .before(
                                    '<tr class="group"><td colspan="5">' +
                                    group +
                                    '</td></tr>'
                                );

                            last = group;
                        }
                    });
            }
        });

        // Order by the grouping
        $('#example tbody').on('click', 'tr.group', function () {
            var currentOrder = table.order()[0];
            if (currentOrder[0] === groupColumn && currentOrder[1] === 'asc') {
                table.order([groupColumn, 'desc']).draw();
            }
            else {
                table.order([groupColumn, 'asc']).draw();
            }
        });

    </script>
</asp:Content>
