<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="ZeroCheckIn.aspx.cs" Inherits="Guest_Reporting_System.ZeroCheckIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .lblCtrl {
            text-align: center;
            display: block;
        }

        .olul {
            margin-left: -17px;
            margin-right: 9px;
        }

        @media only screen and (min-width: 600px) {
            .login-box-body {
                width: 410px;
            }

            .olul {
                margin-left: 0px;
                margin-right: 0px;
            }
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
                        <asp:Label ID="lbl4" runat="server">जीरो चेक इन रिपोर्ट</asp:Label>
                        <%--<div style="float: right">
         <asp:Button ID="btnsearch" runat="server" Text="सर्च गेस्ट" class="btn btn-primary me-2" OnClick="btnsearch_Click" />
     </div>--%>
                    </h4>
                    <p class="box-header">
                        <asp:Label ID="Label2" runat="server" CssClass="lblCtrl"><b>|| कृपया ध्यान दें ||</b></asp:Label></br>
                         <ol class="olul" type="1">
                             <li>अगर कल आपकी प्रॉपर्टी में कोई चेक इन नहीं हुआ है, तो आप यहाँ से जीरो चेक इन रिपोर्ट को पुलिस स्टेशन में सबमिट कर सकते हैं।</li>
                             <li>अगर आप कल की चेक इन रिपोर्ट पहले ही सबमिट कर चुके हैं, तो यह विकल्प आपके लिए डिसेबल  रहेगा ।</li>
                             <li>अगर पेंडिंग रिपोर्ट सेक्शन में कल की तारीख की कोई चेक इन रिपोर्ट है, तो यह विकल्प आपके लिए डिसेबल  रहेगा ।</li>
                         </ol>
                    </p>
                    <hr />
                    <div class="box-body">
                        <div>
                            <div class="row" runat="server" id="divSubmit">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <%--<asp:CheckBox ID="ckhIsAllow" runat="server" />      --%>
                                        <asp:TextBox ID="txtName" placeholder="रिपोर्ट बनाने वाले का नाम" runat="server"></asp:TextBox></br>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया नाम दर्ज करें।"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtName" ErrorMessage="कृपया नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[A-Za-z ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-8">
                                    <div class="form-group">
                                        <label runat="server" id="lblmasg">प्रमाणित करता हूँ की इस रिपोर्ट में दी हुई जानकारी पूर्ण एवं सत्य है |</label>
                                        <label runat="server" id="lblData">मैं प्रमाणित करता हूँ की इस रिपोर्ट में दी हुई जानकारी पूर्ण एवं सत्य है |</label>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <asp:Button ID="Button1" runat="server" Text="पुष्टि करें और सबमिट करें" class="btn btn-primary me-2" OnClientClick="return myFunction();" OnClick="Button1_Click" />
                                <asp:Button ID="Button4" runat="server" Text="ठीक है" class="btn btn-primary me-2" OnClick="Button4_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade modalign" id="saveCompleteModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel" style="text-align: center;">कृपया ध्यान दे</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>आप <span id="spDate" runat="server"></span>के लिए गेस्ट रिपोर्ट को सबमिट कर रहे है | एक बार रिपोर्ट सबमिट होने के बाद आप उसमे किसी भी तरह का चेंज नहीं कर सकते है और नहीं <span id="spDateN" runat="server"></span>के लिए आप फिर से रिपोर्ट सबमिट कर पाएंगे | 
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <asp:Button ID="btnSubmitReport" runat="server" Text="रिपोर्ट सबमिट करें" class="btn btn-success me-2" OnClick="btnSubmitReport_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalign" id="saveCompleteSubmitModal" tabindex="-1" aria-labelledby="saveModalSubmitLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalSubmitLabel" style="text-align: center;">रिपोर्ट सबमिट</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>धन्यवाद आपकी <span id="SpDateCom" runat="server"></span>की गेस्ट रिपोर्ट सबमिट हो गयी है  
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <asp:Button ID="Button2" runat="server" Text="होम पेज पर जाएं" class="btn btn-info me-2" OnClick="Button2_Click" />
                    <%--<asp:Button ID="Button3" runat="server" Text="रिपोर्ट डाउनलोड करें" class="btn btn-success me-2" OnClick="btnReport_Click" />--%>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function SaveGuestData() {
            if (Page_ClientValidate()) {
                $('#saveCompleteModal').modal('show');
                return false;
            }
            return true;
        }
        function SaveGuestDataCom() {
            if (Page_ClientValidate()) {
                $('#saveCompleteSubmitModal').modal('show');
                return false;
            }
            return true;
        }
        function myFunction() {
            Page_ClientValidate();
            //Validate();
        }
    </script>
</asp:Content>
