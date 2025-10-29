<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Ecommerce.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <style>
        .floatRight {
            float: right;
        }
        .fontcolour{
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="card shadow mb-4" runat="server" id="frmChangedPassword">
            <div class="card-header py-3">
                <asp:HiddenField ID="hdUserId" runat="server" />
                <asp:HiddenField ID="hdUserName" runat="server" />
                <asp:HiddenField ID="hdCurrentPassword" runat="server" />
                <asp:HiddenField ID="hdMessage" runat="server" />
                <%--Change Password--%>
                <asp:Label ID="lblMess" class="m-0 font-weight-bold text-primary" Style="display: inline-block;" runat="server" ClientIDMode="Static"></asp:Label>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" class="btn btn-success btn-use floatRight" OnClick="btnUpdate_Click" Style="margin-left: 10px;" ValidationGroup="save" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" class="btn btn-danger btn-use floatRight" OnClick="btnCancel_Click" />
            </div>
            <div class="card-body">
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        Current Password
                        <asp:TextBox ID="txtCurrentPassword" runat="server" class="form-control form-control-user" TextMode="Password" placeholder="CurrentPassword"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="fontcolour" ControlToValidate="txtCurrentPassword" runat="server" ErrorMessage="Please Enter Current Password." ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        New Password
                        <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-user" placeholder="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="fontcolour" ControlToValidate="txtPassword" runat="server" ErrorMessage="Please Enter Password." ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-6 mb-3 mb-sm-0">
                        Confirm Password
                        <asp:TextBox ID="txtConfirmPassword" runat="server" class="form-control form-control-user" placeholder="Confirm Password"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtConfirmPassword"  CssClass="fontcolour ValidationError"  ControlToCompare="txtPassword" ErrorMessage="Password No Match" ToolTip="Password must be the same" Display="Dynamic" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="fontcolour" ControlToValidate="txtConfirmPassword" runat="server" ErrorMessage="Please Enter Confirm Password." ValidationGroup="save" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class=""></div>
        </div>
    </div>

    <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript">
        function Validate() {
            var password = document.getElementById("txtPassword").value;
            var confirmPassword = document.getElementById("txtConfirmPassword").value;
            if (password != confirmPassword) {
                alert("Passwords do not match.");
                return false;
            }
            return true;
        }
        $("#frmChangedPassword").validate({
            rules : {
                password : {
                    minlength : 5,
                    maxlength: 10
                },
                password_confirm : {
                    minlength : 5,
                    maxlength: 10,
                    equalTo : "#password"
                }


        });
    </script>
</asp:Content>
