<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="HotalManagment.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="robots" content="noindex, nofollow">

    <title>Calendar Design - Bootsnipp.com</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet">
    <link href="css/styles.css" rel="stylesheet" type="text/css" />
	
    <script src="https://code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
    <script type="text/javascript">
        window.alert = function () { };
        var defaultCSS = document.getElementById('bootstrap-css');
        function changeCSS(css) {
            if (css) $('head > link').filter(':first').replaceWith('<link rel="stylesheet" href="' + css + '" type="text/css" />');
            else $('head > link').filter(':first').replaceWith(defaultCSS);
        }
        $(document).ready(function () {
            var iframe_height = parseInt($('html').height());
            window.parent.postMessage(iframe_height, 'https://bootsnipp.com');
        });

//        function GetEvents() {
//            /* GetEvents Data from Database */
//            alert(55);
//            $.ajax({
//                method: "POST",
//                dataType: "json",
//                ContentType: "application/json;charset=utf-8",
//                success: function (result) {
//                    alert("success");
//                },
//                error: function (err) {
//                    alert("error");
//                }
//            });
//        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

    <link href="https://fonts.googleapis.com/css?family=Roboto:100,100i,300,300i,400,400i,500,500i,700,700i,900,900i" rel="stylesheet">

    <script src="/js/customs.js" type="text/javascript"></script>
    <%--<script type="text/javascript">
    $(document).ready(function() {
	    var date = new Date();
		var d = date.getDate();
		var m = date.getMonth();
		var y = date.getFullYear();
		
		/*  className colors
		
		className: default(transparent), important(red), chill(pink), success(green), info(blue)
		
		*/		
		
		  
		/* initialize the external events
		-----------------------------------------------------------------*/
	
		$('#external-events div.external-event').each(function() {
		
			// create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
			// it doesn't need to have a start or end
			var eventObject = {
				title: $.trim($(this).text()) // use the element's text as the event title
			};
			
			// store the Event Object in the DOM element so we can get to it later
			$(this).data('eventObject', eventObject);
			
			// make the event draggable using jQuery UI
			$(this).draggable({
				zIndex: 999,
				revert: true,      // will cause the event to go back to its
				revertDuration: 0  //  original position after the drag
			});
			
		});
	
	
		/* initialize the calendar
		-----------------------------------------------------------------*/
		
		var calendar =  $('#calendar').fullCalendar({
			header: {
				left: 'title',
				center: 'agendaDay,agendaWeek,month',
				right: 'prev,next today'
			},
			editable: true,
			firstDay: 1, //  1(Monday) this can be changed to 0(Sunday) for the USA system
			selectable: true,
			defaultView: 'month',
			
			axisFormat: 'h:mm',
			columnFormat: {
                month: 'ddd',    // Mon
                week: 'ddd d', // Mon 7
                day: 'dddd M/d',  // Monday 9/7
                agendaDay: 'dddd d'
            },
            titleFormat: {
                month: 'MMMM yyyy', // September 2009
                week: "MMMM yyyy", // September 2009
                day: 'MMMM yyyy'                  // Tuesday, Sep 8, 2009
            },
			allDaySlot: false,
			selectHelper: true,
			select: function(start, end, allDay) {
				var title = prompt('Event Title:');
				if (title) {
					calendar.fullCalendar('renderEvent',
						{
							title: title,
							start: start,
							end: end,
							allDay: allDay
						},
						true // make the event "stick"
					);
				}
				calendar.fullCalendar('unselect');
			},
			droppable: true, // this allows things to be dropped onto the calendar !!!
			drop: function(date, allDay) { // this function is called when something is dropped
				// retrieve the dropped element's stored Event Object
				var originalEventObject = $(this).data('eventObject');
				
				// we need to copy it, so that multiple events don't have a reference to the same object
				var copiedEventObject = $.extend({}, originalEventObject);
				
				// assign it the date that was reported
				copiedEventObject.start = date;
				copiedEventObject.allDay = allDay;
				
				// render the event on the calendar
				// the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
				$('#calendar').fullCalendar('renderEvent', copiedEventObject, true);
				
				// is the "remove after drop" checkbox checked?
				if ($('#drop-remove').is(':checked')) {
					// if so, remove the element from the "Draggable Events" list
					$(this).remove();
				}
				
			},
			
			events: [
				{
					title: 'All Day Event',
					start: new Date(y, m, 1)
				},
				{
					id: 999,
					title: 'Repeating Event',
					start: new Date(y, m, d-3, 16, 0),
					allDay: false,
					className: 'info'
				},
				{
					id: 999,
					title: 'Repeating Event',
					start: new Date(y, m, d+4, 16, 0),
					allDay: false,
					className: 'info'
				},
				{
					title: 'Meeting',
					start: new Date(y, m, d, 10, 30),
					allDay: false,
					className: 'important'
				},
				{
					title: 'Lunch',
					start: new Date(y, m, d, 12, 0),
					end: new Date(y, m, d, 14, 0),
					allDay: false,
					className: 'important'
				},
				{
					title: 'Birthday Party',
					start: new Date(y, m, d+1, 19, 0),
					end: new Date(y, m, d+1, 22, 30),
					allDay: false,
				},
				{
					title: 'Click for Google',
					start: new Date(y, m, 28),
					end: new Date(y, m, 29),
					url: 'http://google.com/',
					className: 'success'
				}
			],			
		});
		
		
	});

    </script>--%>

<style>

	body {
	    margin-bottom: 40px;
		margin-top: 40px;
		text-align: center;
		font-size: 14px;
		font-family: 'Roboto', sans-serif;
		background:url(http://www.digiphotohub.com/wp-content/uploads/2015/09/bigstock-Abstract-Blurred-Background-Of-92820527.jpg);
		}
		
	#wrap {
		width: 1100px;
		margin: 0 auto;
		}
		
	#external-events {
		float: left;
		width: 150px;
		padding: 0 10px;
		text-align: left;
		}
		
	#external-events h4 {
		font-size: 16px;
		margin-top: 0;
		padding-top: 1em;
		}
		
	.external-event { /* try to mimick the look of a real event */
		margin: 10px 0;
		padding: 2px 4px;
		background: #3366CC;
		color: #fff;
		font-size: .85em;
		cursor: pointer;
		}
		
	#external-events p {
		margin: 1.5em 0;
		font-size: 11px;
		color: #666;
		}
		
	#external-events p input {
		margin: 0;
		vertical-align: middle;
		}

	#calendar {
/* 		float: right; */
        margin: 0 auto;
		width: 900px;
		background-color: #FFFFFF;
		  border-radius: 6px;
        box-shadow: 0 1px 2px #C3C3C3;
		-webkit-box-shadow: 0px 0px 21px 2px rgba(0,0,0,0.18);
-moz-box-shadow: 0px 0px 21px 2px rgba(0,0,0,0.18);
box-shadow: 0px 0px 21px 2px rgba(0,0,0,0.18);
		}

</style>
    <div id="wrap">

<div id="calendar" class="fc fc-ltr">

<table class="fc-header" style="width:100%">
<tbody>
<tr>
<td class="fc-header-left"><span class="fc-header-title"><h2>January 2018</h2></span></td>
<td class="fc-header-center"><span class="fc-button fc-button-agendaDay fc-state-default fc-corner-left" unselectable="on">day</span><span class="fc-button fc-button-agendaWeek fc-state-default" unselectable="on">week</span><span class="fc-button fc-button-month fc-state-default fc-corner-right fc-state-active" unselectable="on">month</span></td>
<td class="fc-header-right"><span class="fc-button fc-button-prev fc-state-default fc-corner-left" unselectable="on"><span class="fc-text-arrow">‹</span></span><span class="fc-button fc-button-next fc-state-default fc-corner-right" unselectable="on"><span class="fc-text-arrow">›</span></span><span class="fc-header-space"></span><span class="fc-button fc-button-today fc-state-default fc-corner-left fc-corner-right fc-state-disabled" unselectable="on">today</span></td>
</tr>
</tbody>
</table>

<div class="fc-content" style="position: relative;">
<div class="fc-view fc-view-month fc-grid" style="position:relative" unselectable="on">
<div class="fc-event-container" style="position:absolute;z-index:8;top:0;left:0">
<div class="fc-event fc-event-hori fc-event-draggable fc-event-start fc-event-end" style="position: absolute; left: 2px; width: 124px; top: 67px;">
<div class="fc-event-inner"><span class="fc-event-title">All Day Event</span>
</div>
<div class="ui-resizable-handle ui-resizable-e">&nbsp;&nbsp;&nbsp;
</div>
</div>
<div class="fc-event fc-event-hori fc-event-draggable fc-event-start fc-event-end info" style="position: absolute; left: 771px; width: 127px; top: 414px;">
<div class="fc-event-inner"><span class="fc-event-time">4p</span><span class="fc-event-title">Repeating Event</span>
</div>
<div class="ui-resizable-handle ui-resizable-e">&nbsp;&nbsp;&nbsp;</div>
</div>
<div class="fc-event fc-event-hori fc-event-draggable fc-event-start fc-event-end info" style="position: absolute; left: 771px; width: 127px; top: 492px;">
<div class="fc-event-inner"><span class="fc-event-time">4p</span><span class="fc-event-title">Repeating Event</span></div>
<div class="ui-resizable-handle ui-resizable-e">&nbsp;&nbsp;&nbsp;</div>
</div>
<div class="fc-event fc-event-hori fc-event-draggable fc-event-start fc-event-end important" style="position: absolute; left: 259px; width: 123px; top: 492px;">
<div class="fc-event-inner"><span class="fc-event-time">10:30a</span><span class="fc-event-title">Meeting</span></div><div class="ui-resizable-handle ui-resizable-e">&nbsp;&nbsp;&nbsp;</div></div><div class="fc-event fc-event-hori fc-event-draggable fc-event-start fc-event-end important" style="position: absolute; left: 259px; width: 123px; top: 520px;"><div class="fc-event-inner"><span class="fc-event-time">12p</span><span class="fc-event-title">Lunch</span></div><div class="ui-resizable-handle ui-resizable-e">&nbsp;&nbsp;&nbsp;</div></div><div class="fc-event fc-event-hori fc-event-draggable fc-event-start fc-event-end" style="position: absolute; left: 387px; width: 123px; top: 492px;"><div class="fc-event-inner"><span class="fc-event-time">7p</span><span class="fc-event-title">Birthday Party</span></div><div class="ui-resizable-handle ui-resizable-e">&nbsp;&nbsp;&nbsp;</div></div><a href="http://google.com/" class="fc-event fc-event-hori fc-event-draggable fc-event-start success" style="position: absolute; left: 771px; width: 129px; top: 386px;"><div class="fc-event-inner"><span class="fc-event-title">Click for Google</span></div></a><a href="http://google.com/" class="fc-event fc-event-hori fc-event-draggable fc-event-end success" style="position: absolute; left: 0px; width: 126px; top: 492px;"><div class="fc-event-inner"><span class="fc-event-title">Click for Google</span></div><div class="ui-resizable-handle ui-resizable-e">&nbsp;&nbsp;&nbsp;</div></a></div>

</div>
</div>
</div>

<div style="clear:both"></div>
</div>
    <%--<script src="js/calendar.js" type="text/javascript"></script>--%>
   	
    <%--<script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.12/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/rowreorder/1.2.3/js/dataTables.rowReorder.min.js"></script>
    <script type="text/javascript" src=" https://cdn.datatables.net/responsive/2.2.1/js/dataTables.responsive.min.js" ></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var table = $('#example').DataTable({             
                responsive: true
            });
        });
    </script>--%>
    </form>
</body>
</html>
