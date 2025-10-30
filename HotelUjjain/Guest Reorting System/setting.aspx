<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="Guest_Reporting_System.setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /*  .btnAction {
            margin-top: 5px;
        }

        .btnGuest {
            width: 192px;
        }*/
        .modalign {
            align-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdidHotelRoomCategory" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdisDeleted" runat="server" ClientIDMode="Static" />
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">Profile</asp:Label>
                        <div style="float: right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClick="btnCancel_Click" />
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">होटल  का नाम</label>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="होटल  का नाम" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="txtName" ErrorMessage="कृपया होटल का नाम दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hdnHotelNewId" runat="server"></asp:HiddenField>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">होटल  का पता</label>
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="होटल  का पता" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" runat="server" ControlToValidate="txtAddress" ErrorMessage="कृपया होटल का पता दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">रजिस्टर मोबाइल नंबर</label>
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="होटल मालिक का मोबाइल नंबर" Enabled="false"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtContact" ForeColor="Red"
                                        ErrorMessage="अमान्य मोबाइल नंबर।"
                                        ValidationExpression="^([0-9]{10})$">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="fontcolour" runat="server" ControlToValidate="txtContact" ErrorMessage="कृपया संपर्क नंबर दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">होटल मालिक का नाम</label>
                                    <asp:TextBox ID="txtContactPerson" runat="server" CssClass="form-control" placeholder="होटल मालिक का नाम" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="fontcolour" runat="server" ControlToValidate="txtContactPerson" ErrorMessage="कृपया संपर्क व्यक्ति दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">होटल मेल आईडी </label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="होटल मेल आईडी " Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="fontcolour" runat="server" ControlToValidate="txtEmail" ErrorMessage="कृपया ईमेल दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>होटल वेबसाइट </label>
                                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control form-control-lg border-left-0" placeholder="Contact Person" Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="fontcolour" runat="server" ControlToValidate="txtWebsite" ErrorMessage="Please enter Contact Person" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>होटल मालिक का मोबाइल नंबर</label>
                                    <asp:TextBox ID="txtMobileno" runat="server" CssClass="form-control form-control-lg border-left-0" placeholder="Mobile number" Enabled="false"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileno" ForeColor="Red"
                                        ErrorMessage="अमान्य मोबाइल नंबर।"
                                        ValidationExpression="^([0-9]{10})$">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="fontcolour" runat="server" ControlToValidate="txtMobileno" ErrorMessage="Please enter Mobileno" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>प्रॉपर्टी प्रकार</label>
                                    <asp:DropDownList ID="ddlPropertyType" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="fontcolour" runat="server" ControlToValidate="ddlPropertyType" ErrorMessage="Please select PropertyType" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>राज्य</label>
                                    <asp:DropDownList ID="ddlStateId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateId_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="ddlStateId" ErrorMessage="Please select state" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>ज़िला</label>
                                    <asp:DropDownList ID="ddlDistrictId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictId_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="ddlDistrictId" ErrorMessage="Please select District" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>शहर</label>
                                    <asp:DropDownList ID="ddlCityId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCityId_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="ddlCityId" ErrorMessage="Please select city" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%-- <div class="col-md-4">
                                <div class="form-group">
                                    <label>क्षेत्र</label>
                                    <asp:DropDownList ID="ddlZoneId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlZoneId_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="ddlZoneId" ErrorMessage="Please select zone" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>--%>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">थाना</label>
                                    <asp:DropDownList ID="ddlPoliceStation" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour" runat="server" Enabled="false" ControlToValidate="ddlPoliceStation" ErrorMessage="Please select police station" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <%--   <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>होटल का गुमस्ता अपलोड करे</label>
                                    <asp:FileUpload ID="FileGumasta" runat="server" />
                                    <asp:CustomValidator ID="cvvalidate" runat="server"
                                        ToolTip="FileSize should not exceed 2MB" ForeColor="Red"
                                        ErrorMessage="FileSize should not exceed 2MB..."
                                        ControlToValidate="FileGumasta"
                                        ClientValidationFunction="checksize"></asp:CustomValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileGumasta" ForeColor="Red"
                                        ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।"
                                        ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" CssClass="fontcolour" runat="server" ControlToValidate="FileGumasta" ErrorMessage="Please select PropertyType" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>मालिक का आधार कार्ड</label>
                                    <asp:FileUpload ID="FileAdhar" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator1" runat="server"
                                        ToolTip="FileSize should not exceed 2MB" ForeColor="Red"
                                        ErrorMessage="FileSize should not exceed 2MB..."
                                        ControlToValidate="FileAdhar"
                                        ClientValidationFunction="checksize1"></asp:CustomValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileAdhar" ForeColor="Red"
                                        ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।"
                                        ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="fontcolour" runat="server" ControlToValidate="FileAdhar" ErrorMessage="Please select PropertyType" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">कमरे की श्रेणी</label>
                                    <asp:TextBox ID="txtRoomCategory" runat="server" CssClass="form-control" placeholder="कमरे की श्रेणी"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="fontcolour" runat="server" ControlToValidate="txtRoomCategory" ErrorMessage="कृपया कमरे की श्रेणी दर्ज करें" ValidationGroup="Catsave" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hdnidHotelRoomCategory" runat="server" Value='' />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtRoomCategory" ErrorMessage="कृपया कमरे की श्रेणी दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^.{1,50}" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">मूल्य</label>
                                    <asp:TextBox ID="txtRoomPrice" runat="server" CssClass="form-control" placeholder="मूल्य" MaxLength="10"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="fontcolour" runat="server" ControlToValidate="txtRoomPrice" ErrorMessage="कृपया कमरे का मूल्य दर्ज करें" ValidationGroup="Catsave" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRoomPrice" ErrorMessage="कृपया कमरे का मूल्य दर्ज करें। कृपया अंक दर्ज करें।" ValidationExpression="^\d+(,\d{1,2})?$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <div style="float: right">
                                        <asp:Button ID="btnSaveCategory" runat="server" Text="Save" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClick="btnSaveCategory_Click" ValidationGroup="Catsave" />
                                        <asp:Button ID="btnCancelCategory" runat="server" Text="Cancel" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClick="btnCancelCategory_Click" ValidationGroup="Catsave" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="box-body">
                        <asp:Repeater ID="rptCategory" runat="server" OnItemCommand="rptCategory_ItemCommand">
                            <HeaderTemplate>
                                <table id="example3" class="table table-bordered table-striped" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>S. No.</th>
                                            <th>कमरे की श्रेणी</th>
                                            <th>मूल्य</th>
                                            <th></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Container.ItemIndex + 1 %>
                                        <asp:HiddenField ID="hdnidHotelRoomCategory" runat="server" Value='<%#Eval("idHotelRoomCategory")%>' />
                                        <asp:HiddenField ID="hdnCategoryName" runat="server" Value='<%#Eval("CategoryName")%>' />
                                        <asp:HiddenField ID="hdniPrice" runat="server" Value='<%#Eval("iPrice")%>' />
                                    </td>
                                    <td><%#Eval("CategoryName")%></td>
                                    <td><%#Eval("iPrice")%></td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Text="Edit" class="btn btn-primary waves-effect waves-light btnGuest" data-toggle="tooltip" data-placement="top" title="Edit" CommandArgument='<%# Eval("idHotelRoomCategory") %>' CommandName="Update" />
                                        <asp:Button ID="Button3" runat="server" Text="Delete" Style="margin-left: 10px;" class="btn btn-primary waves-effect waves-light btnAction" data-toggle="tooltip" data-placement="top" title="Delete" CommandArgument='<%# Eval("idHotelRoomCategory") %>' CommandName="Delete" />
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


    <div class="modal fade modalign" id="saveCompleteModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel" style="text-align: center;">Hotel Update </h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>रूम कैटेगरी के रेट सफलतापूर्वक अपडेट कर दिए गए हैं।
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <asp:Button ID="btnAddGuest" runat="server" Text="ठीक है" data-dismiss="modal" class="btn btn-primary me-2" ValidationGroup="Catsave" />

                </div>
            </div>
        </div>
    </div>

    <div class="modal fade modalign" id="saveCompleteError" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabelError" style="text-align: center;">Hotel Update </h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><span id="idError" runat="server"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalign" id="saveCompleteModal1" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel1" style="text-align: center;">Hotel Category Delete </h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>क्या आप कमरे की श्रेणी हटाना चाहते हैं ?
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <a href="setting.aspx" class="btn btn-danger me-2">रद्द करें</a>
                    <asp:Button ID="Button2" runat="server" Text="पुष्टि करें" class="btn btn-primary me-2" OnClick="Button2_Click" />
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
        function QuestionDeleteData() {
            if (Page_ClientValidate()) {
                $('#saveCompleteModal1').modal('show');
                return false;
            }
            return true;
        }

        function SaveGuestError() {
            if (Page_ClientValidate()) {
                $('#saveCompleteError').modal('show');
                return false;
            }
            return true;
        }
       <%-- function checksize(source, arguments) {
            arguments.IsValid = false;
            var size = document.getElementById("<%=FileGumasta.ClientID%>").files[0].size;
            if (size > 2097152) {
                arguments.IsValid = false;
                return false;
            }
            else {
                arguments.IsValid = true;
                return true;
            }
        }
        function checksize1(source, arguments) {
            arguments.IsValid = false;
            var size1 = document.getElementById("<%=FileGumasta.ClientID%>").files[0].size;
            if (size1 > 2097152) {
                arguments.IsValid = false;
                return false;
            }
            else {
                arguments.IsValid = true;
                return true;
            }
        }--%>
    </script>
</asp:Content>
