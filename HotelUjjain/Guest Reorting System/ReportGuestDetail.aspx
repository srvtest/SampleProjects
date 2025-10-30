<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="ReportGuestDetail.aspx.cs" Inherits="Guest_Reporting_System.ReportGuestDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src='../newpanel/bower_components/jquery/dist/jquery.min.js' type="text/javascript"></script>--%>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.10.1/html2pdf.bundle.min.js" integrity="sha512-GsLlZN/3F2ErC5ifS5QtgpiJtWd43JWSuIgh7mbzZ8zBps+dvLusV+eNQATqgA/HdeKFVgA5v3S/cIrLF7QnIg==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>--%>
    <style>
        @media (min-width: 768px) {
            .col-sm-11 {
                width: 97.666667%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
    <div class="floatbtn">
        <asp:HiddenField ID="hdnDoc" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnHotelId" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCheckInDate" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnHost" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnToEmailId" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnPassword" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnCon" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdnTotalGuest" runat="server" ClientIDMode="Static" />
        <%--<button class="btn btn-default" onclick="printDiv('printableArea')"><i class="fa fa-print" aria-hidden="true" style="font-size: 17px;">Print</i></button>--%>
        <span class="btn btn-info" style="margin-top: 5px; margin-right: 5px;">
            <i class="fa fa-download" aria-hidden="true" style="font-size: 17px;"></i>
            <input type="reset" onclick="Download()" value="Download" style="border: none; background: none;" />
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
                <h5 runat="server">रिपोर्ट सबमिट द्वारा : <span id="lblReportBy" runat="server"></span></h5>
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
                                        <%--  <th>पता</th>--%>
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
                    <asp:Repeater runat="server" ID="rptGuestDetail" OnItemDataBound="rptGuestDetail_ItemDataBound">
                        <ItemTemplate>
                            <div class="box box-primary" style="margin-left: 15px; margin-top: 30px; ">
                                <div class="card-body box-profile" style="background-color: white;">
                                    <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("idGuestMaster")%>' />
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Convert.ToString(((IList)((Repeater)Container.Parent).DataSource).Count)%>' />
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
                                        <tr style="height: 400px;">
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
                                </div>
                            </div>
                              <div id="hideContent" style="break-after: page" onclick="changeDivStyle(index)"></div>
                        </ItemTemplate>
                        <%-- <FooterTemplate>
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
        //function changeDivStyle(index) {
        //    // Construct the ID of the div.
        //    var divId = "itemDiv_" + index;
        //    alert(HiddenField1.val);
        //    // Get the div element by its ID.
        //    var divElement = document.getElementById(divId);

        //    // Check if the element exists.
        //    if (divElement) {
        //        // Change the background color and text color.
        //        divElement.style.backgroundColor = "lightblue";
        //        divElement.style.color = "darkblue";
        //        divElement.innerText = "This div was clicked!";
        //    }
        //}
       <%-- function printDiv(divName) {
            var DocName = $("#<%=hdnDoc.ClientID%>").val();
            var printContents = document.getElementById(divName).innerHTML;
            var originalContents = document.body.innerHTML;

            document.body.innerHTML = printContents;
            document.title = DocName;
            window.print();

            document.body.innerHTML = originalContents;
        }

        function SendEmailReport() {
           
        }--%>

        //$(document).ready(function () {

        //});
        function Download() {
            /* alert("aa");*/
            var DocName = $("#<%=hdnDoc.ClientID%>").val();
            /*alert(DocName);*/
            let div = document.querySelector("#ContentPlaceHolder1_printableArea");
            //var printContents = document.getElementById("printableArea").innerHTML;
            html2pdf().from(div).set({ filename: DocName }).save();
        }


    </script>


    <script type="text/javascript">  
        $(document).ready(function () {   //same as: $(function() {
            // alert("aaa");
            const searchParams = new URLSearchParams(window.location.search);
            var sendMail = searchParams.get('sendMail'); // price_descending
            //var PoliceStationEmailId = searchParams.get('PoliceStationEmailId');
            if (sendMail == '1') {
                //HandleIT(PoliceStationEmailId);
                HandleIT();
            }

            //let div = document.querySelector("#ContentPlaceHolder1_printableArea");
            //html2pdf().from(div).save()

            //const pdfBlob = await html2pdf().from(div).outputPdf();
            ////const pdfBlob = await html2pdf(content).outputPdf();
            //const arrayBuffer = await new Response(pdfBlob).arrayBuffer();
            //const base64String = btoa(new TextDecoder().decode(arrayBuffer));



        });
        function HandleIT() {


            var DocName = $("#<%=hdnDoc.ClientID%>").val();
                                    var Id = $("#<%=hdnHotelId.ClientID%>").val();
                                    var CheckInDate = $("#<%=hdnCheckInDate.ClientID%>").val();
                                    var Host = $("#<%=hdnHost.ClientID%>").val();
                                    var FromEmailId = $("#<%=hdnToEmailId.ClientID%>").val();
                                    var Password = $("#<%=hdnPassword.ClientID%>").val();
                                    var Con = $("#<%=hdnCon.ClientID%>").val();
            let div = document.querySelector("#ContentPlaceHolder1_printableArea");
            //html2pdf().from(div).save();

            html2pdf().from(div).outputPdf().then(function (pdf) {
                // This logs the right base64
                //alert(btoa(pdf));
                var base64String = btoa(pdf);
                //var base64String = base64String.substring(0, base64String.length-1);
                $.ajax({
                    type: "POST",
                    url: '/DocName.aspx/EmailReport',
                    data: "{'base64String' : '" + base64String + "','DocName' : '" + DocName + "','HotelId' : '" + Id + "', 'CheckInDate': '" + CheckInDate + "', 'Host': '" + Host + "', 'FromEmailId': '" + FromEmailId + "', 'Password': '" + Password + "', 'Con': '" + Con + "'}",
                    headers: {
                        "Content-Type": "application/json; charset=utf-8",
                        "Content-Length": base64String.length
                    },
                    success: function (data) {
                        console.log(data);
                    },
                    failure: function (response) {
                        alert(response.d);
                    }
                });
            });
            //const pdfBlob = html2pdf().from(div).outputPdf();
            //alert('A2');
            ////const pdfBlob = await html2pdf(content).outputPdf();
            //const arrayBuffer =  new Response(pdfBlob).arrayBuffer();
            //const base64String = btoa( TextDecoder().decode(arrayBuffer));
            //$.ajax({
            //    type: "POST",
            //    url: '/WebData.aspx/EmailReport',
            //    data: "{base64String: '" + base64String + "',DocName:'" + DocName + "' }",
            //    contentType: "application/json; charset=utf-8",
            //    success: function (data) {
            //        console.log(data);
            //    },
            //    failure: function (response) {
            //        alert(response.d);
            //    }
            //});
        }
    </script>
</asp:Content>
