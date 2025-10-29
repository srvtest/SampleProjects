<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CreateReview.aspx.cs" Inherits="EcommerceWebsite.CreateReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .rating {
            float: left;
        }

            /* :not(:checked) is a filter, so that browsers that don’t support :checked don’t 
   follow these rules. Every browser that supports :checked also supports :not(), so
   it doesn’t make the test unnecessarily selective */
            .rating:not(:checked) > input {
                position: absolute;
                top: -9999px;
                clip: rect(0,0,0,0);
            }

            .rating:not(:checked) > label {
                float: right;
                width: 1em;
                padding: 0 .1em;
                overflow: hidden;
                white-space: nowrap;
                cursor: pointer;
                font-size: 200%;
                line-height: 1.2;
                color: #ddd;
                text-shadow: 1px 1px #bbb, 2px 2px #666, .1em .1em .2em rgba(0,0,0,.5);
            }

                .rating:not(:checked) > label:before {
                    content: '★ ';
                }

            .rating > input:checked ~ label {
                color: #f70;
                text-shadow: 1px 1px #c60, 2px 2px #940, .1em .1em .2em rgba(0,0,0,.5);
            }

            .rating:not(:checked) > label:hover,
            .rating:not(:checked) > label:hover ~ label {
                color: gold;
                text-shadow: 1px 1px goldenrod, 2px 2px #B57340, .1em .1em .2em rgba(0,0,0,.5);
            }

            .rating > input:checked + label:hover,
            .rating > input:checked + label:hover ~ label,
            .rating > input:checked ~ label:hover,
            .rating > input:checked ~ label:hover ~ label,
            .rating > label:hover ~ input:checked ~ label {
                color: #ea0;
                text-shadow: 1px 1px goldenrod, 2px 2px #B57340, .1em .1em .2em rgba(0,0,0,.5);
            }

            .rating > label:active {
                position: relative;
                top: 2px;
                left: 2px;
            }

        /* end of Lea's code */

        /*
 * Clearfix from html5 boilerplate
 */

        .clearfix:before,
        .clearfix:after {
            content: " "; /* 1 */
            display: table; /* 2 */
        }

        .clearfix:after {
            clear: both;
        }

        /*
 * For IE 6/7 only
 * Include this rule to trigger hasLayout and contain floats.
 */

        .clearfix {
            *zoom: 1;
        }

        /* my stuff */
        #status, button {
            margin: 20px 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row ">
            <!-- =====  BREADCRUMB START  ===== -->
            <div class="col-sm-12">
                <div class="breadcrumb ptb_20">
                    <h1>Create Review</h1>
                    <ul>
                        <li><a href="../index">Home</a></li>
                        <li class="active">Review</li>
                    </ul>
                </div>
            </div>
            <!-- =====  BREADCRUMB END===== -->
            <div class="col-sm-12">
                <div class="card-body">
                    <div>
                        <%--<div class="form-group row mb_40">
                            <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                        </div>--%>
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <img width="75" data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%=imgProduct%>" alt="<%=imgProduct%>" />
                                <%= productName %>
                            </div>
                        </div>
                        <hr />
                        <h4 class="h4 text-gray-900 mt_30">Overall rating</h4>
                        <asp:HiddenField ID="hdnidCustomerReview" runat="server" />
                        <asp:HiddenField ID="hdnRating" runat="server" />
                        <!-- Rating -->
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <div id="ratingForm">
                                    <div class="rating">
                                        <input type="radio" id="star5" name="rating" value="5" /><label for="star5" title="Rocks!">5 stars</label>
                                        <input type="radio" id="star4" name="rating" value="4" /><label for="star4" title="Pretty good">4 stars</label>
                                        <input type="radio" id="star3" name="rating" value="3" /><label for="star3" title="Meh">3 stars</label>
                                        <input type="radio" id="star2" name="rating" value="2" /><label for="star2" title="Kinda bad">2 stars</label>
                                        <input type="radio" id="star1" name="rating" value="1" /><label for="star1" title="Sucks big time">1 star</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div>
                            <h4 class="h4 text-gray-900 mt_30">Add a photo</h4>
                            <div class="form-group row">
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:FileUpload ID="reviewImageUpload" Width="100%" runat="server" />
                                </div>
                                <div class="col-sm-6 mb-3 mb-sm-0">
                                    <asp:Button runat="server" ID="btnUpload" CssClass="btn btn-md btn-primary marginTop"
                                        Text="Upload image" OnClick="btnUpload_Click" CausesValidation="false" OnClientClick="return ValidateFile()" />
                                   <%-- <asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-12 mb-3 mb-sm-0">
                                    <div class="row">
                                        <asp:Repeater runat="server" ID="rptImage" OnItemCommand="rptImage_ItemCommand">
                                            <ItemTemplate>
                                                <div class="col-sm-2">
                                                    <div style="position: relative; display: inline-flex;">
                                                        <img src='<%# "ReviewImage/" + (string.IsNullOrEmpty(Convert.ToString(Eval("Name"))) ? "NoImage.png" : Convert.ToString(Eval("Name"))) %>' />

                                                        <div class="btn-cancel">
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandName="Delete" OnClientClick='javascript:return confirm("Are you sure you want to delete?")' CommandArgument='<%# Eval("guid") %>'><i class="btn-icon fa fa-trash"></i></asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div>
                            <h4 class="h4 text-gray-900 mt_30">Add a headline</h4>
                            <div class="form-group row">
                                <div class="col-sm-12 mb-3 mb-sm-0">
                                    <asp:TextBox ID="txtHeadline" runat="server" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtHeadline" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please enter Headline"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <hr />
                        <div>
                            <h4 class="h4 text-gray-900 mt_30">Add a written review</h4>
                            <div class="form-group row">
                                <div class="col-sm-12 mb-3 mb-sm-0">
                                    <asp:TextBox TextMode="MultiLine" Rows="7" ID="txtReview" runat="server" Width="100%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtReview" ForeColor="Red" Display="Dynamic" runat="server" ErrorMessage="Please enter review"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" class="btn btn-primary mb_20" Style="float: left;" OnClick="btnSubmit_Click" />
                        <div style="margin-top: 9px; margin-left: 25px; float: left;">
                            <asp:Label ID="lblMsg" runat="server" Visible="false" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="js/jquery.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {

                var rate = $("#<%= hdnRating.ClientID %>").val();
                //alert(rate);
                if (rate == "1") {
                    $("#star1").prop("checked", true);
                }
                else if (rate == "2") {
                    $("#star2").prop("checked", true);
                }
                else if (rate == "3") {
                    $("#star3").prop("checked", true);
                }
                else if (rate == "4") {
                    $("#star4").prop("checked", true);
                }
                else if (rate == "5") {
                    $("#star5").prop("checked", true);
                }

                $('#ratingForm .rating').click(function () {
                    debugger;
                    if ($("#ratingForm input:radio:checked").length > 0) {
                        $("#<%= hdnRating.ClientID %>").val($('#ratingForm input:radio:checked').val());
                }
                });
            });
            var validFilesTypes = ["png", "jpg", "jpeg"];

            function ValidateFile() {
                var file = document.getElementById("<%=reviewImageUpload.ClientID%>");
                //var label = document.getElementById("<= Label1.ClientID%>");
                var path = file.value;
                var ext = path.substring(path.lastIndexOf(".") + 1, path.length).toLowerCase();
                var isValidFile = false;
                for (var i = 0; i < validFilesTypes.length; i++) {
                    if (ext == validFilesTypes[i]) {
                        isValidFile = true;
                        break;
                    }
                }
                if (!isValidFile) {
                    //label.style.color = "red";
                    //label.innerHTML = "Invalid File. Please choose a File with" +
                    //    " extension:\n\n" + validFilesTypes.join(", ");
                    alert("Invalid File. Please choose a File with" +
                        " extension:\n\n" + validFilesTypes.join(", "));
                }
                return isValidFile;
            }
        </script>
        <style type="text/css">
            .btn-cancel {
                position: absolute;
                right: -12px;
                top: -12px;
                width: 23px;
                background: #f00;
                height: 23px;
                border-radius: 50%;
            }

            .btn-icon {
                margin-left: 6px;
                color: #fff;
            }
        </style>
</asp:Content>
