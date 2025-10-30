<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TermsConditions.aspx.cs" Inherits="Police_Station_Reporting_System.TermsConditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">महत्वपूर्ण नियम एवं शर्तें:</asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div>
                            <div class="row" runat="server" id="divSubmit">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <%--<label runat="server" id="lblmasg">GuestReport.in होटलों को अतिथि जानकारी को सुरक्षित रूप से पुलिस थानों तक पहुंचाने का डिजिटल प्लेटफॉर्म प्रदान करता है। हम एक मध्यस्थ के रूप में कार्य करते हैं, जो होटलों और पुलिस थानों  के बीच डेटा का संप्रेषण सुगम बनाते हैं।</label>
                                        <ol type="1">
                                            <li>एक बार रिपोर्ट सबमिट करने के बाद उस तारीख के लिए आप कोई एंट्री नहीं कर पाएंगे।</li>
                                            <li>इस पोर्टल पर आप एक महीने तक की पुरानी रिपोर्ट देख सकते हैं। अपने रिकॉर्ड के लिए आप समय-समय पर रिपोर्ट डाउनलोड कर सकते हैं।</li>
                                            <li>आप सिर्फ आज और कल के लिए ही चेक-इन की एंट्री कर सकते हैं।</li>
                                            <li>होटलों की जिम्मेदारी है कि वे वेबसाइट के माध्यम से सबमिट की गई सभी अतिथि जानकारी की सटीकता और वैधता सुनिश्चित करें। इसमें अतिथि के नाम, मोबाइल नंबर, और आधार विवरण की पुष्टि शामिल है।
GuestReport.in होटलों द्वारा सबमिट की गई अतिथि जानकारी की सामग्री या सटीकता के लिए जिम्मेदार नहीं है। </li>
                                            <li>विस्तृत नियम एवं शर्तों के लिए नियम एवं शर्तें पृष्ठ पर जाएं।</li>
                                        </ol>--%>
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
                        <div>
                            <asp:Button ID="Button4" runat="server" Text="ठीक है" class="btn btn-primary me-2" OnClick="Button4_Click" />
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
