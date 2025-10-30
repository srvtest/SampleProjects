<%@ Page Title="" Language="C#" MasterPageFile="~/mainHome.Master" AutoEventWireup="true" CodeBehind="SearchGuest.aspx.cs" Inherits="Hotel_Guest_Reporting_System.SearchGuest" %>

<%@ MasterType VirtualPath="~/mainHome.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdPropertyTypeId" runat="server" Value="0" />
        <div class="row">
            <div class="col-sm-12 p-0">
                <div class="main-header">
                    <h4>
                        <asp:Label ID="lbl1" runat="server"></asp:Label></h4>
                    <ol class="breadcrumb breadcrumb-title breadcrumb-arrow">
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>dashboard.aspx"><i class="icofont icofont-home"></i></a>
                        </li>
                        <li class="breadcrumb-item"><a href="<%=this.Master.baseUrl %>SearchGuest.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>
                        <%-- <li class="breadcrumb-item"><a href="frmPropertyType.aspx">
                            <asp:Label ID="lbl2" runat="server"></asp:Label></a>
                        </li>--%>
                    </ol>
                </div>
            </div>
        </div>
        <div class="row" runat="server" id="pnlUser">
            <!--Basic Form starts-->
            <div class="col-md-12 grid-margin stretch-card mx-auto">
                <div class="card" runat="server">
                    <div class="card-header" style="background-color: #ffe2c8; color: #000000;">
                        <h4 class="with-border">
                            <asp:Label ID="lbl4" runat="server">सर्च गेस्ट</asp:Label>
                            <div style="float: right">
                            </div>
                        </h4>
                    </div>
                    <div class="card-body">
                        <div class="row" style="margin-left: 10px; margin-top: 10px;">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label style="color: #000000;">गेस्ट नाम </label>
                                    <asp:TextBox ID="txtName" runat="server" class="form-control" placeholder="गेस्ट नाम" MaxLength="25"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtName" ErrorMessage="कृपया गेस्ट नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[A-Za-z ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label style="color: #000000;">आईडी नंबर </label>
                                    <asp:TextBox ID="txtAdhar" runat="server" class="form-control" placeholder="आईडी नंबर" MaxLength="25"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAdhar" ErrorMessage="कृपया नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षर डालें।" ValidationExpression="^[A-Za-z0-9 ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label style="color: #000000;">मोबाइल नंबर </label>
                                    <asp:TextBox ID="txtContact" runat="server" class="form-control" placeholder="मोबाइल नंबर" MaxLength="12"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContact" ErrorMessage="कृपया वैध संपर्क नंबर दर्ज करें।" ValidationExpression="^[0-9 ]{10}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <div class="col-md-3" style="padding-top: 30px;">
                                <div style="">
                                    <asp:Button ID="Button1" runat="server" Text="सर्च गेस्ट" class="btn btn-guestsuccess me-2" data-toggle="tooltip" data-placement="top" title="सर्च गेस्ट" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-block">
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptGuest" runat="server" OnItemDataBound="rptGuest_ItemDataBound" OnItemCommand="rptGuest_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example" class="table table-bordered table-striped" style="width: 100%">
                                            <thead class="Guestthead">
                                                <tr>
                                                    <th class="Guestth">चेक इन नंबर</th>
                                                    <%--  <th>होटल का नाम </th>
                                                        <th>आईडी प्रकार </th>--%>
                                                    <th class="Guestth">प्रथम नाम </th>
                                                    <th class="Guestth">मोबाइल नंबर</th>
                                                    <%--                                                        <th>पता </th>--%>
                                                    <th class="Guestth">चेक इन तारीख</th>
                                                    <%-- <th>अतिरिक्त अतिथि</th>--%>
                                                    <th class="Guestth">जानकारी देखें</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td class="Guesttd"><%# Eval("BookingID") %>
                                                <asp:HiddenField ID="hdnBookingId" runat="server" Value='<%#Eval("BookingID")%>' />
                                                <asp:HiddenField ID="hdnIdGuest" runat="server" Value='<%#Eval("GuestId")%>' />
                                                <asp:HiddenField ID="hdnHotelID" runat="server" Value='<%#Eval("HotelID")%>' />
                                                <asp:HiddenField ID="hdnCheckinDate" runat="server" Value='<%#Convert.ToDateTime(Eval("CheckInDate")).ToString("yyyy-MM-dd")%>' />
                                            </td>
                                            <%--  <td><%#Eval("HotelName")%></td>
                                                <td><%#Eval("IdentificationType")%></td>--%>
                                            <td class="Guesttd"><%#Eval("GuestName")%></td>
                                            <td class="Guesttd"><%# (Eval("GuestMobileNumber").ToString())%></td>
                                            <%--<td class="Guesttd"><%# EncryptionHelper.Decrypt(Eval("GuestMobileNumber").ToString())%></td>--%>
                                            <%--   <td><%#Eval("Address")%></td>--%>
                                            <td class="Guesttd"><%#Convert.ToDateTime(Eval("CheckInDate")).ToString("yyyy-MM-dd")%>
                                                <%--  <br />
                                                    Check-Out : <%#Convert.ToDateTime(Eval("CheckOutDate")).ToString("dd-MMM-yyyy")%>--%>
                                            </td>
                                            <%-- <td>
                                                    <asp:Label ID="lblAddGuest" runat="server" Text=""></asp:Label>
                                                </td>--%>
                                            <td>
                                                <asp:Button ID="btnDetails" runat="server" Text="विवरण" class="btn btn-guestsuccess" data-toggle="tooltip" data-placement="top" title="विवरण" CommandName="Details" /></td>
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
</asp:Content>
