<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="PendingGuestDetails.aspx.cs" Inherits="Police_Station_Reporting_System.PendingGuestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/ui-lightness/jquery-ui.css' rel='stylesheet'>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js">    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">होटल में रुके हुए गेस्ट के जानकारी देखे</asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <%--<div class="col-md-4">
                                <div class="form-group">
                                    <label>दिनांक <span class="text-danger">*</span></label>
                                    <asp:DropDownList runat="server" ID="ddlDays" AutoPostBack="true" class="form-control" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
                                        <asp:ListItem Value="4">आज की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="0">कल की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="1">पिछले 7 दिनों की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="2">पिछले 15 दिनों की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="3">पिछले 30 दिनों की चेक इन रिपोर्ट</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>चेक इन तारीख <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control" placeholder="Please select from date" ClientIDMode="Static" onkeypress="return allowDateCharacters(event)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtfrom" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please select from date."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div style="padding-top: 25px;">
                                    <%--<asp:CheckBox ID="chkShowReport" runat="server" CssClass="form-check-input" Style="margin-right: 3px;" ClientIDMode="Static" />
        <label class="form-check-label" for="chkShowReport" style="margin-right: 25px;">ज़ीरो अतिथि रिपोर्ट</label>--%>
                                    <asp:Button ID="btnSearch" runat="server" Text="रिपोर्ट देखे" class="btn btn-primary me-2" OnClick="btnSearch_Click1" />
                                </div>
                            </div>
                            <%--  <div class="col-md-3">
                                <div class="form-group">
                                    <label>दिनांक तक  <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtTo" runat="server" class="form-control" placeholder="Please select to date" ClientIDMode="Static" onkeypress="return allowDateCharacters(event)"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTo" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please select to date."></asp:RequiredFieldValidator>
                                </div>
                            </div>--%>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>होटल</label>
                                    <asp:DropDownList runat="server" ID="ddlHotel" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptGuest" runat="server" OnItemDataBound="rptGuest_ItemDataBound" OnItemCommand="rptGuest_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example4" class="table table-striped nowrap" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>क्रम संख्‍या</th>
                                                    <th>होटल का नाम</th>
                                                    <th>अतिथि सूची</th>
                                                    <%-- <th>चेक इन की तारीख</th>--%>
                                                    <th>कुल अतिथि </th>
                                                    <%-- <th>नोट</th>--%>
                                                    <th>सारांश</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %>
                                                <asp:HiddenField ID="hdnIdHotel" runat="server" Value='<%#Eval("idHotelMaster")%>' />
                                                <asp:HiddenField ID="hdnSubDate" runat="server" Value='<%#Eval("SubmitDate")%>' />
                                            </td>
                                            <td><%#Eval("HotelName")%></td>
                                            <td>
                                                <asp:Repeater runat="server" ID="rptPendingGuestDetail">
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
                                                                <%-- <asp:Button ID="Button1" runat="server" Text="संपादित करें" CssClass="btn btn-primary HideButton" CommandName="Change" />--%>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                        <%--<div style="break-after: page"></div>--%>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                            <%-- <td><%#Convert.ToDateTime(Eval("SubmitDate")).ToString("dd-MMM-yyyy")%></td>--%>
                                            <td><%#Eval("TotalGuest")%></td>
                                            <%--<td><%#Eval("SubmitType")%></td>--%>
                                            <td>
                                                <asp:HiddenField ID="hdnAdd" runat="server" Value='<%#Eval("TotalGuest")%>' />
                                                <asp:Button ID="btnDetails" runat="server" Text="विवरण" CssClass="btn btn-primary" CommandName="Details" /></td>
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
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>
    <script>
        function allowDateCharacters(event) {
            var char = String.fromCharCode(event.keyCode);
            if (!/[0-9\/]/.test(char)) {
                event.preventDefault();
                return false;
            }
            return true;
        }
        //$('.buttons-print').hide();
        //$('.buttons-print').hide();
        $(document).ready(function () {
            $('#txtfrom').datepicker({
                minDate: -30,
                maxDate: 0,
                dateFormat: "dd/MM/yy"
            }).attr('readonly', 'readonly');
            $('#txtTo').datepicker({
                minDate: -30,
                maxDate: 0,
                dateFormat: "dd/MM/yy"
            }).attr('readonly', 'readonly');
        });
        //$("#txtfrom").keypress(function (e) {
        //    e.preventDefault();
        //    //return false;
        //});
        //$("#txtfrom").keydown(function (e) {
        //    e.preventDefault();
        //    //return false;
        //});
        //$("#txtTo").keypress(function (e) {
        //    e.preventDefault();
        //    //return false;
        //});
        //$("#txtTo").keydown(function (e) {
        //    e.preventDefault();
        //    //return false;
        //});
    </script>
</asp:Content>
