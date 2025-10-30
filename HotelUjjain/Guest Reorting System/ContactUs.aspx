<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="Guest_Reporting_System.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">हमसे संपर्क करें</asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div>
                            <div class="row" runat="server" id="divSubmit">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label runat="server" id="lblmasg">किसी भी प्रकार की सहायता के लिए आप हमें निम्न नंबर पर संपर्क कर सकते हैं:</label>
                                        <p><label runat="server" class="fa fa-phone" id="Label1"><a href="tel://8989006759"> 8989006759</a></label></p>
                                         <p><label runat="server" id="Label2">(सुबह 10 से शाम 6 बजे, सोमवार से शनिवार)।</label></p>
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
