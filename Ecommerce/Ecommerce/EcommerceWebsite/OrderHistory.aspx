<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="EcommerceWebsite.OrderHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
         <asp:HiddenField ID="hdPageNo" runat="server" Value="1" />
         <asp:HiddenField ID="customerID" runat="server"  />
        <div class="row ">
            <!-- =====  BREADCRUMB STRAT  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>My Account</h1>
                    <ul>
                        <li><a href="../index">Home</a></li>
                        <li class="active">My Account</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <div class="col-sm-12">
                <div class="alert alert-success alert-dismissible fade hide">
                    <strong>Success! </strong>
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    <button type="button" class="close" data-dismiss="alert">&times;</button>
                </div>
            </div>
            <div class="col-sm-8 col-lg-8 mtb_20 col-lg-offset-1">
                 <asp:Panel ID="pnlMyOrder" runat="server">

                    <asp:Repeater ID="rptOrder" runat="server" OnItemDataBound="rptOrder_ItemDataBound">
                        <ItemTemplate>
                            <div class="panel panel-default">
                                <asp:HiddenField ID="hdnidOrder" runat="server" Value='<%#Eval("idCustomerOrder")%>' />
                                <div class="panel-heading">
                                    <table style="width: 100%; font-size: smaller;">
                                        <tr>
                                            <td style="width: 20%">ORDER PLACED<br />
                                                <%#Convert.ToDateTime(Eval("dtOrder")).ToShortDateString()%></td>

                                            <td style="width: 20%">SHIP TO
                                    <br />
                                                <%#Eval("sName")%></td>
                                            <td style="width: 20%">Status
                                    <br />
                                                <%#Eval("ApproveReject")%></td>
                                            <td style="width: 40%"><span style="float: right;">ORDER # <%# Convert.ToString(Eval("sOrderNo"))%></span></td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="panel-collapse collapse in">
                                    <div class="panel-body">
                                        <div class="col-sm-12 mb-3 mb-sm-0" style="margin-bottom: 20px;">

                                            <div class="card-body">
                                                <table class="table table-bordered table-hover">
                                                    <tbody>
                                                        <asp:Repeater ID="rptOrderproduct" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td class="text-center" style="width: 70px"><a href="#">
                                                                        <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("ImageURL")%>" alt="<%#Eval("sName")%>" title="<%#Eval("sName")%>" class="rounded mx-auto d-block"></a></td>
                                                                    <td class="text-left"><a href="../ProductDetail/<%#Eval("SEOName")%>"><%#Eval("sName")%></a></td>
                                                                    <td class="text-right"><%#Eval("Quantity")%></td>
                                                                    <td class="text-right"><%#Eval("sNameCurrency")%><%# Convert.ToDouble(Eval("Quantity"))* Convert.ToDouble(Eval("PurchasePrice"))%></td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                    <tfoot>
                                                        <tr>
                                                            <td class="text-right" colspan="3"><strong>Total:</strong></td>
                                                            <td class="text-right"><%#Eval("totalAmount")%></td>
                                                        </tr>
                                                    </tfoot>
                                                </table>
                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                     <div class="pagination-nav text-center mt_50">
                    <ul>
                        <%--<li><a href="#"><i class="fa fa-angle-left"></i></a></li>
                        <li class="active"><a href="#">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#"><i class="fa fa-angle-right"></i></a></li>--%>
                        <%--<asp:HiddenField ID="hdnPageNum" runat="server" Value="1" />--%>
                        <asp:Repeater ID="rptPagination" ClientIDMode="Static" runat="server" OnItemCommand="rptPagination_ItemCommand">
                            <HeaderTemplate>
                                <li>
                                    <asp:LinkButton ID='lnkFirst' CommandName="Page" CommandArgument="-1" runat="server" Font-Bold="True" ToolTip="First"><i class="fa fa-angle-left"></i>
                                    </asp:LinkButton>
                                </li>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li class='<%# ((ListItem)Container.DataItem).Value.Equals(hdPageNo.Value) ? "active" : string.Empty %>'>
                                    <asp:LinkButton ID='lnkPage'
                                        CommandName="Page" CommandArgument="<%# Container.DataItem %>" runat="server" Font-Bold="True"><%# Container.DataItem %>  
                                    </asp:LinkButton>
                                </li>
                            </ItemTemplate>
                            <FooterTemplate>
                                <li>
                                    <asp:LinkButton ID='lnkLast' CommandName="Page" CommandArgument="-2" runat="server" Font-Bold="True" ToolTip="Last"><i class="fa fa-angle-right"></i>
                                    </asp:LinkButton>
                                </li>
                            </FooterTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                </asp:Panel>
            </div>
        </div>
    </div>

    <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>


</asp:Content>
