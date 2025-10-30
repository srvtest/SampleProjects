<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="SubmitedData.aspx.cs" Inherits="Guest_Reporting_System.SubmitedData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">--%>
    <link href='https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/ui-lightness/jquery-ui.css' rel='stylesheet'>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js">    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">    </script>
    <style>
        .lblCtrl {
            text-align: center;
            display: block;
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
                        <asp:Label ID="lbl4" runat="server">पुलिस स्टेशन में सबमिट की गई रिपोर्ट.</asp:Label>
                        <%--<div style="float: right">
                            <asp:Button ID="btnsearch" runat="server" Text="सर्च गेस्ट" class="btn btn-primary me-2" OnClick="btnsearch_Click" />
                        </div>--%>
                    </h4>
                    <p class="box-header">
                        <asp:Label ID="Label2" runat="server" CssClass="lblCtrl"><b>|| कृपया ध्यान दें ||</b></asp:Label></br>
                        <asp:Label ID="Label1" runat="server">इस पोर्टल पर आप एक महीने तक की पुरानी रिपोर्ट देख सकते हैं। अपने रिकॉर्ड के लिए आप समय-समय पर रिपोर्ट डाउनलोड कर के रख सकते हैं।</asp:Label>
                    </p>
                    <hr />
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>दिनांक से <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtfrom" runat="server" CssClass="form-control" placeholder="Please select from date" ClientIDMode="Static"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtfrom" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please select from date."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>दिनांक तक  <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtTo" runat="server" class="form-control" placeholder="Please select to date" ClientIDMode="Static"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTo" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="Please select to date."></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-4" style="padding-top: 25px;">
                                <div class="form-group">
                                    <asp:CheckBox ID="chkShowReport" runat="server" CssClass="form-check-input" Style="margin-right: 3px;" ClientIDMode="Static" />
                                    <label class="form-check-label" for="chkShowReport" style="margin-right: 25px;">ज़ीरो अतिथि रिपोर्ट</label>
                                    <asp:Button ID="btnsearch" runat="server" Text="रिपोर्ट देखे" class="btn btn-primary me-2" OnClick="btnsearch_Click" />
                                </div>
                            </div>
                        </div>
                        <%--                        <div class="row">
                            <div>
                                <div style="float: right">
                                </div>
                            </div>
                        </div>--%>
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
                                                    <th>जानकारी देखें</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %>
                                                <asp:HiddenField ID="hdnsubmitDate" runat="server" Value='<%#Eval("SubmitDate")%>' />
                                            </td>
                                            <td>
                                                <%#Convert.ToDateTime(Eval("SubmitDate")).ToString("dd-MMM-yyyy")%>
                                            </td>
                                            <td><%#Eval("AddionalGuest")%></td>
                                            <td>
                                               <asp:HiddenField ID="hdnAdd" runat="server" Value='<%#Eval("AddionalGuest")%>' />
                                                <asp:Button ID="btnDetails" runat="server" Text="जानकारी देखें" CssClass="btn btn-primary" CommandName="Details" />
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
        <script>
            $('.buttons-print').hide();
            $('.buttons-print').hide();
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
            $("#txtfrom").keypress(function (e) {
                e.preventDefault();
                //return false;
            });
            $("#txtfrom").keydown(function (e) {
                e.preventDefault();
                //return false;
            });
            $("#txtTo").keypress(function (e) {
                e.preventDefault();
                //return false;
            });
            $("#txtTo").keydown(function (e) {
                e.preventDefault();
                //return false;
            });
        </script>
</asp:Content>

