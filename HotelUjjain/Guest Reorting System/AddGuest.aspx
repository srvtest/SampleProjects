<%@ Page Title="" Language="C#" UICulture="hi-IN" MasterPageFile="~/HotelMain.Master" AutoEventWireup="true" CodeBehind="AddGuest.aspx.cs" Inherits="Guest_Reporting_System.AddGuest" %>

<%--<%@ Register Assembly="AjaxControlToolKit" Namespace="AjaxControlToolKit" TagPrefix="d1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">--%>
    <link href='https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/ui-lightness/jquery-ui.css' rel='stylesheet'>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js">    </script>
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js">    </script>
    <%--<link href="../NewPanel/plugins/daterangepicker/daterangepicker.css" rel="stylesheet" />--%>
    <%--  <img src="New/assets/images/android-chrome-512x512.png" />--%>
    <style>
        .btnSubguest {
            width: 122px;
            margin-top: 5px;
            margin-left: 5px;
        }

        .btnFoot {
            text-align: center;
        }

        .imgAlign {
            float: left;
        }

        .UploadImg {
            width: 50px;
        }

        .lblCtrl {
            text-align: center;
            display: block;
        }

        .vbnpage {
            background: #ffffff;
            /* background: url(NewPanel/dist/schoolbg.jpg) no-repeat;
            background-size: cover;*/
        }

        .olul {
            margin-left: -17px;
            margin-right: 9px;
        }

        .CtrlBotSpace {
            margin-bottom: 5px;
        }

        @media only screen and (min-width: 600px) {
            .login-box-body {
                width: 410px;
            }

            .form-group {
                margin-bottom: 1px;
            }

            .UploadImg {
                width: 150px;
            }

            .olul {
                margin-left: 0px;
                margin-right: 0px;
            }
        }

        .modalign {
            align-content: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--    <c1:ToolkitScriptManager ID="toolScriptManageer1" runat="server"></c1:ToolkitScriptManager>--%>
    <div class="row" id="pnlUser">
        <!--Basic Form starts-->
        <div class="col-md-12 grid-margin stretch-card mx-auto">
            <div class="box box-primary">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <div class="card-body">
                    <h4 class="box-header with-border">
                        <asp:HiddenField ID="hdnPassword" runat="server" />
                        <asp:HiddenField ID="hdnsFruntFileName" runat="server" />
                        <asp:HiddenField ID="hdnsBackFileName" runat="server" />
                        <asp:HiddenField ID="hdnPryFront" runat="server" ClientIDMode="Static" />
                        <asp:HiddenField ID="hdnPryBack" runat="server" ClientIDMode="Static" />
                        <asp:Label ID="Label1" runat="server">अतिथि की जानकारी दर्ज करें</asp:Label>
                    </h4>
                    <p class="box-header">
                        <asp:Label ID="Label2" runat="server" CssClass="lblCtrl"><b>|| कृपया ध्यान दें ||</b></asp:Label>
                        <ol class="olul" type="1">
                            <li>इस फॉर्म के माध्यम से आप गेस्ट  की एंट्री  सेव कर रहे हैं। इसे थाने में भेजने के लिए कृपया पेंडिंग रिपोर्ट में जाकर  इस रिपोर्ट को सबमिट करें।</li>
                            <li>एक बार रिपोर्ट थाने में सबमिट करने के बाद उस तारीख के लिए आप कोई नए गेस्ट की एंट्री नहीं कर पाएंगे।</li>
                            <li>आप सिर्फ आज (Today) और कल (Yesterday) के चेक-इन के लिए ही एंट्री कर सकते हैं।</li>
                            <li>5MB से अधिक की इमेज अपलोड नहीं हो पाएगी। कृपया इमेज का साइज कम करके अपलोड करें।</li>
                            <li>होटलों की जिम्मेदारी है कि वे वेबसाइट के माध्यम से सबमिट की गई सभी अतिथि जानकारी की सटीकता और वैधता सुनिश्चित करें। इसमें अतिथि के नाम, मोबाइल नंबर, और आधार विवरण की पुष्टि शामिल है।</li>
                        </ol>
                    </p>
                    <hr />
                    <h4 class="box-header with-border">
                        <asp:Label ID="lbl4" runat="server">प्राथमिक अतिथि की जानकारी</asp:Label>
                        <div style="float: right">
                            <asp:Button ID="Button1" runat="server" Text="सेव करे" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                            <asp:Button ID="Button2" runat="server" Text="रद्द करें" CssClass="btn btn-danger" CausesValidation="false" OnClick="btnCancel_Click" />
                        </div>
                    </h4>
                    <div class="box-body">
                        <asp:HiddenField ID="hdGuestMasterId" runat="server" Value="0" />
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>कृपया गेस्ट के चेक इन की तारीख चुने <span class="text-danger">*</span></label>
                                    <asp:DropDownList ID="ddlCheckIn" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCheckIn_SelectedIndexChanged" onchange="javascript:setDateLimit();">
                                    </asp:DropDownList>
                                    <%--</br>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlCheckIn" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया चेक इन तिथि दर्ज करें।"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>चेक आउट तारीख <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtCheckOutDate" runat="server" CssClass="form-control" placeholder="dd-MM-yyyy" ClientIDMode="Static" onkeypress="return allowDateCharacters(event)"></asp:TextBox>
                                    <%-- <d1:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" runat="server" TargetControlID="txtCheckOutDate" Format="dd/MM/yyyy"></d1:CalendarExtender>--%>
                                    <%--</br>--%>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="txtCheckOutDate" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया चेक आउट तिथि दर्ज करें।"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <contenttemplate>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>यात्रियों की कुल संख्या</label>
                                            <asp:DropDownList ID="ddlAddGustCnt" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" onchange="setDateLimit();">
                                                <asp:ListItem Text="1"></asp:ListItem>
                                                <asp:ListItem Text="2"></asp:ListItem>
                                                <asp:ListItem Text="3"></asp:ListItem>
                                                <asp:ListItem Text="4"></asp:ListItem>
                                                <asp:ListItem Text="5"></asp:ListItem>
                                                <asp:ListItem Text="6"></asp:ListItem>
                                                <asp:ListItem Text="7"></asp:ListItem>
                                                <asp:ListItem Text="8"></asp:ListItem>
                                                <asp:ListItem Text="9"></asp:ListItem>
                                                <asp:ListItem Text="10"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>यात्रा का उद्देश्य <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddlTrevelReson" runat="server" CssClass="form-control">
                                                <asp:ListItem>दर्शन</asp:ListItem>
                                                <asp:ListItem>अध्ययन या सेमिनार</asp:ListItem>
                                                <asp:ListItem>सत्संग</asp:ListItem>
                                                <asp:ListItem>पारिवारिक या मित्रों से मिलना</asp:ListItem>
                                                <asp:ListItem>व्यापारिक या व्यावसायिक यात्रा</asp:ListItem>
                                                <asp:ListItem>अन्य</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--</br>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatoResun" ControlToValidate="ddlTrevelReson" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया यात्रा का कारण चुनें।"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <%--  </div>--%>


                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>पूरा नाम <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control CtrlBotSpace" placeholder="पूरा नाम दर्ज करें।" MaxLength="25"></asp:TextBox>
                                            <%--</br>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtFirstName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया पूरा नाम दर्ज करें।"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtFirstName" ErrorMessage="कृपया पूरा नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।" ValidationExpression="^[A-Za-z ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>जेंडर<span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddlFirstSex" runat="server" CssClass="form-control">
                                                <asp:ListItem>पुरुष</asp:ListItem>
                                                <asp:ListItem>महिला</asp:ListItem>
                                                <asp:ListItem>अन्य</asp:ListItem>
                                            </asp:DropDownList>
                                            <%--</br>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatoSex" ControlToValidate="ddlFirstSex" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया लिंग चुनें।"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </div>
                                <div class="row" style="margin-top: 20px;">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>मोबाइल नंबर <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control CtrlBotSpace" placeholder="संपर्क नंबर दर्ज करें" MaxLength="12"></asp:TextBox>
                                            <%--</br>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtContactNo" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया संपर्क नंबर दर्ज करें।"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContactNo" ErrorMessage="कृपया वैध संपर्क नंबर दर्ज करें। कृपया अंक दर्ज करें।" ValidationExpression="^[0-9 ]{10}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%--   <div class="col-md-4">
                                <div class="form-group">
                                    <label>अंतिम नाम <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtGuestLastName" runat="server" CssClass="form-control" placeholder="अंतिम नाम दर्ज करें।" MaxLength="25"></asp:TextBox>
                                    </br>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorlast" ControlToValidate="txtGuestLastName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया अंतिम नाम दर्ज करें।"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtGuestLastName" ErrorMessage="कृपया अंतिम नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।" ValidationExpression="^[A-Za-z ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>--%>

                                    <%--<div class="row" style="margin-top: 20px;">--%>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>आईडी प्रकार <span class="text-danger">*</span></label>
                                            <asp:DropDownList ID="ddlIDType" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="myFunction()">
                                                <asp:ListItem Text="आधार कार्ड"></asp:ListItem>
                                                <asp:ListItem Text="पासपोर्ट"></asp:ListItem>
                                                <asp:ListItem Text="वोटर आईडी कार्ड"></asp:ListItem>
                                                <asp:ListItem Text="ड्राइविंग लाइसेंस"></asp:ListItem>
                                                <asp:ListItem Text="पैन कार्ड"></asp:ListItem>
                                                <asp:ListItem Text="राशन कार्ड"></asp:ListItem>
                                                <asp:ListItem Text="सरकारी कर्मचारी पहचान पत्र"></asp:ListItem>
                                                <asp:ListItem Text="विदेशियों का पंजीकरण कार्ड (FRC)"></asp:ListItem>
                                                <asp:ListItem Text="कोई अन्य सरकारी जारी किया गया पहचान पत्र"></asp:ListItem>
                                            </asp:DropDownList>
                                            <%--  </br>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5_1" ControlToValidate="ddlIDType" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया पहचान प्रकार दर्ज करें।"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>आईडी नंबर<span class="text-danger">*</span></label>
                                            <span style="position: relative;">
                                                <asp:TextBox ID="txtIdentificationNo" runat="server" CssClass="form-control CtrlBotSpace" placeholder="पहचान संख्या दर्ज करें।" MaxLength="25"></asp:TextBox>
                                                <img src="NewPanel/images/download.png" id="validImage" width="20" style="position: absolute; right: 5px; top: 30px; display: none;" />
                                            </span>
                                            <%-- </br>--%>
                                            <asp:CustomValidator ID="CustomValidator3" runat="server" ForeColor="Red" ControlToValidate="txtIdentificationNo" ClientValidationFunction="checkValidation"></asp:CustomValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtIdentificationNo" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया पहचान संख्या दर्ज करें।"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <%--<div class="col-md-3">
                                <div class="form-group">
                                    <label>पता <span class="text-danger">*</span></label>
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control CtrlBotSpace" placeholder="पता दर्ज करें।" MaxLength="100"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2_1" ControlToValidate="txtAddress" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया पता दर्ज करें।"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txtAddress" ErrorMessage="कृपया पता दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।" ValidationExpression="^.{1,100}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>--%>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>शहर <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control CtrlBotSpace" placeholder="शहर दर्ज करें।" MaxLength="25"></asp:TextBox>
                                            <%--</br>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2_2" ControlToValidate="txtCity" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया शहर दर्ज करें।"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="txtCity" ErrorMessage="कृपया शहर दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।" ValidationExpression="^[A-Za-z ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%--  </div>
<div class="row">--%>
                                </div>
                                <div class="row" runat="server" id="UploadDoc" style="margin-top: 20px;">
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>फ्रंटसाइड आईडी अपलोड करें<span class="text-danger">*</span></label>
                                            <%--<input id="FileUploadFrunt" type="file" runat="server" class="CtrlBotSpace" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."/>--%>
                                            <asp:FileUpload ID="FileUploadFrunt" runat="server" CssClass="CtrlBotSpace PmyFront" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." />
                                            <asp:Image ID="Image1" runat="server" CssClass="imgAlign UploadImg" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="FileUploadFrunt" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="आईडी का Front अपलोड करें। केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cvvalidate" runat="server"
                                                ToolTip="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ForeColor="Red"
                                                ErrorMessage="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."
                                                ControlToValidate="FileUploadFrunt" Display="Dynamic"
                                                ClientValidationFunction="checksize">
                                            </asp:CustomValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="FileUploadFrunt" ForeColor="Red"
                                                ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।" Display="Dynamic"
                                                ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>बैकसाइड आईडी अपलोड करें<span class="text-danger">*</span></label>
                                            <asp:FileUpload ID="FileUploadBack" runat="server" CssClass="CtrlBotSpace PmyBack" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." />
                                            <asp:Image ID="Image2" runat="server" CssClass="imgAlign UploadImg" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="FileUploadBack" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="आईडी का Back अपलोड करें। केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."></asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="CustomValidator1" runat="server"
                                                ToolTip="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ForeColor="Red"
                                                ErrorMessage="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."
                                                ControlToValidate="FileUploadBack" Display="Dynamic"
                                                ClientValidationFunction="checksize1">
                                            </asp:CustomValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileUploadBack" ForeColor="Red"
                                                ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।" Display="Dynamic"
                                                ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <%-- <div class="col-md-3">
                                        <div class="form-group">
                                            <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                                            <asp:Label ID="Label4" runat="server" Visible="false"></asp:Label>
                                        </div>
                                    </div>--%>
                                </div>
                                </br>
                        <%-- </div>
                            
                    <div class="box-body">--%>
                                <%-- <h4 class="box-header with-border">अतिरिक्त अतिथि</h4>--%>

                                <asp:Repeater ID="rptGuest" runat="server" OnItemDataBound="rptGuest_ItemDataBound">
                                    <headertemplate>
                                    </headertemplate>
                                    <itemtemplate>
                                        <div class="row">
                                            <asp:HiddenField ID="hdnGuestPassword" runat="server" Value='<%#Eval("filePass")%>' />
                                            <asp:HiddenField ID="hdnsFileName" runat="server" Value='<%#Eval("Image")%>' />
                                            <asp:HiddenField ID="hdnsFileNameBack" runat="server" Value='<%#Eval("Image2")%>' />
                                            <asp:HiddenField ID="hdnIdGuestDetail" runat="server" Value='<%#Eval("idGuestDetail")%>' />
                                            <h4 class="box-header with-border">अतिरिक्त अतिथि <%# Container.ItemIndex + 1 %></h4>
                                        </div>
                                        <div class="row SecGuest">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>पूरा नाम <span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txtSecGuestFirstName" runat="server" CssClass="form-control CtrlBotSpace" placeholder="पूरा नाम दर्ज करें।" Text='<%#Eval("sName")%>' MaxLength="25"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtSecGuestFirstName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया पूरा नाम दर्ज करें।"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtSecGuestFirstName" ErrorMessage="कृपया पूरा नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।" ValidationExpression="^[A-Za-z0-9 ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <%--<div class="col-md-4">
                                        <div class="form-group">
                                            <label>अंतिम नाम <span class="text-danger">*</span></label>
                                            <asp:TextBox ID="txtSecGuestLastName" runat="server" CssClass="form-control" placeholder="अंतिम नाम दर्ज करें।" Enabled="false" Text='<%#Eval("LastName")%>' MaxLength="25"></asp:TextBox>
                                            </br>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorlast" ControlToValidate="txtSecGuestLastName" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया अंतिम नाम दर्ज करें।"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="txtSecGuestLastName" ErrorMessage="कृपया अंतिम नाम दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।" ValidationExpression="^[A-Za-z0-9 ]+$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </div>
                                    </div>--%>
                                            <%--   </div>
                                  <div class="row">--%>

                                            <div class="col-md-3 rptCont">
                                                <div class="form-group">
                                                    <label>मोबाइल नंबर <span class="text-danger"></span></label>
                                                    <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control CtrlBotSpace" placeholder="संपर्क नंबर दर्ज करें।" Text='<%#Eval("ContactNo")%>' MaxLength="12"></asp:TextBox>
                                                    <%-- </br>--%>
                                                    <%--<asp:CustomValidator ID="CustomValidator5" runat="server" ForeColor="Red" ControlToValidate="txtContactNumber" Display="Dynamic" ClientValidationFunction="chkValidateContact"></asp:CustomValidator>--%>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtContactNumber" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया संपर्क नंबर दर्ज करें।"></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtContactNumber" ErrorMessage="कृपया वैध संपर्क नंबर दर्ज करें। कृपया अंक दर्ज करें।" ValidationExpression="^[0-9]{10}$" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <%--     </div>
                                <div class="row ">--%>
                                            <div class="col-md-3 rptDrop">
                                                <div class="form-group">
                                                    <label>आईडी प्रकार <span class="text-danger">*</span></label>
                                                    <asp:DropDownList ID="ddlSecGuestIDType" runat="server" CssClass="form-control" ClientIDMode="Static" onchange="myFunction()">
                                                        <asp:ListItem Text="आधार कार्ड"></asp:ListItem>
                                                        <asp:ListItem Text="ड्राइविंग लाइसेंस"></asp:ListItem>
                                                        <asp:ListItem Text="पैन कार्ड"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%-- </br>--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5_1" ControlToValidate="ddlSecGuestIDType" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया पहचान प्रकार दर्ज करें।"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>आईडी नंबर<span class="text-danger">*</span></label>
                                                    <asp:TextBox ID="txtSecGuestIdentificationNo" runat="server" CssClass="form-control CtrlBotSpace" placeholder="Enter Identification No" Text='<%#Eval("IdentificationNo")%>' MaxLength="25"></asp:TextBox>
                                                    <%--</br>--%>
                                                    <img src="NewPanel/images/download.png" id="validImage1" width="20" style="position: absolute; right: 20px; top: 33px; display: none;" />
                                                    <asp:CustomValidator ID="CustomValidator3" runat="server"
                                                        ForeColor="Red"
                                                        ControlToValidate="txtSecGuestIdentificationNo" Display="Dynamic"
                                                        ClientValidationFunction="checkValidationRpt">
                                                    </asp:CustomValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtSecGuestIdentificationNo" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया पहचान संख्या दर्ज करें।"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="row" style="margin-top: 20px;">
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>जेंडर<span class="text-danger">*</span></label>
                                                    <asp:DropDownList ID="ddlSecGuestFirstSex" runat="server" CssClass="form-control">
                                                        <asp:ListItem>पुरुष</asp:ListItem>
                                                        <asp:ListItem>महिला</asp:ListItem>
                                                        <asp:ListItem>अन्य</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <%--</br>--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatoSex" ControlToValidate="ddlSecGuestFirstSex" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया लिंग चुनें।"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div id="FrontId" class="form-group">
                                                    <label>आईडी का Front अपलोड करें<span class="text-danger">*</span></label>
                                                    <asp:FileUpload ID="FileSecGuestUpload1" CssClass="demo CtrlBotSpace" runat="server" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।\nफ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="FileSecGuestUpload1" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="आईडी का Front अपलोड करें। केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."></asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="CustomValidator4" runat="server"
                                                        ToolTip="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ForeColor="Red"
                                                        ErrorMessage="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."
                                                        ControlToValidate="FileSecGuestUpload1" Display="Dynamic"
                                                        ClientValidationFunction="checksize2">
                                                    </asp:CustomValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="FileSecGuestUpload1" ForeColor="Red"
                                                        ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।" Display="Dynamic"
                                                        ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Image ID="Image3" runat="server" CssClass="imgAlign" Width="150px" />
                                                    <%--  <label runat="server" ID="lblmasg"></label>--%>
                                                    <%--</br>--%>
                                                </div>
                                            </div>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <label>आईडी का Back अपलोड करें<span class="text-danger">*</span></label>
                                                    <asp:FileUpload ID="FileSecGuestUpload2" runat="server" CssClass="CtrlBotSpace" accept=".png,.jpg,.jpeg,.JPG,.PNG" ToolTip="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।\nफ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="FileSecGuestUpload2" runat="server" ForeColor="Red" Display="Dynamic" ErrorMessage="आईडी का Back अपलोड करें। केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है। फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..."></asp:RequiredFieldValidator>
                                                    <asp:CustomValidator ID="CustomValidator2" runat="server"
                                                        ToolTip="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." ForeColor="Red"
                                                        ErrorMessage="फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए..." Display="Dynamic"
                                                        ControlToValidate="FileSecGuestUpload2" ClientValidationFunction="checksize3">
                                                    </asp:CustomValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="FileSecGuestUpload2" ForeColor="Red"
                                                        ErrorMessage="केवल .jpg, .JPG, .jpeg, .png और .PNG छवि प्रारूपों की अनुमति है।" Display="Dynamic"
                                                        ValidationExpression="^(.*?)\.(jpg|JPG|jpeg|JPEG|png|PNG)$">
                                                    </asp:RegularExpressionValidator>
                                                    <asp:Image ID="Image4" runat="server" CssClass="imgAlign" Width="150px" />
                                                </div>
                                            </div>
                                            <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <asp:Button ID="btnUploadAdd" runat="server" Text="Upload" OnClick="btnUploadAdd_Click" />

                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnUploadAdd" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <div class="col-md-3">
                                                <div class="form-group">
                                                    <asp:Label ID="Label5" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>--%>
                                        </div>

                                        <div class="row" id="filetypeload" runat="server">
                                        </div>
                                        <div class="row">
                                            <hr />
                                        </div>
                                    </itemtemplate>
                                    <footertemplate>
                                        <%--  <span id="spnError1" class="error" style="display: none; color: red; margin-left: 15px;">फ़ाइल का आकार 5MB से अधिक नहीं होना चाहिए...</span>--%>
                                    </footertemplate>
                                </asp:Repeater>

                                <%--  <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Please select at least one record." ClientValidationFunction="ValidateFileUpload" ForeColor="Red"></asp:CustomValidator>--%>

                                <div class="row" id="Cat" style="margin-top: 20px;">
                                    <asp:Repeater ID="rptCategory" runat="server">
                                        <headertemplate>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <label style="margin-left: 14px;">अतिथि को दिए हुए कमरे की श्रेणी चुनें। <span class="text-danger">*</span></label>
                                                    </div>
                                                </div>
                                            </div>
                                            <%--<table id="example3" class="table table-bordered table-striped" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>S. No.</th>
                                                <th>Action</th>
                                                <th>कमरे की श्रेणी</th>
                                                <th>मूल्य</th>
                                            </tr>
                                        </thead>
                                        <tbody>--%>
                                        </headertemplate>
                                        <itemtemplate>
                                            <div class="col-sm-4">
                                                <div class="form-group">
                                                    <asp:CheckBox ID="ChkSelect" runat="server" Checked='<%#Eval("bChecked")%>' />
                                                    <label><%#Eval("CategoryName")%> -</label>
                                                    <label><%#Eval("iPrice")%></label>
                                                    <asp:HiddenField ID="hdnidHotelRoomCategory" runat="server" Value='<%#Eval("idHotelRoomCategory")%>' />
                                                    <asp:HiddenField ID="hdnCategoryName" runat="server" Value='<%#Eval("CategoryName")%>' />
                                                    <asp:HiddenField ID="hdniPrice" runat="server" Value='<%#Eval("iPrice")%>' />
                                                    <%--<asp:RequiredFieldValidator ID="reqValidator" runat="server" ControlToValidate="ChkSelect" ForeColor="Red" Display="Dynamic" ErrorMessage="कृपया कम से कम एक का चयन करें"></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>
                                        </itemtemplate>
                                        <footertemplate>
                                            <%--</tbody>
</table>--%>
                                            <div id="spnError" class="error" style="display: none; color: red; margin-left: 15px;">कृपया कम से कम एक का चयन करें।</div>
                                        </footertemplate>
                                    </asp:Repeater>
                                    <%--    <asp:CustomValidator ID="CustomValidator5" runat="server" ErrorMessage="कृपया कम से कम एक का चयन करें।"
                                ClientValidationFunction="Validate" ForeColor="Red"></asp:CustomValidator>--%>
                                </div>
                            </contenttemplate>
                            <triggers>
                                <%--<asp:PostBackTrigger ControlID="btnUpload" />--%>
                                <%-- <asp:PostBackTrigger ControlID="ddlAddGustCnt" />--%>
                            </triggers>
                        </asp:UpdatePanel>
                    </div>
                    <h4 class="box-header">
                        <div style="float: right;">
                            <%--<asp:Button ID="btnSubmit" runat="server" Text="सहेजें" OnClientClick="return Validate()" CssClass="btn btn-primary me-2" OnClick="btnSubmit_Click" />--%>
                            <asp:Button ID="btnSubmit" runat="server" Text="सेव करे" CssClass="btn btn-success me-2" OnClientClick="return Validate()" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnCancel" runat="server" Text="रद्द करें" CssClass="btn btn-danger" CausesValidation="false" OnClick="btnCancel_Click" />
                        </div>
                    </h4>
                </div>
            </div>
        </div>
    </div>


    <!-- Button trigger modal -->
    <%--   <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#saveModal">
            Launch demo modal
        </button>--%>

    <!-- Modal -->
    <div class="modal fade modalign" id="saveModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel" style="text-align: center;">Save Records</h5>
                    <button type="button" style="position: absolute; right: 16px; top: 18px;" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <span id="lblMessage" runat="server"></span>
                    <%--<span id="Span1" runat="server"><i class="fa fa-exclamation-triangle fa-2x"></i>गेस्ट की एंट्री  सेव हो गयी है | आप अन्य गेस्ट की जानकारी ऐड कर सकते है या पेंडिंग रिपोर्ट पे जेक इस रिपोर्ट को सबमिट कर सकते है </span>--%>
                    <span id="Span1" runat="server"><i class="fa fa-exclamation-triangle fa-2x"></i>गेस्ट की एंट्री सफलतापूर्वक सेव हो गई है। आप चाहें तो अन्य गेस्ट की जानकारी जोड़ सकते हैं, या पेंडिंग रिपोर्ट पर जाकर इस रिपोर्ट को सबमिट कर सकते हैं। </span>
                </div>
                <div class="modal-footer btnFoot">
                    <a href="Dashboard.aspx" class="btn btn-primary me-2 btnSubguest">ठीक है</a>
                    <a href="AddGuest.aspx" id="btnGuestAdd" class="btn btn-info me-2 btnSubguest">अन्य  गेस्ट  जोड़ें</a>
                    <a href="pendingSummery.aspx" id="btnPan" class="btn btn-success me-2 btnSubguest">रिपोर्ट सबमिट करें</a>
                    <a href="pendingSummery.aspx" id="btnSum" class="btn btn-success me-2 btnSubguest">रिपोर्ट देखें</a>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalign" id="messageModal" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="messageModalLabel" style="text-align: center;">महत्वपूर्ण संदेश</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><span runat="server" id="lblMessage1"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <button type="button" class="btn btn-primary me-2" data-dismiss="modal">ठीक है</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalign" id="errorModal" tabindex="-1" aria-labelledby="errorModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="errorModalLabel" style="text-align: center;">Save Records</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><span id="Spnerror" runat="server"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <a href="Dashboard.aspx" class="btn btn-primary me-2" data-dismiss="modal">ठीक है</a>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalign" id="saveModal2" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel2" style="text-align: center;">त्रुटि रिकॉर्ड</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><span id="Span2" runat="server"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <button type="button" class="btn btn-primary me-2" data-dismiss="modal">ठीक है</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalign" id="saveModal3" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel3" style="text-align: center;">त्रुटि रिकॉर्ड</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i><span id="lblMessage2" runat="server"></span>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <a href="setting.aspx" class="btn btn-primary me-2">ठीक है</a>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade modalign" id="saveModal4" tabindex="-1" aria-labelledby="saveModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <h5 class="modal-title" id="saveModalLabel4" style="text-align: center;">महत्वपूर्ण संदेश</h5>
                    <button type="button" class="close" style="position: absolute; right: 16px; top: 18px;" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                </div>
                <div class="modal-body">
                    <i class="fa fa-exclamation-triangle fa-2x"></i>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </div>
                <div class="modal-footer" style="text-align: center;">
                    <button type="button" class="btn btn-primary me-2" data-dismiss="modal">ठीक है</button>
                </div>
            </div>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"></script>
    <%--    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>--%>
   <%-- <script src="../NewPanel/plugins/jquery/jquery.min.js"></script>
    <script src="../NewPanel/plugins/daterangepicker/daterangepicker.js"></script>--%>
    <script type="text/javascript">
        <%--function HideLabel() {
            var fileUpload = $(source).closest('.form-group').children('label');
            alert(fileUpload);
            var seconds = 5;
            setTimeout(function () {
                document.getElementById("<%=Label4.ClientID %>").style.display = "none";                
            }, seconds * 1000);
        };--%>
        //$(function () {
        //    var fileUpload = $("[id*=fuUpload]");
        //    var img = $("[id*=Image1]");
        //    img.click(function () { fileUpload.click(); });
        //    fileUpload.change(function () {
        //        alert("hi");
        //        $('[id*=btnUpload]').click();
        //    });
        //});
      <%--  $(document).ready(function () {

            // Detect change event on file input with the class 'file-upload'
            $(".PmyFront").change(function () {
                var fileName = $(this).val().split("\\").pop(); // Get the selected file name
                //alert("File selected: " + fileName);

                // Optionally, set the value of a hidden field or perform any other action
                $("#<%= hdnPryFront.ClientID %>").val(fileName); // Example for setting hidden field
            });
            $(".PmyBack").change(function () {
                var fileName = $(this).val().split("\\").pop(); // Get the selected file name
                //alert("File selected: " + fileName);

                // Optionally, set the value of a hidden field or perform any other action
                $("#<%= hdnPryBack.ClientID %>").val(fileName); // Example for setting hidden field
            });
            //setFilecontrolValue();
        });
        function setFilecontrolValue() {
            var fileName = $(".PmyFront").val().split("\\").pop();
            alert(fileName);
            if (fileName == "") {
                var front = $("#<%= hdnPryFront.ClientID %>").val();
                alert(front);
                if (front != "") {
                    fileName.attr("name", front);
                   // $(".PmyFront").val(front);
                }
            }
            var fileName1 = $(".PmyBack").val().split("\\").pop();
            alert(fileName1);
            if (fileName1 == "") {
                var front1 = $("#<%= hdnPryBack.ClientID %>").val();
                alert(front1);
                if (front1 != "") {
                    $(".PmyBack").val(front1);
                }
            }
        }--%>
        function SaveGuestData() {
            $('#saveModal').modal('show');
            return false;

        }
        function MessageShow() {
            $('#saveModal2').modal('show');
            /*return false;*/

        }
        function ShowError() {
            $('#errorModal').modal('show');
            /*return false;*/

        }
        function SHOWmESSAGE(SmSG) {
            $('#messageModal').modal('show');
            /*return false;*/

        }
        function SHOWmESSAGEUpload(SmSG) {
            $('#saveModal4').modal('show');
            /*return false;*/

        }
        function SaveGuestData1() {
            $('#saveModal3').modal('show');
            /* return false;*/
        }
        function checksize(source, arguments) {
            arguments.IsValid = false;
            var size = document.getElementById("<%=FileUploadFrunt.ClientID%>").files[0].size;
            if (size > 5242880) {
                arguments.IsValid = false;
                return false;
            }
            else {
                arguments.IsValid = true;
                return true;
            }
        }
        function checksize1(source, arguments) {
            arguments.IsValid = false;
            var size1 = document.getElementById("<%=FileUploadBack.ClientID%>").files[0].size;
            if (size1 > 5242880) {
                arguments.IsValid = false;
                return false;
            }
            else {
                arguments.IsValid = true;
                return true;
            }
        }
        function checksize2(source, arguments) {
            arguments.IsValid = false;
            var fileUpload = $(source).closest('.form-group').children('input');
            var size2 = $(fileUpload)[0].files[0].size;
            if (size2 > 5242880) {
                arguments.IsValid = false;
                return false;
            }
            else {
                arguments.IsValid = true;
                return true;
            }
        }
        function checksize3(source, arguments) {
            arguments.IsValid = false;
            var fileUpload = $(source).closest('.form-group').children('input');
            var size3 = $(fileUpload)[0].files[0].size;
            if (size3 > 5242880) {
                arguments.IsValid = false;
                return false;
            }
            else {
                arguments.IsValid = true;
                return true;
            }
        }
        function checkValidation(source, arguments) {
            $('#validImage').hide();
            arguments.IsValid = false;
            var valid = $("#<%=ddlIDType.ClientID%> option:selected").text();
            var vaLUE = $("#<%=txtIdentificationNo.ClientID%>").val();
            switch (valid) {
                case "आधार कार्ड":
                    var re = new RegExp('^[2-9 ]{1}[0-9 ]{3}[0-9 ]{4}[0-9 ]{4}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना आधार कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "ड्राइविंग लाइसेंस":
                    var re = new RegExp('^(([A-Z ]{2}[0-9 ]{2})( )|([A-Z ]{2}-[0-9 ]{2}))((19|20)[0-9 ][0-9 ])[0-9 ]{7}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना ड्राइविंग लाइसेंस नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "पासपोर्ट":
                    var re = new RegExp('^(?!^0+$)[a-zA-Z0-9 ]{3,20}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना पासपोर्ट नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "वोटर आईडी कार्ड":
                    var re = new RegExp('^[A-Z ]{3}[0-9 ]{7}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना वोटर आईडी कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "पैन कार्ड":
                    var re = new RegExp('^[A-Z ]{5}[0-9 ]{4}[A-Z ]{1}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना पैन कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "राशन कार्ड":
                    var re = new RegExp('^([a-zA-Z0-9 ]){8,12}\s*$');
                    var check = re.test(vaLUE);
                    if (check) {
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना राशन कार्ड जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                default:
                    var re = new RegExp('^(?=.*\d).{5,}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('कृपया वैध आईडी दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                // code block
            }
            arguments.IsValid = false;
            return false;
        }
        $(document).ready(function () {
            setDateLimit();
        });

        function setDateLimit() {
            var vaL = $("#<%=ddlCheckIn.ClientID%>").val();
            // alert(vaL)
            if (vaL == 'Today') {
                var options = { minDate: 0, dateFormat: "dd-MM-yy" };
                var additionalOptions = $('#txtCheckOutDate').data("datepicker");
                jQuery.extend(options, additionalOptions);
                $('#txtCheckOutDate').datepicker(options);
                var options = { minDate: 0, dateFormat: "dd-MM-yy" };
                var additionalOptions = $('#txtCheckOutDate').data("datepicker");
                jQuery.extend(options, additionalOptions);
                $('#txtCheckOutDate').datepicker(options).attr('readonly', 'readonly');
                //$("#txtCheckOutDate").prop("readonly", true);
                //document.getElementById("txtCheckOutDate").readOnly = true;
            }
            else {
                var options = { minDate: -1, dateFormat: "dd-MM-yy" };
                var additionalOptions = $('#txtCheckOutDate').data("datepicker");
                jQuery.extend(options, additionalOptions);
                $('#txtCheckOutDate').datepicker(options);
                var options = { minDate: -1, dateFormat: "dd-MM-yy" };
                var additionalOptions = $('#txtCheckOutDate').data("datepicker");
                jQuery.extend(options, additionalOptions);
                $('#txtCheckOutDate').datepicker(options).attr('readonly', 'readonly');
                //$("#txtCheckOutDate").prop("readonly", true);
                //document.getElementById("txtCheckOutDate").readOnly = true;
            }
        }
        //$("#txtCheckOutDate").keypress(function (e) {
        //    e.preventDefault();
        //});
        //$("#txtCheckOutDate").keydown(function (e) {
        //    e.preventDefault();
        //});

        function allowDateCharacters(event) {
            var char = String.fromCharCode(event.keyCode);
            if (!/[0-9\/]/.test(char)) {
                event.preventDefault();
                return false;
            }
            return true;
        }
        function myFunction() {
            Page_ClientValidate();
            //Validate();
        }
        function Validate() {
            myFunction();
            //var valid = $(source).closest('.Cat').children('.col-md-4:first-child').find('input').val();
            //console.log(valid);
            //Reference the Table containing Group of CheckBoxes.
            var table = document.getElementById("Cat");
            var checkBoxes = $(table).find('input[type="checkbox"]')
            //Reference the Group of CheckBoxes.
            //var checkBoxes = table.getElementsByTagName("input[type='checkbox']");
            //Set the Valid Flag to False initially.
            var isValid = false;

            //Loop and verify whether at-least one CheckBox is checked.
            for (var i = 0; i < checkBoxes.length; i++) {
                if (checkBoxes[i].checked) {
                    isValid = true;
                    break;
                }
            }

            //Display error message if no CheckBox is checked.
            document.getElementById("spnError").style.display = isValid ? "none" : "block";
            return isValid;
        }
        //function chkValidateContact(source, arguments) {
        //    arguments.IsValid = false;
        //    var valid = $(source).closest('.SecGuest').children('.rptDrop').find('input').val();
        //    var vaLUE = $(source).closest('.form-group').children('input').val();
        //    alert(valid);
        //    alert(vaLUE);
        //    if (vaLUE = "") {
        //        $(source).closest('.form-group').children('input').val() = "NA";
        //    }
        //    else {
        //        $(source).closest('.form-group').children('input').val() = "";
        //    }
        //}
        function checkValidationRpt(source, arguments) {
            arguments.IsValid = false;
            var valid = $(source).closest('.SecGuest').children('.rptDrop').find('select').val();
            var vaLUE = $(source).closest('.form-group').children('input').val();
            var img = $(source).closest('.form-group').children('img');
            $(img).hide();
            switch (valid) {
                case "आधार कार्ड":
                    var re = new RegExp('^[2-9 ]{1}[0-9 ]{3}[0-9 ]{4}[0-9 ]{4}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $(img).show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना आधार कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "ड्राइविंग लाइसेंस":
                    var re = new RegExp('^(([A-Z ]{2}[0-9 ]{2})( )|([A-Z ]{2}-[0-9 ]{2}))((19|20)[0-9 ][0-9 ])[0-9 ]{7}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $(img).show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना ड्राइविंग लाइसेंस नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "पासपोर्ट":
                    var re = new RegExp('^(?!^0+$)[a-zA-Z0-9 ]{3,20}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना पासपोर्ट नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "वोटर आईडी कार्ड":
                    var re = new RegExp('^[A-Z ]{3}[0-9 ]{7}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $('#validImage').show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना वोटर आईडी कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "पैन कार्ड":
                    var re = new RegExp('^[A-Z ]{5}[0-9 ]{4}[A-Z ]{1}$');
                    vaLUE = vaLUE.toUpperCase();
                    var check = re.test(vaLUE);
                    if (check) {
                        $(img).show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना पैन कार्ड नंबर जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                case "राशन कार्ड":
                    var re = new RegExp('^([a-zA-Z0-9 ]){8,12}\s*$');
                    var check = re.test(vaLUE);
                    if (check) {
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('अपना राशन कार्ड जांचें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                default:
                    var re = new RegExp('^(?=.*\d).{5,}$');
                    var check = re.test(vaLUE);
                    if (check) {
                        $(img).show();
                        arguments.IsValid = true;
                        return true;
                    }
                    else {
                        $(source).text('कृपया वैध आईडी दर्ज करें। कृपया केवल अंग्रेजी अक्षरों का ही उपयोग करे।');
                    }
                    break;
                // code block
            }
            arguments.IsValid = false;
            return false;
        }
        //var btns = $('#txtFirstName,#txtGuestLastName,#txtAddress,#txtCity');
        //$(btns).bind('keyup blur', function () {
        //    $(this).val($(this).val().replace(/[^A-Za-z0-9]/g, ''))
        //});
        //var btns1 = $('#txtContactNo,#txtPinCode');
        //$(btns1).bind('keyup blur', function () {
        //    $(this).val($(this).val().replace(/[^0-9]/g, ''))
        //});
    </script>
</asp:Content>
