<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="pendingReport.aspx.cs" Inherits="Guest_Reporting_System.pendingReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        @media (min-width: 768px) {
            .col-sm-11 {
                width: 97.666667%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="floatbtn">
        <asp:HiddenField ID="hdnDoc" runat="server" ClientIDMode="Static" Value="" />
        <%--<button class="btn btn-default" onclick="printDiv('printableArea')"><i class="fa fa-print" aria-hidden="true" style="font-size: 17px;">Print</i></button>--%>
        <span class="btn btn-info" style="margin-top: 5px; margin-right: 5px;">
            <i class="fa fa-download" aria-hidden="true" style="font-size: 17px;"></i>
            <input type="reset" onclick="HandleIT()" value="Download" style="border: none; background: none;" />
        </span>
    </div>
    <div id="printableArea" runat="server">
        <div class="row">
            <div class="col-md-12" style="text-align: center;">
                <h3 id="lblHotelName" runat="server"></h3>
                <h5 id="lblHotelAddress" runat="server"></h5>
                <h5 id="lblHotelContact" runat="server"></h5>
                <hr />
                <h4><b>
                    <center>अतिथि की जानकारी रिपोर्ट</center>
                </b></h4>
                <hr />
                <h5 runat="server">कुल अतिथि : <span id="lblTotalGuest" runat="server"></span></h5>
                <h5 runat="server">चेक इन की तारीख : <span id="lblCheckIndate" runat="server"></span></h5>
                <h5 runat="server">रिपोर्ट सबमिट : <span id="lblReportBy" runat="server"></span></h5>
            </div>
        </div>
        <div class="box-body">
            <div class="row">
                <div class="col-md-12 table-responsive">
                    <asp:Repeater runat="server" ID="rptGuestDetailTbl" OnItemDataBound="rptGuestDetailTbl_ItemDataBound" OnItemCommand="rptGuestDetailTbl_ItemCommand">
                        <HeaderTemplate>
                            <table class="table nowrap" style="width: 100%" id="example3">
                                <thead>
                                    <tr>
                                        <th>क्रम संख्‍या</th>
                                        <th>नाम</th>
                                        <th>जेंडर</th>
                                        <th>मोबाइल नंबर</th>
                                        <%-- <th>पता</th>--%>
                                        <th>शहर</th>
                                        <th>यात्रा का उद्देश्य</th>
                                        <th>आईडी प्रकार</th>
                                        <th>आईडी नंबर</th>
                                        <th></th>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex + 1 %></td>
                                <td><%#Eval("GuestName")%> <%#Eval("GuestLastName")%></td>
                                <td><%#Eval("gender")%></td>
                                <td><%#Eval("ContactNo")%></td>
                                <%--<td><%#Eval("Address")%></td>--%>
                                <td><%#Eval("City")%></td>
                                <td><%#Eval("TravelReson")%></td>
                                <td><%#Eval("IdentificationType")%></td>
                                <td><%#Eval("IdentificationNo")%></td>
                                <td>
                                    <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("idGuestMaster")%>' />
                                    <asp:HiddenField ID="hdnIdMain" runat="server" Value='<%#Eval("idMain")%>' />
                                    <asp:Literal ID="Literal1" runat="server" Text='<%#Eval("idMain")%>' Visible="false"></asp:Literal>
                                    <asp:Button ID="Button1" runat="server" Text="संपादित करें" CssClass="btn btn-primary HideButton" CommandName="Change" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
             <div style="break-after: page"></div>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-11 table-responsive">
                    <%-- <div class="box box-primary">
                        <div class="box-body box-profile">--%>
                    <asp:Repeater runat="server" ID="rptGuestDetail" OnItemDataBound="rptGuestDetail_ItemDataBound">
                        <ItemTemplate>
                            <div class="box box-primary" style="margin-left: 15px; margin-top: 30px;">
                                <div class="box-body box-profile" style="background-color: white;">
                                    <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("idGuestMaster")%>' />
                                    <table class="table" style="width: 100%" id="example2">
                                        <tr>
                                            <td>नाम : <%#Eval("GuestName")%> <%#Eval("GuestLastName")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>जेंडर : <%#Eval("gender")%>
                                        </tr>
                                        <tr>
                                            <td>आईडी प्रकार : <%#Eval("IdentificationType")%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>आईडी नंबर : <%#Eval("IdentificationNo")%>
                                            </td>
                                        </tr>
                                        <tr style="height: 450px;">
                                            <td>
                                                <span style="margin-right: 110px;">फ्रंटसाइड आईडी</span>
                                                <span style="margin-right: 110px;">
                                                    <asp:Image ID="Image1" runat="server" Width="350px" Height="350px" /></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span style="margin-right: 110px;">बैकसाइड आईडी</span>
                                                <span style="margin-right: 110px;">
                                                    <asp:Image ID="Image2" runat="server" Width="350px" Height="350px" /></span>
                                            </td>
                                        </tr>
                                    </table>
                                    <div style="break-after: page"></div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <%--   <FooterTemplate>
                                    <div style="break-after: page"></div>
                                </FooterTemplate>--%>
                    </asp:Repeater>
                    <%-- </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <script>
       <%-- var doc = new jsPDF();
        function printDiv(divName) {
            var DocName = $("#<%=hdnDoc.ClientID%>").val();
            var printContents = document.getElementById(divName).innerHTML;
            //alert(printContents);
            var originalContents = document.body.innerHTML;
            //alert(originalContents);
            document.body.innerHTML = printContents;
            $('.HideButton').hide();
            document.title = DocName;
             window.print();
            //doc.fromHTML(document.body.innerHTML);
            //doc.save(DocName +'.pdf');

            document.body.innerHTML = originalContents;
        }--%>


        //function saveDiv(divId) {
        //    doc.fromHTML(`<html><head><title></title></head><body>` + document.getElementById(divId).innerHTML + `</body></html>`);
        //    doc.save('div.pdf');
        //}
        function HandleIT() {
            /* alert("aa");*/
            var DocName = $("#<%=hdnDoc.ClientID%>").val();
            /*alert(DocName);*/
            let div = document.querySelector("#ContentPlaceHolder1_printableArea");
            //var printContents = document.getElementById("printableArea").innerHTML;
            html2pdf().from(div).set({ filename: DocName }).save();
        }
    </script>
</asp:Content>
