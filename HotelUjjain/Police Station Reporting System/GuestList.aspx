<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GuestList.aspx.cs" Inherits="Police_Station_Reporting_System.GuestList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">चेक इन रिपोर्ट न भेजने वाली होटलो की सूची </asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>दिनांक <span class="text-danger">*</span></label>
                                    <asp:DropDownList runat="server" ID="ddlDays" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDays_SelectedIndexChanged">
                                        <asp:ListItem Value="4">आज की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="0">कल की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="1">पिछले 7 दिनों की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="2">पिछले 15 दिनों की चेक इन रिपोर्ट</asp:ListItem>
                                        <asp:ListItem Value="3">पिछले 30 दिनों की चेक इन रिपोर्ट</asp:ListItem>
                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <label>होटल <span class="text-danger">*</span></label>
                                    <asp:DropDownList runat="server" ID="ddlHotel" class="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div style="padding-top: 25px;">
                                    <asp:Button ID="btnSearch" runat="server" Text="रिपोर्ट देखे" class="btn btn-primary me-2" OnClick="btnSearch_Click1" />
                                </div>
                            </div>
                        </div>

                        <%--   <div>
                        </div>--%>
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:Repeater ID="rptGuest" runat="server" OnItemDataBound="rptGuest_ItemDataBound" OnItemCommand="rptGuest_ItemCommand">
                                    <HeaderTemplate>
                                        <table id="example4" class="table table-bordered table-striped nowrap" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>क्रम संख्‍या</th>
                                                    <th>तारीख</th>
                                                    <th>होटल का नाम </th>
                                                    <th>पता</th>
                                                    <th>शहर</th>
                                                    <th>संपर्क नंबर</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex + 1 %></td>
                                            <td><%#Convert.ToDateTime(Eval("SubmitDate")).ToString("dd-MMM-yyyy")%></td>
                                            <td>
                                              <asp:HiddenField ID="hdnIdHotel" runat="server" Value='<%#Eval("idHotel")%>' />
                                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Details"><%#Eval("HotelName")%></asp:LinkButton></td>
                                            <td><%#Eval("Address")%></td>
                                            <td><%#Eval("City")%></td>
                                            <td><%#Eval("ContactNo")%></td>
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
