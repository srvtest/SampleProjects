<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="GuestDetails.aspx.cs" Inherits="Guest_Reporting_System.GuestDertails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table_container {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="doc floatbtn">
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
                <h5 runat="server">चेक इन तारीख : <span id="lblCheckIndate" runat="server"></span></h5>
                <h5 runat="server">चेक आउट तारीख : <span id="lblCheckOutdate" runat="server"></span></h5>
                <h5 runat="server">कुल व्यक्ति संख्या : <span id="lblTotalGuest" runat="server"></span></h5>
                <h5 runat="server">रिपोर्ट सबमिट : <span id="lblisSumbit" runat="server"></span></h5>
            </div>
        </div>
        <div class="box-body">
            <div class="row">
                <div class="col-md-12 table-responsive">
                    <asp:Repeater runat="server" ID="rptGuestDetailTbl">
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
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# Container.ItemIndex + 1 %></td>
                                <td><%#Eval("GuestName")%> <%#Eval("GuestLastName")%></td>
                                <td><%#Eval("gender")%></td>
                                <td><%#Eval("ContactNo")%></td>
                                <%-- <td><%#Eval("Address")%></td>--%>
                                <td><%#Eval("City")%></td>
                                <td><%#Eval("TravelReson")%></td>
                                <td><%#Eval("IdentificationType")%></td>
                                <td><%#Eval("IdentificationNo")%></td>
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
                    <asp:Repeater ID="rptDetail" runat="server" OnItemDataBound="rptDetail_ItemDataBound">
                        <ItemTemplate>
                            <div class="box box-primary" style="margin-left: 15px; margin-top: 30px;">
                                <div class="box-body box-profile" style="background-color: white;">
                                    <table class="table" style="width: 100%" id="example2">
                                        <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("idGuestMaster")%>' />
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
                    <%--  </div>
                    </div>--%>
                </div>
            </div>
        </div>
    </div>
    <script>
       <%-- function printDiv(divName) {
           var DocName = $("#<%=hdnDoc.ClientID%>").val();
             <%--var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            document.title = DocName;
            window.print();

            document.body.innerHTML = originalContents;
            //let div = document.querySelector("#ContentPlaceHolder1_printableArea");
            //html2pdf().from(div).save();
        }--%>
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
