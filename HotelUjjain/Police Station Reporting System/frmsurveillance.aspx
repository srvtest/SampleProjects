<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="frmsurveillance.aspx.cs" Inherits="Police_Station_Reporting_System.frmsurveillance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btnGuest {
            width: 98px;
        }
        .modalignCtrl{
            align-content:center;
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
                        <asp:HiddenField ID="hdnSurveillanceId" runat="server" />
                        <asp:HiddenField ID="hdnsurveillanceDetail" runat="server" />
                        <asp:HiddenField ID="hdnidUser" runat="server" />
                        <asp:HiddenField ID="hdnsType" runat="server" />
                        <asp:Label ID="lbl4" runat="server">किसी आईडी जैसे आधार कार्ड या मोबाइल नंबर को निगरानी में जोड़ें।</asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>आईडी प्रकार <span class="text-danger">*</span></label>
                                    <asp:DropDownList ID="ddlIDType" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="myFunction()">
                                        <asp:ListItem Text="आधार कार्ड"></asp:ListItem>
                                       <%-- <asp:ListItem Text="ड्राइविंग लाइसेंस"></asp:ListItem>--%>
                                        <asp:ListItem Text="मोबाइल नंबर"></asp:ListItem>
                                        <%--                                        <asp:ListItem Text="पासपोर्ट"></asp:ListItem>
                                        <asp:ListItem Text="वोटर आईडी कार्ड"></asp:ListItem>--%>

                                        <%--<asp:ListItem Text="पैन कार्ड"></asp:ListItem>
                                        <asp:ListItem Text="राशन कार्ड"></asp:ListItem>
                                        <asp:ListItem Text="सरकारी कर्मचारी पहचान पत्र"></asp:ListItem>
                                        <asp:ListItem Text="विदेशियों का पंजीकरण कार्ड (FRC)"></asp:ListItem>
                                        <asp:ListItem Text="कोई अन्य सरकारी जारी किया गया पहचान पत्र"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5_1" ControlToValidate="ddlIDType" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter Identification Type."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>निगरानी के लिए नंबर जोड़ें </label>
                                    <span style="position: relative;">
                                        <asp:TextBox ID="txtSurveillanceNo" CssClass="form-control" runat="server"></asp:TextBox>
                                        <img src="NewPanel/images/download.png" id="validImage" width="20" style="position: absolute; right: 5px; top: 30px; display: none;" />
                                    </span>
                                    <asp:CustomValidator ID="CustomValidator3" runat="server"
                                        ForeColor="Red"
                                        ControlToValidate="txtSurveillanceNo"
                                        ClientValidationFunction="checkValidation"></asp:CustomValidator>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSurveillanceNo" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please enter Identification No."></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-1">
                                <div class="form-group" style="padding-top: 25px;">
                                    <asp:Button ID="btnSearch" runat="server" Text="जोड़ें" CssClass="btn btn-primary me-2" OnClick="btnAddSurveillance_Click" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>पहले से मौजूदा आईडी/नंबर को सर्च करे</label>
                                    <span style="position: relative;">
                                        <asp:TextBox ID="txtSurveillanceId" CssClass="form-control" runat="server"></asp:TextBox>
                                    </span>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group" style="padding-top: 25px;">
                                    <asp:Button ID="btnSurveillanceSearch" runat="server" Text="सर्च करे" CssClass="btn btn-primary me-2" OnClick="btnSurveillanceSearch_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptSurveillance" runat="server" OnItemCommand="rptSurveillance_ItemCommand" OnItemDataBound="rptSurveillance_ItemDataBound">
                                    <HeaderTemplate>
                                        <table id="example4" class="table table-bordered table-striped nowrap" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>S. No.</th>
                                                    <th>पुलिस स्टेशन का नाम</th>
                                                    <th>आईडी का प्रकार</th>
                                                    <th>आईडी/मोबाइल नंबर</th>
                                                    <%-- <th>Type</th>--%>
                                                    <th>एंट्री प्राप्त हुई  (हां/नहीं)</th>
                                                    <th>कार्रवाई</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %>
                                                <asp:HiddenField ID="hdnIdSurveillance" runat="server" Value='<%#Eval("idSurveillance")%>' />
                                                <asp:HiddenField ID="hdnIsTrace" runat="server" Value='<%#Eval("isTrace")%>' />
                                                <asp:HiddenField ID="hdnType" runat="server" Value='<%#Eval("sType")%>' />
                                            </td>
                                            <td><%#Eval("sName")%></td>
                                            <td><%#Eval("sType")%></td>
                                            <td><%#Eval("surveillanceDetail")%></td>
                                            <%-- <td><%#Eval("sType")%></td>--%>
                                            <td><%#(Convert.ToString(Eval("isTrace"))=="True" ? "हाँ" :"नहीं")%></td>
                                            <td>
                                                <asp:Button ID="Button1" runat="server" Text="जानकारी देखें" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Details" />
                                                <%-- <asp:Button ID="Button2" runat="server" Text="अपडेट करें" class="btn btn-primary waves-effect waves-light" data-toggle="tooltip" data-placement="top" title=".icofont-home " CommandName="Update" />--%>
                                                <asp:Button ID="Button4" runat="server" Text="हटाएँ" class="btn btn-primary waves-effect waves-light btnGuest" data-toggle="tooltip" CommandName="Delete" />
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
    <%--   <div class="card">
        <div class="card-header">
            <h3 class="card-title">Surveillance details</h3>
        </div>
        <!-- /.card-header -->
    </div>--%>

    <%--  <div class="card">
        <!-- /.card-header -->
        <div class="card-body">
        </div>
        <!-- /.card-body -->
    </div>--%>
    <div class="modal fade modalignCtrl" id="saveModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel" style="text-align: center;">Save Records</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>
                    <span runat="server" id="lblMessage1"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <%--<a href="frmsurveillance.aspx" class="btn btn-primary me-2">रद्द करें</a>--%>
                    <asp:Button ID="Button3" runat="server" Text="ठीक है" class="btn btn-primary me-2" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade modalignCtrl" id="saveModal1" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel1" style="text-align: center;">Save Records</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>निगरानी के लिए नंबर जोड़ा दिया है | आप अन्य निगरानी के लिए नंबर ऐड कर सकते है  
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <a href="frmsurveillance.aspx" class="btn btn-primary me-2">ठीक है</a>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade modalignCtrl" id="saveModal2" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel2" style="text-align: center;">प्रश्न</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>क्या आप निगरानी में मौजूद आईडी/मोबाइल नंबर हटाना चाहते हैं ?
            
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <a href="frmsurveillance.aspx" class="btn btn-danger me-2">रद्द करें</a>
                    <asp:Button ID="Button2" runat="server" Text="पुष्टि करें" class="btn btn-success me-2" OnClick="Button2_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalignCtrl" id="saveModal3" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel3" style="text-align: center;">रिकॉर्ड हटाएं</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>कृपया ध्यान दें, आपके आईडी/मोबाइल नंबर को सर्वेलेंस में से हटा रहे हैं।               
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <a href="frmsurveillance.aspx" class="btn btn-primary me-2">ठीक है</a>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalignCtrl" id="saveModal4" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel4" style="text-align: center;">प्रश्न</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><%--क्या आप आईडी/मोबाइल नंबर को निगरानी में जोडना चाहते हैं ?      --%>
                    <span runat="server" id="Span2"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <a href="frmsurveillance.aspx" class="btn btn-danger me-2">रद्द करें</a>
                    <asp:Button ID="Button5" runat="server" Text="पुष्टि करें" class="btn btn-success me-2" OnClick="Button5_Click" />
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalignCtrl" id="saveModal5" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel5" style="text-align: center;">Save Records</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>
                    <span runat="server" id="Span1"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <%--<a href="frmsurveillance.aspx" class="btn btn-primary me-2">रद्द करें</a>--%>
                    <%-- <asp:Button ID="Button6" runat="server" Text="ठीक है" class="btn btn-primary me-2" />--%>
                    <a href="frmsurveillance.aspx" class="btn btn-primary me-2">ठीक है</a>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript"> 
        function QuestionSaveData() {
            if (Page_ClientValidate()) {
                $('#saveModal4').modal('show');
                return false;
            }
            return true;
        }
        function SaveGuestData() {
            $('#saveModal').modal('show');
            return false;
        }
        function saveData() {
            $('#saveModal1').modal('show');
            return false;
        }
        function QuestionDeleteData() {
            if (Page_ClientValidate()) {
                $('#saveModal2').modal('show');
                return false;
            }
            return true;
        }
        function DeleteData() {
            $('#saveModal3').modal('show');
            return false;
        }
        function surveillanceData() {
            $('#saveModal5').modal('show');
            return false;
        }
        function checkValidation(source, arguments) {
            $('#validImage').hide();
            arguments.IsValid = false;
            var valid = $("#<%=ddlIDType.ClientID%> option:selected").text();
            var vaLUE = $("#<%=txtSurveillanceNo.ClientID%>").val();
            switch (valid) {
                case "आधार कार्ड":
                    var re = new RegExp('^[2-9 ]{1}[0-9 ]{3}[0-9 ]{4}[0-9 ]{4}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना आधार कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षर डालें।');
                    }
                    break;
                case "ड्राइविंग लाइसेंस":
                    var re = new RegExp('^(([A-Z ]{2}[0-9 ]{2})( )|([A-Z ]{2}-[0-9 ]{2}))((19|20)[0-9 ][0-9 ])[0-9 ]{7}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना ड्राइविंग लाइसेंस नंबर जांचें। कृपया केवल अंग्रेजी अक्षर डालें।');
                    }
                    break;
                case "पासपोर्ट":
                    var re = new RegExp('^(?!^0+$)[a-zA-Z0-9 ]{3,20}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना पासपोर्ट नंबर जांचें। कृपया केवल अंग्रेजी अक्षर डालें।');
                    }
                    break;
                case "वोटर आईडी कार्ड":
                    var re = new RegExp('^[A-Z ]{3}[0-9 ]{7}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना वोटर आईडी कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षर डालें।');
                    }
                    break;
                case "पैन कार्ड":
                    var re = new RegExp('^[A-Z ]{5}[0-9 ]{4}[A-Z ]{1}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना पैन कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षर डालें।');
                    }
                    break;
                case "मोबाइल नंबर":
                    var re = new RegExp('^[0-9 ]{10}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना मोबाइल नंबर जांचें। कृपया केवल अंग्रेजी अक्षर डालें।');
                    }
                    break;
                //case "राशन कार्ड":
                //    var re = new RegExp('^(([A-Z]{2}[0-9]{2})( )|([A-Z]{2}-[0-9]{2}))((19|20)[0-9][0-9])[0-9]{7}$');
                //    var check = re.test(vaLUE);
                //    if (check) {
                //        arguments.IsValid = true;
                //        return true;
                //    }
                //    else {
                //        $(source).text('अपना राशन कार्ड जांचें');
                //    }
                //    break;
                default:
                    //var re = new RegExp('^[a-zA-Z0-9]{5}$');
                    //var check = re.test(vaLUE);
                    //if (check) {
                    //    $('#validImage').show();
                    //    arguments.IsValid = true;
                    //    return true;
                    //}
                    //else {
                    //    $(source).text('कृपया वैध आईडी दर्ज करें');
                    //}
                    break;
                // code block
            }
            arguments.IsValid = false;
            return false;
        }
        function myFunction() {
            Page_ClientValidate();
        }
    </script>


</asp:Content>


