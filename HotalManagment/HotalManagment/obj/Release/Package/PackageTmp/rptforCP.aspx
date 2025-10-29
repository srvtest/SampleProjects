<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptforCP.aspx.cs" Inherits="HotalManagment.rptforCP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Channel partner transection</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta name="description" content="Responsive Admin Template" />
    <meta name="author" content="SmartUniversity" />
    <!-- google font -->
    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700"
        rel="stylesheet" type="text/css" />
    <!-- icons -->
    <link href="assets/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <!-- bootstrap -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- data tables -->
    <link href="assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.css"
        rel="stylesheet" type="text/css" />
    <!-- Material Design Lite CSS -->
    <link rel="stylesheet" href="assets/plugins/material/material.min.css">
    <link rel="stylesheet" href="assets/css/material_style.css">
    <!-- animation -->
    <link href="assets/css/pages/animate_page.css" rel="stylesheet">
    <!-- Template Styles -->
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/theme-color.css" rel="stylesheet" type="text/css" />
    <!-- favicon -->
    <link rel="shortcut icon" href="assets/img/favicon.ico" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.1.3/css/bootstrap.css"
        rel="stylesheet" type="text/css" />
    <link href="https://cdn.datatables.net/1.10.19/css/dataTables.bootstrap4.min.css"
        rel="stylesheet" type="text/css" />
</head>
<body class="page-header-fixed sidemenu-closed-hidelogo page-content-white page-md header-white dark-sidebar-color logo-dark">
    <form id="form1" runat="server">
        <div class="page-wrapper">
            <div class="page-content-wrapper">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-box">
                            <div class="card-head">
                                <header>Channel partner transection</header>
                                <div class="tools">
                                    <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a><a class="t-collapse btn-color fa fa-chevron-down"
                                        href="javascript:;"></a><a class="t-close btn-color fa fa-times" href="javascript:;"></a>
                                </div>
                            </div>
                            <div class="card-body ">
                                <input type="button" id="btnExport" value="Export" />
                                <asp:Repeater ID="rptCPdetail" runat="server">
                                    <HeaderTemplate>
                                        <table id="example" class="table table-striped table-bordered table2excel" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>Hotel Name
                                                    </th>
                                                    <th>Booking Vendor - Id
                                                    </th>
                                                    <th>Booking Status
                                                    </th>
                                                    <th>Customer Name
                                                    </th>
                                                    <th>Check-in
                                                    </th>
                                                    <th>Check-out
                                                    </th>
                                                    <th>Booked On
                                                    </th>
                                                    <th>PAH Booking
                                                    </th>
                                                    <th>Room name (Rate Plan)
                                                    </th>
                                                    <th>No. of Rooms / Nights
                                                    </th>
                                                    <th>Extra Adult/Child Charges (B)
                                                    </th>
                                                    <th>Gross Payable (A+B+C-D)
                                                    </th>
                                                    <th>Amount collected from guest
                                                    </th>
                                                    <th>Hotel To pay to travinities
                                                    </th>
                                                    <th>Trav to pay to hotel
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <%#Eval("HotelName")%>
                                            </td>
                                            <td>
                                                <%#Eval("Booking Vendor") %> -  <%#Eval("BookingID") %>
                                            </td>
                                            <td>
                                                <%#Eval("Booking Status") %>
                                            </td>
                                            <td>
                                                <%#Eval("Customer Name") %>
                                            </td>
                                            <td>
                                                <%#Eval("Check-in") %>
                                            </td>
                                            <td>
                                                <%#Eval("Check-out") %>
                                            </td>
                                            <td>
                                                <%#Eval("Booked On") %>
                                            </td>
                                            <td>
                                                <%#Eval("PAH Booking") %>
                                            </td>
                                            <td>
                                                <%#Eval("Room name") %>
                                            </td>
                                            <td>
                                                <%#Eval("No of Rooms") %> / <%#Eval("No of Nights") %>
                                            </td>
                                            <td>
                                                <%#Eval("Extra Adult") %>
                                            </td>
                                            <td>
                                                <%#Eval("Gross Payable") %>
                                            </td>
                                            <td>
                                                <%#Eval("amount collected from guest") %>
                                            </td>
                                            <td>
                                                <%#Eval("Hotel To pay to travinities") %>
                                            </td>
                                            <td>
                                                <%#Eval("trav to pay to hotel") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody> </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- start js include path -->
        <script src="assets/plugins/jquery/jquery.min.js"></script>
        <script src="assets/plugins/popper/popper.min.js"></script>
        <script src="assets/plugins/jquery-blockui/jquery.blockui.min.js"></script>
        <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js"></script>
        <!-- bootstrap -->
        <script src="assets/plugins/bootstrap/js/bootstrap.min.js"></script>
        <!-- data tables -->
        <script src="assets/plugins/datatables/jquery.dataTables.min.js"></script>
        <script src="assets/plugins/datatables/plugins/bootstrap/dataTables.bootstrap4.min.js"></script>
        <!-- Common js-->
        <script src="assets/js/app.js"></script>
        <script src="assets/js/layout.js"></script>
        <script src="assets/js/theme-color.js"></script>
        <!-- Material -->
        <script src="assets/plugins/material/material.min.js"></script>
        <!-- animation -->
        <script src="assets/js/pages/ui/animations.js"></script>
        <%--
    <script src="https://code.jquery.com/jquery-3.3.1.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="https://cdn.datatables.net/1.10.19/js/dataTables.bootstrap4.min.js" type="text/javascript"></script>--%>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#example').DataTable();
            });


        </script>
        <script src="js/table2excel/jquery.table2excel.js"></script>
        <script type="text/javascript">
    $(function () {
        $("#btnExport").click(function () {
            $("#example").table2excel({
                filename: "Channel partner transection" + new Date().toISOString().replace(/[\-\:\.]/g, "") + ".xls"
            });
        });
    });
</script>
        <!-- end js include path -->
        --%>
    </form>
</body>
</html>
