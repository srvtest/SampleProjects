$(document).ready(function () {
    $('#date').bootstrapMaterialDatePicker
			({
			    time: false,
			    clearButton: true
			});
    $('#date1').bootstrapMaterialDatePicker
			({
			    time: false,
			    clearButton: false
			});
    $('#date2').bootstrapMaterialDatePicker
			({
			    time: false,
			    clearButton: true
			});
    $('#dateOfBirth').bootstrapMaterialDatePicker
			({
			    time: false,
			    clearButton: true
			});

    $('#therapyDate').bootstrapMaterialDatePicker
			({
			    time: false,
			    clearButton: true
			});

    $('#time').bootstrapMaterialDatePicker
			({
			    date: false,
			    shortTime: false,
			    format: 'HH:mm'
			});
    $('#time2').bootstrapMaterialDatePicker
			({
			    date: false,
			    shortTime: false,
			    format: 'HH:mm'
			});

    $('#date-format').bootstrapMaterialDatePicker
			({
			    format: 'dddd DD MMMM YYYY - HH:mm'
			});
    $('#date-fr').bootstrapMaterialDatePicker
			({
			    format: 'DD/MM/YYYY HH:mm',
			    lang: 'fr',
			    weekStart: 1,
			    cancelText: 'ANNULER',
			    nowButton: true,
			    switchOnClick: true
			});

    $('#date-end').bootstrapMaterialDatePicker
			({
			    weekStart: 0, format: 'DD/MM/YYYY HH:mm'
			});
    $('#date-start').bootstrapMaterialDatePicker
			({
			    weekStart: 0, format: 'DD/MM/YYYY HH:mm', shortTime: true
			}).on('change', function (e, date) {
			    $('#date-end').bootstrapMaterialDatePicker('setMinDate', date);
			});

    $('#min-date').bootstrapMaterialDatePicker({ format: 'DD/MM/YYYY HH:mm', minDate: new Date() });



    //----------------- user code --------------------//

    $(".datepickerFrom").bootstrapMaterialDatePicker({
        time: false,
        clearButton: false,
        weekStart: 0,
        minDate: new Date(),
        format: 'MM/DD/YYYY'
    }).on('change', function (e, date) {
        $('.datepickerTo').bootstrapMaterialDatePicker('setMinDate', date);
        $('.datepickerCheckin').bootstrapMaterialDatePicker('setMinDate', date);
    });

    $(".datepickerTo").bootstrapMaterialDatePicker({
        time: false,
        clearButton: false,
        minDate: new Date(),
        format: 'MM/DD/YYYY'
    }).on('change', function (e, date) {
        $('.datepickerFrom').bootstrapMaterialDatePicker('setMaxDate', date);
        $('.datepickerCheckin').bootstrapMaterialDatePicker('setMaxDate', date);
    });

    $(".datepickerCheckin").bootstrapMaterialDatePicker({
        time: false,
        clearButton: false,
        minDate: $(".datepickerFrom").val(),
        maxDate: $(".datepickerTo").val(),
        format: 'MM/DD/YYYY'
    });

    $(".timepicker10").bootstrapMaterialDatePicker({
        date: false,
        clearButton: false,
        format: 'hh:mm A'
    });

    $('.txtFromDate').click(function () {
        $(".ddCategory").val("0");
        $(".ddRoomNo").val("0");
    });
    $('.txtTodate').click(function () {
        var validate = $('.txtCheckinDate').val();
        if (validate == null || validate == '') {
            $(".ddCategory").val("0");
            $(".ddRoomNo").val("0");
        }
    });

    $(".datepickerAll").bootstrapMaterialDatePicker({
        time: false,
        clearButton: false,
        weekStart: 0,
        format: 'MM/DD/YYYY'
    });
});