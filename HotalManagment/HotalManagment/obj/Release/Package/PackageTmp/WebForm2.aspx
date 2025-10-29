<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="HotalManagment.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta name="description" content="Responsive Admin Template" />
    <meta name="author" content="SmartUniversity" />
    <title>Spice Hotel | Bootstrap 4 Admin Dashboard Template + UI Kit</title>
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
</head>
<body>
    <form id="form1" runat="server">
    <div class="page-wrapper">
        <!-- start page container -->
        <div class="page-container">
            <div class="page-content-wrapper">
                <div>
                    <div class="page-bar">
                        <div class="page-title-breadcrumb">
                            <div class=" pull-left">
                                <div class="page-title">
                                    Table With Javascript Data</div>
                            </div>
                            <ol class="breadcrumb page-breadcrumb pull-right">
                                <li><i class="fa fa-home"></i>&nbsp;<a class="parent-item" href="index.html">Home</a>&nbsp;<i
                                    class="fa fa-angle-right"></i> </li>
                                <li><a class="parent-item" href="#">Tables</a>&nbsp;<i class="fa fa-angle-right"></i>
                                </li>
                                <li class="active">Table With Data</li>
                            </ol>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <div class="card card-box">
                                <div class="card-head">
                                    <header>Javascript sourced data</header>
                                    <div class="tools">
                                        <a class="fa fa-repeat btn-color box-refresh" href="javascript:;"></a><a class="t-collapse btn-color fa fa-chevron-down"
                                            href="javascript:;"></a><a class="t-close btn-color fa fa-times" href="javascript:;">
                                            </a>
                                    </div>
                                </div>
                                <div class="card-body ">
                                    <table id="dataTable" class="display full-width">
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- end page content -->
        </div>
        <!-- end page container -->
        <!-- start footer -->
        <div class="page-footer">
            <div class="page-footer-inner">
                2018 &copy; Spice Hotel Template By <a href="mailto:redstartheme@gmail.com" target="_top"
                    class="makerCss">RedStar Theme</a>
            </div>
            <div class="scroll-to-top">
                <i class="icon-arrow-up"></i>
            </div>
        </div>
        <!-- end footer -->
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
    <!-- end js include path -->
    <script type="text/javascript">
        $(document).ready(function () {

            var dataSet = [
                   ["Tiger Nixon", "System Architect", "Edinburgh", "5421", "2011/04/25", "$320,800"],
                   ["Garrett Winters", "Accountant", "Tokyo", "8422", "2011/07/25", "$170,750"],
                   ["Ashton Cox", "Junior Technical Author", "San Francisco", "1562", "2009/01/12", "$86,000"],
                   ["Cedric Kelly", "Senior Javascript Developer", "Edinburgh", "6224", "2012/03/29", "$433,060"],
                   ["Airi Satou", "Accountant", "Tokyo", "5407", "2008/11/28", "$162,700"],
                   ["Brielle Williamson", "Integration Specialist", "New York", "4804", "2012/12/02", "$372,000"],
                   ["Herrod Chandler", "Sales Assistant", "San Francisco", "9608", "2012/08/06", "$137,500"],
                   ["Rhona Davidson", "Integration Specialist", "Tokyo", "6200", "2010/10/14", "$327,900"],
                   ["Colleen Hurst", "Javascript Developer", "San Francisco", "2360", "2009/09/15", "$205,500"],
                   ["Sonya Frost", "Software Engineer", "Edinburgh", "1667", "2008/12/13", "$103,600"],
                   ["Jena Gaines", "Office Manager", "London", "3814", "2008/12/19", "$90,560"],
                   ["Quinn Flynn", "Support Lead", "Edinburgh", "9497", "2013/03/03", "$342,000"],
                   ["Charde Marshall", "Regional Director", "San Francisco", "6741", "2008/10/16", "$470,600"],
                   ["Haley Kennedy", "Senior Marketing Designer", "London", "3597", "2012/12/18", "$313,500"],
                   ["Tatyana Fitzpatrick", "Regional Director", "London", "1965", "2010/03/17", "$385,750"],
                   ["Michael Silva", "Marketing Designer", "London", "1581", "2012/11/27", "$198,500"],
                   ["Paul Byrd", "Chief Financial Officer (CFO)", "New York", "3059", "2010/06/09", "$725,000"],
                   ["Gloria Little", "Systems Administrator", "New York", "1721", "2009/04/10", "$237,500"],
                   ["Bradley Greer", "Software Engineer", "London", "2558", "2012/10/13", "$132,000"],
                   ["Dai Rios", "Personnel Lead", "Edinburgh", "2290", "2012/09/26", "$217,500"],
                   ["Jenette Caldwell", "Development Lead", "New York", "1937", "2011/09/03", "$345,000"],
                   ["Yuri Berry", "Chief Marketing Officer (CMO)", "New York", "6154", "2009/06/25", "$675,000"],
                   ["Caesar Vance", "Pre-Sales Support", "New York", "8330", "2011/12/12", "$106,450"],
                   ["Doris Wilder", "Sales Assistant", "Sidney", "3023", "2010/09/20", "$85,600"],
                   ["Angelica Ramos", "Chief Executive Officer (CEO)", "London", "5797", "2009/10/09", "$1,200,000"],
                   ["Gavin Joyce", "Developer", "Edinburgh", "8822", "2010/12/22", "$92,575"],
                   ["Jennifer Chang", "Regional Director", "Singapore", "9239", "2010/11/14", "$357,650"],
                   ["Brenden Wagner", "Software Engineer", "San Francisco", "1314", "2011/06/07", "$206,850"],
                   ["Fiona Green", "Chief Operating Officer (COO)", "San Francisco", "2947", "2010/03/11", "$850,000"],
                   ["Shou Itou", "Regional Marketing", "Tokyo", "8899", "2011/08/14", "$163,000"],
                   ["Michelle House", "Integration Specialist", "Sidney", "2769", "2011/06/02", "$95,400"],
                   ["Suki Burks", "Developer", "London", "6832", "2009/10/22", "$114,500"],
                   ["Prescott Bartlett", "Technical Author", "London", "3606", "2011/05/07", "$145,000"],
                   ["Gavin Cortez", "Team Leader", "San Francisco", "2860", "2008/10/26", "$235,500"],
                   ["Martena Mccray", "Post-Sales support", "Edinburgh", "8240", "2011/03/09", "$324,050"],
                   ["Unity Butler", "Marketing Designer", "San Francisco", "5384", "2009/12/09", "$85,675"]
               ];

            $('#dataTable').DataTable({
                "scrollX": true
                ,
                data: dataSet,
                columns: [
		            { title: "Name" },
		            { title: "Position" },
		            { title: "Office" },
		            { title: "Extn." },
		            { title: "Start date" },
		            { title: "Salary" }
		        ]
            });


        });
    </script>
    </form>
</body>
</html>
