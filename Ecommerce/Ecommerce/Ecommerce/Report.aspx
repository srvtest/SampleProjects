<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Ecommerce.Report" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.5/css/buttons.bootstrap4.min.css" />
    <!-- Custom styles for this page -->
     <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <link href="vendor/sumoselect.css" rel="stylesheet" />
    <style>
        .floatRight {
            float: right;
        }

        .fontcolour {
            color: red;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdReportId" runat="server" Value="0" />
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Report</h1>
        <p class="mb-4">Report description</p>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblConfig">
            <div class="card-header py-3">
                <%--<h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">Report Details</h6>--%>
                <asp:Label ID="lblStartDate" class="m-0 font-weight-bold text-primary" runat="server" Text="Start Date :"></asp:Label>
                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" ></asp:TextBox>
                <asp:Label ID="lblEndDate" class="m-0 font-weight-bold text-primary" runat="server" Text="End Date :"></asp:Label>
                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" ></asp:TextBox>
                <asp:Label ID="lblStatus" class="m-0 font-weight-bold text-primary" runat="server" Text="Status :"></asp:Label>
               <%-- <asp:DropDownList ID="ddlStatus" runat="server" CssClass="dropdown">
                    <asp:ListItem Text="Approve" Enabled="true" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Reject" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Shipped" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Delivered" Value="4"></asp:ListItem>
                </asp:DropDownList>--%>
                <asp:ListBox ID="lstStatus" runat="server" CssClass="dropdown" SelectionMode="Multiple">
                    <asp:ListItem Text="Approve" Enabled="true" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Reject" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Shipped" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Delivered" Value="4"></asp:ListItem>
                </asp:ListBox>
                <asp:Label ID="lblCountry" class="m-0 font-weight-bold text-primary" runat="server" Text="Country :"></asp:Label>
                 <asp:ListBox ID="lstCountry" runat="server" SelectionMode="Multiple">
                   <asp:ListItem Text="India" Enabled="true" Value="1"></asp:ListItem>
                    <asp:ListItem Text="USA" Value="2"></asp:ListItem>
                </asp:ListBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                <%-- <asp:Button ID="btnConfig" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnConfig_Click" />--%>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstReport" runat="server">
                        <HeaderTemplate>
                            <table class="table table-bordered table-striped" id="example" width="100%" cellspacing="0">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Name</th>
                                        <th>Date</th>
                                        <th>Status</th>
                                        <th>Country</th>
                                        <%-- <th>Action</th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" ClientIDMode="Static" Text='<%#Eval("RowNumber")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblName" runat="server" ClientIDMode="Static" Text='<%#Eval("sName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblValue" runat="server" ClientIDMode="Static" Text='<%#Eval("dtOrder")%>'></asp:Label>
                                </td>
                                <td>                                    
                                    <asp:Label ID="lblStatus" runat="server" ClientIDMode="Static" Text='<%#
                                         Convert.ToString(Eval("bStatus"))== "0" ? "Pending" :  
                                          Convert.ToString(Eval("bStatus"))== "1"? "Approved":
                                        Convert.ToString(Eval("bStatus"))== "2" ? "Reject":
                                        Convert.ToString(Eval("bStatus"))== "3" ? "Shipped":
                                        Convert.ToString(Eval("bStatus"))== "4" ? "Delivered": "User Cancel"                                      
                                        
                                        %>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCountry" runat="server" ClientIDMode="Static" Text='<%#Eval("Country")%>'></asp:Label>
                                </td>
                                <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idCustomerOrder") %>' />
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                                   <%-- <tfoot>
                                        <tr>
                                            <th>Name</th>
                                            <th>Salary</th>
                                        </tr>
                                    </tfoot>--%>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>

    <!-- Page level plugins -->


    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap4.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.5/js/dataTables.buttons.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.5/js/buttons.bootstrap4.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.5/js/buttons.html5.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.5/js/buttons.print.min.js"></script>
    <script src="https://cdn.datatables.net/buttons/1.6.5/js/buttons.colVis.min.js"></script>
   <%-- <script src="vendor/jquery/jquery.min.js"></script>--%>
    <script src="vendor/jquery.sumoselect.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            
            var table = $('#example').DataTable({
                lengthChange: false,
                buttons: ['copy', 'excel', 'pdf', 'print'],
                "pagingType": "full_numbers"
            });

            table.buttons().container()
                .appendTo('#example_wrapper .col-md-6:eq(0)');

            $(<%=lstStatus.ClientID%>).SumoSelect();
            $(<%=lstCountry.ClientID%>).SumoSelect();
           
        });

       

    </script>

</asp:Content>
