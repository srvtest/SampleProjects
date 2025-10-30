<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="TermsConditionsMain.aspx.cs" Inherits="Guest_Reporting_System.TermsConditionsMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title>Terms & Conditions</title>
    <link rel="icon" type="image/png" href="New/assets/images/favicon-16x16.png" />
    <link href="newpanel/bower_components/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/bower_components/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/bower_components/ionicons/css/ionicons.min.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/dist/css/AdminLTE.css" rel="stylesheet" type="text/css" />
    <link href="newpanel/custom/customcolor.css" rel="stylesheet" type="text/css" />
    <!-- iCheck -->
    <link rel="stylesheet" href="newpanel/Plugins/iCheck/square/blue.css" />
    <link href="newpanel/dist/css/skins/skin-blue.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 9]>
       <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
       <script src="https://oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
     <![endif]-->
    <!-- Google Font -->

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <style>
        .li-item {
            text-decoration: none;
        }

        body {
            top: 0px !important;
        }

        .goog-logo-link {
            display: none !important;
        }

        .trans-section {
            margin: 100px;
        }

        .skiptranslate iframe {
            display: none !important;
        }

        .goog-te-gadget {
            color: transparent !important;
        }

        @media only screen and (min-width: 600px) {
            .register-box {
                width: 800px;
            }
        }
    </style>
</head>
<body id="pageBody" class="hold-transition login-page" style="width: 100%;">
    <form id="form1" runat="server">
        <div class="register-box">
            <div class="row" id="pnlUser">
                <!--Basic Form starts-->
                <div class="col-md-12 grid-margin stretch-card mx-auto">
                    <div class="box box-primary">
                        <div class="card-body">
                            <h4 class="box-header with-border">
                                <asp:Label ID="lbl4" runat="server">Welcome to GuestReport.in!</asp:Label>
                               <%-- <div style="float: right;margin-top:-10px;">
                                     <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClientClick="JavaScript:window.history.back(1); return false;"  />
                                </div>--%>
                            </h4>
                            <div class="box-body">
                                <div>
                                    <div class="row" runat="server" id="divSubmit">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label runat="server" id="lblmasg">These Terms and Conditions ("Terms") govern your use of the GuestReport.in website ("Website") and its services ("Services"). By accessing or using the Website, you agree to be bound by these Terms. Please read them carefully.</label>
                                                <ol type="1">
                                                    <li>Services</br>
                                                GuestReport.in provides a platform for hotels to submit guest information securely to police stations. We act as an intermediary, facilitating the transmission of data between hotels and law enforcement. 
                                                    </li>
                                                    <li>User Responsibilities
                                                 <ol type="2">
                                                     <li>Hotels</br>
         Data Accuracy: Hotels are solely responsible for ensuring the accuracy and validity of all guest information submitted through the Website. This includes verifying guest names, mobile numbers, and Aadhar details.
                                                         </br>
                                                         Data Ownership: Hotels retain ownership of the guest information they submit. GuestReport.in does not claim any ownership of this data.</br>
                                                         Prohibited Activities: You agree not to:
                                                         <ul style="list-style-type: none;">
                                                             <li>Hack, disrupt, or attempt to gain unauthorized access to the Website or its systems.</li>
                                                             <li>Submit false, misleading, or incomplete information.</li>
                                                             <li>Use the Website for any illegal or unlawful purpose.</li>
                                                             <li>Overload the Website with excessive data or requests.</li>
                                                         </ul>
                                                     </li>
                                                     <li>GuestReport.in
                                                         <ul style="list-style-type: none;">
                                                             <li>Data Security: GuestReport.in takes data security seriously. We employ encryption to protect guest information stored on our servers.</li>
                                                             <li>Data Retention: We will retain guest information for a period of 30 days after submission. After that, the data will be securely deleted.</li>
                                                             <li>Disclaimer of Liability: GuestReport.in is not responsible for the content or accuracy of guest information submitted by hotels. We are not liable for any misuse of such information by third parties.</li>
                                                         </ul>
                                                     </li>
                                                 </ol>
                                                    </li>
                                                    <li>Suspension and Termination</br>
                                                GuestReport.in reserves the right to suspend or terminate your access to the Website for any violation of these Terms.
                                                    </li>
                                                    <li>Modifications to Terms</br>
                                                We may revise these Terms at any time by updating this page. Your continued use of the Website after any such change constitutes your acceptance of the new Terms.
                                                    </li>
                                                    <li>Governing Law</br>
                                                These Terms shall be governed by and construed in accordance with the laws of India.
                                                    </li>
                                                    <li>Contact Us</br>
                                                 If you have any questions regarding these Terms, please contact us at [insert email address].</br>
                                                 Additional Terms</br>
                                                 <ul style="list-style-type: none;">
                                                     <li>You agree to indemnify and hold harmless GuestReport.in, its officers, directors, employees, and agents from any and all claims, losses, expenses, damages, and costs (including attorney's fees) arising from or relating to your use of the Website.</li>
                                                     <li>You agree that these Terms constitute the entire agreement between you and GuestReport.in regarding your use of the Website.</li>
                                                     <li>If any provision of these Terms is held to be invalid or unenforceable, such provision shall be struck and the remaining provisions shall remain in full force and effect.</li>
                                                 </ul>
                                                    </li>
                                                    <li>Compliance with IT Act 2001</br>
                                                 You agree to comply with all applicable provisions of the Information Technology Act, 2001 (IT Act) while using the Website. This includes:</br>
                                                 <ul style="list-style-type: none;">
                                                     <li>Reasonable Security Practices: You (hotels) are responsible for implementing reasonable security practices to protect guest information from unauthorized access, disclosure, modification, or destruction. </li>
                                                     <li>Consent for Data Collection:  Hotels must obtain explicit consent from guests before collecting and submitting their information through GuestReport.in. You are responsible for informing guests about how their data will be used and stored.</li>
                                                 </ul>
                                                    </li>
                                                    <li>Data Breach Notification</br>
                                                 In the event of a data breach involving guest information, GuestReport.in will notify the affected hotels and relevant authorities as per applicable data protection laws. Hotels are responsible for notifying their guests about the breach in a timely manner. 
                                                    </li>
                                                    <li>Dispute Resolution</br>
                                                 Any dispute arising out of or relating to these Terms or your use of the Website shall be subject to the exclusive jurisdiction of the courts located in [insert city, state].</br>
                                                 By using GuestReport.in, you acknowledge that you have read, understood, and agree to be bound by these Terms and Conditions.
                                                    </li>
                                                </ol>
                                            </div>
                                        </div>
                                    </div>
                                    <%--  <div class="row">
                            <div class="col-md-8">
                                <div class="form-group">
                                    <label runat="server" id="lblmasg">प्रमणित करता हु की इस रिपोर्ट में दी हुई जानकारी पूर्ण एवं सत्य है |</label>
                                    <label runat="server" id="lblData">मैं प्रमणित करता हु की इस रिपोर्ट में दी हुई जानकारी पूर्ण एवं सत्य है |</label>
                                </div>
                            </div>
                        </div>--%>
                                    <%--<div>
                                <asp:Button ID="Button4" runat="server" Text="ठीक है" class="btn btn-primary me-2" OnClick="Button4_Click" />
                            </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
