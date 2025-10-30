function Successmsg() {
    var str = $('#hdMessage').val();
    var msgHead = str.split("|")[0];
    var msg = str.split("|")[1];
    $.toast({
        heading: msgHead,
        text: msg,
        position: 'top-center',
        loaderBg: '#ff6849',
        icon: 'success',
        hideAfter: 5000,
        stack: 6
    });

}

function Errormsg() {
    var str = $('#hdMessage').val();
    var msgHead = str.split("|")[0];
    var msg = str.split("|")[1];
    $.toast({
        heading: msgHead,
        text: msg,
        position: 'top-center',
        loaderBg: '#ff6849',
        icon: 'error',
        hideAfter: 5000
    });
}