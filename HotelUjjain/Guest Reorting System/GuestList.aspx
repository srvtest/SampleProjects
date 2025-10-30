<%@ Page Title="" Language="C#" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="GuestList.aspx.cs" Inherits="Guest_Reporting_System.GuestList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <asp:Label ID="lbl4" runat="server">सर्च गेस्ट</asp:Label>
                        <%-- <div style="float: right">
                            <asp:Button ID="btnsearch" runat="server" Text="सर्च गेस्ट" class="btn btn-primary me-2" OnClick="btnSearch_Click" />
                        </div>--%>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>नाम </label>
                                    <asp:TextBox ID="txtGuestName" runat="server" class="form-control" placeholder="नाम" MaxLength="25"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtGuestName" ErrorMessage="कृपया नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[A-Za-z ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>मोबाइल नंबर  </label>
                                    <asp:TextBox ID="txtMobileNo" runat="server" class="form-control" placeholder="मोबाइल नंबर" MaxLength="12"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="कृपया वैध संपर्क नंबर दर्ज करें।" ValidationExpression="^[0-9 ]{10}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>आईडी नंबर </label>
                                    <asp:TextBox ID="txtAadharNo" runat="server" class="form-control" placeholder="आईडी नंबर" MaxLength="25"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAadharNo" ErrorMessage="कृपया नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[A-Za-z0-9 ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-3" style="padding-top: 25px;">
                                <div class="form-group">
                                    <asp:Button ID="btnsearch" runat="server" Text="सर्च गेस्ट" class="btn btn-primary me-2" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptGuest" runat="server" OnItemDataBound="rptGuest_ItemDataBound" OnItemCommand="rptGuest_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-bordered table-striped nowrap" style="width: 100%" id="example4">
                                            <thead>
                                                <tr>
                                                    <th>क्रम संख्‍या</th>
                                                    <th>आईडी प्रकार </th>
                                                    <th>प्रथम नाम </th>
                                                    <th>मोबाइल नंबर</th>
                                                   <%-- <th>पता </th>--%>
                                                    <th>चेक इन तारीख</th>
                                                    <%--  <th>अतिरिक्त अतिथि</th>
                                                    <th>जानकारी देखें</th>--%>
                                                    <th></th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %>
                                                <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("idGuestMaster")%>' />
                                            </td>
                                            <td><%#Eval("IdentificationType")%></td>
                                            <td><%#Eval("GuestName")%></td>
                                            <td><%#Eval("ContactNo")%></td>
                                           <%-- <td><%#Eval("Address")%></td>--%>
                                            <td>Check-In : <%#Convert.ToDateTime(Eval("CheckInDate")).ToString("dd-MMM-yyyy")%>
                                                <br />
                                                Check-Out : <%#Convert.ToDateTime(Eval("CheckOutDate")).ToString("dd-MMM-yyyy")%>
                                            </td>
                                            <%-- <td>
                                                <asp:Label ID="lblAddGuest" runat="server" Text=""></asp:Label>
                                            </td>--%>
                                            <td>
                                                <asp:Button ID="btnDetails" runat="server" Text="जानकारी देखें" class="btn btn-primary" CommandName="Details" />
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
                        <div class="row lblCtrl">
                            <div class="col-md-12 table-responsive">
                                <span runat="server" id="lblMessage1"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--    <div class="modal fade" id="saveModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
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
                  
                    <asp:Button ID="Button3" runat="server" Text="ठीक है" class="btn btn-primary me-2" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript"> 
        function SearchGuestData() {
            $('#saveModal').modal('show');
            return false;
        }
    </script>--%>
</asp:Content>
