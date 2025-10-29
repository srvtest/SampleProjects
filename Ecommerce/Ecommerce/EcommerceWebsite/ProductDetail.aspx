<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="EcommerceWebsite.ProductDetail" %>

<%@ MasterType VirtualPath="~/Main.Master" %>
<%--<%@ Register Src="~/UCTopCategory.ascx" TagPrefix="uc1" TagName="UCTopCategory" %>--%>
<%@ Register Src="~/UCTopProducts.ascx" TagPrefix="uc1" TagName="UCTopProducts" %>
<%@ Register Src="~/UCbrandcarouse.ascx" TagPrefix="uc1" TagName="UCbrandcarouse" %>

<%@ Register Src="UCRelatedProduct.ascx" TagName="UCRelatedProduct" TagPrefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Font Awesome Icon Library -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
    <style>
        .no-visible {
            display: none;
        }

        .visible {
            display: block;
        }

        .videosize {
            height: 85px;
            width: 115px;
        }

        #myDiv.fullscreen {
            z-index: 9999;
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0;
            left: 0;
        }

        #myDiv {
            background: #cc0000;
        }

        .btnCart {
            border: 1px solid #030303;
            border-radius: 5px;
            color: white;
            /*padding: 7px 7px 7px 50px;*/
            background: url() left 3px top 3px no-repeat #030303;
            font-weight: 600;
            text-transform: uppercase;
            width: 140px;
            height: 40px;
            margin-left: 40px;
            margin-top: 20px;
        }

        .btnWish {
            border: 1px solid #030303;
            border-radius: 5px;
            color: white;
            /*padding: 7px 7px 7px 50px;*/
            background: url() left 3px top 3px no-repeat #030303;
            font-weight: 600;
            text-transform: uppercase;
            width: 166px;
            height: 40px;
            margin-left: 40px;
            margin-top: 20px;
        }
    </style>

    <style>
        * {
            box-sizing: border-box;
        }

        .img-zoom-container {
            position: relative;
        }

        .img-zoom-lens {
            position: absolute;
            border: 1px solid #d4d4d4;
            /*set the size of the lens:*/
            width: 40px;
            height: 40px;
            opacity:0;
        }

        .img-zoom-result {
            border: 1px solid #d4d4d4;
            /*set the size of the result div:*/
            width: 400px;
            height: 400px;
            top: 0px;
            position: absolute;
            left: 98%;
            z-index: 99;
        }



        .review .fa {
            font-size: 25px;
        }

        .review .checked {
            color: orange;
        }

        /* Three column layout */
        .review .side {
            float: left;
            width: 15%;
            margin-top:10px;
        }

        .review .middle {
            margin-top:10px;
            float: left;
            width: 70%;
        }

        /* Place text to the right */
        .review .right {
            text-align: right;
        }

        /* Clear floats after the columns */
        /*.row:after {
            content: "";
            display: table;
            clear: both;
        }*/

        /* The bar container */
        .review .bar-container {
            width: 100%;
            background-color: #f1f1f1;
            text-align: center;
            color: white;
        }

        /* Individual bars */
        .review .bar-5 {width: 60%; height: 18px; background-color: #4CAF50;}
        .review .bar-4 {width: 30%; height: 18px; background-color: #2196F3;}
        .review .bar-3 {width: 10%; height: 18px; background-color: #00bcd4;}
        .review .bar-2 {width: 4%; height: 18px; background-color: #ff9800;}
        .review .bar-1 {width: 15%; height: 18px; background-color: #f44336;}

        /* Responsive layout - make the columns stack on top of each other instead of next to each other */
        @media (max-width: 400px) {
            .review .side, .review .middle {
            width: 100%;
            }
            .review .right {
            display: none;
            }
        }
    </style>

    <script>
        function imageZoom(imgID, resultID) {
            var img, lens, result, cx, cy;
            img = document.getElementById(imgID);
            result = document.getElementById(resultID);
            /* Create lens: */
            lens = document.createElement("DIV");
            lens.setAttribute("class", "img-zoom-lens");
            /* Insert lens: */
            img.parentElement.insertBefore(lens, img);
            /* Calculate the ratio between result DIV and lens: */
            cx = result.offsetWidth / lens.offsetWidth;
            cy = result.offsetHeight / lens.offsetHeight;
            cx = 4;
            cy = 4;
            /* Set background properties for the result DIV */
            result.style.backgroundImage = "url('" + img.src + "')";
            //result.style.backgroundRepeat = "no-repeat";
            result.style.backgroundSize = (img.width * cx) + "px " + (img.height * cy) + "px";
            /* Execute a function when someone moves the cursor over the image, or the lens: */
            lens.addEventListener("mousemove", moveLens);
            img.addEventListener("mousemove", moveLens);
            /* And also for touch screens: */
            lens.addEventListener("touchmove", moveLens);
            img.addEventListener("touchmove", moveLens);
            function moveLens(e) {
                var pos, x, y;
                /* Prevent any other actions that may occur when moving over the image */
                e.preventDefault();
                /* Get the cursor's x and y positions: */
                pos = getCursorPos(e);
                /* Calculate the position of the lens: */
                x = pos.x - (lens.offsetWidth / 2);
                y = pos.y - (lens.offsetHeight / 2);
                /* Prevent the lens from being positioned outside the image: */
                if (x > img.width - lens.offsetWidth) { x = img.width - lens.offsetWidth; }
                if (x < 0) { x = 0; }
                if (y > img.height - lens.offsetHeight) { y = img.height - lens.offsetHeight; }
                if (y < 0) { y = 0; }
                if (x <= 0 || y <= 0 || x >= img.width - lens.offsetWidth || y >= img.height - lens.offsetHeight) {
                    result.style.display = 'none';
                } else {
                    result.style.display = 'block';
                }
                /* Set the position of the lens: */
                lens.style.left = x + "px";
                lens.style.top = y + "px";
                /* Display what the lens "sees": */
                result.style.backgroundPosition = "-" + (x * cx) + "px -" + (y * cy) + "px";
            }
            function getCursorPos(e) {
                var a, x = 0, y = 0;
                e = e || window.event;
                /* Get the x and y positions of the image: */
                a = img.getBoundingClientRect();
                /* Calculate the cursor's x and y coordinates, relative to the image: */
                x = e.pageX - a.left;
                y = e.pageY - a.top;
                /* Consider any page scrolling: */
                x = x - window.pageXOffset;
                y = y - window.pageYOffset;
                return { x: x, y: y };
            }
          
        }
        function clearLens() {
            var result = document.getElementById("myresult");
            result.style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="pnlPage" onmouseover="clearLens()" >
        <asp:Repeater ID="rptProduct" runat="server" OnItemDataBound="rptProduct_ItemDataBound" OnItemCommand="rptProduct_ItemCommand">
            <ItemTemplate>
                <div class="row ">
                    <!-- =====  BANNER STRAT  ===== -->
                    <div class="col-sm-12">
                        <div class="breadcrumb ptb_20">
                            <h1><%#Eval("SName")%></h1>
                            <ul>
                                <li><a href="/">Home</a></li>
                                <li><a href="../Category/<%#Eval("CategoryName")%>"><%#Eval("CategoryName")%></a></li>
                                <li class="active"><%#Eval("SName")%></li>
                            </ul>
                        </div>
                    </div>
                    <!-- =====  BREADCRUMB END===== -->
                    <div id="column-left" class="col-sm-4 col-lg-3 hidden-xs">
                        <%--<uc1:UCTopCategory runat="server" ID="UCTopCategory" />--%>
                        <div class="left_banner left-sidebar-widget mt_30 mb_40">
                            <a href="#">
                                <img src="../images/left1.jpg" alt="Left Banner" class="img-responsive" /></a>
                        </div>
                        <uc1:UCTopProducts runat="server" ID="UCTopProducts" />
                        <asp:HiddenField ID="hdnId" runat="server" Value='<%#Eval("idProduct") %>' />
                    </div>
                    <div class="col-sm-8 col-lg-9 mtb_20">
                        <div class="row mt_10 ">
                            <asp:Repeater ID="rptProductImage" runat="server">
                                <HeaderTemplate>
                                    <div class="col-md-6">
                                        <div class="img-zoom-container">
                                            <a class="thumbnails">
                                                <img id="myimage" data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%=MainImage%>" alt="" class="block__pic" />
                                            </a>
                                        </div>
                                        <div id="myresult" class="img-zoom-result"></div>
                                        <div id="product-thumbnail" class="owl-carousel">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="item">

                                        <div class='
                                            <%#
                                                    Convert.ToString(Eval("type"))=="image" 
                                                    ? "image-additional" : "vid"%>
                                            '>
                                            <a class="thumbnail" href='
                                                <%#
                                                    Convert.ToString(Eval("type"))=="image" 
                                                    ? 
                                                    DataLayer.CommonControl.GetAdminUrl()+"/ProductImage/"+ Eval("url") 
                                                    : "https://www.youtube.com/watch?v="+ Eval("name")
                                                %>'
                                                data-fancybox="group1">
                                                <img src='
                                                    <%#
                                                        Convert.ToString(Eval("type"))=="image"
                                                        ? 
                                                        DataLayer.CommonControl.GetAdminUrl()+"/ProductImage/"+Eval("url") 
                                                        : "http://img.youtube.com/vi/"+Eval("name")+"/hqdefault.jpg"
                                                    %>'
                                                    alt="" />
                                            </a>
                                        </div>


                                        <%--

                                        <div class="image-additional <%# string.IsNullOrEmpty(Convert.ToString(Eval("type"))) ?"no-visible" : (Convert.ToString(Eval("type"))=="image"?"visible":"no-visible")%> ">
                                            <a id="img" class="thumbnail" href="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("url")%>" data-fancybox="group1">
                                                <img src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%#Eval("url")%>" alt="" />
                                            </a>
                                        </div>
                                        <div class="vid image-additional <%# string.IsNullOrEmpty(Convert.ToString(Eval("type"))) ?"no-visible" : (Convert.ToString(Eval("type"))=="video"?"visible":"no-visible")%> ">
                                            <a class="thumbnail" href="https://www.youtube.com/watch?v=<%#Eval("name")%>" data-fancybox="group1">
                                                <img src="http://img.youtube.com/vi/<%#Eval("name")%>/hqdefault.jpg" />
                                            </a>
                                        </div>--%>
                                    </div>

                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="col-md-6 prodetail caption product-thumb">
                                <h4 data-name="product_name" class="product-name"><a href="#" title="Casual Shirt With Ruffle Hem">
                                    <%#Eval("SName")%>
                                </a></h4>
                                <div class="rating">
                                    <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                                    <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                                    <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                                    <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-1x"></i></span>
                                    <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i><i class="fa fa-star fa-stack-x"></i></span>
                                </div>
                                <span class="price mb_20">
                                    <span class="amount">
                                        <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                        <%#Eval("PurchasePrice")%>
                                    </span>
                                    <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice")) ? "<span style='display:none'>" :""%>
                                    <span style="text-decoration: line-through; font-size: small;">
                                        <span class="currencySymbol"><%=this.Master.CurrencySymbol %></span>
                                        <%#Eval("ProductPrice")%>
                                    </span>
                                    <br />
                                    <span style="font-size: small;">You Save: <%#Convert.ToDouble(Eval("ProductPrice"))- Convert.ToDouble(Eval("PurchasePrice"))%> (<%#Eval("Discount")%>%)</span>
                                    <%# Convert.ToString(Eval("PurchasePrice")) == Convert.ToString(Eval("ProductPrice"))  ? "</span>" :""%>
                                </span>
                                <hr>
                                <ul class="list-unstyled product_info mtb_20">
                                    <li>
                                        <label>Availability:</label>
                                        <span>In Stock</span></li>
                                </ul>
                                <hr>
                                <p class="product-desc mtb_30">
                                    <%#Eval("Features")%>
                                </p>
                                <div id="product">
                                    <div class="qty mt_30 form-group2">
                                        <label>Qty</label>
                                        <asp:TextBox ID="txtQty" runat="server" type="number" Text="1" min="1"></asp:TextBox>
                                    </div>                                    
                                    <div class="add-to-cart">
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnCartAdd" class="btnCart" runat="server" ClientIDMode="Static" CommandName="CrtAdd" Text="Add to Cart" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnWishlistAdd" class="btnWish" runat="server" ClientIDMode="Static" CommandName="WishAdd" Text="Add to WishList" />
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div style="margin-top: 40px;">
                                        <table style="width:390px;">
                                            <tr style="border-top: 1px solid #ddd;border-bottom:1px solid #ddd;">
                                                <th>
                                                    Item Type :
                                                </th>
                                                <td>
                                                     <a style="color:#77c6b5;font-weight: bold;" href="../products/<%#Eval("MasterCategory")%>"><%#Eval("MasterCategory")%></a>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom:1px solid #ddd;">
                                                <th>Category : </th>                                               
                                                <td>
                                                    <a style="color:#77c6b5;font-weight: bold;" href="../Category/<%#Eval("CategoryName")%>"><%#Eval("CategoryName")%></a>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom:1px solid #ddd;">
                                                <th>Collection : </th>                                               
                                                <td>
                                                    <%#Eval("Collection")%>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom:1px solid #ddd;">
                                                <th>Material : </th>                                               
                                                <td>
                                                    <%#Eval("Material")%>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom:1px solid #ddd;">
                                                <th>GEMSTONE : </th>                                               
                                                <td>
                                                     <%#Eval("gemstone")%>
                                                </td>
                                            </tr>
                                            <tr style="border-bottom:1px solid #ddd;">
                                                <th>GENDER : </th>                                               
                                                <td>
                                                    <%#Eval("gender")%>
                                                </td>
                                            </tr>
                                            
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="heading-part text-center mb_10">
                                    <h2 class="main_title mt_50">Customer reviews</h2>
                                </div>
                                <div class="">
                                    <div class="related-pro">
                                        <div class="review">
                                            <%--<span class="heading">User Rating</span>--%>
                                            <div class="rate-star">
                                                <span class='<%= avgReview > 0 ? "fa fa-star checked" : "fa fa-star" %>'></span>
                                                <span class='<%= avgReview > 1 ? "fa fa-star checked" : "fa fa-star" %>'></span>
                                                <span class='<%= avgReview > 2 ? "fa fa-star checked" : "fa fa-star" %>'></span>
                                                <span class='<%= avgReview > 3 ? "fa fa-star checked" : "fa fa-star" %>'></span>
                                                <span class='<%= avgReview > 4 ? "fa fa-star checked" : "fa fa-star" %>'></span>
                                            </div>
                                            <p class="rate-avg"><%= avgReview %> out of <%= totalReview %></p>
                                            <hr style="border:3px solid #f1f1f1">

                                            <div class="">
                                                <div class="side">
                                                <div>5 star</div>
                                                </div>
                                                <div class="middle">
                                                <div class="bar-container">
                                                    <div class="bar-5"></div>
                                                </div>
                                                </div>
                                                <div class="side right">
                                                <div><%= rate5 %></div>
                                                </div>
                                                <div class="side">
                                                <div>4 star</div>
                                                </div>
                                                <div class="middle">
                                                <div class="bar-container">
                                                    <div class="bar-4"></div>
                                                </div>
                                                </div>
                                                <div class="side right">
                                                <div><%= rate4 %></div>
                                                </div>
                                                <div class="side">
                                                <div>3 star</div>
                                                </div>
                                                <div class="middle">
                                                <div class="bar-container">
                                                    <div class="bar-3"></div>
                                                </div>
                                                </div>
                                                <div class="side right">
                                                <div><%= rate3 %></div>
                                                </div>
                                                <div class="side">
                                                <div>2 star</div>
                                                </div>
                                                <div class="middle">
                                                <div class="bar-container">
                                                    <div class="bar-2"></div>
                                                </div>
                                                </div>
                                                <div class="side right">
                                                <div><%= rate2 %></div>
                                                </div>
                                                <div class="side">
                                                <div>1 star</div>
                                                </div>
                                                <div class="middle">
                                                <div class="bar-container">
                                                    <div class="bar-1"></div>
                                                </div>
                                                </div>
                                                <div class="side right">
                                                <div><%= rate1 %></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="all-review">
                                            <asp:Repeater ID="rptImages" runat="server">
                                                <ItemTemplate>
                                                    <img width="75" data-name="product_image" src="<%=DataLayer.CommonControl.GetAdminUrl() %>/ProductImage/<%# Eval("Name")%>" alt="<%#Eval("Name")%>" />
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="write-review">
                                        <h3>Review this product</h3>
                                        <p>Share your thoughts with other customers</p>
                                        <asp:LinkButton ID="btnReview" CommandName="Review" CssClass="btn" runat="server">Review</asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <uc2:UCRelatedProduct ID="UCRelatedProduct1" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <uc1:UCbrandcarouse runat="server" ID="UCbrandcarouse" />
        <script>
            imageZoom("myimage", "myresult");
        </script>
        <script>
            //$(document).ready(function () {
            //    $('#img').magnificPopup({
            //      //  delegate: 'a',
            //        type: 'image',
            //        closeOnContentClick: false,
            //        closeBtnInside: false,
            //        mainClass: 'mfp-with-zoom mfp-img-mobile',
            //        image: {
            //            verticalFit: true,
            //        },
            //        gallery: {
            //            enabled: true
            //        },
            //        zoom: {
            //            enabled: true,
            //            duration: 300, // don't foget to change the duration also in CSS
            //            opener: function (element) {
            //                return element.find('img');
            //            }
            //        }
            //    })

            //    $('#vid').magnificPopup({
            //       // delegate: 'a',
            //        type: 'iframe',
            //        closeOnContentClick: false,
            //        closeBtnInside: false,
            //        //mainClass: 'mfp-with-zoom mfp-img-mobile',
            //        //image: {
            //        //    verticalFit: true,
            //        //    mainClass: 'mfp-with-zoom mfp-img-mobile',
            //        //    width:'100px',
            //        //        },
            //        iframe: {
            //            verticalFit: true,
            //            markup: '<div class="mfp-iframe-scaler">' +
            //            '<div class="mfp-close"></div>' +
            //            '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>' +
            //          '</div>', // HTML markup of popup, `mfp-close` will be replaced by the close button

            //            patterns: {
            //                youtube: {
            //                    index: 'youtube.com/', // String that detects type of video (in this case YouTube). Simply via url.indexOf(index).

            //                    id: 'v=', // String that splits URL in a two parts, second part should be %id%
            //                    // Or null - full URL will be returned
            //                    // Or a function that should return %id%, for example:
            //                    // id: function(url) { return 'parsed id'; } 

            //                    src: '//www.youtube.com/embed/%id%?autoplay=1' // URL that will be set as a source for iframe. 
            //                },
            //                vimeo: {
            //                    index: 'vimeo.com/',
            //                    id: '/',
            //                    src: '//player.vimeo.com/video/%id%?autoplay=1'
            //                },
            //                gmaps: {
            //                    index: '//maps.google.',
            //                    src: '%id%&output=embed'
            //                }

            //                // you may add here more sources

            //            },

            //            srcAction: 'iframe_src', // Templating object key. First part defines CSS selector, second attribute. "iframe_src" means: find "iframe" and set attribute "src".
            //        },
            //        gallery: {
            //            enabled: true
            //        },
            //        zoom: {
            //            enabled: true,
            //            duration: 300, // don't foget to change the duration also in CSS
            //            opener: function (element) {
            //                return element.find('iframe');
            //            }
            //        }



            //    })

            //})
            //function mouseOver() {
            //    document.getElementById('pic').style.width = "900px";
            //    document.getElementById('pic').style.height = "506px";
            //}
            //jQuery(document).ready(function () {
            //    jQuery('#product-thumbnail').magnificPopup({
            //        delegate: 'a',
            //        type: 'image',
            //        closeOnContentClick: false,
            //        closeBtnInside: false,
            //        callbacks: {
            //            elementParse: function (item) {
            //                // Function will fire for each target element
            //                // "item.el" is a target DOM element (if present)
            //                // "item.src" is a source that you may modify
            //                console.log(item.el.context.className);
            //                if (item.el.context.className == 'video') {
            //                    item.type = 'iframe',

            //                    item.iframe = {
            //                        markup: '<div class="mfp-iframe-scaler">' + '<div class="mfp-close"></div>' + '<iframe class="mfp-iframe" frameborder="0" allowfullscreen></iframe>' + '</div>', // HTML markup of popup, `mfp-close` will be replaced by the close button
            //                        patterns: {
            //                            youtube: {
            //                                index: 'youtube.com/', // String that detects type of video (in this case YouTube). Simply via url.indexOf(index).

            //                                id: 'v=', // String that splits URL in a two parts, second part should be %id%
            //                                // Or null - full URL will be returned
            //                                // Or a function that should return %id%, for example:
            //                                // id: function(url) { return 'parsed id'; } 

            //                                src: '//www.youtube.com/embed/%id%?autoplay=1' // URL that will be set as a source for iframe. 
            //                            },
            //                            vimeo: {
            //                                index: 'vimeo.com/',
            //                                id: '/',
            //                                src: '//player.vimeo.com/video/%id%?autoplay=1'
            //                            },
            //                            gmaps: {
            //                                index: '//maps.google.',
            //                                src: '%id%&output=embed'
            //                            }
            //                        }

            //                        //srcAction: 'iframe_src', // Templating object key. First part defines CSS selector, second attribute. "iframe_src" means: find "iframe" and set attribute "src".
            //                    }
            //                    item.src = {
            //                        srcAction: 'iframe_src',
            //                    }

            //                } else {
            //                    item.type = 'image',
            //                    item.tLoading = 'Loading image #%curr%...',
            //                    item.mainClass = 'mfp-with-zoom mfp-img-mobile',
            //                     item.closeOnContentClick = {
            //                         closeOnContentClick: false,
            //                     }
            //                    item.closeBtnInside = {
            //                        closeBtnInside: false,
            //                    }
            //                    item.image = {
            //                        verticalFit: true,
            //                        tError: '<a href="%url%">The image #%curr%</a> could not be loaded.'
            //                    }                         

            //                }

            //            }
            //        },
            //        gallery: {
            //            enabled: true,
            //            navigateByImgClick: true,
            //            preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
            //        }


            //    });

            //});


        </script>
    </div>

</asp:Content>
