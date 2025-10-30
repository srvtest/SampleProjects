<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="GuestDetails.aspx.cs" Inherits="Police_Station_Reporting_System.GuestDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">चेक इन रिपोर्ट देखें--होटल द्वारा भेजी गई चेक इन रिपोर्ट देखें</asp:Label>
                        <div style="float: right">
                        </div>
                    </h4>
                    <div class="box-body">
                        <div class="row">
                            <div class="col-md-4">
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
                                    <asp:CheckBox ID="chkShowReport" runat="server" CssClass="form-check-input" Style="margin-right: 3px;" ClientIDMode="Static" />
                                    <label class="form-check-label" for="chkShowReport" style="margin-right: 25px;">ज़ीरो अतिथि रिपोर्ट</label>
                                    <asp:Button ID="btnSearch" runat="server" Text="रिपोर्ट देखे" class="btn btn-primary me-2" OnClick="btnSearch_Click1" />
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
                                                    <th>चेक इन की तारीख</th>
                                                    <th>कुल अतिथि </th>
                                                    <th>नोट</th>
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
                                            <td><%#Convert.ToDateTime(Eval("SubmitDate")).ToString("dd-MMM-yyyy")%></td>
                                            <td><%#Eval("TotalGuest")%></td>
                                            <td><%#Eval("SubmitType")%></td>
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
</asp:Content>
