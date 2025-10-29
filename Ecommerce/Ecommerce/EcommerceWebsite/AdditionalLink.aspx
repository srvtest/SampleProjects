<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdditionalLink.aspx.cs" Inherits="EcommerceWebsite.AdditionalLink" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .additionlink {
            margin-top: 20px;
            width: 1190px;
            height: 500px;
        }

        .labelname {
            text-align: center;
            text-transform: uppercase;
            margin-bottom:20px;
        }
        div.scroll{
                height: 410px;
    overflow-y: scroll;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid additionlink">
        <asp:HiddenField ID="hdMessage" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="hdIdProductPrice" runat="server" Value="0" />
        <asp:HiddenField ID="hdIdAdditionalLink" runat="server" Value="0" />
        <!-- Page Heading -->
        <%--<h1 class="h3 mb-2 text-gray-800">Additional Link</h1>
        <p class="mb-4">Additional Link description</p>--%>

        <!-- DataTales Example -->
        <div class="card shadow mb-4" runat="server" id="tblAdditionalLink">
            <div class="card-header py-3">
                <%-- <h6 class="m-0 font-weight-bold text-primary" style="display: inline-block;">AdditionalLink</h6>--%>
                <%--<asp:Button ID="btnProductPrice" runat="server" Text="Add New" class="btn btn-success btn-use floatRight" OnClick="btnProductPrice_Click" />--%>
                <%--<asp:Button ID="btnSave" runat="server" Text="Save" class="btn btn-success btn-use floatRight" OnClick="btnSave_Click" />--%>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:Repeater ID="lstAdditionalLink" runat="server">
                        <HeaderTemplate>
                            <%--<table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">--%>
                                <%-- <thead>
                                    <tr>
                                        <th></th>
                                        <th>Name</th>
                                        <th>Product Price Details</th>
                                        
                                    </tr>
                                </thead>--%>
                               <%-- <tbody>--%>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%--<tr>--%>
                                <h1 class="labelname">
                                    <asp:Label ID="lblName" runat="server" ClientIDMode="Static" Text='<%#Eval("Name")%>'></asp:Label></h1>
                                <div class="scroll">
                                    <%#Eval("sDescription")%>
                                </div>
                           <%-- </tr>--%>
                        </ItemTemplate>
                        <FooterTemplate>
                          <%--  </tbody>--%>
                                   <%-- <tfoot>
                                        <tr>
                                            <th>Name</th>
                                            <th>Salary</th>
                                        </tr>
                                    </tfoot>--%>
                           <%-- </table>--%>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
