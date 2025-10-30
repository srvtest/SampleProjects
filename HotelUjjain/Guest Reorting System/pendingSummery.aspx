<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="pendingSummery.aspx.cs" Inherits="Guest_Reporting_System.pendingSummery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      /*  .btnAction {
            margin-top: 5px;
        }

        .btnGuest {
            width: 192px;
        }*/

        .lblCtrl {
            text-align: center;
            display: block;
        }

        .vbnpage {
            background: #ffffff;
            /*  background: url(NewPanel/dist/schoolbg.jpg) no-repeat;
            background-size: cover;*/
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">अभी तक पुलिस स्टेशन में सबमिट नहीं हुई पेंडिंग चेक-इन रिपोर्ट</asp:Label>
                        <%-- <div style="float: right">
                            <asp:Button ID="btnAddGuest" runat="server" Text="रिपोर्ट में गेस्ट जोड़े" class="btn btn-primary me-2" OnClick="btnAddGuest_Click" />
                            <asp:Button ID="btnSubmitReport" runat="server" Text="रिपोर्ट सबमिट" class="btn btn-primary me-2" OnClick="btnSubmitReport_Click" />
                        </div>--%>
                    </h4>
                    <p class="box-header">
                        <asp:Label ID="Label2" runat="server" CssClass="lblCtrl"><b>|| कृपया ध्यान दें ||</b></asp:Label>
                        <ol class="olul" type="1">
                            <li>एक बार रिपोर्ट थाने में सबमिट करने के बाद उस तारीख के लिए आप कोई नए गेस्ट की एंट्री नहीं कर पाएंगे।</li>
                            <li>GuestReport.in होटलों द्वारा सबमिट की गई अतिथि जानकारी की सामग्री या सटीकता के लिए जिम्मेदार नहीं है।</li>
                        </ol>
                    </p>
                    <hr />
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptGuest" runat="server" OnItemCommand="rptGuest_ItemCommand" OnItemDataBound="rptGuest_ItemDataBound">
                                    <HeaderTemplate>
                                        <table class="table table-striped nowrap" style="width: 100%" id="example4">
                                            <thead>
                                                <tr>
                                                    <th>क्रम संख्‍या</th>
                                                    <th>चेक इन तारीख</th>
                                                    <th>कुल अतिथि</th>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %>
                                                <asp:HiddenField ID="hdnsubmitDate" runat="server" Value='<%#Eval("SubmitDate")%>' />
                                                <asp:HiddenField ID="hdnEmailId" runat="server" Value='<%#Eval("PoliceStationEmailId")%>' />
                                            </td>
                                            <td>
                                                <%#Convert.ToDateTime(Eval("SubmitDate")).ToString("dd-MMM-yyyy")%>
                                            </td>
                                            <td><%#Eval("AddionalGuest")%></td>
                                            <td>
                                                <asp:Button ID="btnDetails" runat="server" Text="जानकारी देखें" CssClass="btn btn-primary btnGuest" CommandName="Details" />
                                                <%--  <a href="AddGuest.aspx" id="" style="margin-left:10px;" class="btn btn-primary">रिपोर्ट में गेस्ट जोड़े</a>--%>
                                                <%-- </td>
                                            <td>--%>
                                                <asp:Button ID="Button2" runat="server" Text="रिपोर्ट में गेस्ट जोड़े" CssClass="btn btn-primary btnAction" Style="margin-left: 10px;" OnClick="btnAddGuest_Click" />
                                                <%--</td>
                                            <td>--%>
                                                <asp:Button ID="Button1" runat="server" Text="रिपोर्ट सबमिट" CssClass="btn btn-primary btnAction" Style="margin-left: 10px;" CommandName="Submit" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                            </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

