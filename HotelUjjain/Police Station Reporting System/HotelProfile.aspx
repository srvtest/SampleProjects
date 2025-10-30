<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="HotelProfile.aspx.cs" Inherits="Police_Station_Reporting_System.HotelProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <%-- <asp:Button ID="btnSubmit" runat="server" Text="Save" class="btn btn-success waves-effect waves-light m-r-30" OnClick="btnSubmit_Click" />--%>
                            <asp:Button ID="btnCancel" runat="server" Text="Back" CssClass="btn btn-success waves-effect waves-light m-r-30" OnClientClick="JavaScript:window.history.back(1); return false;" />
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
                                    <label for="exampleInputEmail" class="form-control-label">रजिस्टर मोबाइल नंबर </label>
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
                                    <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control form-control-lg border-left-0" Enabled="false" placeholder="Contact Person"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="fontcolour" runat="server" ControlToValidate="txtWebsite" ErrorMessage="Please enter Contact Person" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>होटल मालिक का मोबाइल नंबर</label>
                                    <asp:TextBox ID="txtMobileno" runat="server" CssClass="form-control form-control-lg border-left-0" Enabled="false" placeholder="Mobile number"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlStateId" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlStateId_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" runat="server" ControlToValidate="ddlStateId" ErrorMessage="Please select state" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>ज़िला</label>
                                    <asp:DropDownList ID="ddlDistrictId" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDistrictId_SelectedIndexChanged" Enabled="false"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="fontcolour" runat="server" ControlToValidate="ddlCityId" ErrorMessage="Please select District" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>शहर</label>
                                    <asp:DropDownList ID="ddlCityId" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlCityId_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" runat="server" ControlToValidate="ddlCityId" ErrorMessage="Please select city" ValidationGroup="save" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <%--    <div class="col-md-4">
                                <div class="form-group">
                                    <label>क्षेत्र</label>
                                    <asp:DropDownList ID="ddlZoneId" runat="server" CssClass="form-control" AutoPostBack="true" Enabled="false" OnSelectedIndexChanged="ddlZoneId_SelectedIndexChanged"></asp:DropDownList>
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
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- <div class="modal fade" id="saveCompleteModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
     <div class="modal-dialog modal-dialog-centered">
         <div class="modal-content">
             <div class="modal-header">
                 <h5 class="modal-title" id="saveModalLabel">Hotel Update </h5>
                 <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
             </div>
             <div class="modal-body">
                 <i class="fa fa-exclamation-triangle fa-2x"></i>होटल प्रोफ़ाइल अपडेट कर दी गई है |
             </div>
             <div class="modal-footer">
                 <asp:Button ID="btnAddGuest" runat="server" Text="ठीक है" class="btn btn-primary me-2" OnClick="btnAddGuest_Click" />

             </div>
         </div>
     </div>
 </div>

 <div class="modal fade" id="saveCompleteError" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
     <div class="modal-dialog modal-dialog-centered">
         <div class="modal-content">
             <div class="modal-header">
                 <h5 class="modal-title" id="saveModalLabelError">Hotel Update </h5>
                 <button type="button" class="btn-close" data-dismiss="modal" aria-label="Close"></button>
             </div>
             <div class="modal-body">
                 <i class="fa fa-exclamation-triangle fa-2x"></i><span id="idError" runat="server"></span>
             </div>
             <div class="modal-footer">
             </div>
         </div>
     </div>
 </div>--%>
    <script type="text/javascript">  
        //function SaveGuestData() {
        //    if (Page_ClientValidate()) {
        //        $('#saveCompleteModal').modal('show');
        //        return false;
        //    }
        //    return true;
        //}

        //function SaveGuestError() {
        //    if (Page_ClientValidate()) {
        //        $('#saveCompleteError').modal('show');
        //        return false;
        //    }
        //    return true;
        //}
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
