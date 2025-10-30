function validation($form, $setScroll) {
    var $formId = $($form);
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    var regUrl = /^(((http|ftp|https){1}(:[/][/]){1})|((www.){1}))[-a-zA-Z0-9@:%_\+.~#?&//=]+$/;

    $('span.ni-error').remove();
    $('div.has-error').removeClass("has-error");
    $('.required', $formId).each(function () {
        var isAnyError = false;
        var $parentTag = $(this).parent(); if (!$parentTag.hasClass("form-group")) $parentTag = $parentTag.parent();
        var inputVal = $(this).val();
        var hiddenclass = $(this).attr("responsivehideclass");
        if (inputVal == '' && !$(this).hasClass("combo")) {
            $msg = $(this).attr("reqerrormsg");
            isAnyError = true;
        } else {
            if ($(this).hasClass('combo') == true && $(this).prop("tagName") == "SELECT") {
                if (inputVal == '0' || inputVal == '' || inputVal == null) {
                    $msg = $(this).attr("reqerrormsg");
                    isAnyError = true;
                }
            }
            if ($(this).hasClass('password') == true) {
                var password1 = $(this).val();
                var password2 = $('#' + $(this).attr("passcheck")).val();
                if (password1 != password2 && (password1 != "" || password2 != "")) {
                    $("span.ni-error", $parentTag).remove();
                    $msg = "Passwords do not match";
                    isAnyError = true;
                    hiddenclass = "";
                }
            }
            if ($(this).hasClass('space') == true) {
                if (inputVal.indexOf(" ") != -1) {
                    $msg = "Space not allowed.";
                    $("span.ni-error", $parentTag).remove();
                    isAnyError = true;
                    hiddenclass = "";
                }
            }
            if ($(this).hasClass('characterlength') == true) {
                var minchar = $(this).attr("mincharlength");
                var maxchar = $(this).attr("maxcharlength");
                if (maxchar!=undefined && parseInt(maxchar) > 0 && inputVal.length > parseInt(maxchar)) {
                    $msg = "It should not more then " + maxchar + " char long.";
                    $("label.ni-error", $parentTag).remove();
                    isAnyError = true;
                    hiddenclass = "";
                }
                if (minchar != undefined && parseInt(minchar) > 0 && inputVal.length < parseInt(minchar)) {
                    $msg = "It should be minimum " + minchar + " char long.";
                    $("label.ni-error", $parentTag).remove();
                    isAnyError = true;
                    hiddenclass = "";
                }
            }
        }
        if (isAnyError) {
            var $witherrormsg = $("<span class='control-label ni-error help-block " + (hiddenclass != undefined ? hiddenclass : "") + "' for='inputError'><i class='fa fa-times-circle-o'></i>" + $msg + "</span>");
            var $noerromsg = $("<span class='control-label ni-error help-block' for='inputError'></span>");
            $parentTag.addClass("has-error").append($msg != undefined ? $witherrormsg : $noerromsg);
        }
    });
    $('.matchcase', $formId).each(function () {
        var isAnyError = false;
        var $parentTag = $(this).parent(); if (!$parentTag.hasClass("form-group")) $parentTag = $parentTag.parent();
        var inputVal = $(this).val();
        var hiddenclass = $(this).attr("responsivehideclass");
        if (inputVal != "" && $(this).hasClass('space') == true) {
            if (inputVal.indexOf(" ") != -1) {
                $msg = "Space not allowed.";
                $("span.ni-error", $parentTag).remove();
                isAnyError = true;
                hiddenclass = "";
            }
        }
        if (inputVal != "" &&  $(this).hasClass('characterlength') == true) {
            var minchar = $(this).attr("mincharlength");
            var maxchar = $(this).attr("maxcharlength");
            if (maxchar != undefined && parseInt(maxchar) > 0 && inputVal.length > parseInt(maxchar)) {
                $msg = "It should not more then " + maxchar + " char long.";
                $("label.ni-error", $parentTag).remove();
                isAnyError = true;
                hiddenclass = "";
            }
            if (minchar != undefined && parseInt(minchar) > 0 && inputVal.length < parseInt(minchar)) {
                $msg = "It should be minimum " + minchar + " char long.";
                $("label.ni-error", $parentTag).remove();
                isAnyError = true;
                hiddenclass = "";
            }
        }
        if (isAnyError) {
            var $witherrormsg = $("<span class='control-label ni-error help-block " + (hiddenclass != undefined ? hiddenclass : "") + "' for='inputError'><i class='fa fa-times-circle-o'></i>" + $msg + "</span>");
            var $noerromsg = $("<span class='control-label ni-error help-block' for='inputError'></span>");
            $parentTag.addClass("has-error").append($msg != undefined ? $witherrormsg : $noerromsg);
        }
    });
    $('.email', $formId).each(function () {
        var isAnyError = false;
        var $parentTag = $(this).parent(); if (!$parentTag.hasClass("form-group")) $parentTag = $parentTag.parent();
        var inputVal = $(this).val();
        var hiddenclass = $(this).attr("responsivehideclass");
        if (inputVal != "" && !emailReg.test(inputVal)) {
            $msg = "Enter Valid E-Mail.";
            $("span.ni-error", $parentTag).remove();
            isAnyError = true;
            hiddenclass = "";
        }
        if (isAnyError) {
            var $witherrormsg = $("<span class='control-label ni-error help-block " + (hiddenclass != undefined ? hiddenclass : "") + "' for='inputError'><i class='fa fa-times-circle-o'></i>" + $msg + "</span>");
            var $noerromsg = $("<span class='control-label ni-error help-block' for='inputError'></span>");
            $parentTag.addClass("has-error").append($msg != undefined ? $witherrormsg : $noerromsg);
        }
    });
    $('.mobile', $formId).each(function () {
        var isAnyError = false;
        var $parentTag = $(this).parent(); if (!$parentTag.hasClass("form-group")) $parentTag = $parentTag.parent();
        var inputVal = $(this).val();
        var hiddenclass = $(this).attr("responsivehideclass");
        if (inputVal != "") {
            if (parse_Int(inputVal) > 999999999 && parse_Int(inputVal) < 10000000000) {
                isAnyError = false;
            } else {
                $msg = "Enter Valid 10 digit Mobile No.";
                $("span.ni-error", $parentTag).remove();
                isAnyError = true;
                hiddenclass = "";
            }
        }
        if (isAnyError) {
            var $witherrormsg = $("<span class='control-label ni-error help-block " + (hiddenclass != undefined ? hiddenclass : "") + "' for='inputError'><i class='fa fa-times-circle-o'></i>" + $msg + "</span>");
            var $noerromsg = $("<span class='control-label ni-error help-block' for='inputError'></span>");
            $parentTag.addClass("has-error").append($msg != undefined ? $witherrormsg : $noerromsg);
        }
    });
    if ($('span.ni-error').length > 0) {
        if ($setScroll) {
            p = $('span.ni-error:first').offset();
            $(document).scrollTop(p.top - 50);
        }
        return false;
    }
    else {
        return true;
    }
    return false;
}

$(document).ready(function () {
    $('form').bind(' reset', function () {
        $.each($(this).find("select").is(":hidden"), function () {
            $.uniform.update($(this));
        });
    });
});