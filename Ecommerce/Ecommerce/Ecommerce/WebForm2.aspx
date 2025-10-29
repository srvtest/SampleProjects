<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Ecommerce.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
   <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css" />
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/buttons/1.6.5/css/buttons.bootstrap4.min.css" />
    <!-- Custom styles for this page -->
    <%--   <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">--%>
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">


    <link href="vendor/sumoselect.css" rel="stylesheet" />
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
    <asp:ListBox ID="lstStatus" runat="server" CssClass="dropdown" SelectionMode="Multiple">
                    <asp:ListItem Text="Approve" Enabled="true" Value="1"></asp:ListItem>
                    <asp:ListItem Text="Reject" Value="2"></asp:ListItem>
                    <asp:ListItem Text="Pending" Value="0"></asp:ListItem>
                    <asp:ListItem Text="Shipped" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Delivered" Value="4"></asp:ListItem>
                </asp:ListBox>
    </div></div>
     <script src="vendor/jquery.sumoselect.min.js"></script>
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
    <script type="text/javascript">
        $(document).ready(function () {
            $(<%=lstStatus.ClientID%>).SumoSelect();
          
        });
    </script>
   


    
    
   
    
    
    
    
    
    
    

</asp:Content>
