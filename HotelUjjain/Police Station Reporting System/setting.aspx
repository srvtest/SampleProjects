<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="setting.aspx.cs" Inherits="Police_Station_Reporting_System.setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .lblCtrl {
            text-align: center;
            display: block;
        }

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
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">Profile</asp:Label>
                        <div style="float: right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClick="btnCancel_Click" />
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label lblCtrl">पुलिस स्टेशन</label>
                                    <asp:DropDownList ID="ddlPoliceStation" runat="server" CssClass="form-control lblCtrl" AutoPostBack="true" OnSelectedIndexChanged="ddlPoliceStation_SelectedIndexChanged"></asp:DropDownList>
                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="fontcolour lblCtrl" runat="server" ControlToValidate="ddlPoliceStation" ErrorMessage="Please select Police Station" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    <asp:HiddenField ID="HiddenField1" runat="server"></asp:HiddenField>
                                </div>
                            </div>
                            <div class="col-md-4"></div>
                        </div>
                    </div>
                    <div class="box-body" id="Main">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">पुलिस स्टेशन का नाम</label>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="पुलिस स्टेशन का नाम" Enabled="false"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" runat="server" ControlToValidate="txtName" ErrorMessage="कृपया पुलिस स्टेशन का नाम दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                    <asp:HiddenField ID="hdnHotelNewId" runat="server"></asp:HiddenField>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">पुलिस स्टेशन का मोबाइल नंबर</label>
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" placeholder="पुलिस स्टेशन का मोबाइल नंबर" Enabled="false"></asp:TextBox>
                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtContact" ForeColor="Red"
                                        ErrorMessage="अमान्य मोबाइल नंबर।"
                                        ValidationExpression="^([0-9]{10})$">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="fontcolour" runat="server" ControlToValidate="txtContact" ErrorMessage="कृपया संपर्क नंबर दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">पुलिस स्टेशन का लैंडलाइन नंबर</label>
                                    <asp:TextBox ID="txtLandline" runat="server" CssClass="form-control" placeholder="पुलिस स्टेशन का लैंडलाइन नंबर" Enabled="false"></asp:TextBox>
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtLandline" ForeColor="Red"
                                        ErrorMessage="अमान्य मोबाइल नंबर।"
                                        ValidationExpression="^([0-9]{10})$">
                                    </asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="fontcolour" runat="server" ControlToValidate="txtLandline" ErrorMessage="कृपया संपर्क नंबर दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label for="exampleInputEmail" class="form-control-label">पुलिस स्टेशन मेल आईडी </label>
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="पुलिस स्टेशन मेल आईडी " Enabled="false"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="fontcolour" runat="server" ControlToValidate="txtEmail" ErrorMessage="कृपया ईमेल दर्ज करें" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>राज्य</label>
                                    <asp:DropDownList ID="ddlStateId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlStateId_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="ddlStateId" ErrorMessage="Please select state" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>ज़िला</label>
                                    <asp:DropDownList ID="ddlDistrictId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictId_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="ddlDistrictId" ErrorMessage="Please select District" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
                            </div>

                            <%--  <div class="col-md-6">
                                <div class="form-group">
                                    <label>क्षेत्र</label>
                                    <asp:DropDownList ID="ddlZoneId" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="ddlZoneId" ErrorMessage="Please select zone" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>--%>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>शहर</label>
                                    <asp:DropDownList ID="ddlCityId" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false"></asp:DropDownList>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="ddlCityId" ErrorMessage="Please select city" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>--%>
                                </div>
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
                    <h5 class="modal-title" id="saveModalLabel" style="text-align: center;">Hotel Update </h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>पुलिस स्टेशन प्रोफ़ाइल अपडेट कर दी गई है |
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <asp:Button ID="btnAddGuest" runat="server" Text="ठीक है" data-dismiss="modal" class="btn btn-primary me-2" ValidationGroup="Catsave_1" />

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
    <script type="text/javascript">  
        function SaveGuestData() {
            if (Page_ClientValidate()) {
                $('#saveCompleteModal').modal('show');
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
